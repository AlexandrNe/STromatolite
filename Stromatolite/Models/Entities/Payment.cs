using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Payment
    {
        [Key]
        public System.Guid PaymentID { get; set; }

        [DisplayName("№ договора")]
        [StringLength(200)]
        public string ContractNum { get; set; }

        [DisplayName("Дата платежа")]
        public System.Nullable<System.DateTime> PaymentDate { get; set; }

        [DisplayName("E-mail")]
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Телефон")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [DisplayName("Имя")]
        [StringLength(256)]
        public string FullName { get; set; }

        [DisplayName("IP-адрес")]
        [StringLength(50)]
        public string IP { get; set; }

        [DisplayName("Комментарий")]
        [AllowHtml]
        public string Comment { get; set; }

        [DisplayName("Закрыт")]
        [DefaultValue(false)]
        public System.Nullable<bool> Closed { get; set; }
    }
}