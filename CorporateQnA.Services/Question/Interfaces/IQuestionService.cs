using CorporateQnA.Core.Models.Questions;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public void AddQuestion(Question question);

        public Question GetQuestionById(int questionId);

        public IEnumerable<Question> GetQuestionList();

        public IEnumerable<Question> GetQuestionsAskedByEmployee(int employeeId);

        public IEnumerable<Question> GetQuestionsAnsweredByEmployee(int employeeId);
    }
}
