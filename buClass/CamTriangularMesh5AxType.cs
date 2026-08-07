// Decompiled with JetBrains decompiler
// Type: buClass.CamTriangularMesh5AxType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamTriangularMesh5AxType
{
  Rough = 0,
  ParallelCuts = 1,
  ConstantZ = 2,
  Geodesic = 3,
  None = 999, // 0x000003E7
}
