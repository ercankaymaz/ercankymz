// Decompiled with JetBrains decompiler
// Type: buClass.Apps.XRayPointData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass.Apps;

public class XRayPointData : buSerilization
{
  public double X = 0.0;
  public double Y = 0.0;
  public double Z = 0.0;
  public double A = 0.0;
  public double C = 0.0;
  public XRayData XRay = new XRayData();
  public bool Enable = true;

  public XRayPointData()
  {
  }

  public XRayPointData(double x, double y, double z, bool enable, XRayData xray)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.Enable = enable;
    this.XRay = new XRayData(xray);
  }

  public XRayPointData(
    double x,
    double y,
    double z,
    double a,
    double c,
    bool enable,
    XRayData xray)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.C = c;
    this.Enable = enable;
    this.XRay = new XRayData(xray);
  }

  public XRayPointData(XRayPointData data)
  {
    this.X = data.X;
    this.Y = data.Y;
    this.Z = data.Z;
    this.C = data.C;
    this.A = data.A;
    this.Enable = data.Enable;
    this.XRay = new XRayData(data.XRay);
  }
}
