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

        public QuestionDetailsView GetQuestionById(Guid questionId)
        {
            return this._db.Get<QuestionDetailsView>(questionId);
        }

        public IEnumerable<QuestionDetailsView> GetAllQuestions(Guid currentEmployeeId)
        {
            return this._db.Query<QuestionDetailsView>("GetQuestionDetails", new { employeeId = currentEmployeeId}, commandType: CommandType.StoredProcedure).ToList();
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId,Guid currentEmployeeId)
        {
            return this.GetAllQuestions(currentEmployeeId).Where(item => item.EmployeeId == employeeId);
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId,Guid currentEmployeeId)
        {
            var answerList = _answerService.GetAnswersByEmployeeId(employeeId);
            return answerList.Select(answer => GetQuestionById(answer.QuestionId));
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
