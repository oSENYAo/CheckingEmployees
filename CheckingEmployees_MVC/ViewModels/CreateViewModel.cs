using System;
using System.ComponentModel.DataAnnotations;

namespace CheckingEmployees_MVC.ViewModels
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Причина отсутствия")]
        public int Reason { get; set; }

        [Required]
        [Display(Name = "Дата начала отсутствия")]
        public DateTime StarDate { get; set; }

        [Required]
        [Range(1, 365, ErrorMessage = "от 1 до 365")]
        [Display(Name = "Продолжительность отсутствия")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Учтено при оплате")]
        public bool Discounted { get; set; }

        [Required]
        [StringLength(1024)]
        [Display(Name = "Ваш комментарий")]
        [RegularExpression("^[а-яёА-ЯЁ0-9 ]*$", ErrorMessage = "Допустимы комментарии только на русском языке")]
        public string Description { get; set; }
    }
}
