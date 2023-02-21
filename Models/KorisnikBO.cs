namespace Hotel.Models
{
    public class KorisnikBO
    {
        public int KorisnikID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public Role Rola { get; set; }
    }
}
