﻿namespace CorporateQnA.Data.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Description { get; set; }

        public int AnsweredBy { get; set; }

        public DateTime AnsweredOn { get; set; }

        public bool IsBestSolution { get; set; }
    }
}