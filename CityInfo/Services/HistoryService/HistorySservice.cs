using System;
using CityInfo.Models;
using CityInfo.Repositories;

namespace CityInfo.Services
{
    public class HistorySservice : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistorySservice(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task AddHistory(History newHistory)
        {
            var historyExists = await _historyRepository.GetByCountry(newHistory.Country);
            if (historyExists == null)
            {
                _historyRepository.Create(newHistory);
                await _historyRepository.SaveChanges();
            }
        }

        public async Task<IEnumerable<History>> GetHistoryConsultation()
        {
            return await _historyRepository.GetHistoryConsultation();
        }
    }
}

