namespace Arcadia.Core.DataStructures;

/// <summary>
///     Marks a ModItem as a debug item, which will be disabled in normal gameplay unless if debug mode is enabled.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DebugItemAttribute : Attribute
{
}