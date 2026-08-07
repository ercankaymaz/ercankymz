// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.DoublePoint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace buCore.buClipperLib;

public struct DoublePoint
{
  public double X;
  public double Y;

  public DoublePoint(double x = 0.0, double y = 0.0)
  {
    this.X = x;
    this.Y = y;
  }

  public DoublePoint(DoublePoint dp)
  {
    this.X = dp.X;
    this.Y = dp.Y;
  }

  public DoublePoint(IntPoint ip)
  {
    this.X = (double) ip.X;
    this.Y = (double) ip.Y;
  }
}
