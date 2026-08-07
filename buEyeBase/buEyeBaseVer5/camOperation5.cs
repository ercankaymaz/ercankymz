// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camOperation5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camOperation5 : buSerilization5
{
  public bool Enable;
  public bool PeckMode;
  public bool PeckFullRetract;
  public bool IncremantalRotation;
  public double StartHeight;
  public double EndHeight;
  public double StartAngle;
  public double EndAngle;
  public double PeckDepth;
  public double PeckMinRetractDistance;
  public static List<string> Captions;
  public static byte f00023D;
  public bool Enable;
  public bool UsePoints;
  public double StepOverPersentage;
  public CamPocketType PocketType;
  public InToOutType PocketInOut;
  public bool SharpCorner;
  public static List<string> Captions;
  public static byte f000245;
  public double Height;
  public double Depth;
  public double DepthUp;
  public double Width;
  public double BaseThickness;
  public double Overlap;
  public double Stepover;
  public double SurfaceOffset;
  public bool FinishEnable;
  public bool AreaClearanceEnable;

  public camOperation5(camMaterial5 distance)
  {
    ((camPocket5) this).Thickness = 2.0;
    ((camPocket5) this).StartZ = 0.0;
    ((camPocket5) this).MaxPoint = new Pnt3D();
    ((camPocket5) this).MinPoint = new Pnt3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) distance, ref CopiedClass);
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

  public override string ToString()
  {
    return $"Thickness: {((camPocket5) this).Thickness.ToString()} , StartZ: {((camPocket5) this).StartZ.ToString()}";
  }

  static camOperation5() => camPocket5.Captions = new List<string>();

  public camOperation5() => ((pageInfo) this).\u002Ector();

  public camOperation5(camDrill5 distance)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) distance, ref CopiedClass);
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
