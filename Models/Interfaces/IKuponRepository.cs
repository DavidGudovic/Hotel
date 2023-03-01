namespace Hotel.Models.Interfaces
{
    public interface IKuponRepository
    {
        public void AddKupon(KuponBO kupon);
        public void DeleteKupon(string kuponId);
        public void UpdateKupon(KuponBO kupon, string kuponID);
        public IEnumerable<KuponBO> GetAllKupons();
        public KuponBO GetKupon(string kuponId);
    }
}
