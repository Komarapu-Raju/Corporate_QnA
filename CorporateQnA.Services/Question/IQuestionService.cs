using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        Guid AddQuestion(Question newQuestion);

        QuestionListItem GetQuestionById(Guid questionId);

        IEnumerable<QuestionListItem> GetAllQuestions();

        IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId);

        IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId);

        long AddQuestionActivity(Guid questionId);

        void VoteQuestion(Guid questionId, Vote voteStatus);
    }
}
