using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public enum Role
    {
        Admin, Korisnik
    }
    [Index(nameof(KorisnickoIme), IsUnique = true)]
    [Index(nameof(Email), IsUnique =true )]
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public Role Rola { get; set; }

        public ICollection<Rezervacija> Rezervacije { get; set; }

    }
}

