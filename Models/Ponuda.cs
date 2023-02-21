using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public enum Tip
    {
        Polupansion, Pansion, AllInclusive, Najam
    }
    public class Ponuda
    {
        [Key]
        public int PonudaID { get; set; }
        public int BrojSoba { get; set; }
        public int Sprat { get; set; }
        public string Slika { get; set; }
        public float CenaPoDanu { get; set; }
        public Tip Tip { get; set; }

    }
}
