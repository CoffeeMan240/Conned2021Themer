using BepInEx.Configuration;

namespace Conned2021Themer.Patch;

public class PatchConfig
{
    public static ConfigEntry<bool> Enabled { get; set; }
    public static ConfigEntry<bool> LightModeEnabled { get; set; }
}