using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IDbConnection _db;

        public AnswerService(ApplicationDbContext db)
        {
            this._db = db.GetConnection();
        }
        public long AddAnswer(Answer answer)
        {
            return this._db.Insert(answer);
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(Guid questionId)
        {
            return this._db.GetAll<AnswerDetailsView>().Where(item => item.QuestionId == questionId);
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByEmployeeId(Guid employeeId)
        {
            return this._db.GetAll<AnswerDetailsView>().Where(item => item.EmployeeId == employeeId);
        }

        public void VoteAnswer()
        {
            throw new NotImplementedException();
        }

        public void BestSolution()
        {
            throw new NotImplementedException();
        }
    }
}
