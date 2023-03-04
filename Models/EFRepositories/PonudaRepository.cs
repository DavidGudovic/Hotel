using Hotel.Models.Interfaces;

namespace Hotel.Models.EFRepositories
{
    public class PonudaRepository : IPonudaRepository
    {
        private HotelContext hotelEntities = new HotelContext();
        public void AddPonuda(PonudaBO ponuda)
        {
            try
            {
                Ponuda ponudaEntity = new Ponuda()
                {
                    BrojKreveta = ponuda.BrojKreveta,
                    Sprat = ponuda.Sprat,
                    CenaPoDanu = ponuda.CenaPoDanu,
                    Tip = ponuda.Tip,
                    Slika = ponuda.Slika,
                    Opis = ponuda.Opis,
                };
                hotelEntities.Ponude.Add(ponudaEntity);
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
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
            try
            {
                hotelEntities.Ponude.Remove(hotelEntities.Ponude.Where(pon => pon.PonudaID== id).Single());
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePonuda(PonudaBO ponuda, int ponudaID)
        {
            Ponuda ponudaEntity = hotelEntities.Ponude.Where(pon => pon.PonudaID == ponudaID).Single();
            ponudaEntity.Sprat = ponuda.Sprat;
            ponudaEntity.Opis = ponuda.Opis;
            ponudaEntity.Tip = ponuda.Tip;
            ponudaEntity.Slika = ponuda.Slika;
            ponudaEntity.BrojKreveta = ponuda.BrojKreveta;
            ponudaEntity.CenaPoDanu = ponuda.CenaPoDanu;
            try
            {
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
