// Decompiled with JetBrains decompiler
// Type: buMotion.typeMinMaxXYZ
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class typeMinMaxXYZ : buSerilization
{
  public bool InputPosLimit;
  public bool InputCapture;
  public bool DistanceToGo;
  public double MinX;
  public double MinY;
  public double MinZ;

  public typeMinMaxXYZ(
    bool position,
    bool offsetedposition,
    bool followerror,
    bool vel,
    bool current,
    bool enabled,
    bool homingdone,
    bool standstill,
    bool axiserror,
    bool commok,
    bool inphome,
    bool inpneglimit,
    bool inpposlimit,
    bool inpcapture)
  {
    ((ReadAxisDataBits) this).Position = false;
    ((ReadAxisDataBits) this).OffsetedPosition = false;
    ((ReadAxisDataBits) this).FollowingError = false;
    ((ReadAxisDataBits) this).Velocity = false;
    ((ReadAxisDataBits) this).Current = false;
    ((ReadAxisDataBits) this).Enabled = false;
    ((ReadAxisDataBits) this).HomingDone = false;
    ((ReadAxisDataBits) this).StandStill = false;
    ((ReadAxisDataBits) this).AxisError = false;
    ((ReadAxisDataBits) this).CommOk = false;
    ((ReadAxisDataBits) this).InputHoming = false;
    ((ReadAxisDataBits) this).InputNegLimit = false;
    this.InputPosLimit = false;
    this.InputCapture = false;
    this.DistanceToGo = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((ReadAxisDataBits) this).Position = position;
    ((ReadAxisDataBits) this).OffsetedPosition = offsetedposition;
    ((ReadAxisDataBits) this).FollowingError = followerror;
    ((ReadAxisDataBits) this).Velocity = vel;
    ((ReadAxisDataBits) this).Current = current;
    ((ReadAxisDataBits) this).Enabled = enabled;
    ((ReadAxisDataBits) this).HomingDone = homingdone;
    ((ReadAxisDataBits) this).StandStill = standstill;
    ((ReadAxisDataBits) this).AxisError = axiserror;
    ((ReadAxisDataBits) this).CommOk = commok;
    ((ReadAxisDataBits) this).InputHoming = inphome;
    ((ReadAxisDataBits) this).InputNegLimit = inpneglimit;
    this.InputPosLimit = inpposlimit;
    this.InputCapture = inpcapture;
  }
}
