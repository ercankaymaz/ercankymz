// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camNotch5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camNotch5 : buSerilization5
{
  public bool RadiuFitFlag;
  public double SplineMaxDeviation;
  public bool AngleRangeEnable;
  public double AngleRangeSlopeAngleStart;

  public override string ToString() => ((camRotary5) this).TiltStrategy.ToString();

  static camNotch5() => camStrategy5.Captions = new List<string>();

  public camNotch5()
  {
    ((camStrategy5) this).CutStep = 5.0;
    ((camStrategy5) this).XDirectionLength = 1000.0;
    ((camStrategy5) this).YDirectionWidth = 500.0;
    ((camStrategy5) this).CornerPoint = new Pnt3D();
    ((camStrategy5) this).CuttingDirection = CamHatchCuttingDirection.XDirection;
    ((camStrategy5) this).CuttingModes = CamHatchCuttingMode.ForwardNextBackward;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
