using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. John Doe")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Range(18, 100)]
        public string Age { get; set; }

        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [StringLength(35)]
        public string City { get; set; }

        [DisplayName("Upload Resume")]
        public string Resume { get; set; }

        [Required(ErrorMessage = "Please Enter Education")]
        public string Education { get; set; }


    }
}