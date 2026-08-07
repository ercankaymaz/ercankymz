// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.BarCodeRenderInfo
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

internal class BarCodeRenderInfo
{
  public XGraphics Gfx;
  public XBrush Brush;
  public XFont Font;
  public XPoint Position;
  public double BarHeight;
  public XPoint CurrPos;
  public int CurrPosInString;
  public double ThinBarWidth;

  public BarCodeRenderInfo(XGraphics gfx, XBrush brush, XFont font, XPoint position)
  {
    this.Gfx = gfx;
    this.Brush = brush;
    this.Font = font;
    this.Position = position;
  }
}
