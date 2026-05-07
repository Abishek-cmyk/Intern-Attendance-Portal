using IAP.Domain.Data;
using IAP.Domain.Entity;
using IAP.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace IAP.Domain.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Company
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _dbContext.Company
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            var normalizedEmail = email.Trim().ToLower();

            return await _dbContext.Company
                .AnyAsync(x => x.Email != null &&
                               x.Email.ToLower() == normalizedEmail);
        }

        public async Task CreateAsync(Company company)
        {
            await _dbContext.Company.AddAsync(company);
        }

        public void Update(Company company)
        {
            _dbContext.Company.Update(company);
        }

        public void Delete(Company company)
        {
            _dbContext.Company.Remove(company);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}