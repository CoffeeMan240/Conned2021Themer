using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using Conned2021Themer.Patch;
using HarmonyLib;
using Il2CppInterop.Common;
using Il2CppInterop.Runtime.Injection;
using RRUI.Theme;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Conned2021Themer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;
    public static Palette cachedpalette;
    public static Palette cachedpaletteLegacy;
    public static Palette LEGACYTheme;
    public static bool isLight = true;
    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        PatchConfig.Enabled = Config.Bind("General",
            "Enabled",
            true,
            "Enable or disable the themer.");
        PatchConfig.LightModeEnabled = Config.Bind("General",
            "Light Mode",
            false,
            "Enables Light Mode, basically this patch but opposite. Even themes legacy uis with a modified theme. Not the best option as alot of the ui colors are hard coded in this build (\"RRUI is not hardcoded.\" - john rec room) but if you want to commit sins against gabe, be my guest :333");

        isLight = PatchConfig.LightModeEnabled.Value;
        if (PatchConfig.Enabled.Value)
        {
            InitPalettes();
            var harmony = new  Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll(typeof(ApplyPatch));
        }
    }

    public void InitPalettes()
    {
        if (!isLight)
        {
            cachedpalette = DarkTheme.CreateDarkTheme();
        }
        else
        {
            cachedpalette = LightTheme.CreateLightTheme();
        }
    }
    
    /*[HarmonyPatch(typeof(SurfaceTheme), "Apply")]

    public class ISTHATTHEFUCKINGSIDEBAR
    {
        static void Prefix(ref SurfaceTheme __instance)
        {
            if(__instance.name == "[LeftNav]")
            {
                Console.WriteLine("AASAoipdsjgoisdjg");
                for (int i = 0; i < __instance.transform.childCount; i++)
                {
                    var child =  __instance.transform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
            }
        }
    }*/
    
    
    
    [HarmonyPatch(typeof(PaletteThemeReference), "JFDLDKAMBBB")]
    public class ApplyPatch
    {
        static void Postfix(ref PaletteThemeReference __instance)
        {
            if (__instance.paletteTheme.palette == null) return;
            if (!Plugin.isLight)
            {
                if (__instance.paletteTheme.palette.name.Contains("LEGACY"))
                {
                    if (cachedpaletteLegacy == null)
                    {
                        LEGACYTheme =  __instance.paletteTheme.palette;
                        cachedpaletteLegacy = DarkTheme.CreateDarkLegacyTheme();
                    }
                
                    __instance.paletteTheme.palette = cachedpaletteLegacy;
                }
                else
                    __instance.paletteTheme.palette = cachedpalette;
            }
            else
            {
                if (__instance.paletteTheme.palette.name.Contains("LEGACY"))
                {
                    if (cachedpaletteLegacy == null)
                    {
                        LEGACYTheme = __instance.paletteTheme.palette;
                        cachedpaletteLegacy = LightTheme.CreateLightLegacyTheme();
                    }

                    __instance.paletteTheme.palette = cachedpaletteLegacy;
                }
                else
                    __instance.paletteTheme.palette = cachedpalette;
            }
            
        }
    }
}