using meeting.core.Interfaces;
using meeting.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompany
    {
        public CompanyRepository(IdsContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllCompaniestAsync() => await MyDbContext.Companies.ToListAsync();

        public Task<Company> GetCompanyByIdAsync(string id)
        {
            return MyDbContext.Companies
                .SingleOrDefaultAsync(a => a.CompanyId == int.Parse(id));
        }


        public Task<Company> GetCompanyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IdsContext MyDbContext
        {
            get { return Context as IdsContext; }
        }
    }
}
