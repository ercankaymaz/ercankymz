// Decompiled with JetBrains decompiler
// Type: buMotion.miscVars
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class miscVars : buSerilization
{
  public int AlarmListCountPre;
  public int WarningCountPre;
  public int WarningListCountPre;
  public bool WarningAvailable;
  public int cntWarning;
  public int cntGeneralTick;
  public int cntCommunication;
  public int tickCameraImage;
  public int ImageCounter;
  public int StartLine;
  public int systemBool32BitValue;
  public int appBool32BitValue1;
  public int appBool32BitValue2;
  public int appBool32BitValue3;
  public int appBool32BitValue4;
  public int appBool16BitValue1;
  public int appBool16BitValue2;
  public int appBool16BitValue3;
  public int appBool16BitValue4;
  public int DIBool32BitValue1;
  public int DIBool16BitValue1;
  public int DOBool32BitValue1;
  public int DOBool16BitValue1;
  public int DIBool32BitValue2;
  public int DIBool16BitValue2;
  public int DOBool32BitValue2;
  public int DOBool16BitValue2;
  public int DIBool32BitValue3;
  public int DIBool16BitValue3;
  public int DOBool16BitValue3;
  public int DOBool32BitValue4;
  public int DIBool32BitValue4;
  public int DIBool16BitValue4;
  public int DOBool32BitValue3;
  public int DOBool16BitValue4;
  public bool IsCNCViewportCreated;
  public bool IsCadCamViewportCreated;
  public bool IsDialogViewportCreated;
  public bool IsPreviewViewportCreated;
  public string LoadedFileName;
  public int ThreadCount;
  public bool ThreadEnable;
  public bool InfoFlash;
  public int indexInfo;
  public double TotalHour;
  public double TotalEnergizedHour;
  public double TotalAlarmHour;
  public double TotalRunHour;
  public double TotalFreeHour;
  public double MaintenanceLubricateHour;
  public double MaintenanceHydraulicHour;
  public double MaintenanceFanHour;
  public double MaintenanceCabinetHour;
  public double MaintenanceAirHour;
  public double MaintenanceMachineCleaningHour;
  public int TotalProducedCount;
  public int TotalStartCount;
  public int TotalAlarmCount;
  public int WarmUpSawPhase;
  public int WarmUpSpindlePhase;
  public Pnt6D MinMachinePoint;

  public miscVars()
  {
    ((preBoolVars) this).ParWriting = false;
    ((preBoolVars) this).Start = false;
    ((preBoolVars) this).Stop = false;
    ((preBoolVars) this).Pause = false;
    ((preBoolVars) this).Warning = false;
    ((preBoolVars) this).Alarm = false;
    ((preBoolVars) this).Saw = false;
    ((preBoolVars) this).Spindle = false;
    ((preBoolVars) this).AlarmCountPre = 0;
    this.AlarmListCountPre = 0;
    this.WarningCountPre = 0;
    this.WarningListCountPre = 0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
