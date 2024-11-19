using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(25, ErrorMessage ="Name cannot exceed 25 characters limit")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email address")]
        public string Email { get; set; }
    }
}
