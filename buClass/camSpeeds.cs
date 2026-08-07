// Decompiled with JetBrains decompiler
// Type: buClass.camSpeeds
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camSpeeds : buSerilization
{
  public double Feed = 100.0;
  public bool FeedEnable = false;
  public double BackwardFeed = 100.0;
  public bool BackwardEnable = false;
  public double Plunge = 20.0;
  public bool PlungeEnable = false;
  public double Rapid = 500.0;
  public bool RapidEnable = false;
  public double Leave = 300.0;
  public bool LeaveEnable = false;
  public double Finish = 20.0;
  public bool FinishEnable = false;
  public double SpindleSpeed = 0.0;
  public bool SpindleEnable = false;
  public ClockDirectionType SpindleDirection = ClockDirectionType.CW;
  public bool SpindleDirectionEnable = false;
  public double AreaClearance = 0.0;
  public bool AreaClearanceEnable = false;
  public static List<string> Captions = new List<string>();

  public camSpeeds()
  {
  }

  public camSpeeds(
    double feed,
    double plunge,
    double rapid,
    double leave,
    double backwardfeed,
    double finish)
  {
    this.Feed = feed;
    this.Plunge = plunge;
    this.Rapid = rapid;
    this.Leave = leave;
    this.BackwardFeed = backwardfeed;
    this.Finish = finish;
  }

  public camSpeeds(camSpeeds speeds)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) speeds, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return $"Feed: {this.Feed.ToString()} , Plunge: {this.Plunge.ToString()} , Rapid: {this.Rapid.ToString()} , Leave: {this.Leave.ToString()}";
  }
}
