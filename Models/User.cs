using System;
using System.Collections.Generic;

namespace meeting.core.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
