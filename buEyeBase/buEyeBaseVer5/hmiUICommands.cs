// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUICommands
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class hmiUICommands : buSerilization5
{
  public hmiUICommands()
  {
    ((ShapeRuntimeData) this).Center = new Point3D();
    ((ShapeRuntimeData) this).Diameter = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(Point3D center, double dia)
  {
    ((ShapeRuntimeData) this).Center = new Point3D();
    ((ShapeRuntimeData) this).Diameter = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ShapeRuntimeData) this).Center = new Point3D(center.X, center.Y, center.Z);
    ((ShapeRuntimeData) this).Diameter = dia;
  }

  public hmiUICommands(ShapeMultiCenterData data)
  {
    ((ShapeRuntimeData) this).Center = new Point3D();
    ((ShapeRuntimeData) this).Diameter = 0.0;
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

  public override string ToString()
  {
    return $"Diameter :{((ShapeRuntimeData) this).Diameter.ToString()} - Center :{((ShapeRuntimeData) this).Center.ToString()}";
  }

  public abstract void m00031B();

  public hmiUICommands()
  {
    ((ShapeRuntimeData) this).EachLayer = true;
    ((ShapeRuntimeData) this).ManuelZ = false;
    ((ShapeRuntimeData) this).ExtraDepth = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(ShapeProfileData data)
  {
    ((ShapeRuntimeData) this).EachLayer = true;
    ((ShapeRuntimeData) this).ManuelZ = false;
    ((ShapeRuntimeData) this).ExtraDepth = 1.0;
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
    return $"ExtraDepth: {((ShapeRuntimeData) this).ExtraDepth.ToString()} , EachLayer : {((ShapeRuntimeData) this).EachLayer.ToString()} , ManuelZ: {((ShapeRuntimeData) this).ManuelZ.ToString()}";
  }

  public abstract void m00031F();

  public hmiUICommands()
  {
    ((ShapeRuntimeData) this).UpdateRuntime = false;
    ((ShapeRuntimeData) this).Finished = false;
    ((ShapeRuntimeData) this).isError = false;
    ((ShapeRuntimeData) this).ToolChangeForced = false;
    ((ShapeRuntimeData) this).ToolFound = false;
    ((ShapeRuntimeData) this).OnlyDrawing = false;
    ((ShapeRuntimeData) this).OpenFile = false;
    ((ShapeRuntimeData) this).NotOriginalTool = false;
    ((ShapeRuntimeData) this).DontUpdateTree = false;
    ((ShapeRuntimeData) this).ToolName = "";
    ((ShapeRuntimeData) this).ToolAuxName = "";
    ((ShapeRuntimeData) this).ToolIndex = -1;
    ((ShapeRuntimeData) this).Command = "";
    ((ShapeRuntimeData) this).Parameters = (ShapeRuntimeData) new hmiUICommands();
    ((ShapeRuntimeData) this).Tool = (ToolBase5) null;
    ((ShapeRuntimeData) this).ValueType = ShapeDataValueType.None;
    ((ShapeRuntimeData) this).CommandList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(ShapeRuntimeData Pars)
  {
    ((ShapeRuntimeData) this).UpdateRuntime = false;
    ((ShapeRuntimeData) this).Finished = false;
    ((ShapeRuntimeData) this).isError = false;
    ((ShapeRuntimeData) this).ToolChangeForced = false;
    ((ShapeRuntimeData) this).ToolFound = false;
    ((ShapeRuntimeData) this).OnlyDrawing = false;
    ((ShapeRuntimeData) this).OpenFile = false;
    ((ShapeRuntimeData) this).NotOriginalTool = false;
    ((ShapeRuntimeData) this).DontUpdateTree = false;
    ((ShapeRuntimeData) this).ToolName = "";
    ((ShapeRuntimeData) this).ToolAuxName = "";
    ((ShapeRuntimeData) this).ToolIndex = -1;
    ((ShapeRuntimeData) this).Command = "";
    ((ShapeRuntimeData) this).Parameters = (ShapeRuntimeData) new hmiUICommands();
    ((ShapeRuntimeData) this).Tool = (ToolBase5) null;
    ((ShapeRuntimeData) this).ValueType = ShapeDataValueType.None;
    ((ShapeRuntimeData) this).CommandList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ShapeRuntimeData) this).Parameters = (ShapeRuntimeData) new hmiUICommands(Pars);
  }

  public hmiUICommands(ShapeUpdateArg data)
  {
    ((ShapeRuntimeData) this).UpdateRuntime = false;
    ((ShapeRuntimeData) this).Finished = false;
    ((ShapeRuntimeData) this).isError = false;
    ((ShapeRuntimeData) this).ToolChangeForced = false;
    ((ShapeRuntimeData) this).ToolFound = false;
    ((ShapeRuntimeData) this).OnlyDrawing = false;
    ((ShapeRuntimeData) this).OpenFile = false;
    ((ShapeRuntimeData) this).NotOriginalTool = false;
    ((ShapeRuntimeData) this).DontUpdateTree = false;
    ((ShapeRuntimeData) this).ToolName = "";
    ((ShapeRuntimeData) this).ToolAuxName = "";
    ((ShapeRuntimeData) this).ToolIndex = -1;
    ((ShapeRuntimeData) this).Command = "";
    ((ShapeRuntimeData) this).Parameters = (ShapeRuntimeData) new hmiUICommands();
    ((ShapeRuntimeData) this).Tool = (ToolBase5) null;
    ((ShapeRuntimeData) this).ValueType = ShapeDataValueType.None;
    ((ShapeRuntimeData) this).CommandList = new List<string>();
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

  public override string ToString() => "Finished :" + ((ShapeRuntimeData) this).Finished.ToString();

  public abstract void m000324();

  public hmiUICommands()
  {
    ((ShapeRuntimeData) this).LeftRigthViewType = LeftRightType.Right;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(ShapeSettingData data)
  {
    ((ShapeRuntimeData) this).LeftRigthViewType = LeftRightType.Right;
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

  public override string ToString()
  {
    return "LeftRight :" + ((ShapeRuntimeData) this).LeftRigthViewType.ToString();
  }

  public abstract void m000328();

  public void MmToInch()
  {
    ((camOffset5) ((ShapeRuntimeData) this).CamPars).MmToInch();
    ((ColorType) ((ShapeRuntimeData) this).Edit).MmToInch();
    ((ShapeRuntimeData) this).pntBase.X = Math.Round(((ShapeRuntimeData) this).pntBase.X * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) this).pntBase.Y = Math.Round(((ShapeRuntimeData) this).pntBase.Y * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) this).pntBase.Z = Math.Round(((ShapeRuntimeData) this).pntBase.Z * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.X = Math.Round(((ShapeRuntimeData) this).pntCalc.X * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.Y = Math.Round(((ShapeRuntimeData) this).pntCalc.Y * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.Z = Math.Round(((ShapeRuntimeData) this).pntCalc.Z * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailWidth = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailWidth * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailHeight = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailHeight * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailDepth = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailDepth * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).ExtraDepth = Math.Round(((CurveToSurfaceSettingsType) this).ExtraDepth * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).ManuelDepthStart = Math.Round(((CurveToSurfaceSettingsType) this).ManuelDepthStart * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).IncrementalDistance = Math.Round(((CurveToSurfaceSettingsType) this).IncrementalDistance * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).RectangleWidth = Math.Round(((CurveToSurfaceSettingsType) this).RectangleWidth * buSystem.MmToInchRatio, 5);
    ((CurveToSurfaceSettingsType) this).RectangleHeight = Math.Round(((CurveToSurfaceSettingsType) this).RectangleHeight * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).RectangleDepth = Math.Round(((SelectedPlaneInfo) this).RectangleDepth * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).RectangleAngle = Math.Round(((SelectedPlaneInfo) this).RectangleAngle * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).RectangleRadius = Math.Round(((SelectedPlaneInfo) this).RectangleRadius * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).RectangleChamfer = Math.Round(((SelectedPlaneInfo) this).RectangleChamfer * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).CircleRadius = Math.Round(((SelectedPlaneInfo) this).CircleRadius * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).CircleDepth = Math.Round(((SelectedPlaneInfo) this).CircleDepth * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).EllipseRadiusX = Math.Round(((SelectedPlaneInfo) this).EllipseRadiusX * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).EllipseRadiusY = Math.Round(((SelectedPlaneInfo) this).EllipseRadiusY * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).EllipseDepth = Math.Round(((SelectedPlaneInfo) this).EllipseDepth * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).PolygonRadius = Math.Round(((SelectedPlaneInfo) this).PolygonRadius * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).PolygonDepth = Math.Round(((SelectedPlaneInfo) this).PolygonDepth * buSystem.MmToInchRatio, 5);
    ((SelectedPlaneInfo) this).SlotLength = Math.Round(((SelectedPlaneInfo) this).SlotLength * buSystem.MmToInchRatio, 5);
    ((SelectionEntityTypes) this).SlotDiameter = Math.Round(((SelectionEntityTypes) this).SlotDiameter * buSystem.MmToInchRatio, 5);
    ((SelectionEntityTypes) this).SlotDepth = Math.Round(((SelectionEntityTypes) this).SlotDepth * buSystem.MmToInchRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleLength = Math.Round(((SelectionEntityTypes) this).KeyHoleLength * buSystem.MmToInchRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleHeadDiameter = Math.Round(((SelectionEntityTypes) this).KeyHoleHeadDiameter * buSystem.MmToInchRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleDiameter = Math.Round(((SelectionEntityTypes) this).KeyHoleDiameter * buSystem.MmToInchRatio, 5);
    ((SelectionOperation) this).KeyHoleDepth = Math.Round(((SelectionOperation) this).KeyHoleDepth * buSystem.MmToInchRatio, 5);
    ((SelectionOperation) this).FreeDrawWidth = Math.Round(((SelectionOperation) this).FreeDrawWidth * buSystem.MmToInchRatio, 5);
    ((SelectionOperation) this).FreeDrawHeight = Math.Round(((SelectionOperation) this).FreeDrawHeight * buSystem.MmToInchRatio, 5);
    ((SelectionOperation) this).FreeDrawDepth = Math.Round(((SelectionOperation) this).FreeDrawDepth * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).TextWidth = Math.Round(((SelectionEntity) this).TextWidth * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).TextHeight = Math.Round(((SelectionEntity) this).TextHeight * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).TextDepth = Math.Round(((SelectionEntity) this).TextDepth * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).HoleDiameter = Math.Round(((SelectionEntity) this).HoleDiameter * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).HoleDiameterOutside = Math.Round(((SelectionEntity) this).HoleDiameterOutside * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).HoleDepth = Math.Round(((SelectionEntity) this).HoleDepth * buSystem.MmToInchRatio, 5);
    ((SelectionEntity) this).HoleDistance = Math.Round(((SelectionEntity) this).HoleDistance * buSystem.MmToInchRatio, 5);
    ((SelectionAlingmentPoints) this).HoleStartDistance = Math.Round(((SelectionAlingmentPoints) this).HoleStartDistance * buSystem.MmToInchRatio, 5);
    ((SelectionAlingmentPoints) this).HoleEndDistance = Math.Round(((SelectionAlingmentPoints) this).HoleEndDistance * buSystem.MmToInchRatio, 5);
    ((MeasureItem) this).HoleOutsideDisX = Math.Round(((MeasureItem) this).HoleOutsideDisX * buSystem.MmToInchRatio, 5);
    ((MeasureItem) this).HoleOutsideDisY = Math.Round(((MeasureItem) this).HoleOutsideDisY * buSystem.MmToInchRatio, 5);
    ((MeasureItem) this).HoleAngle3Point = Math.Round(((MeasureItem) this).HoleAngle3Point * buSystem.MmToInchRatio, 5);
    ((MeasureData) this).CutDiameter = Math.Round(((MeasureData) this).CutDiameter * buSystem.MmToInchRatio, 5);
    ((MeasureData) this).CutLength = Math.Round(((MeasureData) this).CutLength * buSystem.MmToInchRatio, 5);
    ((MeasureData) this).CutDepth = Math.Round(((MeasureData) this).CutDepth * buSystem.MmToInchRatio, 5);
    ((MeasureData) this).CutStartDistance = Math.Round(((MeasureData) this).CutStartDistance * buSystem.MmToInchRatio, 5);
    ((MeasureData) this).CutEndDistance = Math.Round(((MeasureData) this).CutEndDistance * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).ProfilingRadius = Math.Round(((CustomDataAdd) this).ProfilingRadius * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).ProfilingLength = Math.Round(((CustomDataAdd) this).ProfilingLength * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).ProfilingWidth = Math.Round(((CustomDataAdd) this).ProfilingWidth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).ProfilingHeight = Math.Round(((CustomDataAdd) this).ProfilingHeight * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).ProfilingDepth = Math.Round(((CustomDataAdd) this).ProfilingDepth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).EngravingWidth = Math.Round(((CustomDataAdd) this).EngravingWidth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).EngravingHeight = Math.Round(((CustomDataAdd) this).EngravingHeight * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).EngravingDepth = Math.Round(((CustomDataAdd) this).EngravingDepth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).EngravingOffsetZ = Math.Round(((CustomDataAdd) this).EngravingOffsetZ * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).JunctionDiameter = Math.Round(((CustomDataAdd) this).JunctionDiameter * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).JunctionDiameterOutside = Math.Round(((CustomDataAdd) this).JunctionDiameterOutside * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).JunctionDistance = Math.Round(((CustomDataAdd) this).JunctionDistance * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).JunctionDepth = Math.Round(((CustomDataAdd) this).JunctionDepth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).NotchWidth = Math.Round(((CustomDataAdd) this).NotchWidth * buSystem.MmToInchRatio, 5);
    ((CustomDataAdd) this).NotchHeight = Math.Round(((CustomDataAdd) this).NotchHeight * buSystem.MmToInchRatio, 5);
    ((MachineConfigSettings) this).NotchDepth = Math.Round(((MachineConfigSettings) this).NotchDepth * buSystem.MmToInchRatio, 5);
    ((MachineConfigSettings) this).NotchStartHeight = Math.Round(((MachineConfigSettings) this).NotchStartHeight * buSystem.MmToInchRatio, 5);
  }

  public void InchToMm()
  {
    ((camStep5) ((ShapeRuntimeData) this).CamPars).InchToMm();
    ((ColorDrawType) ((ShapeRuntimeData) this).Edit).InchToMm();
    ((ShapeRuntimeData) this).pntBase.X = Math.Round(((ShapeRuntimeData) this).pntBase.X * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) this).pntBase.Y = Math.Round(((ShapeRuntimeData) this).pntBase.Y * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) this).pntBase.Z = Math.Round(((ShapeRuntimeData) this).pntBase.Z * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.X = Math.Round(((ShapeRuntimeData) this).pntCalc.X * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.Y = Math.Round(((ShapeRuntimeData) this).pntCalc.Y * buSystem.InchToMmRatio, 5);
    ((ShapeRuntimeData) this).pntCalc.Z = Math.Round(((ShapeRuntimeData) this).pntCalc.Z * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailWidth = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailWidth * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailHeight = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailHeight * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).SizeMaterailDepth = Math.Round(((CurveToSurfaceSettingsType) this).SizeMaterailDepth * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).ExtraDepth = Math.Round(((CurveToSurfaceSettingsType) this).ExtraDepth * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).ManuelDepthStart = Math.Round(((CurveToSurfaceSettingsType) this).ManuelDepthStart * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).IncrementalDistance = Math.Round(((CurveToSurfaceSettingsType) this).IncrementalDistance * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).RectangleWidth = Math.Round(((CurveToSurfaceSettingsType) this).RectangleWidth * buSystem.InchToMmRatio, 5);
    ((CurveToSurfaceSettingsType) this).RectangleHeight = Math.Round(((CurveToSurfaceSettingsType) this).RectangleHeight * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).RectangleDepth = Math.Round(((SelectedPlaneInfo) this).RectangleDepth * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).RectangleAngle = Math.Round(((SelectedPlaneInfo) this).RectangleAngle * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).RectangleRadius = Math.Round(((SelectedPlaneInfo) this).RectangleRadius * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).RectangleChamfer = Math.Round(((SelectedPlaneInfo) this).RectangleChamfer * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).CircleRadius = Math.Round(((SelectedPlaneInfo) this).CircleRadius * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).CircleDepth = Math.Round(((SelectedPlaneInfo) this).CircleDepth * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).EllipseRadiusX = Math.Round(((SelectedPlaneInfo) this).EllipseRadiusX * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).EllipseRadiusY = Math.Round(((SelectedPlaneInfo) this).EllipseRadiusY * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).EllipseDepth = Math.Round(((SelectedPlaneInfo) this).EllipseDepth * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).PolygonRadius = Math.Round(((SelectedPlaneInfo) this).PolygonRadius * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).PolygonDepth = Math.Round(((SelectedPlaneInfo) this).PolygonDepth * buSystem.InchToMmRatio, 5);
    ((SelectedPlaneInfo) this).SlotLength = Math.Round(((SelectedPlaneInfo) this).SlotLength * buSystem.InchToMmRatio, 5);
    ((SelectionEntityTypes) this).SlotDiameter = Math.Round(((SelectionEntityTypes) this).SlotDiameter * buSystem.InchToMmRatio, 5);
    ((SelectionEntityTypes) this).SlotDepth = Math.Round(((SelectionEntityTypes) this).SlotDepth * buSystem.InchToMmRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleLength = Math.Round(((SelectionEntityTypes) this).KeyHoleLength * buSystem.InchToMmRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleHeadDiameter = Math.Round(((SelectionEntityTypes) this).KeyHoleHeadDiameter * buSystem.InchToMmRatio, 5);
    ((SelectionEntityTypes) this).KeyHoleDiameter = Math.Round(((SelectionEntityTypes) this).KeyHoleDiameter * buSystem.InchToMmRatio, 5);
    ((SelectionOperation) this).KeyHoleDepth = Math.Round(((SelectionOperation) this).KeyHoleDepth * buSystem.InchToMmRatio, 5);
    ((SelectionOperation) this).FreeDrawWidth = Math.Round(((SelectionOperation) this).FreeDrawWidth * buSystem.InchToMmRatio, 5);
    ((SelectionOperation) this).FreeDrawHeight = Math.Round(((SelectionOperation) this).FreeDrawHeight * buSystem.InchToMmRatio, 5);
    ((SelectionOperation) this).FreeDrawDepth = Math.Round(((SelectionOperation) this).FreeDrawDepth * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).TextWidth = Math.Round(((SelectionEntity) this).TextWidth * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).TextHeight = Math.Round(((SelectionEntity) this).TextHeight * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).TextDepth = Math.Round(((SelectionEntity) this).TextDepth * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).HoleDiameter = Math.Round(((SelectionEntity) this).HoleDiameter * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).HoleDiameterOutside = Math.Round(((SelectionEntity) this).HoleDiameterOutside * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).HoleDepth = Math.Round(((SelectionEntity) this).HoleDepth * buSystem.InchToMmRatio, 5);
    ((SelectionEntity) this).HoleDistance = Math.Round(((SelectionEntity) this).HoleDistance * buSystem.InchToMmRatio, 5);
    ((SelectionAlingmentPoints) this).HoleStartDistance = Math.Round(((SelectionAlingmentPoints) this).HoleStartDistance * buSystem.InchToMmRatio, 5);
    ((SelectionAlingmentPoints) this).HoleEndDistance = Math.Round(((SelectionAlingmentPoints) this).HoleEndDistance * buSystem.InchToMmRatio, 5);
    ((MeasureItem) this).HoleOutsideDisX = Math.Round(((MeasureItem) this).HoleOutsideDisX * buSystem.InchToMmRatio, 5);
    ((MeasureItem) this).HoleOutsideDisY = Math.Round(((MeasureItem) this).HoleOutsideDisY * buSystem.InchToMmRatio, 5);
    ((MeasureItem) this).HoleAngle3Point = Math.Round(((MeasureItem) this).HoleAngle3Point * buSystem.InchToMmRatio, 5);
    ((MeasureData) this).CutDiameter = Math.Round(((MeasureData) this).CutDiameter * buSystem.InchToMmRatio, 5);
    ((MeasureData) this).CutLength = Math.Round(((MeasureData) this).CutLength * buSystem.InchToMmRatio, 5);
    ((MeasureData) this).CutDepth = Math.Round(((MeasureData) this).CutDepth * buSystem.InchToMmRatio, 5);
    ((MeasureData) this).CutStartDistance = Math.Round(((MeasureData) this).CutStartDistance * buSystem.InchToMmRatio, 5);
    ((MeasureData) this).CutEndDistance = Math.Round(((MeasureData) this).CutEndDistance * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).ProfilingRadius = Math.Round(((CustomDataAdd) this).ProfilingRadius * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).ProfilingLength = Math.Round(((CustomDataAdd) this).ProfilingLength * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).ProfilingWidth = Math.Round(((CustomDataAdd) this).ProfilingWidth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).ProfilingHeight = Math.Round(((CustomDataAdd) this).ProfilingHeight * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).ProfilingDepth = Math.Round(((CustomDataAdd) this).ProfilingDepth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).EngravingWidth = Math.Round(((CustomDataAdd) this).EngravingWidth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).EngravingHeight = Math.Round(((CustomDataAdd) this).EngravingHeight * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).EngravingDepth = Math.Round(((CustomDataAdd) this).EngravingDepth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).EngravingOffsetZ = Math.Round(((CustomDataAdd) this).EngravingOffsetZ * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).JunctionDiameter = Math.Round(((CustomDataAdd) this).JunctionDiameter * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).JunctionDiameterOutside = Math.Round(((CustomDataAdd) this).JunctionDiameterOutside * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).JunctionDistance = Math.Round(((CustomDataAdd) this).JunctionDistance * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).JunctionDepth = Math.Round(((CustomDataAdd) this).JunctionDepth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).NotchWidth = Math.Round(((CustomDataAdd) this).NotchWidth * buSystem.InchToMmRatio, 5);
    ((CustomDataAdd) this).NotchHeight = Math.Round(((CustomDataAdd) this).NotchHeight * buSystem.InchToMmRatio, 5);
    ((MachineConfigSettings) this).NotchDepth = Math.Round(((MachineConfigSettings) this).NotchDepth * buSystem.InchToMmRatio, 5);
    ((MachineConfigSettings) this).NotchStartHeight = Math.Round(((MachineConfigSettings) this).NotchStartHeight * buSystem.InchToMmRatio, 5);
  }

  public hmiUICommands()
  {
    ((ShapeRuntimeData) this).CamPars = new camParameters5();
    ((ShapeRuntimeData) this).pntBase = new Point3D();
    ((ShapeRuntimeData) this).pntCalc = new Point3D();
    ((ShapeRuntimeData) this).pntCorner = new Point3D();
    ((ShapeRuntimeData) this).ShapeGroup = ShapeGroup.Shape;
    ((ShapeRuntimeData) this).DrillType = drillTypes.SingleHole;
    ((ShapeRuntimeData) this).CutType = CutTypes.CutHorizontal;
    ((ShapeRuntimeData) this).ProfilingType = ProfilingTypes.ProfilingRectangle;
    ((ShapeRuntimeData) this).JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    ((ShapeRuntimeData) this).ShapeType = ShapeTypes.Rectangle;
    ((ShapeRuntimeData) this).selectedPlane = planeBoxNames.Top;
    ((ShapeRuntimeData) this).selectedCorner = CornerLocation.LeftBottom;
    ((ShapeRuntimeData) this).objectAlignment = ObjectAlignment.MiddleCenter;
    ((ShapeRuntimeData) this).ValueType = ShapeDataValueType.None;
    ((ShapeRuntimeData) this).Edit = (ShapeEdit) new ColorType();
    ((ShapeRuntimeData) this).isTapping = false;
    ((ShapeRuntimeData) this).isMillingHole = false;
    ((ShapeRuntimeData) this).isMillingCut = false;
    ((ShapeRuntimeData) this).isMillingJunction = false;
    ((ShapeRuntimeData) this).isShapePocket = false;
    ((ShapeRuntimeData) this).isProfilingPocket = false;
    ((ShapeRuntimeData) this).isEngravePocket = false;
    ((ShapeRuntimeData) this).isIncrementalMode = false;
    ((ShapeTempData) this).ManuelDepthEnable = false;
    ((ShapeTempData) this).EachLayer = false;
    ((CurveToSurfaceSettingsType) this).Priority = 0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailWidth = 0.0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailHeight = 0.0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailDepth = 0.0;
    ((CurveToSurfaceSettingsType) this).ExtraDepth = 0.0;
    ((CurveToSurfaceSettingsType) this).ManuelDepthStart = 0.0;
    ((CurveToSurfaceSettingsType) this).IncrementalDistance = 100.0;
    ((CurveToSurfaceSettingsType) this).RectangleWidth = 20.0;
    ((CurveToSurfaceSettingsType) this).RectangleHeight = 20.0;
    ((SelectedPlaneInfo) this).RectangleDepth = 5.0;
    ((SelectedPlaneInfo) this).RectangleAngle = 0.0;
    ((SelectedPlaneInfo) this).RectangleRadius = 0.0;
    ((SelectedPlaneInfo) this).RectangleChamfer = 0.0;
    ((SelectedPlaneInfo) this).CircleRadius = 20.0;
    ((SelectedPlaneInfo) this).CircleDepth = 5.0;
    ((SelectedPlaneInfo) this).EllipseRadiusX = 20.0;
    ((SelectedPlaneInfo) this).EllipseRadiusY = 10.0;
    ((SelectedPlaneInfo) this).EllipseDepth = 5.0;
    ((SelectedPlaneInfo) this).EllipseAngle = 0.0;
    ((SelectedPlaneInfo) this).PolygonRadius = 20.0;
    ((SelectedPlaneInfo) this).PolygonSide = 5;
    ((SelectedPlaneInfo) this).PolygonDepth = 5.0;
    ((SelectedPlaneInfo) this).PolygonAngle = 0.0;
    ((SelectedPlaneInfo) this).SlotLength = 50.0;
    ((SelectionEntityTypes) this).SlotDiameter = 10.0;
    ((SelectionEntityTypes) this).SlotDepth = 5.0;
    ((SelectionEntityTypes) this).SlotAngle = 0.0;
    ((SelectionEntityTypes) this).KeyHoleLength = 33.0;
    ((SelectionEntityTypes) this).KeyHoleHeadDiameter = 17.0;
    ((SelectionEntityTypes) this).KeyHoleDiameter = 8.0;
    ((SelectionOperation) this).KeyHoleDepth = 0.0;
    ((SelectionOperation) this).KeyHoleAngle = 0.0;
    ((SelectionOperation) this).FreeDrawWidth = 20.0;
    ((SelectionOperation) this).FreeDrawHeight = 20.0;
    ((SelectionOperation) this).FreeDrawDepth = 5.0;
    ((SelectionEntity) this).FreeDrawAngle = 0.0;
    ((SelectionEntity) this).TextWidth = 20.0;
    ((SelectionEntity) this).TextHeight = 20.0;
    ((SelectionEntity) this).TextDepth = 5.0;
    ((SelectionEntity) this).TextAngle = 0.0;
    ((SelectionEntity) this).TextString = "";
    ((SelectionEntity) this).TextIsWire = false;
    ((SelectionEntity) this).TextFont = new Font("Arial", 10f);
    ((SelectionEntity) this).HoleDiameter = 8.0;
    ((SelectionEntity) this).HoleDiameterOutside = 8.0;
    ((SelectionEntity) this).HoleDepth = 5.0;
    ((SelectionEntity) this).HoleDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleCount = 2;
    ((SelectionAlingmentPoints) this).HoleStartDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleEndDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleAngle = 0.0;
    ((MeasureItem) this).HoleOutsideDisX = 40.0;
    ((MeasureItem) this).HoleOutsideDisY = 10.0;
    ((MeasureItem) this).HoleAngle3Point = 0.0;
    ((MeasureItem) this).TappingDiameter = 8.0;
    ((MeasureItem) this).TappingPitch = 2.0;
    ((MeasureItem) this).TappingAdditional = 1.0;
    ((MeasureData) this).TappingDepth = 5.0;
    ((MeasureData) this).CutDiameter = 8.0;
    ((MeasureData) this).CutLength = 100.0;
    ((MeasureData) this).CutDepth = 5.0;
    ((MeasureData) this).CutStartDistance = 0.0;
    ((MeasureData) this).CutEndDistance = 0.0;
    ((CustomDataAdd) this).CutAngle = 0.0;
    ((CustomDataAdd) this).ProfilingRadius = 8.0;
    ((CustomDataAdd) this).ProfilingLength = 10.0;
    ((CustomDataAdd) this).ProfilingWidth = 20.0;
    ((CustomDataAdd) this).ProfilingHeight = 20.0;
    ((CustomDataAdd) this).ProfilingDepth = 5.0;
    ((CustomDataAdd) this).EngravingWidth = 100.0;
    ((CustomDataAdd) this).EngravingHeight = 100.0;
    ((CustomDataAdd) this).EngravingDepth = 5.0;
    ((CustomDataAdd) this).EngravingOffsetZ = 0.0;
    ((CustomDataAdd) this).JunctionDiameter = 8.0;
    ((CustomDataAdd) this).JunctionDiameterOutside = 5.0;
    ((CustomDataAdd) this).JunctionDistance = 100.0;
    ((CustomDataAdd) this).JunctionDepth = 5.0;
    ((CustomDataAdd) this).NotchWidth = 10.0;
    ((CustomDataAdd) this).NotchHeight = 10.0;
    ((MachineConfigSettings) this).NotchDepth = 10.0;
    ((MachineConfigSettings) this).NotchStartHeight = 0.0;
    ((dynamicInfo) this).NotchCutPersentage = 90.0;
    ((dynamicInfo) this).NotchOPType = ProfileNotchOperationType.Side;
    ((dynamicInfo) this).NotchUpDown = UpDownLocationType.Up;
    ((dynamicInfo) this).NotchFrontBack = FrontBackType.Front;
    ((dynamicInfo) this).NotchSideLocation = ProfileNotchLocationType.Left;
    ((dynamicInfo) this).NotchLengthLocation = ProfileNotchLocationType.Front;
    ((dynamicInfo) this).CutDirection = UpDownDirectionType.UpToDown;
    ((dynamicInfo) this).NotchCutType = ProfileNotchCutType.BySawAndMilling;
    ((dynamicInfo) this).NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;
    ((dynamicInfo) this).UpdateEditOperationWithoutOk = false;
    ((dynamicInfo) this).DepthLevels = new List<double>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(ShapeRuntimeData data)
  {
    ((ShapeRuntimeData) this).CamPars = new camParameters5();
    ((ShapeRuntimeData) this).pntBase = new Point3D();
    ((ShapeRuntimeData) this).pntCalc = new Point3D();
    ((ShapeRuntimeData) this).pntCorner = new Point3D();
    ((ShapeRuntimeData) this).ShapeGroup = ShapeGroup.Shape;
    ((ShapeRuntimeData) this).DrillType = drillTypes.SingleHole;
    ((ShapeRuntimeData) this).CutType = CutTypes.CutHorizontal;
    ((ShapeRuntimeData) this).ProfilingType = ProfilingTypes.ProfilingRectangle;
    ((ShapeRuntimeData) this).JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    ((ShapeRuntimeData) this).ShapeType = ShapeTypes.Rectangle;
    ((ShapeRuntimeData) this).selectedPlane = planeBoxNames.Top;
    ((ShapeRuntimeData) this).selectedCorner = CornerLocation.LeftBottom;
    ((ShapeRuntimeData) this).objectAlignment = ObjectAlignment.MiddleCenter;
    ((ShapeRuntimeData) this).ValueType = ShapeDataValueType.None;
    ((ShapeRuntimeData) this).Edit = (ShapeEdit) new ColorType();
    ((ShapeRuntimeData) this).isTapping = false;
    ((ShapeRuntimeData) this).isMillingHole = false;
    ((ShapeRuntimeData) this).isMillingCut = false;
    ((ShapeRuntimeData) this).isMillingJunction = false;
    ((ShapeRuntimeData) this).isShapePocket = false;
    ((ShapeRuntimeData) this).isProfilingPocket = false;
    ((ShapeRuntimeData) this).isEngravePocket = false;
    ((ShapeRuntimeData) this).isIncrementalMode = false;
    ((ShapeTempData) this).ManuelDepthEnable = false;
    ((ShapeTempData) this).EachLayer = false;
    ((CurveToSurfaceSettingsType) this).Priority = 0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailWidth = 0.0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailHeight = 0.0;
    ((CurveToSurfaceSettingsType) this).SizeMaterailDepth = 0.0;
    ((CurveToSurfaceSettingsType) this).ExtraDepth = 0.0;
    ((CurveToSurfaceSettingsType) this).ManuelDepthStart = 0.0;
    ((CurveToSurfaceSettingsType) this).IncrementalDistance = 100.0;
    ((CurveToSurfaceSettingsType) this).RectangleWidth = 20.0;
    ((CurveToSurfaceSettingsType) this).RectangleHeight = 20.0;
    ((SelectedPlaneInfo) this).RectangleDepth = 5.0;
    ((SelectedPlaneInfo) this).RectangleAngle = 0.0;
    ((SelectedPlaneInfo) this).RectangleRadius = 0.0;
    ((SelectedPlaneInfo) this).RectangleChamfer = 0.0;
    ((SelectedPlaneInfo) this).CircleRadius = 20.0;
    ((SelectedPlaneInfo) this).CircleDepth = 5.0;
    ((SelectedPlaneInfo) this).EllipseRadiusX = 20.0;
    ((SelectedPlaneInfo) this).EllipseRadiusY = 10.0;
    ((SelectedPlaneInfo) this).EllipseDepth = 5.0;
    ((SelectedPlaneInfo) this).EllipseAngle = 0.0;
    ((SelectedPlaneInfo) this).PolygonRadius = 20.0;
    ((SelectedPlaneInfo) this).PolygonSide = 5;
    ((SelectedPlaneInfo) this).PolygonDepth = 5.0;
    ((SelectedPlaneInfo) this).PolygonAngle = 0.0;
    ((SelectedPlaneInfo) this).SlotLength = 50.0;
    ((SelectionEntityTypes) this).SlotDiameter = 10.0;
    ((SelectionEntityTypes) this).SlotDepth = 5.0;
    ((SelectionEntityTypes) this).SlotAngle = 0.0;
    ((SelectionEntityTypes) this).KeyHoleLength = 33.0;
    ((SelectionEntityTypes) this).KeyHoleHeadDiameter = 17.0;
    ((SelectionEntityTypes) this).KeyHoleDiameter = 8.0;
    ((SelectionOperation) this).KeyHoleDepth = 0.0;
    ((SelectionOperation) this).KeyHoleAngle = 0.0;
    ((SelectionOperation) this).FreeDrawWidth = 20.0;
    ((SelectionOperation) this).FreeDrawHeight = 20.0;
    ((SelectionOperation) this).FreeDrawDepth = 5.0;
    ((SelectionEntity) this).FreeDrawAngle = 0.0;
    ((SelectionEntity) this).TextWidth = 20.0;
    ((SelectionEntity) this).TextHeight = 20.0;
    ((SelectionEntity) this).TextDepth = 5.0;
    ((SelectionEntity) this).TextAngle = 0.0;
    ((SelectionEntity) this).TextString = "";
    ((SelectionEntity) this).TextIsWire = false;
    ((SelectionEntity) this).TextFont = new Font("Arial", 10f);
    ((SelectionEntity) this).HoleDiameter = 8.0;
    ((SelectionEntity) this).HoleDiameterOutside = 8.0;
    ((SelectionEntity) this).HoleDepth = 5.0;
    ((SelectionEntity) this).HoleDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleCount = 2;
    ((SelectionAlingmentPoints) this).HoleStartDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleEndDistance = 0.0;
    ((SelectionAlingmentPoints) this).HoleAngle = 0.0;
    ((MeasureItem) this).HoleOutsideDisX = 40.0;
    ((MeasureItem) this).HoleOutsideDisY = 10.0;
    ((MeasureItem) this).HoleAngle3Point = 0.0;
    ((MeasureItem) this).TappingDiameter = 8.0;
    ((MeasureItem) this).TappingPitch = 2.0;
    ((MeasureItem) this).TappingAdditional = 1.0;
    ((MeasureData) this).TappingDepth = 5.0;
    ((MeasureData) this).CutDiameter = 8.0;
    ((MeasureData) this).CutLength = 100.0;
    ((MeasureData) this).CutDepth = 5.0;
    ((MeasureData) this).CutStartDistance = 0.0;
    ((MeasureData) this).CutEndDistance = 0.0;
    ((CustomDataAdd) this).CutAngle = 0.0;
    ((CustomDataAdd) this).ProfilingRadius = 8.0;
    ((CustomDataAdd) this).ProfilingLength = 10.0;
    ((CustomDataAdd) this).ProfilingWidth = 20.0;
    ((CustomDataAdd) this).ProfilingHeight = 20.0;
    ((CustomDataAdd) this).ProfilingDepth = 5.0;
    ((CustomDataAdd) this).EngravingWidth = 100.0;
    ((CustomDataAdd) this).EngravingHeight = 100.0;
    ((CustomDataAdd) this).EngravingDepth = 5.0;
    ((CustomDataAdd) this).EngravingOffsetZ = 0.0;
    ((CustomDataAdd) this).JunctionDiameter = 8.0;
    ((CustomDataAdd) this).JunctionDiameterOutside = 5.0;
    ((CustomDataAdd) this).JunctionDistance = 100.0;
    ((CustomDataAdd) this).JunctionDepth = 5.0;
    ((CustomDataAdd) this).NotchWidth = 10.0;
    ((CustomDataAdd) this).NotchHeight = 10.0;
    ((MachineConfigSettings) this).NotchDepth = 10.0;
    ((MachineConfigSettings) this).NotchStartHeight = 0.0;
    ((dynamicInfo) this).NotchCutPersentage = 90.0;
    ((dynamicInfo) this).NotchOPType = ProfileNotchOperationType.Side;
    ((dynamicInfo) this).NotchUpDown = UpDownLocationType.Up;
    ((dynamicInfo) this).NotchFrontBack = FrontBackType.Front;
    ((dynamicInfo) this).NotchSideLocation = ProfileNotchLocationType.Left;
    ((dynamicInfo) this).NotchLengthLocation = ProfileNotchLocationType.Front;
    ((dynamicInfo) this).CutDirection = UpDownDirectionType.UpToDown;
    ((dynamicInfo) this).NotchCutType = ProfileNotchCutType.BySawAndMilling;
    ((dynamicInfo) this).NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;
    ((dynamicInfo) this).UpdateEditOperationWithoutOk = false;
    ((dynamicInfo) this).DepthLevels = new List<double>();
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
    ((ShapeRuntimeData) this).CamPars = (camParameters5) new camRuntime5(data.CamPars);
    ((ShapeRuntimeData) this).Edit = (ShapeEdit) new ColorType(data.Edit);
    ((ShapeRuntimeData) this).pntBase = new Point3D(data.pntBase.X, data.pntBase.Y, data.pntBase.Z);
    ((ShapeRuntimeData) this).pntCalc = new Point3D(data.pntCalc.X, data.pntCalc.Y, data.pntCalc.Z);
    ((ShapeRuntimeData) this).pntCorner = new Point3D(data.pntCorner.X, data.pntCorner.Y, data.pntCorner.Z);
  }

  public override string ToString()
  {
    return $"X :{((ShapeRuntimeData) this).pntBase.X.ToString()}, Y :{((ShapeRuntimeData) this).pntBase.Y.ToString()}, Z :{((ShapeRuntimeData) this).pntBase.Z.ToString()}";
  }

  public abstract void m00032E();

  public hmiUICommands()
  {
    ((dynamicInfo) this).ValueType = ShapeDataValueType.None;
    ((dynamicInfo) this).ValueGridIndex = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(ShapeTempData data)
  {
    ((dynamicInfo) this).ValueType = ShapeDataValueType.None;
    ((dynamicInfo) this).ValueGridIndex = 0;
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

  public override string ToString() => "ValueType :" + ((dynamicInfo) this).ValueType.ToString();

  public abstract void m000332();

  public hmiUICommands()
  {
    ((dynamicInfo) this).SurfaceOffset = 0.0;
    ((dynamicInfo) this).MinDistance = 0.0;
    ((dynamicInfo) this).MaxDistance = 0.0;
    ((HighLights) this).MaxZ = 0.0;
    ((HighLights) this).MinZ = 0.0;
    ((HighLights) this).InsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).OutsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).SilhouetteToPartEnd = false;
    ((WriteDxfDwgPropeties) this).isVertical = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public hmiUICommands(
    double surfaceOffset,
    double minDistance,
    double maxDistance,
    bool silhouetteToPartEnd)
  {
    ((dynamicInfo) this).SurfaceOffset = 0.0;
    ((dynamicInfo) this).MinDistance = 0.0;
    ((dynamicInfo) this).MaxDistance = 0.0;
    ((HighLights) this).MaxZ = 0.0;
    ((HighLights) this).MinZ = 0.0;
    ((HighLights) this).InsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).OutsideOffset = 0.0;
    ((WriteDxfDwgPropeties) this).SilhouetteToPartEnd = false;
    ((WriteDxfDwgPropeties) this).isVertical = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((dynamicInfo) this).SurfaceOffset = surfaceOffset;
    ((dynamicInfo) this).MinDistance = minDistance;
    ((dynamicInfo) this).MaxDistance = maxDistance;
    ((WriteDxfDwgPropeties) this).SilhouetteToPartEnd = silhouetteToPartEnd;
  }
}
