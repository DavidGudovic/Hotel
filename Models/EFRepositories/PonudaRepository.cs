using Hotel.Models.Interfaces;

namespace Hotel.Models.EFRepositories
{
    public class PonudaRepository : IPonudaRepository
    {
        private HotelContext hotelEntities = new HotelContext();
        public void AddPonuda(PonudaBO ponuda)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PonudaBO> GetAllPonude()
        {
            List<PonudaBO> ponude = new List<PonudaBO>();
            foreach (Ponuda ponuda in hotelEntities.Ponude)
            {
                ponude.Add(new PonudaBO
                {
                   PonudaID = ponuda.PonudaID,
                   BrojSoba = ponuda.BrojSoba,
                   Sprat = ponuda.Sprat,
                   Slika = ponuda.Slika,
                   Opis = ponuda.Opis,
                   CenaPoDanu = ponuda.CenaPoDanu,
                   Tip = ponuda.Tip,
                });
            }

            return ponude;
        }

        public PonudaBO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePonuda(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePonuda(PonudaBO ponuda, int id)
        {
            throw new NotImplementedException();
        }
    }
}
