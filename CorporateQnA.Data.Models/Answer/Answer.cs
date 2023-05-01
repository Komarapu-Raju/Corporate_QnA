using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Answer
{
    [Table("Answer")]
    public class Answer
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public string Description { get; set; }

        public Guid AnsweredBy { get; set; }

        public DateTime AnsweredOn { get; set; } = DateTime.Now;

        public bool IsBestSolution { get; set; }
    }
}
