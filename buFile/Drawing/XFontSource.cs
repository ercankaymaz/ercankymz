// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XFontSource
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
internal class XFontSource
{
  private const uint ttcf = 1717793908;
  private OpenTypeFontface _fontface;
  private ulong _key;
  private string _fontName;
  private readonly byte[] _bytes;

  private XFontSource(byte[] bytes, ulong key)
  {
    this._fontName = (string) null;
    this._bytes = bytes;
    this._key = key;
  }

  public static XFontSource GetOrCreateFrom(byte[] bytes)
  {
    ulong key = FontHelper.CalcChecksum(bytes);
    XFontSource fontSource;
    if (!FontFactory.TryGetFontSourceByKey(key, out fontSource))
      fontSource = FontFactory.CacheFontSource(new XFontSource(bytes, key));
    return fontSource;
  }

  internal static XFontSource GetOrCreateFromGdi(string typefaceKey, Font gdiFont)
  {
    byte[] fontBytes = XFontSource.ReadFontBytesFromGdi(gdiFont);
    return XFontSource.GetOrCreateFrom(typefaceKey, fontBytes);
  }

  private static byte[] ReadFontBytesFromGdi(Font gdiFont)
  {
    Marshal.GetLastWin32Error();
    Marshal.GetLastWin32Error();
    IntPtr hfont = gdiFont.ToHfont();
    IntPtr dc = PdfSharp.Internal.NativeMethods.GetDC(IntPtr.Zero);
    Marshal.GetLastWin32Error();
    IntPtr hgdiobj = PdfSharp.Internal.NativeMethods.SelectObject(dc, hfont);
    Marshal.GetLastWin32Error();
    bool flag = false;
    int fontData1 = PdfSharp.Internal.NativeMethods.GetFontData(dc, 0U, 0U, (byte[]) null, 0);
    switch (fontData1)
    {
      case -1073741790 /*0xC0000022*/:
        throw new InvalidOperationException("Microsoft Azure returns STATUS_ACCESS_DENIED ((NTSTATUS)0xC0000022L) from GetFontData. This is a bug in Azure. You must implement a FontResolver to circumvent this issue.");
      case -1:
        fontData1 = PdfSharp.Internal.NativeMethods.GetFontData(dc, 1717793908U, 0U, (byte[]) null, 0);
        flag = true;
        break;
    }
    Marshal.GetLastWin32Error();
    byte[] lpvBuffer = fontData1 != 0 ? new byte[fontData1] : throw new InvalidOperationException("Cannot retrieve font data.");
    int fontData2 = PdfSharp.Internal.NativeMethods.GetFontData(dc, flag ? 1717793908U : 0U, 0U, lpvBuffer, fontData1);
    Debug.Assert(fontData1 == fontData2);
    PdfSharp.Internal.NativeMethods.SelectObject(dc, hgdiobj);
    PdfSharp.Internal.NativeMethods.ReleaseDC(IntPtr.Zero, dc);
    return lpvBuffer;
  }

  private static XFontSource GetOrCreateFrom(string typefaceKey, byte[] fontBytes)
  {
    ulong key = FontHelper.CalcChecksum(fontBytes);
    XFontSource fontSource;
    if (FontFactory.TryGetFontSourceByKey(key, out fontSource))
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

  public static XFontSource CreateCompiledFont(byte[] bytes) => new XFontSource(bytes, 0UL);

  internal OpenTypeFontface Fontface
  {
    get => this._fontface;
    set
    {
      this._fontface = value;
      this._fontName = value.name.FullFontName;
    }
  }

  internal ulong Key
  {
    get
    {
      if (this._key == 0UL)
        this._key = FontHelper.CalcChecksum(this.Bytes);
      return this._key;
    }
  }

  public void IncrementKey() => this._key += 4294967296UL /*0x0100000000*/;

  public string FontName => this._fontName;

  public byte[] Bytes => this._bytes;

  public override int GetHashCode() => (int) ((long) (this.Key >> 32 /*0x20*/) ^ (long) this.Key);

  public override bool Equals(object obj)
  {
    return obj is XFontSource xfontSource && (long) this.Key == (long) xfontSource.Key;
  }

  internal string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "XFontSource: '{0}', keyhash={1}", (object) this.FontName, (object) (this.Key % 99991UL));
    }
  }
}
