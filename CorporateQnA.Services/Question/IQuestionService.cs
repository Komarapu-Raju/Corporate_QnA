using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        void AddQuestion(Question newQuestion);

        QuestionListItem GetQuestionById(Guid questionId, Guid currentEmployeeId);

        IEnumerable<QuestionListItem> GetAllQuestions(Guid currentEmployeeId);

        IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId, Guid currentEmployeeId);

        IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId, Guid currentEmployeeId);

        long AddQuestionActivity(Guid questionId, Guid employeeId);

        void VoteQuestion(Guid questionId, Guid employeeId, Vote voteStatus);
    }
}
