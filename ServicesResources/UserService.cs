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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Reservation> CreateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users
               .GetAllUsersAsync();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUserByRoomId(int RoomId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User userToBeUpdated, User user)
        {
            throw new NotImplementedException();
        }
    }
}
