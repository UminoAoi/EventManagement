using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Event_Pracownik
    {
        [Required]
        public Event Event { get; set; }
        public int IdEvent { get; set; }
        [Required]
        public Pracownik Pracownik { get; set; }
        public int IdPracownik { get; set; }
    }
}
