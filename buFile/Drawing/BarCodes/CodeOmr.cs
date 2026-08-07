// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.CodeOmr
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public class CodeOmr(string text, XSize size, CodeDirection direction) : BarCode(text, size, direction)
{
  private bool _synchronizeCode;
  private double _makerDistance = 12.0;
  private double _makerThickness = 1.0;

  protected internal override void Render(
    XGraphics gfx,
    XBrush brush,
    XFont font,
    XPoint position)
  {
    XGraphicsState state = gfx.Save();
    switch (this.Direction)
    {
      case CodeDirection.BottomToTop:
        gfx.RotateAtTransform(-90.0, position);
        break;
      case CodeDirection.RightToLeft:
        gfx.RotateAtTransform(180.0, position);
        break;
      case CodeDirection.TopToBottom:
        gfx.RotateAtTransform(90.0, position);
        break;
    }
    XPoint xpoint = position - CodeBase.CalcDistance(AnchorType.TopLeft, this.Anchor, this.Size);
    uint result;
    uint.TryParse(this.Text, out result);
    result |= 1U;
    this._synchronizeCode = true;
    if (this._synchronizeCode)
    {
      XRect rect = new XRect(xpoint.X, xpoint.Y, this._makerThickness, this.Size.Height);
      gfx.DrawRectangle(brush, rect);
      xpoint.X += 2.0 * this._makerDistance;
    }
    for (int index = 0; index < 32 /*0x20*/; ++index)
    {
      if (((int) result & 1) == 1)
      {
        XRect rect = new XRect(xpoint.X + (double) index * this._makerDistance, xpoint.Y, this._makerThickness, this.Size.Height);
        gfx.DrawRectangle(brush, rect);
      }
      result >>= 1;
    }
    gfx.Restore(state);
  }

  public bool SynchronizeCode
  {
    get => this._synchronizeCode;
    set => this._synchronizeCode = value;
  }

  public double MakerDistance
  {
    get => this._makerDistance;
    set => this._makerDistance = value;
  }

  public double MakerThickness
  {
    get => this._makerThickness;
    set => this._makerThickness = value;
  }

  protected override void CheckCode(string text)
  {
  }
}
