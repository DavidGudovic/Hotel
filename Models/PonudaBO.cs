namespace Hotel.Models
{
    public class PonudaBO
    {
        public int PonudaID { get; set; }
        public int BrojSoba { get; set; }
        public int Sprat { get; set; }
        public string Slika { get; set; }
        public float CenaPoDanu { get; set; }
        public Tip Tip { get; set; }
    }
}
