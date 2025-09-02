//using Arcadia.Assets.Sounds;
//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.Audio;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace Arcadia.Content.NPCs.Bosses.Auroralis;

//public class AuroralisHead : ModNPC
//{
//    #region Enumerations

//    public enum AuroralisState
//    {
//        // Summon animation state.
//        SummonAnimation,

//        // Phase one.
//        Charge,
//        BreatheFrost,
//        SpitSnow,
//        CircleAndShootBolts,

//        // Phase two.
//        GiantFrostnado,
//        Hailstorm,
//        SnowVortex,

//        // Death animation state.
//        DeathAnimation
//    }

//    #endregion Enumerations

//    #region Fields and Properties

//    public ref float State => ref NPC.ai[0];
//    public ref float AttackTimer => ref NPC.ai[1];
//    public ref float InitializedFlag => ref NPC.ai[2];

//    public const float Phase2LifeRatio = 0.75f;
//    public const float Phase3LifeRatio = 0.25f;

//    public Player Target => Main.player[NPC.target];

//    #endregion Fields and Properties

//    #region Initialization

//    public override void SetStaticDefaults()
//    {
//        Main.npcFrameCount[Type] = 1;
//        NPCID.Sets.BossBestiaryPriority.Add(Type);
//    }

//    public override void SetDefaults()
//    {
//        NPC.width = 90;
//        NPC.height = 90;

//        NPC.lifeMax = 5600;
//        NPC.damage = 70;
//        NPC.defense = 10;
//        NPC.knockBackResist = 0f;
//        NPC.npcSlots = 3f;

//        NPC.aiStyle = -1;
//        AIType = -1;

//        NPC.boss = true;
//        NPC.noGravity = true;
//        NPC.noTileCollide = true;
//        NPC.behindTiles = true;
//        NPC.netAlways = true;
//        NPC.coldDamage = true;
//        NPC.lavaImmune = true;
//        NPC.value = Item.buyPrice(0, 5);

//        NPC.HitSound = SoundID.Item30;
//        NPC.DeathSound = null;
//        Music = MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Auroralis");
//        SceneEffectPriority = SceneEffectPriority.BossHigh;
//    }

//    #endregion Initialization

//    #region AI

//    public override void AI()
//    {
//        // Reset the contact damage.
//        NPC.damage = 70;

//        // Select the nearest target.
//        NPC.TargetClosest();

//        // Spawn the worm segments.
//        if (Main.netMode != NetmodeID.MultiplayerClient && InitializedFlag == 0f)
//        {
//            CreateSegments(25, ModContent.NPCType<AuroralisBody>(), ModContent.NPCType<AuroralisTail>());
//            InitializedFlag = 1f;
//            NPC.netUpdate = true;
//        }

//        // If there is no current target, despawn.
//        if (NPC.target < 0 || NPC.target >= Main.maxPlayers || Target.dead ||
//            !Target.active || !NPC.WithinRange(Target.Center, 5200f))
//        {
//            Despawn();
//            return;
//        }

//        // Perform the following AI behaviors.
//        switch ((AuroralisState)(int)State)
//        {
//            case AuroralisState.SummonAnimation:
//                SummonAnimation();
//                break;
//        }

//        // Increment the attack timer.
//        AttackTimer++;
//    }

//    public void SummonAnimation()
//    {
//        int groundShakeTime = 300;
//        int riseUpTime = 240;
        
//        if (AttackTimer <= groundShakeTime)
//        {
//            // Play a rumble sound.
//            if (AttackTimer == 1f)
//                SoundEngine.PlaySound(ArcadiaSounds.Rumble);

//            // Stay underneath the target.
//            NPC.velocity = Vector2.UnitY * -9f;
//            NPC.Center = Target.Center + Vector2.UnitY * 1020f;
//        }

//        // Disable damage.
//        NPC.damage = 0;

//        // Calculate the rotation.
//        NPC.rotation = NPC.velocity.ToRotation() + PiOver2;
//    }

//    public void Despawn()
//    {
//        NPC.velocity.X *= 0.985f;
//        if (NPC.velocity.Y < 26f)
//            NPC.velocity.Y += 0.4f;

//        if (NPC.timeLeft > 200)
//            NPC.timeLeft = 200;

//        if (!NPC.WithinRange(Target.Center, 1500f))
//            NPC.active = false;
//    }

//    public void CreateSegments(int wormLength, int bodyType, int tailType)
//    {
//        int previous = NPC.whoAmI;
//        int minLength = wormLength;

//        int bodyTypeAIVariable = 0;
//        for (int i = 0; i < minLength + 1; i++)
//        {
//            // Fuck you, it's big brain time.
//            int lol;
//            if (i >= 0 && i < minLength)
//            {
//                if (i == 0)
//                    bodyTypeAIVariable = 0;
//                else if (i == minLength - 1)
//                    bodyTypeAIVariable = 30;
//                else if (i % 2 == 0)
//                    bodyTypeAIVariable = 20;
//                else
//                    bodyTypeAIVariable = 10;

//                lol = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, bodyType, NPC.whoAmI);
//                Main.npc[lol].ai[3] = bodyTypeAIVariable;
//            }
//            else
//                lol = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, tailType, NPC.whoAmI);

//            Main.npc[lol].ai[2] = NPC.whoAmI;
//            Main.npc[lol].realLife = NPC.whoAmI;
//            Main.npc[lol].ai[1] = previous;
//            Main.npc[previous].ai[0] = lol;
//            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, lol, 0f, 0f, 0f, 0);
//            previous = lol;
//        }
//    }

//    #endregion AI

//    public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
//    {
//        int usedLifeMax = Main.masterMode ? 8000 : Main.expertMode ? 7500 : 6000;
//        NPC.lifeMax = (int)(usedLifeMax * balance);

//        NPC.damage = 40;
//        if (Main.expertMode)
//            NPC.damage = 50;
//        if (Main.masterMode)
//            NPC.damage = 60;
//    }
//}