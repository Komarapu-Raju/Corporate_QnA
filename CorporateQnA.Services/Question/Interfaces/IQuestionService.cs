using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public long AddQuestion(Question question);

        public QuestionDetailsView GetQuestionById(Guid questionId);

        public IEnumerable<QuestionDetailsView> GetQuestionList();

        public IEnumerable<Question> GetQuestionsAskedByEmployee(Guid employeeId);

        public IEnumerable<Question> GetQuestionsAnsweredByEmployee(Guid employeeId);
    }
}
