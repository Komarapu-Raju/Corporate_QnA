
Create view [dbo].[QuestionDetails] as
SELECT Question.Id, Question.CreatedBy as EmployeeId, CONCAT(Employee.FirstName, ' ', Employee.LastName) as EmployeeName, Question.Title, Question.Description, category.Title as CategoryName,
       COUNT(DISTINCT EmployeeQuestionActivity.EmployeeId) as NumberOfViews, COUNT(DISTINCT Answer.Id) as NumberOfAnswers,
       MAX(CASE WHEN Answer.IsBestSolution = 1 THEN 1 ELSE 0 END) as IsSolved, Question.CreatedOn, 
       SUM(CASE WHEN EmployeeQuestionActivity.VoteStatus = 1 THEN 1 ELSE 0 END) as NumberOfUpVotes
FROM Question
INNER JOIN Employee ON Question.CreatedBy = Employee.Id
LEFT JOIN EmployeeQuestionActivity ON Question.Id = EmployeeQuestionActivity.QuestionId
LEFT JOIN Answer ON Question.Id = Answer.QuestionId
left join Category on Question.CategoryId = Category.Id
GROUP BY Question.Id, Question.CreatedBy, CONCAT(Employee.FirstName, ' ', Employee.LastName), Question.Title, Question.Description, Question.CreatedOn, category.Title;
