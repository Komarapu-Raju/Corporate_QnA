using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateQnA.Core.Models.Dtos.AnswersDtos
{
    public class AnswerDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime AnsweredOn { get; set; }

        public int AnsweredBy { get; set; }

        public string EmployeeName { get; set; }

        public bool IsBestSolution { get; set; }

        public int Upvotes { get; set; }

        public int DownVotes { get; set; }
    }
}
