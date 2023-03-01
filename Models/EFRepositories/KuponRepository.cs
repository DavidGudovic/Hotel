using Hotel.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                    Rezervacija = hotelEntities.Rezervacije.Where(rez => rez.RezervacijaID == kupon.Rezervacija.RezervacijaID).First()
                }) ;
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteKupon(string kuponID)
        {
            try
            {
                hotelEntities.Kuponi.Remove(hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponID).FirstOrDefault());
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
            foreach(Kupon kupon in hotelEntities.Kuponi.Include(kup => kup.Rezervacija))
            {
                kuponi.Add(new KuponBO()
                {
                    KuponID = kupon.KuponID,
                    Iskoriscen = kupon.Iskoriscen,
                    Rezervacija = new RezervacijaBO()
                    {
                        RezervacijaID = kupon.Rezervacija.RezervacijaID
                    }
                });
            }
            return kuponi;
        }

        public KuponBO GetKupon(string kuponID)
        {
            Kupon kupon = hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponID).FirstOrDefault();
            return new KuponBO()
            {
                KuponID = kuponID,
                Iskoriscen = kupon.Iskoriscen,
                Rezervacija = new RezervacijaBO()
                {
                    RezervacijaID = kupon.Rezervacija.RezervacijaID
                }
            };
        }

        public void UpdateKupon(KuponBO kupon, string kuponID)
        {         
            try
            {
                Kupon kuponEntity = hotelEntities.Kuponi.Where(kup => kup.KuponID == kuponID).FirstOrDefault();
                kuponEntity.Rezervacija = hotelEntities.Rezervacije.Where(rez => rez.RezervacijaID == kuponEntity.Rezervacija.RezervacijaID).First();
                kuponEntity.Iskoriscen = kupon.Iskoriscen;
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
            
        }
    }
}
