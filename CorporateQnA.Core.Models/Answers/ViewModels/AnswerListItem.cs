namespace CorporateQnA.Core.Models.Answers.ViewModels
{
    public class AnswerListItem
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Description { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public bool IsBestSolution { get; set; }

        public DateTime AnsweredOn { get; set; }

        public int NumberOfUpVotes { get; set; }

        public int NumberOfDownVotes { get; set; }
    }
}
