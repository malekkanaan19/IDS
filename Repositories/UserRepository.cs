using meeting.core.Interfaces;
using meeting.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Repositories
{
    public class UserRepository : Repository<User>, IUser
    {
        public UserRepository(IdsContext context)
            : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await MyDbContext.Users
                .ToListAsync();

        }
        public Task<User> GetUsersByIdAsync(String id)
        {
            return MyDbContext.Users
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        Task<IEnumerable<User>> IUser.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUsersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IdsContext MyDbContext
        {
            get { return Context as IdsContext; }
        }
    }
}
