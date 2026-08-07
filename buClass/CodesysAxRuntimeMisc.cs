// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxRuntimeMisc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxRuntimeMisc : buSerilization
{
  public double AbsolutePosition;
  public double IncrementalPosition;
  public double maintenanceTotalMeter = 0.0;
  public double measureTotalHour = 0.0;
  public double measureTotalAlarmdHour = 0.0;
  public double measureTotalEnergizedHour = 0.0;
  public double measureMaxCurrent = 0.0;
  public double measureMaxVelocity = 0.0;
  public double measureTotalTravelMeter = 0.0;
  public double measureTotalTravelMeterRun = 0.0;
  public double measureTotalTravelMeterFree = 0.0;
  public double measureTotalTravelMeterNoEnable = 0.0;
  public int measureTotalAlarmCount = 0;
  public int measureTotalEnableCount = 0;
  public string AxisNotAllowMessage = "";

  public CodesysAxRuntimeMisc()
  {
  }

  public CodesysAxRuntimeMisc(CodesysAxRuntimeMisc data)
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
    return $"AbsolutePosition: {this.AbsolutePosition.ToString()} , IncrementalPosition: {this.IncrementalPosition.ToString()}";
  }
}
