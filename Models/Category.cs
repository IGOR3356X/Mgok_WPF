using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GameCategory> GameCategories { get; set; } = new List<GameCategory>();
}
