// Decompiled with JetBrains decompiler
// Type: buControls.Controls.rectDraw
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;

#nullable disable
namespace buControls.Controls;

public class rectDraw
{
  public RectangleF rect = new RectangleF();
  public RectangleF rectText = new RectangleF();
  public RoundRectangleType RoundType = RoundRectangleType.RoundRectAll;

  public rectDraw()
  {
  }

  public rectDraw(RectangleF rectt, RoundRectangleType round)
  {
    this.rect = new RectangleF(rectt.X, rectt.Y, rectt.Width, rectt.Height);
    this.rectText = new RectangleF(rectt.X, rectt.Y, rectt.Width, rectt.Height);
    this.RoundType = round;
  }
}
