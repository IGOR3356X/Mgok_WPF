using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class GameCategory
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
