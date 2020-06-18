using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Wystawca
    {
        [Key]
        public int IdWystawca { get; set; }
        [Required]
        [MaxLength(20), MinLength(3)]
        public string NazwaFirmy { get; set; }
        [Required]
        public float RozmiarStoiska { get; set; }
        [Required]
        public string RodzajStoiska { get; set; }
        [Required]
        public string DaneKontaktowe { get; set; }

        public List<Event_Wystawca> Eventy { get; set; }
        public Organizator Organizator { get; set; }
    }
}
