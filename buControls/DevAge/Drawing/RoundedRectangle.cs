// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.RoundedRectangle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DevAge.Drawing;

[Serializable]
public struct RoundedRectangle(Rectangle rect, double roundValue)
{
  private Rectangle mRectangle = rect;
  private double mRoundValue = roundValue;

  public Rectangle Rectangle
  {
    get => this.mRectangle;
    set => this.mRectangle = value;
  }

  public double RoundValue
  {
    get => this.mRoundValue;
    set
    {
      this.mRoundValue = (this.mRoundValue < 0.0 ? 1 : (this.mRoundValue > 1.0 ? 1 : 0)) == 0 ? value : throw new ApplicationException("Invalid value, must be a value from 0 to 1");
    }
  }

  public GraphicsPath ToGraphicsPath()
  {
    GraphicsPath graphicsPath1;
    if (this.mRectangle.IsEmpty)
    {
      graphicsPath1 = new GraphicsPath();
    }
    else
    {
      GraphicsPath graphicsPath2 = new GraphicsPath();
      if (this.mRoundValue == 0.0)
      {
        graphicsPath2.AddRectangle(this.mRectangle);
      }
      else
      {
        int x = this.mRectangle.X;
        int y = this.mRectangle.Y;
        int num1;
        int num2;
        if (this.mRectangle.Height < this.mRectangle.Width)
        {
          num1 = (int) ((double) this.mRectangle.Height * this.mRoundValue);
          num2 = num1 * 2;
        }
        else
        {
          num1 = (int) ((double) this.mRectangle.Width * this.mRoundValue);
          num2 = num1 * 2;
        }
        graphicsPath2.AddLine(num1 + x, y, this.mRectangle.Width - num1 + x, y);
        graphicsPath2.AddArc(this.mRectangle.Width - num2 + x, y, num2, num2, 270f, 90f);
        graphicsPath2.AddLine(this.mRectangle.Width + x, num1 + y, this.mRectangle.Width + x, this.mRectangle.Height - num1 + y);
        graphicsPath2.AddArc(this.mRectangle.Width - num2 + x, this.mRectangle.Height - num2 + y, num2, num2, 0.0f, 90f);
        graphicsPath2.AddLine(this.mRectangle.Width - num1 + x, this.mRectangle.Height + y, num1 + x, this.mRectangle.Height + y);
        graphicsPath2.AddArc(x, this.mRectangle.Height - num2 + y, num2, num2, 90f, 90f);
        graphicsPath2.AddLine(x, this.mRectangle.Height - num1 + y, x, num1 + y);
        graphicsPath2.AddArc(x, y, num2, num2, 180f, 90f);
      }
      graphicsPath1 = graphicsPath2;
    }
    return graphicsPath1;
  }
}
