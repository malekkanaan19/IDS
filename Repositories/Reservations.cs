using System;
using System.Collections.Generic;
using System.Text;
using meeting.core.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using meeting.core.Models;

namespace meeting.core.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservation
    {
        public ReservationRepository(IdsContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await MyDbContext.Reservations
                .ToListAsync();

        }
        public Task<Reservation> GetReservationByIdAsync(String id)
        {
            return MyDbContext.Reservations
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Reservation> GetReservationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        private IdsContext MyDbContext
        {
            get { return Context as IdsContext; }
        }
    }
}
