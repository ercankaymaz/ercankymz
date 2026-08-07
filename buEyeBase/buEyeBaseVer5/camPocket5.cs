// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camPocket5
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
public class camPocket5 : buSerilization5
{
  public static byte f00022B;
  public double Thickness;
  public double StartZ;
  public Pnt3D MaxPoint;
  public Pnt3D MinPoint;
  public static List<string> Captions;
  public static byte f000231;

  public camPocket5(camHole5 distance)
  {
    ((camDrill5) this).StartHeight = 100.0;
    ((camDrill5) this).EndHeight = 80.0;
    ((camDrill5) this).DownStep = 2.0;
    ((camDrill5) this).UpStep = 1.0;
    ((camDrill5) this).HoleType = grindingHoleType.UpDownByStep;
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
    return $"StartHeight: {((camDrill5) this).StartHeight.ToString()} , EndHeight: {((camDrill5) this).EndHeight.ToString()} , DownStep: {((camDrill5) this).DownStep.ToString()} , HoleType: {((camDrill5) this).HoleType.ToString()}";
  }

  static camPocket5() => camDrill5.Captions = new List<string>();

  public camPocket5() => ((pageInfo) this).\u002Ector();
}
