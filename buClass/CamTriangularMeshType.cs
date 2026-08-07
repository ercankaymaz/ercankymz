// Decompiled with JetBrains decompiler
// Type: buClass.CamTriangularMeshType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamTriangularMeshType
{
  Rough = 0,
  ParallelCuts = 1,
  ProjectCurves = 2,
  ConstantZ = 3,
  ConstantCusp = 4,
  Flatlands = 5,
  Pencil = 6,
  Geodesic = 7,
  Projection = 8,
  RotaryRough = 9,
  RotaryFinish = 10, // 0x0000000A
  Rotary = 11, // 0x0000000B
  Trochoidal = 12, // 0x0000000C
  ConstantZPlusConstantCusp = 13, // 0x0000000D
  ConstantZPlusParallelCuts = 14, // 0x0000000E
  Rough3Plus2 = 15, // 0x0000000F
  ProjectionAround = 16, // 0x00000010
  ProjectionAlong = 17, // 0x00000011
  None = 999, // 0x000003E7
}
