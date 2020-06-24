using System.ComponentModel.DataAnnotations;

namespace EmployeeForm.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. John Doe")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(18, 25)]
        public string Age { get; set; }

        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

       
        [StringLength(35)]
        public string City { get; set; }
        public string Resume { get; set; }
        public string Education { get; set; }


    }
}