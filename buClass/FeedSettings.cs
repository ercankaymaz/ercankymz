// Decompiled with JetBrains decompiler
// Type: buClass.FeedSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class FeedSettings : buSerilization
{
  public double FeedOverrideG0 = 100.0;
  public double FeedOverrideG1 = 100.0;
  public double FeedOverride = 100.0;
  public double FeedOverrideAxes = 100.0;
  public double FeedOverrideMin = 0.0;
  public double FeedOverrideMax = 100.0;
  public double FeedOverrideStep = 2.0;
  public bool FeedFromAnalogInput = false;
  public OverrideType FeedOverrideMode = OverrideType.Value;
  public static List<string> Captions = new List<string>();

  public FeedSettings()
  {
  }

  public FeedSettings(FeedSettings data)
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
    return $"FeedOverrideMin: {this.FeedOverrideMin.ToString()} , FeedOverrideMax : {this.FeedOverrideMax.ToString()}";
  }
}
