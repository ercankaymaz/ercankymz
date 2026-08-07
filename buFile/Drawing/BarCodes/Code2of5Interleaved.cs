// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.Code2of5Interleaved
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public class Code2of5Interleaved : ThickThinBarCode
{
  private static bool[][] Lines = new bool[10][]
  {
    new bool[5]{ false, false, true, true, false },
    new bool[5]{ true, false, false, false, true },
    new bool[5]{ false, true, false, false, true },
    new bool[5]{ true, true, false, false, false },
    new bool[5]{ false, false, true, false, true },
    new bool[5]{ true, false, true, false, false },
    new bool[5]{ false, true, true, false, false },
    new bool[5]{ false, false, false, true, true },
    new bool[5]{ true, false, false, true, false },
    new bool[5]{ false, true, false, true, false }
  };

  public Code2of5Interleaved()
    : base("", XSize.Empty, CodeDirection.LeftToRight)
  {
  }

  public Code2of5Interleaved(string code)
    : base(code, XSize.Empty, CodeDirection.LeftToRight)
  {
  }

  public Code2of5Interleaved(string code, XSize size)
    : base(code, size, CodeDirection.LeftToRight)
  {
  }

  public Code2of5Interleaved(string code, XSize size, CodeDirection direction)
    : base(code, size, direction)
  {
  }

  private static bool[] ThickAndThinLines(int digit) => Code2of5Interleaved.Lines[digit];

  protected internal override void Render(
    XGraphics gfx,
    XBrush brush,
    XFont font,
    XPoint position)
  {
    XGraphicsState state = gfx.Save();
    BarCodeRenderInfo info = new BarCodeRenderInfo(gfx, brush, font, position);
    this.InitRendering(info);
    info.CurrPosInString = 0;
    info.CurrPos = position - CodeBase.CalcDistance(AnchorType.TopLeft, this.Anchor, this.Size);
    if (this.TurboBit)
      this.RenderTurboBit(info, true);
    this.RenderStart(info);
    while (info.CurrPosInString < this.Text.Length)
      this.RenderNextPair(info);
    this.RenderStop(info);
    if (this.TurboBit)
      this.RenderTurboBit(info, false);
    if (this.TextLocation != 0)
      this.RenderText(info);
    gfx.Restore(state);
  }

  internal override void CalcThinBarWidth(BarCodeRenderInfo info)
  {
    double num = 6.0 + this.WideNarrowRatio + (2.0 * this.WideNarrowRatio + 3.0) * (double) this.Text.Length;
    info.ThinBarWidth = this.Size.Width / num;
  }

  private void RenderStart(BarCodeRenderInfo info)
  {
    this.RenderBar(info, false);
    this.RenderGap(info, false);
    this.RenderBar(info, false);
    this.RenderGap(info, false);
  }

  private void RenderStop(BarCodeRenderInfo info)
  {
    this.RenderBar(info, true);
    this.RenderGap(info, false);
    this.RenderBar(info, false);
  }

  private void RenderNextPair(BarCodeRenderInfo info)
  {
    int index1 = int.Parse(this.Text[info.CurrPosInString].ToString());
    int index2 = int.Parse(this.Text[info.CurrPosInString + 1].ToString());
    bool[] line1 = Code2of5Interleaved.Lines[index1];
    bool[] line2 = Code2of5Interleaved.Lines[index2];
    for (int index3 = 0; index3 < 5; ++index3)
    {
      this.RenderBar(info, line1[index3]);
      this.RenderGap(info, line2[index3]);
    }
    info.CurrPosInString += 2;
  }

  protected override void CheckCode(string text)
  {
  }
}
