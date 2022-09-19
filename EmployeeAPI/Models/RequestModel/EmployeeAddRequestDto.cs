using EmployeeAPI.Models.DataViewModel;

namespace EmployeeAPI.Models.RequestModel
{
    public class EmployeeAddRequestDto
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }
        public int WorkLocationId { get; set; }
        public string Qualification { get; set; }
        public float Marks { get; set; }
        public string CollegeName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
    }
}
