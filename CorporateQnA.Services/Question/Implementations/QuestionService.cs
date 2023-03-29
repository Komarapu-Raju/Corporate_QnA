using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Services.Interfaces;

namespace CorporateQnA.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        public void AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsAnsweredByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsAskedByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
