namespace Hotel.Models
{
    public class PonudaBO
    {
        public int PonudaID { get; set; }
        public int BrojKreveta { get; set; }
        public int Sprat { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public float CenaPoDanu { get; set; }
        public Tip Tip { get; set; }

        //value isnt stored in database and isnt in Ponuda model but is useful in the system
        public int BrojRezervacija { get; set; }
    }
}
