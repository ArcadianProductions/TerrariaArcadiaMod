using Arcadia.Content.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Items.Weapons.Ranged;

public class Shadethrower : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 18;
        Item.damage = 55;
        Item.DamageType = DamageClass.Ranged;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 1.5f;
        Item.UseSound = SoundID.Item34;
        Item.value = Item.sellPrice(0, 3, 20);
        Item.rare = ItemRarityID.LightRed;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<ShadowFireRanged>();
        Item.shootSpeed = 8.5f;
        Item.useAmmo = AmmoID.Gel;
        Item.consumeAmmoOnFirstShotOnly = true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i <= 2; i++)
            Projectile.NewProjectile(source, position + velocity * 4f, velocity.RotatedByRandom(0.25f) * Main.rand.NextFloat(0.45f, 0.9f), type, damage, knockback, player.whoAmI);

        return false;
    }
}
