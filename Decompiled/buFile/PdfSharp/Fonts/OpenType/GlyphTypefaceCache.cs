#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Internal;

namespace PdfSharp.Fonts.OpenType;

internal class GlyphTypefaceCache
{
	private static volatile GlyphTypefaceCache _singleton;

	private readonly Dictionary<string, XGlyphTypeface> _glyphTypefacesByKey;

	private static GlyphTypefaceCache Singleton
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
						_singleton = new GlyphTypefaceCache();
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

	private GlyphTypefaceCache()
	{
		_glyphTypefacesByKey = new Dictionary<string, XGlyphTypeface>();
	}

	public static bool TryGetGlyphTypeface(string key, out XGlyphTypeface glyphTypeface)
	{
		try
		{
			Lock.EnterFontFactory();
			return Singleton._glyphTypefacesByKey.TryGetValue(key, out glyphTypeface);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static void AddGlyphTypeface(XGlyphTypeface glyphTypeface)
	{
		try
		{
			Lock.EnterFontFactory();
			GlyphTypefaceCache singleton = Singleton;
			Debug.Assert(!singleton._glyphTypefacesByKey.ContainsKey(glyphTypeface.Key));
			singleton._glyphTypefacesByKey.Add(glyphTypeface.Key, glyphTypeface);
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
		stringBuilder.Append("Glyph typefaces by name\n");
		Dictionary<string, XGlyphTypeface>.KeyCollection keys = Singleton._glyphTypefacesByKey.Keys;
		int count = keys.Count;
		string[] array = new string[count];
		keys.CopyTo(array, 0);
		Array.Sort(array, StringComparer.OrdinalIgnoreCase);
		string[] array2 = array;
		foreach (string text in array2)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", text, Singleton._glyphTypefacesByKey[text].DebuggerDisplay);
		}
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}
}
