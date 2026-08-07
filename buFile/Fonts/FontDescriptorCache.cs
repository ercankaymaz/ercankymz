// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.FontDescriptorCache
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using System;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Fonts;

internal sealed class FontDescriptorCache
{
  private static volatile FontDescriptorCache _singleton;
  private readonly Dictionary<string, FontDescriptor> _cache;

  private FontDescriptorCache() => this._cache = new Dictionary<string, FontDescriptor>();

  public static FontDescriptor GetOrCreateDescriptorFor(XFont font)
  {
    string str = font != null ? FontDescriptor.ComputeKey(font) : throw new ArgumentNullException(nameof (font));
    try
    {
      Lock.EnterFontFactory();
      FontDescriptor descriptorFor;
      if (!FontDescriptorCache.Singleton._cache.TryGetValue(str, out descriptorFor))
      {
        descriptorFor = (FontDescriptor) new OpenTypeDescriptor(str, font);
        FontDescriptorCache.Singleton._cache.Add(str, descriptorFor);
      }
      return descriptorFor;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  public static FontDescriptor GetOrCreateDescriptor(string fontFamilyName, XFontStyle style)
  {
    string key = !string.IsNullOrEmpty(fontFamilyName) ? FontDescriptor.ComputeKey(fontFamilyName, style) : throw new ArgumentNullException(nameof (fontFamilyName));
    try
    {
      Lock.EnterFontFactory();
      FontDescriptor descriptorFor;
      if (!FontDescriptorCache.Singleton._cache.TryGetValue(key, out descriptorFor))
      {
        descriptorFor = FontDescriptorCache.GetOrCreateDescriptorFor(new XFont(fontFamilyName, 10.0, style));
        if (FontDescriptorCache.Singleton._cache.ContainsKey(key))
          FontDescriptorCache.Singleton.GetType();
        else
          FontDescriptorCache.Singleton._cache.Add(key, descriptorFor);
      }
      return descriptorFor;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  public static FontDescriptor GetOrCreateDescriptor(string idName, byte[] fontData)
  {
    string key = FontDescriptor.ComputeKey(idName);
    try
    {
      Lock.EnterFontFactory();
      FontDescriptor openTypeDescriptor;
      if (!FontDescriptorCache.Singleton._cache.TryGetValue(key, out openTypeDescriptor))
      {
        openTypeDescriptor = (FontDescriptor) FontDescriptorCache.GetOrCreateOpenTypeDescriptor(key, idName, fontData);
        FontDescriptorCache.Singleton._cache.Add(key, openTypeDescriptor);
      }
      return openTypeDescriptor;
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  private static OpenTypeDescriptor GetOrCreateOpenTypeDescriptor(
    string fontDescriptorKey,
    string idName,
    byte[] fontData)
  {
    return new OpenTypeDescriptor(fontDescriptorKey, idName, fontData);
  }

  private static FontDescriptorCache Singleton
  {
    get
    {
      if (FontDescriptorCache._singleton == null)
      {
        try
        {
          Lock.EnterFontFactory();
          if (FontDescriptorCache._singleton == null)
            FontDescriptorCache._singleton = new FontDescriptorCache();
        }
        finally
        {
          Lock.ExitFontFactory();
        }
      }
      return FontDescriptorCache._singleton;
    }
  }
}
