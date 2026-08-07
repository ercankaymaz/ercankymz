// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XFontFamily
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using System;
using System.Drawing;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XFontFamily
{
  internal FontFamilyInternal FamilyInternal;

  public XFontFamily(string familyName)
  {
    this.FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, true);
  }

  internal XFontFamily(string familyName, bool createPlatformObjects)
  {
    this.FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, createPlatformObjects);
  }

  private XFontFamily(FontFamilyInternal fontFamilyInternal)
  {
    this.FamilyInternal = fontFamilyInternal;
  }

  internal static XFontFamily CreateFromName_not_used(string name, bool createPlatformFamily)
  {
    XFontFamily fromNameNotUsed = new XFontFamily(name);
    if (createPlatformFamily)
      ;
    return fromNameNotUsed;
  }

  internal static XFontFamily GetOrCreateFontFamily(string name)
  {
    return new XFontFamily(FontFamilyCache.GetFamilyByName(name) ?? FontFamilyCache.CacheOrGetFontFamily(FontFamilyInternal.GetOrCreateFromName(name, false)));
  }

  internal static XFontFamily GetOrCreateFromGdi(Font font)
  {
    return new XFontFamily(FontFamilyInternal.GetOrCreateFromGdi(font.FontFamily));
  }

  public string Name => this.FamilyInternal.Name;

  public int GetCellAscent(XFontStyle style)
  {
    return FontDescriptorCache.GetOrCreateDescriptor(this.Name, style).Ascender;
  }

  public int GetCellDescent(XFontStyle style)
  {
    return FontDescriptorCache.GetOrCreateDescriptor(this.Name, style).Descender;
  }

  public int GetEmHeight(XFontStyle style)
  {
    return FontDescriptorCache.GetOrCreateDescriptor(this.Name, style).UnitsPerEm;
  }

  public int GetLineSpacing(XFontStyle style)
  {
    return FontDescriptorCache.GetOrCreateDescriptor(this.Name, style).LineSpacing;
  }

  public bool IsStyleAvailable(XFontStyle style)
  {
    throw new InvalidOperationException("In CORE build it is the responsibility of the developer to provide all required font faces.");
  }

  [Obsolete("Use platform API directly.")]
  public static XFontFamily[] Families
  {
    get => throw new InvalidOperationException("Obsolete and not implemted any more.");
  }

  [Obsolete("Use platform API directly.")]
  public static XFontFamily[] GetFamilies(XGraphics graphics)
  {
    throw new InvalidOperationException("Obsolete and not implemted any more.");
  }
}
