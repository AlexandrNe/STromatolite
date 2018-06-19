using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }

        [DisplayName("Название")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Полное наименование")]
        [StringLength(500)]
        [Required]
        public string TitleFull { get; set; }

        [DisplayName("Артикул")]
        [StringLength(25)]
        public string Article { get; set; }

        [DisplayName("Описание")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("ЧПУ")]
        public string SEOurl { get; set; }

        [DisplayName("Опубликован")]
        [DefaultValue(true)]
        public bool Active { get; set; }

        [DisplayName("Теги")]
        [StringLength(500)]
        public string Tags { get; set; }

        [DisplayName("MetaDescription")]
        [StringLength(300)]
        public string MetaDescription { get; set; }

        [DisplayName("MetaDescription")]
        [StringLength(200)]
        public string KeyWords { get; set; }

        [DisplayName("Индекс сортировки")]
        [Required]
        [DefaultValue(500)]
        public int Sort { get; set; }

    }
}