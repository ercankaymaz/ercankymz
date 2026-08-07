// Decompiled with JetBrains decompiler
// Type: buClass.drillCommands
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum drillCommands
{
  SingleHole = 0,
  VerticalHoles = 1,
  HorizontalHoles = 2,
  HorizontalLineHoles = 3,
  VerticalLineHoles = 4,
  ThreeHole = 5,
  InclineHoles = 6,
  CutVertical = 100, // 0x00000064
  CutHorizontal = 101, // 0x00000065
  CutFree = 102, // 0x00000066
  CutVerticalLine = 103, // 0x00000067
  CutHorizontalLine = 104, // 0x00000068
  DrawingRectangle = 200, // 0x000000C8
  DrawingCircle = 201, // 0x000000C9
  DrawingEllipse = 202, // 0x000000CA
  DrawingPoliygon = 203, // 0x000000CB
  DrawingKeyHole = 204, // 0x000000CC
  DrawingSlot = 205, // 0x000000CD
  DrawingStar = 206, // 0x000000CE
  DrawingContour = 207, // 0x000000CF
  ProfilingSingleCorner = 300, // 0x0000012C
  ProfilingAllCorner = 301, // 0x0000012D
  ProfilingSingleRoundCorner = 302, // 0x0000012E
  ProfilingMiddleHorizontalPocket = 303, // 0x0000012F
  ProfilingMiddleVerticalPocket = 304, // 0x00000130
  ProfilingMiddleHorizontalCurve = 305, // 0x00000131
  ProfilingMiddleVerticalCurve = 306, // 0x00000132
  Engraving = 400, // 0x00000190
}
