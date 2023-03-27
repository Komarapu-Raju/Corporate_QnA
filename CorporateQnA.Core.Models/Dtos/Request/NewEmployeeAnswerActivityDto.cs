namespace CorporateQnA.Core.Models.Dtos.Request
{
    public class NewEmployeeAnswerActivityDto
    {
        public int AnswerId { get; set; }

        public int EmployeeId { get; set; }

        public int VoteStatus { get; set; }
    }
}
