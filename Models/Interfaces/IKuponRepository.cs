namespace Hotel.Models.Interfaces
{
    public interface IKuponRepository
    {
        public void AddKupon(KuponBO kupon);
        public void DeleteKupon(int kuponId);
        public void UpdateKupon(KuponBO kupon, int kuponID);
        public IEnumerable<KuponBO> GetAllKupons();
        public KuponBO GetKupon(int kuponId);
    }
}
