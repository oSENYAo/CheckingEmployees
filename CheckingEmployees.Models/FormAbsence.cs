using System;

namespace CheckingEmployees.Models
{
    public class FormAbsence
    {
        public int Id { get; set; }
        public Causes Reason { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool Discounted { get; set; }
        public string Description { get; set; }
    }
    
}

