using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IDbConnection _db;

        private readonly IAnswerService _answerService;

        public QuestionService(ApplicationDbContext db, IAnswerService _answerService)
        {
            this._db = db.GetConnection();
            this._answerService = _answerService;
        }
        public long AddQuestion(Question question)
        {
           return this._db.Insert(question);
        }

        public QuestionDetailsView GetQuestionById(Guid questionId)
        {
            return this._db.Get<QuestionDetailsView>(questionId);
        }

        public IEnumerable<QuestionDetailsView> GetAllQuestion()
        {
            return this._db.GetAll<QuestionDetailsView>();
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId)
        {
            var answerList = this._answerService.GetAnswersByEmployeeId(employeeId);
            return answerList.Select(answer => GetQuestionById(answer.QuestionId));
        }

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId)
        {
            return this.GetAllQuestion().Where(item => item.EmployeeId == employeeId);
        }
    }
}
