using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Enemies.SnowLegion;

public class SnowmanBomber : ModNPC
{
	public override void SetStaticDefaults() =>
        Main.npcFrameCount[Type] = 20;

    public override void SetDefaults()
	{
		NPC.lifeMax = 400;
		NPC.damage = 60;
		NPC.defense = 15;
		NPC.knockBackResist = 0.1f;
		NPC.width = 34;
		NPC.height = 46;
		AnimationType = NPCID.SkeletonCommando;
		NPC.aiStyle = NPCAIStyleID.Fighter;
		AIType = NPCID.SkeletonCommando;
		NPC.npcSlots = 0.3f;
		NPC.HitSound = SoundID.NPCHit11;
		NPC.DeathSound = SoundID.NPCDeath38;
		NPC.value = Item.buyPrice(0, 0, 4, 7);
		//Banner = Type;
		//BannerItem = ModContent.ItemType<SnowmanBomberBanner>();
	}

	public override void HitEffect(NPC.HitInfo hit)
	{
		if (NPC.life <= 0)
		{
			for (int i = 0; i < 5; i++)
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow, 2.5f * hit.HitDirection, -2.5f);
        }
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
		=> NPC.AnyNPCs(NPCID.MisterStabby) && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.08f : 0f;
}