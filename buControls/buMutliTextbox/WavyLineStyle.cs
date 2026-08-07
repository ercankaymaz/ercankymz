// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.WavyLineStyle
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buMutliTextbox;

public class WavyLineStyle : Style
{
  [CompilerGenerated]
  [SpecialName]
  internal Pen method_0() => this.pen_0;

  public WavyLineStyle(int alpha, Color color)
  {
    // ISSUE: reference to a compiler-generated method
    this.method_1(new Pen(Color.FromArgb(alpha, color)));
  }

  public override void Draw(Graphics gr, Point pos, Range range)
  {
    Size sizeOfRange = Style.GetSizeOfRange(range);
    Point point_0 = new Point(pos.X, pos.Y + sizeOfRange.Height - 1);
    Point point_1 = new Point(pos.X + sizeOfRange.Width, pos.Y + sizeOfRange.Height - 1);
    Class39.smethod_375(point_0, gr, point_1, this);
  }

  public override void Dispose()
  {
    base.Dispose();
    if (this.method_0() == null)
      return;
    this.method_0().Dispose();
  }
}
