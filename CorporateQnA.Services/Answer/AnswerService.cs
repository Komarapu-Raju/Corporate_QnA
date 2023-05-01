using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.DbContext;
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
            this._db = db.GetConnection();
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(Guid questionId)
        {
            return this._db.GetAll<AnswerDetailsView>().Where(item => item.QuestionId == questionId);
        }

        public IEnumerable<AnswerDetailsView> GetAnswersByEmployeeId(Guid employeeId)
        {
            return this._db.GetAll<AnswerDetailsView>().Where(item => item.EmployeeId == employeeId);
        }

        public void AddAnswer(Answer answer)
        {
            this._db.Insert(answer);
        }

        public void VoteAnswer(EmployeeAnswerActivity answerActivity)
        {
            var answer = this._db.QueryFirstOrDefault("Select * from EmployeeAnswerActivity Where EmployeeId = @employeeId and AnswerId = @answerId", new { employeeId = answerActivity.EmployeeId, answerId = answerActivity.AnswerId });
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

        public void BestSolution(Guid answerId)
        {
            var answer = this._db.Get<Answer>(answerId);
            answer.IsBestSolution = !answer.IsBestSolution;
            this._db.Update(answer);
        }
    }
}
