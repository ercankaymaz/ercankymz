// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camMaterial5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camMaterial5 : buSerilization5
{
  public double RightSafeSmall;
  public double RightFirstApproach;
  public double RightStepUp;
  public double Air;
  public double Rapid;

  public override string ToString()
  {
    return $"Feed: {((camDistances5) this).Feed.ToString()} , Plunge: {((camDistances5) this).Plunge.ToString()} , Rapid: {((camDistances5) this).Rapid.ToString()} , Leave: {((camDistances5) this).Leave.ToString()}";
  }

  static camMaterial5() => camDistances5.Captions = new List<string>();

  public camMaterial5()
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
    this.RightSafeSmall = 80.0;
    this.RightFirstApproach = 20.0;
    this.RightStepUp = 20.0;
    this.Air = 500.0;
    this.Rapid = 100.0;
    ((camDrill5) this).EntryAndExit = 100.0;
    ((camDrill5) this).IncrementalSafe = false;
    ((camDrill5) this).RapidRetract = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camMaterial5(double safe, double stepup, double air, bool increemntalsafe)
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
    this.RightSafeSmall = 80.0;
    this.RightFirstApproach = 20.0;
    this.RightStepUp = 20.0;
    this.Air = 500.0;
    this.Rapid = 100.0;
    ((camDrill5) this).EntryAndExit = 100.0;
    ((camDrill5) this).IncrementalSafe = false;
    ((camDrill5) this).RapidRetract = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camDistances5) this).Safe = safe;
    ((camHole5) this).StepUp = stepup;
    this.Air = air;
    ((camDrill5) this).IncrementalSafe = increemntalsafe;
  }
}
