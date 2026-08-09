using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp;

public readonly struct Color : IEquatable<Color>
{
	private readonly Rgba64 data;

	private readonly IPixel? boxedHighPrecisionPixel;

	private static readonly Lazy<Dictionary<string, Color>> NamedColorsLookupLazy;

	public static readonly Color AliceBlue;

	public static readonly Color AntiqueWhite;

	public static readonly Color Aqua;

	public static readonly Color Aquamarine;

	public static readonly Color Azure;

	public static readonly Color Beige;

	public static readonly Color Bisque;

	public static readonly Color Black;

	public static readonly Color BlanchedAlmond;

	public static readonly Color Blue;

	public static readonly Color BlueViolet;

	public static readonly Color Brown;

	public static readonly Color BurlyWood;

	public static readonly Color CadetBlue;

	public static readonly Color Chartreuse;

	public static readonly Color Chocolate;

	public static readonly Color Coral;

	public static readonly Color CornflowerBlue;

	public static readonly Color Cornsilk;

	public static readonly Color Crimson;

	public static readonly Color Cyan;

	public static readonly Color DarkBlue;

	public static readonly Color DarkCyan;

	public static readonly Color DarkGoldenrod;

	public static readonly Color DarkGray;

	public static readonly Color DarkGreen;

	public static readonly Color DarkGrey;

	public static readonly Color DarkKhaki;

	public static readonly Color DarkMagenta;

	public static readonly Color DarkOliveGreen;

	public static readonly Color DarkOrange;

	public static readonly Color DarkOrchid;

	public static readonly Color DarkRed;

	public static readonly Color DarkSalmon;

	public static readonly Color DarkSeaGreen;

	public static readonly Color DarkSlateBlue;

	public static readonly Color DarkSlateGray;

	public static readonly Color DarkSlateGrey;

	public static readonly Color DarkTurquoise;

	public static readonly Color DarkViolet;

	public static readonly Color DeepPink;

	public static readonly Color DeepSkyBlue;

	public static readonly Color DimGray;

	public static readonly Color DimGrey;

	public static readonly Color DodgerBlue;

	public static readonly Color Firebrick;

	public static readonly Color FloralWhite;

	public static readonly Color ForestGreen;

	public static readonly Color Fuchsia;

	public static readonly Color Gainsboro;

	public static readonly Color GhostWhite;

	public static readonly Color Gold;

	public static readonly Color Goldenrod;

	public static readonly Color Gray;

	public static readonly Color Green;

	public static readonly Color GreenYellow;

	public static readonly Color Grey;

	public static readonly Color Honeydew;

	public static readonly Color HotPink;

	public static readonly Color IndianRed;

	public static readonly Color Indigo;

	public static readonly Color Ivory;

	public static readonly Color Khaki;

	public static readonly Color Lavender;

	public static readonly Color LavenderBlush;

	public static readonly Color LawnGreen;

	public static readonly Color LemonChiffon;

	public static readonly Color LightBlue;

	public static readonly Color LightCoral;

	public static readonly Color LightCyan;

	public static readonly Color LightGoldenrodYellow;

	public static readonly Color LightGray;

	public static readonly Color LightGreen;

	public static readonly Color LightGrey;

	public static readonly Color LightPink;

	public static readonly Color LightSalmon;

	public static readonly Color LightSeaGreen;

	public static readonly Color LightSkyBlue;

	public static readonly Color LightSlateGray;

	public static readonly Color LightSlateGrey;

	public static readonly Color LightSteelBlue;

	public static readonly Color LightYellow;

	public static readonly Color Lime;

	public static readonly Color LimeGreen;

	public static readonly Color Linen;

	public static readonly Color Magenta;

	public static readonly Color Maroon;

	public static readonly Color MediumAquamarine;

	public static readonly Color MediumBlue;

	public static readonly Color MediumOrchid;

	public static readonly Color MediumPurple;

	public static readonly Color MediumSeaGreen;

	public static readonly Color MediumSlateBlue;

	public static readonly Color MediumSpringGreen;

	public static readonly Color MediumTurquoise;

	public static readonly Color MediumVioletRed;

	public static readonly Color MidnightBlue;

	public static readonly Color MintCream;

	public static readonly Color MistyRose;

	public static readonly Color Moccasin;

	public static readonly Color NavajoWhite;

	public static readonly Color Navy;

	public static readonly Color OldLace;

	public static readonly Color Olive;

	public static readonly Color OliveDrab;

	public static readonly Color Orange;

	public static readonly Color OrangeRed;

	public static readonly Color Orchid;

	public static readonly Color PaleGoldenrod;

	public static readonly Color PaleGreen;

	public static readonly Color PaleTurquoise;

	public static readonly Color PaleVioletRed;

	public static readonly Color PapayaWhip;

	public static readonly Color PeachPuff;

	public static readonly Color Peru;

	public static readonly Color Pink;

	public static readonly Color Plum;

	public static readonly Color PowderBlue;

	public static readonly Color Purple;

	public static readonly Color RebeccaPurple;

	public static readonly Color Red;

	public static readonly Color RosyBrown;

	public static readonly Color RoyalBlue;

	public static readonly Color SaddleBrown;

	public static readonly Color Salmon;

	public static readonly Color SandyBrown;

	public static readonly Color SeaGreen;

	public static readonly Color SeaShell;

	public static readonly Color Sienna;

	public static readonly Color Silver;

	public static readonly Color SkyBlue;

	public static readonly Color SlateBlue;

	public static readonly Color SlateGray;

	public static readonly Color SlateGrey;

	public static readonly Color Snow;

	public static readonly Color SpringGreen;

	public static readonly Color SteelBlue;

	public static readonly Color Tan;

	public static readonly Color Teal;

	public static readonly Color Thistle;

	public static readonly Color Tomato;

	public static readonly Color Transparent;

	public static readonly Color Turquoise;

	public static readonly Color Violet;

	public static readonly Color Wheat;

	public static readonly Color White;

	public static readonly Color WhiteSmoke;

	public static readonly Color Yellow;

	public static readonly Color YellowGreen;

	private static readonly Lazy<Color[]> WebSafePaletteLazy;

	private static readonly Lazy<Color[]> WernerPaletteLazy;

	public static ReadOnlyMemory<Color> WebSafePalette => WebSafePaletteLazy.Value;

	public static ReadOnlyMemory<Color> WernerPalette => WernerPaletteLazy.Value;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Rgba64 pixel)
	{
		data = pixel;
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Rgb48 pixel)
	{
		data = new Rgba64(pixel.R, pixel.G, pixel.B, ushort.MaxValue);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(La32 pixel)
	{
		data = new Rgba64(pixel.L, pixel.L, pixel.L, pixel.A);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(L16 pixel)
	{
		data = new Rgba64(pixel.PackedValue, pixel.PackedValue, pixel.PackedValue, ushort.MaxValue);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Rgba32 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Argb32 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Bgra32 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Abgr32 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Rgb24 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Bgr24 pixel)
	{
		data = new Rgba64(pixel);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Color(Vector4 vector)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		vector = Numerics.Clamp(vector, Vector4.Zero, Vector4.One);
		boxedHighPrecisionPixel = new RgbaVector(vector.X, vector.Y, vector.Z, vector.W);
		data = default(Rgba64);
	}

	public static explicit operator Vector4(Color color)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return color.ToScaledVector4();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static explicit operator Color(Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new Color(source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Rgba32 ToRgba32()
	{
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToRgba32();
		}
		Rgba32 dest = default(Rgba32);
		boxedHighPrecisionPixel.ToRgba32(ref dest);
		return dest;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Bgra32 ToBgra32()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToBgra32();
		}
		Bgra32 result = default(Bgra32);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Argb32 ToArgb32()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToArgb32();
		}
		Argb32 result = default(Argb32);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Abgr32 ToAbgr32()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToAbgr32();
		}
		Abgr32 result = default(Abgr32);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Rgb24 ToRgb24()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToRgb24();
		}
		Rgb24 result = default(Rgb24);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Bgr24 ToBgr24()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToBgr24();
		}
		Bgr24 result = default(Bgr24);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal Vector4 ToScaledVector4()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (boxedHighPrecisionPixel == null)
		{
			return data.ToScaledVector4();
		}
		return boxedHighPrecisionPixel.ToScaledVector4();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Color(byte r, byte g, byte b, byte a)
	{
		data = new Rgba64(ColorNumerics.UpscaleFrom8BitTo16Bit(r), ColorNumerics.UpscaleFrom8BitTo16Bit(g), ColorNumerics.UpscaleFrom8BitTo16Bit(b), ColorNumerics.UpscaleFrom8BitTo16Bit(a));
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Color(byte r, byte g, byte b)
	{
		data = new Rgba64(ColorNumerics.UpscaleFrom8BitTo16Bit(r), ColorNumerics.UpscaleFrom8BitTo16Bit(g), ColorNumerics.UpscaleFrom8BitTo16Bit(b), ushort.MaxValue);
		boxedHighPrecisionPixel = null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Color(IPixel pixel)
	{
		boxedHighPrecisionPixel = pixel;
		data = default(Rgba64);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Color left, Color right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Color left, Color right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color FromRgba(byte r, byte g, byte b, byte a)
	{
		return new Color(r, g, b, a);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color FromRgb(byte r, byte g, byte b)
	{
		return new Color(r, g, b);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color FromPixel<TPixel>(TPixel pixel) where TPixel : unmanaged, IPixel<TPixel>
	{
		if (typeof(TPixel) == typeof(Rgba64))
		{
			return new Color((Rgba64)(object)pixel);
		}
		if (typeof(TPixel) == typeof(Rgb48))
		{
			return new Color((Rgb48)(object)pixel);
		}
		if (typeof(TPixel) == typeof(La32))
		{
			return new Color((La32)(object)pixel);
		}
		if (typeof(TPixel) == typeof(L16))
		{
			return new Color((L16)(object)pixel);
		}
		if (Unsafe.SizeOf<TPixel>() <= Unsafe.SizeOf<Rgba32>())
		{
			Rgba32 dest = default(Rgba32);
			pixel.ToRgba32(ref dest);
			return new Color(dest);
		}
		return new Color((IPixel)pixel);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Color ParseHex(string hex)
	{
		return new Color(Rgba32.ParseHex(hex));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryParseHex(string hex, out Color result)
	{
		result = default(Color);
		if (Rgba32.TryParseHex(hex, out var result2))
		{
			result = new Color(result2);
			return true;
		}
		return false;
	}

	public static Color Parse(string input)
	{
		Guard.NotNull(input, "input");
		if (!TryParse(input, out var result))
		{
			throw new ArgumentException("Input string is not in the correct format.", "input");
		}
		return result;
	}

	public static bool TryParse(string input, out Color result)
	{
		result = default(Color);
		if (string.IsNullOrWhiteSpace(input))
		{
			return false;
		}
		if (NamedColorsLookupLazy.Value.TryGetValue(input, out result))
		{
			return true;
		}
		return TryParseHex(input, out result);
	}

	public Color WithAlpha(float alpha)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		Vector4 vector = (Vector4)this;
		vector.W = alpha;
		return new Color(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public string ToHex()
	{
		if (boxedHighPrecisionPixel != null)
		{
			Rgba32 dest = default(Rgba32);
			boxedHighPrecisionPixel.ToRgba32(ref dest);
			return dest.ToHex();
		}
		return data.ToRgba32().ToHex();
	}

	public override string ToString()
	{
		return ToHex();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TPixel ToPixel<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		IPixel pixel = boxedHighPrecisionPixel;
		if (pixel is TPixel)
		{
			return (TPixel)pixel;
		}
		TPixel result;
		if (boxedHighPrecisionPixel == null)
		{
			result = default(TPixel);
			result.FromRgba64(data);
			return result;
		}
		result = default(TPixel);
		result.FromScaledVector4(boxedHighPrecisionPixel.ToScaledVector4());
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ToPixel<TPixel>(ReadOnlySpan<Color> source, Span<TPixel> destination) where TPixel : unmanaged, IPixel<TPixel>
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		for (int i = 0; i < source.Length; i++)
		{
			destination[i] = source[i].ToPixel<TPixel>();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(Color other)
	{
		if (boxedHighPrecisionPixel == null && other.boxedHighPrecisionPixel == null)
		{
			return data.PackedValue == other.data.PackedValue;
		}
		return boxedHighPrecisionPixel?.Equals(other.boxedHighPrecisionPixel) ?? false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Color other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		if (boxedHighPrecisionPixel == null)
		{
			return data.PackedValue.GetHashCode();
		}
		return boxedHighPrecisionPixel.GetHashCode();
	}

	private static Dictionary<string, Color> CreateNamedColorsLookup()
	{
		return new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
		{
			{ "AliceBlue", AliceBlue },
			{ "AntiqueWhite", AntiqueWhite },
			{ "Aqua", Aqua },
			{ "Aquamarine", Aquamarine },
			{ "Azure", Azure },
			{ "Beige", Beige },
			{ "Bisque", Bisque },
			{ "Black", Black },
			{ "BlanchedAlmond", BlanchedAlmond },
			{ "Blue", Blue },
			{ "BlueViolet", BlueViolet },
			{ "Brown", Brown },
			{ "BurlyWood", BurlyWood },
			{ "CadetBlue", CadetBlue },
			{ "Chartreuse", Chartreuse },
			{ "Chocolate", Chocolate },
			{ "Coral", Coral },
			{ "CornflowerBlue", CornflowerBlue },
			{ "Cornsilk", Cornsilk },
			{ "Crimson", Crimson },
			{ "Cyan", Cyan },
			{ "DarkBlue", DarkBlue },
			{ "DarkCyan", DarkCyan },
			{ "DarkGoldenrod", DarkGoldenrod },
			{ "DarkGray", DarkGray },
			{ "DarkGreen", DarkGreen },
			{ "DarkGrey", DarkGrey },
			{ "DarkKhaki", DarkKhaki },
			{ "DarkMagenta", DarkMagenta },
			{ "DarkOliveGreen", DarkOliveGreen },
			{ "DarkOrange", DarkOrange },
			{ "DarkOrchid", DarkOrchid },
			{ "DarkRed", DarkRed },
			{ "DarkSalmon", DarkSalmon },
			{ "DarkSeaGreen", DarkSeaGreen },
			{ "DarkSlateBlue", DarkSlateBlue },
			{ "DarkSlateGray", DarkSlateGray },
			{ "DarkSlateGrey", DarkSlateGrey },
			{ "DarkTurquoise", DarkTurquoise },
			{ "DarkViolet", DarkViolet },
			{ "DeepPink", DeepPink },
			{ "DeepSkyBlue", DeepSkyBlue },
			{ "DimGray", DimGray },
			{ "DimGrey", DimGrey },
			{ "DodgerBlue", DodgerBlue },
			{ "Firebrick", Firebrick },
			{ "FloralWhite", FloralWhite },
			{ "ForestGreen", ForestGreen },
			{ "Fuchsia", Fuchsia },
			{ "Gainsboro", Gainsboro },
			{ "GhostWhite", GhostWhite },
			{ "Gold", Gold },
			{ "Goldenrod", Goldenrod },
			{ "Gray", Gray },
			{ "Green", Green },
			{ "GreenYellow", GreenYellow },
			{ "Grey", Grey },
			{ "Honeydew", Honeydew },
			{ "HotPink", HotPink },
			{ "IndianRed", IndianRed },
			{ "Indigo", Indigo },
			{ "Ivory", Ivory },
			{ "Khaki", Khaki },
			{ "Lavender", Lavender },
			{ "LavenderBlush", LavenderBlush },
			{ "LawnGreen", LawnGreen },
			{ "LemonChiffon", LemonChiffon },
			{ "LightBlue", LightBlue },
			{ "LightCoral", LightCoral },
			{ "LightCyan", LightCyan },
			{ "LightGoldenrodYellow", LightGoldenrodYellow },
			{ "LightGray", LightGray },
			{ "LightGreen", LightGreen },
			{ "LightGrey", LightGrey },
			{ "LightPink", LightPink },
			{ "LightSalmon", LightSalmon },
			{ "LightSeaGreen", LightSeaGreen },
			{ "LightSkyBlue", LightSkyBlue },
			{ "LightSlateGray", LightSlateGray },
			{ "LightSlateGrey", LightSlateGrey },
			{ "LightSteelBlue", LightSteelBlue },
			{ "LightYellow", LightYellow },
			{ "Lime", Lime },
			{ "LimeGreen", LimeGreen },
			{ "Linen", Linen },
			{ "Magenta", Magenta },
			{ "Maroon", Maroon },
			{ "MediumAquamarine", MediumAquamarine },
			{ "MediumBlue", MediumBlue },
			{ "MediumOrchid", MediumOrchid },
			{ "MediumPurple", MediumPurple },
			{ "MediumSeaGreen", MediumSeaGreen },
			{ "MediumSlateBlue", MediumSlateBlue },
			{ "MediumSpringGreen", MediumSpringGreen },
			{ "MediumTurquoise", MediumTurquoise },
			{ "MediumVioletRed", MediumVioletRed },
			{ "MidnightBlue", MidnightBlue },
			{ "MintCream", MintCream },
			{ "MistyRose", MistyRose },
			{ "Moccasin", Moccasin },
			{ "NavajoWhite", NavajoWhite },
			{ "Navy", Navy },
			{ "OldLace", OldLace },
			{ "Olive", Olive },
			{ "OliveDrab", OliveDrab },
			{ "Orange", Orange },
			{ "OrangeRed", OrangeRed },
			{ "Orchid", Orchid },
			{ "PaleGoldenrod", PaleGoldenrod },
			{ "PaleGreen", PaleGreen },
			{ "PaleTurquoise", PaleTurquoise },
			{ "PaleVioletRed", PaleVioletRed },
			{ "PapayaWhip", PapayaWhip },
			{ "PeachPuff", PeachPuff },
			{ "Peru", Peru },
			{ "Pink", Pink },
			{ "Plum", Plum },
			{ "PowderBlue", PowderBlue },
			{ "Purple", Purple },
			{ "RebeccaPurple", RebeccaPurple },
			{ "Red", Red },
			{ "RosyBrown", RosyBrown },
			{ "RoyalBlue", RoyalBlue },
			{ "SaddleBrown", SaddleBrown },
			{ "Salmon", Salmon },
			{ "SandyBrown", SandyBrown },
			{ "SeaGreen", SeaGreen },
			{ "SeaShell", SeaShell },
			{ "Sienna", Sienna },
			{ "Silver", Silver },
			{ "SkyBlue", SkyBlue },
			{ "SlateBlue", SlateBlue },
			{ "SlateGray", SlateGray },
			{ "SlateGrey", SlateGrey },
			{ "Snow", Snow },
			{ "SpringGreen", SpringGreen },
			{ "SteelBlue", SteelBlue },
			{ "Tan", Tan },
			{ "Teal", Teal },
			{ "Thistle", Thistle },
			{ "Tomato", Tomato },
			{ "Transparent", Transparent },
			{ "Turquoise", Turquoise },
			{ "Violet", Violet },
			{ "Wheat", Wheat },
			{ "White", White },
			{ "WhiteSmoke", WhiteSmoke },
			{ "Yellow", Yellow },
			{ "YellowGreen", YellowGreen }
		};
	}

	private static Color[] CreateWebSafePalette()
	{
		return new Color[142]
		{
			AliceBlue, AntiqueWhite, Aqua, Aquamarine, Azure, Beige, Bisque, Black, BlanchedAlmond, Blue,
			BlueViolet, Brown, BurlyWood, CadetBlue, Chartreuse, Chocolate, Coral, CornflowerBlue, Cornsilk, Crimson,
			Cyan, DarkBlue, DarkCyan, DarkGoldenrod, DarkGray, DarkGreen, DarkKhaki, DarkMagenta, DarkOliveGreen, DarkOrange,
			DarkOrchid, DarkRed, DarkSalmon, DarkSeaGreen, DarkSlateBlue, DarkSlateGray, DarkTurquoise, DarkViolet, DeepPink, DeepSkyBlue,
			DimGray, DodgerBlue, Firebrick, FloralWhite, ForestGreen, Fuchsia, Gainsboro, GhostWhite, Gold, Goldenrod,
			Gray, Green, GreenYellow, Honeydew, HotPink, IndianRed, Indigo, Ivory, Khaki, Lavender,
			LavenderBlush, LawnGreen, LemonChiffon, LightBlue, LightCoral, LightCyan, LightGoldenrodYellow, LightGray, LightGreen, LightPink,
			LightSalmon, LightSeaGreen, LightSkyBlue, LightSlateGray, LightSteelBlue, LightYellow, Lime, LimeGreen, Linen, Magenta,
			Maroon, MediumAquamarine, MediumBlue, MediumOrchid, MediumPurple, MediumSeaGreen, MediumSlateBlue, MediumSpringGreen, MediumTurquoise, MediumVioletRed,
			MidnightBlue, MintCream, MistyRose, Moccasin, NavajoWhite, Navy, OldLace, Olive, OliveDrab, Orange,
			OrangeRed, Orchid, PaleGoldenrod, PaleGreen, PaleTurquoise, PaleVioletRed, PapayaWhip, PeachPuff, Peru, Pink,
			Plum, PowderBlue, Purple, RebeccaPurple, Red, RosyBrown, RoyalBlue, SaddleBrown, Salmon, SandyBrown,
			SeaGreen, SeaShell, Sienna, Silver, SkyBlue, SlateBlue, SlateGray, Snow, SpringGreen, SteelBlue,
			Tan, Teal, Thistle, Tomato, Transparent, Turquoise, Violet, Wheat, White, WhiteSmoke,
			Yellow, YellowGreen
		};
	}

	private static Color[] CreateWernerPalette()
	{
		return new Color[110]
		{
			ParseHex("#f1e9cd"),
			ParseHex("#f2e7cf"),
			ParseHex("#ece6d0"),
			ParseHex("#f2eacc"),
			ParseHex("#f3e9ca"),
			ParseHex("#f2ebcd"),
			ParseHex("#e6e1c9"),
			ParseHex("#e2ddc6"),
			ParseHex("#cbc8b7"),
			ParseHex("#bfbbb0"),
			ParseHex("#bebeb3"),
			ParseHex("#b7b5ac"),
			ParseHex("#bab191"),
			ParseHex("#9c9d9a"),
			ParseHex("#8a8d84"),
			ParseHex("#5b5c61"),
			ParseHex("#555152"),
			ParseHex("#413f44"),
			ParseHex("#454445"),
			ParseHex("#423937"),
			ParseHex("#433635"),
			ParseHex("#252024"),
			ParseHex("#241f20"),
			ParseHex("#281f3f"),
			ParseHex("#1c1949"),
			ParseHex("#4f638d"),
			ParseHex("#383867"),
			ParseHex("#5c6b8f"),
			ParseHex("#657abb"),
			ParseHex("#6f88af"),
			ParseHex("#7994b5"),
			ParseHex("#6fb5a8"),
			ParseHex("#719ba2"),
			ParseHex("#8aa1a6"),
			ParseHex("#d0d5d3"),
			ParseHex("#8590ae"),
			ParseHex("#3a2f52"),
			ParseHex("#39334a"),
			ParseHex("#6c6d94"),
			ParseHex("#584c77"),
			ParseHex("#533552"),
			ParseHex("#463759"),
			ParseHex("#bfbac0"),
			ParseHex("#77747f"),
			ParseHex("#4a475c"),
			ParseHex("#b8bfaf"),
			ParseHex("#b2b599"),
			ParseHex("#979c84"),
			ParseHex("#5d6161"),
			ParseHex("#61ac86"),
			ParseHex("#a4b6a7"),
			ParseHex("#adba98"),
			ParseHex("#93b778"),
			ParseHex("#7d8c55"),
			ParseHex("#33431e"),
			ParseHex("#7c8635"),
			ParseHex("#8e9849"),
			ParseHex("#c2c190"),
			ParseHex("#67765b"),
			ParseHex("#ab924b"),
			ParseHex("#c8c76f"),
			ParseHex("#ccc050"),
			ParseHex("#ebdd99"),
			ParseHex("#ab9649"),
			ParseHex("#dbc364"),
			ParseHex("#e6d058"),
			ParseHex("#ead665"),
			ParseHex("#d09b2c"),
			ParseHex("#a36629"),
			ParseHex("#a77d35"),
			ParseHex("#f0d696"),
			ParseHex("#d7c485"),
			ParseHex("#f1d28c"),
			ParseHex("#efcc83"),
			ParseHex("#f3daa7"),
			ParseHex("#dfa837"),
			ParseHex("#ebbc71"),
			ParseHex("#d17c3f"),
			ParseHex("#92462f"),
			ParseHex("#be7249"),
			ParseHex("#bb603c"),
			ParseHex("#c76b4a"),
			ParseHex("#a75536"),
			ParseHex("#b63e36"),
			ParseHex("#b5493a"),
			ParseHex("#cd6d57"),
			ParseHex("#711518"),
			ParseHex("#e9c49d"),
			ParseHex("#eedac3"),
			ParseHex("#eecfbf"),
			ParseHex("#ce536b"),
			ParseHex("#b74a70"),
			ParseHex("#b7757c"),
			ParseHex("#612741"),
			ParseHex("#7a4848"),
			ParseHex("#3f3033"),
			ParseHex("#8d746f"),
			ParseHex("#4d3635"),
			ParseHex("#6e3b31"),
			ParseHex("#864735"),
			ParseHex("#553d3a"),
			ParseHex("#613936"),
			ParseHex("#7a4b3a"),
			ParseHex("#946943"),
			ParseHex("#c39e6d"),
			ParseHex("#513e32"),
			ParseHex("#8b7859"),
			ParseHex("#9b856b"),
			ParseHex("#766051"),
			ParseHex("#453b32")
		};
	}

	static Color()
	{
		NamedColorsLookupLazy = new Lazy<Dictionary<string, Color>>(CreateNamedColorsLookup, isThreadSafe: true);
		AliceBlue = FromRgba(240, 248, byte.MaxValue, byte.MaxValue);
		AntiqueWhite = FromRgba(250, 235, 215, byte.MaxValue);
		Aqua = FromRgba(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		Aquamarine = FromRgba(127, byte.MaxValue, 212, byte.MaxValue);
		Azure = FromRgba(240, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		Beige = FromRgba(245, 245, 220, byte.MaxValue);
		Bisque = FromRgba(byte.MaxValue, 228, 196, byte.MaxValue);
		Black = FromRgba(0, 0, 0, byte.MaxValue);
		BlanchedAlmond = FromRgba(byte.MaxValue, 235, 205, byte.MaxValue);
		Blue = FromRgba(0, 0, byte.MaxValue, byte.MaxValue);
		BlueViolet = FromRgba(138, 43, 226, byte.MaxValue);
		Brown = FromRgba(165, 42, 42, byte.MaxValue);
		BurlyWood = FromRgba(222, 184, 135, byte.MaxValue);
		CadetBlue = FromRgba(95, 158, 160, byte.MaxValue);
		Chartreuse = FromRgba(127, byte.MaxValue, 0, byte.MaxValue);
		Chocolate = FromRgba(210, 105, 30, byte.MaxValue);
		Coral = FromRgba(byte.MaxValue, 127, 80, byte.MaxValue);
		CornflowerBlue = FromRgba(100, 149, 237, byte.MaxValue);
		Cornsilk = FromRgba(byte.MaxValue, 248, 220, byte.MaxValue);
		Crimson = FromRgba(220, 20, 60, byte.MaxValue);
		Cyan = Aqua;
		DarkBlue = FromRgba(0, 0, 139, byte.MaxValue);
		DarkCyan = FromRgba(0, 139, 139, byte.MaxValue);
		DarkGoldenrod = FromRgba(184, 134, 11, byte.MaxValue);
		DarkGray = FromRgba(169, 169, 169, byte.MaxValue);
		DarkGreen = FromRgba(0, 100, 0, byte.MaxValue);
		DarkGrey = DarkGray;
		DarkKhaki = FromRgba(189, 183, 107, byte.MaxValue);
		DarkMagenta = FromRgba(139, 0, 139, byte.MaxValue);
		DarkOliveGreen = FromRgba(85, 107, 47, byte.MaxValue);
		DarkOrange = FromRgba(byte.MaxValue, 140, 0, byte.MaxValue);
		DarkOrchid = FromRgba(153, 50, 204, byte.MaxValue);
		DarkRed = FromRgba(139, 0, 0, byte.MaxValue);
		DarkSalmon = FromRgba(233, 150, 122, byte.MaxValue);
		DarkSeaGreen = FromRgba(143, 188, 143, byte.MaxValue);
		DarkSlateBlue = FromRgba(72, 61, 139, byte.MaxValue);
		DarkSlateGray = FromRgba(47, 79, 79, byte.MaxValue);
		DarkSlateGrey = DarkSlateGray;
		DarkTurquoise = FromRgba(0, 206, 209, byte.MaxValue);
		DarkViolet = FromRgba(148, 0, 211, byte.MaxValue);
		DeepPink = FromRgba(byte.MaxValue, 20, 147, byte.MaxValue);
		DeepSkyBlue = FromRgba(0, 191, byte.MaxValue, byte.MaxValue);
		DimGray = FromRgba(105, 105, 105, byte.MaxValue);
		DimGrey = DimGray;
		DodgerBlue = FromRgba(30, 144, byte.MaxValue, byte.MaxValue);
		Firebrick = FromRgba(178, 34, 34, byte.MaxValue);
		FloralWhite = FromRgba(byte.MaxValue, 250, 240, byte.MaxValue);
		ForestGreen = FromRgba(34, 139, 34, byte.MaxValue);
		Fuchsia = FromRgba(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
		Gainsboro = FromRgba(220, 220, 220, byte.MaxValue);
		GhostWhite = FromRgba(248, 248, byte.MaxValue, byte.MaxValue);
		Gold = FromRgba(byte.MaxValue, 215, 0, byte.MaxValue);
		Goldenrod = FromRgba(218, 165, 32, byte.MaxValue);
		Gray = FromRgba(128, 128, 128, byte.MaxValue);
		Green = FromRgba(0, 128, 0, byte.MaxValue);
		GreenYellow = FromRgba(173, byte.MaxValue, 47, byte.MaxValue);
		Grey = Gray;
		Honeydew = FromRgba(240, byte.MaxValue, 240, byte.MaxValue);
		HotPink = FromRgba(byte.MaxValue, 105, 180, byte.MaxValue);
		IndianRed = FromRgba(205, 92, 92, byte.MaxValue);
		Indigo = FromRgba(75, 0, 130, byte.MaxValue);
		Ivory = FromRgba(byte.MaxValue, byte.MaxValue, 240, byte.MaxValue);
		Khaki = FromRgba(240, 230, 140, byte.MaxValue);
		Lavender = FromRgba(230, 230, 250, byte.MaxValue);
		LavenderBlush = FromRgba(byte.MaxValue, 240, 245, byte.MaxValue);
		LawnGreen = FromRgba(124, 252, 0, byte.MaxValue);
		LemonChiffon = FromRgba(byte.MaxValue, 250, 205, byte.MaxValue);
		LightBlue = FromRgba(173, 216, 230, byte.MaxValue);
		LightCoral = FromRgba(240, 128, 128, byte.MaxValue);
		LightCyan = FromRgba(224, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		LightGoldenrodYellow = FromRgba(250, 250, 210, byte.MaxValue);
		LightGray = FromRgba(211, 211, 211, byte.MaxValue);
		LightGreen = FromRgba(144, 238, 144, byte.MaxValue);
		LightGrey = LightGray;
		LightPink = FromRgba(byte.MaxValue, 182, 193, byte.MaxValue);
		LightSalmon = FromRgba(byte.MaxValue, 160, 122, byte.MaxValue);
		LightSeaGreen = FromRgba(32, 178, 170, byte.MaxValue);
		LightSkyBlue = FromRgba(135, 206, 250, byte.MaxValue);
		LightSlateGray = FromRgba(119, 136, 153, byte.MaxValue);
		LightSlateGrey = LightSlateGray;
		LightSteelBlue = FromRgba(176, 196, 222, byte.MaxValue);
		LightYellow = FromRgba(byte.MaxValue, byte.MaxValue, 224, byte.MaxValue);
		Lime = FromRgba(0, byte.MaxValue, 0, byte.MaxValue);
		LimeGreen = FromRgba(50, 205, 50, byte.MaxValue);
		Linen = FromRgba(250, 240, 230, byte.MaxValue);
		Magenta = Fuchsia;
		Maroon = FromRgba(128, 0, 0, byte.MaxValue);
		MediumAquamarine = FromRgba(102, 205, 170, byte.MaxValue);
		MediumBlue = FromRgba(0, 0, 205, byte.MaxValue);
		MediumOrchid = FromRgba(186, 85, 211, byte.MaxValue);
		MediumPurple = FromRgba(147, 112, 219, byte.MaxValue);
		MediumSeaGreen = FromRgba(60, 179, 113, byte.MaxValue);
		MediumSlateBlue = FromRgba(123, 104, 238, byte.MaxValue);
		MediumSpringGreen = FromRgba(0, 250, 154, byte.MaxValue);
		MediumTurquoise = FromRgba(72, 209, 204, byte.MaxValue);
		MediumVioletRed = FromRgba(199, 21, 133, byte.MaxValue);
		MidnightBlue = FromRgba(25, 25, 112, byte.MaxValue);
		MintCream = FromRgba(245, byte.MaxValue, 250, byte.MaxValue);
		MistyRose = FromRgba(byte.MaxValue, 228, 225, byte.MaxValue);
		Moccasin = FromRgba(byte.MaxValue, 228, 181, byte.MaxValue);
		NavajoWhite = FromRgba(byte.MaxValue, 222, 173, byte.MaxValue);
		Navy = FromRgba(0, 0, 128, byte.MaxValue);
		OldLace = FromRgba(253, 245, 230, byte.MaxValue);
		Olive = FromRgba(128, 128, 0, byte.MaxValue);
		OliveDrab = FromRgba(107, 142, 35, byte.MaxValue);
		Orange = FromRgba(byte.MaxValue, 165, 0, byte.MaxValue);
		OrangeRed = FromRgba(byte.MaxValue, 69, 0, byte.MaxValue);
		Orchid = FromRgba(218, 112, 214, byte.MaxValue);
		PaleGoldenrod = FromRgba(238, 232, 170, byte.MaxValue);
		PaleGreen = FromRgba(152, 251, 152, byte.MaxValue);
		PaleTurquoise = FromRgba(175, 238, 238, byte.MaxValue);
		PaleVioletRed = FromRgba(219, 112, 147, byte.MaxValue);
		PapayaWhip = FromRgba(byte.MaxValue, 239, 213, byte.MaxValue);
		PeachPuff = FromRgba(byte.MaxValue, 218, 185, byte.MaxValue);
		Peru = FromRgba(205, 133, 63, byte.MaxValue);
		Pink = FromRgba(byte.MaxValue, 192, 203, byte.MaxValue);
		Plum = FromRgba(221, 160, 221, byte.MaxValue);
		PowderBlue = FromRgba(176, 224, 230, byte.MaxValue);
		Purple = FromRgba(128, 0, 128, byte.MaxValue);
		RebeccaPurple = FromRgba(102, 51, 153, byte.MaxValue);
		Red = FromRgba(byte.MaxValue, 0, 0, byte.MaxValue);
		RosyBrown = FromRgba(188, 143, 143, byte.MaxValue);
		RoyalBlue = FromRgba(65, 105, 225, byte.MaxValue);
		SaddleBrown = FromRgba(139, 69, 19, byte.MaxValue);
		Salmon = FromRgba(250, 128, 114, byte.MaxValue);
		SandyBrown = FromRgba(244, 164, 96, byte.MaxValue);
		SeaGreen = FromRgba(46, 139, 87, byte.MaxValue);
		SeaShell = FromRgba(byte.MaxValue, 245, 238, byte.MaxValue);
		Sienna = FromRgba(160, 82, 45, byte.MaxValue);
		Silver = FromRgba(192, 192, 192, byte.MaxValue);
		SkyBlue = FromRgba(135, 206, 235, byte.MaxValue);
		SlateBlue = FromRgba(106, 90, 205, byte.MaxValue);
		SlateGray = FromRgba(112, 128, 144, byte.MaxValue);
		SlateGrey = SlateGray;
		Snow = FromRgba(byte.MaxValue, 250, 250, byte.MaxValue);
		SpringGreen = FromRgba(0, byte.MaxValue, 127, byte.MaxValue);
		SteelBlue = FromRgba(70, 130, 180, byte.MaxValue);
		Tan = FromRgba(210, 180, 140, byte.MaxValue);
		Teal = FromRgba(0, 128, 128, byte.MaxValue);
		Thistle = FromRgba(216, 191, 216, byte.MaxValue);
		Tomato = FromRgba(byte.MaxValue, 99, 71, byte.MaxValue);
		Transparent = FromRgba(0, 0, 0, 0);
		Turquoise = FromRgba(64, 224, 208, byte.MaxValue);
		Violet = FromRgba(238, 130, 238, byte.MaxValue);
		Wheat = FromRgba(245, 222, 179, byte.MaxValue);
		White = FromRgba(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		WhiteSmoke = FromRgba(245, 245, 245, byte.MaxValue);
		Yellow = FromRgba(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
		YellowGreen = FromRgba(154, 205, 50, byte.MaxValue);
		WebSafePaletteLazy = new Lazy<Color[]>(CreateWebSafePalette, isThreadSafe: true);
		WernerPaletteLazy = new Lazy<Color[]>(CreateWernerPalette, isThreadSafe: true);
	}
}
