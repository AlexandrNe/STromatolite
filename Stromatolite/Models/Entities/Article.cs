using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Stromatolite.Models
{
    public class Article
    {
        [Key]
        public Guid ArticleID { get; set; }

        [DisplayName("Изображение")]
        public string ImgUrl { get; set; }

        [DisplayName("Заголовок")]
        [StringLength(500)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Описание")]
        [AllowHtml]
        public string Abstract { get; set; }

        [DisplayName("Статья")]
        [AllowHtml]
        public string ArtBody { get; set; }

        [DisplayName("Дата добавления")]
        [DataType(DataType.DateTime)]
        [Required]
        public System.DateTime AddedDate { get; set; }

        [DisplayName("Дата публикации")]
        [DataType(DataType.DateTime)]
        [Required]
        public System.DateTime ReleaseDate { get; set; }

        [DisplayName("Срок действия")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ExpireDate { get; set; }

        [DisplayName("Источник")]
        public string Reference { get; set; }

        [DisplayName("Утверждена")]
        [Required]
        public bool Approved { get; set; }

        [DisplayName("Разрешены комментарии")]
        [Required]
        public bool CommentsEnabled { get; set; }

        [DisplayName("Количество просмотров")]
        public Nullable<int> ViewCount { get; set; }

        [DisplayName("Голосов")]
        public Nullable<int> Votes { get; set; }

        [DisplayName("Оценка")]
        public Nullable<int> TotalRating { get; set; }

        [DisplayName("ЧПУ")]
        [StringLength(500)]
        public string SeoUrl { get; set; }

        [DisplayName("KeyWords")]
        [StringLength(200)]
        public string Keywords { get; set; }

        [DisplayName("MetaDescription")]
        [StringLength(300)]
        public string MetaDescription { get; set; }

        [DisplayName("Теги")]
        [StringLength(500)]
        public string Tags { get; set; }

    }
}