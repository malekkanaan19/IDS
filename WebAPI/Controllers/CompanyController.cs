using AutoMapper;
using meeting.core.Models;
using meeting.core.Repositories;
using meeting.services.Interfaces;
using meeting.services.Resources;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using Web_API.Resources;
using Web_API.Validators;
using SaveCompanyResources = Web_API.Resources.SaveCompanyResources;

namespace Web_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyService = companyService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Resources.CompanyResources>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            var companyResources = _mapper.Map<IEnumerable<meeting.core.Models.Company>, IEnumerable<Resources.CompanyResources>>(companies);

            return Ok(companyResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resources.CompanyResources>> GetCompanyById(string id)
        {
            var companies = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<meeting.core.Models.Company, Resources.CompanyResources>(companies);

            return Ok(companyResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<Resources.CompanyResources>> CreateCompany([FromBody] Resources.SaveCompanyResources saveCompanyResource, SaveCompanyResources saveCompanyResources)
        {
            var validator = new SaveCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var companyToCreate = _mapper.Map<Resources.SaveCompanyResources, Company>(saveCompanyResources);

            var newCompany = await _companyService.CreateCompany(companyToCreate);

            var company = await _companyService.GetCompanyById(newCompany.Id);

            var companyResource = _mapper.Map<meeting.core.Models.Company, Resources.CompanyResources>(company);

            return Ok(companyResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Resources.CompanyResources>> UpdateCompany(string id, [FromBody] Resources.SaveCompanyResources saveCompanyResource, SaveCompanyResources saveCompanyResources)
        {
            var validator = new SaveCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);

            var requestIsInvalid = id == "0" || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var companyToBeUpdate = await _companyService.GetCompanyById(id);

            if (companyToBeUpdate == null)
                return NotFound();

            Company company = _mapper.Map<Resources.SaveCompanyResources, Company>(saveCompanyResources);

            await _companyService.UpdateCompany(companyToBeUpdate, company);

            var updatedCompany = await _companyService.GetCompanyById(id);
            var updatedCompanyResource = _mapper.Map<meeting.core.Models.Company, Resources.CompanyResources>(updatedCompany);

            return Ok(updatedCompanyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(string id)
        {
            if (id == "0")
                return BadRequest();

            var company = await _companyService.GetCompanyById(id);

            if (company == null)
                return NotFound();

            await _companyService.DeleteCompany(company);

            return NoContent();
        }
    }
}

