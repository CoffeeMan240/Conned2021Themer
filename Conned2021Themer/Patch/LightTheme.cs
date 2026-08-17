using System.Linq;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using RRUI.Theme;
using UnityEngine;
using UnityEngine.UI;

namespace Conned2021Themer.Patch;

public class LightTheme
{
    public static Palette CreateLightTheme()
    {
        var theme = UnityEngine.Resources.Load<Palette>("themes/palette_lighttheme");
        return theme;
    }

    public static Palette CreateLightLegacyTheme()
    {
        var palette = Plugin.LEGACYTheme;
        var lighttheme = UnityEngine.Resources.Load<Palette>("themes/palette_lighttheme");
        
        palette.name = "LightTheme_LEGACY";
        //palette.backgroundColorPalettes = lighttheme.backgroundColorPalettes;
        //palette.foregroundColorPalettes = lighttheme.foregroundColorPalettes;
        palette.textStylePalettes = lighttheme.textStylePalettes;
        
        palette.backgroundColorPalettes = new Palette.BackgroundColorPaletteItem[]
        {
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.PrimarySolid,
                color = new Color(0.94509804f, 0.8784314f, 0.84705883f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.SecondarySolid,
                color = new Color(1f, 0.49803922f, 0.3019608f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.HighlightSolid,
                color = new Color(1f, 0.52f, 0.28f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.HighlightGradient,
                color = new Color(1f, 0.49803922f, 0.3019608f),
                gradient = new Gradient()
                {
                    colorKeys = new GradientColorKey[]
                    {
                        new GradientColorKey()
                        {
                            color = new Color(1f, 0.49803922f, 0.3019608f),
                            time = 39321f
                        },
                        new GradientColorKey()
                        {
                            color = new Color(0.9137255f, 0.61960787f, 0.29411766f),
                            time = 65535f
                        }
                    }
                }
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.SideBarBG,
                color = new Color(1f, 0.49803922f, 0.3019608f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.BackgroundAccent,
                color = new Color(1f, 0.49803922f, 0.3019608f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.Accent,
                color = new Color(0.18431373f, 0.20392157f, 0.45882353f),
            },
            new Palette.BackgroundColorPaletteItem()
            {
                backgroundColorPaletteType = HKNKJCKPDIH.InputField,
                color = new Color(1f,1f,1f)
            },
        };

        palette.foregroundColorPalettes = new Palette.ForegroundColorPaletteItem[]
        {
            new Palette.ForegroundColorPaletteItem()
            {
                foregroundColorPaletteType = OHNIIDEDGBL.MainPrimary,
                color = new Color(0.18431373f, 0.20392157f, 0.45882353f)
            },
            new Palette.ForegroundColorPaletteItem()
            {
                foregroundColorPaletteType = OHNIIDEDGBL.MainSecondary,
                color = new Color(0.18431373f, 0.20392157f, 0.45882353f)
            },
            new Palette.ForegroundColorPaletteItem()
            {
                foregroundColorPaletteType = OHNIIDEDGBL.InverseSecondary,
                color = new Color(0.94509804f, 0.3529412f, 0.14509805f)
            },
            new Palette.ForegroundColorPaletteItem()
            {
                foregroundColorPaletteType = OHNIIDEDGBL.WhitePrimary,
                color = Color.white
            },
            new Palette.ForegroundColorPaletteItem()
            {
                foregroundColorPaletteType = OHNIIDEDGBL.WhiteSecondary,
                color = Color.white
            }
        };

        var secondary = palette.buttonPalettes[1];

        var disColor = secondary.ButtonPalette.backgroundTints.disabledColor;
        disColor.a = 0.5f;
        secondary.ButtonPalette.backgroundTints = secondary.ButtonPalette.backgroundTints with { disabledColor = disColor };
        
        var disColor2 = secondary.ButtonPalette.foregroundTints.disabledColor;
        disColor2.a = 0.6f;
        secondary.ButtonPalette.foregroundTints = secondary.ButtonPalette.foregroundTints with { disabledColor = disColor2 };
        
        palette.buttonPalettes[1] = secondary;
        
        var primary = palette.buttonPalettes[0];

        primary.buttonPalette.foregroundTints = primary.buttonPalette.foregroundTints with
        {
            normalColor = new Color(1f, 0.42f, 0f),
            highlightedColor = new Color(0.94509804f, 0.3529412f, 0.14509805f),
            selectedColor = new Color(0.61f, 0.24f, 0.11f),
            pressedColor = new Color(0.61f, 0.24f, 0.11f)
        };
        primary.buttonPalette.backgroundTints = primary.buttonPalette.backgroundTints with
        {
            normalColor = new Color(0.94509804f, 0.8784314f, 0.84705883f),
            highlightedColor = Color.white,
            selectedColor = new Color(0.88f, 0.81f, 0.79f),
            pressedColor = new Color(0.88f, 0.81f, 0.79f, 0.67f)
        };
        
        palette.buttonPalettes[0] = primary;
        
        var action = palette.buttonPalettes[4];
        
        var normal = action.ButtonPalette.foregroundTints.normalColor;
        normal = new Color(0.18431373f, 0.20392157f, 0.45882353f);
        action.ButtonPalette.foregroundTints = action.ButtonPalette.foregroundTints with
        {
            normalColor = new Color(0.18431373f, 0.20392157f, 0.45882353f)
        };
        palette.buttonPalettes[4] = action;
        
        
        return palette;
    }
}