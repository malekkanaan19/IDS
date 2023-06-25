using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompany Companies { get; }
        IReservation Reservations { get; }
        IRoom Rooms { get; }
        IUser Users { get; }

        Task<int> CommitAsync();
    }
}
