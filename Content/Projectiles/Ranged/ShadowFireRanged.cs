using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.Projectiles.Ranged;

public class ShadowFireRanged : ModProjectile
{
    public override string Texture => "Arcadia/Assets/Textures/Grayscale/FireProjectile";

    public ref float Time => ref Projectile.ai[0];

    public override void SetDefaults()
    {
        Projectile.width = Projectile.height = 10;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.MaxUpdates = 3;
        Projectile.timeLeft = 60;
        Projectile.usesIDStaticNPCImmunity = true;
        Projectile.idStaticNPCHitCooldown = 3;
    }

    public override void AI()
    {
        Time++;
        if (Time < 45 && Main.rand.NextBool(5))
        {
            Vector2 dustPosition = Projectile.Center + Main.rand.NextVector2Circular(30f, 30f) * Utils.Remap(Time, 0f, 60, 0.5f, 1f);
            float dustSize = Utils.GetLerpValue(6f, 12f, Time, true);
            Dust shadow = Dust.NewDustDirect(dustPosition, 4, 4, DustID.Shadowflame, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f);
            
            if (Main.rand.NextBool(3))
            {
                shadow.scale *= 1.2f;
                shadow.velocity *= 1.5f;
            }

            shadow.noGravity = true;
            shadow.scale *= dustSize * 1.2f;
            shadow.velocity += Projectile.velocity * Utils.Remap(Time, 0f, 60 * 0.75f, 1f, 0.1f) * Utils.Remap(Time, 0f, 45 * 0.1f, 0.1f, 1f);
        }

        Lighting.AddLight(Projectile.Center, Color.MediumPurple.ToVector3() * 0.3f);
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.velocity = oldVelocity * 0.95f;
        Projectile.position -= Projectile.velocity;
        Time++;
        Projectile.timeLeft--;

        return false;
    }

    public override void ModifyDamageHitbox(ref Rectangle hitbox)
    {
        int size = (int)Utils.Remap(Time, 0f, 45, 10f, 40f);
        if (Time > 60)
            size = (int)Utils.Remap(Time, 45, 60, 40f, 0f);

        hitbox.Inflate(size, size);
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) =>
        projHitbox.Intersects(targetHitbox) && Collision.CanHit(Projectile.Center, 0, 0, targetHitbox.Center.ToVector2(), 0, 0) ? null : false;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) =>
        target.AddBuff(BuffID.ShadowFlame, 180);

    public override bool PreDraw(ref Color lightColor)
    {
        float length = (Time > 25f) ? 0.1f : 0.15f;
        float vOffset = Math.Min(Time, 20f);
        float timeRatio = Utils.GetLerpValue(0f, 60, Time);
        float fireSize = Utils.Remap(timeRatio, 0.2f, 0.5f, 0.25f, 1f);

        if (timeRatio >= 1f)
            return false;

        for (float i = 1f; i >= 0f; i -= length)
        {
            Texture2D fire = TextureAssets.Projectile[Type].Value;

            Color fireColor = (timeRatio < 0.85f) ? Color.Lerp(Color.Transparent, Color.Purple, Utils.GetLerpValue(0f, 0.7f, timeRatio)) :
                Color.Lerp(Color.Purple, Color.Transparent, Utils.GetLerpValue(0.85f, 1f, timeRatio));
            fireColor *= (1f - i) * Utils.GetLerpValue(0f, 0.2f, timeRatio, true);
            Color innerColor = Color.Lerp(fireColor, Color.Black, 0.3f);

            Vector2 firePosition = Projectile.Center - Main.screenPosition - Projectile.velocity * vOffset * i;
            float mainRotation = -i * MathHelper.PiOver2 - Main.GlobalTimeWrappedHourly * (i + 1f) * 2f / length;
            float trailRotation = MathHelper.PiOver4 - mainRotation;

            // Draw an afterimage.
            Vector2 trailOffset = Projectile.velocity * vOffset * length * 0.5f;
            Main.EntitySpriteDraw(fire, firePosition - trailOffset, null, innerColor * 0.25f, trailRotation, fire.Size() * 0.5f, fireSize, SpriteEffects.None);

            // Draw the actual fire.
            Main.EntitySpriteDraw(fire, firePosition, null, innerColor, mainRotation, fire.Size() * 0.5f, fireSize, SpriteEffects.None);
        }
            
        return false;
    }
}
