using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Uzytkownik
    {
        [Key]
        public int IdUzytkownik { get; set; }
        [Required]
        [MaxLength(12)]
        public string NazwaUzytkownika { get; set; }
        [Required]
        [MaxLength(20)]
        public string Haslo { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NumerTelefonu { get; set; }
        public Organizator Organizator { get; set; }
        public int IdOrganizator { get; set; }
        public Uczestnik Uczestnik { get; set; }
        public int IdUczestnik { get; set; }
        public Pracownik Pracownik { get; set; }
        public int IdPracownik { get; set; }

    }

    public enum Rola
    {
        Uczestnik,
        Organizator,
        Pracownik
    }
}
