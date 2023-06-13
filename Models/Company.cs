using System;
using System.Collections.Generic;

namespace meeting.core.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? LogoFilePath { get; set; }

    public bool? IsActive { get; set; }

    public int? RelatedUserId { get; set; }

    public virtual User? RelatedUser { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
