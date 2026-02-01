using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Enemies.Meteor;

public class CoreSlime : ModNPC
{
    public override void SetStaticDefaults() =>
        Main.npcFrameCount[Type] = 2;

    public override void SetDefaults()
    {
        NPC.lifeMax = 80;
        NPC.damage = 20;
        NPC.defense = 4;
        NPC.knockBackResist = 0.6f;
        NPC.width = 32;
        NPC.height = 22;
        AnimationType = NPCID.BlueSlime;
        NPC.aiStyle = NPCAIStyleID.Slime;
        NPC.npcSlots = 0.1f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = Item.buyPrice(0, 0, 1, 50);
        //Banner = Type;
        //BannerItem = ModContent.ItemType<CoreSlimeBanner>();
        //ItemID.Sets.KillsToBanner[BannerItem] = 50;
    }

    public override void AI()
    {
        if (Main.rand.NextBool(4))
            Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life <= 0)
        {
            for (int k = 0; k < 20; k++)
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 2.5f * hit.HitDirection, -2.5f, 0, default, 0.8f);
        }
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        spawnInfo.Player.ZoneMeteor ? 1f : 0f;
}