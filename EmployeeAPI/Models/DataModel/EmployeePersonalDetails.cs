using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DataViewModel
{
    public class EmployeePersonalDetails
    {
        [Key]
        public Guid Id { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
    }
}
