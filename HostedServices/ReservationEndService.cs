using Hotel.Models;
using Hotel.Models.EFRepositories;

namespace Hotel.HostedServices
{
    public class ReservationEndService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private RezervacijaRepository _repository;

        public ReservationEndService(ILogger<ReservationEndService> logger)
        {
            _logger = logger;
            _repository = new RezervacijaRepository();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Checking if any reservation ended now");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }
        /*
         * Gets all ended reservations that werent canceled, sets their Status to Ended and updates the database
         */
        private void DoWork(object state)
        {
            List<RezervacijaBO> endedRezervacije = _repository.GetAllRezervacije()
                .Where(rez => rez.DatumKraja <= DateTime.Today && rez.Status == Status.Rezervisana).ToList();
            foreach(RezervacijaBO rez in endedRezervacije)
            {
                rez.Status = Status.Završena;
                _repository.UpdateRezervacija(rez, rez.RezervacijaID);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ReservationEndService stopped.");

            _timer?.Dispose();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
