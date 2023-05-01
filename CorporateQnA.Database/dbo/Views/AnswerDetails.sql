
Create view [dbo].[AnswerDetails] as
SELECT 
    Answer.Id,
	Answer.QuestionId,
    Answer.Description,
    Answer.AnsweredBy AS EmployeeId,
    Employee.FirstName + ' ' + Employee.LastName AS EmployeeName,
    COALESCE(Answer.IsBestSolution, 0) as IsBestSolution,
    Answer.AnsweredOn,
    (SELECT COUNT(*) FROM [dbo].[EmployeeAnswerActivity] WHERE [AnswerId] = Answer.Id AND [VoteStatus] = 1) AS NumberOfUpVotes,
    (SELECT COUNT(*) FROM [dbo].[EmployeeAnswerActivity] WHERE [AnswerId] = Answer.Id AND [VoteStatus] = 2) AS NumberOfDownVotes
FROM 
    Answer
    INNER JOIN Employee ON Answer.AnsweredBy = Employee.Id
