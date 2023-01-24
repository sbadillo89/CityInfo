using System;
using CityInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly SerbadTestContext _dbContext;

        public HistoryRepository(SerbadTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<History>> GetHistoryConsultation()
        {
            return await _dbContext.Histories.ToListAsync();
        }

        public void Create(History history)
        {
            if (history == null)
                throw new ArgumentNullException(nameof(history));

            _dbContext.Histories.Add(history);
        }

        public async Task<bool> SaveChanges()
        {
            return Convert.ToBoolean(await _dbContext.SaveChangesAsync());
        }

        public async Task<History> GetByCountry(string country)
        {
            return await _dbContext.Histories.FirstOrDefaultAsync(h=> h.Country == country);
        }
    }
}

