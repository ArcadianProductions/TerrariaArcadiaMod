//using Arcadia.Content.Projectiles.Melee;
//using Arcadia.Content.Rarities;
//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.ID;
//using Terraria.ModLoader;
//using static Terraria.ModLoader.ModContent;

//namespace Arcadia.Content.Items.Weapons.Melee;

//public class DivineStar : ModItem
//{
//    private int AttackIndex;

//    // Allow holding right-click for this weapon.
//    public override void SetStaticDefaults() =>
//        ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;

//    public override void SetDefaults()
//    {
//        Item.width = 172;
//        Item.height = 180;

//        Item.damage = 12500;
//        Item.DamageType = DamageClass.Melee;
//        Item.knockBack = 7.5f;
//        Item.useTime = 20;
//        Item.useAnimation = 20;

//        Item.useStyle = ItemUseStyleID.Swing;
//        Item.useTurn = true;
//        Item.noMelee = true;
//        Item.autoReuse = true;
//        Item.noUseGraphic = true;
//        Item.channel = true;
//        Item.value = Item.sellPrice(175);
//        Item.rare = RarityType<VaemaRarity>();

//        Item.shoot = ProjectileType<DivineStarSwing>();
//        Item.shootSpeed = 20f;
        
//        Item.UseSound = null;
//    }

//    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
//    {
//        int state = 0;
//        if (++AttackIndex > 6)
//        {
//            state = 1;
//            AttackIndex = 0;
//        }

//        // Switch states if the player is pressing right-click.
//        if (player.altFunctionUse == 2)
//            state = 2;

//        Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, state);

//        return false;
//    }

//    //public override bool CanShoot(Player player) =>
//    //    !Main.projectile.Any(n => n.active && n.owner == player.whoAmI && n.type == ProjectileType<DivineStarSwing>());

//    public override void ModifyWeaponCrit(Player player, ref float crit) => crit = 100;

//    public override bool AltFunctionUse(Player player) => true;

//    public override bool? CanHitNPC(Player player, NPC target) => false;

//    public override bool CanHitPvp(Player player, Player target) => false;
//}