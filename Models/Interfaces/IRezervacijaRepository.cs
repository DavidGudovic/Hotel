namespace Hotel.Models.Interfaces
{
    public interface IRezervacijaRepository
    {
        public void AddRezervacija(RezervacijaBO rezervacija);
        public void RemoveRezervacija(int id);
        public RezervacijaBO GetRezervacijaByID(int id);
        public IEnumerable<RezervacijaBO> GetAllRezervacije();
        public IEnumerable<RezervacijaBO> GetAllRezervacijeByUser(int korisnikID);
        public IEnumerable<RezervacijaBO> GetAllRezervacijeByPonuda(int ponudaID);
    }
}
