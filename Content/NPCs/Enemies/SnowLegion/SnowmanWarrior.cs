using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Enemies.SnowLegion;

public class SnowmanWarrior : ModNPC
{
	public override void SetStaticDefaults() =>
		Main.npcFrameCount[NPC.type] = 5;

	public override void SetDefaults()
	{
		NPC.lifeMax = 350;
		NPC.damage = 60;
		NPC.defense = 12;
		NPC.knockBackResist = 0.1f;
		NPC.width = 34;
		NPC.height = 46;
		AnimationType = NPCID.Herpling;
		NPC.aiStyle = NPCAIStyleID.Herpling;
		AIType = NPCID.Herpling;
		NPC.npcSlots = 0.3f;
		NPC.HitSound = SoundID.NPCHit11;
		NPC.DeathSound = SoundID.NPCDeath15;
		NPC.value = Item.buyPrice(0, 0, 8, 7);
		//Banner = NPC.type;
		//BannerItem = ModContent.ItemType<SnowmanWarriorBanner>();
	}

	public override void HitEffect(NPC.HitInfo hit)
	{
		int hitDirection = hit.HitDirection;

		if (NPC.life <= 0)
		{
			for (int k = 0; k < 20; k++)
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow, 2.5f * hitDirection, -2.5f, 0, default, 1f);

			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow, 2.5f * hitDirection, -2.5f, 0, default, 3f);
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow, 2.5f * hitDirection, -2.5f, 0, default, 2f);
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Snow, 2.5f * hitDirection, -2.5f, 0, default, 3f);
		}
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
		=> NPC.AnyNPCs(NPCID.MisterStabby) && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.08f : 0f;
}