// Decompiled with JetBrains decompiler
// Type: buClass.mtSystemErr
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum mtSystemErr
{
  NoAlarm,
  Emergency,
  HomingTimeout,
  MACMissmatch,
  InitFailure,
  GantryError,
  LowAirPreasue,
  SpindleFault,
  ToolChangeTimeout,
  ToolMeasureTimeout,
  ToolMeasureFailure,
  ParkTimeout,
  Compile,
  ShortTool,
  LongTool,
  ToolClamperNotEmpty,
  ToolNotAvailable,
  ToolNoActive,
  ReadNC,
  DecodeNC,
  SmoothMerge,
  SmoothPath,
  ExtendVel,
  LimitDynamics,
  CheckVel,
  ToolCoverNotOpen,
  ToolCoverNotClosed,
  ToolNotForward,
  ToolNotBackward,
  WaterLevelLow,
  DoorOpen,
  ToolStillInSpindle,
  ToolChangeNextToolWrong,
  CncIpo,
  CncReadNc,
  CncDecodeNc,
  BBBActivated,
  ToolCantGet,
  ClamperNotClosed,
  ClamperNotEmpty,
  ToolChangeFailure,
  Calculation,
  FileOpen,
  FileSave,
  NoProduct,
  PhaseError,
  EthercatInitFailure,
  AxesParUpdateInitFailure,
}
