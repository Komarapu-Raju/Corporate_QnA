﻿namespace CorporateQnA.Data.Models.Models
{
    public class EmployeeAnswerActivity
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }

        public int EmployeeId { get; set; }

        public int VoteStatus { get; set; }
    }
}
