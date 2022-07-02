using System.ComponentModel.DataAnnotations;

namespace Marvis.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Igbo Language")]
        Igbo = 10,
        [Display(Name = "English Language")]
        English = 11,
        [Display(Name = "Hausa Language")]
        Hausa = 12,
        [Display(Name = "Igala Language")]
        Igala = 13,
        [Display(Name = "Yoruba Language")]
        Yoruba = 14
    }
}
