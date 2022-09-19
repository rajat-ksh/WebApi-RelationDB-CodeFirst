using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeAPI.Models.DataViewModel
{
    public class EmployeeEducationDetails
    {

        [Key]
        public Guid Id { get; set; }
        public string Qualification { get; set; }
        public float Marks { get; set; }
        public string CollegeName { get; set; }
    }
}
