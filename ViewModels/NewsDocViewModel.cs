using System.ComponentModel.DataAnnotations;
using NewsApp.Entities;

namespace NewsApp.ViewModels
{
    public class NewsDocViewModel
    {
        public string Id { get; set; }

        [Required, MaxLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Main Text")]
        public string Main { get; set; }

        [Display(Name = "News Type")]
        public NewsType Type { get; set; }
    }
}