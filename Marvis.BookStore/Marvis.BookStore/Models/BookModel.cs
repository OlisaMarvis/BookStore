using Marvis.BookStore.Enums;
using Marvis.BookStore.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marvis.BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.DateTime)]
        //[Display(Name = "Display date and time")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter email address")]
        [EmailAddress]
        public string MyField { get; set; }
        public int Id { get; set; }
        //[StringLength(100, MinimumLength = 5)]
        //[Required(ErrorMessage = "Please enter the title of your book")]

        //[MyCustomValidation("abc")]
        //[MyCustomValidation]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose the language of your book")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int? Totalpages { get; set; }
        public string Category { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }
    }
}
