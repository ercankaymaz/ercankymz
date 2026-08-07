// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.TrimMargins
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("(Left={left.Millimeter}mm, Right={right.Millimeter}mm, Top={top.Millimeter}mm, Bottom={bottom.Millimeter}mm)")]
public sealed class TrimMargins
{
  private XUnit _left;
  private XUnit _right;
  private XUnit _top;
  private XUnit _bottom;

  public XUnit All
  {
    set
    {
      this._left = value;
      this._right = value;
      this._top = value;
      this._bottom = value;
    }
  }

  public XUnit Left
  {
    get => this._left;
    set => this._left = value;
  }

  public XUnit Right
  {
    get => this._right;
    set => this._right = value;
  }

  public XUnit Top
  {
    get => this._top;
    set => this._top = value;
  }

  public XUnit Bottom
  {
    get => this._bottom;
    set => this._bottom = value;
  }

  public bool AreSet
  {
    get
    {
      return this._left.Value != 0.0 || this._right.Value != 0.0 || this._top.Value != 0.0 || this._bottom.Value != 0.0;
    }
  }
}
