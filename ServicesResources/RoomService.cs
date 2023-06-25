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
    public class RoomServive : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomServive(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<meeting.core.Models.Room> CreateRoom(meeting.core.Models.Room newRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoom(meeting.core.Models.Room reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<meeting.core.Models.Room>> GetAllRooms()
        {
            return await _unitOfWork.Rooms
               .GetAllRoomsAsync();
        }

        public Task<IEnumerable<meeting.core.Models.Room>> GetAllWithUsers()
        {
            throw new NotImplementedException();
        }

        public Task<meeting.core.Models.Room> GetRoomById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetRoomById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<meeting.core.Models.Room>> GetRoomByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoom(meeting.core.Models.Room roomToBeUpdated, meeting.core.Models.Room room)
        {
            throw new NotImplementedException();
        }
    }
}
