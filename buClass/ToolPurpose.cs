// Decompiled with JetBrains decompiler
// Type: buClass.ToolPurpose
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum ToolPurpose
{
  None = -1, // 0xFFFFFFFF
  General = 0,
  Milling = 1,
  Cutting = 2,
  Grinding = 3,
  Hole = 4,
  Drilling = 5,
  Lathe = 6,
  Derz = 7,
  Text = 8,
  PocketFlat = 9,
  PocketCircular = 10, // 0x0000000A
  CutOut = 11, // 0x0000000B
  CutIn = 12, // 0x0000000C
  CutCenter = 13, // 0x0000000D
  GrindingRought = 14, // 0x0000000E
  Saw = 15, // 0x0000000F
  WaterJet = 16, // 0x00000010
  Plasma = 17, // 0x00000011
  LaserCut = 18, // 0x00000012
  Tapping = 19, // 0x00000013
  Slot = 20, // 0x00000014
  DiamondCut = 21, // 0x00000015
  Spin = 22, // 0x00000016
  Engrave = 23, // 0x00000017
  Info = 50, // 0x00000032
  MillingHead = 51, // 0x00000033
  AirDry = 52, // 0x00000034
  Pointer = 53, // 0x00000035
  Milling5Axis = 54, // 0x00000036
  Other = 100, // 0x00000064
}
