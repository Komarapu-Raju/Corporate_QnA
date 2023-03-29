namespace CorporateQnA.Core.Models.Categories.ViewModels
{
    public class CategoryListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalNumberOfTags { get; set; }

        public int NumberOfTagsThisWeek { get; set; }

        public int NumberOfTagsThisMonth { get; set; }
    }
}
