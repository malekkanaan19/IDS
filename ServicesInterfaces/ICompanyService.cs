using meeting.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace meeting.services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllWithUser();
        Task<Company> GetCompanyById(int id);
        Task<IEnumerable<Company>> GetCompanyByUserId(int userId);
        Task<Company> CreateMusic(Company newCompany);
        Task UpdateCompany(Company companyToBeUpdated, Company company);
        Task DeleteCompany(Company company);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task GetAllWithCompanies();
        Task CreateCompany(Company companyToCreate);
        Task GetCompanyById(string id);
    }
}
