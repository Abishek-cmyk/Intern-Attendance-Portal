using IAP.Application.DTOs.Company;
using IAP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intern_Attendance_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/company
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanyAsync();

            return Ok(companies);
        }

        // GET api/company/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound("Company not found.");
            }

            return Ok(company);
        }

        // POST api/company
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _companyService.CreateCompanyAsync(dto);

            return Ok(result);
        }

        // PUT api/company/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id,
            [FromBody] UpdateCompanyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _companyService.UpdateCompanyAsync(id, dto);

            if (result == "Company not found.")
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // DELETE api/company/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);

            if (result == "Company not found.")
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}