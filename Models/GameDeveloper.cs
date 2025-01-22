using System;
using System.Collections.Generic;

namespace SteamDesktop.Models;

public partial class GameDeveloper
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int DeveloperId { get; set; }

    public virtual Developer Developer { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
