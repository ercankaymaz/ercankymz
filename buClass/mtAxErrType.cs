// Decompiled with JetBrains decompiler
// Type: buClass.mtAxErrType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum mtAxErrType
{
  SWLimit,
  HWLimit,
  DriveError,
  ErrorStop,
  FlowingError,
  HomeTimeout,
  Communication,
  DataLimitPosError,
  DataLimitNegError,
  SWLimitPositive,
  SWLimitNegative,
  MCStop,
  MCReset,
  MCPower,
  MCMoveAbs,
  MCMoveRel,
  MCHome,
  MCSetPos,
  MCSetHome,
  MCJog,
  LimitDynamics,
  MCGearIn,
  MCGearOut,
  AxisOutOfLimit,
  SMCChangeDynamicLimits,
  SMCChangeRatio,
  SMCHome,
  SMCSoftLimit,
  SMCRampType,
  SMCMoveType,
  ReInit,
}
