using IAP.Domain.Entity;

namespace IAP.Domain.Interface
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();

        Task<Company?> GetByIdAsync(int id);

        Task<bool> IsEmailExistsAsync(string email);

        Task CreateAsync(Company company);

        void Update(Company company);

        void Delete(Company company);


        Task<bool> SaveAsync();
    }
}