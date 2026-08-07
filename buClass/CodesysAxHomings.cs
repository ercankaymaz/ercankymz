// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxHomings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxHomings : buSerilization
{
  public double homingFastVelocity = 10.0;
  public double homingSlowVelocity = 2.0;
  public double homingSetPosition = 0.0;
  public double homingOffset = 0.0;
  public double homingAcc = 2000.0;
  public double homingDec = 2000.0;
  public double homingJerk = 1000.0;
  public double homingDelay = 0.0;
  public double homingTimeoutSec = 120.0;
  public CodesysHomeMode homingMode = CodesysHomeMode.FAST_BSLOW_S_STOP;
  public CodesysHomeMethod homingMethod = CodesysHomeMethod.SMCHome;
  public int homingDriveHomeMode = 0;
  public bool homingReverseDir = false;
  public bool homingSwitchNC = false;
  public bool homingDisableLimits = true;
  public bool homingUseSecondSlowSpeed = false;
  public double homingAbsoluteHomePosition = 0.0;
  public static List<string> Captions = new List<string>();

  public CodesysAxHomings()
  {
  }

  public CodesysAxHomings(CodesysAxHomings data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    return $"Fast Vel: {this.homingFastVelocity.ToString()} , Slow Vel: {this.homingSlowVelocity.ToString()} , Set Pos: {this.homingSetPosition.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{$"{$"{$"{$"{this.homingFastVelocity.ToString()};{this.homingSlowVelocity.ToString()};{this.homingSetPosition.ToString()}"};{this.homingOffset.ToString()};{this.homingAcc.ToString()};{this.homingDec.ToString()}"};{this.homingJerk.ToString()};{this.homingDelay.ToString()};{this.homingTimeoutSec.ToString()}"};{this.homingMode.ToString()};{this.homingMethod.ToString()};{this.homingDriveHomeMode.ToString()}"};{this.homingAbsoluteHomePosition.ToString()};{buSerilization.BoolToString(this.homingReverseDir)};{buSerilization.BoolToString(this.homingSwitchNC)}"};{buSerilization.BoolToString(this.homingDisableLimits)};{buSerilization.BoolToString(this.homingUseSecondSlowSpeed)}";
  }
}
