using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class PanelKonkursowy : Panel
    {
        [Required]
        public Konkurs Konkurs { get; set; }
        public int IdKonkurs { get; set; }
    }
}
