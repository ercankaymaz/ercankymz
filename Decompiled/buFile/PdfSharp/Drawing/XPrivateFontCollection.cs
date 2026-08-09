using System;
using System.Collections.Generic;
using System.IO;

namespace PdfSharp.Drawing;

public sealed class XPrivateFontCollection
{
	internal static XPrivateFontCollection _singleton = new XPrivateFontCollection();

	private readonly Dictionary<string, XGlyphTypeface> _typefaces = new Dictionary<string, XGlyphTypeface>();

	internal static XPrivateFontCollection Singleton => _singleton;

	private XPrivateFontCollection()
	{
	}

	[Obsolete("Use Add(Stream stream)")]
	public static void AddFont(string filename)
	{
		throw new NotImplementedException();
	}

	[Obsolete("Use Add(Stream stream)")]
	public static void AddFont(Stream stream, string facename)
	{
		throw new NotImplementedException();
	}

	private static string MakeKey(string familyName, XFontStyle style)
	{
		return MakeKey(familyName, (style & XFontStyle.Bold) != 0, (style & XFontStyle.Italic) != 0);
	}

	private static string MakeKey(string familyName, bool bold, bool italic)
	{
		return familyName + "#" + (bold ? "b" : "") + (italic ? "i" : "");
	}
}
