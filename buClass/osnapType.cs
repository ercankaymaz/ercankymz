// Decompiled with JetBrains decompiler
// Type: buClass.osnapType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum osnapType
{
  None = -1, // 0xFFFFFFFF
  Point = 0,
  Middle = 1,
  Center = 2,
  Outer = 3,
  Intersection = 4,
  Vertice = 5,
  BoxHorizontal = 6,
  Ortho = 7,
  Over = 8,
  Track = 9,
  Snap = 10, // 0x0000000A
  BoxVertical = 11, // 0x0000000B
  ControlPoint = 12, // 0x0000000C
  Alingment = 13, // 0x0000000D
  Grid = 14, // 0x0000000E
}
