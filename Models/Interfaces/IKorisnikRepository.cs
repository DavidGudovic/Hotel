namespace Hotel.Models.Interfaces
{
    public interface IKorisnikRepository
    {
        public void AddKorisnik(KorisnikBO korisnik);
        public void RemoveKorisnik(KorisnikBO korisnik);
        public KorisnikBO GetKorisnikByUsername(string username);

    }
}
