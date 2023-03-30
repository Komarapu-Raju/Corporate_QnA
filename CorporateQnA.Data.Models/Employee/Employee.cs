namespace CorporateQnA.Data.Models.Employee
{
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
