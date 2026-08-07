// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XGlyphTypeface
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
internal sealed class XGlyphTypeface
{
  private const string KeyPrefix = "tk:";
  private readonly XFontFamily _fontFamily;
  private readonly OpenTypeFontface _fontface;
  private readonly XFontSource _fontSource;
  private string _faceName;
  private string _familyName;
  private string _styleName;
  private string _displayName;
  private bool _isBold;
  private bool _isItalic;
  private XStyleSimulations _styleSimulations;
  private readonly string _key;
  private readonly Font _gdiFont;

  private XGlyphTypeface(
    string key,
    XFontFamily fontFamily,
    XFontSource fontSource,
    XStyleSimulations styleSimulations,
    Font gdiFont)
  {
    this._key = key;
    this._fontFamily = fontFamily;
    this._fontSource = fontSource;
    this._fontface = OpenTypeFontface.CetOrCreateFrom(fontSource);
    Debug.Assert(this._fontSource.Fontface == this._fontface);
    this._gdiFont = gdiFont;
    this._styleSimulations = styleSimulations;
    this.Initialize();
  }

  public static XGlyphTypeface GetOrCreateFrom(
    string familyName,
    FontResolvingOptions fontResolvingOptions)
  {
    string key = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
    XGlyphTypeface glyphTypeface;
    XGlyphTypeface from;
    try
    {
      Lock.EnterFontFactory();
      if (GlyphTypefaceCache.TryGetGlyphTypeface(key, out glyphTypeface))
      {
        from = glyphTypeface;
        goto label_11;
      }
      FontResolverInfo fontResolverInfo1 = FontFactory.ResolveTypeface(familyName, fontResolvingOptions, key);
      if (fontResolverInfo1 == null)
        throw new InvalidOperationException("No appropriate font found.");
      Font font = (Font) null;
      XFontFamily fontFamily;
      if (fontResolverInfo1 is PlatformFontResolverInfo fontResolverInfo2)
      {
        font = fontResolverInfo2.GdiFont;
        fontFamily = XFontFamily.GetOrCreateFromGdi(font);
      }
      else
        fontFamily = XFontFamily.GetOrCreateFontFamily(familyName);
      XFontSource sourceByFontName = FontFactory.GetFontSourceByFontName(fontResolverInfo1.FaceName);
      Debug.Assert(sourceByFontName != null);
      glyphTypeface = new XGlyphTypeface(key, fontFamily, sourceByFontName, fontResolverInfo1.StyleSimulations, font);
      GlyphTypefaceCache.AddGlyphTypeface(glyphTypeface);
    }
    finally
    {
      Lock.ExitFontFactory();
    }
    from = glyphTypeface;
label_11:
    return from;
  }

  public static XGlyphTypeface GetOrCreateFromGdi(Font gdiFont)
  {
    string key = XGlyphTypeface.ComputeKey(gdiFont);
    XGlyphTypeface glyphTypeface1;
    XGlyphTypeface fromGdi1;
    if (GlyphTypefaceCache.TryGetGlyphTypeface(key, out glyphTypeface1))
    {
      fromGdi1 = glyphTypeface1;
    }
    else
    {
      XFontFamily fromGdi2 = XFontFamily.GetOrCreateFromGdi(gdiFont);
      XFontSource fromGdi3 = XFontSource.GetOrCreateFromGdi(key, gdiFont);
      XStyleSimulations styleSimulations = XStyleSimulations.None;
      if ((!gdiFont.Bold ? 0 : (!fromGdi3.Fontface.os2.IsBold ? 1 : 0)) != 0)
        styleSimulations |= XStyleSimulations.BoldSimulation;
      if ((!gdiFont.Italic ? 0 : (!fromGdi3.Fontface.os2.IsItalic ? 1 : 0)) != 0)
        styleSimulations |= XStyleSimulations.ItalicSimulation;
      XGlyphTypeface glyphTypeface2 = new XGlyphTypeface(key, fromGdi2, fromGdi3, styleSimulations, gdiFont);
      GlyphTypefaceCache.AddGlyphTypeface(glyphTypeface2);
      fromGdi1 = glyphTypeface2;
    }
    return fromGdi1;
  }

