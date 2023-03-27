namespace CorporateQnA.Core.Models.Dtos.Response
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalTags { get; set; }

        public int TagsThisWeek { get; set; }

        public int TagsThisMonth { get; set; }
    }
}
