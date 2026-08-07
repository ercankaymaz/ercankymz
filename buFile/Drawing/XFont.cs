// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XFont
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public sealed class XFont
{
  private readonly double _emSize;
  private readonly XFontStyle _style;
  private bool _isVertical;
  private XPdfFontOptions _pdfOptions;
  private int _cellSpace;
  private int _cellAscent;
  private int _cellDescent;
  private XFontMetrics _fontMetrics;
  private XGlyphTypeface _glyphTypeface;
  private OpenTypeDescriptor _descriptor;
  private string _familyName;
  internal int _unitsPerEm;
  internal bool OverrideStyleSimulations;
  internal XStyleSimulations StyleSimulations;
  private readonly System.Drawing.FontFamily _gdiFontFamily;
  private Font _gdiFont;
  private string _selector;

  public XFont(string familyName, double emSize)
    : this(familyName, emSize, XFontStyle.Regular, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
  {
  }

  public XFont(string familyName, double emSize, XFontStyle style)
    : this(familyName, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
  {
  }

  public XFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
  {
    this._familyName = familyName;
    this._emSize = emSize;
    this._style = style;
    this._pdfOptions = pdfOptions;
    this.Initialize();
  }

  internal XFont(
    string familyName,
    double emSize,
    XFontStyle style,
    XPdfFontOptions pdfOptions,
    XStyleSimulations styleSimulations)
  {
    this._familyName = familyName;
    this._emSize = emSize;
    this._style = style;
    this._pdfOptions = pdfOptions;
    this.OverrideStyleSimulations = true;
    this.StyleSimulations = styleSimulations;
    this.Initialize();
  }

  public XFont(System.Drawing.FontFamily fontFamily, double emSize, XFontStyle style)
    : this(fontFamily, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
  {
  }

  public XFont(System.Drawing.FontFamily fontFamily, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
  {
    this._familyName = fontFamily.Name;
    this._gdiFontFamily = fontFamily;
    this._emSize = emSize;
    this._style = style;
    this._pdfOptions = pdfOptions;
    this.InitializeFromGdi();
  }

  public XFont(Font font)
    : this(font, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
  {
  }

  public XFont(Font font, XPdfFontOptions pdfOptions)
  {
    this._gdiFont = font.Unit == 0 ? font : throw new ArgumentException("Font must use GraphicsUnit.World.");
    Debug.Assert(font.Name == font.FontFamily.Name);
    this._familyName = font.Name;
    this._emSize = (double) font.Size;
    this._style = XFont.FontStyleFrom(font);
    this._pdfOptions = pdfOptions;
    this.InitializeFromGdi();
  }

  private void Initialize()
  {
    if ((!(this._familyName == "Segoe UI Semilight") ? 0 : ((this._style & XFontStyle.BoldItalic) == XFontStyle.Italic ? 1 : 0)) != 0)
      this.GetType();
    FontResolvingOptions fontResolvingOptions = this.OverrideStyleSimulations ? new FontResolvingOptions(this._style, this.StyleSimulations) : new FontResolvingOptions(this._style);
    if (StringComparer.OrdinalIgnoreCase.Compare(this._familyName, "PlatformDefault") == 0)
      this._familyName = "Calibri";
    this._glyphTypeface = XGlyphTypeface.GetOrCreateFrom(this._familyName, fontResolvingOptions);
    this.CreateDescriptorAndInitializeFontMetrics();
  }

  private void InitializeFromGdi()
  {
    try
    {
      Lock.EnterFontFactory();
      if (this._gdiFontFamily != null)
        this._gdiFont = new Font(this._gdiFontFamily, (float) this._emSize, (FontStyle) this._style, GraphicsUnit.World);
      if (this._gdiFont != null)
        this._familyName = this._gdiFont.FontFamily.Name;
      else
        Debug.Assert(false);
      if (this._glyphTypeface == null)
        this._glyphTypeface = XGlyphTypeface.GetOrCreateFromGdi(this._gdiFont);
      this.CreateDescriptorAndInitializeFontMetrics();
    }
    finally
    {
      Lock.ExitFontFactory();
    }
  }

  private void CreateDescriptorAndInitializeFontMetrics()
  {
    Debug.Assert(this._fontMetrics == null, "InitializeFontMetrics() was already called.");
    this._descriptor = (OpenTypeDescriptor) FontDescriptorCache.GetOrCreateDescriptorFor(this);
    this._fontMetrics = new XFontMetrics(this._descriptor.FontName, this._descriptor.UnitsPerEm, this._descriptor.Ascender, this._descriptor.Descender, this._descriptor.Leading, this._descriptor.LineSpacing, this._descriptor.CapHeight, this._descriptor.XHeight, this._descriptor.StemV, 0, 0, 0, this._descriptor.UnderlinePosition, this._descriptor.UnderlineThickness, this._descriptor.StrikeoutPosition, this._descriptor.StrikeoutSize);
    XFontMetrics metrics = this.Metrics;
    this.UnitsPerEm = this._descriptor.UnitsPerEm;
    this.CellAscent = this._descriptor.Ascender;
    this.CellDescent = this._descriptor.Descender;
    this.CellSpace = this._descriptor.LineSpacing;
    Debug.Assert(metrics.UnitsPerEm == this._descriptor.UnitsPerEm);
  }

  [Browsable(false)]
  public XFontFamily FontFamily => this._glyphTypeface.FontFamily;

  public string Name => this._glyphTypeface.FontFamily.Name;

  internal string FaceName => this._glyphTypeface.FaceName;

  public double Size => this._emSize;

  [Browsable(false)]
  public XFontStyle Style => this._style;

  public bool Bold => (this._style & XFontStyle.Bold) == XFontStyle.Bold;

  public bool Italic => (this._style & XFontStyle.Italic) == XFontStyle.Italic;

  public bool Strikeout => (this._style & XFontStyle.Strikeout) == XFontStyle.Strikeout;

  public bool Underline => (this._style & XFontStyle.Underline) == XFontStyle.Underline;

  internal bool IsVertical
  {
    get => this._isVertical;
    set => this._isVertical = value;
  }

  public XPdfFontOptions PdfOptions
  {
    get => this._pdfOptions ?? (this._pdfOptions = new XPdfFontOptions());
  }

  internal bool Unicode
  {
    get => this._pdfOptions != null && this._pdfOptions.FontEncoding == PdfFontEncoding.Unicode;
  }

  public int CellSpace
  {
    get => this._cellSpace;
    internal set => this._cellSpace = value;
  }

  public int CellAscent
  {
    get => this._cellAscent;
    internal set => this._cellAscent = value;
  }

  public int CellDescent
  {
    get => this._cellDescent;
    internal set => this._cellDescent = value;
  }

  public XFontMetrics Metrics
  {
    get
    {
      Debug.Assert(this._fontMetrics != null, "InitializeFontMetrics() not yet called.");
      return this._fontMetrics;
    }
  }

  public double GetHeight() => (double) this.CellSpace * this._emSize / (double) this.UnitsPerEm;

  [Obsolete("Use GetHeight() without parameter.")]
  public double GetHeight(XGraphics graphics)
  {
    throw new InvalidOperationException("Honestly: Use GetHeight() without parameter!");
  }

  [Browsable(false)]
  public int Height => (int) Math.Ceiling(this.GetHeight());

  internal XGlyphTypeface GlyphTypeface => this._glyphTypeface;

  internal OpenTypeDescriptor Descriptor
  {
    get => this._descriptor;
    private set => this._descriptor = value;
  }

  internal string FamilyName => this._familyName;

  internal int UnitsPerEm
  {
    get => this._unitsPerEm;
    private set => this._unitsPerEm = value;
  }

  public System.Drawing.FontFamily GdiFontFamily => this._gdiFontFamily;

  internal Font GdiFont => this._gdiFont;

  internal static XFontStyle FontStyleFrom(Font font)
  {
    return (XFontStyle) ((font.Bold ? 1 : 0) | (font.Italic ? 2 : 0) | (font.Strikeout ? 8 : 0) | (font.Underline ? 4 : 0));
  }

  public static implicit operator XFont(Font font) => new XFont(font);

  internal string Selector
  {
    get => this._selector;
    set => this._selector = value;
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "font=('{0}' {1:0.##})", (object) this.Name, (object) this.Size);
    }
  }
}
