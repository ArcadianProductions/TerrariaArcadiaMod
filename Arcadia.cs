using Terraria.ModLoader;

namespace Arcadia;

public class Arcadia : Mod
{
    internal static Arcadia Instance { get; set; }

    public Arcadia() => Instance = this;
}