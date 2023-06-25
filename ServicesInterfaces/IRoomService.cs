using meeting.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<meeting.core.Models.Room>> GetAllWithUsers();
        Task<meeting.core.Models.Room> GetRoomById(int id);
        Task<IEnumerable<meeting.core.Models.Room>> GetRoomByUserId(int UserId);
        Task<meeting.core.Models.Room> CreateRoom(meeting.core.Models.Room newRoom);
        Task UpdateRoom(meeting.core.Models.Room roomToBeUpdated, meeting.core.Models.Room room);
        Task DeleteRoom(meeting.core.Models.Room reservation);
        Task GetRoomById(string id);
    }
}
