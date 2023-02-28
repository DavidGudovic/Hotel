using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public enum Status
    {
        Otkazana, Završena, Rezervisana 
    }
    public class Rezervacija
    {
        [Key]
        public int RezervacijaID { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public float Cena { get; set; }
        public Status Status { get; set; }
        public int BrojGostiju { get; set; }
        public Korisnik Korisnik { get; set; }
        public Ponuda Ponuda { get; set; }
    }
}
