﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Category.Views
{
    [Table("CategoryDetails")]
    public class CategoryDetailsView
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalNumberOfTags { get; set; }

        public int NumberOfTagsThisWeek { get; set; }

        public int NumberOfTagsThisMonth { get; set; }
    }
}
