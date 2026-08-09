using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Fonts.OpenType;

[DebuggerDisplay("{DebuggerDisplay}")]
internal class OpenTypeFontfaceCache
{
	private static volatile OpenTypeFontfaceCache _singleton;

	private readonly Dictionary<string, OpenTypeFontface> _fontfaceCache;

	private readonly Dictionary<ulong, OpenTypeFontface> _fontfacesByCheckSum;

	private static OpenTypeFontfaceCache Singleton
	{
		get
		{
			if (_singleton == null)
			{
				try
				{
					Lock.EnterFontFactory();
					if (_singleton == null)
					{
						_singleton = new OpenTypeFontfaceCache();
					}
				}
				finally
				{
					Lock.ExitFontFactory();
				}
			}
			return _singleton;
		}
	}

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "Fontfaces: {0}", _fontfaceCache.Count);

	private OpenTypeFontfaceCache()
	{
		_fontfaceCache = new Dictionary<string, OpenTypeFontface>(StringComparer.OrdinalIgnoreCase);
		_fontfacesByCheckSum = new Dictionary<ulong, OpenTypeFontface>();
	}

	public static bool TryGetFontface(string key, out OpenTypeFontface fontface)
	{
		try
		{
			Lock.EnterFontFactory();
			return Singleton._fontfaceCache.TryGetValue(key, out fontface);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static bool TryGetFontface(ulong checkSum, out OpenTypeFontface fontface)
	{
		try
		{
			Lock.EnterFontFactory();
			return Singleton._fontfacesByCheckSum.TryGetValue(checkSum, out fontface);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static OpenTypeFontface AddFontface(OpenTypeFontface fontface)
	{
		try
		{
			Lock.EnterFontFactory();
			if (TryGetFontface(fontface.FullFaceName, out var fontface2))
			{
				if (fontface2.CheckSum != fontface.CheckSum)
				{
					throw new InvalidOperationException("OpenTypeFontface with same signature but different bytes.");
				}
				return fontface2;
			}
			Singleton._fontfaceCache.Add(fontface.FullFaceName, fontface);
			Singleton._fontfacesByCheckSum.Add(fontface.CheckSum, fontface);
			return fontface;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	internal static string GetCacheState()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("====================\n");
		stringBuilder.Append("OpenType fontfaces by name\n");
		Dictionary<string, OpenTypeFontface>.KeyCollection keys = Singleton._fontfaceCache.Keys;
		int count = keys.Count;
		string[] array = new string[count];
		keys.CopyTo(array, 0);
		Array.Sort(array, StringComparer.OrdinalIgnoreCase);
		string[] array2 = array;
		foreach (string text in array2)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", text, Singleton._fontfaceCache[text].DebuggerDisplay);
		}
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}
}
