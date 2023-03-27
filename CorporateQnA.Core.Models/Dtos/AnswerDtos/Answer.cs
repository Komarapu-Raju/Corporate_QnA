namespace CorporateQnA.Core.Models.Dtos.AnswerDtos
{
    public class Answer
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime AnsweredOn { get; set; }

        public int AnsweredBy { get; set; }

        public string EmployeeName { get; set; }

        public bool IsBestSolution { get; set; }

        public int Upvotes { get; set; }

        public int DownVotes { get; set; }
    }
}
