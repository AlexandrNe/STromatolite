using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class ErrorLog
    {
        [Key]
        public System.Guid ErrorLogID { get; set; }

        [DisplayName("Время")]
        [DataType(DataType.DateTime)]
        public System.DateTime ErrDate { get; set; }

        [DisplayName("Описание")]
        [AllowHtml]
        public string ErrDescription { get; set; }

    }
}