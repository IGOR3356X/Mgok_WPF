using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class Developer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GameDeveloper> GameDevelopers { get; set; } = new List<GameDeveloper>();
}