  public XFontFamily FontFamily => this._fontFamily;

  internal OpenTypeFontface Fontface => this._fontface;

  public XFontSource FontSource => this._fontSource;

  private void Initialize()
  {
    this._familyName = this._fontface.name.Name;
    if ((string.IsNullOrEmpty(this._faceName) ? 1 : (this._faceName.StartsWith("?") ? 1 : 0)) != 0)
      this._faceName = this._familyName;
    this._styleName = this._fontface.name.Style;
    this._displayName = this._fontface.name.FullFontName;
    if (string.IsNullOrEmpty(this._displayName))
    {
      this._displayName = this._familyName;
      if (string.IsNullOrEmpty(this._styleName))
        this._displayName = $"{this._displayName} ({this._styleName})";
    }
    this._isBold = this._fontface.os2.IsBold;
    this._isItalic = this._fontface.os2.IsItalic;
  }

  internal string FaceName => this._faceName;

  public string FamilyName => this._familyName;

  public string StyleName => this._styleName;

  public string DisplayName => this._displayName;

  public bool IsBold => this._isBold;

  public bool IsItalic => this._isItalic;

  public XStyleSimulations StyleSimulations => this._styleSimulations;

  private string GetFaceNameSuffix()
  {
    return !this.IsBold ? (this.IsItalic ? ",Italic" : "") : (this.IsItalic ? ",BoldItalic" : ",Bold");
  }

  internal string GetBaseName()
  {
    string str = this.DisplayName;
    int length1 = str.IndexOf("bold", StringComparison.OrdinalIgnoreCase);
    if (length1 > 0)
      str = str.Substring(0, length1) + str.Substring(length1 + 4, str.Length - length1 - 4);
    int length2 = str.IndexOf("italic", StringComparison.OrdinalIgnoreCase);
    if (length2 > 0)
      str = str.Substring(0, length2) + str.Substring(length2 + 6, str.Length - length2 - 6);
    return str.Trim() + this.GetFaceNameSuffix();
  }

  internal static string ComputeKey(string familyName, FontResolvingOptions fontResolvingOptions)
  {
    string str = "";
    if (fontResolvingOptions.OverrideStyleSimulations)
    {
      switch (fontResolvingOptions.StyleSimulations)
      {
        case XStyleSimulations.None:
          break;
        case XStyleSimulations.BoldSimulation:
          str = "|b+/i-";
          break;
        case XStyleSimulations.ItalicSimulation:
          str = "|b-/i+";
          break;
        case XStyleSimulations.BoldItalicSimulation:
          str = "|b+/i+";
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof (fontResolvingOptions));
      }
    }
    return $"tk:{familyName.ToLowerInvariant()}{(fontResolvingOptions.IsItalic ? "/i" : "/n")}{(fontResolvingOptions.IsBold ? "/700" : "/400")}/5{str}";
  }

  internal static string ComputeKey(string familyName, bool isBold, bool isItalic)
  {
    return XGlyphTypeface.ComputeKey(familyName, new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic)));
  }

  internal static string ComputeKey(Font gdiFont)
  {
    string name = gdiFont.Name;
    string originalFontName = gdiFont.OriginalFontName;
    string systemFontName = gdiFont.SystemFontName;
    string str = name;
    FontStyle style = gdiFont.Style;
    return $"tk:{str.ToLowerInvariant()}{((style & FontStyle.Italic) == FontStyle.Italic ? "/i" : "/n")}{((style & FontStyle.Bold) == FontStyle.Bold ? "/700" : "/400")}/5";
  }

  public string Key => this._key;

  internal Font GdiFont => this._gdiFont;

  internal string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} - {1} ({2})", (object) this.FamilyName, (object) this.StyleName, (object) this.FaceName);
    }
  }
}
