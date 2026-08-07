// Decompiled with JetBrains decompiler
// Type: buClass.mtAxisCmd
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum mtAxisCmd
{
  NoCommand = 300, // 0x0000012C
  McStop = 301, // 0x0000012D
  McMoveAbsolute = 302, // 0x0000012E
  McMoveRelative = 303, // 0x0000012F
  McJog = 304, // 0x00000130
  McReset = 305, // 0x00000131
  McPower = 306, // 0x00000132
  SmcHoming = 307, // 0x00000133
  McSetPosition = 308, // 0x00000134
  McSetHome = 309, // 0x00000135
  AutoPosition = 310, // 0x00000136
  WriteDrivePar = 311, // 0x00000137
  WriteGainSpeedPar = 312, // 0x00000138
  WriteGainPosPar = 313, // 0x00000139
  WriteGainCurrentPar = 314, // 0x0000013A
  WriteGainFeedForwardPar = 315, // 0x0000013B
  WriteGainSetPointPar = 316, // 0x0000013C
  WriteGainOtherPar = 317, // 0x0000013D
  SetScale = 318, // 0x0000013E
  SetLimits = 319, // 0x0000013F
  ReadDrivePar = 320, // 0x00000140
}
