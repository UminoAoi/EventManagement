using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Panel : Atrakcja
    {
        [Required]
        public string Miejsce { get; set; }
        public int IloscMiejsc { get; set; }
        public PanelKonkursowy PanelKonkursowy { get; set; }


    }
}
