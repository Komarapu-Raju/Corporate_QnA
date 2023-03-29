using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Answer
{
    [Table("Answer")]
    public class Answer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Description { get; set; }

        public int AnsweredBy { get; set; }

        public bool IsBestSolution { get; set; }
    }
}
