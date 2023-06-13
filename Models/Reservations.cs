using System;
using System.Collections.Generic;

namespace meeting.core.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public DateTime? MeetingDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? RoomId { get; set; }

    public int? NumAttendees { get; set; }

    public bool? MeetingStatus { get; set; }

    public virtual Room? Room { get; set; }
    public string Id { get; internal set; }
}
