using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Nagroda
    {
        [Key]
        public int IdNagroda { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public float Wartosc { get; set; }

        [Required]
        public Konkurs Konkurs { get; set; }
    }   
}
