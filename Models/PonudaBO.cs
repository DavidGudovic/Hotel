using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class PonudaBO
    {
        public int PonudaID { get; set; }
        [Range(1,10, ErrorMessage ="Broj kreveta mora biti od 1 do 10")]
        [Required(ErrorMessage = "Morate uneti broj kreveta")]
        public int BrojKreveta { get; set; }
        [Range(1, 3, ErrorMessage = "Sprat mora biti od 1 do 3")]
        [Required(ErrorMessage = "Morate uneti sprat")]
        public int Sprat { get; set; }
        [Required(ErrorMessage = "Morate uneti opis apartmana")]
        public string Opis { get; set; }
        public string Slika { get; set; }
        [Range(1,100000,ErrorMessage = "Cena po danu mora biti pozitivan broj")]
        [Required(ErrorMessage = "Morate uneti cenu")]
        public float CenaPoDanu { get; set; }
        public Tip Tip { get; set; }

        //value isnt stored in database and isnt in Ponuda model but is useful in the system
        public int BrojRezervacija { get; set; }
    }
}
