// Decompiled with JetBrains decompiler
// Type: buClass.AxisCommands
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum AxisCommands
{
  NoCommand,
  McStop,
  McMoveAbsolute,
  McMoveRelative,
  McJog,
  McReset,
  McPower,
  SmcHoming,
  McSetPosition,
  McSetHome,
  AutoPosition,
  WriteDrivePar,
  WriteGainSpeedPar,
  WriteGainPosPar,
  WriteGainCurrentPar,
  WriteGainFeedForwardPar,
  WriteGainSetPointPar,
  WriteGainOtherPar,
  SetScale,
  SetLimits,
  ReadDrivePar,
}
