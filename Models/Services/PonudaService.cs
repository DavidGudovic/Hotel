using Hotel.Models.EFRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models.Services
{
    public class PonudaService
    {
        private PonudaRepository ponudaRepository = new PonudaRepository();
        private RezervacijaRepository rezervacijaRepository = new RezervacijaRepository();

        // Returns a List of Ponude that match the filter, returns all if there's no filter
        public IEnumerable<PonudaBO> filterPonude(int? numOfBeds, int? floor, Tip? tip)
        {
            List<PonudaBO> ponude = (List<PonudaBO>)ponudaRepository.GetAllPonude();

            if (numOfBeds is not null)
            {
                ponude.RemoveAll(pon => pon.BrojKreveta != numOfBeds);
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

        //Linq magic
        public IEnumerable<DateTime> GetUnavailableDates(int ponudaID)
        {
            List<RezervacijaBO> reservations = rezervacijaRepository.GetAllRezervacijeByPonuda(ponudaID).Where(rez => rez.Status == Status.Rezervisana).ToList();

            List<DateTime> bookedDates = new List<DateTime>();
            foreach (var reservation in reservations)
            {
                DateTime currentDate = reservation.DatumPocetka;
                while (currentDate <= reservation.DatumKraja)
                {
                    bookedDates.Add(currentDate);
                    currentDate = currentDate.AddDays(1);
                }
            }
            return bookedDates.OrderBy(c => c).ToList(); ;
        }

        // Returns a list of all apartments with the number of their reservations
        public List<PonudaBO> AllPonude()
        {
            List<PonudaBO> ponude = (List<PonudaBO>)ponudaRepository.GetAllPonude();
            foreach (PonudaBO ponuda in ponude)
            {
                ponuda.BrojRezervacija = rezervacijaRepository.CountRezervacijeByPonudaID(ponuda.PonudaID);
            }
            return ponude;
        }
    }
}
