// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Flexo;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileSettings : buSerilization5
{
  public int SelectedResult;
  public int SelectedSheet;
  public bool DoCam;
  public bool PdfFile;
  public bool CsvFile;
  public string FullFileName;
  public string JustFileName;
  public string JustFolderName;
  public int ImageWidth;
  public int ImageHeight;
  public Image ImageResult;
  public List<Image> ImageSheets;
  public buNestedResult nestedResult;
  public buNestedSheet nestedSheet;
  public buNestingResultSettings ResultSettings;
  public static byte f0043D2;
  [SpecialName]
  public int value__;
  public const nestingPartMainDrawAddModes Color = ; // Unable to render the field
  public const nestingPartMainDrawAddModes Layer = ; // Unable to render the field
  public const nestingPartMainDrawAddModes Selection = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const nestedCreateType Draw = ; // Unable to render the field
  public const nestedCreateType SaveFile = ; // Unable to render the field
  public const nestedCreateType Dxf = ; // Unable to render the field
  public const nestedCreateType Hpgl = ; // Unable to render the field
  public const nestedCreateType Iso = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const nestedCreateSheetType Selected = ; // Unable to render the field
  public const nestedCreateSheetType All = ; // Unable to render the field
  public static string sClass;
  public static ProfileSettings varProfileSettings;
  public static ProfileVisualSettings varProfileVisualSettings;
  public static ProfileRuntimeSettings varProfileRunSettings;
  public static UCSObjectData varUCSData;
  public static ProfileTempVars varTemps;
  public static ProfileClamperSettings varProfileClamperSettings;
  public static string UnlockString;
  public static byte f0043E8;
  public static readonly buProfileCalc.\u003C\u003Ec \u003C\u003E9;
  public static Comparison<MinMax> \u003C\u003E9__95_0;
  public static Comparison<ProfileOperation> \u003C\u003E9__96_0;
  public static Comparison<GProfileOperation> \u003C\u003E9__97_0;
  public static Comparison<GProfileOperation> \u003C\u003E9__98_0;
  public static Comparison<GProfileOperation> \u003C\u003E9__99_0;
  public static Comparison<ProfileOperationSortItem> \u003C\u003E9__100_0;
  public string Name;
  public List<ProfileOperation> Operation;
  public static byte f0043F2;
  public string Name;
  public List<ProfileItem> Items;
  public int Station;
  public static byte f0043F6;
  public string Name;
  public bool isSimulationDone;
  public ProfileItem FirstItem;
  public ProfileItem SecondItem;
  public ProfileItem ThirdItem;
  public ProfileItem FourthItem;
  public ArrayList GCodes;
  public static byte f0043FE;
  public string ItemName;
  public string FileName;
  public string FileNameFull;
  public bool IsClamperDone;
  public bool isSimulationDone;
  public bool isCollisionControlDone;
  public bool isError;
  public bool isSupportBlockOffsetAdd;
  public bool isStandartProfile;
  public bool isCollisionOnlineAvailable;
  public bool isCollisionOfflineAvailable;
  public bool isGCodeCreated;
  public bool isGCodeSimMoveCreated;
  public bool CreatedFromDrawing;
  public bool Enable;
  public bool Selected;
  public bool ClamperChanged;
  public int YDirection;
  public int StandartProfileIndex;
  public double Length;
  public double Width;
  public double Height;
  public double TotalWidth;
  public double Thickness;
  public double LeftAngle;
  public double RightAngle;
  public double MaxOperationXPosition;
  public int MaxClamperNumber;
  public string TextureName;
  public System.Drawing.Color colorProfile;
  public System.Drawing.Color colorSupportBlock;
  public Point3D TotalOffset;
  public Point3D ProfileMinPoint;
  public Point3D ProfileMaxPoint;
  public Point3D ProfileCenterPoint;
  public Point3D ProfileOffset;
  public LeftRightType XReferanceLocation;
  public ProfileNewType ProfileType;
  public System.Drawing.Color Color;
  public int Transparency;
  public Vector3D Direction;
  public ProfileSupportBlock SupportBlock;
  public ProfileMultiply MultiplyProfile;
  public MaterialSkin Skin;
  public List<SelectedPlaneInfo> selectedFreePlanes;
  public List<ProfileOperation> Operations;
  public List<ProfileItemCalc> CalculationData;
  public List<buShape> Items;
  public List<ProfileDrawings> Drawings;
  public ProfileClamperSettings ClamperSettings;
  public Entity LeftAngleEntity;
  public Entity RightAngleEntity;
  public Entity ProfileReferanceEntity;
  public Entity ProfileReferanceBottomEntity;
  public Entity ProfileReferanceBackEntity;
  public List<Entity> SupportBlockEntities;
  public List<Entity> auxEntities;
  public List<string> ProfileTraformations;
  public List<string> GCodeList;
  public List<string> warningAllList;
  public List<string> errorAllList;
  public List<string> infoAllList;
  public static byte f00443D;
  public bool IsClamperDone;
  public bool isSimulationDone;
  public bool isError;
  public bool OriginalIsLongProfile;
  public double Width;
  public double Height;
  public double Length;
  public double MaxOperationXPosition;
  public double LongProfileFirstPartLength;
  public int MaxClamperNumber;
  public Point3D TotalOffset;
  public Point3D ProfileMinPoint;
  public Point3D ProfileMaxPoint;
  public Point3D ProfileCenterPoint;
  public LeftRightType XReferanceLocation;
  public ProfileExcType CalcType;
  public List<GProfileOperation> calcOperations;
  public ProfileClamperSettings ClamperSettings;
  public List<Pnt6DSimMove> SimMoves;
  public List<string> ProfileTraformations;
  public List<camTp> Cams;
  public List<string> GCodesItem;
  public List<List<ProfileClamper>> ClamperLists;
  public static byte f004455;
  public List<GProfileOperation> OpList;
  public BoxSize5 Size;

  public void FindShapeDataValueType(
    ShapeRuntimeData Shape,
    int indexRow,
    ref ShapeDataValueType DataValue)
  {
    DataValue = ShapeDataValueType.None;
    if (Shape.ShapeGroup != ShapeGroup.Shape)
      return;
    if (indexRow == 0)
    {
      if (Shape.selectedPlane == planeBoxNames.Top | Shape.selectedPlane == planeBoxNames.Bottom | Shape.selectedPlane == planeBoxNames.Front | Shape.selectedPlane == planeBoxNames.Back | Shape.selectedPlane == planeBoxNames.Free)
        DataValue = ShapeDataValueType.XPosition;
      if (Shape.selectedPlane == planeBoxNames.Left | Shape.selectedPlane == planeBoxNames.Right)
        DataValue = ShapeDataValueType.YPosition;
    }
    if (indexRow == 1)
    {
      if (Shape.selectedPlane == planeBoxNames.Top | Shape.selectedPlane == planeBoxNames.Bottom | Shape.selectedPlane == planeBoxNames.Free)
        DataValue = ShapeDataValueType.YPosition;
      if (Shape.selectedPlane == planeBoxNames.Front | Shape.selectedPlane == planeBoxNames.Back | Shape.selectedPlane == planeBoxNames.Left | Shape.selectedPlane == planeBoxNames.Right)
        DataValue = ShapeDataValueType.ZPosition;
    }
    if (Shape.ShapeType == ShapeTypes.Rectangle)
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
    if (Shape.ShapeType == ShapeTypes.Circle)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (Shape.ShapeType == ShapeTypes.Ellipse)
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
    if (Shape.ShapeType == ShapeTypes.KeyHole)
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
    if (Shape.ShapeType == ShapeTypes.Slot)
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
    if (Shape.ShapeType == ShapeTypes.Polygon)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 5)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (Shape.ShapeType == ShapeTypes.Hole)
    {
      if (indexRow == 2)
        DataValue = ShapeDataValueType.Width;
      if (indexRow == 3)
        DataValue = ShapeDataValueType.Depth;
      if (indexRow == 4)
        DataValue = ShapeDataValueType.ExtraDepth;
    }
    if (Shape.ShapeType == ShapeTypes.Cut)
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
    if (Shape.ShapeType == ShapeTypes.FreeDraw)
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
    if (Shape.ShapeType != ShapeTypes.Text)
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

  public void buShapeToProfileData(
    buShape Shape,
    ShapeRuntimeData shapeRuntimeData,
    ref ProfileOperationData OPData,
    ref actionTypeBU Action)
  {
    Action = actionTypeBU.None;
    if (Shape.GetType() == typeof (buShapeRectangle))
    {
      buShapeRectangle buShapeRectangle = Shape as buShapeRectangle;
      Action = actionTypeBU.profileRectangle;
      ((CreateProfileFromDataOptions) ((DepthPositions) OPData).RectangleData).RectangleWidth = ((ClipperOffset) buShapeRectangle).Width;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleHeight = ((ClipperOffset) buShapeRectangle).Height;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleAngle = ((ClipperOffset) buShapeRectangle).Angle;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleRadius = ((ClipperOffset) buShapeRectangle).Radius;
      ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleChamfer = ((ClipperOffset) buShapeRectangle).Chamfer;
      if (((buClipperBase) buShapeRectangle).Edit != null)
        ((OperationUpdateArg) ((DepthPositions) OPData).RectangleData).RectangleAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeRectangle).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeCircle))
    {
      buShapeCircle buShapeCircle = Shape as buShapeCircle;
      Action = actionTypeBU.profileCircle;
      ((CreateProfileFromDataOptions) ((OperationInsideClampers) OPData).CircleData).CircleDiameter = ((ClipperOffset) buShapeCircle).Radius * 2.0;
    }
    if (Shape.GetType() == typeof (buShapeHole))
    {
      buShapeHole buShapeHole = Shape as buShapeHole;
      Action = actionTypeBU.profileHole;
      ((NestingPanel) ((DepthPositions) OPData).HoleData).HoleDiameter = ((DiemakerGrindingShapeSettings) buShapeHole).Diameter;
      if (((DiemakerGrindingShapeSettings) buShapeHole).isTapping)
        Action = actionTypeBU.profileTapping;
    }
    if (Shape.GetType() == typeof (buShapeEllipse))
    {
      buShapeEllipse buShapeEllipse = Shape as buShapeEllipse;
      Action = actionTypeBU.profileEllipse;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseWidth = ((ClipperOffset) buShapeEllipse).RadiusX * 2.0;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseHeight = ((ClipperOffset) buShapeEllipse).RadiusY * 2.0;
      ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseAngle = ((ClipperOffset) buShapeEllipse).Angle;
      if (((buClipperBase) buShapeEllipse).Edit != null)
        ((NestingPanelJob) ((DepthPositions) OPData).EllipseData).EllipseAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeEllipse).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeKeyHole))
    {
      buShapeKeyHole buShapeKeyHole = Shape as buShapeKeyHole;
      Action = actionTypeBU.profileBarrel;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelDiameter = ((DiemakerGrindingShapeSettings) buShapeKeyHole).HeadDiameter;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelLength = ((DiemakerGrindingShapeSettings) buShapeKeyHole).Length;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelWidth = ((DiemakerGrindingShapeSettings) buShapeKeyHole).Diameter;
      ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelAngle = ((DiemakerGrindingShapeSettings) buShapeKeyHole).Angle * 2.0;
      if (((buClipperBase) buShapeKeyHole).Edit != null)
        ((PanelCutMove) ((DepthPositions) OPData).BarelData).BarrelAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeKeyHole).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapePolygon))
    {
      buShapePolygon buShapePolygon = Shape as buShapePolygon;
      Action = actionTypeBU.profilePolygon;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonDiameter = ((ClipperOffset) buShapePolygon).Radius * 2.0;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonSide = ((buFlexoCalc) buShapePolygon).Side;
      ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonAngle = ((buDiamakerCalc) buShapePolygon).Angle;
      if (((buClipperBase) buShapePolygon).Edit != null)
        ((CreateProfileFromDataOptions) ((DepthPositionOptions) OPData).PolygonData).PolygonAngle = ((ShapeRuntimeData) ((buClipperBase) buShapePolygon).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeCut))
    {
      buShapeCut buShapeCut = Shape as buShapeCut;
      Action = actionTypeBU.profileCut;
      ((PanelDonePart) ((DepthPositions) OPData).CutData).CutWidth = ((DiemakerGrindingShapeSettings) buShapeCut).Diameter;
      ((PanelDonePart) ((DepthPositions) OPData).CutData).CutHeigth = ((DiemakerGrindingShapeSettings) buShapeCut).Length;
      if (((buClipperBase) buShapeCut).Edit != null)
        ((PanelWaitAssembly) ((DepthPositions) OPData).CutData).CutAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeCut).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeSlot))
    {
      buShapeSlot buShapeSlot = Shape as buShapeSlot;
      Action = actionTypeBU.profileSlot;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotDiameter = ((DiemakerGrindingShapeSettings) buShapeSlot).Diameter;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotWidth = ((DiemakerGrindingShapeSettings) buShapeSlot).Length;
      ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotAngle = ((DiemakerGrindingShapeSettings) buShapeSlot).Angle;
      if (((buClipperBase) buShapeSlot).Edit != null)
        ((PanelEntityData) ((DepthPositions) OPData).SlotData).SlotAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeSlot).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeFreeDraw))
    {
      buShapeFreeDraw buShapeFreeDraw = Shape as buShapeFreeDraw;
      Action = actionTypeBU.profileFreeDraw;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawWidth = ((DiemakerGrindingShapeSettings) buShapeFreeDraw).Width;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawHeight = ((DiemakerGrindingShapeSettings) buShapeFreeDraw).Height;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawAngle = ((DiemakerGrindingShapeSettings) buShapeFreeDraw).Angle;
      if (((buClipperBase) buShapeFreeDraw).Edit != null)
        ((NestingPanelNode) ((DepthPositionOptions) OPData).FreeDrawData).FreeDrawAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeFreeDraw).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeText))
    {
      buShapeText buShapeText = Shape as buShapeText;
      Action = actionTypeBU.profileText;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextWidth = ((CutterRuntimeSettings) buShapeText).Width;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextHeight = ((CutterProgramSettings) buShapeText).Height;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextString = ((CutterProgramSettings) buShapeText).TextString;
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextFont = new Font(((CutterProgramSettings) buShapeText).TextFont.Name, ((CutterProgramSettings) buShapeText).TextFont.Size, ((CutterProgramSettings) buShapeText).TextFont.Style);
      ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).isWire = ((CutterProgramSettings) buShapeText).isWire;
      if (((CutterProgramSettings) buShapeText).isWire)
        Action = actionTypeBU.profileWireText;
      if (((buClipperBase) buShapeText).Edit != null)
        ((NestingPanelNode) ((DepthPositionOptions) OPData).TextData).TextAngle = ((ShapeRuntimeData) ((buClipperBase) buShapeText).Edit).RotateDegree;
    }
    if (Shape.GetType() == typeof (buShapeNotch))
    {
      buShapeNotch buShapeNotch = Shape as buShapeNotch;
      Action = actionTypeBU.profileNotch;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchWidth = ((CutterProgramSettings) buShapeNotch).NotchWidth;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchHeight = ((CutterProgramSettings) buShapeNotch).NotchHeight;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchStart = ((CutterProgramSettings) buShapeNotch).NotchStartHeight;
      ((NestingPanelJob) ((DepthPositions) OPData).NotchData).NotchDepth = ((\u0012.\u0002) buShapeNotch).Depth;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchUpDown = ((CutterProgramSettings) buShapeNotch).NotchUpDown;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchFrontBack = ((CutterProgramSettings) buShapeNotch).NotchFrontBack;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchLocation = ((CutterProgramSettings) buShapeNotch).NotchLocation;
      ((NestingPanel) ((DepthPositions) OPData).NotchData).NotchOPType = ((CutterProgramSettings) buShapeNotch).NotchOPType;
    }
    ((ProfileArray) OPData).ExternalDepth = ((\u0012.\u0002) Shape).Depth;
    ((ProfileOnlineOpOptions) OPData).basePosition.X = ((buClipper) Shape).BasePoint.X;
    ((ProfileOnlineOpOptions) OPData).basePosition.Y = ((buClipper) Shape).BasePoint.Y;
    ((ProfileOnlineOpOptions) OPData).basePosition.Z = ((buClipper) Shape).BasePoint.Z;
    ((ProfileMirror) OPData).selectedPlaneName = (planeNames) Convert.ToInt32((object) ((buClipperBase) Shape).planeName);
    if (((buClipper) Shape).planeOperation != (Plane) null && ((buClipper) Shape).planeOperation != ((ProfilePatternCopy) OPData).selectedPlane)
      ((ProfilePatternCopy) OPData).selectedPlane = (Plane) ((buClipper) Shape).planeOperation.Clone();
    if (((buClipperBase) Shape).Edit != null)
    {
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerEnable;
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).CircularEnable;
      ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorEnable = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorEnable;
      if (((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerXCount = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerXCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerXDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerXDistance;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerYCount = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerYCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).LineerYDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).LineerYDistance;
      }
      if (((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).CircularEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularCount = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).CircularCount;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Array).CircularAngle = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).ArrayData).CircularAngle;
      }
      if (((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorEnable)
      {
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorEnable = true;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorDistance = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorDistance;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorLocation = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorLocation;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorMode = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorMode;
        ((ShapeRuntimeData) ((DepthPositionOptions) OPData).Mirror).MirrorAxis = ((ShapeRuntimeData) ((ShapeRuntimeData) ((buClipperBase) Shape).Edit).MirrorData).MirrorAxis;
      }
    }
    ((ProfileMirror) OPData).EachLayer = ((ShapeTempData) shapeRuntimeData).EachLayer;
    ((ProfileMirror) OPData).ManuelZEnable = ((ShapeTempData) shapeRuntimeData).ManuelDepthEnable;
    ((ProfileArray) OPData).ManuelZVal = ((CurveToSurfaceSettingsType) shapeRuntimeData).ManuelDepthStart;
    ((ProfileArray) OPData).IncrementalDistance = ((CurveToSurfaceSettingsType) shapeRuntimeData).IncrementalDistance;
    ((ProfileArray) OPData).ExtraDepth = ((CurveToSurfaceSettingsType) shapeRuntimeData).ExtraDepth;
    ((CreateProfileFromDataOptions) OPData).Alignment = ((buClipperBase) Shape).Alignment;
    ((CreateProfileFromDataOptions) OPData).Corner = ((buClipperBase) Shape).Corner;
    if (Shape.GetType() == typeof (buShapeNotch))
    {
      ((ProfileArray) OPData).CamParNotch = (camParameters5) new camRuntime5(((buClipper) Shape).CamPar);
    }
    else
    {
      ((ProfileArray) OPData).CamParMilling = (camParameters5) new camRuntime5(((buClipper) Shape).CamPar);
      ((ProfileArray) OPData).CamParMilling.Operations.AreaClearanceEnable = ((buClipperBase) Shape).isPocket;
    }
    ((CreateProfileFromDataOptions) OPData).Action = Action;
  }
}
