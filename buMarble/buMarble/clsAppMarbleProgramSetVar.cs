// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleProgramSetVar
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buEyeBaseVer5;
using System;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleProgramSetVar : buSerilization5
{
  static clsAppMarbleProgramSetVar()
  {
    clsAppMarbleIOVar.ME_XPlus = new clsAppMarbleIODef("ME_XPlus");
    clsAppMarbleIOVar.ME_XMinus = new clsAppMarbleIODef("ME_XMinus");
    clsAppMarbleIOVar.ME_YPlus = new clsAppMarbleIODef("ME_YPlus");
    clsAppMarbleIOVar.ME_YMinus = new clsAppMarbleIODef("ME_YMinus");
    clsAppMarbleIOVar.ME_ZPlus = new clsAppMarbleIODef("ME_ZPlus");
    clsAppMarbleIOVar.ME_ZMinus = new clsAppMarbleIODef("ME_ZMinus");
    clsAppMarbleIOVar.ME_CPlus = new clsAppMarbleIODef("ME_CPlus");
    clsAppMarbleIOVar.ME_CMinus = new clsAppMarbleIODef("ME_CMinus");
    clsAppMarbleIOVar.ME_APlus = new clsAppMarbleIODef("ME_APlus");
    clsAppMarbleIOVar.ME_AMinus = new clsAppMarbleIODef("ME_AMinus");
    clsAppMarbleIOVar.ME_CycleStart = new clsAppMarbleIODef("ME_CycleStart");
    clsAppMarbleIOVar.ME_CycleStop = new clsAppMarbleIODef("ME_CycleStop");
    clsAppMarbleIOVar.ME_SystemStart = new clsAppMarbleIODef("ME_SystemStart");
    clsAppMarbleIOVar.ME_SystemStop = new clsAppMarbleIODef("ME_SystemStop");
    clsAppMarbleIOVar.ME_ResetButton = new clsAppMarbleIODef("ME_ResetButton");
    clsAppMarbleIOVar.ME_Emergency = new clsAppMarbleIODef("ME_Emergency");
    clsAppMarbleIOVar.ME_Auto = new clsAppMarbleIODef("ME_Auto");
    clsAppMarbleIOVar.ME_LaserButton = new clsAppMarbleIODef("ME_LaserButton");
    clsAppMarbleIOVar.ME_SpindleDriveError = new clsAppMarbleIODef("ME_SpindleDriveError");
    clsAppMarbleIOVar.ME_SpindleDownSensor = new clsAppMarbleIODef("ME_SpindleDownSensor");
    clsAppMarbleIOVar.ME_SpindleAtSpeed = new clsAppMarbleIODef("ME_SpindleAtSpeed");
    clsAppMarbleIOVar.ME_SpindleStoped = new clsAppMarbleIODef("ME_SpindleStoped");
    clsAppMarbleIOVar.ME_SpindleUpSensor = new clsAppMarbleIODef("ME_SpindleUpSensor");
    clsAppMarbleIOVar.ME_SpindleRun = new clsAppMarbleIODef("ME_SpindleRun");
    clsAppMarbleIOVar.ME_SawDriveError = new clsAppMarbleIODef("ME_SawDriveError");
    clsAppMarbleIOVar.ME_SawAtSpeed = new clsAppMarbleIODef("ME_SawAtSpeed");
    clsAppMarbleIOVar.ME_SawStoped = new clsAppMarbleIODef("ME_SawStoped");
    clsAppMarbleIOVar.ME_PhaseError = new clsAppMarbleIODef("ME_PhaseError");
    clsAppMarbleIOVar.ME_HidroFault = new clsAppMarbleIODef("ME_HidroFault");
    clsAppMarbleIOVar.ME_XPlusLimit = new clsAppMarbleIODef("ME_XPlusLimit");
    clsAppMarbleIOVar.ME_XMinusLimit = new clsAppMarbleIODef("ME_XMinusLimit");
    clsAppMarbleIOVar.ME_XPlusMinusLimit = new clsAppMarbleIODef("ME_XPlusMinusLimit");
    clsAppMarbleIOVar.ME_YPlusLimit = new clsAppMarbleIODef("ME_YPlusLimit");
    clsAppMarbleIOVar.ME_YMinusLimit = new clsAppMarbleIODef("ME_YMinusLimit");
    clsAppMarbleIOVar.ME_YPlusMinusLimit = new clsAppMarbleIODef("ME_YPlusMinusLimit");
    clsAppMarbleIOVar.ME_ZMinusLimit = new clsAppMarbleIODef("ME_ZMinusLimit");
    clsAppMarbleIOVar.ME_ZPlusLimit = new clsAppMarbleIODef("ME_ZPlusLimit");
    clsAppMarbleIOVar.ME_LubricationLevelSensor = new clsAppMarbleIODef("ME_LubricationLevelSensor");
    clsAppMarbleIOVar.ME_LubricationBlockSensor = new clsAppMarbleIODef("ME_LubricationBlockSensor");
    clsAppMarbleIOVar.ME_ToolMeasure = new clsAppMarbleIODef("ME_ToolMeasure");
    clsAppMarbleIOVar.ME_ToolMeasureLimit = new clsAppMarbleIODef("ME_ToolMeasureLimit");
    clsAppMarbleIOVar.ME_ToolAvailable = new clsAppMarbleIODef("ME_ToolAvailable");
    clsAppMarbleIOVar.ME_ToolNotAvailable = new clsAppMarbleIODef("ME_ToolNotAvailable");
    clsAppMarbleIOVar.ME_ToolMissing = new clsAppMarbleIODef("ME_ToolMissing");
    clsAppMarbleIOVar.ME_WagonDownSensor = new clsAppMarbleIODef("ME_WagonDownSensor");
    clsAppMarbleIOVar.ME_WagonDownButton = new clsAppMarbleIODef("ME_WagonDownButton");
    clsAppMarbleIOVar.ME_WagonUpButton = new clsAppMarbleIODef("ME_WagonUpButton");
    clsAppMarbleIOVar.ME_HandWheelX = new clsAppMarbleIODef("ME_HandWheelX");
    clsAppMarbleIOVar.ME_HandWheelY = new clsAppMarbleIODef("ME_HandWheelY");
    clsAppMarbleIOVar.ME_HandWheelZ = new clsAppMarbleIODef("ME_HandWheelZ");
    clsAppMarbleIOVar.ME_HandWheelC = new clsAppMarbleIODef("ME_HandWheelC");
    clsAppMarbleIOVar.ME_HandWheelA = new clsAppMarbleIODef("ME_HandWheelA");
    clsAppMarbleIOVar.ME_HandWheelX1 = new clsAppMarbleIODef("ME_HandWheelX1");
    clsAppMarbleIOVar.ME_HandWheelX10 = new clsAppMarbleIODef("ME_HandWheelX10");
    clsAppMarbleIOVar.ME_HandWheelX100 = new clsAppMarbleIODef("ME_HandWheelX100");
    clsAppMarbleIOVar.ME_LeftVacuumInSensor = new clsAppMarbleIODef("ME_LeftVacuumInSensor");
    clsAppMarbleIOVar.ME_RightVacuumInSensor = new clsAppMarbleIODef("ME_RightVacuumInSensor");
    clsAppMarbleIOVar.ME_LeftRightVacumDownLimit = new clsAppMarbleIODef("ME_LeftRightVacumDownLimit");
    clsAppMarbleIOVar.ME_LeftRightVacumUpLimit = new clsAppMarbleIODef("ME_LeftRightVacumUpLimit");
    clsAppMarbleIOVar.ME_LeftVacuumOutSensor = new clsAppMarbleIODef("ME_LeftVacuumOutSensor");
    clsAppMarbleIOVar.ME_RightVacuumOutSensor = new clsAppMarbleIODef("ME_RightVacuumOutSensor");
    clsAppMarbleIOVar.ME_LeftVacuumDown = new clsAppMarbleIODef("ME_LeftVacuumDown");
    clsAppMarbleIOVar.ME_RightVacuumDown = new clsAppMarbleIODef("ME_RightVacuumDown");
    clsAppMarbleIOVar.ME_LeftVacuumUp = new clsAppMarbleIODef("ME_LeftVacuumUp");
    clsAppMarbleIOVar.ME_RightVacuumUp = new clsAppMarbleIODef("ME_RightVacuumUp");
    clsAppMarbleIOVar.ME_LeftVacuumOk = new clsAppMarbleIODef("ME_LeftVacuumOk");
    clsAppMarbleIOVar.ME_RightVacuumOk = new clsAppMarbleIODef("ME_RightVacuumOk");
    clsAppMarbleIOVar.ME_DoorSwitch = new clsAppMarbleIODef("ME_DoorSwitch");
    clsAppMarbleIOVar.ME_WaterSwitch = new clsAppMarbleIODef("ME_WaterSwitch");
    clsAppMarbleIOVar.ME_WaterSpindleLeak = new clsAppMarbleIODef("ME_WaterSpindleLeak");
    clsAppMarbleIOVar.ME_MaterialMeasure = new clsAppMarbleIODef("ME_MaterialMeasure");
    clsAppMarbleIOVar.ME_MaterialMeasureUp = new clsAppMarbleIODef("ME_MaterialMeasureUp");
    clsAppMarbleIOVar.ME_MaterialMeasureDown = new clsAppMarbleIODef("ME_MaterialMeasureDown");
    clsAppMarbleIOVar.ME_AirPreasure = new clsAppMarbleIODef("ME_AirPreasure");
    clsAppMarbleIOVar.ME_ATCDown = new clsAppMarbleIODef("ME_ATCDown");
    clsAppMarbleIOVar.ME_ATCUp = new clsAppMarbleIODef("ME_ATCUp");
    clsAppMarbleIOVar.ME_ATCForward = new clsAppMarbleIODef("ME_ATCForward");
    clsAppMarbleIOVar.ME_ATCBackward = new clsAppMarbleIODef("ME_ATCBackward");
    clsAppMarbleIOVar.ME_ATCCoverOpen = new clsAppMarbleIODef("ME_ATCCoverOpen");
    clsAppMarbleIOVar.ME_ATCClose = new clsAppMarbleIODef("ME_ATCClose");
    clsAppMarbleIOVar.ME_ATCOpen = new clsAppMarbleIODef("ME_ATCOpen");
    clsAppMarbleIOVar.ME_PensOpen = new clsAppMarbleIODef("ME_PensOpen");
    clsAppMarbleIOVar.ME_PensClose = new clsAppMarbleIODef("ME_PensClose");
    clsAppMarbleIOVar.ME_AxisA0 = new clsAppMarbleIODef("ME_AxisA0");
    clsAppMarbleIOVar.ME_AxisA45 = new clsAppMarbleIODef("ME_AxisA45");
    clsAppMarbleIOVar.ME_AxisAFault = new clsAppMarbleIODef("ME_AxisAFault");
    clsAppMarbleIOVar.ME_XHome = new clsAppMarbleIODef("ME_XHome");
    clsAppMarbleIOVar.ME_YHome = new clsAppMarbleIODef("ME_YHome");
    clsAppMarbleIOVar.ME_ZHome = new clsAppMarbleIODef("ME_ZHome");
    clsAppMarbleIOVar.ME_Y2Home = new clsAppMarbleIODef("ME_Y2Home");
    clsAppMarbleIOVar.MO_SystemStart = new clsAppMarbleIODef("MO_SystemStart");
    clsAppMarbleIOVar.MO_SpindleFwd = new clsAppMarbleIODef("MO_SpindleFwd");
    clsAppMarbleIOVar.MO_SpindleBwd = new clsAppMarbleIODef("MO_SpindleBwd");
    clsAppMarbleIOVar.MO_CycleStartLed = new clsAppMarbleIODef("MO_CycleStartLed");
    clsAppMarbleIOVar.MO_CycleStopLed = new clsAppMarbleIODef("MO_CycleStopLed");
    clsAppMarbleIOVar.MO_WagonUp = new clsAppMarbleIODef("MO_WagonUp");
    clsAppMarbleIOVar.MO_WagonDown = new clsAppMarbleIODef("MO_WagonDown");
    clsAppMarbleIOVar.MO_WaterMainValf = new clsAppMarbleIODef("MO_WaterMainValf");
    clsAppMarbleIOVar.MO_WaterHeadValf = new clsAppMarbleIODef("MO_WaterHeadValf");
    clsAppMarbleIOVar.MO_RedLed = new clsAppMarbleIODef("MO_RedLed");
    clsAppMarbleIOVar.MO_GreenLed = new clsAppMarbleIODef("MO_GreenLed");
    clsAppMarbleIOVar.MO_YellowLed = new clsAppMarbleIODef("MO_YellowLed");
    clsAppMarbleIOVar.MO_HidroRun = new clsAppMarbleIODef("MO_HidroRun");
    clsAppMarbleIOVar.MO_LaserOn = new clsAppMarbleIODef("MO_LaserOn");
    clsAppMarbleIOVar.MO_SystemReady = new clsAppMarbleIODef("MO_SystemReady");
    clsAppMarbleIOVar.MO_CameraValf = new clsAppMarbleIODef("MO_CameraValf");
    clsAppMarbleIOVar.MO_CameraEnable = new clsAppMarbleIODef("MO_CameraEnable");
    clsAppMarbleIOVar.MO_ResetLed = new clsAppMarbleIODef("MO_ResetLed");
    clsAppMarbleIOVar.MO_VacuumPistons = new clsAppMarbleIODef("MO_VacuumPistons");
    clsAppMarbleIOVar.MO_VacuumLeftValf = new clsAppMarbleIODef("MO_VacuumLeftValf");
    clsAppMarbleIOVar.MO_VacuumRightValf = new clsAppMarbleIODef("MO_VacuumRightValf");
    clsAppMarbleIOVar.MO_VacuumValf = new clsAppMarbleIODef("MO_VacuumValf");
    clsAppMarbleIOVar.MO_VacuumLeftBlowValf = new clsAppMarbleIODef("MO_VacuumLeftBlowValf");
    clsAppMarbleIOVar.MO_VacuumLeftDownValf = new clsAppMarbleIODef("MO_VacuumLeftDownValf");
    clsAppMarbleIOVar.MO_VacuumLeftUpValf = new clsAppMarbleIODef("MO_VacuumLeftUpValf");
    clsAppMarbleIOVar.MO_VacuumRightBlowValf = new clsAppMarbleIODef("MO_VacuumRightBlowValf");
    clsAppMarbleIOVar.MO_VacuumRightDownValf = new clsAppMarbleIODef("MO_VacuumRightDownValf");
    clsAppMarbleIOVar.MO_VacuumRightUpValf = new clsAppMarbleIODef("MO_VacuumRightUpValf");
    clsAppMarbleIOVar.MO_MaterialMeasureDownValf = new clsAppMarbleIODef("MO_MaterialMeasureDownValf");
    clsAppMarbleIOVar.MO_MaterialMeasureUpValf = new clsAppMarbleIODef("MO_MaterialMeasureUpValf");
    clsAppMarbleIOVar.MO_MaterialMeasureValf = new clsAppMarbleIODef("MO_MaterialMeasureValf");
    clsAppMarbleIOVar.MO_ToolMeasurValf = new clsAppMarbleIODef("MO_ToolMeasurValf");
    clsAppMarbleIOVar.MO_SawStart = new clsAppMarbleIODef("MO_SawStart");
    clsAppMarbleIOVar.MO_SawFwd = new clsAppMarbleIODef("MO_SawFwd");
    clsAppMarbleIOVar.MO_SawBwd = new clsAppMarbleIODef("MO_SawBwd");
    clsAppMarbleIOVar.MO_SpindleStart = new clsAppMarbleIODef("MO_SpindleStart");
    clsAppMarbleIOVar.MO_SpindleDownValf = new clsAppMarbleIODef("MO_SpindleDownValf");
    clsAppMarbleIOVar.MO_VacuumBlow = new clsAppMarbleIODef("MO_VacuumBlow");
    clsAppMarbleIOVar.MO_HoleBlow = new clsAppMarbleIODef("MO_HoleBlow");
    clsAppMarbleIOVar.MO_Lubrication = new clsAppMarbleIODef("MO_Lubrication");
    clsAppMarbleIOVar.MO_MachineLight = new clsAppMarbleIODef("MO_MachineLight");
    clsAppMarbleIOVar.MO_SpindleUpValf = new clsAppMarbleIODef("MO_SpindleUpValf");
    clsAppMarbleIOVar.MO_PensOpen = new clsAppMarbleIODef("MO_PensOpen");
    clsAppMarbleIOVar.MO_ToolAir = new clsAppMarbleIODef("MO_ToolAir");
    clsAppMarbleIOVar.MO_ATCPistonUp = new clsAppMarbleIODef("MO_ATCPistonUp");
    clsAppMarbleIOVar.MO_ATCPistonDown = new clsAppMarbleIODef("MO_ATCPistonDown");
    clsAppMarbleFormVar.MO_AxisA0 = new clsAppMarbleIODef("MO_AxisA0");
    clsAppMarbleFormVar.MO_AxisA45 = new clsAppMarbleIODef("MO_AxisA45");
    clsAppMarbleInterfaceVar.MO_Buzzer = new clsAppMarbleIODef("MO_Buzzer");
  }

  public clsAppMarbleProgramSetVar()
  {
    ((clsAppMarbleInterfaceVar) this).GCodeFormWidth = 555;
    ((clsAppMarbleInterfaceVar) this).GCodeFormHeight = 575;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
