using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace PdfSharp.Drawing;

public class XColorResourceManager
{
	internal struct ColorResourceInfo(XKnownColor knownColor, XColor color, uint argb, string name, string nameDE)
	{
		public XKnownColor KnownColor = knownColor;

		public XColor Color = color;

		public uint Argb = argb;

		public string Name = name;

		public string NameDE = nameDE;
	}

	private readonly CultureInfo _cultureInfo;

	internal static ColorResourceInfo[] colorInfos = new ColorResourceInfo[139]
	{
		new ColorResourceInfo(XKnownColor.Transparent, XColors.Transparent, 16777215u, "Transparent", "Transparent"),
		new ColorResourceInfo(XKnownColor.Black, XColors.Black, 4278190080u, "Black", "Schwarz"),
		new ColorResourceInfo(XKnownColor.DarkSlateGray, XColors.DarkSlateGray, 4287609999u, "Darkslategray", "Dunkles Schiefergrau"),
		new ColorResourceInfo(XKnownColor.SlateGray, XColors.SlateGray, 4285563024u, "Slategray", "Schiefergrau"),
		new ColorResourceInfo(XKnownColor.LightSlateGray, XColors.LightSlateGray, 4286023833u, "Lightslategray", "Helles Schiefergrau"),
		new ColorResourceInfo(XKnownColor.LightSteelBlue, XColors.LightSteelBlue, 4289774814u, "Lightsteelblue", "Helles Stahlblau"),
		new ColorResourceInfo(XKnownColor.DimGray, XColors.DimGray, 4285098345u, "Dimgray", "Gedecktes Grau"),
		new ColorResourceInfo(XKnownColor.Gray, XColors.Gray, 4286611584u, "Gray", "Grau"),
		new ColorResourceInfo(XKnownColor.DarkGray, XColors.DarkGray, 4289309097u, "Darkgray", "Dunkelgrau"),
		new ColorResourceInfo(XKnownColor.Silver, XColors.Silver, 4290822336u, "Silver", "Silber"),
		new ColorResourceInfo(XKnownColor.Gainsboro, XColors.Gainsboro, 4292664540u, "Gainsboro", "Helles Blaugrau"),
		new ColorResourceInfo(XKnownColor.WhiteSmoke, XColors.WhiteSmoke, 4294309365u, "Whitesmoke", "Rauchweiß"),
		new ColorResourceInfo(XKnownColor.GhostWhite, XColors.GhostWhite, 4294506751u, "Ghostwhite", "Schattenweiß"),
		new ColorResourceInfo(XKnownColor.White, XColors.White, uint.MaxValue, "White", "Weiß"),
		new ColorResourceInfo(XKnownColor.Snow, XColors.Snow, 4294966010u, "Snow", "Schneeweiß"),
		new ColorResourceInfo(XKnownColor.Ivory, XColors.Ivory, 4294967280u, "Ivory", "Elfenbein"),
		new ColorResourceInfo(XKnownColor.FloralWhite, XColors.FloralWhite, 4294966000u, "Floralwhite", "Blütenweiß"),
		new ColorResourceInfo(XKnownColor.SeaShell, XColors.SeaShell, 4294964718u, "Seashell", "Muschel"),
		new ColorResourceInfo(XKnownColor.OldLace, XColors.OldLace, 4294833638u, "Oldlace", "Altweiß"),
		new ColorResourceInfo(XKnownColor.Linen, XColors.Linen, 4294635750u, "Linen", "Leinen"),
		new ColorResourceInfo(XKnownColor.AntiqueWhite, XColors.AntiqueWhite, 4294634455u, "Antiquewhite", "Antikes Weiß"),
		new ColorResourceInfo(XKnownColor.BlanchedAlmond, XColors.BlanchedAlmond, 4294962125u, "Blanchedalmond", "Mandelweiß"),
		new ColorResourceInfo(XKnownColor.PapayaWhip, XColors.PapayaWhip, 4294963157u, "Papayawhip", "Papayacreme"),
		new ColorResourceInfo(XKnownColor.Beige, XColors.Beige, 4294309340u, "Beige", "Beige"),
		new ColorResourceInfo(XKnownColor.Cornsilk, XColors.Cornsilk, 4294965468u, "Cornsilk", "Mais"),
		new ColorResourceInfo(XKnownColor.LightGoldenrodYellow, XColors.LightGoldenrodYellow, 4294638290u, "Lightgoldenrodyellow", "Helles Goldgelb"),
		new ColorResourceInfo(XKnownColor.LightYellow, XColors.LightYellow, 4294967264u, "Lightyellow", "Hellgelb"),
		new ColorResourceInfo(XKnownColor.LemonChiffon, XColors.LemonChiffon, 4294965965u, "Lemonchiffon", "Pastellgelb"),
		new ColorResourceInfo(XKnownColor.PaleGoldenrod, XColors.PaleGoldenrod, 4293847210u, "Palegoldenrod", "Blasses Goldgelb"),
		new ColorResourceInfo(XKnownColor.Khaki, XColors.Khaki, 4293977740u, "Khaki", "Khaki"),
		new ColorResourceInfo(XKnownColor.Yellow, XColors.Yellow, 4294967040u, "Yellow", "Gelb"),
		new ColorResourceInfo(XKnownColor.Gold, XColors.Gold, 4294956800u, "Gold", "Gold"),
		new ColorResourceInfo(XKnownColor.Orange, XColors.Orange, 4294944000u, "Orange", "Orange"),
		new ColorResourceInfo(XKnownColor.DarkOrange, XColors.DarkOrange, 4294937600u, "Darkorange", "Dunkles Orange"),
		new ColorResourceInfo(XKnownColor.Goldenrod, XColors.Goldenrod, 4292519200u, "Goldenrod", "Goldgelb"),
		new ColorResourceInfo(XKnownColor.DarkGoldenrod, XColors.DarkGoldenrod, 4290283019u, "Darkgoldenrod", "Dunkles Goldgelb"),
		new ColorResourceInfo(XKnownColor.Peru, XColors.Peru, 4291659071u, "Peru", "Peru"),
		new ColorResourceInfo(XKnownColor.Chocolate, XColors.Chocolate, 4291979550u, "Chocolate", "Schokolade"),
		new ColorResourceInfo(XKnownColor.SaddleBrown, XColors.SaddleBrown, 4287317267u, "Saddlebrown", "Sattelbraun"),
		new ColorResourceInfo(XKnownColor.Sienna, XColors.Sienna, 4288696877u, "Sienna", "Ocker"),
		new ColorResourceInfo(XKnownColor.Brown, XColors.Brown, 4289014314u, "Brown", "Braun"),
		new ColorResourceInfo(XKnownColor.DarkRed, XColors.DarkRed, 4287299584u, "Darkred", "Dunkelrot"),
		new ColorResourceInfo(XKnownColor.Maroon, XColors.Maroon, 4286578688u, "Maroon", "Kastanienbraun"),
		new ColorResourceInfo(XKnownColor.PaleTurquoise, XColors.PaleTurquoise, 4289720046u, "Paleturquoise", "Blasses Türkis"),
		new ColorResourceInfo(XKnownColor.Firebrick, XColors.Firebrick, 4289864226u, "Firebrick", "Ziegel"),
		new ColorResourceInfo(XKnownColor.IndianRed, XColors.IndianRed, 4291648604u, "Indianred", "Indischrot"),
		new ColorResourceInfo(XKnownColor.Crimson, XColors.Crimson, 4292613180u, "Crimson", "Karmesinrot"),
		new ColorResourceInfo(XKnownColor.Red, XColors.Red, 4294901760u, "Red", "Rot"),
		new ColorResourceInfo(XKnownColor.OrangeRed, XColors.OrangeRed, 4294919424u, "Orangered", "Orangerot"),
		new ColorResourceInfo(XKnownColor.Tomato, XColors.Tomato, 4294927175u, "Tomato", "Tomate"),
		new ColorResourceInfo(XKnownColor.Coral, XColors.Coral, 4294934352u, "Coral", "Koralle"),
		new ColorResourceInfo(XKnownColor.Salmon, XColors.Salmon, 4294606962u, "Salmon", "Lachs"),
		new ColorResourceInfo(XKnownColor.LightCoral, XColors.LightCoral, 4293951616u, "Lightcoral", "Helles Korallenrot"),
		new ColorResourceInfo(XKnownColor.DarkSalmon, XColors.DarkSalmon, 4293498490u, "Darksalmon", "Dunkles Lachs"),
		new ColorResourceInfo(XKnownColor.LightSalmon, XColors.LightSalmon, 4294942842u, "Lightsalmon", "Helles Lachs"),
		new ColorResourceInfo(XKnownColor.SandyBrown, XColors.SandyBrown, 4294222944u, "Sandybrown", "Sandbraun"),
		new ColorResourceInfo(XKnownColor.RosyBrown, XColors.RosyBrown, 4290547599u, "Rosybrown", "Rotbraun"),
		new ColorResourceInfo(XKnownColor.Tan, XColors.Tan, 4291998860u, "Tan", "Gelbbraun"),
		new ColorResourceInfo(XKnownColor.BurlyWood, XColors.BurlyWood, 4292786311u, "Burlywood", "Kräftiges Sandbraun"),
		new ColorResourceInfo(XKnownColor.Wheat, XColors.Wheat, 4294303411u, "Wheat", "Weizen"),
		new ColorResourceInfo(XKnownColor.PeachPuff, XColors.PeachPuff, 4294957753u, "Peachpuff", "Pfirsich"),
		new ColorResourceInfo(XKnownColor.NavajoWhite, XColors.NavajoWhite, 4294958765u, "Navajowhite", "Orangeweiß"),
		new ColorResourceInfo(XKnownColor.Bisque, XColors.Bisque, 4294960324u, "Bisque", "Blasses Rotbraun"),
		new ColorResourceInfo(XKnownColor.Moccasin, XColors.Moccasin, 4294960309u, "Moccasin", "Mokassin"),
		new ColorResourceInfo(XKnownColor.LavenderBlush, XColors.LavenderBlush, 4294963445u, "Lavenderblush", "Roter Lavendel"),
		new ColorResourceInfo(XKnownColor.MistyRose, XColors.MistyRose, 4294960353u, "Mistyrose", "Altrosa"),
		new ColorResourceInfo(XKnownColor.Pink, XColors.Pink, 4294951115u, "Pink", "Rosa"),
		new ColorResourceInfo(XKnownColor.LightPink, XColors.LightPink, 4294948545u, "Lightpink", "Hellrosa"),
		new ColorResourceInfo(XKnownColor.HotPink, XColors.HotPink, 4294928820u, "Hotpink", "Leuchtendes Rosa"),
		new ColorResourceInfo(XKnownColor.Magenta, XColors.Magenta, 4294902015u, "Magenta", "Magentarot"),
		new ColorResourceInfo(XKnownColor.DeepPink, XColors.DeepPink, 4294907027u, "Deeppink", "Tiefrosa"),
		new ColorResourceInfo(XKnownColor.MediumVioletRed, XColors.MediumVioletRed, 4291237253u, "Mediumvioletred", "Mittleres Violettrot"),
		new ColorResourceInfo(XKnownColor.PaleVioletRed, XColors.PaleVioletRed, 4292571283u, "Palevioletred", "Blasses Violettrot"),
		new ColorResourceInfo(XKnownColor.Plum, XColors.Plum, 4292714717u, "Plum", "Pflaume"),
		new ColorResourceInfo(XKnownColor.Thistle, XColors.Thistle, 4292394968u, "Thistle", "Distel"),
		new ColorResourceInfo(XKnownColor.Lavender, XColors.Lavender, 4293322490u, "Lavender", "Lavendel"),
		new ColorResourceInfo(XKnownColor.Violet, XColors.Violet, 4293821166u, "Violet", "Violett"),
		new ColorResourceInfo(XKnownColor.Orchid, XColors.Orchid, 4292505814u, "Orchid", "Orchidee"),
		new ColorResourceInfo(XKnownColor.DarkMagenta, XColors.DarkMagenta, 4287299723u, "Darkmagenta", "Dunkles Magentarot"),
		new ColorResourceInfo(XKnownColor.Purple, XColors.Purple, 4286578816u, "Purple", "Violett"),
		new ColorResourceInfo(XKnownColor.Indigo, XColors.Indigo, 4283105410u, "Indigo", "Indigo"),
		new ColorResourceInfo(XKnownColor.BlueViolet, XColors.BlueViolet, 4287245282u, "Blueviolet", "Blauviolett"),
		new ColorResourceInfo(XKnownColor.DarkViolet, XColors.DarkViolet, 4287889619u, "Darkviolet", "Dunkles Violett"),
		new ColorResourceInfo(XKnownColor.DarkOrchid, XColors.DarkOrchid, 4288230092u, "Darkorchid", "Dunkle Orchidee"),
		new ColorResourceInfo(XKnownColor.MediumPurple, XColors.MediumPurple, 4287852763u, "Mediumpurple", "Mittleres Violett"),
		new ColorResourceInfo(XKnownColor.MediumOrchid, XColors.MediumOrchid, 4290401747u, "Mediumorchid", "Mittlere Orchidee"),
		new ColorResourceInfo(XKnownColor.MediumSlateBlue, XColors.MediumSlateBlue, 4286277870u, "Mediumslateblue", "Mittleres Schieferblau"),
		new ColorResourceInfo(XKnownColor.SlateBlue, XColors.SlateBlue, 4285160141u, "Slateblue", "Schieferblau"),
		new ColorResourceInfo(XKnownColor.DarkSlateBlue, XColors.DarkSlateBlue, 4282924427u, "Darkslateblue", "Dunkles Schiefergrau"),
		new ColorResourceInfo(XKnownColor.MidnightBlue, XColors.MidnightBlue, 4279834992u, "Midnightblue", "Mitternachtsblau"),
		new ColorResourceInfo(XKnownColor.Navy, XColors.Navy, 4278190208u, "Navy", "Marineblau"),
		new ColorResourceInfo(XKnownColor.DarkBlue, XColors.DarkBlue, 4278190219u, "Darkblue", "Dunkelblau"),
		new ColorResourceInfo(XKnownColor.LightGray, XColors.LightGray, 4292072403u, "Lightgray", "Hellgrau"),
		new ColorResourceInfo(XKnownColor.MediumBlue, XColors.MediumBlue, 4278190285u, "Mediumblue", "Mittelblau"),
		new ColorResourceInfo(XKnownColor.Blue, XColors.Blue, 4278190335u, "Blue", "Blau"),
		new ColorResourceInfo(XKnownColor.RoyalBlue, XColors.RoyalBlue, 4282477025u, "Royalblue", "Königsblau"),
		new ColorResourceInfo(XKnownColor.SteelBlue, XColors.SteelBlue, 4282811060u, "Steelblue", "Stahlblau"),
		new ColorResourceInfo(XKnownColor.CornflowerBlue, XColors.CornflowerBlue, 4284782061u, "Cornflowerblue", "Kornblumenblau"),
		new ColorResourceInfo(XKnownColor.DodgerBlue, XColors.DodgerBlue, 4280193279u, "Dodgerblue", "Dodger-Blau"),
		new ColorResourceInfo(XKnownColor.DeepSkyBlue, XColors.DeepSkyBlue, 4278239231u, "Deepskyblue", "Tiefes Himmelblau"),
		new ColorResourceInfo(XKnownColor.LightSkyBlue, XColors.LightSkyBlue, 4287090426u, "Lightskyblue", "Helles Himmelblau"),
		new ColorResourceInfo(XKnownColor.SkyBlue, XColors.SkyBlue, 4287090411u, "Skyblue", "Himmelblau"),
		new ColorResourceInfo(XKnownColor.LightBlue, XColors.LightBlue, 4289583334u, "Lightblue", "Hellblau"),
		new ColorResourceInfo(XKnownColor.Cyan, XColors.Cyan, 4278255615u, "Cyan", "Zyan"),
		new ColorResourceInfo(XKnownColor.PowderBlue, XColors.PowderBlue, 4289781990u, "Powderblue", "Taubenblau"),
		new ColorResourceInfo(XKnownColor.LightCyan, XColors.LightCyan, 4292935679u, "Lightcyan", "Helles Cyanblau"),
		new ColorResourceInfo(XKnownColor.AliceBlue, XColors.AliceBlue, 4288728576u, "Aliceblue", "Aliceblau"),
		new ColorResourceInfo(XKnownColor.Azure, XColors.Azure, 4293984255u, "Azure", "Himmelblau"),
		new ColorResourceInfo(XKnownColor.MintCream, XColors.MintCream, 4294311930u, "Mintcream", "Helles Pfefferminzgrün"),
		new ColorResourceInfo(XKnownColor.Honeydew, XColors.Honeydew, 4293984240u, "Honeydew", "Honigmelone"),
		new ColorResourceInfo(XKnownColor.Aquamarine, XColors.Aquamarine, 4286578644u, "Aquamarine", "Aquamarinblau"),
		new ColorResourceInfo(XKnownColor.Turquoise, XColors.Turquoise, 4282441936u, "Turquoise", "Türkis"),
		new ColorResourceInfo(XKnownColor.MediumTurquoise, XColors.MediumTurquoise, 4282962380u, "Mediumturqoise", "Mittleres Türkis"),
		new ColorResourceInfo(XKnownColor.DarkTurquoise, XColors.DarkTurquoise, 4278243025u, "Darkturquoise", "Dunkles Türkis"),
		new ColorResourceInfo(XKnownColor.MediumAquamarine, XColors.MediumAquamarine, 4284927402u, "Mediumaquamarine", "Mittleres Aquamarinblau"),
		new ColorResourceInfo(XKnownColor.LightSeaGreen, XColors.LightSeaGreen, 4280332970u, "Lightseagreen", "Helles Seegrün"),
		new ColorResourceInfo(XKnownColor.DarkCyan, XColors.DarkCyan, 4278225803u, "Darkcyan", "Dunkles Zyanblau"),
		new ColorResourceInfo(XKnownColor.Teal, XColors.Teal, 4278222976u, "Teal", "Entenblau"),
		new ColorResourceInfo(XKnownColor.CadetBlue, XColors.CadetBlue, 4284456608u, "Cadetblue", "Kadettblau"),
		new ColorResourceInfo(XKnownColor.MediumSeaGreen, XColors.MediumSeaGreen, 4282168177u, "Mediumseagreen", "Mittleres Seegrün"),
		new ColorResourceInfo(XKnownColor.DarkSeaGreen, XColors.DarkSeaGreen, 4287609999u, "Darkseagreen", "Dunkles Seegrün"),
		new ColorResourceInfo(XKnownColor.LightGreen, XColors.LightGreen, 4287688336u, "Lightgreen", "Hellgrün"),
		new ColorResourceInfo(XKnownColor.PaleGreen, XColors.PaleGreen, 4288215960u, "Palegreen", "Blassgrün"),
		new ColorResourceInfo(XKnownColor.MediumSpringGreen, XColors.MediumSpringGreen, 4278254234u, "Mediumspringgreen", "Mittleres Frühlingsgrün"),
		new ColorResourceInfo(XKnownColor.SpringGreen, XColors.SpringGreen, 4278255487u, "Springgreen", "Frühlingsgrün"),
		new ColorResourceInfo(XKnownColor.Lime, XColors.Lime, 4278255360u, "Lime", "Zitronengrün"),
		new ColorResourceInfo(XKnownColor.LimeGreen, XColors.LimeGreen, 4281519410u, "Limegreen", "Gelbgrün"),
		new ColorResourceInfo(XKnownColor.SeaGreen, XColors.SeaGreen, 4281240407u, "Seagreen", "Seegrün"),
		new ColorResourceInfo(XKnownColor.ForestGreen, XColors.ForestGreen, 4280453922u, "Forestgreen", "Waldgrün"),
		new ColorResourceInfo(XKnownColor.Green, XColors.Green, 4278222848u, "Green", "Grün"),
		new ColorResourceInfo(XKnownColor.LawnGreen, XColors.LawnGreen, 4278222848u, "LawnGreen", "Grasgrün"),
		new ColorResourceInfo(XKnownColor.DarkGreen, XColors.DarkGreen, 4278215680u, "Darkgreen", "Dunkelgrün"),
		new ColorResourceInfo(XKnownColor.OliveDrab, XColors.OliveDrab, 4285238819u, "Olivedrab", "Reife Olive"),
		new ColorResourceInfo(XKnownColor.DarkOliveGreen, XColors.DarkOliveGreen, 4283788079u, "Darkolivegreen", "Dunkles Olivgrün"),
		new ColorResourceInfo(XKnownColor.Olive, XColors.Olive, 4286611456u, "Olive", "Olivgrün"),
		new ColorResourceInfo(XKnownColor.DarkKhaki, XColors.DarkKhaki, 4290623339u, "Darkkhaki", "Dunkles Khaki"),
		new ColorResourceInfo(XKnownColor.YellowGreen, XColors.YellowGreen, 4288335154u, "Yellowgreen", "Gelbgrün"),
		new ColorResourceInfo(XKnownColor.Chartreuse, XColors.Chartreuse, 4286578432u, "Chartreuse", "Hellgrün"),
		new ColorResourceInfo(XKnownColor.GreenYellow, XColors.GreenYellow, 4289593135u, "Greenyellow", "Grüngelb")
	};

