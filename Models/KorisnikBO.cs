using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class KorisnikBO
    {
        public int KorisnikID { get; set; }
        [Required(ErrorMessage ="Morate uneti korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Morate uneti šifru")]
        [MinLength(8,ErrorMessage = "Šifra mora biti duža od 8 karaktera")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Morate uneti ime")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti Prezime")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Morate uneti email")]
        [EmailAddress(ErrorMessage = "Invalidna email adresa")]
        public string Email { get; set; }
        public Role Rola { get; set; }
        //This value isnt stored in the database, and isnt in the Korisnik Model, but is useful in the system
        public int BrojRezervacija { get; set; }
    }
}
