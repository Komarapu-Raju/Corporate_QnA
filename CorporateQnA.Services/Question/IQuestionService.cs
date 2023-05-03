using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Question;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        public void AddQuestion(Question question);

        public QuestionDetailsView GetQuestionById(Guid questionId);

        public IEnumerable<QuestionDetailsView> GetAllQuestions(Guid currentEmployeeId);

        public IEnumerable<QuestionDetailsView> GetQuestionsAskedByEmployee(Guid employeeId,Guid currentEmployeeId);

        public IEnumerable<QuestionDetailsView> GetQuestionsAnsweredByEmployee(Guid employeeId, Guid currentEmployeeId);

        public void AddQuestionActivity(EmployeeQuestionActivity newActivity);
    }
}
