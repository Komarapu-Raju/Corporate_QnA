using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.EmployeeActivities
{
    [Table("EmployeeAnswerActivity")]
    public class EmployeeAnswerActivity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid AnswerId { get; set; }

        public Guid EmployeeId { get; set; }

        public short VoteStatus { get; set; }
    }
}
