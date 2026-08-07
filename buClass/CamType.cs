// Decompiled with JetBrains decompiler
// Type: buClass.CamType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public enum CamType
{
  None,
  ContourClosedCenter,
  ContourClosedOutside,
  ContourClosedInside,
  ContourOpenCenter,
  ContourOpenLeft,
  ContourOpenRight,
  ContourMulti,
  PocketCircular,
  PocketFlat,
  Point,
  AreaScan,
  Rough,
  ParallelCut,
  ConstantZ,
  Pencil,
  ProjectCurves,
  Flatlands,
  ConstantCusp,
  Drill,
  Contour4X,
  Drill4X,
  Face,
  FloorFinishing,
  Chamfer,
  Engrave,
  TextEngrave,
  Trochoidal,
  ContourClosed,
  ContourOpen,
  Contour,
  Finish,
  Center,
  ConstantZPlusConstantCusp,
  ConstantZPlusParallelCuts,
  Geodesic,
  Projection,
  Rotary,
  RotaryFinish,
  RotaryRough,
  CornerCleanByMilling,
  CornerCleanByDrill,
  SawCut,
  MillingCut,
}
