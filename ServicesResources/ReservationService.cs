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
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Reservation> CreateReservation(Reservation newReservation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _unitOfWork.Reservations
               .GetAllReservationsAsync();
        }

        public Task<IEnumerable<Reservation>> GetAllWithUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetReservationById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetReservationsByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation)
        {
            throw new NotImplementedException();
        }

        Task IReservationService.GetAllReservations()
        {
            throw new NotImplementedException();
        }
    }
}
