using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Organizator
    {
        [Key]
        public int IdOrganizator { get; set; }

        [Required]
        public Uzytkownik Uzytkownik { get; set; }

        public List<Event> Eventy { get; set; }

        public List<Wystawca> Wystawcy { get; set; }
    }
}
