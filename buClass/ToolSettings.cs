// Decompiled with JetBrains decompiler
// Type: buClass.ToolSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolSettings : buSerilization
{
  public double toolClamperOpenTimeSec = 1.0;
  public double toolClamperCloseTimeSec = 1.0;
  public double toolChangeFastVelocity = 20.0;
  public double toolChangeSlowVelocity = 10.0;
  public double toolChangeTimeOutSec = 120.0;
  public double toolChangeWaitTimeSec = 1000.0;
  public double toolChangeBrokenToolLimit = 1.0;
  public double toolMeasureTimeOutSec = 120.0;
  public double toolMeasureLengthConstant = 100.0;
  public double toolMeasureFastVelocity = 20.0;
  public double toolMeasureSlowVelocity = 10.0;
  public bool btoolMeasureLengthBeforeLeave = false;
  public bool btoolMeasureLengthAfterTake = false;
  public double toolBrokenToolControlDistance = 0.1;
  public static List<string> Captions = new List<string>();

  public ToolSettings()
  {
  }

  public ToolSettings(ToolSettings data)
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
    return "toolMeasureFastVelocity: " + this.toolMeasureFastVelocity.ToString();
  }
}
