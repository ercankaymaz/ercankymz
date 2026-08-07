// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.FontFamilyInternal
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Drawing;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
internal class FontFamilyInternal
{
  private readonly string _sourceName;
  private readonly string _name;
  private readonly FontFamily _gdiFontFamily;

  private FontFamilyInternal(string familyName, bool createPlatformObjects)
  {
    this._sourceName = this._name = familyName;
    if (!createPlatformObjects)
      return;
    this._gdiFontFamily = new FontFamily(familyName);
    this._name = this._gdiFontFamily.Name;
  }

  private FontFamilyInternal(FontFamily gdiFontFamily)
  {
    this._sourceName = this._name = gdiFontFamily.Name;
    this._gdiFontFamily = gdiFontFamily;
  }

  internal static FontFamilyInternal GetOrCreateFromName(
    string familyName,
    bool createPlatformObject)
  {
    try
    {
      Lock.EnterFontFactory();
      return FontFamilyCache.GetFamilyByName(familyName) ?? FontFamilyCache.CacheOrGetFontFamily(new FontFamilyInternal(familyName, createPlatformObject));
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  internal static FontFamilyInternal GetOrCreateFromGdi(FontFamily gdiFontFamily)
  {
    try
    {
      Lock.EnterFontFactory();
      return FontFamilyCache.CacheOrGetFontFamily(new FontFamilyInternal(gdiFontFamily));
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  public string SourceName => this._sourceName;

  public string Name => this._name;

  public FontFamily GdiFamily => this._gdiFontFamily;

  internal string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "FontFamily: '{0}'", (object) this.Name);
    }
  }
}
