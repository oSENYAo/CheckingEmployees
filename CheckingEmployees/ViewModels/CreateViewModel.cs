using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingEmployees.ViewModels
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
        [Range(1,365,ErrorMessage ="от 1 до 365")]
        [Display(Name = "Продолжительность отсутствия")]
        public int Duration { get; set; }
        
        [Required]
        [Display(Name = "Учтено при оплате")]
        public bool Discounted { get; set; }
        
        [Required]
        [StringLength(1024)]
        [Display(Name = "Ваш комментарий")]
        public string Description { get; set; }
    }
    //<div>
    //    <label asp-for="Reason"></label>
    //    <select asp-for="Reason" asp-items="ViewBag.Reason"></select>
    //    <span asp-validation-for="Reason"></span>
    //</div>
    
}
