using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Atrakcja
    {
        [Key]
        public int IdAtrakcja { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public DateTime Czas { get; set; }
        [Required]
        public string Opis { get; set; }

        public List<Atrakcja_Uczestnik> Uczestnicy { get; set; }

        public Pracownik Pracownik { get; set; }
        public int IdPracownik { get; set; }

        [Required]
        public Event Event { get; set; }
        public int IdEvent { get; set; }
    }
}
