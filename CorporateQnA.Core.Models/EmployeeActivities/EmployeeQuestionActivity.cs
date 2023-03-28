namespace CorporateQnA.Core.Models.EmployeeActivities
{
    public class EmployeeQuestionActivity
    {
        public int QuestionId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public int VoteStatus { get; set; }
    }
}
