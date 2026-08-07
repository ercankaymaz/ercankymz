// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.CreateProfileFromDataOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class CreateProfileFromDataOptions : buSerilization5
{
  public actionTypeBU Action;
  public ProfileOperationTypes OperationType;
  public CornerLocation Corner;
  public ObjectAlignment Alignment;
  public DepthPositions Depth;
  public List<DepthPositions> DepthValues;
  public bool DepthForced;
  public double ToolDiameter;
  public static List<string> Captions;
  public static byte f004510;
  public double CircleDiameter;
  public Color CircleColor;
  public double CircleThickness;
  public static byte f004514;
  public int PolygonSide;
  public double PolygonDiameter;
  public double PolygonAngle;
  public Color PolygonColor;
  public double PolygonThickness;
  public static byte f00451A;
  public double RectangleWidth;

  public void FindNotchDataValueType(buShape Shape, int indexRow, ref ShapeDataValueType DataValue)
  {
    DataValue = ShapeDataValueType.None;
    if (((buClipperBase) Shape).ShapeGroup != ShapeGroup.Shape)
      return;
    buShape buShape = Shape;
    if (!(buShape is buShapeNotch))
      return;
    buShapeNotch buShapeNotch = buShape as buShapeNotch;
    if (((CutterProgramSettings) buShapeNotch).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.Distance;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
    }
    if (((CutterProgramSettings) buShapeNotch).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.XPosition;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.ZPosition;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Distance;
    }
    if (((CutterProgramSettings) buShapeNotch).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.Distance;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
    }
    if (((CutterProgramSettings) buShapeNotch).NotchOPType != ProfileNotchOperationType.Horizontal)
      return;
    if (indexRow == 0)
      DataValue = ShapeDataValueType.XPosition;
    if (indexRow == 1)
      DataValue = ShapeDataValueType.YPosition;
    if (indexRow == 2)
      DataValue = ShapeDataValueType.Width;
    if (indexRow == 3)
      DataValue = ShapeDataValueType.Height;
    if (indexRow != 4)
      return;
    DataValue = ShapeDataValueType.Depth;
  }

  public void FindNotchDataValueType(
    ShapeRuntimeData Shape,
    int indexRow,
    ref ShapeDataValueType DataValue)
  {
    DataValue = ShapeDataValueType.None;
    if (Shape.ShapeGroup != ShapeGroup.Notch)
      return;
    if (((dynamicInfo) Shape).NotchOPType == ProfileNotchOperationType.Side)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.Distance;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
    }
    if (((dynamicInfo) Shape).NotchOPType == ProfileNotchOperationType.Length)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.XPosition;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.ZPosition;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Distance;
    }
    if (((dynamicInfo) Shape).NotchOPType == ProfileNotchOperationType.Vertical)
    {
      if (indexRow == 0)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 1)
        DataValue = ShapeDataValueType.Distance;
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
    }
    if (((dynamicInfo) Shape).NotchOPType != ProfileNotchOperationType.Horizontal)
      return;
    if (indexRow == 0)
      DataValue = ShapeDataValueType.XPosition;
    if (indexRow == 1)
      DataValue = ShapeDataValueType.YPosition;
    if (indexRow == 2)
      DataValue = ShapeDataValueType.Width;
    if (indexRow == 3)
      DataValue = ShapeDataValueType.Height;
    if (indexRow != 4)
      return;
    DataValue = ShapeDataValueType.Depth;
  }

  static CreateProfileFromDataOptions()
  {
    ProfileSettings.sClass = "buProfileCalc";
    ProfileSettings.varProfileSettings = (ProfileSettings) new MarbleEntitiesSettings();
    ProfileSettings.varProfileVisualSettings = (ProfileVisualSettings) new MarbleProgramSettings();
    ProfileSettings.varProfileRunSettings = (ProfileRuntimeSettings) new MarbleScreenCaptureSettings();
    ProfileSettings.varUCSData = (UCSObjectData) new buMatrix5();
    ProfileSettings.varTemps = (ProfileTempVars) new MarbleEntitiesSettings();
    ProfileSettings.varProfileClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ProfileSettings.UnlockString = "";
  }
}
