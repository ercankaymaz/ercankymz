// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ColorDrawType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ColorDrawType : buSerilization5
{
  public string Explanation;
  public double Length;
  public double Height;

  public void InchToMm()
  {
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerXDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerXDistance * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerYDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerYDistance * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).MirrorData).MirrorDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).MirrorData).MirrorDistance * buSystem.InchToMmRatio, 5);
  }

  public override string ToString()
  {
    return $"Degree: {((ShapeRuntimeData) this).RotateDegree.ToString()} , Mirror : {((ShapeRuntimeData) ((ShapeRuntimeData) this).MirrorData).MirrorEnable.ToString()} , Lineer Array: {((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerEnable.ToString()} , Circular Array: {((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).CircularEnable.ToString()}";
  }

  public abstract void m000306();

  public ColorDrawType()
  {
    ((ShapeRuntimeData) this).CircularEnable = false;
    ((ShapeRuntimeData) this).CircularCount = 1;
    ((ShapeRuntimeData) this).CircularAngle = 45.0;
    ((ShapeRuntimeData) this).LineerEnable = false;
    ((ShapeRuntimeData) this).LineerXCount = 1;
    ((ShapeRuntimeData) this).LineerXDistance = 100.0;
    ((ShapeRuntimeData) this).LineerYCount = 1;
    ((ShapeRuntimeData) this).LineerYDistance = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
