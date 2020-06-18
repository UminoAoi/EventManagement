using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Konkurs : Atrakcja
    {
        public PanelKonkursowy PanelKonkursowy { get; set; }
                
        public Nagroda Nagroda { get; set; }
        public int IdNagroda { get; set; }
    }
}
