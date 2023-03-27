namespace CorporateQnA.Core.Models.Dtos.Request
{
    public class NewQuestionDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int EmployeeId { get; set; }
    }
}
