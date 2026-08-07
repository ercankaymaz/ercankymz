// Decompiled with JetBrains decompiler
// Type: buClass.CamSequence
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamSequence
{
  None = 0,
  VerticalSawCut = 1,
  HorizontalSawCut = 2,
  ContourOutsideSawCut = 3,
  ContourInsideSawCut = 4,
  VacuumCut = 5,
  SingleVerticalCut = 6,
  SingleHorizontalCut = 7,
  StripStartCut = 8,
  StripEndCut = 9,
  ContourOutsideMillingCut = 10, // 0x0000000A
  ContourInsideMillingCut = 11, // 0x0000000B
  ContourConvexMillingCut = 12, // 0x0000000C
  ContourConcaveMillingCut = 13, // 0x0000000D
  CollapseMillingCut = 14, // 0x0000000E
  ContourConvexDrill = 15, // 0x0000000F
  ContourConcaveDrill = 16, // 0x00000010
  Drill = 17, // 0x00000011
  Shape = 103, // 0x00000067
  Engraving = 104, // 0x00000068
  Profiling = 105, // 0x00000069
  Text = 106, // 0x0000006A
  Library = 107, // 0x0000006B
  Sweep = 108, // 0x0000006C
  Contour = 110, // 0x0000006E
  Columns = 111, // 0x0000006F
  LatheHorizontal = 112, // 0x00000070
  LatheVertical = 113, // 0x00000071
  ProfileCurve = 114, // 0x00000072
  AirDry = 115, // 0x00000073
  MaterialClean = 116, // 0x00000074
  SingleCut = 117, // 0x00000075
  Editor = 118, // 0x00000076
  GCode = 119, // 0x00000077
  Countertop = 120, // 0x00000078
  Slices = 121, // 0x00000079
  SawHorizontalMillingRough = 122, // 0x0000007A
  SawVerticalMillingRough = 123, // 0x0000007B
  EasyDraw = 124, // 0x0000007C
  PocketByDrill = 125, // 0x0000007D
  SawHorizontalMillingFinish = 126, // 0x0000007E
  SawVerticalMillingFinish = 127, // 0x0000007F
  TextWireframe = 128, // 0x00000080
  Text3D = 129, // 0x00000081
  Milling5AxisRotary = 130, // 0x00000082
  Milling5AxisFlat = 131, // 0x00000083
  HorizontalVerticalCut = 132, // 0x00000084
  Shape3D = 133, // 0x00000085
  Cavity = 134, // 0x00000086
  Tap = 135, // 0x00000087
  CutRemainMaterial = 136, // 0x00000088
  VacuumAdd = 137, // 0x00000089
}
