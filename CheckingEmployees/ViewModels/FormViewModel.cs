using System;

namespace CheckingEmployees.ViewModels
{
    public class FormViewModel
    {
        public int Reason { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
}
