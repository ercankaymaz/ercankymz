// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Pnt6DSimMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Pnt6DSimMove
{
  public ToolBase5 ToolData;
  public List<MachineDefPart> MachineParts;
  public List<MachineDefPart> Clampers;
  public string PartName;
  public string PartFileName;
  public bool isMoveable;
  public bool isBelongToBody;
  public string Tag;
  public int No;
  public AxesEnable MoveAxisPermision;
  public List<Entity> Entities;
  public Color Color;
  public Point3D PositionBaseOffset;
  public Point3D PositionAuxOffset;
  public double RotationDistance;
  public double Stroke;
  public Point3D RotationCenter;
  public int Transparency;
  public bool AddAsMesh;
  public string PartType;

  public override string ToString()
  {
    return $"isSameMoreThanOneCheck: {((EntitiesCopySettings) this).isSameMoreThanOneCheck.ToString()} - isSmallGap: {((EntitiesCopySettings) this).isSmallGap.ToString()}";
  }

  public abstract void m00022C();

  public Pnt6DSimMove()
  {
    ((MachineDef) this).isError = false;
    ((MachineDef) this).ErrorList = new List<AnalyseEntitiesResultError>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(AnalyseEntitiesResult data)
  {
    ((MachineDef) this).isError = false;
    ((MachineDef) this).ErrorList = new List<AnalyseEntitiesResultError>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((MachineDef) this).ErrorList.Clear();
    ((MachineDef) this).ErrorList = new List<AnalyseEntitiesResultError>();
    for (int index = 0; index <= ((MachineDef) data).ErrorList.Count - 1; ++index)
      ((MachineDef) this).ErrorList.Add((AnalyseEntitiesResultError) new Pnt6DSimMove(((MachineDef) data).ErrorList[index]));
  }

  public override string ToString() => "isError: " + ((MachineDef) this).isError.ToString();

  public abstract void m000230();

  public Pnt6DSimMove()
  {
    ((MachineDefPart) this).Enable = true;
    ((MachineDefPart) this).IndexEntity = -1;
    ((MachineDefPart) this).IndexEntityList = new List<int>();
    ((MachineDefPart) this).Explanation = "";
    ((MachineDefPart) this).pntError = new Point3D();
    ((MachineDefPart) this).ErrorType = AnalyseEntitiesResultErrorType.None;
    ((MachineDefPart) this).Action = AnalyseEntitiesActionType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(AnalyseEntitiesResultError data)
  {
    ((MachineDefPart) this).Enable = true;
    ((MachineDefPart) this).IndexEntity = -1;
    ((MachineDefPart) this).IndexEntityList = new List<int>();
    ((MachineDefPart) this).Explanation = "";
    ((MachineDefPart) this).pntError = new Point3D();
    ((MachineDefPart) this).ErrorType = AnalyseEntitiesResultErrorType.None;
    ((MachineDefPart) this).Action = AnalyseEntitiesActionType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    return $"IndexEntity: {((MachineDefPart) this).IndexEntity.ToString()} - ErrorType: {((MachineDefPart) this).ErrorType.ToString()}";
  }

  public abstract void m000234();

  public Pnt6DSimMove()
  {
    ((MachineDefPart) this).Enable = false;
    ((MachineDefPart) this).ArrowPointCount = 0;
    ((MachineDefPart) this).MinLength = 0.0;
    ((MachineDefPart) this).ArrowLength = 2.0;
    ((MachineDefPart) this).ArrowAngle = 20.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(DirectionArrowSetting data)
  {
    ((MachineDefPart) this).Enable = false;
    ((MachineDefPart) this).ArrowPointCount = 0;
    ((MachineDefPart) this).MinLength = 0.0;
    ((MachineDefPart) this).ArrowLength = 2.0;
    ((MachineDefPart) this).ArrowAngle = 20.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    return $"ArrowPointCount: {((MachineDefPart) this).ArrowPointCount.ToString()} - MinLength: {((MachineDefPart) this).MinLength.ToString()}";
  }

  public abstract void m000238();

  public Pnt6DSimMove()
  {
    ((MachineDefPart) this).SceneName = "";
    ((MachineDefPart) this).EntityName = "";
    ((MachineDefPart) this).ActionName = "";
    ((KinematicBase5) this).Tags = "";
    ((KinematicBase5) this).Width = 0.0;
    ((KinematicBase5) this).Height = 0.0;
    ((KinematicBase5) this).Length = 0.0;
    ((KinematicBase5) this).Angle = 0.0;
    ((KinematicBase5) this).Radius = 0.0;
    ((KinematicBase5) this).HeadRadius = 0.0;
    ((KinematicBase5) this).OrientationC = 0.0;
    ((KinematicBase5) this).Side = 0;
    ((KinematicBase5) this).Degree = 1;
    ((KinematicBase5) this).GroupIDIndex = -1;
    ((KinematicBase5) this).CamID = -1;
    ((KinematicBase5) this).CamSelected = false;
    ((KinematicBase5) this).LayerName = "";
    ((KinematicBase5) this).Text = "";
    ((KinematicBase5) this).Data = "";
    ((KinematicBase5) this).Direction = 0.0;
    ((KinematicBase5) this).RefIndex = -1;
    ((KinematicBase5) this).CurveType = entitySplineType.BsplineCubic;
    ((KinematicBase5) this).PntBase = new Point3D();
    ((KinematicBase5) this).sortDirection = entitySortDirection.Normal;
    ((KinematicBase5) this).fileName = Application.StartupPath;
    ((KinematicBase5) this).Defination = entityTypeDefination.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(
    int groupIndex,
    string layerName,
    string sceneName,
    string entityName,
    string actionName,
    string tags,
    Point3D pntBase)
  {
    ((MachineDefPart) this).SceneName = "";
    ((MachineDefPart) this).EntityName = "";
    ((MachineDefPart) this).ActionName = "";
    ((KinematicBase5) this).Tags = "";
    ((KinematicBase5) this).Width = 0.0;
    ((KinematicBase5) this).Height = 0.0;
    ((KinematicBase5) this).Length = 0.0;
    ((KinematicBase5) this).Angle = 0.0;
    ((KinematicBase5) this).Radius = 0.0;
    ((KinematicBase5) this).HeadRadius = 0.0;
    ((KinematicBase5) this).OrientationC = 0.0;
    ((KinematicBase5) this).Side = 0;
    ((KinematicBase5) this).Degree = 1;
    ((KinematicBase5) this).GroupIDIndex = -1;
    ((KinematicBase5) this).CamID = -1;
    ((KinematicBase5) this).CamSelected = false;
    ((KinematicBase5) this).LayerName = "";
    ((KinematicBase5) this).Text = "";
    ((KinematicBase5) this).Data = "";
    ((KinematicBase5) this).Direction = 0.0;
    ((KinematicBase5) this).RefIndex = -1;
    ((KinematicBase5) this).CurveType = entitySplineType.BsplineCubic;
    ((KinematicBase5) this).PntBase = new Point3D();
    ((KinematicBase5) this).sortDirection = entitySortDirection.Normal;
    ((KinematicBase5) this).fileName = Application.StartupPath;
    ((KinematicBase5) this).Defination = entityTypeDefination.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MachineDefPart) this).ActionName = actionName;
    ((MachineDefPart) this).EntityName = entityName;
    ((KinematicBase5) this).GroupIDIndex = groupIndex;
    ((KinematicBase5) this).LayerName = layerName;
    ((MachineDefPart) this).SceneName = sceneName;
    ((KinematicBase5) this).Tags = tags;
    ((KinematicBase5) this).PntBase = new Point3D(pntBase.X, pntBase.Y, pntBase.Z);
  }

  public Pnt6DSimMove(Entity ent)
  {
    ((MachineDefPart) this).SceneName = "";
    ((MachineDefPart) this).EntityName = "";
    ((MachineDefPart) this).ActionName = "";
    ((KinematicBase5) this).Tags = "";
    ((KinematicBase5) this).Width = 0.0;
    ((KinematicBase5) this).Height = 0.0;
    ((KinematicBase5) this).Length = 0.0;
    ((KinematicBase5) this).Angle = 0.0;
    ((KinematicBase5) this).Radius = 0.0;
    ((KinematicBase5) this).HeadRadius = 0.0;
    ((KinematicBase5) this).OrientationC = 0.0;
    ((KinematicBase5) this).Side = 0;
    ((KinematicBase5) this).Degree = 1;
    ((KinematicBase5) this).GroupIDIndex = -1;
    ((KinematicBase5) this).CamID = -1;
    ((KinematicBase5) this).CamSelected = false;
    ((KinematicBase5) this).LayerName = "";
    ((KinematicBase5) this).Text = "";
    ((KinematicBase5) this).Data = "";
    ((KinematicBase5) this).Direction = 0.0;
    ((KinematicBase5) this).RefIndex = -1;
    ((KinematicBase5) this).CurveType = entitySplineType.BsplineCubic;
    ((KinematicBase5) this).PntBase = new Point3D();
    ((KinematicBase5) this).sortDirection = entitySortDirection.Normal;
    ((KinematicBase5) this).fileName = Application.StartupPath;
    ((KinematicBase5) this).Defination = entityTypeDefination.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (ent.EntityData == null || !(ent.EntityData is CustomData))
      return;
    ((MachineDefPart) this).ActionName = ((ClipperOffset) ent.EntityData).get_ActionName();
    ((KinematicBase5) this).Angle = ((CutterNotch) ent.EntityData).get_infoAngle();
    ((KinematicBase5) this).CamSelected = ((buCutter) ent.EntityData).get_CamSelected();
    ((KinematicBase5) this).Degree = ((buRollerBendCalc) ent.EntityData).get_infoDegree();
    ((MachineDefPart) this).EntityName = ((ClipperOffset) ent.EntityData).get_EntityName();
    ((KinematicBase5) this).GroupIDIndex = ((buDiamakerCalc) ent.EntityData).get_GroupIdIndex();
    ((KinematicBase5) this).HeadRadius = ((ToolGrindingRuntimeSettings) ent.EntityData).get_infoHeadRadius();
    ((KinematicBase5) this).Height = ((buToolGrindingCalc) ent.EntityData).get_infoHeight();
    ((KinematicBase5) this).LayerName = ent.LayerName;
    ((KinematicBase5) this).Length = ((CutterProgramSettings) ent.EntityData).get_infoLength();
    ((KinematicBase5) this).OrientationC = ((CutterIsoFileSettings) ent.EntityData).get_OrientationC();
    if (((buRollerBendCalc) ent.EntityData).get_infoBasePoint() != (Point3D) null)
      ((KinematicBase5) this).PntBase = F_NotchEdit.ToPoint3D(((buRollerBendCalc) ent.EntityData).get_infoBasePoint());
    ((KinematicBase5) this).Radius = ((ToolGrindingJob) ent.EntityData).get_infoRadius();
    ((MachineDefPart) this).SceneName = ((ClipperOffset) ent.EntityData).get_SceneName();
    ((KinematicBase5) this).Side = ((ToolGrindingSettings) ent.EntityData).get_infoSide();
    ((KinematicBase5) this).Tags = ((ClipperOffset) ent.EntityData).get_Tags();
    ((KinematicBase5) this).Text = ((CutterRuntimeSettings) ent.EntityData).get_infoString();
    ((KinematicBase5) this).Data = ((CutterProgramSettings) ent.EntityData).get_infoData();
    ((KinematicBase5) this).Width = ((ToolGrindingJob) ent.EntityData).get_infoWidth();
    ((KinematicBase5) this).Defination = ((CutterRuntimeSettings) ent.EntityData).get_typeDefination();
    ((KinematicBase5) this).Direction = ((CutterNotch) ent.EntityData).get_infoDirection();
    ((KinematicBase5) this).RefIndex = ((DiemakerGrindingShapeSettings) ent.EntityData).get_RefIndex();
  }

  public static CustomData ConvertCustomData(EntityDataSet EntData)
  {
    CustomData customData = (CustomData) new ClipperOffset();
    ((\u001D.\u0001) customData).set_ActionName(((MachineDefPart) EntData).ActionName);
    ((buDiamakerCalc) customData).set_CamID(((KinematicBase5) EntData).CamID);
    ((buCutter) customData).set_CamSelected(((KinematicBase5) EntData).CamSelected);
    ((RollerJob) customData).set_CurveType(((KinematicBase5) EntData).CurveType);
    ((ClipperOffset) customData).set_EntityName(((MachineDefPart) EntData).EntityName);
    ((buDiamakerCalc) customData).set_GroupIdIndex(((KinematicBase5) EntData).GroupIDIndex);
    ((CutterNotch) customData).set_infoAngle(((KinematicBase5) EntData).Angle);
    ((RollerJob) customData).set_infoBasePoint(((KinematicBase5) EntData).PntBase);
    ((buRollerBendCalc) customData).set_infoDegree(((KinematicBase5) EntData).Degree);
    ((ToolGrindingRuntimeSettings) customData).set_infoHeadRadius(((KinematicBase5) EntData).HeadRadius);
    ((buToolGrindingCalc) customData).set_infoHeight(((KinematicBase5) EntData).Height);
    ((CutterProgramSettings) customData).set_infoLength(((KinematicBase5) EntData).Length);
    ((ToolGrindingJob) customData).set_infoRadius(((KinematicBase5) EntData).Radius);
    ((ToolGrindingSettings) customData).set_infoSide(((KinematicBase5) EntData).Side);
    ((CutterProgramSettings) customData).set_infoString(((KinematicBase5) EntData).Text);
    ((CutterProgramSettings) customData).set_infoData(((KinematicBase5) EntData).Data);
    ((ToolGrindingJob) customData).set_infoWidth(((KinematicBase5) EntData).Width);
    ((CutterIsoFileItems) customData).set_OrientationC(((KinematicBase5) EntData).OrientationC);
    ((ClipperOffset) customData).set_SceneName(((MachineDefPart) EntData).SceneName);
    ((CutterRuntimeSettings) customData).set_sortDirection(((KinematicBase5) EntData).sortDirection);
    ((ClipperOffset) customData).set_Tags(((KinematicBase5) EntData).Tags);
    ((CutterRuntimeSettings) customData).set_typeDefination(((KinematicBase5) EntData).Defination);
    ((CutterNotch) customData).set_infoDirection(((KinematicBase5) EntData).Direction);
    ((DiemakerGrindingShapeSettings) customData).set_RefIndex(((KinematicBase5) EntData).RefIndex);
    return customData;
  }

  public Pnt6DSimMove(EntityDataSet data)
  {
    ((MachineDefPart) this).SceneName = "";
    ((MachineDefPart) this).EntityName = "";
    ((MachineDefPart) this).ActionName = "";
    ((KinematicBase5) this).Tags = "";
    ((KinematicBase5) this).Width = 0.0;
    ((KinematicBase5) this).Height = 0.0;
    ((KinematicBase5) this).Length = 0.0;
    ((KinematicBase5) this).Angle = 0.0;
    ((KinematicBase5) this).Radius = 0.0;
    ((KinematicBase5) this).HeadRadius = 0.0;
    ((KinematicBase5) this).OrientationC = 0.0;
    ((KinematicBase5) this).Side = 0;
    ((KinematicBase5) this).Degree = 1;
    ((KinematicBase5) this).GroupIDIndex = -1;
    ((KinematicBase5) this).CamID = -1;
    ((KinematicBase5) this).CamSelected = false;
    ((KinematicBase5) this).LayerName = "";
    ((KinematicBase5) this).Text = "";
    ((KinematicBase5) this).Data = "";
    ((KinematicBase5) this).Direction = 0.0;
    ((KinematicBase5) this).RefIndex = -1;
    ((KinematicBase5) this).CurveType = entitySplineType.BsplineCubic;
    ((KinematicBase5) this).PntBase = new Point3D();
    ((KinematicBase5) this).sortDirection = entitySortDirection.Normal;
    ((KinematicBase5) this).fileName = Application.StartupPath;
    ((KinematicBase5) this).Defination = entityTypeDefination.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((KinematicBase5) this).PntBase = new Point3D(((KinematicBase5) data).PntBase.X, ((KinematicBase5) data).PntBase.Y, ((KinematicBase5) data).PntBase.Z);
  }

  public Pnt6DSimMove(
    int groupIndex,
    string layerName,
    string sceneName,
    string entityName,
    string actionName,
    string tags,
    Point3D pntBase,
    double width,
    double height,
    double length,
    double angle,
    double radius,
    double headRadius,
    int side,
    int degree)
  {
    ((MachineDefPart) this).SceneName = "";
    ((MachineDefPart) this).EntityName = "";
    ((MachineDefPart) this).ActionName = "";
    ((KinematicBase5) this).Tags = "";
    ((KinematicBase5) this).Width = 0.0;
    ((KinematicBase5) this).Height = 0.0;
    ((KinematicBase5) this).Length = 0.0;
    ((KinematicBase5) this).Angle = 0.0;
    ((KinematicBase5) this).Radius = 0.0;
    ((KinematicBase5) this).HeadRadius = 0.0;
    ((KinematicBase5) this).OrientationC = 0.0;
    ((KinematicBase5) this).Side = 0;
    ((KinematicBase5) this).Degree = 1;
    ((KinematicBase5) this).GroupIDIndex = -1;
    ((KinematicBase5) this).CamID = -1;
    ((KinematicBase5) this).CamSelected = false;
    ((KinematicBase5) this).LayerName = "";
    ((KinematicBase5) this).Text = "";
    ((KinematicBase5) this).Data = "";
    ((KinematicBase5) this).Direction = 0.0;
    ((KinematicBase5) this).RefIndex = -1;
    ((KinematicBase5) this).CurveType = entitySplineType.BsplineCubic;
    ((KinematicBase5) this).PntBase = new Point3D();
    ((KinematicBase5) this).sortDirection = entitySortDirection.Normal;
    ((KinematicBase5) this).fileName = Application.StartupPath;
    ((KinematicBase5) this).Defination = entityTypeDefination.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MachineDefPart) this).ActionName = actionName;
    ((KinematicBase5) this).Angle = angle;
    ((KinematicBase5) this).Degree = degree;
    ((MachineDefPart) this).EntityName = entityName;
    ((KinematicBase5) this).GroupIDIndex = groupIndex;
    ((KinematicBase5) this).HeadRadius = headRadius;
    ((KinematicBase5) this).Height = height;
    ((KinematicBase5) this).LayerName = layerName;
    ((KinematicBase5) this).Length = length;
    ((KinematicBase5) this).Radius = radius;
    ((MachineDefPart) this).SceneName = sceneName;
    ((KinematicBase5) this).Side = side;
    ((KinematicBase5) this).Tags = tags;
    ((KinematicBase5) this).Width = width;
    ((KinematicBase5) this).PntBase = new Point3D(pntBase.X, pntBase.Y, pntBase.Z);
  }

  public abstract void m00023F();

  public Pnt6DSimMove()
  {
    ((KinematicBase5) this).AddPoint = false;
    ((KinematicBase5) this).AddDimension = false;
    ((KinematicBase5) this).AddCurve = true;
    ((KinematicBase5) this).AddCircular = true;
    ((KinematicBase5) this).AddEllipse = true;
    ((KinematicBase5) this).AddCompositeCurve = true;
    ((Clamper) this).PolylineToLine = false;
    ((Clamper) this).CompositeCurveToEntities = true;
    ((Clamper) this).CurveToPolyLine = true;
    ((Clamper) this).CircleTo4Arc = true;
    ((Clamper) this).ArcToPoyline = false;
    ((Clamper) this).EllipseToPoyline = false;
    ((Clamper) this).CircleToPoyline = false;
    ((Clamper) this).MinLength = 0.01;
    ((Clamper) this).RegenDev = 0.05;
    ((Clamper) this).PolylineToLineMinLength = 100.0;
    ((PlaneAngle) this).ForcePlaneXY = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(
    bool addPoint,
    bool addDimension,
    bool addCurve,
    bool addCircular,
    bool addCompositeCurve,
    bool addEllipse,
    bool compositeCurveToEntities,
    double regen,
    double minLen)
  {
    ((KinematicBase5) this).AddPoint = false;
    ((KinematicBase5) this).AddDimension = false;
    ((KinematicBase5) this).AddCurve = true;
    ((KinematicBase5) this).AddCircular = true;
    ((KinematicBase5) this).AddEllipse = true;
    ((KinematicBase5) this).AddCompositeCurve = true;
    ((Clamper) this).PolylineToLine = false;
    ((Clamper) this).CompositeCurveToEntities = true;
    ((Clamper) this).CurveToPolyLine = true;
    ((Clamper) this).CircleTo4Arc = true;
    ((Clamper) this).ArcToPoyline = false;
    ((Clamper) this).EllipseToPoyline = false;
    ((Clamper) this).CircleToPoyline = false;
    ((Clamper) this).MinLength = 0.01;
    ((Clamper) this).RegenDev = 0.05;
    ((Clamper) this).PolylineToLineMinLength = 100.0;
    ((PlaneAngle) this).ForcePlaneXY = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((KinematicBase5) this).AddPoint = addPoint;
    ((KinematicBase5) this).AddDimension = addDimension;
    ((KinematicBase5) this).AddCurve = addCurve;
    ((KinematicBase5) this).AddCircular = addCircular;
    ((KinematicBase5) this).AddEllipse = addEllipse;
    ((KinematicBase5) this).AddCompositeCurve = addCompositeCurve;
    ((Clamper) this).CompositeCurveToEntities = compositeCurveToEntities;
    ((Clamper) this).RegenDev = regen;
    ((Clamper) this).MinLength = minLen;
  }

  public Pnt6DSimMove(EntitiesCopySettings data)
  {
    ((KinematicBase5) this).AddPoint = false;
    ((KinematicBase5) this).AddDimension = false;
    ((KinematicBase5) this).AddCurve = true;
    ((KinematicBase5) this).AddCircular = true;
    ((KinematicBase5) this).AddEllipse = true;
    ((KinematicBase5) this).AddCompositeCurve = true;
    ((Clamper) this).PolylineToLine = false;
    ((Clamper) this).CompositeCurveToEntities = true;
    ((Clamper) this).CurveToPolyLine = true;
    ((Clamper) this).CircleTo4Arc = true;
    ((Clamper) this).ArcToPoyline = false;
    ((Clamper) this).EllipseToPoyline = false;
    ((Clamper) this).CircleToPoyline = false;
    ((Clamper) this).MinLength = 0.01;
    ((Clamper) this).RegenDev = 0.05;
    ((Clamper) this).PolylineToLineMinLength = 100.0;
    ((PlaneAngle) this).ForcePlaneXY = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    return $"AddPoint: {((KinematicBase5) this).AddPoint.ToString()} , CompositeToEntities: {((Clamper) this).CompositeCurveToEntities.ToString()}";
  }

  public abstract void m000244();

  public Pnt6DSimMove()
  {
    ((PlaneAngle) this).Kinematic = (KinematicBase5) new OsnapPoint();
    this.ToolData = (ToolBase5) new ToolGeometry5();
    this.MachineParts = new List<MachineDefPart>();
    this.Clampers = new List<MachineDefPart>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public Pnt6DSimMove(MachineDef data)
  {
    ((PlaneAngle) this).Kinematic = (KinematicBase5) new OsnapPoint();
    this.ToolData = (ToolBase5) new ToolGeometry5();
    this.MachineParts = new List<MachineDefPart>();
    this.Clampers = new List<MachineDefPart>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.ToolData = (ToolBase5) new ToolGeometry5(((Pnt6DSimMove) data).ToolData);
    ((PlaneAngle) this).Kinematic = (KinematicBase5) new OsnapPoint(((PlaneAngle) data).Kinematic);
    this.MachineParts.Clear();
    for (int index = 0; index <= ((Pnt6DSimMove) data).MachineParts.Count - 1; ++index)
      this.MachineParts.Add((MachineDefPart) new OsnapCoordinateCatch(((Pnt6DSimMove) data).MachineParts[index]));
    this.MachineParts.Clear();
    for (int index = 0; index <= ((Pnt6DSimMove) data).Clampers.Count - 1; ++index)
      this.Clampers.Add((MachineDefPart) new OsnapCoordinateCatch(((Pnt6DSimMove) data).Clampers[index]));
  }

  public Pnt6DSimMove() => ((pageInfo) this).\u002Ector();
}
