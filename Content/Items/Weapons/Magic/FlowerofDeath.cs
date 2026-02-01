using Arcadia.Content.Items.Materials;
using Arcadia.Content.Projectiles.Magic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Weapons.Magic;

public class FlowerofDeath : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.FlowerofFire);
        Item.damage = 65;
        Item.DamageType = DamageClass.Magic;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<BouncyShadowflame>();
    }

    public override void AddRecipes()
    {
        CreateRecipe().
            AddIngredient(ModContent.ItemType<Shadowflame>(), 12).
            AddIngredient(ItemID.SoulofNight, 8).
            AddTile(TileID.MythrilAnvil).
            Register();
    }
}