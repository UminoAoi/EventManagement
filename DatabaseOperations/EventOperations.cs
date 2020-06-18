using Microsoft.EntityFrameworkCore;
using ProjektImplementacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektImplementacja.DatabaseOperations
{
    class EventOperations
    {
        public static Database database = new Database();

        public static Event GetEventById(int id)
        {
            Event evnt = database.Eventy.Where(x => x.IdEvent == id).FirstOrDefault();
            if(evnt == null)
                throw new Exception("Nie znaleziono eventu w bazie danych.");
            else
                return evnt;
        }

        public static List<Wystawca> GetWystawcyOfEvent(Event evnt)
        {
            List<Event_Wystawca> evnt_wyst = database.Event_Wystawcy.Include(x => x.Wystawca).Include(x => x.Event).Where(x => x.Event == evnt).ToList();
            List<Wystawca> wyst = evnt_wyst.Select(x => x.Wystawca).ToList();
            return wyst;
        }

        public static List<Atrakcja> GetAtrakcjeOfEvent(Event evnt)
        {
            return database.Atrakcje.Where(x => x.IdEvent == evnt.IdEvent).ToList();
        }

        public static void AddWystawcaToEvent(Event evnt, Wystawca wyst)
        {
            Event_Wystawca check = database.Event_Wystawcy.Where(x => x.IdEvent == evnt.IdEvent && x.IdWystawca == wyst.IdWystawca).FirstOrDefault();

            if(check != null)
            {
                throw new Exception("Wystawca jest już przypisany do tego eventu.");
            }

            try
            {
                database.Event_Wystawcy.Add(new Event_Wystawca
                {
                    IdEvent = evnt.IdEvent,
                    IdWystawca = wyst.IdWystawca
                });

                database.SaveChanges();
            }
            catch
            {
                throw new Exception("Dodawanie wystawcy do eventu nie powiodło się. Błąd bazy danych");
            }

        }
    }
}
