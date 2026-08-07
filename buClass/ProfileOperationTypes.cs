// Decompiled with JetBrains decompiler
// Type: buClass.ProfileOperationTypes
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum ProfileOperationTypes
{
  Circle = 0,
  Rectangle = 1,
  RoundRectangle = 2,
  Barrel = 3,
  Ellipse = 4,
  Hole = 5,
  Notch = 6,
  FreeDraw = 7,
  Text = 8,
  FromSelection = 9,
  Slot = 10, // 0x0000000A
  FromFile = 11, // 0x0000000B
  Cut = 12, // 0x0000000C
  CustomText = 13, // 0x0000000D
  Polygon = 14, // 0x0000000E
  FromFileList = 15, // 0x0000000F
  WireText = 16, // 0x00000010
  Library = 17, // 0x00000011
  Tapping = 18, // 0x00000012
  UnKnown = 99, // 0x00000063
}
