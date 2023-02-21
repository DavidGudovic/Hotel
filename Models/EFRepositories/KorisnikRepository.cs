using Hotel.Models.Interfaces;
using System.Data.SqlTypes;

namespace Hotel.Models.EFRepositories
{
    public class KorisnikRepository : IKorisnikRepository
    {
        private HotelContext hotelEntities = new HotelContext();
        //Adds a new Korisnik entity to the database
        public void AddKorisnik(KorisnikBO korisnik)
        {
            try {
                hotelEntities.Add(new Korisnik()
                {
                    KorisnickoIme = korisnik.KorisnickoIme,
                    Password = korisnik.Password,
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Email = korisnik.Email,
                    Rola = Role.Korisnik
                });
                hotelEntities.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
           
        }
        // Returns a Korisnik Business Object of the entity with matching username
        public KorisnikBO GetKorisnikByUsername(string username)
        {
            Korisnik? korisnikEntity = hotelEntities.Korisnici.Where(kor => kor.KorisnickoIme == username).FirstOrDefault();

            if (korisnikEntity != null) {
                return new KorisnikBO()
                {
                    KorisnikID = korisnikEntity.KorisnikID,
                    KorisnickoIme = korisnikEntity.KorisnickoIme,
                    Ime = korisnikEntity.Ime,
                    Prezime = korisnikEntity.Prezime,
                    Password = korisnikEntity.Password,
                    Email = korisnikEntity.Email,
                    Rola = korisnikEntity.Rola
                };
            } else return new KorisnikBO();
        }

        public void RemoveKorisnik(KorisnikBO korisnik)
        {
            throw new NotImplementedException();
        }
    }
}
