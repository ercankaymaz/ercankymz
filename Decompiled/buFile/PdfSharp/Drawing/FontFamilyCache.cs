using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

internal sealed class FontFamilyCache
{
	private static volatile FontFamilyCache _singleton;

	private readonly Dictionary<string, FontFamilyInternal> _familiesByName;

	private static FontFamilyCache Singleton
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
						_singleton = new FontFamilyCache();
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

	private FontFamilyCache()
	{
		_familiesByName = new Dictionary<string, FontFamilyInternal>(StringComparer.OrdinalIgnoreCase);
	}

	public static FontFamilyInternal GetFamilyByName(string familyName)
	{
		try
		{
			Lock.EnterFontFactory();
			Singleton._familiesByName.TryGetValue(familyName, out var value);
			return value;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static FontFamilyInternal CacheOrGetFontFamily(FontFamilyInternal fontFamily)
	{
		try
		{
			Lock.EnterFontFactory();
			if (Singleton._familiesByName.TryGetValue(fontFamily.Name, out var value))
			{
				return value;
			}
			Singleton._familiesByName.Add(fontFamily.Name, fontFamily);
			return fontFamily;
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
		stringBuilder.Append("Font families by name\n");
		Dictionary<string, FontFamilyInternal>.KeyCollection keys = Singleton._familiesByName.Keys;
		int count = keys.Count;
		string[] array = new string[count];
		keys.CopyTo(array, 0);
		Array.Sort(array, StringComparer.OrdinalIgnoreCase);
		string[] array2 = array;
		foreach (string text in array2)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", text, Singleton._familiesByName[text].DebuggerDisplay);
		}
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}
}
