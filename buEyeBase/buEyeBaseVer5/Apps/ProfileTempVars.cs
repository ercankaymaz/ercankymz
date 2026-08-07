// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileTempVars : buSerilization5
{
  public int MaxNestingTimeSec;
  public nestResultSendType NestExecutionTo;
  public nestedCreateType nestedResultCreateType;
  public nestedCreateSheetType nestedResultSheetType;
  public bool CamCuttingEnable;
  public bool CamDerzEnable;
  public bool CamHoleEnable;
  public bool CamTextEnable;
  public bool CamPocketCircularEnable;
  public bool CamPocketFlatEnable;
  public bool CamCutInsideEnable;
  public bool CamCutOutsideEnable;
  public bool CamCutCenterEnable;
  public bool OldResultImportNestedResult;
  public bool OldResultImportNestingSheets;
  public bool OldResultImportNestingParts;
  public bool OldResultImportNestingClearSheets;
  public bool OldResultImportNestingClearParts;
  public nestOldResultPosition OldResultLocation;
  public bool ShowSheetAddItemNoParameter;
  public bool ShowSheetAddThicknessParameter;
  public bool ShowSheetAddSalesNoParameter;
  public bool ShowSheetAddOtherParameter;
  public bool ShowSheetAddAuxParameter;
  public bool ShowPartAddItemNoParameter;
  public bool ShowPartAddSalesNoParameter;
  public bool ShowPartAddOtherParameter;
  public bool ShowPartAddAuxParameter;
  public bool ShowItemNoNestingJobPage;
  public bool ShowPartOffsetJobPage;
  public bool AddCsvTypeToAddPartFromFile;
  public nestCsvPartImportType NestingCsvTypeOpenModeForAddPart;
  public bool NestingResultDoCam;
  public bool NestingResultDraw;
  public bool NestingResultCsv;
  public bool NestingResultSaveFile;
  public bool NestingResultPdfFile;
  public bool NestingResultDxfFile;
  public bool NestingResultHpglFile;
  public bool NestingResultIsoFile;
  public string LastNestedProject;
  public bool ShowNestResultPageAsFullScreen;
  public string NestingJobName;
  public string NestingJobExplanation;
  public string pathNesting;
  public string pathNestingPart;
  public string pathNestingSheet;
  public static List<string> Captions;
  public static byte f0043B5;
  public string layerSheet;
  public string layerPart;
  public string layerWireframe;
  public static byte f0043B9;
  public nestResultSendType SendToDraw;
  public int IndexResult;
  public int IndexSheet;
  public int IndexPart;
  public buNestedResult NestResult;
  public static byte f0043BF;
  public nestResultCreatMode Mode;
  public nestedCreateType ResultCreateType;
  public nestedCreateSheetType ResultSheetType;

  public ProfileOperationTypes ProfileActionToOperationType(actionTypeBU Action)
  {
    ProfileOperationTypes profileOperationTypes1 = ProfileOperationTypes.UnKnown;
    ProfileOperationTypes profileOperationTypes2;
    ProfileOperationTypes operationType;
    switch (Action)
    {
      case actionTypeBU.profileCircle:
        profileOperationTypes2 = ProfileOperationTypes.Circle;
        operationType = ProfileOperationTypes.Circle;
        break;
      case actionTypeBU.profileRectangle:
        profileOperationTypes2 = ProfileOperationTypes.Rectangle;
        operationType = ProfileOperationTypes.Rectangle;
        break;
      case actionTypeBU.profileRoundRectangle:
        profileOperationTypes2 = ProfileOperationTypes.RoundRectangle;
        operationType = ProfileOperationTypes.RoundRectangle;
        break;
      case actionTypeBU.profileBarrel:
        profileOperationTypes2 = ProfileOperationTypes.Barrel;
        operationType = ProfileOperationTypes.Barrel;
        break;
      case actionTypeBU.profileEllipse:
        profileOperationTypes2 = ProfileOperationTypes.Ellipse;
        operationType = ProfileOperationTypes.Ellipse;
        break;
      case actionTypeBU.profilePolygon:
        profileOperationTypes2 = ProfileOperationTypes.Polygon;
        operationType = ProfileOperationTypes.Polygon;
        break;
      case actionTypeBU.profileHole:
        profileOperationTypes2 = ProfileOperationTypes.Hole;
        operationType = ProfileOperationTypes.Hole;
        break;
      case actionTypeBU.profileNotch:
        profileOperationTypes2 = ProfileOperationTypes.Notch;
        operationType = ProfileOperationTypes.Notch;
        break;
      case actionTypeBU.profileFreeDraw:
        profileOperationTypes2 = ProfileOperationTypes.FreeDraw;
        operationType = ProfileOperationTypes.FreeDraw;
        break;
      case actionTypeBU.profileText:
        profileOperationTypes2 = ProfileOperationTypes.Text;
        operationType = ProfileOperationTypes.Text;
        break;
      case actionTypeBU.profileFromFile:
        profileOperationTypes2 = ProfileOperationTypes.FromFile;
        operationType = ProfileOperationTypes.FromFile;
        break;
      case actionTypeBU.profileSlot:
        profileOperationTypes2 = ProfileOperationTypes.Slot;
        operationType = ProfileOperationTypes.Slot;
        break;
      case actionTypeBU.profileCut:
        profileOperationTypes2 = ProfileOperationTypes.Cut;
        operationType = ProfileOperationTypes.Cut;
        break;
      case actionTypeBU.profileCustomText:
        profileOperationTypes2 = ProfileOperationTypes.CustomText;
        operationType = ProfileOperationTypes.CustomText;
        break;
      case actionTypeBU.profileWireText:
        profileOperationTypes2 = ProfileOperationTypes.WireText;
        operationType = ProfileOperationTypes.WireText;
        break;
      case actionTypeBU.profileTapping:
        profileOperationTypes2 = ProfileOperationTypes.Tapping;
        operationType = ProfileOperationTypes.Tapping;
        break;
      default:
        operationType = profileOperationTypes1;
        break;
    }
    return operationType;
  }

  public void MirrorOperation(
    ShapeMirror Mirror,
    ProfileItem Profile,
    ref ProfileOperation mirroredOP)
  {
    Point3D point3D1 = new Point3D();
    Plane planeMirror = Plane.XY;
    double num = ((ShapeRuntimeData) Mirror).MirrorDistance;
    Point3D point3D2 = Point3D.MidPoint(((ProfileRuntimeSettings) mirroredOP).MinPoint, ((ProfileRuntimeSettings) mirroredOP).MaxPoint);
    Point3D BasePoint = new Point3D(((ProfileRuntimeSettings) mirroredOP).MinPoint.X, ((ProfileRuntimeSettings) mirroredOP).MinPoint.Y, ((ProfileRuntimeSettings) mirroredOP).MinPoint.Z);
    Point3D MirrorPoint = new Point3D(((ProfileRuntimeSettings) mirroredOP).MinPoint.X, ((ProfileRuntimeSettings) mirroredOP).MinPoint.Y, ((ProfileRuntimeSettings) mirroredOP).MinPoint.Z);
    if (((ShapeRuntimeData) Mirror).MirrorLocation == MinCenterMaxType.Max)
    {
      BasePoint = new Point3D(((ProfileRuntimeSettings) mirroredOP).MaxPoint.X, ((ProfileRuntimeSettings) mirroredOP).MaxPoint.Y, ((ProfileRuntimeSettings) mirroredOP).MaxPoint.Z);
      MirrorPoint = new Point3D(((ProfileRuntimeSettings) mirroredOP).MaxPoint.X, ((ProfileRuntimeSettings) mirroredOP).MaxPoint.Y, ((ProfileRuntimeSettings) mirroredOP).MaxPoint.Z);
    }
    if (((ShapeRuntimeData) Mirror).MirrorLocation == MinCenterMaxType.Center)
    {
      BasePoint = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
      MirrorPoint = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
    }
    if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Front)
      planeMirror = Plane.XZ;
    if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Back)
      planeMirror = Plane.XZ;
    if (((ShapeRuntimeData) Mirror).MirrorMode == MirrorModeType.FromCenter)
    {
      num = 0.0;
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Top)
      {
        BasePoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, -((ProfileSettings) Profile).Width / 2.0, ((ProfileSettings) Profile).Height);
        MirrorPoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, -((ProfileSettings) Profile).Width / 2.0, ((ProfileSettings) Profile).Height);
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Front)
      {
        BasePoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, -((ProfileSettings) Profile).Width, ((ProfileSettings) Profile).Height / 2.0);
        MirrorPoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, -((ProfileSettings) Profile).Width, ((ProfileSettings) Profile).Height / 2.0);
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Back)
      {
        BasePoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, 0.0, ((ProfileSettings) Profile).Height / 2.0);
        MirrorPoint = new Point3D(((ProfileSettings) Profile).Length / 2.0, 0.0, ((ProfileSettings) Profile).Height / 2.0);
      }
    }
    if (((ShapeRuntimeData) Mirror).MirrorAxis == MirrorAxisXYType.X)
    {
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Top)
      {
        MirrorPoint.Y += 10.0;
        MirrorPoint.X += num;
        BasePoint.X += num;
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Back)
      {
        MirrorPoint.Z += 10.0;
        MirrorPoint.X += num;
        BasePoint.X += num;
      }
    }
    if (((ShapeRuntimeData) Mirror).MirrorAxis == MirrorAxisXYType.Y)
    {
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Top)
      {
        MirrorPoint.X += 10.0;
        MirrorPoint.Y += num;
        BasePoint.Y += num;
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) mirroredOP).OperationData).selectedPlaneName == planeNames.Back)
      {
        MirrorPoint.X += 10.0;
        MirrorPoint.Z += num;
        BasePoint.Z += num;
      }
    }
    if (((ProfileRuntimeSettings) mirroredOP).EntityMultiCam != null)
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) mirroredOP).EntityMultiCam.Count - 1; ++index)
        ((buAngularDim) ((ProfileRuntimeSettings) mirroredOP).EntityMultiCam[index]).Mirror(BasePoint, MirrorPoint, planeMirror);
    }
    if (((ProfileRuntimeSettings) mirroredOP).EntityMultiContour != null)
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) mirroredOP).EntityMultiContour.Count - 1; ++index)
        ((buAngularDim) ((ProfileRuntimeSettings) mirroredOP).EntityMultiContour[index]).Mirror(BasePoint, MirrorPoint, planeMirror);
    }
    if (((ProfileRuntimeSettings) mirroredOP).EntityMultiXYPlane != null)
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) mirroredOP).EntityMultiXYPlane.Count - 1; ++index)
        ((buAngularDim) ((ProfileRuntimeSettings) mirroredOP).EntityMultiXYPlane[index]).Mirror(BasePoint, MirrorPoint, planeMirror);
    }
    buCall.\u0001.Mirror(BasePoint, MirrorPoint, planeMirror, ref ((ProfileRuntimeSettings) mirroredOP).EntityMultiSolidDepth);
    Point3D mirrorPoint = new Point3D();
    buCall.\u0001.Mirror(BasePoint, MirrorPoint, planeMirror, ((ProfilePatternCopy) ((ProfileRuntimeSettings) mirroredOP).OperationData).Position, ref mirrorPoint);
    mirrorPoint = new Point3D();
    buCall.\u0001.Mirror(BasePoint, MirrorPoint, planeMirror, ((ProfileRuntimeSettings) mirroredOP).MaxPoint, ref mirrorPoint);
    ((ProfileRuntimeSettings) mirroredOP).MaxPoint = mirrorPoint;
    mirrorPoint = new Point3D();
    buCall.\u0001.Mirror(BasePoint, MirrorPoint, planeMirror, ((ProfileRuntimeSettings) mirroredOP).MinPoint, ref mirrorPoint);
    ((ProfileRuntimeSettings) mirroredOP).MinPoint = mirrorPoint;
    ((DepthPositionOptions) ((ProfileRuntimeSettings) mirroredOP).OperationData).Mirror = (ShapeMirror) new GCodePoint5(Mirror);
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) mirroredOP).OperationData).Corner != CornerLocation.LeftBottom)
      return;
    ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) mirroredOP).OperationData).Corner = CornerLocation.RightBottom;
  }

  public void FindShapeDataValueType(buShape Shape, int indexRow, ref ShapeDataValueType DataValue)
  {
    DataValue = ShapeDataValueType.None;
    if (((buClipperBase) Shape).ShapeGroup != ShapeGroup.Shape)
      return;
    buShape buShape = Shape;
    if (indexRow == 0)
    {
      if (((buClipperBase) buShape).planeName == planeBoxNames.Top | ((buClipperBase) buShape).planeName == planeBoxNames.Bottom | ((buClipperBase) buShape).planeName == planeBoxNames.Front | ((buClipperBase) buShape).planeName == planeBoxNames.Back | ((buClipperBase) buShape).planeName == planeBoxNames.Free)
        DataValue = ShapeDataValueType.XPosition;
      if (((buClipperBase) buShape).planeName == planeBoxNames.Left | ((buClipperBase) buShape).planeName == planeBoxNames.Right)
        DataValue = ShapeDataValueType.YPosition;
    }
    if (indexRow == 1)
    {
      if (((buClipperBase) buShape).planeName == planeBoxNames.Top | ((buClipperBase) buShape).planeName == planeBoxNames.Bottom | ((buClipperBase) buShape).planeName == planeBoxNames.Free)
        DataValue = ShapeDataValueType.YPosition;
      if (((buClipperBase) buShape).planeName == planeBoxNames.Front | ((buClipperBase) buShape).planeName == planeBoxNames.Back | ((buClipperBase) buShape).planeName == planeBoxNames.Left | ((buClipperBase) buShape).planeName == planeBoxNames.Right)
        DataValue = ShapeDataValueType.ZPosition;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Rectangle)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Radius;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 6)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Circle)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Ellipse)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.KeyHole)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.HeadDiameter;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 6)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Slot)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Polygon)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Hole)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.Cut)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType == ShapeTypes.FreeDraw)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Height;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (((buClipperBase) buShape).ShapeType != ShapeTypes.Text)
      return;
    if (indexRow == 2)
      DataValue = ShapeDataValueType.Width;
    if (indexRow == 3)
      DataValue = ShapeDataValueType.Height;
    if (indexRow == 6)
      DataValue = ShapeDataValueType.Depth;
    if (indexRow != 7)
      return;
    DataValue = ShapeDataValueType.ExtraDepth;
  }
}
