using System;
using RRUI.Theme;

namespace Conned2021Themer.Patch;

public class DarkTheme
{
    public static Palette CreateDarkTheme()
    {
        var theme = UnityEngine.Resources.Load<Palette>("themes/palette_darktheme");
        return theme;
    }

    public static Palette CreateDarkLegacyTheme()
    {
        //no, we just ignore it. dark themes already dark already.
        return Plugin.LEGACYTheme;
    }
    
}