using System.ComponentModel.DataAnnotations;

namespace ApplicationForm.Models
{
    public class ApplyModel
    {
        [Required(ErrorMessage = "An E-mail address must be informed.")]
        [DataType(DataType.EmailAddress,ErrorMessage = "A valid E-mail address must be informed.")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}