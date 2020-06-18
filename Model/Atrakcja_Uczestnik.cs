using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Atrakcja_Uczestnik
    {
        [Required]
        public Atrakcja Atrakcja { get; set; }
        public int IdAtrakcja { get; set; }
        [Required]
        public Uczestnik Uczestnik { get; set; }
        public int IdUczestnik { get; set; }
    }
}
