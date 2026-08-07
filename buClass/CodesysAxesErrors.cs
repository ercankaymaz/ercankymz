// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxesErrors
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum CodesysAxesErrors
{
  SWLimit = 300, // 0x0000012C
  HWLimit = 301, // 0x0000012D
  DriveError = 302, // 0x0000012E
  ErrorStop = 303, // 0x0000012F
  FlowingError = 304, // 0x00000130
  HomeTimeout = 305, // 0x00000131
  Communication = 306, // 0x00000132
  DataLimitPosError = 307, // 0x00000133
  DataLimitNegError = 308, // 0x00000134
  SWLimitPositive = 309, // 0x00000135
  MCStop = 311, // 0x00000137
  MCReset = 312, // 0x00000138
  MCPower = 313, // 0x00000139
  MCMoveAbs = 314, // 0x0000013A
  MCMoveRel = 315, // 0x0000013B
  MCHome = 316, // 0x0000013C
  MCSetPos = 317, // 0x0000013D
  MCSetHome = 318, // 0x0000013E
  MCJog = 319, // 0x0000013F
  LimitDynamics = 320, // 0x00000140
  MCGearIn = 321, // 0x00000141
  MCGearOut = 322, // 0x00000142
  AxisOutOfLimit = 323, // 0x00000143
  SMCChangeDynamicLimits = 324, // 0x00000144
  SMCChangeRatio = 325, // 0x00000145
  SMCHome = 326, // 0x00000146
  SMCSoftLimit = 327, // 0x00000147
  SMCRampType = 328, // 0x00000148
  SMCMoveType = 329, // 0x00000149
  ReInit = 330, // 0x0000014A
  SWLimitNegative = 30310, // 0x00007666
}
