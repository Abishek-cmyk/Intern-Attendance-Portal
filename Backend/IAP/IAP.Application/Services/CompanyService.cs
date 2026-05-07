using AutoMapper;
using IAP.Application.DTOs.Company;
using IAP.Domain.Entity;
using IAP.Domain.Interface;

namespace IAP.Application.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        public async Task<List<CompanyDTO>> GetAllCompanyAsync()
        {
            var companies = await _companyRepo.GetAllAsync();

            return _mapper.Map<List<CompanyDTO>>(companies);
        }

        public async Task<CompanyDTO?> GetCompanyByIdAsync(int id)
        {
            var company = await _companyRepo.GetByIdAsync(id);

            if (company == null)
            {
                return null;
            }

            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task<string> CreateCompanyAsync(CreateCompanyDTO dto)
        {
            var isEmailExists = await _companyRepo
                .IsEmailExistsAsync(dto.Email);

            if (isEmailExists)
            {
                return "Email already exists.";
            }

            var company = _mapper.Map<Company>(dto);

            company.CreatedAt = DateTime.UtcNow;
            company.UpdatedAt = DateTime.UtcNow;

            await _companyRepo.CreateAsync(company);

            var result = await _companyRepo.SaveAsync();

            return result
                ? "Company created successfully."
                : "Failed to create company.";
        }

        public async Task<string> UpdateCompanyAsync(
            int id,
            UpdateCompanyDTO dto)
        {
            var company = await _companyRepo.GetByIdAsync(id);

            if (company == null)
            {
                return "Company not found.";
            }

            if (!string.Equals(company.Email,
                dto.Email,
                StringComparison.OrdinalIgnoreCase))
            {
                var isEmailExists = await _companyRepo
                    .IsEmailExistsAsync(dto.Email);

                if (isEmailExists)
                {
                    return "Email already exists.";
                }
            }

            _mapper.Map(dto, company);

            company.UpdatedAt = DateTime.UtcNow;

            _companyRepo.Update(company);

            var result = await _companyRepo.SaveAsync();

            return result
                ? "Company updated successfully."
                : "Failed to update company.";
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

            return result
                ? "Company deleted successfully."
                : "Failed to delete company.";
        }
    }
}