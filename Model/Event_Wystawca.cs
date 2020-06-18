using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Event_Wystawca
    {
        [Required]
        public Event Event { get; set; }
        public int IdEvent { get; set; }
        [Required]
        public Wystawca Wystawca { get; set; }
        public int IdWystawca { get; set; }
    }
}
