namespace Hotel.Models
{
    public class RezervacijaBO
    {
        public int RezervacijaID { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public float Cena { get; set; }
        public bool Iskoriscena { get; set; }
        public Korisnik Korisnik { get; set; }
        public Ponuda Ponuda { get; set; }
    }
}
