// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XFontMetrics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XFontMetrics
{
  private readonly string _name;
  private readonly int _unitsPerEm;
  private readonly int _ascent;
  private readonly int _descent;
  private readonly int _averageWidth;
  private readonly int _capHeight;
  private readonly int _leading;
  private readonly int _lineSpacing;
  private readonly int _maxWidth;
  private readonly int _stemH;
  private readonly int _stemV;
  private readonly int _xHeight;
  private readonly int _underlinePosition;
  private readonly int _underlineThickness;
  private readonly int _strikethroughPosition;
  private readonly int _strikethroughThickness;

  internal XFontMetrics(
    string name,
    int unitsPerEm,
    int ascent,
    int descent,
    int leading,
    int lineSpacing,
    int capHeight,
    int xHeight,
    int stemV,
    int stemH,
    int averageWidth,
    int maxWidth,
    int underlinePosition,
    int underlineThickness,
    int strikethroughPosition,
    int strikethroughThickness)
  {
    this._name = name;
    this._unitsPerEm = unitsPerEm;
    this._ascent = ascent;
    this._descent = descent;
    this._leading = leading;
    this._lineSpacing = lineSpacing;
    this._capHeight = capHeight;
    this._xHeight = xHeight;
    this._stemV = stemV;
    this._stemH = stemH;
    this._averageWidth = averageWidth;
    this._maxWidth = maxWidth;
    this._underlinePosition = underlinePosition;
    this._underlineThickness = underlineThickness;
    this._strikethroughPosition = strikethroughPosition;
    this._strikethroughThickness = strikethroughThickness;
  }

  public string Name => this._name;

  public int UnitsPerEm => this._unitsPerEm;

  public int Ascent => this._ascent;

  public int Descent => this._descent;

  public int AverageWidth => this._averageWidth;

  public int CapHeight => this._capHeight;

  public int Leading => this._leading;

  public int LineSpacing => this._lineSpacing;

  public int MaxWidth => this._maxWidth;

  public int StemH => this._stemH;

  public int StemV => this._stemV;

  public int XHeight => this._xHeight;

  public int UnderlinePosition => this._underlinePosition;

  public int UnderlineThickness => this._underlineThickness;

  public int StrikethroughPosition => this._strikethroughPosition;

  public int StrikethroughThickness => this._strikethroughThickness;
}
