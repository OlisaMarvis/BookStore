using System;
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
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose the language of your book")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int? Totalpages { get; set; }
        public string Category { get; set; }

    }
}
