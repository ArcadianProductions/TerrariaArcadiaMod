using Terraria;
using Terraria.ID;

namespace Arcadia.Core.Utilities;

public static partial class ArcadiaUtils
{
    /// <summary>
    ///     Syncs world changes on a server.
    /// </summary>
    public static void SyncWorld()
    {
        if (Main.dedServ)
            NetMessage.SendData(MessageID.WorldData);
    }
}
