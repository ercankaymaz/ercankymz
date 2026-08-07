// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buNestingCalc : IDisposable
{
  public double ClamperBetweenMinDistance;
  public double ClamperLength;
  public double ClamperOperationMinDistance;
  public double ClamperSafeXDistance;
  public double ClamperMinCatchXDistance;
  public double ClamperCatchDistanceInsideFromMaterial;
  public double ClamperFirstPositionOffset;

  public buNestingCalc()
  {
    ((DrillItem) this).PlaneType = FoamPlaneType.XZ;
    ((DrillItem) this).Direction = NormalReverse.Normal;
    ((DrillItem) this).sortEntities = new List<List<buEntity>>();
    ((DrillItem) this).MinPoint = new Point3D();
    ((DrillItem) this).MaxPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamSortGroup data)
  {
    ((DrillItem) this).PlaneType = FoamPlaneType.XZ;
    ((DrillItem) this).Direction = NormalReverse.Normal;
    ((DrillItem) this).sortEntities = new List<List<buEntity>>();
    ((DrillItem) this).MinPoint = new Point3D();
    ((DrillItem) this).MaxPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null)
    {
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
      ((DrillItem) this).MinPoint = F_NotchEdit.ToPoint3D(((DrillItem) data).MinPoint);
      ((DrillItem) this).MaxPoint = F_NotchEdit.ToPoint3D(((DrillItem) data).MaxPoint);
    }
    buRadialDim.Copy(((DrillItem) data).sortEntities, ref ((DrillItem) this).sortEntities);
  }

  public override string ToString()
  {
    string str1 = "";
    string str2 = "";
    if (((DrillItem) this).sortEntities.Count > 0)
    {
      buEntity buEntity1 = ((DrillItem) this).sortEntities[0][0];
      if (((CustomData) buEntity1).sortDirection == entitySortDirection.Normal)
      {
        if (((DrillItem) this).PlaneType == FoamPlaneType.XZ)
          str1 = $" - SP- X: {((CustomData) buEntity1).StartPoint.X.ToString("f1")} , Z: {((CustomData) buEntity1).StartPoint.Z.ToString("f1")}";
        if (((DrillItem) this).PlaneType == FoamPlaneType.YZ)
          str1 = $" - SP- Y: {((CustomData) buEntity1).StartPoint.Y.ToString("f1")} , Z: {((CustomData) buEntity1).StartPoint.Z.ToString("f1")}";
      }
      else
      {
        if (((DrillItem) this).PlaneType == FoamPlaneType.XZ)
          str1 = $" - SP- X: {((CustomData) buEntity1).EndPoint.X.ToString("f1")} , Z: {((CustomData) buEntity1).EndPoint.Z.ToString("f1")}";
        if (((DrillItem) this).PlaneType == FoamPlaneType.YZ)
          str1 = $" - SP- Y: {((CustomData) buEntity1).EndPoint.Y.ToString("f1")} , Z: {((CustomData) buEntity1).EndPoint.Z.ToString("f1")}";
      }
      buEntity buEntity2 = ((DrillItem) this).sortEntities[((DrillItem) this).sortEntities.Count - 1][((DrillItem) this).sortEntities[((DrillItem) this).sortEntities.Count - 1].Count - 1];
      if (((CustomData) buEntity2).sortDirection == entitySortDirection.Normal)
      {
        if (((DrillItem) this).PlaneType == FoamPlaneType.XZ)
          str2 = $" | EP- X: {((CustomData) buEntity2).EndPoint.X.ToString("f1")} , Z: {((CustomData) buEntity1).EndPoint.Z.ToString("f1")}";
        if (((DrillItem) this).PlaneType == FoamPlaneType.YZ)
          str2 = $" | EP- Y: {((CustomData) buEntity2).EndPoint.Y.ToString("f1")} , Z: {((CustomData) buEntity1).EndPoint.Z.ToString("f1")}";
      }
      else
      {
        if (((DrillItem) this).PlaneType == FoamPlaneType.XZ)
          str2 = $" | EP- X: {((CustomData) buEntity2).StartPoint.X.ToString("f1")} , Z: {((CustomData) buEntity1).StartPoint.Z.ToString("f1")}";
        if (((DrillItem) this).PlaneType == FoamPlaneType.YZ)
          str2 = $" | EP- Y: {((CustomData) buEntity2).StartPoint.Y.ToString("f1")} , Z: {((CustomData) buEntity1).StartPoint.Z.ToString("f1")}";
      }
    }
    return $"{((DrillItem) this).Direction.ToString()} - Cnt: {((DrillItem) this).sortEntities.Count.ToString()}{str1}{str2}";
  }

  public abstract void m001B9B();

  public buNestingCalc()
  {
    ((DrillItem) this).Plane = FoamPlaneType.XZ;
    ((DrillItem) this).BlockIndex = 0;
    ((DrillItem) this).PatternIndex = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamActiveBlock data)
  {
    ((DrillItem) this).Plane = FoamPlaneType.XZ;
    ((DrillItem) this).BlockIndex = 0;
    ((DrillItem) this).PatternIndex = 0;
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
    return $"{((DrillItem) this).Plane.ToString()} - BlockIndex: {((DrillItem) this).BlockIndex.ToString()}";
  }

  public abstract void m001B9F();

  public buNestingCalc()
  {
    ((DrillItem) this).Cutting = 0.0;
    ((DrillItem) this).LeadIn = 0.0;
    ((DrillItem) this).LeadOut = 0.0;
    ((DrillItem) this).Connection = 0.0;
    ((DrillItem) this).CRotation = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(
    double cutting,
    double leadin,
    double leadout,
    double connection,
    double crotation)
  {
    ((DrillItem) this).Cutting = 0.0;
    ((DrillItem) this).LeadIn = 0.0;
    ((DrillItem) this).LeadOut = 0.0;
    ((DrillItem) this).Connection = 0.0;
    ((DrillItem) this).CRotation = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillItem) this).Cutting = cutting;
    ((DrillItem) this).LeadIn = leadin;
    ((DrillItem) this).LeadOut = leadout;
    ((DrillItem) this).Connection = connection;
    ((DrillItem) this).CRotation = crotation;
  }

  public buNestingCalc(FoamSpeeds data)
  {
    ((DrillItem) this).Cutting = 0.0;
    ((DrillItem) this).LeadIn = 0.0;
    ((DrillItem) this).LeadOut = 0.0;
    ((DrillItem) this).Connection = 0.0;
    ((DrillItem) this).CRotation = 0.0;
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
    return $"Cutting: {((DrillItem) this).Cutting.ToString()} - LeadIn: {((DrillItem) this).LeadIn.ToString()} - LeadOut: {((DrillItem) this).LeadOut.ToString()} - Connection: {((DrillItem) this).Connection.ToString()} - CRotation: {((DrillItem) this).CRotation.ToString()}";
  }

  public abstract void m001BA4();

  public buNestingCalc()
  {
    ((DrillItem) this).TotalArea = 0.0;
    ((DrillItem) this).BoxArea = 0.0;
    ((DrillItem) this).UsedPersentageFromBoxArea = 0.0;
    ((DrillItem) this).TotalCuttingLength = 0.0;
    ((DrillItem) this).TotalNoCuttingLength = 0.0;
    ((DrillItem) this).TimeCutting = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(
    double totalArea,
    double boxArea,
    double usedPersentageFromBoxArea,
    double totalCuttingLength,
    double totalNoCuttingLength,
    double timeCutting)
  {
    ((DrillItem) this).TotalArea = 0.0;
    ((DrillItem) this).BoxArea = 0.0;
    ((DrillItem) this).UsedPersentageFromBoxArea = 0.0;
    ((DrillItem) this).TotalCuttingLength = 0.0;
    ((DrillItem) this).TotalNoCuttingLength = 0.0;
    ((DrillItem) this).TimeCutting = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillItem) this).TotalArea = totalArea;
    ((DrillItem) this).BoxArea = boxArea;
    ((DrillItem) this).UsedPersentageFromBoxArea = usedPersentageFromBoxArea;
    ((DrillItem) this).TotalCuttingLength = totalCuttingLength;
    ((DrillItem) this).TotalNoCuttingLength = totalNoCuttingLength;
    ((DrillItem) this).TimeCutting = timeCutting;
  }

  public buNestingCalc(FoamPatternInfo data)
  {
    ((DrillItem) this).TotalArea = 0.0;
    ((DrillItem) this).BoxArea = 0.0;
    ((DrillItem) this).UsedPersentageFromBoxArea = 0.0;
    ((DrillItem) this).TotalCuttingLength = 0.0;
    ((DrillItem) this).TotalNoCuttingLength = 0.0;
    ((DrillItem) this).TimeCutting = 0.0;
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
    return $"TotalArea: {((DrillItem) this).TotalArea.ToString()} - BoxArea: {((DrillItem) this).BoxArea.ToString()} - %: {((DrillItem) this).UsedPersentageFromBoxArea.ToString()} - TimeCutting: {((DrillItem) this).TimeCutting.ToString()}";
  }

  public abstract void m001BA9();

  public buNestingCalc()
  {
    ((DrillItem) this).RegenDeviation = 0.05;
    ((DrillItem) this).MaxDevideLen = 2.0;
    ((DrillItem) this).AngleLimitOnlyCRotation = 20.0;
    ((DrillItem) this).ShowOperationInfo = false;
    ((DrillItem) this).DirectionArrowHeadLength = 20.0;
    ((DrillItem) this).DirectionArrowHeadAngle = 20.0;
    ((DrillItem) this).StartPointDiameter = 8.0;
    ((DrillItem) this).LastPointDiameter = 5.0;
    ((DrillItem) this).EqualValue = 2.0;
    ((DrillItem) this).TangentMaxAngle = 0.0;
    ((DrillItem) this).TangentMinAngle = 0.0;
    ((DrillItem) this).GCodeRegenDEviation = 0.01;
    ((DrillMove) this).ContiniousTangent = false;
    ((DrillMove) this).PatternDistancesWidth = 5.0;
    ((DrillMove) this).PatternDistancesHeight = 5.0;
    ((DrillMove) this).PartDistances = 5.0;
    ((DrillMove) this).EntryFeed = 1000.0;
    ((DrillMove) this).CuttingFeed = 1000.0;
    ((DrillMove) this).LeaveFeed = 1000.0;
    ((DrillMove) this).CRotationFeed = 5000.0;
    ((DrillMove) this).ConnectionFeed = 5000.0;
    ((DrillMove) this).BlockSpace = 5.0;
    ((DrillMove) this).LeadInLength = 10.0;
    ((DrillMove) this).LeadOutLength = 10.0;
    ((DrillMove) this).SequenceHorizontal = FoamSequenceHor.HorizontalStartThenEnd;
    ((DrillMove) this).SequenceVertical = FoamSequenceVer.VerticalStartThenEnd;
    ((DrillMove) this).ZDirection = UpToDownType.DownToUp;
    ((DrillMove) this).ComplateClosedDrawingAfterFirstSelect = false;
    ((DrillMove) this).RotateCBeforeCutting = true;
    ((DrillMove) this).FromFileKeepRatio = true;
    ((DrillMove) this).NonLinearCAxis = false;
    ((DrillMove) this).LeaveAlwaysFromStart = true;
    ((DrillMove) this).LeaveAlwaysZeroZOffsetFromBlockHeight = 10.0;
    ((DrillMove) this).MoveZUpPosition = true;
    ((DrillMove) this).Draw3D = true;
    ((DrillMove) this).UseG1InsteadOfG0 = true;
    ((DrillMove) this).UseCRotationAsG0Always = true;
    ((DrillMove) this).UseMultiColor = true;
    ((DrillMove) this).CheckFoamSize = true;
    ((DrillMove) this).CheckMachineSize = true;
    ((DrillMove) this).UseRadiusFeedTable = true;
    ((DrillMove) this).UseLengthFeedTable = true;
    ((DrillMove) this).ShowInfoAtGCodes = true;
    ((DrillMove) this).CAngleOffset = 0.0;
    ((DrillMove) this).MachineInitialAngle = 0.0;
    ((DrillMove) this).MachineLimitX = 4000.0;
    ((DrillMove) this).MachineLimitY = 2500.0;
    ((DrillMove) this).MachineLimitZ = 3000.0;
    ((DrillMove) this).MachineLimitMinX = 0.0;
    ((DrillMove) this).MachineLimitMinY = 0.0;
    ((DrillMove) this).MachineLimitMinZ = 15.0;
    ((DrillMove) this).MachineG0Speed = 100.0;
    ((DrillMove) this).MachineG0TangentSpeed = 200.0;
    ((DrillMove) this).pathFromFile = "C:\\";
    ((DrillMove) this).FoamBaseTransparency = 150;
    ((DrillMove) this).OnlineBorderDrawOffset = 1.0;
    ((DrillMove) this).FoamBaseColor = Color.Gray;
    ((DrillMove) this).MarkColor = Color.DarkOrange;
    ((DrillMove) this).MarkLastColor = Color.Lavender;
    ((DrillMove) this).SortUpperColor = Color.Red;
    ((DrillMove) this).SortCutColor = Color.Blue;
    ((DrillMove) this).LeadInColor = Color.Lime;
    ((DrillMove) this).LeadOutColor = Color.DarkMagenta;
    ((DrillFound) this).ConenctionColor = Color.Cyan;
    ((DrillFound) this).LimitExceedColor = Color.Pink;
    ((DrillFindTool) this).RotationMoreThen180 = Color.DeepPink;
    ((DrillFindTool) this).UnitLength = LengthUnit.mm;
    ((DrillFindTool) this).UnitSpeed = SpeedUnit.mmPerSec;
    ((DrillFindTool) this).OperationWindow = ProfileOperationWindowType.AutoHideDock;
    ((DrillFindTool) this).OperationWindowClose = ProfileOperationWindowCloseType.Hide;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamSettings data)
  {
    ((DrillItem) this).RegenDeviation = 0.05;
    ((DrillItem) this).MaxDevideLen = 2.0;
    ((DrillItem) this).AngleLimitOnlyCRotation = 20.0;
    ((DrillItem) this).ShowOperationInfo = false;
    ((DrillItem) this).DirectionArrowHeadLength = 20.0;
    ((DrillItem) this).DirectionArrowHeadAngle = 20.0;
    ((DrillItem) this).StartPointDiameter = 8.0;
    ((DrillItem) this).LastPointDiameter = 5.0;
    ((DrillItem) this).EqualValue = 2.0;
    ((DrillItem) this).TangentMaxAngle = 0.0;
    ((DrillItem) this).TangentMinAngle = 0.0;
    ((DrillItem) this).GCodeRegenDEviation = 0.01;
    ((DrillMove) this).ContiniousTangent = false;
    ((DrillMove) this).PatternDistancesWidth = 5.0;
    ((DrillMove) this).PatternDistancesHeight = 5.0;
    ((DrillMove) this).PartDistances = 5.0;
    ((DrillMove) this).EntryFeed = 1000.0;
    ((DrillMove) this).CuttingFeed = 1000.0;
    ((DrillMove) this).LeaveFeed = 1000.0;
    ((DrillMove) this).CRotationFeed = 5000.0;
    ((DrillMove) this).ConnectionFeed = 5000.0;
    ((DrillMove) this).BlockSpace = 5.0;
    ((DrillMove) this).LeadInLength = 10.0;
    ((DrillMove) this).LeadOutLength = 10.0;
    ((DrillMove) this).SequenceHorizontal = FoamSequenceHor.HorizontalStartThenEnd;
    ((DrillMove) this).SequenceVertical = FoamSequenceVer.VerticalStartThenEnd;
    ((DrillMove) this).ZDirection = UpToDownType.DownToUp;
    ((DrillMove) this).ComplateClosedDrawingAfterFirstSelect = false;
    ((DrillMove) this).RotateCBeforeCutting = true;
    ((DrillMove) this).FromFileKeepRatio = true;
    ((DrillMove) this).NonLinearCAxis = false;
    ((DrillMove) this).LeaveAlwaysFromStart = true;
    ((DrillMove) this).LeaveAlwaysZeroZOffsetFromBlockHeight = 10.0;
    ((DrillMove) this).MoveZUpPosition = true;
    ((DrillMove) this).Draw3D = true;
    ((DrillMove) this).UseG1InsteadOfG0 = true;
    ((DrillMove) this).UseCRotationAsG0Always = true;
    ((DrillMove) this).UseMultiColor = true;
    ((DrillMove) this).CheckFoamSize = true;
    ((DrillMove) this).CheckMachineSize = true;
    ((DrillMove) this).UseRadiusFeedTable = true;
    ((DrillMove) this).UseLengthFeedTable = true;
    ((DrillMove) this).ShowInfoAtGCodes = true;
    ((DrillMove) this).CAngleOffset = 0.0;
    ((DrillMove) this).MachineInitialAngle = 0.0;
    ((DrillMove) this).MachineLimitX = 4000.0;
    ((DrillMove) this).MachineLimitY = 2500.0;
    ((DrillMove) this).MachineLimitZ = 3000.0;
    ((DrillMove) this).MachineLimitMinX = 0.0;
    ((DrillMove) this).MachineLimitMinY = 0.0;
    ((DrillMove) this).MachineLimitMinZ = 15.0;
    ((DrillMove) this).MachineG0Speed = 100.0;
    ((DrillMove) this).MachineG0TangentSpeed = 200.0;
    ((DrillMove) this).pathFromFile = "C:\\";
    ((DrillMove) this).FoamBaseTransparency = 150;
    ((DrillMove) this).OnlineBorderDrawOffset = 1.0;
    ((DrillMove) this).FoamBaseColor = Color.Gray;
    ((DrillMove) this).MarkColor = Color.DarkOrange;
    ((DrillMove) this).MarkLastColor = Color.Lavender;
    ((DrillMove) this).SortUpperColor = Color.Red;
    ((DrillMove) this).SortCutColor = Color.Blue;
    ((DrillMove) this).LeadInColor = Color.Lime;
    ((DrillMove) this).LeadOutColor = Color.DarkMagenta;
    ((DrillFound) this).ConenctionColor = Color.Cyan;
    ((DrillFound) this).LimitExceedColor = Color.Pink;
    ((DrillFindTool) this).RotationMoreThen180 = Color.DeepPink;
    ((DrillFindTool) this).UnitLength = LengthUnit.mm;
    ((DrillFindTool) this).UnitSpeed = SpeedUnit.mmPerSec;
    ((DrillFindTool) this).OperationWindow = ProfileOperationWindowType.AutoHideDock;
    ((DrillFindTool) this).OperationWindowClose = ProfileOperationWindowCloseType.Hide;
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

  public abstract void m001BAC();

  public buNestingCalc()
  {
    ((DrillFindTool) this).WaveFormPyramidShapeHeight = 30.0;
    ((DrillFindTool) this).WaveFormPyramidShapeWidth = 30.0;
    ((DrillFindTool) this).WaveFormPyramidShapeBaseHeight = 15.0;
    ((DrillFindTool) this).WaveFormPyramidShapeCount = 5.0;
    ((DrillFindTool) this).WaveFormVShapeHeight = 30.0;
    ((DrillFindTool) this).WaveFormVShapeWidth = 30.0;
    ((DrillShapeData) this).WaveFormVShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormUShapeHeight = 30.0;
    ((DrillShapeData) this).WaveFormUShapeWidth = 30.0;
    ((DrillShapeData) this).WaveFormUShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormSShapeHeight = 20.0;
    ((DrillShapeData) this).WaveFormSShapeWidth = 60.0;
    ((DrillShapeData) this).WaveFormSShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormCShapeHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormCShapeWidth = 60.0;
    ((DrillMoveOptions) this).WaveFormCShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormZShapeHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormZShapeWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormZShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormRectShapeHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormRectShapeWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormRectShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonCount = 5.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonRoundRad = 0.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonChamferLen = 0.0;
    ((DrillMoveOptions) this).WaveFormRepeatCount = 0;
    ((DrillMoveOptions) this).WaveFormSpace = 0.0;
    ((DrillMoveOptions) this).SlicesHeight = 50.0;
    ((DrillMoveOptions) this).ShapeLength = 500.0;
    ((DrillMoveOptions) this).WaveFormTopHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormBottomHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormZHeight = 0.0;
    ((DrillMoveOptions) this).WaveFormStartOffset = 0.0;
    ((DrillMoveOptions) this).WaveFormEndOffset = 0.0;
    ((DrillMoveOptions) this).MoveX = 0.0;
    ((DrillMoveOptions) this).BlockName = "Block";
    ((DrillMoveOptions) this).BlockWidth = 0.0;
    ((DrillCNCSettings) this).BlockHeight = 0.0;
    ((DrillCNCSettings) this).BlockIdealWidth = 0.0;
    ((DrillCNCSettings) this).BlockIdealHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).PatternOrjWidth = 0.0;
    ((DrillCNCSettings) this).PatternOrjHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidthStartOffset = 10.0;
    ((DrillCNCSettings) this).PatternWidthEndOffset = 10.0;
    ((DrillCNCSettings) this).PatternHeightStartOffset = 10.0;
    ((DrillCNCSettings) this).PatternHeightEndOffset = 10.0;
    ((DrillCNCSettings) this).PatternMirrorX = false;
    ((DrillCNCSettings) this).PatternMirrorY = false;
    ((DrillCNCSettings) this).DrawBorder = true;
    ((DrillCNCSettings) this).WaveReverse = false;
    ((DrillCNCSettings) this).WaveUpDownDirection = true;
    ((DrillCNCSettings) this).SemiAutoSelection = false;
    ((DrillCNCSettings) this).ShowVirtualDrawings = false;
    ((DrillCNCSettings) this).MaterialWidth = 2000.0;
    ((DrillCNCSettings) this).MaterialHeight = 1000.0;
    ((DrillCNCSettings) this).MaterialDepth = 500.0;
    ((DrillCNCSettings) this).planeNames = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).TypeFoam = FoamType.VForm;
    ((DrillCNCSettings) this).Operation = FoamOperationType.Pattern;
    ((DrillCNCSettings) this).pathFoamPattern = Application.StartupPath;
    ((DrillCNCSettings) this).pathFoamJob = Application.StartupPath;
    ((DrillCNCSettings) this).pathConverter = Application.StartupPath;
    ((DrillCNCSettings) this).SimStep = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamRuntimeSettings data)
  {
    ((DrillFindTool) this).WaveFormPyramidShapeHeight = 30.0;
    ((DrillFindTool) this).WaveFormPyramidShapeWidth = 30.0;
    ((DrillFindTool) this).WaveFormPyramidShapeBaseHeight = 15.0;
    ((DrillFindTool) this).WaveFormPyramidShapeCount = 5.0;
    ((DrillFindTool) this).WaveFormVShapeHeight = 30.0;
    ((DrillFindTool) this).WaveFormVShapeWidth = 30.0;
    ((DrillShapeData) this).WaveFormVShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormUShapeHeight = 30.0;
    ((DrillShapeData) this).WaveFormUShapeWidth = 30.0;
    ((DrillShapeData) this).WaveFormUShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormSShapeHeight = 20.0;
    ((DrillShapeData) this).WaveFormSShapeWidth = 60.0;
    ((DrillShapeData) this).WaveFormSShapeBaseHeight = 100.0;
    ((DrillShapeData) this).WaveFormCShapeHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormCShapeWidth = 60.0;
    ((DrillMoveOptions) this).WaveFormCShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormZShapeHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormZShapeWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormZShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormRectShapeHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormRectShapeWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormRectShapeBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonHeight = 30.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonWidth = 30.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonBaseHeight = 100.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonCount = 5.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonRoundRad = 0.0;
    ((DrillMoveOptions) this).WaveFormShapeCommonChamferLen = 0.0;
    ((DrillMoveOptions) this).WaveFormRepeatCount = 0;
    ((DrillMoveOptions) this).WaveFormSpace = 0.0;
    ((DrillMoveOptions) this).SlicesHeight = 50.0;
    ((DrillMoveOptions) this).ShapeLength = 500.0;
    ((DrillMoveOptions) this).WaveFormTopHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormBottomHeight = 20.0;
    ((DrillMoveOptions) this).WaveFormZHeight = 0.0;
    ((DrillMoveOptions) this).WaveFormStartOffset = 0.0;
    ((DrillMoveOptions) this).WaveFormEndOffset = 0.0;
    ((DrillMoveOptions) this).MoveX = 0.0;
    ((DrillMoveOptions) this).BlockName = "Block";
    ((DrillMoveOptions) this).BlockWidth = 0.0;
    ((DrillCNCSettings) this).BlockHeight = 0.0;
    ((DrillCNCSettings) this).BlockIdealWidth = 0.0;
    ((DrillCNCSettings) this).BlockIdealHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).PatternOrjWidth = 0.0;
    ((DrillCNCSettings) this).PatternOrjHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidthStartOffset = 10.0;
    ((DrillCNCSettings) this).PatternWidthEndOffset = 10.0;
    ((DrillCNCSettings) this).PatternHeightStartOffset = 10.0;
    ((DrillCNCSettings) this).PatternHeightEndOffset = 10.0;
    ((DrillCNCSettings) this).PatternMirrorX = false;
    ((DrillCNCSettings) this).PatternMirrorY = false;
    ((DrillCNCSettings) this).DrawBorder = true;
    ((DrillCNCSettings) this).WaveReverse = false;
    ((DrillCNCSettings) this).WaveUpDownDirection = true;
    ((DrillCNCSettings) this).SemiAutoSelection = false;
    ((DrillCNCSettings) this).ShowVirtualDrawings = false;
    ((DrillCNCSettings) this).MaterialWidth = 2000.0;
    ((DrillCNCSettings) this).MaterialHeight = 1000.0;
    ((DrillCNCSettings) this).MaterialDepth = 500.0;
    ((DrillCNCSettings) this).planeNames = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).TypeFoam = FoamType.VForm;
    ((DrillCNCSettings) this).Operation = FoamOperationType.Pattern;
    ((DrillCNCSettings) this).pathFoamPattern = Application.StartupPath;
    ((DrillCNCSettings) this).pathFoamJob = Application.StartupPath;
    ((DrillCNCSettings) this).pathConverter = Application.StartupPath;
    ((DrillCNCSettings) this).SimStep = 1;
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

  public abstract void m001BAF();

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).BlockTrimedHeight = 0.0;
    ((DrillCNCSettings) this).BlockTrimedWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).XOffset = 0.0;
    ((DrillCNCSettings) this).YOffset = 0.0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    ((DrillCNCSettings) this).XRatio = 0.0;
    ((DrillCNCSettings) this).YRatio = 0.0;
    ((DrillCNCSettings) this).XMax = 0.0;
    ((DrillCNCSettings) this).YMax = 0.0;
    ((DrillCNCSettings) this).XCountActual = 1;
    ((DrillCNCSettings) this).YCountActual = 1;
    ((DrillCNCSettings) this).BlockIdealWidth = 0.0;
    ((DrillCNCSettings) this).BlockIdealHeight = 0.0;
    ((DrillCNCSettings) this).isVertical = false;
    ((DrillCNCSettings) this).MaterialWidth = 2000.0;
    ((DrillCNCSettings) this).MaterialHeight = 1000.0;
    ((DrillCNCSettings) this).MaterialDepth = 500.0;
    ((DrillCNCSettings) this).planeNames = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).TypeFoam = FoamType.VForm;
    ((DrillCNCSettings) this).Operation = FoamOperationType.Pattern;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamCalcVars data)
  {
    ((DrillCNCSettings) this).BlockTrimedHeight = 0.0;
    ((DrillCNCSettings) this).BlockTrimedWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).XOffset = 0.0;
    ((DrillCNCSettings) this).YOffset = 0.0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    ((DrillCNCSettings) this).XRatio = 0.0;
    ((DrillCNCSettings) this).YRatio = 0.0;
    ((DrillCNCSettings) this).XMax = 0.0;
    ((DrillCNCSettings) this).YMax = 0.0;
    ((DrillCNCSettings) this).XCountActual = 1;
    ((DrillCNCSettings) this).YCountActual = 1;
    ((DrillCNCSettings) this).BlockIdealWidth = 0.0;
    ((DrillCNCSettings) this).BlockIdealHeight = 0.0;
    ((DrillCNCSettings) this).isVertical = false;
    ((DrillCNCSettings) this).MaterialWidth = 2000.0;
    ((DrillCNCSettings) this).MaterialHeight = 1000.0;
    ((DrillCNCSettings) this).MaterialDepth = 500.0;
    ((DrillCNCSettings) this).planeNames = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).TypeFoam = FoamType.VForm;
    ((DrillCNCSettings) this).Operation = FoamOperationType.Pattern;
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

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).ShowRightVirtualDrawing = false;
    ((DrillCNCSettings) this).ShowBottomVirtualDrawing = false;
    ((DrillCNCSettings) this).ShowBottomRightVirtualDrawing = false;
    ((DrillCNCSettings) this).RigthVirtualDrawingDistance = 20.0;
    ((DrillCNCSettings) this).BottomVirtualDrawingDistance = 20.0;
    ((DrillCNCSettings) this).VirtualColor = Color.LightGreen;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamEditorSettings data)
  {
    ((DrillCNCSettings) this).ShowRightVirtualDrawing = false;
    ((DrillCNCSettings) this).ShowBottomVirtualDrawing = false;
    ((DrillCNCSettings) this).ShowBottomRightVirtualDrawing = false;
    ((DrillCNCSettings) this).RigthVirtualDrawingDistance = 20.0;
    ((DrillCNCSettings) this).BottomVirtualDrawingDistance = 20.0;
    ((DrillCNCSettings) this).VirtualColor = Color.LightGreen;
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

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).isReverse = false;
    ((DrillCNCSettings) this).NotCatchFound = false;
    ((DrillCNCSettings) this).pntLastSelected = (Point3D) null;
    ((DrillCNCSettings) this).LayerGeneral = "";
    ((DrillCNCSettings) this).LayerFoam = "";
    ((DrillCNCSettings) this).Layer3DPattern = "";
    ((DrillCNCSettings) this).LayerWirePattern = "";
    ((DrillCNCSettings) this).LayerSelection = "";
    ((DrillCNCSettings) this).LayerMark = "";
    ((DrillCNCSettings) this).LayerDefault = "Default";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buNestingCalc(FoamTempVars data)
  {
    ((DrillCNCSettings) this).isReverse = false;
    ((DrillCNCSettings) this).NotCatchFound = false;
    ((DrillCNCSettings) this).pntLastSelected = (Point3D) null;
    ((DrillCNCSettings) this).LayerGeneral = "";
    ((DrillCNCSettings) this).LayerFoam = "";
    ((DrillCNCSettings) this).Layer3DPattern = "";
    ((DrillCNCSettings) this).LayerWirePattern = "";
    ((DrillCNCSettings) this).LayerSelection = "";
    ((DrillCNCSettings) this).LayerMark = "";
    ((DrillCNCSettings) this).LayerDefault = "Default";
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

  public abstract void m001BB6();

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).StartWidthOffset = 0.0;
    ((DrillCNCSettings) this).ZPos = 0.0;
    ((DrillCNCSettings) this).Height = 0.0;
    ((DrillCNCSettings) this).BaseHeight = 0.0;
    ((DrillCNCSettings) this).WaveCount = 0;
    ((DrillCNCSettings) this).RepeatCount = 0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    ((DrillCNCSettings) this).refPlane = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).Size = new SizeObject();
    ((DrillCNCSettings) this).CuttingSpeed = 0.0;
    ((DrillCNCSettings) this).RoundRadius = 0.0;
    ((DrillCNCSettings) this).ChamferLen = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(
    double startWidthOffset,
    double zPos,
    double height,
    double width,
    double baseHeight,
    int waveCount,
    int repeatCount,
    double zOffset,
    double cuttingSpeed,
    double roundRadius,
    double chamferLen,
    FoamPlaneType refplane,
    SizeObject size)
  {
    ((DrillCNCSettings) this).StartWidthOffset = 0.0;
    ((DrillCNCSettings) this).ZPos = 0.0;
    ((DrillCNCSettings) this).Height = 0.0;
    ((DrillCNCSettings) this).BaseHeight = 0.0;
    ((DrillCNCSettings) this).WaveCount = 0;
    ((DrillCNCSettings) this).RepeatCount = 0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    ((DrillCNCSettings) this).refPlane = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).Size = new SizeObject();
    ((DrillCNCSettings) this).CuttingSpeed = 0.0;
    ((DrillCNCSettings) this).RoundRadius = 0.0;
    ((DrillCNCSettings) this).ChamferLen = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillCNCSettings) this).StartWidthOffset = startWidthOffset;
    ((DrillCNCSettings) this).ZPos = zPos;
    ((DrillCNCSettings) this).Height = height;
    ((DrillCNCSettings) this).Width = width;
    ((DrillCNCSettings) this).BaseHeight = baseHeight;
    ((DrillCNCSettings) this).WaveCount = waveCount;
    ((DrillCNCSettings) this).RepeatCount = repeatCount;
    ((DrillCNCSettings) this).CuttingSpeed = cuttingSpeed;
    ((DrillCNCSettings) this).RoundRadius = roundRadius;
    ((DrillCNCSettings) this).ChamferLen = chamferLen;
    ((DrillCNCSettings) this).refPlane = refplane;
    ((DrillCNCSettings) this).Size = new SizeObject(size);
    ((DrillCNCSettings) this).ZOffset = zOffset;
  }

  public buNestingCalc(FoamWaveShapeArgs data)
  {
    ((DrillCNCSettings) this).StartWidthOffset = 0.0;
    ((DrillCNCSettings) this).ZPos = 0.0;
    ((DrillCNCSettings) this).Height = 0.0;
    ((DrillCNCSettings) this).BaseHeight = 0.0;
    ((DrillCNCSettings) this).WaveCount = 0;
    ((DrillCNCSettings) this).RepeatCount = 0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    ((DrillCNCSettings) this).refPlane = FoamPlaneType.XZ;
    ((DrillCNCSettings) this).Size = new SizeObject();
    ((DrillCNCSettings) this).CuttingSpeed = 0.0;
    ((DrillCNCSettings) this).RoundRadius = 0.0;
    ((DrillCNCSettings) this).ChamferLen = 0.0;
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

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(double patternWidth, double patternHeight, double zOffset)
  {
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillCNCSettings) this).PatternWidth = patternWidth;
    ((DrillCNCSettings) this).PatternHeight = patternHeight;
    ((DrillCNCSettings) this).ZOffset = zOffset;
  }

  public buNestingCalc(OperationSizeCalcArgs data)
  {
    ((DrillCNCSettings) this).PatternWidth = 0.0;
    ((DrillCNCSettings) this).PatternHeight = 0.0;
    ((DrillCNCSettings) this).ZOffset = 0.0;
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

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).OutLimitMaxAngle = 0.0;
    ((DrillCNCSettings) this).OutLimitMinAngle = 0.0;
    ((DrillCNCSettings) this).MaxAngle = 0.0;
    ((DrillCNCSettings) this).MinAngle = 0.0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).UpdateRuntime = false;
    ((DrillCNCSettings) this).Finished = false;
    ((DrillCNCSettings) this).FitToLength = false;
    ((DrillCNCSettings) this).PatternSpaceWidth = 0.0;
    ((DrillCNCSettings) this).PatternSpaceHeight = 0.0;
    ((DrillCNCSettings) this).Command = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingCalc(FoamUpdateArg data)
  {
    ((DrillCNCSettings) this).UpdateRuntime = false;
    ((DrillCNCSettings) this).Finished = false;
    ((DrillCNCSettings) this).FitToLength = false;
    ((DrillCNCSettings) this).PatternSpaceWidth = 0.0;
    ((DrillCNCSettings) this).PatternSpaceHeight = 0.0;
    ((DrillCNCSettings) this).Command = "";
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

  public override string ToString() => "Finished :" + ((DrillCNCSettings) this).Finished.ToString();

  public abstract void m001BC1();

  public bool AddCodeSewingJobItem(ref SewingJobItem S, int Code)
  {
    bool flag;
    if (((DrillCNCSettings) S).Code1 == 0)
    {
      ((DrillCNCSettings) S).Code1 = Code;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code2 == 0)
    {
      ((DrillCNCSettings) S).Code2 = Code;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code3 == 0)
    {
      ((DrillCNCSettings) S).Code3 = Code;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code4 == 0)
    {
      ((DrillCNCSettings) S).Code4 = Code;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code5 == 0)
    {
      ((DrillCNCSettings) S).Code5 = Code;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public void ClearCodeSewingJobItem(ref SewingJobItem S)
  {
    ((DrillCNCSettings) S).Code0 = 0;
    ((DrillCNCSettings) S).Code1 = 0;
    ((DrillCNCSettings) S).Code2 = 0;
    ((DrillCNCSettings) S).Code3 = 0;
    ((DrillCNCSettings) S).Code4 = 0;
    ((DrillCNCSettings) S).Code5 = 0;
  }

  public void GetVertexCodes(ref SewingJobItem S, SewingVertex Vertex)
  {
    for (int index = 0; index <= ((DimensionInfo) Vertex).Codes.Count - 1; ++index)
    {
      if (index == 0)
        ((DrillCNCSettings) S).Code1 = (int) ((DimensionInfo) ((DimensionInfo) Vertex).Codes[index]).Codes;
      if (index == 1)
        ((DrillCNCSettings) S).Code2 = (int) ((DimensionInfo) ((DimensionInfo) Vertex).Codes[index]).Codes;
      if (index == 2)
        ((DrillCNCSettings) S).Code3 = (int) ((DimensionInfo) ((DimensionInfo) Vertex).Codes[index]).Codes;
      if (index == 3)
        ((DrillCNCSettings) S).Code4 = (int) ((DimensionInfo) ((DimensionInfo) Vertex).Codes[index]).Codes;
      if (index == 4)
        ((DrillCNCSettings) S).Code5 = (int) ((DimensionInfo) ((DimensionInfo) Vertex).Codes[index]).Codes;
    }
  }

  public int TreeJobImageIndex(buEntity refEntity)
  {
    int num;
    if (((CustomData) refEntity).Sewing != null)
    {
      if (((DimensionInfo) ((CustomData) refEntity).Sewing).isStitchDrawing)
      {
        switch (refEntity)
        {
          case buLine _:
            num = 1;
            goto label_7;
          case buArc _:
            num = 2;
            goto label_7;
        }
      }
      else
      {
        num = 3;
        goto label_7;
      }
    }
    num = -1;
label_7:
    return num;
  }

  public string TreeJobDefination(buEntity refEntity)
  {
    string str1 = "";
    string str2;
    if (((CustomData) refEntity).Sewing != null)
    {
      if (((DimensionInfo) ((CustomData) refEntity).Sewing).isStitchDrawing)
      {
        if (refEntity is buLine)
          str1 = $"{buLangTranslate.preDef.Stitch} {buLangTranslate.preDef.Line} - {buLangTranslate.preDef.Length} : {((MarbleInfo) ((CustomData) refEntity).Sewing).StitchLengt.ToString("f1")} , {buLangTranslate.preDef.Speed} : {((MarbleInfo) ((CustomData) refEntity).Sewing).HeadSpeed.ToString("f0")}";
        if (refEntity is buArc)
          str1 = $"{buLangTranslate.preDef.Stitch} {buLangTranslate.preDef.Arc} - {buLangTranslate.preDef.Length} : {((MarbleInfo) ((CustomData) refEntity).Sewing).StitchLengt.ToString("f1")} , {buLangTranslate.preDef.Speed} : {((MarbleInfo) ((CustomData) refEntity).Sewing).HeadSpeed.ToString("f0")}";
      }
      else
        str1 = $"{buLangTranslate.preDef.Jump} {buLangTranslate.preDef.Line} - {buLangTranslate.preDef.Length} : {((MarbleInfo) ((CustomData) refEntity).Sewing).StitchLengt.ToString("f1")} , {buLangTranslate.preDef.Speed} : {((MarbleInfo) ((CustomData) refEntity).Sewing).HeadSpeed.ToString("f0")}";
      str2 = str1;
    }
    else
      str2 = "No Defination";
    return str2;
  }

  public bool isCodeAvailable(SewingJobItem S, int Code)
  {
    return ((DrillCNCSettings) S).Code0 == Code || ((DrillCNCSettings) S).Code1 == Code || ((DrillCNCSettings) S).Code2 == Code || ((DrillCNCSettings) S).Code3 == Code || ((DrillCNCSettings) S).Code4 == Code || ((DrillCNCSettings) S).Code5 == Code;
  }

  public bool isCodeAvailable(SewingJobItem S, int Code, ref int Index)
  {
    Index = -1;
    bool flag;
    if (((DrillCNCSettings) S).Code0 == Code)
    {
      Index = 0;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code1 == Code)
    {
      Index = 1;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code2 == Code)
    {
      Index = 2;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code3 == Code)
    {
      Index = 3;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code4 == Code)
    {
      Index = 4;
      flag = true;
    }
    else if (((DrillCNCSettings) S).Code5 == Code)
    {
      Index = 5;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public int FreeAvailableCodeSequence(SewingJobItem S)
  {
    return ((DrillCNCSettings) S).Code1 != 0 ? (((DrillCNCSettings) S).Code2 != 0 ? (((DrillCNCSettings) S).Code3 != 0 ? (((DrillCNCSettings) S).Code4 != 0 ? (((DrillCNCSettings) S).Code5 != 0 ? -1 : 5) : 4) : 3) : 2) : 1;
  }

  public buNestingCalc()
  {
    if (!buVector5.\u0001("buSewingCalc"))
      throw new RegisterException("buSewingCalc");
  }

  static buNestingCalc()
  {
    DrillCNCSettings.LangSewingStatus = new List<string>();
    DrillCNCSettings.LangSewingMessage = new List<string>();
    DrillCNCSettings.LangSewingCaptions = new List<string>();
    DrillCNCSettings.LangSewingCommands = new List<string>();
    DrillCNCSettings.LangSewingMainForm = new List<string>();
    DrillCNCSettings.UnlockString = "";
  }

  public buNestingCalc()
  {
    ((DrillCNCSettings) this).MainEntityList = new List<buEntity>();
    ((DrillCNCSettings) this).SimilationPoint = (SimulationTp) new camParameters5();
    ((DrillCNCSettings) this).isSorted = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;
}
