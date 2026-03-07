using System.ComponentModel;
using System.Runtime.Serialization;

using Terraria;
using Terraria.ModLoader.Config;

namespace Arcadia.Core.Configuration;

public class ArcadiaClientConfig : ModConfig
{
    public static ArcadiaClientConfig Instance;

    public override ConfigScope Mode => ConfigScope.ClientSide;

    // Clamps values that would cause ugly problems if loaded directly without sanitization.
    [OnDeserialized]
    internal void ClampValues(StreamingContext context)
    {
        ParticleLimit = Utils.Clamp(ParticleLimit, MinParticleLimit, MaxParticleLimit);
    }

    [Header("Graphics")]

    private const int MinParticleLimit = 500;
    private const int MaxParticleLimit = 10000;

    [Range(MinParticleLimit, MaxParticleLimit)]
    [DefaultValue(5000)]
    public int ParticleLimit { get; set; }
}
