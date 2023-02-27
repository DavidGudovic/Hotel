namespace Hotel.Models.Interfaces
{
    public interface IKorisnikRepository
    {
        public void AddKorisnik(KorisnikBO korisnik);
        public void RemoveKorisnik(KorisnikBO korisnik);
        public void UpdateKorisnik(KorisnikBO korisnik, int ID);
        public IEnumerable<KorisnikBO> GetAllKorisnike();
        public KorisnikBO GetKorisnikByUsername(string username);
        public KorisnikBO GetKorisnikByID(int korisnikID);
    }
}
