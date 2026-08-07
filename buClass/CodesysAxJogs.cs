// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxJogs
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxJogs : buSerilization
{
  public double jogVelocity = 20.0;
  public double jogAcc = 1000.0;
  public double jogDec = 1000.0;
  public double jogJerk = 2500.0;
  public double jogFirstSpeedPersentage = 20.0;
  public double jogSecondSpeedPersentage = 50.0;
  public double jogFirstSpeedTimeSec = 0.0;
  public double jogSecondSpeedTimeSec = 0.0;
  public bool jogWithAbsoluteMove = false;
  public bool jogOverrideEnable = true;
  public bool jogDynamicVelocityFromFeed = false;
  public static List<string> Captions = new List<string>();

  public CodesysAxJogs()
  {
  }

  public CodesysAxJogs(CodesysAxJogs data)
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
    return $"Vel : {this.jogVelocity.ToString()} , Acc: {this.jogAcc.ToString()} , Dec: {this.jogDec.ToString()} , Jerk: {this.jogJerk.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{$"{$"{this.jogVelocity.ToString()};{this.jogAcc.ToString()};{this.jogDec.ToString()}"};{this.jogJerk.ToString()}"};{buSerilization.BoolToString(this.jogWithAbsoluteMove)};{buSerilization.BoolToString(this.jogOverrideEnable)}"};{buSerilization.BoolToString(this.jogDynamicVelocityFromFeed)}";
  }
}
