// Decompiled with JetBrains decompiler
// Type: buClass.ShapeTypes
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public enum ShapeTypes
{
  Circle = 0,
  Rectangle = 1,
  RoundRectangle = 2,
  KeyHole = 3,
  Ellipse = 4,
  Hole = 5,
  Polygon = 6,
  FreeDraw = 7,
  Text = 8,
  Triangle = 9,
  Slot = 10, // 0x0000000A
  Trepezoid = 11, // 0x0000000B
  Rhombus = 12, // 0x0000000C
  Star = 13, // 0x0000000D
  Moon = 14, // 0x0000000E
  Cut = 15, // 0x0000000F
  FreeLines = 16, // 0x00000010
  Cleaning = 17, // 0x00000011
  Line = 18, // 0x00000012
  Rectangle3Edge = 19, // 0x00000013
  Rectangle2Edge = 20, // 0x00000014
  CircleHalf = 21, // 0x00000015
  NotchSide = 80, // 0x00000050
  NotchLength = 81, // 0x00000051
  NotchVertical = 82, // 0x00000052
  NotchHorizontal = 83, // 0x00000053
  Notch = 84, // 0x00000054
  None = 100, // 0x00000064
}
