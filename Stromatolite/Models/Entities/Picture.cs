using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stromatolite.Models
{
    public class Picture
    {
        [Key]
        public System.Guid PictureID { get; set; }

        [DisplayName("Заголовок")]
        [StringLength(200)]
        public string Title { get; set; }

        [DisplayName("URL картинки")]
        [Required]
        public string PicUrl { get; set; }
        public System.Guid GalleryID { get; set; }

        [DisplayName("Порядок")]
        public Nullable<int> Ord { get; set; }

        public virtual Gallery Gallery { get; set; }

    }
}