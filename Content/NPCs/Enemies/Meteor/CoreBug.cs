using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Enemies.Meteor;

public class CoreBug : ModNPC
{
    public override void SetStaticDefaults() =>
        Main.npcFrameCount[Type] = 6;

    public override void SetDefaults()
    {
        NPC.lifeMax = 150;
        NPC.damage = 18;
        NPC.defense = 10;
        NPC.knockBackResist = 0.6f;
        NPC.width = 38;
        NPC.height = 44;
        AnimationType = NPCID.MushiLadybug;
        NPC.aiStyle = NPCAIStyleID.Fighter;
        AIType = NPCID.MushiLadybug;
        NPC.npcSlots = 0.2f;
        NPC.HitSound = SoundID.NPCHit45;
        NPC.DeathSound = SoundID.NPCDeath47;
        NPC.value = Item.buyPrice(0, 0, 2, 24);
        //Banner = Type;
        //BannerItem = ModContent.ItemType<CoreBugBanner>();
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