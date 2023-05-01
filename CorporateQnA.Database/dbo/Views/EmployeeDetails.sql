
create View [dbo].[EmployeeDetails] as
SELECT Employee.Id, CONCAT(Employee.FirstName, ' ', Employee.LastName) as Name,  Designation.Title AS Designation, Department.Title AS Department, Location.Name AS Location, 
       COALESCE(qa.QuestionsAsked, 0) AS NumberOfQuestionsAsked, 
       COALESCE(qs.QuestionsSolved, 0) AS NumberOfQuestionsSolved, 
       COALESCE(qn.QuestionsAnswered, 0) AS NumberOfQuestionsAnswered,
       COALESCE(eqa.UpvotesRecieved, 0) AS NumberOfUpvotesRecieved,
       COALESCE(eqa.DownvotesRecieved, 0) AS NumberOfDownvotesRecieved
FROM Employee
INNER JOIN Designation ON Employee.DesignationId =  Designation.Id
INNER JOIN Department ON Employee.DepartmentId = Department.Id
INNER JOIN Location ON Employee.LocationId = Location.Id
LEFT JOIN (
  SELECT CreatedBy, COUNT(*) AS QuestionsAsked
  FROM Question
  GROUP BY CreatedBy
) qa ON Employee.Id = qa.CreatedBy
LEFT JOIN (
  SELECT CreatedBy, COUNT(*) AS QuestionsSolved
  FROM Question
  WHERE Id IN (
    SELECT QuestionId
    FROM Answer
    WHERE IsBestSolution = 1
  )
  GROUP BY CreatedBy
) qs ON Employee.Id = qs.CreatedBy
LEFT JOIN (
  SELECT AnsweredBy, COUNT(distinct QuestionId) AS QuestionsAnswered
  FROM Answer
  GROUP BY AnsweredBy
) qn ON Employee.Id = qn.AnsweredBy
LEFT JOIN (
  SELECT EmployeeId, SUM(CASE WHEN VoteStatus = 1 THEN 1 ELSE 0 END) AS UpVotesRecieved,
                          SUM(CASE WHEN VoteStatus = 2 THEN 1 ELSE 0 END) AS DownVotesRecieved
  FROM EmployeeAnswerActivity
  GROUP BY EmployeeId
) eqa ON Employee.Id = eqa.EmployeeId
