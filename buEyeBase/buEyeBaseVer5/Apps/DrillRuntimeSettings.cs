// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillRuntimeSettings : buSerilization5
{
  public bool ClampesSetByManuelly;
  public double ContourOffset;
  public Entity panelEntity;
  public Entity FirstClamperEntity;
  public Entity SecondClamperEntity;
  public List<Entity> otherEntities;
  public static byte f003F13;
  public string ItemName;
  public bool isError;
  public bool isDrill;
  public bool isPocket;
  public bool isCenter;
  public int ID;
  public int Tool;
  public int GroupIndex;
  public int HeadNo;
  public double Diameter;
  public double Depth;
  public double Length;
  public double Width;
  public double Height;
  public double Angle;
  public Vector3D Direction;
  public Point3D Center;
  public Point3D OffsetedPoint;
  public Point3D BoxMin;
  public Point3D BoxMax;
  public int Transparency;
  public planeBoxNames planeName;
  public DrillItemType Type;
  public drillCommands Command;
  public CornerLocation Corner;
  public ShapeTypes ShapeType;
  public ProfilingTypes ProfilingType;
  public bool Calculated;
  public bool Enable;
  public bool UseMilling;
  public int HorizontalCount;
  public int VerticalCount;
  public double HorizontalDistance;
  public double VerticalDistance;
  public double StartDistance;
  public double EndDistance;
  public int NumberNextHorizontalItem;
  public int NumberNextVerticalItem;
  public static byte f003F3A;
  public string ItemName;
  public Vector3D CornerDirection;
  public planeBoxNames planeName;
  public DrillItemType Type;
  public drillCommands Command;
  public CornerLocation Corner;
  public ShapeTypes ShapeType;
  public DrillProfilingType ProfilingType;
  public Plane planeOperation;
  public int HorizontalCount;
  public int VerticalCount;
  public double HorizontalDistance;
  public double VerticalDistance;
  public double StartDistance;
  public double EndDistance;
  public Point3D BaseCenter;
  public Point3D BoxBoundingMin;
  public Point3D BoxBoundingMax;
  public Point3D CornerPoint;
  public int ID;
  public int Index;
  public DrillShapeData ShapeCommonData;
  public DrillRuntimeSettings Parameter;
  public List<DrillItem> Items;
  public static byte f003F53;
  public string ItemName;
  public bool isError;
  public bool isDrill;
  public bool isPocket;
  public bool isCenter;
  public bool isMillingAtClamperSide;
  public bool isRough;
  public bool isFinish;
  public int SubID;
  public int Tool;
  public int GroupIndex;
  public int BaseIndex;
  public int Index;
  public DrillShapeData ShapeData;
  public camParameters5 CamPars;
  public double Sing;
  public Vector3D CornerDirection;
  public Point3D Center;
  public Point3D CornerPoint;
  public Point3D OffsetedPoint;
  public Point3D BoxMinOfDrawing;
  public Point3D BoxMaxOfDrawing;
  public Point3D BoxMinItem;
  public Point3D BoxMaxItem;
  public Color Color;
  public int Transparency;
  public List<List<buEntity>> shapeEntitites;
  public List<List<buEntity>> camEntities;
  public List<Entity> solidEntities;
  public Entity SolidEntity;
  public Plane planeOperation;
  public planeBoxNames planeName;
  public DrillItemType Type;
  public drillCommands Command;
  public CornerLocation Corner;
  public ShapeTypes ShapeType;
  public ProfilingTypes ProfilingType;
  public bool Calculated;
  public bool Enable;
  public bool UseMilling;
  public int HorizontalCount;
  public int VerticalCount;
  public double HorizontalDistance;
  public double VerticalDistance;
  public double StartDistance;
  public double EndDistance;
  public double X1Move;
  public double X2Move;
  public bool X1First;

  static DrillRuntimeSettings()
  {
    DrillCalcItem.UnitLength = LengthUnit.mm;
    DrillCalcItem.UnitsSpeed = SpeedUnit.mmPerSec;
    DrillCalcItem.LangFoamStatus = new List<string>();
    DrillCalcItem.LangFoamMessage = new List<string>();
    DrillCalcItem.LangFoamCaptions = new List<string>();
    DrillCalcItem.LangFoamCommands = new List<string>();
    DrillCalcItem.varTemps = (FoamTempVars) new buNestingCalc();
    DrillCalcItem.varFoamSettings = (FoamSettings) new buNestingCalc();
    DrillCalcItem.varFoamEditorSettings = (FoamEditorSettings) new buNestingCalc();
    DrillCalcItem.varFoamGCodeConverter = (GCodeConverter) new buFunctions();
    DrillCalcItem.varFoamRunSettings = (FoamRuntimeSettings) new buNestingCalc();
    DrillCalcItem.RadiusFeedList = new List<camRadiusFeed>();
    DrillCalcItem.LengthFeedList = new List<camLengthFeed>();
    DrillCalcItem.EntityID = 1;
    DrillCalcItem.UnlockString = "";
  }

  public DrillRuntimeSettings()
  {
    ((DrillCalcItem) this).ItemName = "";
    ((DrillCalcItem) this).FileName = "";
    ((DrillCalcItem) this).FileNameFull = "";
    ((DrillCalcItem) this).isError = false;
    ((DrillCalcItem) this).isGCodeCreated = false;
    ((DrillCalcItem) this).CreatedFromDrawing = false;
    ((DrillCalcItem) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((DrillCalcItem) this).TextureName = "";
    ((DrillCalcItem) this).colorFoam = Color.DarkGray;
    ((DrillCalcItem) this).Transparency = 120;
    ((DrillCalcItem) this).MinPoint = new Point3D();
    ((DrillCalcItem) this).MaxPoint = new Point3D();
    ((DrillCalcItem) this).SolidEntity = (Entity) null;
    ((DrillCalcItem) this).BlockXZ = new List<FoamBlock>();
    ((DrillCalcItem) this).BlockYZ = new List<FoamBlock>();
    ((DrillCalcItem) this).CamXZ = new camTp();
    ((DrillCalcItem) this).CamYZ = new camTp();
    ((DrillCalcItem) this).sortedEntitiesYZ = new List<buEntity>();
    ((DrillCalcItem) this).sortedEntitiesXZ = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
