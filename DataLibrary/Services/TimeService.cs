using DataLibrary.Entities;
using DataLibrary.Repository.Interfaces;
using DataLibrary.Services.Interfaces;

namespace DataLibrary.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        public TimeService(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public List<TimeModel> GetTimes() =>
            _timeRepository.GetTimes().ToList();
    }
}
