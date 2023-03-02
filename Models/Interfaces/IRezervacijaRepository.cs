namespace Hotel.Models.Interfaces
{
    public interface IRezervacijaRepository
    {
        public int AddRezervacija(RezervacijaBO rezervacija);
        public void RemoveRezervacija(int id);
        public RezervacijaBO GetRezervacijaByID(int id);
        public void UpdateRezervacija(RezervacijaBO rezervacija, int rezervacijaID);
        public IEnumerable<RezervacijaBO> GetAllRezervacije();
        public IEnumerable<RezervacijaBO> GetAllRezervacijeByUser(int korisnikID);
        public IEnumerable<RezervacijaBO> GetAllRezervacijeByPonuda(int ponudaID);
        public int CountRezervacijeByKorisnikID(int korisnikID);
        public int CountRezervacijeByPonudaID(int ponudaID);
    }
}
