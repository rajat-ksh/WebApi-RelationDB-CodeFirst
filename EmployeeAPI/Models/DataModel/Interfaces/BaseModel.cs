using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DataViewModel.Interfaces
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> employee { get; set; }
    }
}
