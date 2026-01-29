using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Armor.GemHats;

[AutoloadEquip(EquipType.Head)]
public class EmeraldHat : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.defense = 6;
        Item.value = Item.sellPrice(silver: 8);
        Item.rare = ItemRarityID.Blue;
    }

    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 60;
        player.GetDamage<MagicDamageClass>() += 0.8f;
    }

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient(ItemID.Silk, 10).
            AddIngredient(ItemID.Emerald, 5).
            AddTile(TileID.Loom).
            Register();
    }
}