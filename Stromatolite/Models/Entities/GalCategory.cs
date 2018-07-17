using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stromatolite.Models
{
    public class GalCategory
    {
        public GalCategory()
        {
            this.Galleries = new HashSet<Gallery>();
        }

        [Key]
        public System.Guid GalCategoryID { get; set; }

        [DisplayName("Категория галереи")]
        [StringLength(200)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Для каталога товаров")]
        [DefaultValue(false)]
        public bool ProdGal { get; set; }

        public virtual ICollection<Gallery> Galleries { get; set; }
    }
}