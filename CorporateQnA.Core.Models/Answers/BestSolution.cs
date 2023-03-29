namespace CorporateQnA.Core.Models.Answers
{
    public class BestSolution
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        public bool IsBestSolution { get; set; }
    }
}
