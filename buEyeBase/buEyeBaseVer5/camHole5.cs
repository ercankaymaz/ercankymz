// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camHole5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camHole5 : buSerilization5
{
  public double StepUp;
  public double LeftSafe;
  public double LeftSafeSmall;
  public double LeftFirstApproach;
  public double LeftStepUp;
  public double RightSafe;

  static camHole5() => camDistances5.Captions = new List<string>();

  public camHole5()
  {
    ((camDistances5) this).Feed = true;
    ((camDistances5) this).BackwardFeed = false;
    ((camDistances5) this).Plunge = true;
    ((camDistances5) this).Rapid = false;
    ((camDistances5) this).Leave = true;
    ((camDistances5) this).Finish = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camHole5(
    bool feed,
    bool plunge,
    bool rapid,
    bool leave,
    bool backwardfeed,
    bool finish)
  {
    ((camDistances5) this).Feed = true;
    ((camDistances5) this).BackwardFeed = false;
    ((camDistances5) this).Plunge = true;
    ((camDistances5) this).Rapid = false;
    ((camDistances5) this).Leave = true;
    ((camDistances5) this).Finish = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camDistances5) this).Feed = feed;
    ((camDistances5) this).Plunge = plunge;
    ((camDistances5) this).Rapid = rapid;
    ((camDistances5) this).Leave = leave;
    ((camDistances5) this).BackwardFeed = backwardfeed;
    ((camDistances5) this).Finish = finish;
  }

  public camHole5(camSpeedsEnable speeds)
  {
    ((camDistances5) this).Feed = true;
    ((camDistances5) this).BackwardFeed = false;
    ((camDistances5) this).Plunge = true;
    ((camDistances5) this).Rapid = false;
    ((camDistances5) this).Leave = true;
    ((camDistances5) this).Finish = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) speeds, ref CopiedClass);
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
