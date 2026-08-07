// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.ThickThinBarCode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public abstract class ThickThinBarCode : BarCode
{
  private double _wideNarrowRatio = 2.6;

  public ThickThinBarCode(string code, XSize size, CodeDirection direction)
    : base(code, size, direction)
  {
  }

  internal override void InitRendering(BarCodeRenderInfo info)
  {
    base.InitRendering(info);
    this.CalcThinBarWidth(info);
    info.BarHeight = this.Size.Height;
    if (this.TextLocation != 0)
      info.BarHeight *= 0.8;
    switch (this.Direction)
    {
      case CodeDirection.BottomToTop:
        info.Gfx.RotateAtTransform(-90.0, info.Position);
        break;
      case CodeDirection.RightToLeft:
        info.Gfx.RotateAtTransform(180.0, info.Position);
        break;
      case CodeDirection.TopToBottom:
        info.Gfx.RotateAtTransform(90.0, info.Position);
        break;
    }
  }

  public override double WideNarrowRatio
  {
    get => this._wideNarrowRatio;
    set
    {
      this._wideNarrowRatio = (value > 3.0 ? 1 : (value < 2.0 ? 1 : 0)) == 0 ? value : throw new ArgumentOutOfRangeException(nameof (value), BcgSR.Invalid2of5Relation);
    }
  }

  internal void RenderBar(BarCodeRenderInfo info, bool isThick)
  {
    double barWidth = this.GetBarWidth(info, isThick);
    double height = this.Size.Height;
    double x = info.CurrPos.X;
    double y = info.CurrPos.Y;
    switch (this.TextLocation)
    {
      case TextLocation.AboveEmbedded:
        height -= info.Gfx.MeasureString(this.Text, info.Font).Height;
        y += info.Gfx.MeasureString(this.Text, info.Font).Height;
        break;
      case TextLocation.BelowEmbedded:
        height -= info.Gfx.MeasureString(this.Text, info.Font).Height;
        break;
    }
    XRect rect = new XRect(x, y, barWidth, height);
    info.Gfx.DrawRectangle(info.Brush, rect);
    info.CurrPos.X += barWidth;
  }

  internal void RenderGap(BarCodeRenderInfo info, bool isThick)
  {
    info.CurrPos.X += this.GetBarWidth(info, isThick);
  }

  internal void RenderTurboBit(BarCodeRenderInfo info, bool startBit)
  {
    if (startBit)
      info.CurrPos.X -= 0.5 + this.GetBarWidth(info, true);
    else
      info.CurrPos.X += 0.5;
    this.RenderBar(info, true);
    if (!startBit)
      return;
    info.CurrPos.X += 0.5;
  }

  internal void RenderText(BarCodeRenderInfo info)
  {
    XSize xsize;
    if (info.Font == null)
    {
      BarCodeRenderInfo barCodeRenderInfo = info;
      xsize = this.Size;
      XFont xfont = new XFont("Courier New", xsize.Height / 6.0);
      barCodeRenderInfo.Font = xfont;
    }
    XPoint location = info.Position + CodeBase.CalcDistance(this.Anchor, AnchorType.TopLeft, this.Size);
    switch (this.TextLocation)
    {
      case TextLocation.Above:
        ref XPoint local1 = ref location;
        double x1 = location.X;
        double y1 = location.Y;
        xsize = info.Gfx.MeasureString(this.Text, info.Font);
        double height = xsize.Height;
        double y2 = y1 - height;
        local1 = new XPoint(x1, y2);
        info.Gfx.DrawString(this.Text, info.Font, info.Brush, new XRect(location, this.Size), XStringFormats.TopCenter);
        break;
      case TextLocation.Below:
        ref XPoint local2 = ref location;
        double x2 = location.X;
        xsize = info.Gfx.MeasureString(this.Text, info.Font);
        double y3 = xsize.Height + location.Y;
        local2 = new XPoint(x2, y3);
        info.Gfx.DrawString(this.Text, info.Font, info.Brush, new XRect(location, this.Size), XStringFormats.BottomCenter);
        break;
      case TextLocation.AboveEmbedded:
        info.Gfx.DrawString(this.Text, info.Font, info.Brush, new XRect(location, this.Size), XStringFormats.TopCenter);
        break;
      case TextLocation.BelowEmbedded:
        info.Gfx.DrawString(this.Text, info.Font, info.Brush, new XRect(location, this.Size), XStringFormats.BottomCenter);
        break;
    }
  }

  internal double GetBarWidth(BarCodeRenderInfo info, bool isThick)
  {
    return !isThick ? info.ThinBarWidth : info.ThinBarWidth * this._wideNarrowRatio;
  }

  internal abstract void CalcThinBarWidth(BarCodeRenderInfo info);
}
