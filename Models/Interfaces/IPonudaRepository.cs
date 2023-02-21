namespace Hotel.Models.Interfaces
{
    public interface IPonudaRepository
    {
        public void AddPonuda(PonudaBO ponuda);
        public void RemovePonuda(int id);
        public void UpdatePonuda(PonudaBO ponuda, int id);
        public IEnumerable<PonudaBO> GetAllPonude();
        public PonudaBO GetById(int id);
    }
}
