using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Dtos.QuestionDtos
{
    public class AddQuestionDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int EmployeeId { get; set; }
    }
}
