namespace UniversityIot.UsersService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EditUserViewModel
    {
        [Required]
        [MaxLength(10),MinLength(10)]
        public string CustomerNumber { get; set; }
    }
}