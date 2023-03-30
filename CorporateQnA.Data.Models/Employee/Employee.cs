using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Employee
{
    [Table("Employee")]
    public class Employee
    {
        public Guid Id;

        public string FirstName;

        public string? LastName;

        public string Email;

        public Guid DesignationId;

        public Guid DepartmentId;

        public Guid LocationId;
    }
}
