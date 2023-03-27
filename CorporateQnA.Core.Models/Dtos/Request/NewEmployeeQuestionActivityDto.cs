namespace CorporateQnA.Core.Models.Dtos.Request
{
    public class NewEmployeeQuestionActivityDto
    {
        public int QuestionId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public int VoteStatus { get; set; }
    }
}
