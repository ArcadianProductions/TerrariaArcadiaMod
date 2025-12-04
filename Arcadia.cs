using Luminance.Core.ModCalls;
using Terraria.ModLoader;

namespace Arcadia;

public class Arcadia : Mod
{
    /// <summary>
    ///     The instance for this mod.
    /// </summary>
    public static Mod? Instance
    {
        get;
        private set;
    }

    public override void Load() => Instance = this;

    public override void Unload() => Instance = null;

    // Use Luminance's cross-compatibility system for mod calls.
    public override object Call(params object[] args) => ModCallManager.ProcessAllModCalls(this, args);
}