// Decompiled with JetBrains decompiler
// Type: buMotion.AlarmActionSettings
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class AlarmActionSettings : buSerilization
{
  public Pnt6D MaxMachinePoint;
  public bool ProgramParameterFailure;
  public bool ProgramIOFailure;
  public static byte f0000D2;
  public AlarmWarningActionType WaterCheckAction;
  public AlarmWarningActionType WaterLeakAction;
  public AlarmWarningActionType PhaseErrorAction;
  public AlarmWarningActionType DoorSwitch;
  public AlarmWarningActionType AirPreasure;
  public AlarmWarningActionType HidroTermic;
  public AlarmWarningActionType XLimitAction;
  public AlarmWarningActionType YLimitAction;
  public AlarmWarningActionType ZLimitAction;
  public AlarmWarningActionType LubricateBlockAction;
  public AlarmWarningActionType LubricateLevelAction;
  public AlarmWarningActionType ToolNotAvailableAction;
  public AlarmWarningActionType ToolMissingAction;
  public AlarmWarningActionType SpindleDriveAction;
  public AlarmWarningActionType SawDriveAction;
  public AlarmWarningActionType SawWarmUp;
  public AlarmWarningActionType SpindleWarmUp;
  public AlarmWarningActionType XAxisMaintenance;
  public AlarmWarningActionType YAxisMaintenance;
  public AlarmWarningActionType ZAxisMaintenance;
  public AlarmWarningActionType AAxisMaintenance;
  public AlarmWarningActionType CAxisMaintenance;
  public AlarmWarningActionType HidroMotorMaintenance;
  public AlarmWarningActionType LubricateMaintenance;

  public AlarmActionSettings()
  {
    ((miscVars) this).WarningAvailable = false;
    ((miscVars) this).cntWarning = 0;
    ((miscVars) this).cntGeneralTick = 0;
    ((miscVars) this).cntCommunication = 0;
    ((miscVars) this).tickCameraImage = 0;
    ((miscVars) this).ImageCounter = 0;
    ((miscVars) this).StartLine = 0;
    ((miscVars) this).systemBool32BitValue = 0;
    ((miscVars) this).appBool32BitValue1 = 0;
    ((miscVars) this).appBool32BitValue2 = 0;
    ((miscVars) this).appBool32BitValue3 = 0;
    ((miscVars) this).appBool32BitValue4 = 0;
    ((miscVars) this).appBool16BitValue1 = 0;
    ((miscVars) this).appBool16BitValue2 = 0;
    ((miscVars) this).appBool16BitValue3 = 0;
    ((miscVars) this).appBool16BitValue4 = 0;
    ((miscVars) this).DIBool32BitValue1 = 0;
    ((miscVars) this).DIBool16BitValue1 = 0;
    ((miscVars) this).DOBool32BitValue1 = 0;
    ((miscVars) this).DOBool16BitValue1 = 0;
    ((miscVars) this).DIBool32BitValue2 = 0;
    ((miscVars) this).DIBool16BitValue2 = 0;
    ((miscVars) this).DOBool32BitValue2 = 0;
    ((miscVars) this).DOBool16BitValue2 = 0;
    ((miscVars) this).DIBool32BitValue3 = 0;
    ((miscVars) this).DIBool16BitValue3 = 0;
    ((miscVars) this).DOBool16BitValue3 = 0;
    ((miscVars) this).DOBool32BitValue4 = 0;
    ((miscVars) this).DIBool32BitValue4 = 0;
    ((miscVars) this).DIBool16BitValue4 = 0;
    ((miscVars) this).DOBool32BitValue3 = 0;
    ((miscVars) this).DOBool16BitValue4 = 0;
    ((miscVars) this).IsCNCViewportCreated = false;
    ((miscVars) this).IsCadCamViewportCreated = false;
    ((miscVars) this).IsDialogViewportCreated = false;
    ((miscVars) this).IsPreviewViewportCreated = false;
    ((miscVars) this).LoadedFileName = "";
    ((miscVars) this).ThreadCount = 0;
    ((miscVars) this).ThreadEnable = true;
    ((miscVars) this).InfoFlash = false;
    ((miscVars) this).indexInfo = -1;
    ((miscVars) this).TotalHour = 0.0;
    ((miscVars) this).TotalEnergizedHour = 0.0;
    ((miscVars) this).TotalAlarmHour = 0.0;
    ((miscVars) this).TotalRunHour = 0.0;
    ((miscVars) this).TotalFreeHour = 0.0;
    ((miscVars) this).MaintenanceLubricateHour = 0.0;
    ((miscVars) this).MaintenanceHydraulicHour = 0.0;
    ((miscVars) this).MaintenanceFanHour = 0.0;
    ((miscVars) this).MaintenanceCabinetHour = 0.0;
    ((miscVars) this).MaintenanceAirHour = 0.0;
    ((miscVars) this).MaintenanceMachineCleaningHour = 0.0;
    ((miscVars) this).TotalProducedCount = 0;
    ((miscVars) this).TotalStartCount = 0;
    ((miscVars) this).TotalAlarmCount = 0;
    ((miscVars) this).WarmUpSawPhase = 0;
    ((miscVars) this).WarmUpSpindlePhase = 0;
    ((miscVars) this).MinMachinePoint = new Pnt6D();
    this.MaxMachinePoint = new Pnt6D();
    this.ProgramParameterFailure = false;
    this.ProgramIOFailure = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public abstract void m000072();

  public AlarmActionSettings()
  {
    // ISSUE: unable to decompile the method.
  }

  public AlarmActionSettings(AlarmActionSettings data)
  {
    // ISSUE: unable to decompile the method.
  }
}
