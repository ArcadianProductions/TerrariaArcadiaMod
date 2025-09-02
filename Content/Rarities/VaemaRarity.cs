using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Arcadia.Content.Rarities;

public class VaemaRarity : ModRarity
{
    public override Color RarityColor => Color.Lerp(Color.DarkViolet, Color.Violet, 2);

    // There is no higher rarity after a developer rarity, so just leave it be.
    public override int GetPrefixedRarity(int offset, float valueMult) => Type;
}