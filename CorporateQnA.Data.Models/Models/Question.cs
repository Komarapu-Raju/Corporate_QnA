namespace CorporateQnA.Data.Models.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
