using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Gallery
    {
        public Gallery()
        {
            this.Pictures = new HashSet<Picture>();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public Guid GalleryID { get; set; }

        [DisplayName("Название")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [AllowHtml]
        public string Abstarct { get; set; }

        public System.Guid GalCategoryID { get; set; }

        public virtual GalCategory GalCategory { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}