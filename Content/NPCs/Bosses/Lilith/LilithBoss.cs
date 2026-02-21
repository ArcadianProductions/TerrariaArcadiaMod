//using Arcadia.Core.Utilities;
//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.GameContent.Bestiary;
//using Terraria.GameContent.Events;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace Arcadia.Content.NPCs.Bosses.Lilith;

//public class LilithBoss : ModNPC
//{
//    public enum LilithState
//    {
//        // Summon animation.
//        SummonAnimation,

//        // Phase one.
//        SummonTenebrus,

//        // Phase two.
//        DirectDarkSouls,
//        TrailCharges,
//        DarkStarBulletHell,

//        // Phase three.
//        DarkEnergyBursts,
//        SummonShadowDevils,
//        HomingDarkSouls,
//        DirectLaser,

//        // Phase four.
//        SummonApparitions,
//        GiantLaserSpin,
//        BlackHole,

//        // Desperation phase.
//        DesperationPhase,

//        // Defeat animation.
//        DefeatAnimation
//    }

//    public Player Target => Main.player[NPC.target];

//    public float LifeRatio => Saturate(NPC.life / (float)NPC.lifeMax);

//    public const float Phase2LifeRatio = 0.75f;

//    public const float Phase3LifeRatio = 0.5f;

//    public const float Phase4LifeRatio = 0.25f;

//    public override void SetStaticDefaults()
//    {
//        Main.npcFrameCount[Type] = 1;

//        NPCID.Sets.TrailingMode[Type] = 1;
//        NPCID.Sets.MPAllowedEnemies[Type] = true;
//        NPCID.Sets.BossBestiaryPriority.Add(Type);
//    }

//    public override void SetDefaults()
//    {
//        NPC.width = NPC.height = 54;
        
//        NPC.SetLifeMaxByMode(4525000, 4750000, 5000000);
//        NPC.damage = 325;
//        NPC.defense = 125;
//        NPC.knockBackResist = 0f;
//        NPC.npcSlots = 50f;

//        NPC.aiStyle = -1;
//        AIType = -1;

//        NPC.boss = true;
//        NPC.noGravity = true;
//        NPC.noTileCollide = true;
//        NPC.lavaImmune = true;
//        NPC.chaseable = true;

//        NPC.value = Item.buyPrice(platinum: 5);
//    }

//    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
//    {
//        bestiaryEntry.Info.AddRange(
//        [
//            // Gives a black background.
//            new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
//            new FlavorTextBestiaryInfoElement("Mods.Arcadia.Bestiary.Lilith")
//        ]);
//    }

//    public override void AI()
//    {
//        // Find the nearest target.
//        if (NPC.target < 0 || NPC.target == Main.maxPlayers || Target.dead || !Target.active)
//            NPC.TargetClosest();

//        // Ensure to target any other potential players if the current one is too far away.
//        if (Vector2.Distance(Target.Center, NPC.Center) > 3200f)
//            NPC.TargetClosest();

//        // Disable weather ambience.
//        DisableWeatherAmbience();

//        // Prevent Slime Rain events from naturally happening.
//        if (Main.slimeRain)
//        {
//            Main.StopSlimeRain(true);
//            SyncWorld();
//        }

//        // TODO: The rest of the AI.
//    }

//    public static void DisableWeatherAmbience()
//    {
//        Main.StopRain();
//        for (int i = 0; i < Main.maxRain; i++)
//            Main.rain[i].active = false;

//        if (Main.netMode != NetmodeID.Server)
//            Sandstorm.StopSandstorm();
//    }
//}
