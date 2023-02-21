using Hotel.Models.EFRepositories;
using Hotel.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace Hotel.Models.Services
{
    public class KorisnikService
    {
        private IKorisnikRepository korisnikRepository = new KorisnikRepository();
        public void Register(KorisnikBO korisnikBO)
        {
            korisnikBO.Password = BCrypt.Net.BCrypt.HashPassword(korisnikBO.Password);
            try { 
                korisnikRepository.AddKorisnik(korisnikBO);
            } catch(Exception ex) {
                throw ex;
            }
        }
    }
}
