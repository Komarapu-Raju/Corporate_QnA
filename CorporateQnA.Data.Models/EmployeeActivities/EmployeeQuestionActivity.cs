namespace CorporateQnA.Data.Models.EmployeeActivities
{
    public class EmployeeQuestionActivityView
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public short VoteStatus { get; set; }
    }
}
