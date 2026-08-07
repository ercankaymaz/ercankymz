// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XSolidBrush
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XSolidBrush : XBrush
{
  internal XColor _color;
  internal bool _overprint;
  private readonly bool _immutable;

  public XSolidBrush()
  {
  }

  public XSolidBrush(XColor color)
    : this(color, false)
  {
  }

  internal XSolidBrush(XColor color, bool immutable)
  {
    this._color = color;
    this._immutable = immutable;
  }

  public XSolidBrush(XSolidBrush brush) => this._color = brush.Color;

  public XColor Color
  {
    get => this._color;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XSolidBrush)));
      this._color = value;
    }
  }

  public bool Overprint
  {
    get => this._overprint;
    set
    {
      if (this._immutable)
        throw new ArgumentException(PSSR.CannotChangeImmutableObject(nameof (XSolidBrush)));
      this._overprint = value;
    }
  }
}
