using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Uczestnik
    {
        [Key]
        public int IdUczestnik { get; set; }
        [Required]
        public Uzytkownik Uzytkownik { get; set; }

        public List<Bilet> Bilety { get; set; }
        public List<Atrakcja_Uczestnik> Atrakcje { get; set; }
    }
}
