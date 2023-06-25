using meeting.core.Interfaces;
using meeting.core.Models;
using meeting.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Company> CreateCompany(Company newCompany)
        {
            throw new NotImplementedException();
        }

        public Task<Company> CreateMusic(Company newCompany)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies
               .GetAllCompaniesAsync();
        }

        public Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAllWithCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllWithUser()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetCompanyById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetCompanyByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            throw new NotImplementedException();
        }

        Task ICompanyService.CreateCompany(Company companyToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
