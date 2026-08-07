// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSettings : buSerilization5
{
  public planeBoxNames planeName;
  public camTp CamData;
  public ToolBase5 Tool;
  public camParameters5 CamPars;
  public List<buEntity> CamEntities;
  public Router3AXCamPlane entitiesPlane;
  public CamMode camMode;
  public CamWireFrameType camWireframeType;
  public CamTriangularMeshType camMeshType;
  public CamTriangularMesh5AxType camMesh5AXType;
  public CamSurfaceType camSurfType;
  public CamDrillType camDrillType;
  public Router3AXLayerPurpose Purpose;
  public static byte f003B9F;
  public buEntity entityPlaneBottom;
  public buEntity entityPlaneBottomText;
  public buEntity entityPlaneTop;
  public buEntity entityPlaneTopText;
  public buEntity entityPlaneClearance;
  public buEntity entityPlaneClearanceText;
  public buEntity entityPlaneRetract;
  public buEntity entityPlaneRetractText;
  public static byte f003BA8;
  public bool ShowOperationInfo;
  public SizeObject SizeStock;
  public string MultiGCodeSeparatorChar;
  public MachineTableType TableType;
  public bool DualTable;
  public bool M75Mode;
  public bool BuCenterCalculation;
  public bool AutoWaterClose;
  public bool Save3DDataWhileGCodeCreate;
  public bool SaveGCodeDataWhileGCodeCreate;
  public static byte f003BB3;
  public ColorType colorStock;
  public ColorType colorPlaneTop;
  public ColorType colorPlaneBottom;
  public ColorType colorPlaneClearance;
  public ColorType colorPlaneRetract;
  public ColorType colorPlaneText;
  public ColorDrawType colorCamBase;
  public ColorDrawType colorCamG1;
  public ColorDrawType colorCamG0;
  public ColorDrawType colorCamPlunge;
  public ColorDrawType colorCamLeave;
  public ColorDrawType colorCamLeadIn;
  public ColorDrawType colorCamLeadOut;
  public bool SelectMode;
  public bool FromFileKeepRatio;
  public string pathFromFile;
  public double MaterialHeight;
  public double MaterialWidth;
  public double MaterialDepth;
  public int SimStep;
  public ShapeRuntimeData ShapeDataParameters;
  public List<string> SequenceList;
  public static byte f003BCA;
  public string layerPanel;
  public string layerOperation;
  public string layerGeneral;
  public string layerSelected;
  public string layerCam;
  public string layerCamPlane;
  public string layerWireframe;
  public string layerSheet;
  public string layerPart;
  public string layerSolid;
  public ViewportRefType ViewportRef;
  public planeBoxNames activePlane;
  public static byte f003BD7;

  static FoamSettings()
  {
    FoamPattern.LangRouterStatus = new List<string>();
    FoamPattern.LangRouterMessage = new List<string>();
    FoamPattern.LangRouterCaptions = new List<string>();
    FoamCreatePanelOptions.LangRouterCommands = new List<string>();
  }

  public FoamSettings()
  {
    ((FoamCreatePanelOptions) this).ItemName = "Job";
    ((FoamCreatePanelOptions) this).FileName = "";
    ((FoamEntities) this).FileNameFull = "";
    ((FoamSortGroup) this).Index = -1;
    ((FoamSortGroup) this).isError = false;
    ((FoamSortGroup) this).isGCodeCreated = false;
    ((FoamSortGroup) this).CreatedFromDrawing = false;
    ((FoamSortGroup) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamActiveBlock) this).TextureName = "";
    ((FoamActiveBlock) this).colorFoam = Color.DarkGray;
    ((FoamActiveBlock) this).Transparency = 120;
    ((FoamSpeeds) this).MinPoint = new Point3D();
    ((FoamSpeeds) this).MaxPoint = new Point3D();
    ((FoamSpeeds) this).Stock = (CamStock) null;
    ((FoamSpeeds) this).GCodeResult = (MachineGCodeExecutionResult) null;
    ((FoamSpeeds) this).CamList = new List<Router3AXCAM>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
