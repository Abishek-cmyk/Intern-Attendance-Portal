using IAP.Application.DTOs.Company;
using IAP.Domain.Entity;
using IAP.Domain.Interface;

namespace IAP.Application.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<List<CompanyDTO>> GetAllCompanyAsync()
        {
            var companies = await _companyRepo.GetAllAsync();

            return companies.Select(company => new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                ContactPerson = company.ContactPerson ?? string.Empty,
                Phone = company.Phone ?? string.Empty,
                Email = company.Email ?? string.Empty,
                CreatedAt = company.CreatedAt,
                UpdatedAt = company.UpdatedAt
            }).ToList();
        }

        public async Task<CompanyDTO?> GetCompanyByIdAsync(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);

            if (company == null)
            {
                return null;
            }

            return new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                ContactPerson = company.ContactPerson ?? string.Empty,
                Phone = company.Phone ?? string.Empty,
                Email = company.Email ?? string.Empty,
                CreatedAt = company.CreatedAt,
                UpdatedAt = company.UpdatedAt
            };
        }

        public async Task<string> CreateCompanyAsync(CreateCompanyDTO dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                Address = dto.Address,
                ContactPerson = dto.ContactPerson,
                Phone = dto.Phone,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _companyRepo.CreateAsync(company);

            var result = await _companyRepo.SaveAsync();

            return result ? "Company created successfully." : "Failed to create company.";
        }

        public async Task<string> UpdateCompanyAsync(int id, UpdateCompanyDTO dto)
        {
            var company = await _companyRepo.GetByIdAsync(id);

            if (company == null)
            {
                return "Company not found.";
            }

            company.Name = dto.Name;
            company.Address = dto.Address;
            company.ContactPerson = dto.ContactPerson;
            company.Phone = dto.Phone;
            company.Email = dto.Email;
            company.UpdatedAt = DateTime.UtcNow;

            _companyRepo.Update(company);

            var result = await _companyRepo.SaveAsync();

            return result ? "Company updated successfully." : "Failed to update company.";
        }

        public async Task<string> DeleteCompanyAsync(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);

            if (company == null)
            {
                return "Company not found.";
            }

            _companyRepo.Delete(company);

            var result = await _companyRepo.SaveAsync();

            return result ? "Company deleted successfully." : "Failed to delete company.";
        }
    }
}