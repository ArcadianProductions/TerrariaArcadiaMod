using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;

namespace Arcadia;

public static partial class Utilities
{
    /// <summary>
    /// Displays arbitrary text in the game chat with a desired color. This method expects to be called server-side in multiplayer, with the message display packet being sent to all clients from there.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="color">The color of the text.</param>
    public static void BroadcastText(string text, Color color)
    {
        if (Main.netMode == NetmodeID.SinglePlayer)
            Main.NewText(text, color);
        else if (Main.netMode == NetmodeID.Server)
            ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), color);
    }

    /// <summary>
    /// Returns a color lerp that allows for smooth transitioning between two given colors.
    /// </summary>
    /// <param name="firstColor">The first color you want it to switch between.</param>
    /// <param name="secondColor">The second color you want it to switch between.</param>
    /// <param name="seconds">How long you want it to take to swap between colors.</param>
    public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
    {
        double timeMult = (double)(MathHelper.TwoPi / seconds);
        float colorMePurple = (float)((Math.Sin(timeMult * Main.GlobalTimeWrappedHourly) + 1) * 0.5f);

        return Color.Lerp(firstColor, secondColor, colorMePurple);
    }
}