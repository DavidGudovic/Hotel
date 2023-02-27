using Hotel.Models.EFRepositories;

namespace Hotel.Models.Services
{
    public class PonudaService
    {
        private PonudaRepository ponudaRepository = new PonudaRepository();

        // Returns a List of Ponude that match the filter, returns all if there's no filter
        public IEnumerable<PonudaBO> filterPonude(int? numOfRooms, int? floor, Tip? tip)
        {
            List<PonudaBO> ponude = (List<PonudaBO>)ponudaRepository.GetAllPonude();

            if(numOfRooms is not null)
            {
                ponude.RemoveAll(pon => pon.BrojSoba != numOfRooms);
            }

            if (floor is not null)
            {
                ponude.RemoveAll(pon => pon.Sprat != floor);
            }

            if (tip is not null)
            {
                ponude.RemoveAll(pon => pon.Tip != tip);
            }

            return ponude;
        }
    }
}
