using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace EmployeeAPI.Models.DataViewModel
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }

        //navigation Properties
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public Department Department { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public WorkLocation WorkLocation { get; set; }
    }
}
