// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Spinning.SpinPatternRuntime
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5.Spinning;

[Serializable]
public class SpinPatternRuntime : buSerilization
{
  public Point3D pntLeaveArcMid = new Point3D();
  public Point3D pntLeaveArcEnd = new Point3D();
  public Point3D pntCurveStart = new Point3D();
  public Point3D pntCurveEnd = new Point3D();
  public Point3D pntCurveFinishStart = new Point3D();
  public Point3D pntCurveFinishEnd = new Point3D();
  public Point3D pntSameWayReturn = new Point3D();
  public Point3D pntLastCalc = new Point3D();
  public bool isLastSpin = false;
  public bool isFinish = false;
  public double DirectionAngle = 0.0;

  public SpinPatternRuntime()
  {
  }

  public SpinPatternRuntime(SpinPatternRuntime data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
