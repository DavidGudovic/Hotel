using Hotel.Models.Interfaces;

namespace Hotel.Models.EFRepositories
{
    public class KuponRepository : IKuponRepository
    {
        private HotelContext hotelEntities = new HotelContext();
        public void AddKupon(KuponBO kupon)
        {
            try
            {
                hotelEntities.Kuponi.Add(new Kupon()
                {
                    KuponID = kupon.KuponID,
                    Iskoriscen = kupon.Iskoriscen,
                    Rezervacija = kupon.Rezervacija
                }) ;
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteKupon(int kuponId)
        {
            try
            {
                hotelEntities.Kuponi.Remove(hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponId).FirstOrDefault());
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<KuponBO> GetAllKupons()
        {
            List<KuponBO> kuponi = new List<KuponBO>();
            foreach(Kupon kupon in hotelEntities.Kuponi)
            {
                kuponi.Add(new KuponBO()
                {
                    KuponID = kupon.KuponID,
                    Iskoriscen = kupon.Iskoriscen,
                    Rezervacija = kupon.Rezervacija
                });
            }
            return kuponi;
        }

        public KuponBO GetKupon(int kuponId)
        {
            Kupon kupon = hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponId).FirstOrDefault();
            return new KuponBO()
            {
                KuponID = kuponId,
                Iskoriscen = kupon.Iskoriscen,
                Rezervacija = kupon.Rezervacija
            };
        }

        public void UpdateKupon(KuponBO kupon, int kuponID)
        {
            Kupon kuponEntity = hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponID).FirstOrDefault();
            kuponEntity.Rezervacija = kupon.Rezervacija;
            kuponEntity.Iskoriscen = kupon.Iskoriscen;

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
