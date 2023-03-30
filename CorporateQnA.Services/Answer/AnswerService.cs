using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper;
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

        public void VoteAnswer(EmployeeAnswerActivity answerActivity)
        {
            var answer =this._db.QueryFirstOrDefault("Select * from EmployeeAnswerActivity Where EmployeeId = @employeeId and AnswerId = @answerId", new { employeeId = answerActivity.EmployeeId,answerId = answerActivity.AnswerId});
            if (answer != null)
            {
                answerActivity.Id = answer.Id;
                this._db.Update(answerActivity);
            }
            else
            {
                this._db.Insert(answerActivity);
            }
        }

        public void BestSolution()
        {
            throw new NotImplementedException();
        }
    }
}
