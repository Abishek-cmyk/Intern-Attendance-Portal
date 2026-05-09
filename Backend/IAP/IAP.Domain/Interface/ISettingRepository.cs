using IAP.Domain.Entity;

namespace IAP.Domain.Interfaces
{
    public interface ISettingRepository
    {
        Task<List<SystemSetting>> GetAllAsync();
        Task<SystemSetting?> GetByIdAsync(int id);
        Task<SystemSetting?> GetByCompanyIdAsync(int companyId);
        Task<bool> IsCompanySettingExistsAsync(int companyId);
        Task CreateAsync(SystemSetting systemSetting);
        void Update(SystemSetting systemSetting);
        void Delete(SystemSetting systemSetting);
        Task<bool> SaveAsync();
    }
}