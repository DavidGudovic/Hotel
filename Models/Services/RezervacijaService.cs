using Hotel.Models.EFRepositories;

namespace Hotel.Models.Services
{
    public class RezervacijaService
    {
        private RezervacijaRepository rezervacijaRepository = new RezervacijaRepository();
        private PonudaRepository ponudaRepository = new PonudaRepository();
        private KorisnikRepository korisnikRepository = new KorisnikRepository();
        private KuponRepository kuponRepository = new KuponRepository();

        // Adds the Ponuda and Korisnik objects, checks if the coupon is used, calls Rezervacija repository.
        public void CreateReservation(int ponuda_id, string name, DateTime checkin, DateTime checkout, int number_of_guests, string? coupon)
        {
            RezervacijaBO rezervacija = new RezervacijaBO()
            {
                Ponuda = ponudaRepository.GetById(ponuda_id),
                Korisnik = korisnikRepository.GetKorisnikByUsername(name),
                Status = Status.Rezervisana,
                DatumPocetka = checkin,
                DatumKraja = checkout,
                BrojGostiju = number_of_guests       
            };
            int duration = ((TimeSpan)(checkout - checkin)).Days + 1;
            rezervacija.Cena = rezervacija.Ponuda.CenaPoDanu * rezervacija.BrojGostiju * duration;

             // TODO KUPONI
            if (!String.IsNullOrEmpty(coupon))
            {
                rezervacija.Cena -= (int)(rezervacija.Cena * 0.1);
            }

            try
            {
                rezervacijaRepository.AddRezervacija(rezervacija);
            }
            catch
            {
                throw;
            }
        }


    }
}
