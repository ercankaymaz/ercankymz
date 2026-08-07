// Decompiled with JetBrains decompiler
// Type: buClass.CamSurfaceType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamSurfaceType
{
  SurfaceParalel = 0,
  MeshParalel = 1,
  MeshConstantZ = 2,
  MeshRough = 3,
  None = 999, // 0x000003E7
}
