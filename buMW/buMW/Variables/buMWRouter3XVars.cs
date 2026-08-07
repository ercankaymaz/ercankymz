// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWRouter3XVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks;

#nullable disable
namespace buMW.Variables;

public class buMWRouter3XVars
{
  public static MWParameters varCamRough;
  public static MWParameters varCamContour;
  public static MWParameters varCamCommon;
  public static MWParameters varCamWireframeCompCutting;
  public static MWParameters varCamWireframeCompGrove;
  public static MWParameters varCamWireframeCompCutInside;
  public static MWParameters varCamWireframeCompCutOutside;
  public static MWParameters varCamWireframeCompCutCenter;
  public static MWParameters varCamWireframeCompPocket;
  public static MWParameters varCamWireframeCompText;
  public static MWParameters varCamWireframeRough;
  public static MWParameters varCamWireframeContour;
  public static MWParameters varCamWireframeFace;
  public static MWParameters varCamWireframeEngrave;
  public static MWParameters varCamWireframeTextEngrave;
  public static MWParameters varCamWireframeFloorFinish;
  public static MWParameters varCamWireframeCenterPath;
  public static MWParameters varCamWireframeTrochoidial;
  public static MWParameters varCamWireframeDrill;
  public static MWParameters varCamWireframeChamfer;
  public static MWParameters varCamMeshRough;
  public static MWParameters varCamMeshParallel;
  public static MWParameters varCamMeshConstantZ;
  public static MWParameters varCamMeshPencil;
  public static MWParameters varCamMeshFlatLand;
  public static MWParameters varCamMeshProjectCurves;
  public static MWParameters varCamMeshConstantCusp;
  public static MWParameters varCamMeshProjection;
  public static MWParameters varCamMeshRotary;
  public static MWParameters varCamMeshParallel5AX;

  public static void Init() => buMWRouter3XVars.varCamCommon = new MWParameters(Unit.Metric, 0);
}
