using meeting.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Interfaces
{
    public interface ICompany : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniestAsync();
        Task<Company> GetCompanyByIdAsync(int id);

    }
}
