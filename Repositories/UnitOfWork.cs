using meeting.core.Interfaces;
using meeting.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdsContext _context;
        private CompanyRepository _companyRepository;
        private UserRepository _userRepository;
        private RoomRepository _roomRepository;
        private ReservationRepository _reservationRepository;

        public UnitOfWork(IdsContext context)
        {
            this._context = context;
        }

        public ICompany Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IReservation Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);
        public IUser Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IRoom Rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
