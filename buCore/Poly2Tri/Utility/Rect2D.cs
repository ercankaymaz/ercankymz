// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Utility.Rect2D
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace Poly2Tri.Utility;

public struct Rect2D
{
  private readonly double double_0;
  private readonly double double_1;
  private readonly double double_2;
  private readonly double double_3;

  public double MinX => this.double_0;

  public double MaxX => this.double_1;

  public double MinY => this.double_2;

  public double MaxY => this.double_3;

  public double Left => this.double_0;

  public double Right => this.double_1;

  public double Top => this.double_3;

  public double Bottom => this.double_2;

  public double Width => this.Right - this.Left;

  public double Height => this.Top - this.Bottom;

  public bool IsEmpty
  {
    get
    {
      return Math.Abs(this.Width) < 1.4012984643248171E-45 || Math.Abs(this.Height) < 1.4012984643248171E-45;
    }
  }

  private Rect2D(double double_4, double double_5, double double_6, double double_7)
  {
    this.double_0 = double_4;
    this.double_1 = double_5;
    this.double_2 = double_6;
    this.double_3 = double_7;
  }

  public override int GetHashCode()
  {
    return 54734431 * this.double_0.GetHashCode() + 1122547711 * this.double_2.GetHashCode() + 1097393683 * this.double_1.GetHashCode() + 1198754321 * this.double_3.GetHashCode();
  }

  public override bool Equals(object obj) => obj is Rect2D rect2D_0 && this.method_0(rect2D_0);

  private bool method_0(Rect2D rect2D_0, double double_4 = 1E-12)
  {
    return MathUtil.AreValuesEqual(this.MinX, rect2D_0.MinX, double_4) && MathUtil.AreValuesEqual(this.MaxX, rect2D_0.MaxX, double_4) && MathUtil.AreValuesEqual(this.MinY, rect2D_0.MinY, double_4) && MathUtil.AreValuesEqual(this.MaxY, rect2D_0.MaxY, double_4);
  }

  public bool Intersects(Rect2D r)
  {
    return this.Right > r.Left && this.Left < r.Right && this.Bottom < r.Top && this.Top > r.Bottom;
  }

  public Rect2D AddPoint(Point2D p)
  {
    return new Rect2D(Math.Min(this.MinX, p.X), Math.Max(this.MaxX, p.X), Math.Min(this.MinY, p.Y), Math.Max(this.MaxY, p.Y));
  }
}
