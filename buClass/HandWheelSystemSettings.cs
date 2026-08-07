// Decompiled with JetBrains decompiler
// Type: buClass.HandWheelSystemSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class HandWheelSystemSettings : buSerilization
{
  public bool Enable = true;
  public double HandwheelPosFilterFactor = 0.2;
  public bool HandwheelPosUseAvarage = false;
  public int HandwheelPosAvarageCount = 10;
  public bool HandwheelPosUseFilterFactor = false;
  public int HandwheelVelAvarageCount = 50;
  public double stepFeedRateEncoderPulse = 5.0;
  public double stepSpindleRateEncoderPulse = 5.0;
  public double stepGCodeLinesEncoderPulse = 5.0;
  public double FeedOverrideCalibration = 0.1;
  public static List<string> Captions = new List<string>();

  public HandWheelSystemSettings()
  {
  }

  public HandWheelSystemSettings(HandWheelSystemSettings data)
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

  public override string ToString() => "Enable: " + this.Enable.ToString();
}
