namespace Hotel.Models
{
    public class KuponBO
    {
        public string KuponID { get; set; }
        public bool Iskoriscen { get; set; } = false;
        public RezervacijaBO Rezervacija { get; set; }
    }
}
