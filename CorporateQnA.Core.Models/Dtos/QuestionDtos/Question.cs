namespace CorporateQnA.Core.Models.Dtos.QuestionDtos
{
    public class Question
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public string EmployeeName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ViewCount { get; set; }

        public int AnswerCount { get; set; }

        public bool IsSolved { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Upvotes { get; set; }
    }
}
