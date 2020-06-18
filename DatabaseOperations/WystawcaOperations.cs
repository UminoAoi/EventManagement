using Microsoft.EntityFrameworkCore;
using ProjektImplementacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektImplementacja.DatabaseOperations
{
    class WystawcaOperations
    {
        public static Database database = new Database();

        public static Wystawca GetWystawcaById(int id)
        {
            Wystawca wyst = database.Wystawcy.Where(x => x.IdWystawca == id).FirstOrDefault();

            if (wyst == null)
                throw new Exception("Nie znaleziono eventu w bazie danych.");
            else
                return wyst;
        }

        public static void AddNewWystawca(Wystawca wystawca)
        {
            try
            {
                database.Wystawcy.Add(wystawca);
                database.SaveChanges();

                UzytkownikOperations.AddWystawcaToOrganizator(wystawca);
            }
            catch(Exception ex)
            {
                throw new Exception("Dodawanie wystawcy do bazy nie powiodło się. Błąd bazy danych");
            }
        }

        internal static List<Event> GetEventyWithWystawca(Wystawca wystawca)
        {
            List<Event_Wystawca> eW = database.Event_Wystawcy.Include(x => x.Event).Where(x => x.IdWystawca == wystawca.IdWystawca).ToList();
            return eW.Select(x => x.Event).ToList();
        }
    }
}
