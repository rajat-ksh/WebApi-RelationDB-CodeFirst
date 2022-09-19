namespace EmployeeAPI.Models.RequestModel
{
    public class EmployeeUpdateRequestDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
    }
}
