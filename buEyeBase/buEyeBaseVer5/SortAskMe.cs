// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortAskMe
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortAskMe : buSerilization5
{
  public MaterialShapes Shapes;
  public MaterialPurpose Purpose;
  public bool Enable;
  public double Angle;
  public double Radius;
  public double Diameter;
  public double MajorRadius;
  public double MinorRadius;
  public double RoundRadiue;
  public double ChamferLength;
  public double dX;
  public double dY;

  public SortAskMe(double a, double b, double c)
  {
    ((ViewportSettings) this).A = 0.0;
    ((ViewportSettings) this).B = 0.0;
    ((ViewportSettings) this).C = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportSettings) this).A = a;
    ((ViewportSettings) this).B = b;
    ((ViewportSettings) this).C = c;
  }
}
