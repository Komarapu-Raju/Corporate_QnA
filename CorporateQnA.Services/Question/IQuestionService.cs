using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public long AddQuestion(Question question);

        public QuestionDetailsView GetQuestionById(Guid questionId);

        public IEnumerable<QuestionDetailsView> GetAllQuestion();

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId);

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId);
    }
}
