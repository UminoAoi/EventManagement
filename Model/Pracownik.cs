using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Pracownik
    {
        [Key]
        public int IdPracownik { get; set; }
        [Required]
        public string PESEL { get; set; }
        public static float Pensja = 10;
        [Required]
        public Uzytkownik Uzytkownik { get; set; }

        public List<Atrakcja> Atrakcje { get; set; }
        public List<Event_Pracownik> Eventy { get; set; }
    }
}
