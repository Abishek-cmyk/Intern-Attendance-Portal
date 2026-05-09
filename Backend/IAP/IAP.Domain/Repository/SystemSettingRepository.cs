using IAP.Domain.Data;
using IAP.Domain.Entity;
using IAP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IAP.Domain.Repositories
{
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SystemSettingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SystemSetting>> GetAllAsync()
        {
            return await _dbContext.SystemSettings.ToListAsync();
        }

        public async Task<SystemSetting?> GetByIdAsync(int id)
        {
            return await _dbContext.SystemSettings.FindAsync(id);
        }

        public async Task<SystemSetting?> GetByCompanyIdAsync(int companyId)
        {
            return await _dbContext.SystemSettings
                .FirstOrDefaultAsync(x => x.CompanyId == companyId);
        }

        public async Task<bool> IsCompanySettingExistsAsync(int companyId)
        {
            return await _dbContext.SystemSettings
                .AnyAsync(x => x.CompanyId == companyId);
        }

        public async Task CreateAsync(SystemSetting systemSetting)
        {
            await _dbContext.SystemSettings.AddAsync(systemSetting);
        }

        public void Update(SystemSetting systemSetting)
        {
            _dbContext.SystemSettings.Update(systemSetting);
        }

        public void Delete(SystemSetting systemSetting)
        {
            _dbContext.SystemSettings.Remove(systemSetting);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}