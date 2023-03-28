﻿namespace CorporateQnA.Core.Models.Questions.ViewModels
{
    public class QuestionListItem
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfAnswers { get; set; }

        public bool IsSolved { get; set; }

        public DateTime CreatedOn { get; set; }

        public int NumberOfUpVotes { get; set; }
    }
}