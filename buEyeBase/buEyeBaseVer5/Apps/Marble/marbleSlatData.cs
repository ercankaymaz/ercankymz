// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSlatData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSlatData : buSerilization5
{
  public double RoughMinZ;
  public double RoughCOffsetAngle;
  public double RoughLeadInAngle;
  public double RoughLeadOutAngle;
  public double RoughStep;
  public double RoughTopOffset;
  public double RoughBottomOffset;
  public double RoughInsideOffset;
  public double RoughOutsideOffset;
  public double RoughZForwardDownStep;

  public marbleSlatData()
  {
  }

  internal double \u0001([In] (double, double) obj0) => obj0.Item1;

  public marbleSlatData()
  {
  }

  internal (double, double) \u0001([In] buEntity obj0)
  {
    double val1 = Vector3D.Dot(((MarbleProgramSettings) this).\u0001, ((CustomData) obj0).StartPoint);
    double val2 = Vector3D.Dot(((MarbleProgramSettings) this).\u0001, ((CustomData) obj0).EndPoint);
    return (Math.Min(val1, val2), Math.Max(val1, val2));
  }
}
