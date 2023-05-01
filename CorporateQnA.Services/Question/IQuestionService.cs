using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public void AddQuestion(Question question);

        public QuestionDetailsView GetQuestionById(Guid questionId);

        public IEnumerable<QuestionDetailsView> GetAllQuestions();

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId);

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId);

        public void AddQuestionActivity(EmployeeQuestionActivity newActivity);
    }
}
