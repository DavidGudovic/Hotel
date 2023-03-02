using Hotel.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models.EFRepositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private HotelContext hotelEntities = new HotelContext();

        //Returns the new entity ID 
        public int AddRezervacija(RezervacijaBO rezervacija)
        {
            try
            {
                Rezervacija reservationEntity = new Rezervacija()
                {
                    DatumKraja = rezervacija.DatumKraja,
                    DatumPocetka = rezervacija.DatumPocetka,
                    Status = Status.Rezervisana,
                    Cena = rezervacija.Cena,
                    Ponuda = hotelEntities.Ponude.Where(pon => pon.PonudaID == rezervacija.Ponuda.PonudaID).First(),
                    Korisnik = hotelEntities.Korisnici.Where(kor => kor.KorisnikID == rezervacija.Korisnik.KorisnikID).First(),
                    BrojGostiju = rezervacija.BrojGostiju
                };
                hotelEntities.Rezervacije.Add(reservationEntity);
                hotelEntities.SaveChanges();
                return reservationEntity.RezervacijaID;
            }
            catch
            {
                throw;
            }
           
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacije()
        {
            List<RezervacijaBO> rezervacije = new List<RezervacijaBO>();
            foreach (Rezervacija rezervacijaEntity in hotelEntities.Rezervacije.Include(r => r.Korisnik).Include(r => r.Ponuda))
            {
                rezervacije.Add(new RezervacijaBO()
                {
                    RezervacijaID = rezervacijaEntity.RezervacijaID,
                    BrojGostiju = rezervacijaEntity.BrojGostiju,
                    Cena = rezervacijaEntity.Cena,
                    DatumKraja = rezervacijaEntity.DatumKraja,
                    DatumPocetka = rezervacijaEntity.DatumPocetka,
                    Status = rezervacijaEntity.Status,
                    Ponuda = new PonudaBO()
                    {
                        PonudaID = rezervacijaEntity.Ponuda.PonudaID,
                        BrojKreveta = rezervacijaEntity.Ponuda.BrojKreveta,
                        Slika = rezervacijaEntity.Ponuda.Slika,
                        Opis = rezervacijaEntity.Ponuda.Opis,
                        Tip = rezervacijaEntity.Ponuda.Tip,
                        Sprat = rezervacijaEntity.Ponuda.Sprat,
                        CenaPoDanu = rezervacijaEntity.Ponuda.CenaPoDanu,
                    },
                    Korisnik = new KorisnikBO()
                    {
                        KorisnikID = rezervacijaEntity.Korisnik.KorisnikID,
                        Email = rezervacijaEntity.Korisnik.Email,
                        KorisnickoIme = rezervacijaEntity.Korisnik.KorisnickoIme,
                        Ime = rezervacijaEntity.Korisnik.Ime,
                        Prezime = rezervacijaEntity.Korisnik.Prezime,
                        Password = rezervacijaEntity.Korisnik.Password,
                        Rola = rezervacijaEntity.Korisnik.Rola
                    }
                });
            }
            return rezervacije;
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacijeByPonuda(int ponudaID)
        {
            List<RezervacijaBO> rezervacije = new List<RezervacijaBO>();
            foreach (Rezervacija rezervacijaEntity in hotelEntities.Rezervacije.Where(rez => rez.Ponuda.PonudaID == ponudaID).Include(r => r.Korisnik).Include(r => r.Ponuda))
            {
                rezervacije.Add(new RezervacijaBO()
                {
                    RezervacijaID = rezervacijaEntity.RezervacijaID,
                    BrojGostiju = rezervacijaEntity.BrojGostiju,
                    Cena = rezervacijaEntity.Cena,
                    DatumKraja = rezervacijaEntity.DatumKraja,
                    DatumPocetka = rezervacijaEntity.DatumPocetka,
                    Status = rezervacijaEntity.Status,
                    Ponuda = new PonudaBO(){
                        PonudaID = rezervacijaEntity.Ponuda.PonudaID,
                        BrojKreveta = rezervacijaEntity.Ponuda.BrojKreveta,
                        Slika = rezervacijaEntity.Ponuda.Slika,
                        Opis = rezervacijaEntity.Ponuda.Opis,
                        Tip = rezervacijaEntity.Ponuda.Tip,
                        Sprat = rezervacijaEntity.Ponuda.Sprat,
                        CenaPoDanu = rezervacijaEntity.Ponuda.CenaPoDanu,
                    },
                    Korisnik = new KorisnikBO()
                    {
                        KorisnikID = rezervacijaEntity.Korisnik.KorisnikID,
                        Email = rezervacijaEntity.Korisnik.Email,
                        KorisnickoIme = rezervacijaEntity.Korisnik.KorisnickoIme,
                        Ime = rezervacijaEntity.Korisnik.Ime,
                        Prezime = rezervacijaEntity.Korisnik.Prezime,
                        Password = rezervacijaEntity.Korisnik.Password,
                        Rola = rezervacijaEntity.Korisnik.Rola
                    }
                });
            }
            return rezervacije;
        }

        public IEnumerable<RezervacijaBO> GetAllRezervacijeByUser(int korisnikID)
        {
            List<RezervacijaBO> rezervacije = new List<RezervacijaBO>();
            foreach (Rezervacija rezervacijaEntity in hotelEntities.Rezervacije.Where(rez => rez.Korisnik.KorisnikID == korisnikID).Include(r => r.Korisnik).Include(r => r.Ponuda))
            {
                rezervacije.Add(new RezervacijaBO()
                {
                    RezervacijaID = rezervacijaEntity.RezervacijaID,
                    BrojGostiju = rezervacijaEntity.BrojGostiju,
                    Cena = rezervacijaEntity.Cena,
                    DatumKraja = rezervacijaEntity.DatumKraja,
                    DatumPocetka = rezervacijaEntity.DatumPocetka,
                    Status = rezervacijaEntity.Status,
                    Ponuda = new PonudaBO()
                    {
                        PonudaID = rezervacijaEntity.Ponuda.PonudaID,
                        BrojKreveta = rezervacijaEntity.Ponuda.BrojKreveta,
                        Slika = rezervacijaEntity.Ponuda.Slika,
                        Opis = rezervacijaEntity.Ponuda.Opis,
                        Tip = rezervacijaEntity.Ponuda.Tip,
                        Sprat = rezervacijaEntity.Ponuda.Sprat,
                        CenaPoDanu = rezervacijaEntity.Ponuda.CenaPoDanu,
                    },
                    Korisnik = new KorisnikBO()
                    {
                        KorisnikID = rezervacijaEntity.Korisnik.KorisnikID,
                        Email = rezervacijaEntity.Korisnik.Email,
                        KorisnickoIme = rezervacijaEntity.Korisnik.KorisnickoIme,
                        Ime = rezervacijaEntity.Korisnik.Ime,
                        Prezime = rezervacijaEntity.Korisnik.Prezime,
                        Password = rezervacijaEntity.Korisnik.Password,
                        Rola = rezervacijaEntity.Korisnik.Rola
                    }
                });
            }
            return rezervacije;
        }
        // Only updates status since we dont need more for this websites functionality
        public void UpdateRezervacija(RezervacijaBO rezervacija, int rezervacijaID)
        {
            try
            {
                Rezervacija rezervacijaEntity = hotelEntities.Rezervacije.Where(rez => rez.RezervacijaID == rezervacijaID).Include(r => r.Korisnik).Include(r => r.Ponuda).First();
                rezervacijaEntity.Status = rezervacija.Status;
                hotelEntities.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public RezervacijaBO GetRezervacijaByID(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRezervacija(int id)
        {
            throw new NotImplementedException();
        }

        public int CountRezervacijeByKorisnikID(int korisnikID)
        {
            return hotelEntities.Rezervacije.Where(r => r.Korisnik.KorisnikID == korisnikID).Count();
        }

        public int CountRezervacijeByPonudaID(int ponudaID)
        {
            return hotelEntities.Rezervacije.Where(r => r.Ponuda.PonudaID == ponudaID).Count();
        }
    }
}
