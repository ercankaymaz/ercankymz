// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OpenTypeFontfaceCache
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
internal class OpenTypeFontfaceCache
{
  private static volatile OpenTypeFontfaceCache _singleton;
  private readonly Dictionary<string, OpenTypeFontface> _fontfaceCache;
  private readonly Dictionary<ulong, OpenTypeFontface> _fontfacesByCheckSum;

  private OpenTypeFontfaceCache()
  {
    this._fontfaceCache = new Dictionary<string, OpenTypeFontface>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    this._fontfacesByCheckSum = new Dictionary<ulong, OpenTypeFontface>();
  }

  public static bool TryGetFontface(string key, out OpenTypeFontface fontface)
  {
    try
    {
      Lock.EnterFontFactory();
      return OpenTypeFontfaceCache.Singleton._fontfaceCache.TryGetValue(key, out fontface);
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
      return OpenTypeFontfaceCache.Singleton._fontfacesByCheckSum.TryGetValue(checkSum, out fontface);
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
      OpenTypeFontface fontface1;
      if (OpenTypeFontfaceCache.TryGetFontface(fontface.FullFaceName, out fontface1))
      {
        if ((long) fontface1.CheckSum != (long) fontface.CheckSum)
          throw new InvalidOperationException("OpenTypeFontface with same signature but different bytes.");
        return fontface1;
      }
      OpenTypeFontfaceCache.Singleton._fontfaceCache.Add(fontface.FullFaceName, fontface);
      OpenTypeFontfaceCache.Singleton._fontfacesByCheckSum.Add(fontface.CheckSum, fontface);
      return fontface;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  private static OpenTypeFontfaceCache Singleton
  {
    get
    {
      if (OpenTypeFontfaceCache._singleton == null)
      {
        try
        {
          Lock.EnterFontFactory();
          if (OpenTypeFontfaceCache._singleton == null)
            OpenTypeFontfaceCache._singleton = new OpenTypeFontfaceCache();
        }
        finally
        {
          Lock.ExitFontFactory();
        }
      }
      return OpenTypeFontfaceCache._singleton;
    }
  }

  internal static string GetCacheState()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("====================\n");
    stringBuilder.Append("OpenType fontfaces by name\n");
    Dictionary<string, OpenTypeFontface>.KeyCollection keys = OpenTypeFontfaceCache.Singleton._fontfaceCache.Keys;
    string[] array = new string[keys.Count];
    keys.CopyTo(array, 0);
    Array.Sort<string>(array, (IComparer<string>) StringComparer.OrdinalIgnoreCase);
    foreach (string key in array)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) OpenTypeFontfaceCache.Singleton._fontfaceCache[key].DebuggerDisplay);
    stringBuilder.Append("\n");
    return stringBuilder.ToString();
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Fontfaces: {0}", (object) this._fontfaceCache.Count);
    }
  }
}