	public XColorResourceManager()
		: this(Thread.CurrentThread.CurrentUICulture)
	{
	}

	public XColorResourceManager(CultureInfo cultureInfo)
	{
		_cultureInfo = cultureInfo;
	}

	public static XKnownColor GetKnownColor(uint argb)
	{
		XKnownColor knownColor = XKnownColorTable.GetKnownColor(argb);
		if (knownColor == (XKnownColor)(-1))
		{
			throw new ArgumentException("The argument is not a known color", "argb");
		}
		return knownColor;
	}

	public static XKnownColor[] GetKnownColors(bool includeTransparent)
	{
		int num = colorInfos.Length;
		XKnownColor[] array = new XKnownColor[num - ((!includeTransparent) ? 1 : 0)];
		int num2 = ((!includeTransparent) ? 1 : 0);
		int num3 = 0;
		while (num2 < num)
		{
			array[num3] = colorInfos[num2].KnownColor;
			num2++;
			num3++;
		}
		return array;
	}

	public string ToColorName(XKnownColor knownColor)
	{
		ColorResourceInfo colorInfo = GetColorInfo(knownColor);
		if (_cultureInfo.TwoLetterISOLanguageName == "de")
		{
			return colorInfo.NameDE;
		}
		return colorInfo.Name;
	}

	public string ToColorName(XColor color)
	{
		if (color.IsKnownColor)
		{
			return ToColorName(XKnownColorTable.GetKnownColor(color.Argb));
		}
		return $"{(int)(255.0 * color.A)}, {color.R}, {color.G}, {color.B}";
	}

	private static ColorResourceInfo GetColorInfo(XKnownColor knownColor)
	{
		for (int i = 0; i < colorInfos.Length; i++)
		{
			ColorResourceInfo result = colorInfos[i];
			if (result.KnownColor == knownColor)
			{
				return result;
			}
		}
		throw new InvalidEnumArgumentException("Enum is not an XKnownColor.");
	}
}
