using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Joining Date is required.")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        public virtual ICollection<EmpSalary> Salaries { get; set; }
       
    }
}
