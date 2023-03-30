using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IDbConnection _db;

        public AnswerService(ApplicationDbContext db)
        {
            _db = db.GetConnection();
        }
        public long AddAnswer(Answer answer)
        {
            return _db.Insert(answer);
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(Guid questionId)
        {
            return _db.GetAll<AnswerDetailsView>().Where(item => item.QuestionId == questionId);
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByEmployeeId(Guid employeeId)
        {
            return _db.GetAll<AnswerDetailsView>().Where(item => item.EmployeeId == employeeId);
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
