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

        public QuestionService(ApplicationDbContext db)
        {
            this._db = db.GetConnection();
        }
        public long AddQuestion(Question question)
        {
           return this._db.Insert(question);
        }

        public QuestionDetailsView GetQuestionById(Guid questionId)
        {
            return this._db.Get<QuestionDetailsView>(questionId);
        }

        public IEnumerable<QuestionDetailsView> GetQuestionList()
        {
            return this._db.GetAll<QuestionDetailsView>();
        }

        public IEnumerable<Question> GetQuestionsAnsweredByEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsAskedByEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
