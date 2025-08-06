using Arcadia.Assets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Bosses.Auroralis;

public class AuroralisHitbox : ModNPC
{
    public override string Texture => AssetDirectory.Invisible;

    public int HeadIndex => (int)NPC.ai[0];

    public override void SetStaticDefaults() => this.HideFromBestiary();

    public override void SetDefaults()
    {
        NPC.width = 60;
        NPC.height = 60;

        NPC.lifeMax = 6000;
        NPC.damage = 40;
        NPC.defense = 8;
        NPC.knockBackResist = 0f;

        NPC.aiStyle = -1;
        AIType = -1;

        NPC.boss = true;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.behindTiles = true;
        NPC.dontCountMe = true;
        NPC.netAlways = true;
        NPC.dontTakeDamage = true;
        NPC.value = Item.buyPrice(0, 5);
        NPC.frame = new Rectangle(0, 0, NPC.width, NPC.height);

        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = null;
    }

    public override void AI()
    {
        NPC.frame = new Rectangle(0, 0, NPC.width, NPC.height);

        // Set the worm variable.
        if (HeadIndex > 0)
            NPC.realLife = HeadIndex;

        // Despawn check.
        bool shouldDespawn = true;
        for (int i = 0; i < Main.maxNPCs; i++)
        {
            if (Main.npc[HeadIndex].active && Main.npc[HeadIndex].type == ModContent.NPCType<Auroralis>())
            {
                shouldDespawn = false;
                break;
            }
        }

        // Despawn if necessary.
        if (shouldDespawn)
        {
            NPC.life = 0;
            NPC.checkDead();
            NPC.active = false;
        }

        // Ensure these variables are set based on the primary index.
        NPC.chaseable = Main.npc[HeadIndex].chaseable;
        NPC.dontTakeDamage = Main.npc[HeadIndex].dontTakeDamage;
        NPC.damage = Main.npc[HeadIndex].damage;
    }

    public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) => Auroralis.ScaleStats(NPC, numPlayers, balance);

    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;

    public override bool CheckActive() => false;
}