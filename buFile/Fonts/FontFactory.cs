// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.FontFactory
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Fonts;

internal static class FontFactory
{
  private static readonly Dictionary<string, FontResolverInfo> FontResolverInfosByName = new Dictionary<string, FontResolverInfo>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<string, XFontSource> FontSourcesByName = new Dictionary<string, XFontSource>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<ulong, XFontSource> FontSourcesByKey = new Dictionary<ulong, XFontSource>();

  public static FontResolverInfo ResolveTypeface(
    string familyName,
    FontResolvingOptions fontResolvingOptions,
    string typefaceKey)
  {
    if (string.IsNullOrEmpty(typefaceKey))
      typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
    try
    {
      Lock.EnterFontFactory();
      FontResolverInfo fontResolverInfo1;
      if (FontFactory.FontResolverInfosByName.TryGetValue(typefaceKey, out fontResolverInfo1))
        return fontResolverInfo1;
      IFontResolver fontResolver = GlobalFontSettings.FontResolver;
      if (fontResolver != null)
      {
        fontResolverInfo1 = fontResolver.ResolveTypeface(familyName, fontResolvingOptions.IsBold, fontResolvingOptions.IsItalic);
        if ((fontResolverInfo1 == null ? 0 : (!(fontResolverInfo1 is PlatformFontResolverInfo) ? 1 : 0)) != 0)
        {
          if (fontResolvingOptions.OverrideStyleSimulations)
            fontResolverInfo1 = new FontResolverInfo(fontResolverInfo1.FaceName, fontResolvingOptions.MustSimulateBold, fontResolvingOptions.MustSimulateItalic, fontResolverInfo1.CollectionNumber);
          string key = fontResolverInfo1.Key;
          FontResolverInfo fontResolverInfo2;
          if (FontFactory.FontResolverInfosByName.TryGetValue(key, out fontResolverInfo2))
          {
            fontResolverInfo1 = fontResolverInfo2;
            FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo1);
            Debug.Assert(FontFactory.FontSourcesByName.ContainsKey(fontResolverInfo1.FaceName));
          }
          else
          {
            FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo1);
            Debug.Assert(key == fontResolverInfo1.Key);
            FontFactory.FontResolverInfosByName.Add(key, fontResolverInfo1);
            if (!FontFactory.FontSourcesByName.TryGetValue(fontResolverInfo1.FaceName, out XFontSource _))
            {
              XFontSource from = XFontSource.GetOrCreateFrom(fontResolver.GetFont(fontResolverInfo1.FaceName));
              if (string.Compare(fontResolverInfo1.FaceName, from.FontName, StringComparison.OrdinalIgnoreCase) != 0)
                FontFactory.FontSourcesByName.Add(fontResolverInfo1.FaceName, from);
            }
          }
        }
      }
      else
        fontResolverInfo1 = PlatformFontResolver.ResolveTypeface(familyName, fontResolvingOptions, typefaceKey);
      return fontResolverInfo1;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  public static XFontSource GetFontSourceByFontName(string fontName)
  {
    XFontSource xfontSource;
    XFontSource sourceByFontName;
    if (FontFactory.FontSourcesByName.TryGetValue(fontName, out xfontSource))
    {
      sourceByFontName = xfontSource;
    }
    else
    {
      Debug.Assert(false, $"An XFontSource with the name '{fontName}' does not exists.");
      sourceByFontName = (XFontSource) null;
    }
    return sourceByFontName;
  }

  public static XFontSource GetFontSourceByTypefaceKey(string typefaceKey)
  {
    XFontSource xfontSource;
    XFontSource sourceByTypefaceKey;
    if (FontFactory.FontSourcesByName.TryGetValue(typefaceKey, out xfontSource))
    {
      sourceByTypefaceKey = xfontSource;
    }
    else
    {
      Debug.Assert(false, $"An XFontSource with the typeface key '{typefaceKey}' does not exists.");
      sourceByTypefaceKey = (XFontSource) null;
    }
    return sourceByTypefaceKey;
  }

  public static bool TryGetFontSourceByKey(ulong key, out XFontSource fontSource)
  {
    return FontFactory.FontSourcesByKey.TryGetValue(key, out fontSource);
  }

  public static bool HasFontSources => FontFactory.FontSourcesByName.Count > 0;

  public static bool TryGetFontResolverInfoByTypefaceKey(
    string typeFaceKey,
    out FontResolverInfo info)
  {
    return FontFactory.FontResolverInfosByName.TryGetValue(typeFaceKey, out info);
  }

  public static bool TryGetFontSourceByTypefaceKey(string typefaceKey, out XFontSource source)
  {
    return FontFactory.FontSourcesByName.TryGetValue(typefaceKey, out source);
  }

