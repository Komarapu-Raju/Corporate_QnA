using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;
using CorporateQnA.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IDbConnection _db;

        private readonly IAnswerService _answerService;

        public QuestionService(ApplicationDbContext db, IAnswerService answerService)
        {
            this._db = db.GetConnection();
            this._answerService = answerService;
        }

        public void AddQuestion(Question question)
        {
            this._db.Insert(question);
        }

        public QuestionDetailsView GetQuestionById(Guid questionId, Guid currentEmployeeId)
        {
            return this._db.QuerySingleOrDefault<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId and Id = @questionId", new { currentEmployeeId = currentEmployeeId, questionId = questionId });
        }

        public IEnumerable<QuestionDetailsView> GetAllQuestions(Guid currentEmployeeId)
        {
            return this._db.Query<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId", new { currentEmployeeId = currentEmployeeId }); ;
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId, Guid currentEmployeeId)
        {
            return this._db.Query<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId and EmployeeId = @questionId", new { currentEmployeeId = currentEmployeeId, employeeId = employeeId }).ToList(); 
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId, Guid currentEmployeeId)
        {
            var answerList = _answerService.GetAnswersByEmployeeId(employeeId, currentEmployeeId);

            var answers = answerList.Select(answer => GetQuestionById(answer.QuestionId, currentEmployeeId)).GroupBy(question => question.Id).Select(group => group.First()).ToList();

            return answers;
        }

        public void AddQuestionActivity(EmployeeQuestionActivity newActivity)
        {
            var existingActivity = this._db.QueryFirstOrDefault("Select * from EmployeeQuestionActivity Where EmployeeId = @employeeId and QuestionId = @questionId", new { employeeId = newActivity.EmployeeId, questionId = newActivity.QuestionId });
            if (existingActivity != null)
            {
                newActivity.Id = existingActivity.Id;
                this._db.Update(newActivity);
            }
            else
            {
                this._db.Insert(newActivity);
            }
        }
    }
}
