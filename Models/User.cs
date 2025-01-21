using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string TelephonNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
