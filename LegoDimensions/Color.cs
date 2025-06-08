// Licensed to Laurent Ellerbach and contributors under one or more agreements.
// Laurent Ellerbach and contributors license this file to you under the MIT license.

using System.Reflection;

namespace LegoDimensions;

/// <summary>
/// Represents an ARGB (alpha, red, green, blue) color.
/// </summary>

public readonly struct Color
{
    private readonly uint _color;

    internal Color(uint color)
    {
        _color = color;
    }

    #region Known colors

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF66CDAA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumAquamarine => new(0xFF66CDAA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF0000CD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumBlue => new(0xFF0000CD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFBA55D3.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumOrchid => new(0xFFBA55D3);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF9370DB.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumPurple => new(0xFF9370DB);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF3CB371.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumSeaGreen => new(0xFF3CB371);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF7B68EE.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumSlateBlue => new(0xFF7B68EE);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00FA9A.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumSpringGreen => new(0xFF00FA9A);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF800000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Maroon => new(0xFF800000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF48D1CC.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumTurquoise => new(0xFF48D1CC);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF191970.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MidnightBlue => new(0xFF191970);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF5FFFA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MintCream => new(0xFFF5FFFA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFE4E1.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MistyRose => new(0xFFFFE4E1);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFE4B5.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Moccasin => new(0xFFFFE4B5);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFDEAD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color NavajoWhite => new(0xFFFFDEAD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF000080.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Navy => new(0xFF000080);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFDF5E6.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color OldLace => new(0xFFFDF5E6);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFC71585.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color MediumVioletRed => new(0xFFC71585);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF00FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Magenta => new(0xFFFF00FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFAF0E6.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Linen => new(0xFFFAF0E6);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF32CD32.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LimeGreen => new(0xFF32CD32);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFF0F5.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LavenderBlush => new(0xFFFFF0F5);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF7CFC00.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LawnGreen => new(0xFF7CFC00);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFACD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LemonChiffon => new(0xFFFFFACD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFADD8E6.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightBlue => new(0xFFADD8E6);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF08080.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightCoral => new(0xFFF08080);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFE0FFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightCyan => new(0xFFE0FFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFAFAD2.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightGoldenrodYellow => new(0xFFFAFAD2);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFD3D3D3.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightGray => new(0xFFD3D3D3);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF90EE90.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightGreen => new(0xFF90EE90);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFB6C1.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightPink => new(0xFFFFB6C1);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFA07A.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightSalmon => new(0xFFFFA07A);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF20B2AA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightSeaGreen => new(0xFF20B2AA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF87CEFA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightSkyBlue => new(0xFF87CEFA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF778899.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightSlateGray => new(0xFF778899);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFB0C4DE.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightSteelBlue => new(0xFFB0C4DE);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFFE0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color LightYellow => new(0xFFFFFFE0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00FF00.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Lime => new(0xFF00FF00);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF808000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Olive => new(0xFF808000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF6B8E23.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color OliveDrab => new(0xFF6B8E23);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFA500.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Orange => new(0xFFFFA500);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF4500.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color OrangeRed => new(0xFFFF4500);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFC0C0C0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Silver => new(0xFFC0C0C0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF87CEEB.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SkyBlue => new(0xFF87CEEB);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF6A5ACD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SlateBlue => new(0xFF6A5ACD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF708090.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SlateGray => new(0xFF708090);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFAFA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Snow => new(0xFFFFFAFA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00FF7F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SpringGreen => new(0xFF00FF7F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF4682B4.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SteelBlue => new(0xFF4682B4);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFD2B48C.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Tan => new(0xFFD2B48C);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF008080.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Teal => new(0xFF008080);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFD8BFD8.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Thistle => new(0xFFD8BFD8);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF6347.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Tomato => new(0xFFFF6347);

    /// <summary>
    /// Gets a system-defined color.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Transparent => new(0x00000000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF40E0D0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Turquoise => new(0xFF40E0D0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFEE82EE.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Violet => new(0xFFEE82EE);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF5DEB3.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Wheat => new(0xFFF5DEB3);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color White => new(0xFFFFFFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF5F5F5.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color WhiteSmoke => new(0xFFF5F5F5);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFA0522D.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Sienna => new(0xFFA0522D);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFE6E6FA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Lavender => new(0xFFE6E6FA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFF5EE.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SeaShell => new(0xFFFFF5EE);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF4A460.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SandyBrown => new(0xFFF4A460);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDA70D6.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Orchid => new(0xFFDA70D6);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFEEE8AA.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PaleGoldenrod => new(0xFFEEE8AA);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF98FB98.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PaleGreen => new(0xFF98FB98);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFAFEEEE.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PaleTurquoise => new(0xFFAFEEEE);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDB7093.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PaleVioletRed => new(0xFFDB7093);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFEFD5.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PapayaWhip => new(0xFFFFEFD5);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFDAB9.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PeachPuff => new(0xFFFFDAB9);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFCD853F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Peru => new(0xFFCD853F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFC0CB.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Pink => new(0xFFFFC0CB);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDDA0DD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Plum => new(0xFFDDA0DD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFB0E0E6.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color PowderBlue => new(0xFFB0E0E6);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF800080.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Purple => new(0xFF800080);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF0000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Red => new(0xFFFF0000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFBC8F8F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color RosyBrown => new(0xFFBC8F8F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF4169E1.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color RoyalBlue => new(0xFF4169E1);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF8B4513.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SaddleBrown => new(0xFF8B4513);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFA8072.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Salmon => new(0xFFFA8072);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF2E8B57.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color SeaGreen => new(0xFF2E8B57);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFF00.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Yellow => new(0xFFFFFF00);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF0E68C.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Khaki => new(0xFFF0E68C);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00FFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Cyan => new(0xFF00FFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF8B008B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkMagenta => new(0xFF8B008B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFBDB76B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkKhaki => new(0xFFBDB76B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF006400.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkGreen => new(0xFF006400);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFA9A9A9.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkGray => new(0xFFA9A9A9);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFB8860B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkGoldenrod => new(0xFFB8860B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF008B8B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkCyan => new(0xFF008B8B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00008B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkBlue => new(0xFF00008B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFFF0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Ivory => new(0xFFFFFFF0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDC143C.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Crimson => new(0xFFDC143C);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFF8DC.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Cornsilk => new(0xFFFFF8DC);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF6495ED.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color CornflowerBlue => new(0xFF6495ED);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF7F50.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Coral => new(0xFFFF7F50);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFD2691E.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Chocolate => new(0xFFD2691E);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF556B2F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkOliveGreen => new(0xFF556B2F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF7FFF00.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Chartreuse => new(0xFF7FFF00);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDEB887.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color BurlyWood => new(0xFFDEB887);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFA52A2A.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Brown => new(0xFFA52A2A);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF8A2BE2.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color BlueViolet => new(0xFF8A2BE2);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF0000FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Blue => new(0xFF0000FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFEBCD.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color BlanchedAlmond => new(0xFFFFEBCD);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF000000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Black => new(0xFF000000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFE4C4.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Bisque => new(0xFFFFE4C4);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF5F5DC.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Beige => new(0xFFF5F5DC);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF0FFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Azure => new(0xFFF0FFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF7FFFD4.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Aquamarine => new(0xFF7FFFD4);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00FFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Aqua => new(0xFF00FFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFAEBD7.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color AntiqueWhite => new(0xFFFAEBD7);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF0F8FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color AliceBlue => new(0xFFF0F8FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF5F9EA0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color CadetBlue => new(0xFF5F9EA0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF8C00.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkOrange => new(0xFFFF8C00);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF9ACD32.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color YellowGreen => new(0xFF9ACD32);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF8B0000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkRed => new(0xFF8B0000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF4B0082.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Indigo => new(0xFF4B0082);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFCD5C5C.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color IndianRed => new(0xFFCD5C5C);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF9932CC.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkOrchid => new(0xFF9932CC);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF0FFF0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Honeydew => new(0xFFF0FFF0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFADFF2F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color GreenYellow => new(0xFFADFF2F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF008000.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Green => new(0xFF008000);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF808080.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color structure representing a system-defined color.
    /// </returns>
    public static Color Gray => new(0xFF808080);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDAA520.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Goldenrod => new(0xFFDAA520);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFD700.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Gold => new(0xFFFFD700);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFF8F8FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color GhostWhite => new(0xFFF8F8FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFDCDCDC.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Gainsboro => new(0xFFDCDCDC);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF00FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Fuchsia => new(0xFFFF00FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF228B22.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color ForestGreen => new(0xFF228B22);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF69B4.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color HotPink => new(0xFFFF69B4);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFB22222.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color Firebrick => new(0xFFB22222);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFFFAF0.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color FloralWhite => new(0xFFFFFAF0);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF1E90FF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DodgerBlue => new(0xFF1E90FF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF696969.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DimGray => new(0xFF696969);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00BFFF.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DeepSkyBlue => new(0xFF00BFFF);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFFF1493.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DeepPink => new(0xFFFF1493);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF9400D3.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkViolet => new(0xFF9400D3);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF00CED1.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkTurquoise => new(0xFF00CED1);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF2F4F4F.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkSlateGray => new(0xFF2F4F4F);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF483D8B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkSlateBlue => new(0xFF483D8B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FF8FBC8B.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkSeaGreen => new(0xFF8FBC8B);

    /// <summary>
    /// Gets a system-defined color that has an ARGB value of #FFE9967A.
    /// </summary>
    /// <returns>
    /// A System.Drawing.Color representing a system-defined color.
    /// </returns>
    public static Color DarkSalmon => new(0xFFE9967A);

    #endregion Known colors

    /// <summary>
    /// Gets the alpha component value of this System.Drawing.Color structure.
    /// </summary>
    public byte A => (byte)(_color >> 24);

    /// <summary>
    /// Gets the blue component value of this System.Drawing.Color structure.
    /// </summary>
    public byte B => (byte)_color;

    /// <summary>
    /// Gets the red component value of this System.Drawing.Color structure.
    /// </summary>
    public byte R => (byte)(_color >> 16);

    /// <summary>
    /// Gets the green component value of this System.Drawing.Color structure.
    /// </summary>
    public byte G => (byte)(_color >> 8);

    /// <summary>
    /// Creates a System.Drawing.Color structure from the specified 8-bit color values
    /// (red, green, and blue). The alpha value is implicitly 255 (fully opaque). Although
    /// this method allows a 32-bit value to be passed for each color component, the
    /// value of each component is limited to 8 bits.
    /// </summary>
    /// <param name="r">The red component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="g">The green component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="b">The blue component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <returns>The System.Drawing.Color structure that this method creates.</returns>
    public static Color FromArgb(int r, int g, int b)
    {
        return new Color((uint)((0xFF << 24) | ((r & 0xFF) << 16) | ((g & 0xFF) << 8) | (b & 0xFF)));
    }

    /// <summary>
    /// Creates a System.Drawing.Color structure from the specified 8-bit color values
    /// (red, green, and blue). The alpha value is implicitly 255 (fully opaque). Although
    /// this method allows a 32-bit value to be passed for each color component, the
    /// value of each component is limited to 8 bits.
    /// </summary>
    /// <param name="a">The alpha component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="r">The red component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="g">The green component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="b">The blue component value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <returns>The System.Drawing.Color structure that this method creates.</returns>
    public static Color FromArgb(int a, int r, int g, int b)
    {
        return new Color((uint)(((a & 0xFF) << 24) | ((r & 0xFF) << 16) | ((g & 0xFF) << 8) | (b & 0xFF)));
    }

    /// <summary>
    /// Creates a System.Drawing.Color structure from a 32-bit ARGB value.
    /// </summary>
    /// <param name="argb">A value specifying the 32-bit ARGB value.</param>
    /// <returns>The System.Drawing.Color structure that this method creates.</returns>
    public static Color FromArgb(int argb) => new((uint)argb);

    /// <summary>
    /// Creates a System.Drawing.Color structure from the specified System.Drawing.Color
    /// structure, but with the new specified alpha value. Although this method allows
    /// a 32-bit value to be passed for the alpha value, the value is limited to 8 bits.
    /// </summary>
    /// <param name="alpha">The alpha value for the new System.Drawing.Color. Valid values are 0 through 255.</param>
    /// <param name="baseColor">The System.Drawing.Color from which to create the new System.Drawing.Color.</param>
    /// <returns>The System.Drawing.Color that this method creates.</returns>
    public static Color FromArgb(int alpha, Color baseColor) => new((uint)(alpha << 24) | (0x00FFFFFF & baseColor._color));

    /// <summary>
    /// Tests whether two specified System.Drawing.Color structures are equivalent.
    /// </summary>
    /// <param name="left">The System.Drawing.Color that is to the left of the equality operator.</param>
    /// <param name="right">The System.Drawing.Color that is to the right of the equality operator.</param>
    /// <returns>true if the two System.Drawing.Color structures are equal; otherwise, false.</returns>
    public static bool operator ==(Color left, Color right) => left._color == right._color;

    /// <summary>
    /// Tests whether two specified System.Drawing.Color structures are different.
    /// </summary>
    /// <param name="left">The System.Drawing.Color that is to the left of the inequality operator.</param>
    /// <param name="right">The System.Drawing.Color that is to the right of the inequality operator.</param>
    /// <returns>true if the two System.Drawing.Color structures are different; otherwise, false.</returns>
    public static bool operator !=(Color left, Color right) => left._color != right._color;

    /// <summary>
    /// Internal Helper function for ParseHex.
    /// </summary>
    /// <param name="intChar">Value to convert.</param>
    /// <returns>Int value.</returns>
    internal static int ParseHexChar(char intChar)
    {
        const int LOWER_A_MINUS_10 = 'a' - 10;
        const int UPPER_A_MINUS_10 = 'A' - 10;
        return intChar switch
        {
            >= '0' and <= '9' => intChar - '0',
            >= 'a' and <= 'f' => intChar - LOWER_A_MINUS_10,
            >= 'A' and <= 'F' => intChar - UPPER_A_MINUS_10,
            _ => throw new FormatException($"Illegal token. {intChar} can't be converted")
        };
    }

    /// <summary>
    /// Convert String into a Color struct.
    /// </summary>
    /// <param name="hexString">Color String. Allowed formats are #AARRGGBB #RRGGBB #ARGB #RGB.</param>
    /// <returns>Returns a Color struct otherwise throws an exception.</returns>
    /// <exception>ArgumentException or FormatException.</exception>
    public static Color FromHex(string hexString)
    {
        int r, g, b, a = 255;

        if (hexString[0] != '#')
        {
            throw new ArgumentException("Leading # is missing.");
        }

        switch (hexString.Length)
        {
            case 9: // #AARRGGBB
                a = ParseHexChar(hexString[1]) << 4 | ParseHexChar(hexString[2]);
                r = ParseHexChar(hexString[3]) << 4 | ParseHexChar(hexString[4]);
                g = ParseHexChar(hexString[5]) << 4 | ParseHexChar(hexString[6]);
                b = ParseHexChar(hexString[7]) << 4 | ParseHexChar(hexString[8]);
                break;

            case 7: // #RRGGBB
                r = ParseHexChar(hexString[1]) << 4 | ParseHexChar(hexString[2]);
                g = ParseHexChar(hexString[3]) << 4 | ParseHexChar(hexString[4]);
                b = ParseHexChar(hexString[5]) << 4 | ParseHexChar(hexString[6]);
                break;

            case 5: // #ARGB
                a = ParseHexChar(hexString[1]);
                a = a << 4 | a;
                r = ParseHexChar(hexString[2]);
                r = r << 4 | r;
                g = ParseHexChar(hexString[3]);
                g = g << 4 | g;
                b = ParseHexChar(hexString[4]);
                b = b << 4 | b;
                break;

            case 4: // #RGB
                r = ParseHexChar(hexString[1]);
                r = r << 4 | r;
                g = ParseHexChar(hexString[2]);
                g = g << 4 | g;
                b = ParseHexChar(hexString[3]);
                b = b << 4 | b;
                break;

            default:
                throw new ArgumentException($"Length of {hexString.Length} not match any know format");
        }

        return FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
    }

    /// <summary>
    /// Convert String with a known color name into a Color struct.
    /// </summary>
    /// <param name="color">The name of the color.</param>
    /// <returns>A color.</returns>
    public static Color GetColorFromString(string color)
    {
        // Firs check if we can convert with the name
        Color? col = FromColorName(color);
        if (col != null)
        {
            return (Color)col;
        }

        return FromHex(color);
    }

    /// <summary>
    /// Tries to convert a string into a color either from a color name either from a HEX representation.
    /// </summary>
    /// <param name="strColor">The string to convert.</param>
    /// <param name="color">The color.</param>
    /// <returns>A color.</returns>
    public static bool TryGetColor(string strColor, out Color color)
    {
        try
        {
            color = GetColorFromString(strColor);
            return true;
        }
        catch
        {
            color = Black;
            return false;
        }
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to other; otherwise, false.</returns>
    public override bool Equals(object? other) => _color == ((Color)other)._color;

    /// <summary>
    /// Gets the hue-saturation-lightness (HSL) lightness value for this System.Drawing.Color structure.
    /// </summary>
    /// <returns>The lightness of this System.Drawing.Color. The lightness ranges from 0.0 through 1.0, where 0.0 represents black and 1.0 represents white.</returns>
    public float GetBrightness()
    {
        float r = R / 255.0f;
        float g = G / 255.0f;
        float b = B / 255.0f;
        float max = r > b ? r : b;
        max = max > g ? max : g;
        return max;
    }

    /// <summary>
    /// Returns a hash code for this System.Drawing.Color structure.
    /// </summary>
    /// <returns>An integer value that specifies the hash code for this System.Drawing.Color.</returns>
    public override int GetHashCode() => (int)_color;

    /// <summary>
    /// Gets the hue-saturation-lightness (HSL) hue value, in degrees, for this System.Drawing.Color structure.
    /// </summary>
    /// <returns>The hue, in degrees, of this System.Drawing.Color. The hue is measured in degrees,
    /// ranging from 0.0 through 360.0, in HSL color space.</returns>
    public float GetHue()
    {
        float r = R / 255.0f;
        float g = G / 255.0f;
        float b = B / 255.0f;
        float max = r > b ? r : b;
        max = max > g ? max : g;
        float min = r > b ? b : r;
        min = min > g ? g : min;

        float h = 0.0f;
        if (max == r && g >= b)
        {
            h = 60 * (g - b) / (max - min);
        }
        else if (max == r && g < b)
        {
            h = 60 * (g - b) / (max - min) + 360;
        }
        else if (max == g)
        {
            h = 60 * (b - r) / (max - min) + 120;
        }
        else if (max == b)
        {
            h = 60 * (r - g) / (max - min) + 240;
        }

        return h;
    }

    /// <summary>
    /// Gets the hue-saturation-lightness (HSL) saturation value for this System.Drawing.Color structure.
    /// </summary>
    /// <returns>The saturation of this System.Drawing.Color. The saturation ranges from 0.0 through
    /// 1.0, where 0.0 is grayscale and 1.0 is the most saturated.</returns>
    public float GetSaturation()
    {
        float r = R / 255.0f;
        float g = G / 255.0f;
        float b = B / 255.0f;
        float max = r > b ? r : b;
        max = max > g ? max : g;
        float min = r > b ? b : r;
        min = min > g ? g : min;
        return max == 0 ? 0.0f : 1.0f - min / max;
    }

    /// <summary>
    /// Gets the 32-bit ARGB value of this System.Drawing.Color structure.
    /// </summary>
    /// <returns>The 32-bit ARGB value of this System.Drawing.Color.</returns>
    public int ToArgb() => (int)_color;

    /// <summary>
    /// Converts a known Color name into a Color.
    /// </summary>
    /// <param name="colorName">The known color name.</param>
    /// <returns>The color or null if not found.</returns>
    public static Color? FromColorName(string colorName)
    {
        MethodInfo[] members = typeof(Color).GetMethods(BindingFlags.Static | BindingFlags.Public);
        foreach (MethodInfo member in members)
        {
            if (member.Name.Length > 4)
            {
                if (string.Compare(member.Name[4..], colorName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return (Color)member.Invoke(null, null);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Gets the color in standard HEX format
    /// </summary>
    /// <returns>The standard HEX string.</returns>
    public override string ToString() => $"#{GetHashCode():X2}";
}