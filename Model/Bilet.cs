using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Bilet
    {
        [Key]
        public int IdBilet { get; set; }
        public string Typ { get; set; }

        [Required]
        public Uczestnik Uczestnik { get; set; }
        [Required]
        public Event Event { get; set; }
    }
}
