#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[DebuggerDisplay("{DebuggerDisplay}")]
internal class XFontSource
{
	private const uint ttcf = 1717793908u;

	private OpenTypeFontface _fontface;

	private ulong _key;

	private string _fontName;

	private readonly byte[] _bytes;

	internal OpenTypeFontface Fontface
	{
		get
		{
			return _fontface;
		}
		set
		{
			_fontface = value;
			_fontName = value.name.FullFontName;
		}
	}

	internal ulong Key
	{
		get
		{
			if (_key == 0)
			{
				_key = FontHelper.CalcChecksum(Bytes);
			}
			return _key;
		}
	}

	public string FontName => _fontName;

	public byte[] Bytes => _bytes;

	internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "XFontSource: '{0}', keyhash={1}", FontName, Key % 99991);

	private XFontSource(byte[] bytes, ulong key)
	{
		_fontName = null;
		_bytes = bytes;
		_key = key;
	}

	public static XFontSource GetOrCreateFrom(byte[] bytes)
	{
		ulong key = FontHelper.CalcChecksum(bytes);
		if (!FontFactory.TryGetFontSourceByKey(key, out var fontSource))
		{
			fontSource = new XFontSource(bytes, key);
			return FontFactory.CacheFontSource(fontSource);
		}
		return fontSource;
	}

	internal static XFontSource GetOrCreateFromGdi(string typefaceKey, Font gdiFont)
	{
		byte[] fontBytes = ReadFontBytesFromGdi(gdiFont);
		return GetOrCreateFrom(typefaceKey, fontBytes);
	}

	private static byte[] ReadFontBytesFromGdi(Font gdiFont)
	{
		int lastWin32Error = Marshal.GetLastWin32Error();
		lastWin32Error = Marshal.GetLastWin32Error();
		IntPtr hgdiobj = gdiFont.ToHfont();
		IntPtr dC = NativeMethods.GetDC(IntPtr.Zero);
		lastWin32Error = Marshal.GetLastWin32Error();
		IntPtr hgdiobj2 = NativeMethods.SelectObject(dC, hgdiobj);
		lastWin32Error = Marshal.GetLastWin32Error();
		bool flag = false;
		int fontData = NativeMethods.GetFontData(dC, 0u, 0u, null, 0);
		switch (fontData)
		{
		case -1073741790:
			throw new InvalidOperationException("Microsoft Azure returns STATUS_ACCESS_DENIED ((NTSTATUS)0xC0000022L) from GetFontData. This is a bug in Azure. You must implement a FontResolver to circumvent this issue.");
		case -1:
			fontData = NativeMethods.GetFontData(dC, 1717793908u, 0u, null, 0);
			flag = true;
			break;
		}
		lastWin32Error = Marshal.GetLastWin32Error();
		if (fontData == 0)
		{
			throw new InvalidOperationException("Cannot retrieve font data.");
		}
		byte[] array = new byte[fontData];
		int fontData2 = NativeMethods.GetFontData(dC, flag ? 1717793908u : 0u, 0u, array, fontData);
		Debug.Assert(fontData == fontData2);
		NativeMethods.SelectObject(dC, hgdiobj2);
		NativeMethods.ReleaseDC(IntPtr.Zero, dC);
		return array;
	}

	private static XFontSource GetOrCreateFrom(string typefaceKey, byte[] fontBytes)
	{
		ulong key = FontHelper.CalcChecksum(fontBytes);
		if (FontFactory.TryGetFontSourceByKey(key, out var fontSource))
		{
			FontFactory.CacheExistingFontSourceWithNewTypefaceKey(typefaceKey, fontSource);
		}
		else
		{
			fontSource = new XFontSource(fontBytes, key);
			FontFactory.CacheNewFontSource(typefaceKey, fontSource);
		}
		return fontSource;
	}

	public static XFontSource CreateCompiledFont(byte[] bytes)
	{
		return new XFontSource(bytes, 0uL);
	}

	public void IncrementKey()
	{
		_key += 4294967296uL;
	}

	public override int GetHashCode()
	{
		return (int)((Key >> 32) ^ Key);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is XFontSource xFontSource))
		{
			return false;
		}
		return Key == xFontSource.Key;
	}
}
