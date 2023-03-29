using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public long AddQuestion(Question question);

        public QuestionDetailsView GetQuestionById(int questionId);

        public IEnumerable<QuestionDetailsView> GetQuestionList();

        public IEnumerable<Question> GetQuestionsAskedByEmployee(int employeeId);

        public IEnumerable<Question> GetQuestionsAnsweredByEmployee(int employeeId);
    }
}
