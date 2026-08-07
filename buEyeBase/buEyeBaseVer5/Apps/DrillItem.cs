// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillItem : buSerilization5
{
  public List<buEntity> sortEntities;
  public List<FoamEntities> foamEntities;
  public FoamPatternInfo Info;
  public Color Color;
  public int Transparency;
  public List<Entity> SolidEntities;
  public devDept.Geometry.Plane planeOperation;
  public FoamPlaneType planeName;
  public FoamType Type;
  public FoamOperationType GroupType;
  public int HorizontalIndex;
  public int VerticalIndex;
  public bool isError;
  public bool Calculated;
  public bool Enable;
  public bool isReverse;
  public double Width;
  public double Height;
  public Point3D Offset;
  public static byte f003D65;
  public bool DrawAll;
  public bool DeleteSort;
  public bool DeleteTool;
  public bool DrawPreview;
  public buEntitiesGroup GroupEntity;
  public FoamPlaneType PlaneType;
  public NormalReverse Direction;
  public List<List<buEntity>> sortEntities;
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public static byte f003D70;
  public FoamPlaneType Plane;
  public int BlockIndex;
  public int PatternIndex;
  public static byte f003D74;
  public double Cutting;
  public double LeadIn;
  public double LeadOut;
  public double Connection;
  public double CRotation;
  public static byte f003D7A;
  public double TotalArea;
  public double BoxArea;
  public double UsedPersentageFromBoxArea;
  public double TotalCuttingLength;
  public double TotalNoCuttingLength;
  public double TimeCutting;
  public static byte f003D81;
  public double RegenDeviation;
  public double MaxDevideLen;
  public double AngleLimitOnlyCRotation;
  public bool ShowOperationInfo;
  public double DirectionArrowHeadLength;
  public double DirectionArrowHeadAngle;
  public double StartPointDiameter;
  public double LastPointDiameter;
  public double EqualValue;
  public double TangentMaxAngle;
  public double TangentMinAngle;
  public double GCodeRegenDEviation;

  static DrillItem()
  {
    SewingPickType.StepZ = 30;
    SewingPickType.MedianRadius = 300.0;
    SewingPickType.PipeExecStep = 100;
    SewingPickType.OffsetX = 0;
    SewingCodeDef.OffsetY = 216;
    SewingCodeDef.StraightBlockName = "straight";
    SewingSelectedPoint.StraightbackBlockName = "StraightBack";
    SewingSelectedPoint.BendBlockName = "bend";
    SewingSelectedPoint.MachineBlockName = "machine";
    SewingSelectedPoint._checkMethod = collisionCheckType.SubdivisionTree;
    SewingSelectedPoint.ProgressFinished = false;
    SewingSettings.collidedEntities = new List<Entity>();
    SewingSettings._firstOnly = true;
    SewingSettings.NumberOfSim = 0;
    SewingSettings._machineTranslation = new Vector3D(-1400.0, -495.0, -922.0);
    SewingSettings._machineScalingFactor = 2.1;
    SewingSettings.machineCollisionEntities = new int[4]
    {
      30,
      31 /*0x1F*/,
      68,
      69
    };
    SewingSettings.collisionColor = Color.OrangeRed;
    SewingSettings.collisionColor2 = Color.DarkRed;
    SewingSettings.originalColors = new Dictionary<Entity, Color>();
    SewingSettings._sw = new Stopwatch();
    SewingSettings._surfList = new List<Entity>();
  }

  public DrillItem()
  {
    if (!buVector5.\u0001("buWood"))
      throw new RegisterException("buWood");
  }

  static DrillItem()
  {
    SewingSettings.LangWoodStatus = new List<string>();
    SewingSettings.LangWoodMessage = new List<string>();
    SewingSettings.LangWoodCaptions = new List<string>();
    SewingSettings.LangWoodCommands = new List<string>();
    SewingSettings.varTemps = (WoodTempVars) new DrillItem();
    SewingSettings.varWoodSettings = (WoodSettings) new DrillItem();
    SewingSettings.varWoodRunSettings = (WoodRuntimeSettings) new DrillItem();
  }

  public DrillItem()
  {
    ((SewingSettings) this).Name = "Job";
    ((SewingSettings) this).Items = new List<buShape>();
    ((SewingRuntimeSettings) this).Codes = new List<string>();
    ((SewingRuntimeSettings) this).Cams = new List<camTp>();
    ((SewingRuntimeSettings) this).ErrorCodes = new List<string>();
    ((SewingRuntimeSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((SewingRuntimeSettings) this).TotalCount = 1;
    ((SewingRuntimeSettings) this).Used = 0;
    ((SewingRuntimeSettings) this).isSorted = false;
    ((SewingRuntimeSettings) this).panelEntity = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillItem(WoodJob data)
  {
    ((SewingSettings) this).Name = "Job";
    ((SewingSettings) this).Items = new List<buShape>();
    ((SewingRuntimeSettings) this).Codes = new List<string>();
    ((SewingRuntimeSettings) this).Cams = new List<camTp>();
    ((SewingRuntimeSettings) this).ErrorCodes = new List<string>();
    ((SewingRuntimeSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((SewingRuntimeSettings) this).TotalCount = 1;
    ((SewingRuntimeSettings) this).Used = 0;
    ((SewingRuntimeSettings) this).isSorted = false;
    ((SewingRuntimeSettings) this).panelEntity = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((SewingRuntimeSettings) this).Material = (MaterialBase5) new ShapeMultiCenterData(((SewingRuntimeSettings) data).Material);
    if (((SewingRuntimeSettings) data).panelEntity != null)
      buVector5.CopyEntities(((SewingRuntimeSettings) data).panelEntity, ref ((SewingRuntimeSettings) this).panelEntity);
    buLineCam.Copy(((SewingSettings) data).Items, ref ((SewingSettings) this).Items);
    for (int index = 0; index <= ((SewingRuntimeSettings) data).ErrorCodes.Count - 1; ++index)
      ((SewingRuntimeSettings) this).ErrorCodes.Add(((SewingRuntimeSettings) this).ErrorCodes[index]);
    for (int index = 0; index <= ((SewingRuntimeSettings) data).Cams.Count - 1; ++index)
      ((SewingRuntimeSettings) this).Cams.Add(new camTp(((SewingRuntimeSettings) data).Cams[index]));
  }

  public override string ToString() => ((SewingSettings) this).Name.ToString();

  public abstract void m001B4F();

  public DrillItem()
  {
    ((SewingRuntimeSettings) this).ShowOperationButton = false;
    ((SewingRuntimeSettings) this).MaterialHeight = 800.0;
    ((SewingRuntimeSettings) this).MaterialWidth = 2000.0;
    ((SewingRuntimeSettings) this).MaterialDepth = 20.0;
    ((SewingRuntimeSettings) this).colorPanel = Color.Tan;
    ((SewingRuntimeSettings) this).colorOperation = Color.Blue;
    ((SewingRuntimeSettings) this).colorOperationDisable = Color.DarkGray;
    ((SewingRuntimeSettings) this).FromFileKeepRatio = true;
    ((SewingJobItem) this).pathFromFile = "C:\\";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillItem(WoodSettings data)
  {
    ((SewingRuntimeSettings) this).ShowOperationButton = false;
    ((SewingRuntimeSettings) this).MaterialHeight = 800.0;
    ((SewingRuntimeSettings) this).MaterialWidth = 2000.0;
    ((SewingRuntimeSettings) this).MaterialDepth = 20.0;
    ((SewingRuntimeSettings) this).colorPanel = Color.Tan;
    ((SewingRuntimeSettings) this).colorOperation = Color.Blue;
    ((SewingRuntimeSettings) this).colorOperationDisable = Color.DarkGray;
    ((SewingRuntimeSettings) this).FromFileKeepRatio = true;
    ((SewingJobItem) this).pathFromFile = "C:\\";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m001B52();

  public DrillItem()
  {
    ((SewingJobItem) this).SelectMode = false;
    ((SewingJobItem) this).ShapeType = ShapeTypes.Rectangle;
    ((SewingJobItem) this).LastPlane = planeBoxNames.Top;
    ((SewingJobItem) this).LastCorner = MaterialCornerLocation.LeftBottom;
    ((SewingJobItem) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillItem(WoodRuntimeSettings data)
  {
    ((SewingJobItem) this).SelectMode = false;
    ((SewingJobItem) this).ShapeType = ShapeTypes.Rectangle;
    ((SewingJobItem) this).LastPlane = planeBoxNames.Top;
    ((SewingJobItem) this).LastCorner = MaterialCornerLocation.LeftBottom;
    ((SewingJobItem) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((SewingJobItem) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands(((SewingJobItem) data).ShapeDataParameters);
  }

  public DrillItem()
  {
    ((SewingJobItem) this).layerPanel = "Panel";
    ((SewingJobItem) this).layerOperation = "Operation";
    ((SewingJobItem) this).layerGeneral = "General";
    ((SewingJobItem) this).layerSelected = "Selected";
    ((SewingJobItem) this).layerCam = "Cam";
    ((SewingJobItem) this).lastShape = (buShape) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public DrillItem(WoodTempVars data)
  {
    ((SewingJobItem) this).layerPanel = "Panel";
    ((SewingJobItem) this).layerOperation = "Operation";
    ((SewingJobItem) this).layerGeneral = "General";
    ((SewingJobItem) this).layerSelected = "Selected";
    ((SewingJobItem) this).layerCam = "Cam";
    ((SewingJobItem) this).lastShape = (buShape) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m001B57();

  public DrillItem()
  {
    if (!buVector5.\u0001("buPrinter3D"))
      throw new RegisterException("buPrinter3D");
  }

  public static string LayerToString(Printer3DLayer Layer)
  {
    return $"{((DrillJob) Layer).LevelZ.ToString("f2")} mm";
  }

  static DrillItem()
  {
    QuiltingProgramSettings.LangPrinter3DStatus = new List<string>();
    QuiltingProgramSettings.LangPrinter3DMessage = new List<string>();
    QuiltingProgramSettings.LangPrinter3DCaptions = new List<string>();
    QuiltingProgramSettings.LangPrinter3DCommands = new List<string>();
    QuiltingProgramSettings.varTemps = (Printer3DTempVars) new DrillFound();
    QuiltingProgramSettings.varPrinter3DSettings = (Printer3DSettings) new DrillMove();
    QuiltingProgramSettings.varPrinter3DRunSettings = (Printer3DRuntimeSettings) new DrillFound();
  }
}
