// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camDrill5
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
public class camDrill5 : buSerilization5
{
  public double EntryAndExit;
  public bool IncrementalSafe;
  public bool RapidRetract;
  public static List<string> Captions = new List<string>();
  public static byte f000224;
  public double StartHeight;
  public double EndHeight;
  public double DownStep;
  public double UpStep;
  public grindingHoleType HoleType;
  public static List<string> Captions;

  public camDrill5(camDistances5 distance)
  {
    ((camDistances5) this).Safe = 100.0;
    ((camDistances5) this).SafeSmall = 80.0;
    ((camDistances5) this).FirstApproach = 20.0;
    ((camHole5) this).StepUp = 20.0;
    ((camHole5) this).LeftSafe = 100.0;
    ((camHole5) this).LeftSafeSmall = 80.0;
    ((camHole5) this).LeftFirstApproach = 20.0;
    ((camHole5) this).LeftStepUp = 20.0;
    ((camHole5) this).RightSafe = 100.0;
    ((camMaterial5) this).RightSafeSmall = 80.0;
    ((camMaterial5) this).RightFirstApproach = 20.0;
    ((camMaterial5) this).RightStepUp = 20.0;
    ((camMaterial5) this).Air = 500.0;
    ((camMaterial5) this).Rapid = 100.0;
    this.EntryAndExit = 100.0;
    this.IncrementalSafe = false;
    this.RapidRetract = false;
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
    return $"Safe: {((camDistances5) this).Safe.ToString()} , StepUp: {((camHole5) this).StepUp.ToString()} , Air: {((camMaterial5) this).Air.ToString()} , IncrementalSafe: {this.IncrementalSafe.ToString()}";
  }

  public camDrill5() => ((pageInfo) this).\u002Ector();
}
