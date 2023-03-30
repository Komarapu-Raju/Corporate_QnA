using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Employee.Views
{
    [Table("EmployeeDetails")]
    public class EmployeeDetailsView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public int NumberOfQuestionsAsked { get; set; }

        public int NumberOfQuestionsSolved { get; set; }

        public int NumberOfQuestionsAnswered { get; set; }

        public int NumberOfUpVotesRecieved { get; set; }

        public int NumberOfDownVotesRecieved { get; set; }
    }
}
