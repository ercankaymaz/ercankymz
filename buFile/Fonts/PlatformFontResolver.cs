// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.PlatformFontResolver
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System.Diagnostics;
using System.Drawing;

#nullable disable
namespace PdfSharp.Fonts;

public static class PlatformFontResolver
{
  public static FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
  {
    FontResolvingOptions fontResolvingOptions = new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic));
    return PlatformFontResolver.ResolveTypeface(familyName, fontResolvingOptions, XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions));
  }

  internal static FontResolverInfo ResolveTypeface(
    string familyName,
    FontResolvingOptions fontResolvingOptions,
    string typefaceKey)
  {
    if (string.IsNullOrEmpty(typefaceKey))
      typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
    FontResolverInfo info;
    FontResolverInfo fontResolverInfo1;
    if (FontFactory.TryGetFontResolverInfoByTypefaceKey(typefaceKey, out info))
    {
      fontResolverInfo1 = info;
    }
    else
    {
      Font font;
      XFontSource fontSource = PlatformFontResolver.CreateFontSource(familyName, fontResolvingOptions, out font, typefaceKey);
      if (fontSource == null)
      {
        fontResolverInfo1 = (FontResolverInfo) null;
      }
      else
      {
        FontResolverInfo fontResolverInfo2;
        if (fontResolvingOptions.OverrideStyleSimulations)
        {
          fontResolverInfo2 = (FontResolverInfo) new PlatformFontResolverInfo(typefaceKey, fontResolvingOptions.MustSimulateBold, fontResolvingOptions.MustSimulateItalic, font);
        }
        else
        {
          bool mustSimulateBold = font.Bold && !fontSource.Fontface.os2.IsBold;
          bool mustSimulateItalic = font.Italic && !fontSource.Fontface.os2.IsItalic;
          fontResolverInfo2 = (FontResolverInfo) new PlatformFontResolverInfo(typefaceKey, mustSimulateBold, mustSimulateItalic, font);
        }
        FontFactory.CacheFontResolverInfo(typefaceKey, fontResolverInfo2);
        fontResolverInfo1 = fontResolverInfo2;
      }
    }
    return fontResolverInfo1;
  }

  internal static XFontSource CreateFontSource(
    string familyName,
    FontResolvingOptions fontResolvingOptions,
    out Font font,
    string typefaceKey)
  {
    if (string.IsNullOrEmpty(typefaceKey))
      typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
    FontStyle style = (FontStyle) (fontResolvingOptions.FontStyle & XFontStyle.BoldItalic);
    XFontSource fontSource;
    font = FontHelper.CreateFont(familyName, 10.0, style, out fontSource);
    if (fontSource != null)
    {
      Debug.Assert(font != null);
      XFontSource source;
      Debug.Assert(FontFactory.TryGetFontSourceByTypefaceKey(typefaceKey, out source) && fontSource == source);
    }
    else
      fontSource = XFontSource.GetOrCreateFromGdi(typefaceKey, font);
    return fontSource;
  }
}
