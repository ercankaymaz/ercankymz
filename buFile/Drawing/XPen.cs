// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPen
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XPen
{
  internal XColor _color;
  internal double _width;
  internal XLineJoin _lineJoin;
  internal XLineCap _lineCap;
  internal double _miterLimit;
  internal XDashStyle _dashStyle;
  internal double _dashOffset;
  internal double[] _dashPattern;
  internal bool _overprint;
  private bool _dirty = true;
  private readonly bool _immutable;

  public XPen(XColor color)
    : this(color, 1.0, false)
  {
  }

  public XPen(XColor color, double width)
    : this(color, width, false)
  {
  }

  internal XPen(XColor color, double width, bool immutable)
  {
    this._color = color;
    this._width = width;
    this._lineJoin = XLineJoin.Miter;
    this._lineCap = XLineCap.Flat;
    this._dashStyle = XDashStyle.Solid;
    this._dashOffset = 0.0;
    this._immutable = immutable;
  }

  public XPen(XPen pen)
  {
    this._color = pen._color;
    this._width = pen._width;
    this._lineJoin = pen._lineJoin;
    this._lineCap = pen._lineCap;
    this._dashStyle = pen._dashStyle;
    this._dashOffset = pen._dashOffset;
    this._dashPattern = pen._dashPattern;
    if (this._dashPattern == null)
      return;
    this._dashPattern = (double[]) this._dashPattern.Clone();
  }

  public XPen Clone() => new XPen(this);

  public XColor Color
  {
    get => this._color;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._color != value;
      this._color = value;
    }
  }

  public double Width
  {
    get => this._width;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._width != value;
      this._width = value;
    }
  }

  public XLineJoin LineJoin
  {
    get => this._lineJoin;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._lineJoin != value;
      this._lineJoin = value;
    }
  }

  public XLineCap LineCap
  {
    get => this._lineCap;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._lineCap != value;
      this._lineCap = value;
    }
  }

  public double MiterLimit
  {
    get => this._miterLimit;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._miterLimit != value;
      this._miterLimit = value;
    }
  }

  public XDashStyle DashStyle
  {
    get => this._dashStyle;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._dashStyle != value;
      this._dashStyle = value;
    }
  }

  public double DashOffset
  {
    get => this._dashOffset;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._dirty = this._dirty || this._dashOffset != value;
      this._dashOffset = value;
    }
  }

  public double[] DashPattern
  {
    get
    {
      if (this._dashPattern == null)
        this._dashPattern = new double[0];
      return this._dashPattern;
    }
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      int length = value.Length;
      for (int index = 0; index < length; ++index)
      {
        if (value[index] <= 0.0)
          throw new ArgumentException("Dash pattern value must greater than zero.");
      }
      this._dirty = true;
      this._dashStyle = XDashStyle.Custom;
      this._dashPattern = (double[]) value.Clone();
    }
  }

  public bool Overprint
  {
    get => this._overprint;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XPen)));
      this._overprint = value;
    }
  }
}
