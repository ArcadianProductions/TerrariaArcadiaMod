using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Armor.GemHats;

[AutoloadEquip(EquipType.Head)]
public class DiamondHat : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.defense = 6;
        Item.value = Item.sellPrice(silver: 12);
        Item.rare = ItemRarityID.Green;
    }

    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 80;
        player.GetDamage<MagicDamageClass>() += 0.12f;
    }

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient(ItemID.Silk, 10).
            AddIngredient(ItemID.Diamond, 5).
            AddTile(TileID.Loom).
            Register();
    }
}