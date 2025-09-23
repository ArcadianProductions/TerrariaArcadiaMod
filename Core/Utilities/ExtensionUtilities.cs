using Arcadia.Core.Globals.Players;
using Terraria;

namespace Arcadia;

public static partial class Utilities
{
    public static ArcadiaPlayer Arcadia(this Player player) => player.GetModPlayer<ArcadiaPlayer>();
}