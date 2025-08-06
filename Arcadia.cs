using System.IO;
using Terraria.ModLoader;

namespace Arcadia;

public class Arcadia : Mod
{
    internal static Arcadia Instance { get; set; }

    public Arcadia() => Instance = this;

    public override void Unload()
    {
        Instance = null;
    }

    public override void PostSetupContent()
    {
        NetEasy.NetEasy.Register(this);
    }

    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        NetEasy.NetEasy.HandleModule(reader, whoAmI);
    }
}