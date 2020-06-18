using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        [Required]
        public string NazwaEventu { get; set; }
        [Required]
        public DateTime DataRozpoczecia { get; set; }
        [Required]
        public DateTime DataZakonczenia { get; set; }
        public int IloscMiejsc { get; set; }
        public string Tematyka { get; set; }
        public float CenaBiletow { get; set; }
        [Required]
        public EventStatus Status { get; set; }

        public List<Bilet> Bilety { get; set; }
        public List<Event_Pracownik> Pracownicy { get; set; }
        public List<Atrakcja> Atrakcje { get; set; }
        public List<Event_Wystawca> Wystawcy { get; set; }

        [Required]
        public Organizator Organizator { get; set; }
        [Required]
        public MiejsceEventu MiejsceEventu { get; set; }
    }

    public enum EventStatus
    {
        Zaplanowany,
        WTrakcie,
        Zakończony,
        Odwołany
    }
}
