using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DataViewModel.Interfaces
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
