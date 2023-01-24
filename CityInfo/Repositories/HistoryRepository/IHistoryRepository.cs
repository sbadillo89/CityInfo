using System;
using CityInfo.Models;

namespace CityInfo.Repositories
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistoryConsultation();

        Task<History> GetByCountry(string country);

        void Create(History history);

        Task<bool> SaveChanges();
    }
}

