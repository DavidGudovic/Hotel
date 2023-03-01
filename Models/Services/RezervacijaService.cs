using Hotel.Models.EFRepositories;

namespace Hotel.Models.Services
{
    public class RezervacijaService
    {
        private RezervacijaRepository rezervacijaRepository = new RezervacijaRepository();
        private PonudaRepository ponudaRepository = new PonudaRepository();
        private KorisnikRepository korisnikRepository = new KorisnikRepository();
        private KuponRepository kuponRepository = new KuponRepository();
        private KuponService kuponService= new KuponService();

        // Adds the Ponuda and Korisnik objects, checks if the coupon is used, calls Rezervacija repository. If the duration is more then 10 days, returns a coupon string
        public string CreateReservation(int ponuda_id, string name, DateTime checkin, DateTime checkout, int number_of_guests,float price, string? coupon)
        {
            int reservationID;
            int duration = ((TimeSpan)(checkout - checkin)).Days + 1;
            RezervacijaBO rezervacija = new RezervacijaBO()
            {
                Ponuda = ponudaRepository.GetById(ponuda_id),
                Korisnik = korisnikRepository.GetKorisnikByUsername(name),
                Status = Status.Rezervisana,
                DatumPocetka = checkin,
                DatumKraja = checkout,
                BrojGostiju = number_of_guests  ,
                Cena = price
            };
            try
            {
                //discount price if the coupon isnt empty
                if (!String.IsNullOrEmpty(coupon))
                {
                    rezervacija.Cena -=(int)(rezervacija.Cena * 0.1);
                }
                //Add reservation to DB
                reservationID = rezervacijaRepository.AddRezervacija(rezervacija);
                //Update the coupon in the db to be applied
                if (!String.IsNullOrEmpty(coupon))
                {
                    kuponService.ApplyCoupon(coupon, rezervacija);
                }
            }
            catch
            {
                throw;
            }
                // If the reservation is longer then 10 days, creates a new coupon and returns it, otherwise returns empty string, acts as void
                return duration > 10 ? kuponService.AddCouponCode(reservationID) : "";
            
 
        }

        //Calculates the price without a coupon applied
        public float CalculateSubTotalPrice(int ponuda_id, int guests, DateTime checkin, DateTime checkout)
        {
            int duration = ((TimeSpan)(checkout - checkin)).Days + 1;
            return ponudaRepository.GetById(ponuda_id).CenaPoDanu * guests * duration;
        }

        //Checks wether the new checin and checkout date overlap with any exissting reservations
        //NOTE: Useless in this project as there's only one user, but would be useful if multiple people were making a reservation on the same apartment in the same time
        public bool ValidateReservationDate(DateTime checkin, DateTime checkout, int ponudaID)
        {
            return !rezervacijaRepository.GetAllRezervacijeByPonuda(ponudaID).Select(rez => new { rez.DatumPocetka, rez.DatumKraja }).ToList().Any(r =>
                (checkin <= r.DatumKraja) && (checkout >= r.DatumPocetka)
            ); 

        }
    }
}
