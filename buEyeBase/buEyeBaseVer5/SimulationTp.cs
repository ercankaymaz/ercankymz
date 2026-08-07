// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SimulationTp
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SimulationTp : buSerilization5
{
  public double Radius;
  public double Length;
  public double SweepAngle;
  public double StartAngle;
  public double EndAngle;

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{((TpArcData) this).P9.X.ToString()}; Y:{((TpArcData) this).P9.Y.ToString()}; Z:{((TpArcData) this).P9.Z.ToString()}; A:{((TpArcData) this).P9.A.ToString()}; B:{((TpArcData) this).P9.B.ToString()}; C:{((TpArcData) this).P9.C.ToString()}; U:{((TpArcData) this).P9.U.ToString()}; V:{((TpArcData) this).P9.V.ToString()}; W:{((TpArcData) this).P9.W.ToString()}";
  }

  public abstract void m0000EA();

  public SimulationTp()
  {
    ((TpArcData) this).StartPoint = new Point3D();
    ((TpArcData) this).EndPoint = new Point3D();
    ((TpArcData) this).CenterPoint = new Point3D();
    this.Radius = 0.0;
    this.Length = 0.0;
    this.SweepAngle = 0.0;
    this.StartAngle = 0.0;
    this.EndAngle = 0.0;
    ((camParameters5) this).isCW = false;
    ((camParameters5) this).isReverse = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
