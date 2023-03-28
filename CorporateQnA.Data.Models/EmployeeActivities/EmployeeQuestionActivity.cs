namespace CorporateQnA.Data.Models.EmployeeActivities
{
    public class EmployeeQuestionActivityView
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public short VoteStatus { get; set; }
    }
}
