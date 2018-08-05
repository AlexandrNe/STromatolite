using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stromatolite.Models
{
    public class NotificationEmail
    {
        [Key]
        public int NotificationEmailID { get; set; }

        [DisplayName("Адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}