namespace UniversityIot.UsersService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [MinLength(10),MaxLength(10)]
        public string CustomerNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}