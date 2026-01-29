using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Armor.GemHats;

[AutoloadEquip(EquipType.Head)]
public class AmethystHat : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;
        Item.defense = 2;
        Item.value = Item.sellPrice(silver: 5);
        Item.rare = ItemRarityID.White;
    }

    public override void UpdateEquip(Player player)
    {
        player.statManaMax2 += 20;
        player.GetDamage<MagicDamageClass>() += 0.02f;
    }

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient(ItemID.Silk, 10).
            AddIngredient(ItemID.Amethyst, 5).
            AddTile(TileID.Loom).
            Register();
    }
}