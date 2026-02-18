global using static System.MathF;
global using static Microsoft.Xna.Framework.MathHelper;
global using static Stella.Core.Utilities.Utilities;
global using static Arcadia.Core.Utilities.Utilities;

using Terraria.ModLoader;

namespace Arcadia;

public class Arcadia : Mod
{
    /// <summary>
    ///     The instance for this mod.
    /// </summary>
    public static Mod Instance
    {
        get;
        private set;
    }

    /// <summary>
    ///     A variable to tell whether or not debugging is enabled.
    /// </summary>
    public static bool DebugMode;

    public override void Load()
    {
        Instance = this;

        #if DEBUG
        DebugMode = true;
        #endif
    }

    public override void Unload() => Instance = null;
}
