using AutoMapper;
using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Core.Models.UserContext;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Question.Views;
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

        public AnswerService(ApplicationDbContext db, IMapper mapper, UserContext userContext)
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

        public Guid AddAnswer(Answer newAnswer)
        {
            var answer = this._mapper.Map<Data.Models.Answer.Answer>(newAnswer);
            var query = "insert into Answer (questionId, description, answeredBy) output inserted.id values (@questionId, @description, @answeredBy)";
            return this._db.ExecuteScalar<Guid>(query, new { questionId = answer.QuestionId, description = answer.Description, answeredBy = answer.AnsweredBy });
        }

        public AnswerListItem GetAnswerById(Guid id)
        {
            var answer = this._db.QuerySingleOrDefault<AnswerDetailsView>("Select * from AnswerDetails Where CurrentEmployeeId = @currentEmployeeId and Id = @answerId", new { currentEmployeeId = this._userContext.Id, answerId = id });
            return this._mapper.Map<AnswerListItem>(answer);
        }

        public void VoteAnswer(Guid answerId, Vote voteStatus)
        {
            var answerActivity = new EmployeeAnswerActivity()
            {
                AnswerId = answerId,
                EmployeeId = this._userContext.Id,
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
