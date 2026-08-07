// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.FontFamilyCache
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace PdfSharp.Drawing;

internal sealed class FontFamilyCache
{
  private static volatile FontFamilyCache _singleton;
  private readonly Dictionary<string, FontFamilyInternal> _familiesByName;

  private FontFamilyCache()
  {
    this._familiesByName = new Dictionary<string, FontFamilyInternal>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  }

  public static FontFamilyInternal GetFamilyByName(string familyName)
  {
    try
    {
      Lock.EnterFontFactory();
      FontFamilyInternal familyByName;
      FontFamilyCache.Singleton._familiesByName.TryGetValue(familyName, out familyByName);
      return familyByName;
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
      FontFamilyInternal fontFamily1;
      if (FontFamilyCache.Singleton._familiesByName.TryGetValue(fontFamily.Name, out fontFamily1))
        return fontFamily1;
      FontFamilyCache.Singleton._familiesByName.Add(fontFamily.Name, fontFamily);
      return fontFamily;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  private static FontFamilyCache Singleton
  {
    get
    {
      if (FontFamilyCache._singleton == null)
      {
        try
        {
          Lock.EnterFontFactory();
          if (FontFamilyCache._singleton == null)
            FontFamilyCache._singleton = new FontFamilyCache();
        }
        finally
        {
          Lock.ExitFontFactory();
        }
      }
      return FontFamilyCache._singleton;
    }
  }

  internal static string GetCacheState()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("====================\n");
    stringBuilder.Append("Font families by name\n");
    Dictionary<string, FontFamilyInternal>.KeyCollection keys = FontFamilyCache.Singleton._familiesByName.Keys;
    string[] array = new string[keys.Count];
    keys.CopyTo(array, 0);
    Array.Sort<string>(array, (IComparer<string>) StringComparer.OrdinalIgnoreCase);
    foreach (string key in array)
      stringBuilder.AppendFormat("  {0}: {1}\n", (object) key, (object) FontFamilyCache.Singleton._familiesByName[key].DebuggerDisplay);
    stringBuilder.Append("\n");
    return stringBuilder.ToString();
  }
}
