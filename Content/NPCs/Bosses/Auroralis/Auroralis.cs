using Terraria;
using Terraria.ModLoader;

namespace Arcadia.Content.NPCs.Bosses.Auroralis;

public class Auroralis : ModNPC
{
    public override void SetStaticDefaults()
    {
        
    }

    public override void SetDefaults()
    {
        
    }

    public override void AI()
    {
        
    }

    public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment) => ScaleStats(NPC, numPlayers, balance);

    public static void ScaleStats(NPC npc, int numPlayers, float balance)
    {
        int usedLifeMax = Main.masterMode ? 8000 : Main.expertMode ? 7500 : 6000;
        npc.lifeMax = (int)(usedLifeMax * balance);

        npc.damage = 40;
        if (Main.expertMode)
            npc.damage = 50;
        if (Main.masterMode)
            npc.damage = 60;
    }
}