namespace CorporateQnA.Data.Models.EmployeeActivities
{
    public class EmployeeAnswerActivity
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }

        public int EmployeeId { get; set; }

        public short VoteStatus { get; set; }
    }
}
