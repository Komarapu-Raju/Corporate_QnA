using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ViewCount { get; set; }

        public int AnswerCount { get; set; }

        public bool IsSolved { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Upvotes { get; set; }
    }
}
