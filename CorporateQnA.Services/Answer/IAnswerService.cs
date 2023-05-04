using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId);

        AnswerListItem AddAnswer(Answer answer);

        AnswerListItem GetAnswerById(Guid id);

        void VoteAnswer(Guid answerId, Vote voteStatus);

        void UpdateBestSolution(Guid answerId);
    }
}
