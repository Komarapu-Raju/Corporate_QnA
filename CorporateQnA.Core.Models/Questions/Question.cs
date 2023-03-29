using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Core.Models.Questions
{
    public class Question
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int CreatedBy { get; set; }
    }
}
