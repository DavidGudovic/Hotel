namespace Hotel.Models
{
    public class RezervacijaBO
    {
        public int RezervacijaID { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public float Cena { get; set; }
        public Status Status { get; set; }
        public int BrojGostiju { get; set; }
        public KorisnikBO Korisnik { get; set; }
        public PonudaBO Ponuda { get; set; }
    }
}
