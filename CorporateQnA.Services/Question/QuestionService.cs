using AutoMapper;
using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Data.Models.EmployeeActivities;
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

        public readonly IMapper _mapper;

        private readonly IAnswerService _answerService;

        public QuestionService(ApplicationDbContext db, IMapper mapper, IAnswerService answerService)
        {
            this._db = db.GetConnection();
            this._mapper = mapper;
            this._answerService = answerService;
        }

        public void AddQuestion(Question newQuestion)
        {
            var question = this._mapper.Map<Data.Models.Question.Question>(newQuestion);
            this._db.Insert(question);
        }

        public QuestionListItem GetQuestionById(Guid questionId, Guid currentEmployeeId)
        {
            var question = this._db.QuerySingleOrDefault<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId and Id = @questionId", new { currentEmployeeId = currentEmployeeId, questionId = questionId });
            return this._mapper.Map<QuestionListItem>(question);
        }

        public IEnumerable<QuestionListItem> GetAllQuestions(Guid currentEmployeeId)
        {
            var questions = this._db.Query<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId", new { currentEmployeeId = currentEmployeeId });
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId, Guid currentEmployeeId)
        {
            var questions = this._db.Query<QuestionDetailsView>("Select * from QuestionDetails Where CurrentEmployeeId = @currentEmployeeId and EmployeeId = @employeeId", new { currentEmployeeId = currentEmployeeId, employeeId = employeeId }).ToList();
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId, Guid currentEmployeeId)
        {
            var questionIdList = this._db.Query<Guid>("Select DISTINCT QuestionId from Answer Where AnsweredBy = @EmployeeId", new { EmployeeId = employeeId }).ToList();
            var answers = questionIdList.Select(questionId => GetQuestionById(questionId, currentEmployeeId));
            return answers;
        }

        public long AddQuestionActivity(Guid questionId, Guid employeeId)
        {
            var newActivity = new EmployeeQuestionActivity()
            {
                QuestionId = questionId,
                EmployeeId = employeeId,
                ViewedOn = DateTime.Now
            };

            var existingActivity = this._db.QuerySingleOrDefault("Select * from EmployeeQuestionActivity Where EmployeeId = @employeeId and QuestionId = @questionId", new { employeeId = newActivity.EmployeeId, questionId = newActivity.QuestionId });

            if (existingActivity != null)
            {
                newActivity.Id = existingActivity.Id;
                this._db.Update(newActivity);
            }
            else
            {
                this._db.Insert(newActivity);
            }

            var updatedViewCount = this._db.QuerySingleOrDefault<long>("Select COUNT(*) from EmployeeQuestionActivity Where QuestionId = @questionId", new { questionId = newActivity.QuestionId });

            return updatedViewCount;
        }

        public void VoteQuestion(Guid questionId, Guid employeeId, Vote voteStatus)
        {
            var newActivity = new EmployeeQuestionActivity()
            {
                QuestionId = questionId,
                EmployeeId = employeeId,
                VoteStatus = (short)voteStatus,
            };

            var existingActivity = this._db.QuerySingleOrDefault("Select * from EmployeeQuestionActivity Where EmployeeId = @employeeId and QuestionId = @questionId", new { employeeId = newActivity.EmployeeId, questionId = newActivity.QuestionId });

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
