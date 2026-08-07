// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.IntPoint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace buCore.buClipperLib;

public struct IntPoint
{
  public long X;
  public long Y;
  public long Z;

  public IntPoint(long x, long y, long z = 0)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
  }

  public IntPoint(double x, double y, double z = 0.0)
  {
    this.X = (long) x;
    this.Y = (long) y;
    this.Z = (long) z;
  }

  public IntPoint(DoublePoint dp)
  {
    this.X = (long) dp.X;
    this.Y = (long) dp.Y;
    this.Z = 0L;
  }

  public IntPoint(IntPoint pt)
  {
    this.X = pt.X;
    this.Y = pt.Y;
    this.Z = pt.Z;
  }

  public static bool operator ==(IntPoint a, IntPoint b) => a.X == b.X && a.Y == b.Y;

  public static bool operator !=(IntPoint a, IntPoint b) => a.X != b.X || a.Y != b.Y;

  public override bool Equals(object obj)
  {
    return obj != null && obj is IntPoint intPoint && this.X == intPoint.X && this.Y == intPoint.Y;
  }

  public override int GetHashCode() => base.GetHashCode();
}
