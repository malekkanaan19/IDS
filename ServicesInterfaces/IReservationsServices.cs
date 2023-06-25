using meeting.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.services.Interfaces
{
      public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllWithUsers();
        Task<Reservation> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservationsByUserId(int UserId);
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation);
        Task DeleteReservation(Reservation reservation);
        Task GetAllReservations();
        Task GetReservationById(string id);
    }
}
