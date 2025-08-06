using Terraria.ID;
using Terraria.ModLoader;

namespace Arcadia;

public static partial class ArcadiaUtils
{
    public static void HideFromBestiary(this ModNPC n)
    {
        NPCID.Sets.NPCBestiaryDrawModifiers value = new(0)
        {
            Hide = true
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(n.Type, value);
    }
}