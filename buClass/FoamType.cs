// Decompiled with JetBrains decompiler
// Type: buClass.FoamType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum FoamType
{
  VForm = 0,
  SForm = 1,
  FromDrawing = 2,
  SlicesHorizontal = 3,
  SingleLine = 4,
  CircularLock = 5,
  SlotLock = 6,
  Shape = 7,
  ShapeFromDrawing = 8,
  Pattern = 9,
  UForm = 10, // 0x0000000A
  CForm = 11, // 0x0000000B
  ZForm = 12, // 0x0000000C
  Pyramid = 13, // 0x0000000D
  Rectangle = 14, // 0x0000000E
  Circle = 15, // 0x0000000F
  None = 16, // 0x00000010
  SlicesVertical = 16, // 0x00000010
}
