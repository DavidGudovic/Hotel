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
                   BrojKreveta = ponuda.BrojKreveta,
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
              Ponuda ponudaEntity = hotelEntities.Ponude.Where(pon => pon.PonudaID== id).FirstOrDefault();
              return new PonudaBO()
              {
                  PonudaID = id,
                  BrojKreveta = ponudaEntity.BrojKreveta,
                  Sprat = ponudaEntity.Sprat,
                  Tip = ponudaEntity.Tip,
                  CenaPoDanu = ponudaEntity.CenaPoDanu,
                  Opis = ponudaEntity.Opis,
                  Slika = ponudaEntity.Slika
              };
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
