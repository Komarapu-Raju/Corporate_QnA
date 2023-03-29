using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Core.Models.EmployeeActivities;
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

        public void BestSolution(Core.Models.Answers.BestSolution bestSolution)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(int QuestionId)
        {
            return this._db.GetAll<AnswerDetailsView>().Where(item => item.QuestionId == QuestionId);
        }

        public void VoteAnswer(EmployeeAnswerActivity newActivity)
        {
            throw new NotImplementedException();
        }
    }
}
