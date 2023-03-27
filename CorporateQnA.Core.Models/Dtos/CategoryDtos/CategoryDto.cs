using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Dtos.CategoryDtos
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
