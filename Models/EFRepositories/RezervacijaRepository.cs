using Hotel.Models.Interfaces;

namespace Hotel.Models.EFRepositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        public void AddRezervacija(RezervacijaBO rezervacija)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacije()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacijeByPonuda(int ponudaID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacijeByUser(int korisnikID)
        {
            throw new NotImplementedException();
        }

        public RezervacijaBO GetRezervacijaByID(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRezervacija(int id)
        {
            throw new NotImplementedException();
        }
    }
}
