using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Question
{
    [Table("Question")]
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int CreatedBy { get; set; }
    }
}
