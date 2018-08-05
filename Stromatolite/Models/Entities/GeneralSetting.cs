using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class GeneralSetting
    {
        [Key]
        public int GeneralSettingID { get; set; }

        [DisplayName("Наименование")]
        [StringLength(200)]
        [Required]
        public string SettingName { get; set; }

        [DisplayName("Значение")]
        [AllowHtml]
        [Required]
        public string SettingValue { get; set; }
    }
}