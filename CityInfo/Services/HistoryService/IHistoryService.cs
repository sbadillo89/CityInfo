using System;
using CityInfo.Models;

namespace CityInfo.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistoryConsultation();

        Task AddHistory(History newHistory);
    }
}

