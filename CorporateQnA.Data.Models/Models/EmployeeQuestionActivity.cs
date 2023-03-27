namespace CorporateQnA.Data.Models.Models
{
    public class EmployeeQuestionActivity
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public int VoteStatus { get; set; }
    }
}
