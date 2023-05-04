using AutoMapper;
using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.UserContext;
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

        private readonly IMapper _mapper;

        private readonly UserContext _userContext;

        public AnswerService(ApplicationDbContext db, IMapper mapper,UserContext userContext)
        {
            this._db = db.GetConnection();
            this._mapper = mapper;
            this._userContext = userContext;
        }

        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId)
        {
            var answers = this._db.Query<AnswerDetailsView>("Select * from AnswerDetails Where QuestionId = @questionId and CurrentEmployeeId = @currentEmployeeId ", new { questionId = questionId, currentEmployeeId = this._userContext.Id }).ToList();
            return this._mapper.Map<IEnumerable<AnswerListItem>>(answers);
        }

        public void AddAnswer(Answer newAnswer)
        {
            var answer = this._mapper.Map<Data.Models.Answer.Answer>(newAnswer);
            this._db.Insert(answer);
        }

        public void VoteAnswer(Guid answerId, Guid employeeId, Vote voteStatus)
        {
            var answerActivity = new EmployeeAnswerActivity()
            {
                AnswerId = answerId,
                EmployeeId = employeeId,
                VoteStatus = (short)voteStatus
            };
            var answer = this._db.QuerySingleOrDefault("Select * from EmployeeAnswerActivity Where EmployeeId = @employeeId and AnswerId = @answerId", new { employeeId = answerActivity.EmployeeId, answerId = answerActivity.AnswerId });
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

        public void UpdateBestSolution(Guid answerId)
        {
            var answer = this._db.Get<Data.Models.Answer.Answer>(answerId);
            answer.IsBestSolution = !answer.IsBestSolution;
            this._db.Update(answer);
        }
    }
}
