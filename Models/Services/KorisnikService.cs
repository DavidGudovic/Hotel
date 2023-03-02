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
        public KorisnikBO UpdateKorisnik(KorisnikBO korisnik)
        {
            KorisnikBO izmenjenKorisnik = new KorisnikBO()
            {
                KorisnickoIme = korisnik.KorisnickoIme,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                Rola = korisnik.Rola,
                Password = BCrypt.Net.BCrypt.HashPassword(korisnik.Password)

            };

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
    }
}
