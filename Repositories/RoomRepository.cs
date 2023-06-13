using meeting.core.Interfaces;
using meeting.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Repositories
{
    public class RoomRepository : Repository<meeting.core.Models.Room>, IRoom
    {
        public RoomRepository(IdsContext context)
            : base(context)
        { }

        public async Task<IEnumerable<meeting.core.Models.Room>> GetAllCompaniestAsync()
        {
            return await MyDbContext.Rooms
                .ToListAsync();

        }
        public Task<meeting.core.Models.Room> GetRoomByIdAsync(String id)
        {
            return MyDbContext.Rooms
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<meeting.core.Models.Room> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<meeting.core.Models.Room>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<meeting.core.Models.Room> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<meeting.core.Models.Room>> GetAllRoomsAsync()
        {
            throw new NotImplementedException();
        }

        private IdsContext MyDbContext
        {
            get { return Context as IdsContext; }
        }
    }
}
