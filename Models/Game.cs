using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<GameCategory> GameCategories { get; set; } = new List<GameCategory>();

    public virtual ICollection<GameDeveloper> GameDevelopers { get; set; } = new List<GameDeveloper>();
}
