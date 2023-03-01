using Hotel.Models.EFRepositories;
using System;

namespace Hotel.Models.Services
{
    public class KuponService
    {
        private KuponRepository kuponRepository = new KuponRepository();
        //Sets the coupon used to true and changes the foreign key to point to the reservation that its used on
        public bool ApplyCoupon(string couponID, RezervacijaBO rezervacija)
        {
            if(DoesCouponCodeExists(couponID))
            {
                kuponRepository.UpdateKupon(new KuponBO()
                {
                    KuponID = couponID,
                    Iskoriscen = true,
                    Rezervacija = rezervacija
                }, couponID);
                return true;
            }
            return false;
        }
        //Generates unique 8 character coupon code
        private string GenerateCouponCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string couponCode;

            do
            {
                couponCode = new string(Enumerable.Repeat(chars, 8)
                  .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
            }
            while (DoesCouponCodeExists(couponCode)); // check if the coupon code already exists

            return couponCode;
        }

        //Generates a new coupon, adds it to the database and returns it as a string
        public string AddCouponCode(int rezervacijaID)
        {
            string coupon = GenerateCouponCode();
            try
            {
                kuponRepository.AddKupon(new KuponBO()
                {
                    KuponID = coupon,
                    Iskoriscen = false,
                    Rezervacija = new RezervacijaBO() { 
                        RezervacijaID = rezervacijaID
                    },
                });
            }
            catch
            {
                throw;
            }
            return coupon;
        }

        //Checks if the coupon code exists
        public bool DoesCouponCodeExists(string couponCode)
        {
            List<KuponBO> kuponi = (List<KuponBO>)kuponRepository.GetAllKupons();
            if (kuponi.Select(kup => kup.KuponID).ToList().Contains(couponCode)) return true;
            return false;
        }

        public bool IsCouponUsed(string coupon)
        {
            return kuponRepository.GetKupon(coupon).Iskoriscen;
        }
    }
}
