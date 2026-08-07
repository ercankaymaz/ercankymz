// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeRuntimeData
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
namespace buEyeBaseVer5;

[Serializable]
public class ShapeRuntimeData : buSerilization5
{
  public Point3D LastPoint;
  public SortingResultType ResultType;
  public List<int> SelectedEntitiesIndex;
  public List<buEntity> LastCalculatedEntities;
  public List<buEntity> AskMeEntites;
  public List<int> LastSelectedEntitiesIndex;
  public bool Return;
  public bool ReturnNextGroup;
  public bool GetBack;
  public bool GetBackFromMultiSelection;
  public bool isPointOnEntity;
  public int SelectedIndex;
  public Point3D CatchPoint;
  public List<int> FoundEntitiesIndex;
  public List<string> FoundEntitiesID;
  public List<buEntity> FoundEntities;
  public List<buEntity> SortedEntities;
  public List<buEntity> TempEntities;
  public List<List<buEntity>> RemovedEntities;
  public List<Point3D> LastMarkPosition;
  public int Index;
  public int BaseIndex;
  public camPathDirectionType Direction;
  public Point3D RefPoint;
  public Point3D StartPoint;
  public Point3D NextPoint;
  public buEntity Entity;
  public static byte f000783;
  public int Sequence;
  public Point3D pntFound;
  public StartEndType FoundLocation;
  public double FoundDistance;
  public bool isPointCatch;
  public bool isPointCatchAnyWay;
  public bool isPointCatchCamSelected;
  public Point3D pntCatch;
  public Point3D pntCatchCamSelected;
  public ShapeMirror MirrorData;
  public ShapeArray ArrayData;
  public double RotateDegree;
  public double HorizontanAngle;
  public double VerticalAngle;
  public static byte f000792;
  public bool CircularEnable;
  public int CircularCount;
  public double CircularAngle;
  public bool LineerEnable;
  public int LineerXCount;
  public double LineerXDistance;
  public int LineerYCount;
  public double LineerYDistance;
  public static byte f00079B;
  public bool MirrorEnable;
  public MirrorAxisXYType MirrorAxis;
  public MinCenterMaxType MirrorLocation;
  public double MirrorDistance;
  public MirrorModeType MirrorMode;
  public static byte f0007A1;
  public Point3D MinBox;
  public Point3D MaxBox;
  public Point3D CenterPoint;
  public static byte f0007A5;
  public double LeadInLength;
  public double LeadOutLength;
  public LeadInOutType LeadInType;
  public LeadInOutType LeadOuType;
  public static byte f0007AA;
  public Point3D Center;
  public double Diameter;
  public static byte f0007AD;
  public bool EachLayer;
  public bool ManuelZ;
  public double ExtraDepth;
  public static byte f0007B1;
  public bool UpdateRuntime;
  public bool Finished;
  public bool isError;
  public bool ToolChangeForced;
  public bool ToolFound;
  public bool OnlyDrawing;
  public bool OpenFile;
  public bool NotOriginalTool;
  public bool DontUpdateTree;
  public string ToolName;
  public string ToolAuxName;
  public int ToolIndex;
  public string Command;
  public ShapeRuntimeData Parameters;
  public ToolBase5 Tool;
  public ShapeDataValueType ValueType;
  public List<string> CommandList;
  public static byte f0007C3;
  public LeftRightType LeftRigthViewType;
  public static byte f0007C5;
  public camParameters5 CamPars;
  public Point3D pntBase;
  public Point3D pntCalc;
  public Point3D pntCorner;
  public ShapeGroup ShapeGroup;
  public drillTypes DrillType;
  public CutTypes CutType;
  public ProfilingTypes ProfilingType;
  public JunctionTypes JunctionType;
  public ShapeTypes ShapeType;
  public planeBoxNames selectedPlane;
  public CornerLocation selectedCorner;
  public ObjectAlignment objectAlignment;
  public ShapeDataValueType ValueType;
  public ShapeEdit Edit;
  public bool isTapping;
  public bool isMillingHole;
  public bool isMillingCut;
  public bool isMillingJunction;
  public bool isShapePocket;
  public bool isProfilingPocket;
  public bool isEngravePocket;
  public bool isIncrementalMode;

  public override string ToString() => "SingX: " + ((SortPointClickData) this).SingX.ToString();

  public abstract void m0002DD();

  public ShapeRuntimeData()
  {
    ((SortbuFilter) this).Filter = (SortFilter) new ShapeRuntimeData();
    ((SortbuFilter) this).Option = (SortOptions) new ShapeTempData();
    ((SortbuFilter) this).CamData = (SortCamData) new CurveToSurfaceSettingsType();
    ((SortbuFilter) this).ClosestPoint = (MostClosestPointOption) new SelectionOperation();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeRuntimeData(SortSettings data)
  {
    ((SortbuFilter) this).Filter = (SortFilter) new ShapeRuntimeData();
    ((SortbuFilter) this).Option = (SortOptions) new ShapeTempData();
    ((SortbuFilter) this).CamData = (SortCamData) new CurveToSurfaceSettingsType();
    ((SortbuFilter) this).ClosestPoint = (MostClosestPointOption) new SelectionOperation();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((SortbuFilter) this).CamData = (SortCamData) new CurveToSurfaceSettingsType(((SortbuFilter) data).CamData);
    ((SortbuFilter) this).Filter = (SortFilter) new ShapeTempData(((SortbuFilter) data).Filter);
    ((SortbuFilter) this).Option = (SortOptions) new ShapeTempData(((SortbuFilter) data).Option);
  }

  public ShapeRuntimeData()
  {
    ((SortbuFilter) this).NotSelectEntities = new List<devDept.Eyeshot.Entities.Entity>();
    ((SortbuOptions) this).SelectableEntities = new List<devDept.Eyeshot.Entities.Entity>();
    ((SortbuOptions) this).NotSelectIndex = new List<int>();
    ((SortbuOptions) this).SelectableIndex = new List<int>();
    ((SortbuOptions) this).NotSelectColor = new List<Color>();
    ((SortbuOptions) this).SelectableColor = new List<Color>();
    ((SortbuOptions) this).MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;
    ((SortbuOptions) this).UsePointEntities = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
