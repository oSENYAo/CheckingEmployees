using System;
using System.ComponentModel.DataAnnotations;

namespace CheckingEmployees.Models
{
    /// <summary>
    /// Main model
    /// </summary>
    public class FormAbsence
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Выберите причину отсутствия")]
        public Causes Reason { get; set; }
        [Required(ErrorMessage = "Выберите дату начала отсутствия")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Введите количество пропущенных дней")]
        [Range(1, 365, ErrorMessage = "Продолжительность отсутствия от 1 до 365")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Поставьте галочку если это учтено при оплате")]
        public bool Discounted { get; set; }
        [Required(ErrorMessage = "Оставьте свой комментарий")]
        [StringLength(1024, ErrorMessage = "Комментарий не должен быть длинее 1024 символов")]
        [RegularExpression("^[а-яёА-ЯЁ0-9 ]*$", ErrorMessage = "Допустимы комментарии только на русском языке")]
        public string Description { get; set; }
    }
}