  internal static void CacheFontResolverInfo(string typefaceKey, FontResolverInfo fontResolverInfo)
  {
    FontResolverInfo fontResolverInfo1;
    if (FontFactory.FontResolverInfosByName.TryGetValue(typefaceKey, out fontResolverInfo1))
      throw new InvalidOperationException($"A font file with different content already exists with the specified face name '{typefaceKey}'.");
    if (FontFactory.FontResolverInfosByName.TryGetValue(fontResolverInfo.Key, out fontResolverInfo1))
      throw new InvalidOperationException($"A font resolver already exists with the specified key '{fontResolverInfo.Key}'.");
    FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo);
    FontFactory.FontResolverInfosByName.Add(fontResolverInfo.Key, fontResolverInfo);
  }

  public static XFontSource CacheFontSource(XFontSource fontSource)
  {
    try
    {
      Lock.EnterFontFactory();
      XFontSource xfontSource;
      if (FontFactory.FontSourcesByKey.TryGetValue(fontSource.Key, out xfontSource))
      {
        int length = fontSource.Bytes.Length;
        int index = 0;
        while (index < length && (int) xfontSource.Bytes[index] == (int) fontSource.Bytes[index])
          ++index;
        Debug.Assert(xfontSource.Fontface != null);
        return xfontSource;
      }
      if (fontSource.Fontface == null)
        fontSource.Fontface = new OpenTypeFontface(fontSource);
      FontFactory.FontSourcesByKey.Add(fontSource.Key, fontSource);
      FontFactory.FontSourcesByName.Add(fontSource.FontName, fontSource);
      return fontSource;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  public static XFontSource CacheNewFontSource(string typefaceKey, XFontSource fontSource)
  {
    XFontSource xfontSource1;
    XFontSource xfontSource2;
    if (FontFactory.FontSourcesByKey.TryGetValue(fontSource.Key, out xfontSource1))
    {
      xfontSource2 = xfontSource1;
    }
    else
    {
      if (fontSource.Fontface == null)
      {
        OpenTypeFontface openTypeFontface = new OpenTypeFontface(fontSource);
        fontSource.Fontface = openTypeFontface;
      }
      FontFactory.FontSourcesByName.Add(typefaceKey, fontSource);
      FontFactory.FontSourcesByName.Add(fontSource.FontName, fontSource);
      FontFactory.FontSourcesByKey.Add(fontSource.Key, fontSource);
      xfontSource2 = fontSource;
    }
    return xfontSource2;
  }

  public static void CacheExistingFontSourceWithNewTypefaceKey(
    string typefaceKey,
    XFontSource fontSource)
  {
    try
    {
      Lock.EnterFontFactory();
      FontFactory.FontSourcesByName.Add(typefaceKey, fontSource);
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  internal static string GetFontCachesState()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("====================\n");
    stringBuilder.Append("Font resolver info by name\n");
    Dictionary<string, FontResolverInfo>.KeyCollection keys1 = FontFactory.FontResolverInfosByName.Keys;
    string[] array1 = new string[keys1.Count];
    keys1.CopyTo(array1, 0);
    Array.Sort<string>(array1, (IComparer<string>) StringComparer.OrdinalIgnoreCase);
    foreach (string key in array1)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) FontFactory.FontResolverInfosByName[key].DebuggerDisplay);
    stringBuilder.Append("\n");
    stringBuilder.Append("Font source by key and name\n");
    Dictionary<ulong, XFontSource>.KeyCollection keys2 = FontFactory.FontSourcesByKey.Keys;
    ulong[] array2 = new ulong[keys2.Count];
    keys2.CopyTo(array2, 0);
    Array.Sort<ulong>(array2, (Comparison<ulong>) ((x, y) => (long) x == (long) y ? 0 : (x > y ? 1 : -1)));
    foreach (ulong key in array2)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) FontFactory.FontSourcesByKey[key].DebuggerDisplay);
    Dictionary<string, XFontSource>.KeyCollection keys3 = FontFactory.FontSourcesByName.Keys;
    string[] array3 = new string[keys3.Count];
    keys3.CopyTo(array3, 0);
    Array.Sort<string>(array3, (IComparer<string>) StringComparer.OrdinalIgnoreCase);
    foreach (string key in array3)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) FontFactory.FontSourcesByName[key].DebuggerDisplay);
    stringBuilder.Append("--------------------\n\n");
    stringBuilder.Append(FontFamilyCache.GetCacheState());
    stringBuilder.Append(GlyphTypefaceCache.GetCacheState());
    stringBuilder.Append(OpenTypeFontfaceCache.GetCacheState());
    return stringBuilder.ToString();
  }
}
