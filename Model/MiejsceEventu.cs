using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class MiejsceEventu
    {
        [Key]
        public int IdMiejsceEventu { get; set; }
        [Required]
        public int WolneMiejsca { get; set; }
        [Required]
        public string Adres { get; set; }

        public List<Event> Eventy { get; set; }
    }
}
