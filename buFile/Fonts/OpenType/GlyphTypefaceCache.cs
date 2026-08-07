// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.GlyphTypefaceCache
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class GlyphTypefaceCache
{
  private static volatile GlyphTypefaceCache _singleton;
  private readonly Dictionary<string, XGlyphTypeface> _glyphTypefacesByKey;

  private GlyphTypefaceCache()
  {
    this._glyphTypefacesByKey = new Dictionary<string, XGlyphTypeface>();
  }

  public static bool TryGetGlyphTypeface(string key, out XGlyphTypeface glyphTypeface)
  {
    try
    {
      Lock.EnterFontFactory();
      return GlyphTypefaceCache.Singleton._glyphTypefacesByKey.TryGetValue(key, out glyphTypeface);
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
      GlyphTypefaceCache singleton = GlyphTypefaceCache.Singleton;
      Debug.Assert(!singleton._glyphTypefacesByKey.ContainsKey(glyphTypeface.Key));
      singleton._glyphTypefacesByKey.Add(glyphTypeface.Key, glyphTypeface);
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  private static GlyphTypefaceCache Singleton
  {
    get
    {
      if (GlyphTypefaceCache._singleton == null)
      {
        try
        {
          Lock.EnterFontFactory();
          if (GlyphTypefaceCache._singleton == null)
            GlyphTypefaceCache._singleton = new GlyphTypefaceCache();
        }
        finally
        {
          Lock.ExitFontFactory();
        }
      }
      return GlyphTypefaceCache._singleton;
    }
  }

  internal static string GetCacheState()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("====================\n");
    stringBuilder.Append("Glyph typefaces by name\n");
    Dictionary<string, XGlyphTypeface>.KeyCollection keys = GlyphTypefaceCache.Singleton._glyphTypefacesByKey.Keys;
    string[] array = new string[keys.Count];
    keys.CopyTo(array, 0);
    Array.Sort<string>(array, (IComparer<string>) StringComparer.OrdinalIgnoreCase);
    foreach (string key in array)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) GlyphTypefaceCache.Singleton._glyphTypefacesByKey[key].DebuggerDisplay);
    stringBuilder.Append("\n");
    return stringBuilder.ToString();
  }
}
