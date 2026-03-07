using Arcadia.Core.Globals.Players;
using Terraria;

namespace Arcadia.Core.Utilities;

public static partial class ArcadiaUtils
{
    public static ArcadiaPlayer Arcadia(this Player player) => player.GetModPlayer<ArcadiaPlayer>();
}
