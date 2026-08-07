// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.RollerBend.F_RollerRectangle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Flexo;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Sewing;
using buEyeBaseVer5.Forms.Shape;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.RollerBend;

public class F_RollerRectangle : Form
{
  public bool EnableTopPlane;
  public bool EnableBottomPlane;
  public bool EnableLeftPlane;
  public bool EnableRightPlane;
  public bool EnableFrontPlane;
  public bool EnableBacktPlane;
  public bool ClosePageAfterOk;
  public List<ToolBase5> Tools;
  public ToolBase5 activeTool;
  public buShape selectedShape;
  public ShapeRuntimeData parShape;
  private Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Panel pnl_model;
  internal ImageList \u0001;

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_RollerMenu) this).\u0001.Rows.Count < 2 || ColumnIndex >= 0 & RowIndex >= 0 && !buFile5.IsNumeric(((F_RollerMenu) this).\u0001.Rows[RowIndex].Cells[ColumnIndex].Value.ToString()))
      return;
    if (this.parShape.selectedPlane == planeBoxNames.Top | this.parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((buClipper) this.selectedShape).BasePoint.X = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) this.selectedShape).BasePoint.Y = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (this.parShape.selectedPlane == planeBoxNames.Front | this.parShape.selectedPlane == planeBoxNames.Back)
    {
      ((buClipper) this.selectedShape).BasePoint.X = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) this.selectedShape).BasePoint.Z = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (this.parShape.selectedPlane == planeBoxNames.Left | this.parShape.selectedPlane == planeBoxNames.Right)
    {
      ((buClipper) this.selectedShape).BasePoint.Y = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[0].Cells[1].Value);
      ((buClipper) this.selectedShape).BasePoint.Z = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[1].Cells[1].Value);
    }
    if (this.selectedShape.GetType() == typeof (buShapeRectangle))
    {
      ((ClipperOffset) this.selectedShape).Width = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value);
      ((ClipperOffset) this.selectedShape).Height = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((ClipperOffset) this.selectedShape).Radius = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) this.parShape).RectangleWidth = ((ClipperOffset) this.selectedShape).Width;
      ((CurveToSurfaceSettingsType) this.parShape).RectangleHeight = ((ClipperOffset) this.selectedShape).Height;
      ((SelectedPlaneInfo) this.parShape).RectangleDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectedPlaneInfo) this.parShape).RectangleAngle = ((ClipperOffset) this.selectedShape).Angle;
      ((SelectedPlaneInfo) this.parShape).RectangleRadius = ((ClipperOffset) this.selectedShape).Radius;
      this.parShape.ShapeType = ShapeTypes.Rectangle;
    }
    if (this.selectedShape.GetType() == typeof (buShapeCircle))
    {
      ((ClipperOffset) this.selectedShape).Radius = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value) / 2.0;
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((buClipperBase) this.selectedShape).ShapeType = ShapeTypes.Circle;
      ((SelectedPlaneInfo) this.parShape).CircleRadius = ((ClipperOffset) this.selectedShape).Radius;
      ((SelectedPlaneInfo) this.parShape).CircleDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      this.parShape.ShapeType = ShapeTypes.Circle;
    }
    if (this.selectedShape.GetType() == typeof (buShapeEllipse))
    {
      ((ClipperOffset) this.selectedShape).RadiusX = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value) / 2.0;
      ((ClipperOffset) this.selectedShape).RadiusY = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value) / 2.0;
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      ((SelectedPlaneInfo) this.parShape).EllipseRadiusX = ((ClipperOffset) this.selectedShape).RadiusX;
      ((SelectedPlaneInfo) this.parShape).EllipseRadiusY = ((ClipperOffset) this.selectedShape).RadiusY;
      ((SelectedPlaneInfo) this.parShape).EllipseDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectedPlaneInfo) this.parShape).EllipseAngle = ((ClipperOffset) this.selectedShape).Angle;
      this.parShape.ShapeType = ShapeTypes.Ellipse;
    }
    if (this.selectedShape.GetType() == typeof (buShapeKeyHole))
    {
      ((DiemakerGrindingShapeSettings) this.selectedShape).HeadDiameter = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) this.selectedShape).Diameter = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) this.selectedShape).Length = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[5].Cells[1].Value);
      ((SelectionEntityTypes) this.parShape).KeyHoleHeadDiameter = ((DiemakerGrindingShapeSettings) this.selectedShape).HeadDiameter;
      ((SelectionEntityTypes) this.parShape).KeyHoleDiameter = ((DiemakerGrindingShapeSettings) this.selectedShape).Diameter;
      ((SelectionEntityTypes) this.parShape).KeyHoleLength = ((DiemakerGrindingShapeSettings) this.selectedShape).Length;
      ((SelectionOperation) this.parShape).KeyHoleDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectionOperation) this.parShape).KeyHoleAngle = ((DiemakerGrindingShapeSettings) this.selectedShape).Angle;
      this.parShape.ShapeType = ShapeTypes.KeyHole;
    }
    if (this.selectedShape.GetType() == typeof (buShapePolygon))
    {
      ((ClipperOffset) this.selectedShape).Radius = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value) / 2.0;
      ((buFlexoCalc) this.selectedShape).Side = Convert.ToInt32(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      ((SelectedPlaneInfo) this.parShape).PolygonRadius = ((ClipperOffset) this.selectedShape).Radius;
      ((SelectedPlaneInfo) this.parShape).PolygonSide = ((buFlexoCalc) this.selectedShape).Side;
      ((SelectedPlaneInfo) this.parShape).PolygonDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectedPlaneInfo) this.parShape).PolygonAngle = ((buDiamakerCalc) this.selectedShape).Angle;
      this.parShape.ShapeType = ShapeTypes.Polygon;
    }
    if (this.selectedShape.GetType() == typeof (buShapeSlot))
    {
      ((DiemakerGrindingShapeSettings) this.selectedShape).Diameter = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) this.selectedShape).Length = (double) Convert.ToInt32(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      ((SelectionEntityTypes) this.parShape).SlotDiameter = ((DiemakerGrindingShapeSettings) this.selectedShape).Diameter;
      ((SelectedPlaneInfo) this.parShape).SlotLength = ((DiemakerGrindingShapeSettings) this.selectedShape).Length;
      ((SelectionEntityTypes) this.parShape).SlotDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectionEntityTypes) this.parShape).SlotAngle = ((DiemakerGrindingShapeSettings) this.selectedShape).Angle;
      this.parShape.ShapeType = ShapeTypes.Slot;
    }
    if (this.selectedShape.GetType() == typeof (buShapeFreeDraw))
    {
      ((DiemakerGrindingShapeSettings) this.selectedShape).Width = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[2].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) this.selectedShape).Height = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[3].Cells[1].Value);
      ((\u0012.\u0002) this.selectedShape).Depth = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[4].Cells[1].Value);
      if (((F_RollerMenu) this).\u0001.Rows.Count >= 6 & ((buClipperBase) this.selectedShape).DepthLevel.Count >= 2)
        ((buClipperBase) this.selectedShape).DepthLevel[1] = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[5].Cells[1].Value);
      if (((F_RollerMenu) this).\u0001.Rows.Count >= 6 & ((dynamicInfo) this.parShape).DepthLevels.Count >= 2)
        ((dynamicInfo) this.parShape).DepthLevels[1] = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[5].Cells[1].Value);
      if (((F_RollerMenu) this).\u0001.Rows.Count >= 7 & ((buClipperBase) this.selectedShape).DepthLevel.Count >= 3)
        ((buClipperBase) this.selectedShape).DepthLevel[2] = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[6].Cells[1].Value);
      if (((F_RollerMenu) this).\u0001.Rows.Count >= 7 & ((dynamicInfo) this.parShape).DepthLevels.Count >= 3)
        ((dynamicInfo) this.parShape).DepthLevels[2] = Convert.ToDouble(((F_RollerMenu) this).\u0001.Rows[6].Cells[1].Value);
      ((SelectionOperation) this.parShape).FreeDrawWidth = ((DiemakerGrindingShapeSettings) this.selectedShape).Width;
      ((SelectionOperation) this.parShape).FreeDrawHeight = ((DiemakerGrindingShapeSettings) this.selectedShape).Height;
      ((SelectionOperation) this.parShape).FreeDrawDepth = ((\u0012.\u0002) this.selectedShape).Depth;
      ((SelectionEntity) this.parShape).FreeDrawAngle = ((DiemakerGrindingShapeSettings) this.selectedShape).Angle;
      this.parShape.ShapeType = ShapeTypes.FreeDraw;
    }
    this.parShape.isShapePocket = ((F_RollerCircle) this).\u0001.Checked;
    ((buClipperBase) this.selectedShape).isPocket = this.parShape.isShapePocket;
    this.parShape.pntBase.X = ((buClipper) this.selectedShape).BasePoint.X;
    this.parShape.pntBase.Y = ((buClipper) this.selectedShape).BasePoint.Y;
    this.parShape.pntBase.Z = ((buClipper) this.selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_RollerMenu) this).\u0001.Rows.Clear();
    if (this.parShape.selectedPlane == planeBoxNames.Top | this.parShape.selectedPlane == planeBoxNames.Bottom)
    {
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.X, (F_ShapeList) this, "X"));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.Y, (F_ShapeList) this, "Y"));
    }
    if (this.parShape.selectedPlane == planeBoxNames.Left | this.parShape.selectedPlane == planeBoxNames.Right)
    {
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.Y, (F_ShapeList) this, "Y"));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.Z, (F_ShapeList) this, "Z"));
    }
    if (this.parShape.selectedPlane == planeBoxNames.Front | this.parShape.selectedPlane == planeBoxNames.Back)
    {
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.X, (F_ShapeList) this, "X"));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(this.parShape.pntBase.Z, (F_ShapeList) this, "Z"));
    }
    if (Index == 0)
    {
      if (((SelectedPlaneInfo) this.parShape).RectangleDepth <= 0.0)
        ((SelectedPlaneInfo) this.parShape).RectangleDepth = 5.0;
      this.selectedShape = (buShape) new buUpperLineEnt(((CurveToSurfaceSettingsType) this.parShape).RectangleWidth, ((CurveToSurfaceSettingsType) this.parShape).RectangleHeight, ((SelectedPlaneInfo) this.parShape).RectangleRadius, 0.0, ((SelectedPlaneInfo) this.parShape).RectangleDepth, ((SelectedPlaneInfo) this.parShape).RectangleAngle);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).Width, (F_ShapeList) this, AppLanguage.CadCamDynamic[15]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).Height, (F_ShapeList) this, AppLanguage.CadCamDynamic[16 /*0x10*/]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).Radius, (F_ShapeList) this, AppLanguage.CadCamDynamic[19]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 1)
    {
      if (((SelectedPlaneInfo) this.parShape).CircleDepth <= 0.0)
        ((SelectedPlaneInfo) this.parShape).CircleDepth = 5.0;
      this.selectedShape = (buShape) new buUpperLineEnt(((SelectedPlaneInfo) this.parShape).CircleRadius, ((SelectedPlaneInfo) this.parShape).CircleDepth);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).Radius * 2.0, (F_ShapeList) this, AppLanguage.CadCamDynamic[57]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 2)
    {
      if (((SelectedPlaneInfo) this.parShape).EllipseDepth <= 0.0)
        ((SelectedPlaneInfo) this.parShape).EllipseDepth = 5.0;
      this.selectedShape = (buShape) new buUpperLineEnt(((SelectedPlaneInfo) this.parShape).EllipseRadiusX, ((SelectedPlaneInfo) this.parShape).EllipseRadiusY, ((SelectedPlaneInfo) this.parShape).EllipseDepth, ((SelectedPlaneInfo) this.parShape).EllipseAngle);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).RadiusX * 2.0, (F_ShapeList) this, AppLanguage.CadCamDynamic[20]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).RadiusY * 2.0, (F_ShapeList) this, AppLanguage.CadCamDynamic[21]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 3)
    {
      if (((SelectionOperation) this.parShape).KeyHoleDepth <= 0.0)
        ((SelectionOperation) this.parShape).KeyHoleDepth = 5.0;
      this.selectedShape = (buShape) new buLinearPathArrow(((SelectionEntityTypes) this.parShape).KeyHoleHeadDiameter, ((SelectionEntityTypes) this.parShape).KeyHoleDiameter, ((SelectionEntityTypes) this.parShape).KeyHoleLength, ((SelectionOperation) this.parShape).KeyHoleDepth, ((SelectionOperation) this.parShape).KeyHoleAngle);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).HeadDiameter, (F_ShapeList) this, AppLanguage.CadCamDynamic[128 /*0x80*/]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Diameter, (F_ShapeList) this, AppLanguage.CadCamDynamic[57]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Length, (F_ShapeList) this, AppLanguage.CadCamDynamic[0]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 4)
    {
      if (((SelectedPlaneInfo) this.parShape).PolygonDepth <= 0.0)
        ((SelectedPlaneInfo) this.parShape).PolygonDepth = 5.0;
      this.selectedShape = (buShape) new buUpperLineEnt(((SelectedPlaneInfo) this.parShape).PolygonRadius, ((SelectedPlaneInfo) this.parShape).PolygonSide, ((SelectedPlaneInfo) this.parShape).PolygonDepth, ((SelectedPlaneInfo) this.parShape).PolygonAngle);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((ClipperOffset) this.selectedShape).Radius * 2.0, (F_ShapeList) this, AppLanguage.CadCamDynamic[57]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((double) ((buFlexoCalc) this.selectedShape).Side, (F_ShapeList) this, AppLanguage.CadCamDynamic[71]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 5)
    {
      if (((SelectionEntityTypes) this.parShape).SlotDepth <= 0.0)
        ((SelectionEntityTypes) this.parShape).SlotDepth = 5.0;
      this.selectedShape = (buShape) new buUpperLineEnt(((SelectionEntityTypes) this.parShape).SlotDiameter, ((SelectedPlaneInfo) this.parShape).SlotLength, ((SelectionEntityTypes) this.parShape).SlotDepth, ((SelectionEntityTypes) this.parShape).SlotAngle);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Diameter, (F_ShapeList) this, AppLanguage.CadCamDynamic[57]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Length, (F_ShapeList) this, AppLanguage.CadCamDynamic[0]));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, AppLanguage.CadCamDynamic[113]));
    }
    if (Index == 6)
    {
      if (((SelectionOperation) this.parShape).FreeDrawDepth <= 0.0)
        ((SelectionOperation) this.parShape).FreeDrawDepth = 5.0;
      this.selectedShape = (buShape) new buLinearPathArrow(((SelectionOperation) this.parShape).FreeDrawWidth, ((SelectionOperation) this.parShape).FreeDrawHeight, ((SelectionOperation) this.parShape).FreeDrawDepth, ((SelectionEntity) this.parShape).FreeDrawAngle);
      ((buClipperBase) this.selectedShape).DepthLevel = new List<double>();
      ((buClipperBase) this.selectedShape).DepthLevel.AddRange((IEnumerable<double>) ((dynamicInfo) this.parShape).DepthLevels);
      ((buClipper) this.selectedShape).BasePoint = new Point3D(this.parShape.pntBase.X, this.parShape.pntBase.Y, this.parShape.pntBase.Z);
      ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
      ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
      ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
      ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Width, (F_ShapeList) this, buLangTranslate.preDef.Width));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((DiemakerGrindingShapeSettings) this.selectedShape).Height, (F_ShapeList) this, buLangTranslate.preDef.Height));
      ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((\u0012.\u0002) this.selectedShape).Depth, (F_ShapeList) this, buLangTranslate.preDef.Depth));
      if (((buClipperBase) this.selectedShape).DepthLevel.Count >= 2)
        ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((buClipperBase) this.selectedShape).DepthLevel[1], (F_ShapeList) this, buLangTranslate.preDef.DepthSecond));
      if (((buClipperBase) this.selectedShape).DepthLevel.Count >= 3)
        ((F_RollerMenu) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((buClipperBase) this.selectedShape).DepthLevel[2], (F_ShapeList) this, buLangTranslate.preDef.DepthThird));
    }
    ((buClipperBase) this.selectedShape).isPocket = this.parShape.isShapePocket;
    ((buClipper) this.selectedShape).CamPar = (camParameters5) new camRuntime5(this.parShape.CamPars);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_RollerTable) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_RollerTable) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(this.parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_RollerTable) this).PropertiesForm.Inited || obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
      ;
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_RollerTable) this).PropertiesForm.Inited || obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
      ;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      ((F_RollerTable) this).PropertiesForm.Result = DialogResult.OK;
      if (this.ClosePageAfterOk)
      {
        if (((F_RollerTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_RollerTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      ((F_RollerTable) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_RollerTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RollerTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      {
        this.Visible = false;
        if (this.Owner != null)
          this.Owner.Focus();
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001();
      }
    }
    if (control2.Name == ((F_RollerCircle) this).\u0004.Name && this.selectedShape != null)
    {
      buShape selectedShape = this.selectedShape;
      if (!((buClipperBase) selectedShape).isPocket)
        ((buClipperBase) selectedShape).isPocket = true;
      else
        ((buClipperBase) selectedShape).isPocket = false;
      ((F_RollerCircle) this).\u0001.Checked = ((buClipperBase) selectedShape).isPocket;
      this.parShape.isShapePocket = ((buClipperBase) selectedShape).isPocket;
      this.ShapeToDataGrid(this.\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(this.parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == ((F_RollerCircle) this).\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = this.parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) this.selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        this.parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_RollerCircle) this).\u0001.ImageIndex = Convert.ToInt32((object) this.parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_RollerTable) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_RollerCircle) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = this.parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) this.selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        this.parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_RollerCircle) this).\u0002.ImageIndex = Convert.ToInt32((object) this.parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_RollerTable) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_RollerCircle) this).\u0003.Name)
    {
      F_ShapeEdit fShapeEdit = (F_ShapeEdit) new F_SewingMove();
      ((F_SewingFootHeight) fShapeEdit).Edit = (ShapeEdit) new ColorType(((buClipperBase) this.selectedShape).Edit);
      ((F_SewingSpeed) fShapeEdit).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_SewingFootHeight) fShapeEdit).refPlane = ((buClipperBase) this.selectedShape).planeName;
      ((F_SewingMove) fShapeEdit).Init();
      int num = (int) fShapeEdit.ShowDialog((IWin32Window) this);
      if (((F_SewingSpeed) fShapeEdit).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) this.selectedShape).Edit = (ShapeEdit) new ColorType(((F_SewingFootHeight) fShapeEdit).Edit);
        // ISSUE: reference to a compiler-generated field
        if (((F_RollerTable) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_RollerCircle) this).btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(this.parShape.CamPars);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) this.selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        this.parShape.CamPars = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (control2.Name == ((F_RollerMenu) this).btn_top.Name)
    {
      this.parShape.selectedPlane = planeBoxNames.Top;
      ((F_RollerTable) this).PlaneColorUpdate();
      int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
      if (valueGridIndex >= 0 & valueGridIndex <= ((F_RollerMenu) this).\u0001.Rows.Count - 1)
      {
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) this.selectedShape).planeName);
        this.ShapeToDataGrid(this.\u0001);
        ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
        for (int index = 0; index <= ((F_RollerMenu) this).\u0001.Rows.Count - 1; ++index)
        {
          ((F_RollerMenu) this).\u0001.Rows[index].Cells[0].Selected = false;
          ((F_RollerMenu) this).\u0001.Rows[index].Cells[1].Selected = false;
        }
        ((F_RollerMenu) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
        ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
        ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == ((F_RollerCircle) this).btn_bottom.Name)
    {
      this.parShape.selectedPlane = planeBoxNames.Bottom;
      ((F_RollerTable) this).PlaneColorUpdate();
      this.ShapeToDataGrid(this.\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
        ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
        ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == ((F_RollerMenu) this).btn_left.Name)
    {
      this.parShape.selectedPlane = planeBoxNames.Left;
      ((F_RollerTable) this).PlaneColorUpdate();
      this.ShapeToDataGrid(this.\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
        ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
        ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == ((F_RollerMenu) this).btn_right.Name)
    {
      this.parShape.selectedPlane = planeBoxNames.Right;
      ((F_RollerTable) this).PlaneColorUpdate();
      this.ShapeToDataGrid(this.\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
        ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
        ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (control2.Name == ((F_RollerMenu) this).btn_front.Name)
    {
      this.parShape.selectedPlane = planeBoxNames.Front;
      ((F_RollerTable) this).PlaneColorUpdate();
      this.ShapeToDataGrid(this.\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_RollerTable) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
        ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
        ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
        ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
        ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
        // ISSUE: reference to a compiler-generated field
        ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2);
      }
    }
    if (!(control2.Name == ((F_RollerMenu) this).btn_back.Name))
      return;
    this.parShape.selectedPlane = planeBoxNames.Back;
    ((F_RollerTable) this).PlaneColorUpdate();
    this.ShapeToDataGrid(this.\u0001);
    // ISSUE: reference to a compiler-generated field
    if (((F_RollerTable) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(this.parShape);
    ((buClipperBase) this.selectedShape).planeName = this.parShape.selectedPlane;
    ((buClipper) this.selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(this.parShape.selectedPlane);
    ((buClipperBase) this.selectedShape).Corner = this.parShape.selectedCorner;
    ((buClipperBase) this.selectedShape).Alignment = this.parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_RollerTable) this).\u0001((object) this.selectedShape, (object) Data2_1);
  }
}
