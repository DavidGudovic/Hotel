using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Kupon
    {
        [Key]
        public int KuponID { get; set; }
        public bool Iskoriscen { get; set; } = false;
        public Rezervacija Rezervacija { get; set; }

    }
}
