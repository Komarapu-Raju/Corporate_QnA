using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Core.Models.Questions
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
