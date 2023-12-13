using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_3.Models
{
    public class EmpSalary
    {
        [Key]
        public int SalaryId { get; set; }
        
        [Required(ErrorMessage = "Month is required.")]
        public DateTime Month { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "Credit Date is required.")]
        public DateTime CreditDate { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmpId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
