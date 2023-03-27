namespace CorporateQnA.Core.Models.Dtos.QuestionDtos
{
    public class NewQuestion
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int EmployeeId { get; set; }
    }
}
