using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Group
    {
        public Group()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public Guid GroupID { get; set; }

        [DisplayName("Название")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("ЧПУ")]
        public string SEOurl { get; set; }

        [DisplayName("Опубликована")]
        [DefaultValue(true)]
        public bool Active { get; set; }

        [DisplayName("Порядок")]
        [Required]
        [DefaultValue(500)]
        public int Ord { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}