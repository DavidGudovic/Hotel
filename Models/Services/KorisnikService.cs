using Hotel.Middleware;
using Hotel.Models.EFRepositories;
using Hotel.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Hotel.Models.Services
{
    public class KorisnikService
    {
        private IKorisnikRepository korisnikRepository = new KorisnikRepository();
        private IRezervacijaRepository rezervacijaRepository= new RezervacijaRepository();

        //Update users information
        public KorisnikBO UpdateKorisnik(KorisnikBO korisnik, bool admin_changed_password = false)
        {
            KorisnikBO izmenjenKorisnik = new KorisnikBO()
            {
                KorisnickoIme = korisnik.KorisnickoIme,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                Rola = korisnik.Rola
            };

            if (admin_changed_password)
            {
                izmenjenKorisnik.Password = korisnikRepository.GetKorisnikByID(korisnik.KorisnikID).Password;
            }
            else
            {
                izmenjenKorisnik.Password = BCrypt.Net.BCrypt.HashPassword(korisnik.Password);
            }

            try
            {
                korisnikRepository.UpdateKorisnik(izmenjenKorisnik, korisnik.KorisnikID);
                return izmenjenKorisnik;
            }
            catch
            {
                throw;
            }
         
        }

        //Register a new user
        public void Register(KorisnikBO korisnikBO)
        {
            korisnikBO.Password = BCrypt.Net.BCrypt.HashPassword(korisnikBO.Password);
            try { 
                korisnikRepository.AddKorisnik(korisnikBO);
            } catch(Exception ex) {
                throw ex;
            }
        }


        //Verify the password sent with the users password
        public bool VerifyPassword(string password, int korisnikID)
        {
            return BCrypt.Net.BCrypt.Verify(password, korisnikRepository.GetKorisnikByID(korisnikID).Password);
        }

        //calls RemoveKorisnik from KorisnikRepository : TODO handle deleted users Reservations
        public void DeleteKorisnik(int korisnikID)
        {
           korisnikRepository.RemoveKorisnik(korisnikRepository.GetKorisnikByID(korisnikID));
        }

        // Returns a list of all users with the number of their reservations
        public List<KorisnikBO> AllKorisnici()
        {
            List<KorisnikBO> korisnici = (List<KorisnikBO>)korisnikRepository.GetAllKorisnike();
            foreach(KorisnikBO korisnik in korisnici)
            {
                korisnik.BrojRezervacija = rezervacijaRepository.CountRezervacijeByKorisnikID(korisnik.KorisnikID);
            }
            return korisnici;
        }

        //Invalidates the user for next request and removes him from database
        public void RemoveUser(int korisnikID)
        {
            try
            {
                // Make the user logout on next request
                InvalidatedUsersList.AddInvalidatedUser(korisnikRepository.GetKorisnikByID(korisnikID).KorisnickoIme);
                korisnikRepository.RemoveKorisnik(new KorisnikBO() { KorisnikID = korisnikID });
            }
            catch
            {
                throw;
            }

        }
        //Returns the user
        public KorisnikBO GetKorisnik(int korisnikID)
        {
            return korisnikRepository.GetKorisnikByID(korisnikID);
        }
    }
}
