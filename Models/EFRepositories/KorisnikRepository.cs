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
                hotelEntities.Korisnici.Add(new Korisnik()
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
        //Returns an IEnumerable of all the users
        public IEnumerable<KorisnikBO> GetAllKorisnike()
        {
            List<KorisnikBO> korisnici = new List<KorisnikBO>();
            foreach(Korisnik kor in hotelEntities.Korisnici)
            {
                korisnici.Add(new KorisnikBO()
                {
                    KorisnikID = kor.KorisnikID,
                    KorisnickoIme = kor.KorisnickoIme,
                    Password = kor.Password,
                    Ime = kor.Ime,
                    Prezime= kor.Prezime,
                    Email = kor.Email,
                    Rola = kor.Rola
                }); 
            }

            return korisnici;
        }

        // Returns a Korisnik Business Object of the entity with matching id
        public KorisnikBO GetKorisnikByID(int korisnikID)
        {
            Korisnik? korisnikEntity = hotelEntities.Korisnici.Where(kor => kor.KorisnikID == korisnikID).FirstOrDefault();

            if (korisnikEntity != null)
            {
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
            }
            else return new KorisnikBO();
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
        //Removes the passed user 

        public void RemoveKorisnik(KorisnikBO korisnik)
        {
            try
            {
                hotelEntities.Korisnici.Remove(hotelEntities.Korisnici.Where(kor => kor.KorisnikID == korisnik.KorisnikID).Single());
                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
            

        }
        //Updates the user with the passed ID with the data from the passed KorisnikBO
        public void UpdateKorisnik(KorisnikBO korisnik, int ID)
        {
            try
            {
                Korisnik korisnikEntity = hotelEntities.Korisnici.Where(kor => kor.KorisnikID == ID).Single();
                korisnikEntity.Email = korisnik.Email;
                korisnikEntity.KorisnickoIme = korisnik.KorisnickoIme;
                korisnikEntity.Ime = korisnik.Ime;
                korisnikEntity.Prezime = korisnik.Prezime;
                korisnikEntity.Password = korisnik.Password;
                korisnikEntity.Rola = korisnik.Rola;

                hotelEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
