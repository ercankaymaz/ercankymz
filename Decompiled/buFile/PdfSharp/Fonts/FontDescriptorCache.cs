using System;
using System.Collections.Generic;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Fonts;

internal sealed class FontDescriptorCache
{
	private static volatile FontDescriptorCache _singleton;

	private readonly Dictionary<string, FontDescriptor> _cache;

	private static FontDescriptorCache Singleton
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
						_singleton = new FontDescriptorCache();
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

	private FontDescriptorCache()
	{
		_cache = new Dictionary<string, FontDescriptor>();
	}

	public static FontDescriptor GetOrCreateDescriptorFor(XFont font)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		string text = FontDescriptor.ComputeKey(font);
		try
		{
			Lock.EnterFontFactory();
			if (!Singleton._cache.TryGetValue(text, out var value))
			{
				value = new OpenTypeDescriptor(text, font);
				Singleton._cache.Add(text, value);
			}
			return value;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static FontDescriptor GetOrCreateDescriptor(string fontFamilyName, XFontStyle style)
	{
		if (string.IsNullOrEmpty(fontFamilyName))
		{
			throw new ArgumentNullException("fontFamilyName");
		}
		string key = FontDescriptor.ComputeKey(fontFamilyName, style);
		try
		{
			Lock.EnterFontFactory();
			if (!Singleton._cache.TryGetValue(key, out var value))
			{
				XFont font = new XFont(fontFamilyName, 10.0, style);
				value = GetOrCreateDescriptorFor(font);
				if (Singleton._cache.ContainsKey(key))
				{
					Singleton.GetType();
				}
				else
				{
					Singleton._cache.Add(key, value);
				}
			}
			return value;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static FontDescriptor GetOrCreateDescriptor(string idName, byte[] fontData)
	{
		string text = FontDescriptor.ComputeKey(idName);
		try
		{
			Lock.EnterFontFactory();
			if (!Singleton._cache.TryGetValue(text, out var value))
			{
				value = GetOrCreateOpenTypeDescriptor(text, idName, fontData);
				Singleton._cache.Add(text, value);
			}
			return value;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	private static OpenTypeDescriptor GetOrCreateOpenTypeDescriptor(string fontDescriptorKey, string idName, byte[] fontData)
	{
		return new OpenTypeDescriptor(fontDescriptorKey, idName, fontData);
	}
}
