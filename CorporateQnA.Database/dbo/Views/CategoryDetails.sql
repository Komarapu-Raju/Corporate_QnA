
create view [dbo].[CategoryDetails] As
SELECT Category.Id as Id ,Category.Title as Name,Category.Description,
       COUNT(Question.Id) AS TotalNumberOfTags,
	   SUM(CASE WHEN DATEDIFF(WEEK, Question.CreatedOn, GETDATE()) = 0 THEN 1 ELSE 0 END) AS NumberOfTagsThisWeek,
       SUM(CASE WHEN DATEDIFF(MONTH, Question.CreatedOn, GETDATE()) = 0 THEN 1 ELSE 0 END) AS NumberOfTagsThisMonth   
FROM Question
RIGHT JOIN Category ON Question.CategoryId = Category.Id
GROUP BY Category.Id,Category.Title,Category.Description;
