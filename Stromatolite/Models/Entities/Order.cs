using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Order
    {
        [Key]
        public System.Guid OrderID { get; set; }

        [DisplayName("№ заказа")]
        [StringLength(200)]
        public string OrderNum { get; set; }

        [DisplayName("Дата")]
        public System.Nullable<System.DateTime> OrderDate { get; set; }

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