using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace Arcadia.Assets;

public static class AssetDirectory
{
    public const string Assets = "Arcadia/Assets/";
    public const string Textures = Assets + "Textures/";
    public const string Effects = Assets + "Effects/";

    public const string Grayscale = Textures + "Grayscale/";
    public const string Invisible = Grayscale + "Invisible";

    public static Effect KnifeRendering => ModContent.Request<Effect>("Arcadia/Assets/Effects/KnifeRendering", AssetRequestMode.ImmediateLoad).Value;
}