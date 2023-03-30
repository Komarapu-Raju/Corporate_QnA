﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Answer.Views
{
    [Table("AnswerDetails")]
    public class AnswerDetailsView
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; } 

        public string Description { get; set; }

        public DateTime AnsweredOn { get; set; }

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public bool IsBestSolution { get; set; }

        public int NumberOfUpVotes { get; set; }

        public int NumberOfDownVotes { get; set; }
    }
}
