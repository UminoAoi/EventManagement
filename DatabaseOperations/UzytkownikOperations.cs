using Microsoft.EntityFrameworkCore;
using ProjektImplementacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektImplementacja.DatabaseOperations
{
    class UzytkownikOperations
    {
        public static Database database = new Database();
        public static Uzytkownik loggedUzytkownik = null;

        public static void LogIn(string userName, string password)
        {
            loggedUzytkownik = database.Uzytkownicy.Include(x => x.Organizator).Include(x => x.Uczestnik).Include(x => x.Pracownik).Where(x => x.NazwaUzytkownika.Equals(userName) && x.Haslo.Equals(password)).FirstOrDefault();

            if (loggedUzytkownik == null)
                throw new Exception("Złe hasło lub nazwa użytkownika.");
        }

        public static List<Event> GetLoggedOrganizatorEvents()
        {
            return database.Eventy.Where(x => x.Organizator.IdOrganizator == loggedUzytkownik.IdOrganizator).ToList();
        }

        public static List<Event> GetLoggedUczestnikEvents()
        {
            List<Bilet> bilety = database.Bilety.Include(x => x.Uczestnik).Include(x => x.Event).Where(x => x.Uczestnik.IdUczestnik == loggedUzytkownik.IdUczestnik).ToList();
            List<Event> eventy = bilety.Select(x => x.Event).ToList();
            return eventy;
        }

        public static List<Event> GetLoggedPracownikEvents()
        {
            List<Event_Pracownik> pracownicy = database.Event_Pracownicy.Include(x => x.Pracownik).Include(x => x.Event).Where(x => x.Pracownik.IdPracownik == loggedUzytkownik.IdPracownik).ToList();
            List<Event> eventy = pracownicy.Select(x => x.Event).ToList();
            return eventy;
        }

        public static List<Wystawca> GetWystawcy()
        {
            return database.Wystawcy.Include(x => x.Organizator).Where(x => x.Organizator.IdOrganizator == loggedUzytkownik.IdOrganizator).ToList();
        }

        public static void AddWystawcaToOrganizator(Wystawca wystawca)
        {
            loggedUzytkownik.Organizator.Wystawcy.Add(wystawca);
            database.SaveChanges();
        }

    }
}
