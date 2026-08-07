// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camDistances5
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
public class camDistances5 : buSerilization5
{
  public ClockDirectionType SpindleDirection;
  public bool SpindleDirectionEnable;
  public double AreaClearance;
  public double Pocket;
  public bool AreaClearanceEnable;
  public static List<string> Captions;
  public static byte f000209;
  public bool Feed;
  public bool BackwardFeed;
  public bool Plunge;
  public bool Rapid;
  public bool Leave;
  public bool Finish;
  public static List<string> Captions;
  public static byte f000211;
  public double Safe;
  public double SafeSmall;
  public double FirstApproach;

  static camDistances5() => camSpeeds5.Captions = new List<string>();

  public camDistances5()
  {
    ((camSpeeds5) this).Feed = 100.0;
    ((camSpeeds5) this).FeedEnable = false;
    ((camSpeeds5) this).BackwardFeed = 100.0;
    ((camSpeeds5) this).BackwardEnable = false;
    ((camSpeeds5) this).Plunge = 20.0;
    ((camSpeeds5) this).PlungeEnable = false;
    ((camSpeeds5) this).Rapid = 500.0;
    ((camSpeeds5) this).RapidEnable = false;
    ((camSpeedsEnable) this).Leave = 300.0;
    ((camSpeedsEnable) this).LeaveEnable = false;
    ((camSpeedsEnable) this).Finish = 20.0;
    ((camSpeedsEnable) this).FinishEnable = false;
    ((camSpeedsEnable) this).FirstStep = 20.0;
    ((camSpeedsEnable) this).SpindleSpeed = 0.0;
    ((camSpeedsEnable) this).SpindleEnable = false;
    this.SpindleDirection = ClockDirectionType.CW;
    this.SpindleDirectionEnable = false;
    this.AreaClearance = 0.0;
    this.Pocket = 0.0;
    this.AreaClearanceEnable = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camDistances5(
    double feed,
    double plunge,
    double rapid,
    double leave,
    double backwardfeed,
    double finish)
  {
    ((camSpeeds5) this).Feed = 100.0;
    ((camSpeeds5) this).FeedEnable = false;
    ((camSpeeds5) this).BackwardFeed = 100.0;
    ((camSpeeds5) this).BackwardEnable = false;
    ((camSpeeds5) this).Plunge = 20.0;
    ((camSpeeds5) this).PlungeEnable = false;
    ((camSpeeds5) this).Rapid = 500.0;
    ((camSpeeds5) this).RapidEnable = false;
    ((camSpeedsEnable) this).Leave = 300.0;
    ((camSpeedsEnable) this).LeaveEnable = false;
    ((camSpeedsEnable) this).Finish = 20.0;
    ((camSpeedsEnable) this).FinishEnable = false;
    ((camSpeedsEnable) this).FirstStep = 20.0;
    ((camSpeedsEnable) this).SpindleSpeed = 0.0;
    ((camSpeedsEnable) this).SpindleEnable = false;
    this.SpindleDirection = ClockDirectionType.CW;
    this.SpindleDirectionEnable = false;
    this.AreaClearance = 0.0;
    this.Pocket = 0.0;
    this.AreaClearanceEnable = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camSpeeds5) this).Feed = feed;
    ((camSpeeds5) this).Plunge = plunge;
    ((camSpeeds5) this).Rapid = rapid;
    ((camSpeedsEnable) this).Leave = leave;
    ((camSpeeds5) this).BackwardFeed = backwardfeed;
    ((camSpeedsEnable) this).Finish = finish;
  }

  public camDistances5(camSpeeds5 speeds)
  {
    ((camSpeeds5) this).Feed = 100.0;
    ((camSpeeds5) this).FeedEnable = false;
    ((camSpeeds5) this).BackwardFeed = 100.0;
    ((camSpeeds5) this).BackwardEnable = false;
    ((camSpeeds5) this).Plunge = 20.0;
    ((camSpeeds5) this).PlungeEnable = false;
    ((camSpeeds5) this).Rapid = 500.0;
    ((camSpeeds5) this).RapidEnable = false;
    ((camSpeedsEnable) this).Leave = 300.0;
    ((camSpeedsEnable) this).LeaveEnable = false;
    ((camSpeedsEnable) this).Finish = 20.0;
    ((camSpeedsEnable) this).FinishEnable = false;
    ((camSpeedsEnable) this).FirstStep = 20.0;
    ((camSpeedsEnable) this).SpindleSpeed = 0.0;
    ((camSpeedsEnable) this).SpindleEnable = false;
    this.SpindleDirection = ClockDirectionType.CW;
    this.SpindleDirectionEnable = false;
    this.AreaClearance = 0.0;
    this.Pocket = 0.0;
    this.AreaClearanceEnable = false;
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

  public override string ToString()
  {
    return $"Feed: {((camSpeeds5) this).Feed.ToString()} , Plunge: {((camSpeeds5) this).Plunge.ToString()} , Rapid: {((camSpeeds5) this).Rapid.ToString()} , Leave: {((camSpeedsEnable) this).Leave.ToString()}";
  }
}
