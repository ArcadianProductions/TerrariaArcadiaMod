using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Arcadia.Core.World.WorldSaving;

public class WorldSaveSystem : ModSystem
{
    private static bool bloodbathModeEnabled;

    public static bool BloodbathModeEnabled
    {
        get => bloodbathModeEnabled;
        set => bloodbathModeEnabled = value;
    }

    public override void OnWorldLoad()
    {
        BloodbathModeEnabled = false;
    }

    public override void OnWorldUnload()
    {
        BloodbathModeEnabled = false;
    }

    public override void SaveWorldHeader(TagCompound tag)
    {
        if (BloodbathModeEnabled)
            tag["BloodbathModeEnabled"] = true;
    }

    public override void SaveWorldData(TagCompound tag)
    {
        var downed = new List<string>();
        if (BloodbathModeEnabled)
            downed.Add("BloodbathModeEnabled");

        tag["downed"] = downed;
    }

    public override void LoadWorldData(TagCompound tag)
    {
        var downed = tag.GetList<string>("downed");
        BloodbathModeEnabled = downed.Contains("BloodbathModeEnabled");
    }

    public override void NetSend(BinaryWriter writer)
    {
        BitsByte flags = new();
        flags[0] = BloodbathModeEnabled;
    }

    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        BloodbathModeEnabled = flags[0];
    }
}