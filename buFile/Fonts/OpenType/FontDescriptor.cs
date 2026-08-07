// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.FontDescriptor
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class FontDescriptor
{
  private readonly string _key;
  private string _fontName;
  private string _weight;
  private float _italicAngle;
  private int _xMin;
  private int _yMin;
  private int _xMax;
  private int _yMax;
  private bool _isFixedPitch;
  private int _underlinePosition;
  private int _underlineThickness;
  private int _strikeoutPosition;
  private int _strikeoutSize;
  private string _version;
  private string _encodingScheme;
  private int _unitsPerEm;
  private int _capHeight;
  private int _xHeight;
  private int _ascender;
  private int _descender;
  private int _leading;
  private int _flags;
  private int _stemV;
  private int _lineSpacing;

  protected FontDescriptor(string key) => this._key = key;

  public string Key => this._key;

  public string FontName
  {
    get => this._fontName;
    protected set => this._fontName = value;
  }

  public string Weight
  {
    get => this._weight;
    private set => this._weight = value;
  }

  public virtual bool IsBoldFace => false;

  public float ItalicAngle
  {
    get => this._italicAngle;
    protected set => this._italicAngle = value;
  }

  public virtual bool IsItalicFace => false;

  public int XMin
  {
    get => this._xMin;
    protected set => this._xMin = value;
  }

  public int YMin
  {
    get => this._yMin;
    protected set => this._yMin = value;
  }

  public int XMax
  {
    get => this._xMax;
    protected set => this._xMax = value;
  }

  public int YMax
  {
    get => this._yMax;
    protected set => this._yMax = value;
  }

  public bool IsFixedPitch
  {
    get => this._isFixedPitch;
    private set => this._isFixedPitch = value;
  }

  public int UnderlinePosition
  {
    get => this._underlinePosition;
    protected set => this._underlinePosition = value;
  }

  public int UnderlineThickness
  {
    get => this._underlineThickness;
    protected set => this._underlineThickness = value;
  }

  public int StrikeoutPosition
  {
    get => this._strikeoutPosition;
    protected set => this._strikeoutPosition = value;
  }

  public int StrikeoutSize
  {
    get => this._strikeoutSize;
    protected set => this._strikeoutSize = value;
  }

  public string Version
  {
    get => this._version;
    private set => this._version = value;
  }

  public string EncodingScheme
  {
    get => this._encodingScheme;
    private set => this._encodingScheme = value;
  }

  public int UnitsPerEm
  {
    get => this._unitsPerEm;
    protected set => this._unitsPerEm = value;
  }

  public int CapHeight
  {
    get => this._capHeight;
    protected set => this._capHeight = value;
  }

  public int XHeight
  {
    get => this._xHeight;
    protected set => this._xHeight = value;
  }

  public int Ascender
  {
    get => this._ascender;
    protected set => this._ascender = value;
  }

  public int Descender
  {
    get => this._descender;
    protected set => this._descender = value;
  }

  public int Leading
  {
    get => this._leading;
    protected set => this._leading = value;
  }

  public int Flags
  {
    get => this._flags;
    private set => this._flags = value;
  }

  public int StemV
  {
    get => this._stemV;
    protected set => this._stemV = value;
  }

  public int LineSpacing
  {
    get => this._lineSpacing;
    protected set => this._lineSpacing = value;
  }

  internal static string ComputeKey(XFont font) => font.GlyphTypeface.Key;

  internal static string ComputeKey(string name, XFontStyle style)
  {
    return FontDescriptor.ComputeKey(name, (style & XFontStyle.Bold) == XFontStyle.Bold, (style & XFontStyle.Italic) == XFontStyle.Italic);
  }

  internal static string ComputeKey(string name, bool isBold, bool isItalic)
  {
    return $"{name.ToLowerInvariant()}/{(isBold ? "b" : "")}{(isItalic ? "i" : "")}";
  }

  internal static string ComputeKey(string name) => name.ToLowerInvariant();
}
