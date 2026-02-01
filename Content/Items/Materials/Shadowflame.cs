using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Materials;

public class Shadowflame : ModItem
{
    public override void SetStaticDefaults() =>
        Item.ResearchUnlockCount = 30;

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 9999;
        Item.value = Item.sellPrice(silver: 3);
        Item.rare = ItemRarityID.Pink;
    }
}