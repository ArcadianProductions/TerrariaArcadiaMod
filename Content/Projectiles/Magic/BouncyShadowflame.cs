using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Projectiles.Magic;

public class BouncyShadowflame : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.BallofFire);
        Projectile.DamageType = DamageClass.Magic;
        Projectile.penetrate = 5;
    }

    public override void AI()
    {
        for (int i = 0; i < 2; i++)
        {
            int shadow = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 100, default, 0.8f);
            Main.dust[shadow].noGravity = true;
        }
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo info) =>
        target.AddBuff(BuffID.ShadowFlame, 180);

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) =>
        target.AddBuff(BuffID.ShadowFlame, 180);

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.penetrate--;
        if (Projectile.penetrate <= 0)
            Projectile.Kill();

        if (Projectile.velocity.X != oldVelocity.X)
            Projectile.velocity.X = 0f - oldVelocity.X;
        if (Projectile.velocity.Y != oldVelocity.Y)
            Projectile.velocity.Y = 0f - oldVelocity.Y;

        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

        return false;
    }
}