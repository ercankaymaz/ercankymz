// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestedSheet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedSheet : buSerilization5
{
  public double Tool66YZeroOffset;
  public double Tool67YZeroOffset;
  public double Tool68YZeroOffset;
  public double Tool69YZeroOffset;
  public double Tool70YZeroOffset;
  public double Tool71YZeroOffset;
  public double Tool72YZeroOffset;
  public double Tool73YZeroOffset;
  public double Tool74YZeroOffset;
  public double Tool75YZeroOffset;
  public double Tool76YZeroOffset;
  public double Tool77YZeroOffset;
  public double Tool78YZeroOffset;
  public double Tool79YZeroOffset;
  public double Tool80YZeroOffset;
  public double Tool85YZeroOffset;
  public double Tool161YZeroOffset;
  public double Tool162YZeroOffset;
  public double Tool163YZeroOffset;
  public double Tool164YZeroOffset;
  public double Tool165YZeroOffset;
  public double Tool166YZeroOffset;
  public double Tool167YZeroOffset;
  public double Tool168YZeroOffset;
  public double Tool169YZeroOffset;
  public double Tool170YZeroOffset;
  public double Tool171YZeroOffset;
  public double Tool172YZeroOffset;
  public double Tool173YZeroOffset;
  public double Tool174YZeroOffset;
  public double Tool175YZeroOffset;
  public double Tool176YZeroOffset;
  public double Tool177YZeroOffset;
  public double Tool178YZeroOffset;
  public double Tool179YZeroOffset;
  public double Tool185YZeroOffset;
  public double Tool261YZeroOffset;
  public double Tool262YZeroOffset;
  public double Tool263YZeroOffset;
  public double Tool264YZeroOffset;
  public double Tool265YZeroOffset;
  public double Tool266YZeroOffset;
  public double Tool267YZeroOffset;
  public double Tool268YZeroOffset;
  public double Tool269YZeroOffset;
  public double Tool270YZeroOffset;
  public double X1Velocity;
  public double X1AccDec;
  public double X2Velocity;
  public double X2AccDec;
  public double Y1Velocity;
  public double Y1AccDec;
  public double Y2Velocity;
  public double Y2AccDec;
  public double Y3Velocity;
  public double Y3AccDec;
  public double Z1Velocity;
  public double Z1AccDec;
  public double Z2Velocity;
  public double Z2AccDec;
  public double Z3Velocity;
  public double Z3AccDec;
  public double ClamperUpTime;
  public double ClamperDownTime;
  public double ToolResetTime;
  public double ToolSetTime;
  public double MachineMaxXStroke;
  public double MachineMinXStroke;
  public double MachineMillingStandartXStroke;
  public double MachineMillingStandartXMaxLimit;

  public string MoveCommandToString(DrillMoveCommand Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public string DrillMoveToolsToString(DrillMove Move)
  {
    string str = "";
    if (((ClamperInsideCalc) Move).Tool1 != 0)
      str = $"{str}T: {((ClamperInsideCalc) Move).Tool1.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool2 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool2.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool3 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool3.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool4 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool4.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool5 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool5.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool6 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool6.ToString()}";
    if (((DrillMoveCommand) Move).Tool7 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool7.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool8 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool8.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool9 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool9.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool10 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool10.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool11 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool11.ToString()} - ";
    if (((DrillMoveCommand) Move).Tool12 != 0)
      str = $"{str}T: {((DrillMoveCommand) Move).Tool12.ToString()}";
    return str;
  }

  public string JobItemCommandToString(buShape Item)
  {
    string str1 = "";
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Drill)
    {
      if (Item.GetType() == typeof (buShapeHole))
      {
        buShapeHole buShapeHole = Item as buShapeHole;
        string str2 = "";
        if (((DiemakerGrindingShapeSettings) buShapeHole).isMilling)
          str2 = " (M)";
        str1 = $"{buLangTranslate.preDef.Single} {buLangTranslate.preDef.Hole} " + str2;
      }
      else if (Item.GetType() == typeof (buShapeHoleMulti))
      {
        buShapeHoleMulti buShapeHoleMulti = Item as buShapeHoleMulti;
        string str3 = "";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).isMilling)
          str3 = " (M)";
        string str4 = "";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType == drillTypes.HorizontalHoles)
          str4 = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Multi} {buLangTranslate.preDef.Hole} ";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType == drillTypes.HorizontalLineHoles)
          str4 = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Multi} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Hole} ";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType == drillTypes.VerticalHoles)
          str4 = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Multi} {buLangTranslate.preDef.Hole} ";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType == drillTypes.VerticalLineHoles)
          str4 = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Multi} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Hole} ";
        if (((DiemakerGrindingShapeSettings) buShapeHoleMulti).DrillType == drillTypes.InclineHoles)
          str4 = $"{buLangTranslate.preDef.Inclined} {buLangTranslate.preDef.Multi} {buLangTranslate.preDef.Hole} ";
        str1 = str4 + str3;
      }
      else if (Item.GetType() == typeof (buShapeHole3))
      {
        buShapeHole3 buShapeHole3 = Item as buShapeHole3;
        string str5 = "";
        if (((DiemakerGrindingShapeSettings) buShapeHole3).isMilling)
          str5 = " (M)";
        str1 = "3 " + buLangTranslate.preDef.Hole + str5;
      }
    }
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Cut && Item.GetType() == typeof (buShapeCut))
    {
      buShapeCut buShapeCut = Item as buShapeCut;
      string str6 = "";
      if (((DiemakerGrindingShapeSettings) buShapeCut).isMilling)
        str6 = " (M)";
      string str7 = "";
      if (((DiemakerGrindingShapeSettings) buShapeCut).CutType == CutTypes.CutHorizontal)
        str7 = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Slot} ";
      if (((DiemakerGrindingShapeSettings) buShapeCut).CutType == CutTypes.CutHorizontalLine)
        str7 = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Slot} ";
      if (((DiemakerGrindingShapeSettings) buShapeCut).CutType == CutTypes.CutVertical)
        str7 = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Slot} ";
      if (((DiemakerGrindingShapeSettings) buShapeCut).CutType == CutTypes.CutVerticalLine)
        str7 = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Line} {buLangTranslate.preDef.Slot} ";
      if (((DiemakerGrindingShapeSettings) buShapeCut).CutType == CutTypes.CutFree)
        str7 = $"{buLangTranslate.preDef.Free} {buLangTranslate.preDef.Slot} ";
      str1 = str7 + str6;
    }
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Shape)
    {
      buShape buShape = Item;
      string str8 = "";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Rectangle)
        str8 = ((ClipperOffset) buShape).Radius != 0.0 ? $"{buLangTranslate.preDef.Rect} {buLangTranslate.preDef.Round} " : buLangTranslate.preDef.Rect + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Circle)
        str8 = buLangTranslate.preDef.Cirlce + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Ellipse)
        str8 = buLangTranslate.preDef.Ellipse + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.KeyHole)
        str8 = buLangTranslate.preDef.KeyHole + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Polygon)
        str8 = buLangTranslate.preDef.Polygon + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Slot)
        str8 = buLangTranslate.preDef.Slot + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Text)
        str8 = buLangTranslate.preDef.Text + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Trepezoid)
        str8 = buLangTranslate.preDef.Trapezoid + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Triangle)
        str8 = buLangTranslate.preDef.Triangle + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.FreeDraw)
        str8 = buLangTranslate.preDef.FreeDraw + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Rhombus)
        str8 = buLangTranslate.preDef.Rhombus + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Star)
        str8 = buLangTranslate.preDef.Star + " ";
      if (((buClipperBase) buShape).ShapeType == ShapeTypes.Moon)
        str8 = buLangTranslate.preDef.Moon + " ";
      str1 = str8;
    }
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Profiling)
    {
      buShapeProfiling buShapeProfiling = Item as buShapeProfiling;
      string str9 = "";
      if (((CutterIsoEntities) buShapeProfiling).ProfilingType == ProfilingTypes.ProfilingRectangle)
        str9 = $"{buLangTranslate.preDef.Rect} {buLangTranslate.preDef.Corner} ";
      if (((CutterIsoEntities) buShapeProfiling).ProfilingType == ProfilingTypes.ProfilingRound)
        str9 = $"{buLangTranslate.preDef.Round} {buLangTranslate.preDef.Corner} ";
      if (((CutterIsoEntities) buShapeProfiling).ProfilingType == ProfilingTypes.ProfilingChamfer)
        str9 = $"{buLangTranslate.preDef.Chamfer} {buLangTranslate.preDef.Corner} ";
      if (((CutterIsoEntities) buShapeProfiling).ProfilingType == ProfilingTypes.ProfilingRoundConcave)
        str9 = $"{buLangTranslate.preDef.Round} {buLangTranslate.preDef.Concave} {buLangTranslate.preDef.Corner} ";
      str1 = str9;
    }
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Junction)
    {
      buShapeJunction buShapeJunction = Item as buShapeJunction;
      string str10 = "";
      if (((CutterIsoFileItems) buShapeJunction).JunctionType == JunctionTypes.Junction2HoleNearByHorizontal)
        str10 = $"2 {buLangTranslate.preDef.Hole} {buLangTranslate.preDef.Junction} {buLangTranslate.preDef.Horizontal} ";
      if (((CutterIsoFileItems) buShapeJunction).JunctionType == JunctionTypes.Junction2HoleNearByVertical)
        str10 = $"2 {buLangTranslate.preDef.Hole} {buLangTranslate.preDef.Junction} {buLangTranslate.preDef.Vertical} ";
      if (((CutterIsoFileItems) buShapeJunction).JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal)
        str10 = $"3 {buLangTranslate.preDef.Hole} {buLangTranslate.preDef.Junction} {buLangTranslate.preDef.Horizontal} ";
      if (((CutterIsoFileItems) buShapeJunction).JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
        str10 = $"3 {buLangTranslate.preDef.Hole} {buLangTranslate.preDef.Junction} {buLangTranslate.preDef.Vertical} ";
      str1 = str10;
    }
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Engraving)
      str1 = buLangTranslate.preDef.Engraving + " ";
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Text)
      str1 = buLangTranslate.preDef.Text + " ";
    if (((buClipperBase) Item).ShapeGroup == ShapeGroup.Contour)
      str1 = buLangTranslate.preDef.Contour + " ";
    return str1;
  }

  public string PlaneBoxNamesToString(planeBoxNames plane)
  {
    string str;
    switch (plane)
    {
      case planeBoxNames.Top:
        str = buLangTranslate.preDef.Top;
        break;
      case planeBoxNames.Bottom:
        str = buLangTranslate.preDef.Bottom;
        break;
      case planeBoxNames.Left:
        str = buLangTranslate.preDef.Left;
        break;
      case planeBoxNames.Right:
        str = buLangTranslate.preDef.Right;
        break;
      case planeBoxNames.Front:
        str = buLangTranslate.preDef.Front;
        break;
      case planeBoxNames.Back:
        str = buLangTranslate.preDef.Back;
        break;
      case planeBoxNames.Free:
        str = buLangTranslate.preDef.Free;
        break;
      default:
        str = "";
        break;
    }
    return str;
  }

  public string DrillCalcItemToString(DrillCalcItem Item)
  {
    return $"{$"{$"{"" + this.PlaneBoxNamesToString(((DrillRuntimeSettings) Item).planeName)} - {buLangTranslate.preDef.Diameter} {((DrillRuntimeSettings) Item).Diameter.ToString("f1")}"} - {buLangTranslate.preDef.Depth} {((DrillRuntimeSettings) Item).Depth.ToString("f1")}"} - {buLangTranslate.preDef.Center} X: {((DrillRuntimeSettings) Item).Center.X.ToString("f1")} , Y: {((DrillRuntimeSettings) Item).Center.Y.ToString("f1")} , Z: {((DrillRuntimeSettings) Item).Center.Z.ToString("f1")}";
  }

  public void CreateClamperEntities(
    Entity ClamperEntity,
    double FirstClamperX,
    double SecondClamperX,
    ref Entity FirstClamper,
    ref Entity SecondClamper,
    Color Clr,
    int Transparency = 100)
  {
    if (ClamperEntity == null)
      return;
    FirstClamper = (Entity) null;
    SecondClamper = (Entity) null;
    buVector5.CopyEntities(ClamperEntity, ref FirstClamper);
    buVector5.CopyEntities(ClamperEntity, ref SecondClamper);
    if (FirstClamper != null)
    {
      CustomData customData = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Clamper);
      ((DiemakerGrindingShapeSettings) customData).set_RefIndex(1);
      FirstClamper.Translate(FirstClamperX, 0.0);
      FirstClamper.EntityData = (object) customData;
      FirstClamper.ColorMethod = colorMethodType.byEntity;
      FirstClamper.Color = Color.FromArgb(Transparency, Clr);
    }
    if (SecondClamper == null)
      return;
    CustomData customData1 = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData1).set_typeDefination(entityTypeDefination.Clamper);
    ((DiemakerGrindingShapeSettings) customData1).set_RefIndex(2);
    SecondClamper.Translate(SecondClamperX, 0.0);
    SecondClamper.ColorMethod = colorMethodType.byEntity;
    SecondClamper.Color = Color.FromArgb(Transparency, Clr);
    SecondClamper.EntityData = (object) customData1;
  }

  public void EnableDisableOperations(
    bool Status,
    ref DrillJob Job,
    bool Hole,
    bool Shape,
    bool Cut,
    bool Profiling,
    bool Junction,
    bool Engraving,
    bool Text,
    bool Contour,
    bool Profile)
  {
    for (int index = 0; index <= ((DrillMachineSettings) Job).Items.Count - 1; ++index)
    {
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Drill & Hole)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Shape & Shape)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Cut & Cut)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Profiling & Profiling)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Junction & Junction)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Engraving & Engraving)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Text & Text)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Contour & Contour)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
      if (((buClipperBase) ((DrillMachineSettings) Job).Items[index]).ShapeGroup == ShapeGroup.Profile & Profiling)
        ((buClipperBase) ((DrillMachineSettings) Job).Items[index]).Enable = Status;
    }
  }
}
