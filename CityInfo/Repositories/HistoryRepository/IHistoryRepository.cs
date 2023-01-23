using System;
using CityInfo.Models;

namespace CityInfo.Repositories
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistoryConsultation();

        void Create(History history);

        Task<bool> SaveChanges();
    }
}

