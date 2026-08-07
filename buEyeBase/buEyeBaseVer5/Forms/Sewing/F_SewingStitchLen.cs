// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingStitchLen
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Shape;
using devDept.Geometry;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingStitchLen : Form
{
  public Button btn_top;
  public Button btn_bottom;
  internal PictureBox \u0001;
  internal Button \u0001;
  public Button btn_camsettings;
  public Button btn_toolsettings;
  public ComboBox cmb_tools;
  internal Button \u0002;
  internal ImageList \u0003;

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_SewingPunteriz) this).\u0001.Rows.Count < 2 || ColumnIndex >= 0 & RowIndex >= 0 && !buFile5.IsNumeric(((F_SewingPunteriz) this).\u0001.Rows[RowIndex].Cells[ColumnIndex].Value.ToString()))
      return;
    if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.HorizontalLineHoles)
    {
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
    }
    else if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.VerticalLineHoles)
    {
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
    }
    else
    {
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
      {
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[1].Cells[1].Value);
      }
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
      {
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[1].Cells[1].Value);
      }
      if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
      {
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[1].Cells[1].Value);
      }
    }
    if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.SingleHole)
    {
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = drillTypes.SingleHole;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth = ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth;
    }
    else if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.HorizontalHoles | ((F_SewingPunteriz) this).parShape.DrillType == drillTypes.VerticalHoles)
    {
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count = Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[5].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = ((F_SewingPunteriz) this).parShape.DrillType;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance;
      ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleCount = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth = ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth;
    }
    else if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.HorizontalLineHoles | ((F_SewingPunteriz) this).parShape.DrillType == drillTypes.VerticalLineHoles)
    {
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[1].Cells[1].Value);
      ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[2].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).StartDistance = (double) Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).EndDistance = (double) Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[5].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = ((F_SewingPunteriz) this).parShape.DrillType;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance;
      ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleStartDistance = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).StartDistance;
      ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleEndDistance = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).EndDistance;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth = ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth;
    }
    else if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.ThreeHole)
    {
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DiameterOutside = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceX = (double) Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[5].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceY = (double) Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[6].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Hole3Angle = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[7].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = ((F_SewingPunteriz) this).parShape.DrillType;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameterOutside = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DiameterOutside;
      ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleOutsideDisX = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceX;
      ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleOutsideDisY = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceY;
      ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleAngle3Point = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Hole3Angle;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth = ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth;
    }
    else if (((F_SewingPunteriz) this).parShape.DrillType == drillTypes.InclineHoles)
    {
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count = Convert.ToInt32(((F_SewingPunteriz) this).\u0001.Rows[5].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Angle = Convert.ToDouble(((F_SewingPunteriz) this).\u0001.Rows[6].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = ((F_SewingPunteriz) this).parShape.DrillType;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance;
      ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleCount = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count;
      ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleAngle = ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Angle;
      ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth = ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth;
    }
    if (((F_SewingPunteriz) this).selectedShape is buShapeHole)
      ((DiemakerGrindingShapeSettings) (((F_SewingPunteriz) this).selectedShape as buShapeHole)).isMilling = ((F_SewingSetProperties) this).\u0001.Checked;
    ((F_SewingPunteriz) this).parShape.pntBase.X = ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.X;
    ((F_SewingPunteriz) this).parShape.pntBase.Y = ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Y;
    ((F_SewingPunteriz) this).parShape.pntBase.Z = ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_SewingPunteriz) this).\u0001.Rows.Clear();
    switch (Index)
    {
      case 2:
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Y));
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Z));
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Z));
          break;
        }
        break;
      case 4:
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.X));
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Y));
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.X));
          break;
        }
        break;
      default:
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Top | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Bottom)
        {
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.X));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Y));
        }
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Left | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Right)
        {
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Y", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Y));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Z));
        }
        if (((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Front | ((F_SewingPunteriz) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("X", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.X));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("Z", (F_DrillList) this, ((F_SewingPunteriz) this).parShape.pntBase.Z));
          break;
        }
        break;
    }
    if (Index == 0)
    {
      ((F_SewingPunteriz) this).selectedShape = (buShape) new buLinearPathArrow(((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth);
      ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.SingleHole;
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = drillTypes.SingleHole;
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).isMilling = ((F_SewingPunteriz) this).parShape.isMillingHole;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint = new Point3D(((F_SewingPunteriz) this).parShape.pntBase.X, ((F_SewingPunteriz) this).parShape.pntBase.Y, ((F_SewingPunteriz) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Diameter, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, (F_DrillList) this, ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth));
    }
    else if (Index == 1 | Index == 3)
    {
      drillTypes type = drillTypes.HorizontalHoles;
      if (Index == 1)
      {
        ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.HorizontalHoles;
        type = drillTypes.HorizontalHoles;
      }
      if (Index == 3)
      {
        ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.VerticalHoles;
        type = drillTypes.VerticalHoles;
      }
      ((F_SewingPunteriz) this).selectedShape = (buShape) new buLinearPathArrow(type, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleCount, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleStartDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleEndDistance, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth, 0.0);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = type;
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).isMilling = ((F_SewingPunteriz) this).parShape.isMillingHole;
      ((F_SewingPunteriz) this).parShape.DrillType = type;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint = new Point3D(((F_SewingPunteriz) this).parShape.pntBase.X, ((F_SewingPunteriz) this).parShape.pntBase.Y, ((F_SewingPunteriz) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Diameter, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, (F_DrillList) this, ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Distance, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Count, (F_DrillList) this, (double) ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count));
    }
    else if (Index == 2 | Index == 4)
    {
      drillTypes type = drillTypes.HorizontalLineHoles;
      if (Index == 2)
      {
        ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.HorizontalLineHoles;
        type = drillTypes.HorizontalLineHoles;
      }
      if (Index == 4)
      {
        ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.VerticalLineHoles;
        type = drillTypes.VerticalLineHoles;
      }
      ((F_SewingPunteriz) this).selectedShape = (buShape) new buLinearPathArrow(type, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleCount, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleStartDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleEndDistance, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth, 0.0);
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = type;
      ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).isMilling = ((F_SewingPunteriz) this).parShape.isMillingHole;
      ((F_SewingPunteriz) this).parShape.DrillType = type;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint = new Point3D(((F_SewingPunteriz) this).parShape.pntBase.X, ((F_SewingPunteriz) this).parShape.pntBase.Y, ((F_SewingPunteriz) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Diameter, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, (F_DrillList) this, ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Distance, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001($"{buLangTranslate.preDef.Start} {buLangTranslate.preDef.Distance}", (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).StartDistance));
      ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001($"{buLangTranslate.preDef.End} {buLangTranslate.preDef.Distance}", (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).EndDistance));
    }
    else
    {
      switch (Index)
      {
        case 5:
          ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.InclineHoles;
          ((F_SewingPunteriz) this).selectedShape = (buShape) new buLinearPathArrow(drillTypes.InclineHoles, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleCount, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleStartDistance, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleEndDistance, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth, ((SelectionAlingmentPoints) ((F_SewingPunteriz) this).parShape).HoleAngle);
          ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = drillTypes.InclineHoles;
          ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).isMilling = ((F_SewingPunteriz) this).parShape.isMillingHole;
          ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.InclineHoles;
          ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint = new Point3D(((F_SewingPunteriz) this).parShape.pntBase.X, ((F_SewingPunteriz) this).parShape.pntBase.Y, ((F_SewingPunteriz) this).parShape.pntBase.Z);
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
          ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Diameter, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, (F_DrillList) this, ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Distance, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Distance));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Count, (F_DrillList) this, (double) ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Count));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Angle, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Angle));
          break;
        case 6:
          ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.ThreeHole;
          ((F_SewingPunteriz) this).selectedShape = (buShape) new buSelectionPoint(((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameter, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDepth, ((SelectionEntity) ((F_SewingPunteriz) this).parShape).HoleDiameterOutside, ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleOutsideDisX, ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleOutsideDisY, ((MeasureItem) ((F_SewingPunteriz) this).parShape).HoleAngle3Point);
          ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DrillType = drillTypes.ThreeHole;
          ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).isMilling = ((F_SewingPunteriz) this).parShape.isMillingHole;
          ((F_SewingPunteriz) this).parShape.DrillType = drillTypes.ThreeHole;
          ((buClipper) ((F_SewingPunteriz) this).selectedShape).BasePoint = new Point3D(((F_SewingPunteriz) this).parShape.pntBase.X, ((F_SewingPunteriz) this).parShape.pntBase.Y, ((F_SewingPunteriz) this).parShape.pntBase.Z);
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
          ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
          ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Diameter, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Diameter));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Depth, (F_DrillList) this, ((\u0012.\u0002) ((F_SewingPunteriz) this).selectedShape).Depth));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001($"{buLangTranslate.preDef.Diameter} {buLangTranslate.preDef.Outside}", (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DiameterOutside));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001($"{buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Distance} X", (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceX));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001($"{buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Distance} Y", (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).DistanceY));
          ((F_SewingPunteriz) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(buLangTranslate.preDef.Angle, (F_DrillList) this, ((DiemakerGrindingShapeSettings) ((F_SewingPunteriz) this).selectedShape).Hole3Angle));
          break;
      }
    }
    ((F_SewingSetProperties) this).\u0001.Checked = ((F_SewingPunteriz) this).parShape.isMillingHole;
    ((buClipper) ((F_SewingPunteriz) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((F_SewingPunteriz) this).CamPar);
    ((F_SewingSetProperties) this).\u0001.Text = ((buNestedSheet) buCall.\u0001).JobItemCommandToString(((F_SewingPunteriz) this).selectedShape);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_SewingExtend) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_SewingMove) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_SewingPunteriz) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_SewingExtend) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_SewingPunteriz) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_SewingMove) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_SewingPunteriz) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_SewingPunteriz) this).btn_ok.Name)
    {
      ((F_SewingExtend) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_SewingPunteriz) this).ClosePageAfterOk)
      {
        if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_SewingMove) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_SewingPunteriz) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
      }
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_SewingPunteriz) this).btn_cancel.Name)
    {
      ((F_SewingExtend) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SewingExtend) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
      // ISSUE: reference to a compiler-generated field
      if (((F_SewingMove) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_SewingMove) this).\u0001();
      }
    }
    if (control.Name == this.\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_SewingPunteriz) this).parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        this.\u0001.ImageIndex = Convert.ToInt32((object) ((F_SewingPunteriz) this).parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_SewingMove) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_SewingPunteriz) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == this.\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((F_SewingPunteriz) this).parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_SewingPunteriz) this).parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        this.\u0002.ImageIndex = Convert.ToInt32((object) ((F_SewingPunteriz) this).parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_SewingMove) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_SewingPunteriz) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_SewingSetProperties) this).\u0003.Name && ((F_SewingPunteriz) this).selectedShape is buShapeHole)
    {
      buShapeHole selectedShape = ((F_SewingPunteriz) this).selectedShape as buShapeHole;
      if (!((DiemakerGrindingShapeSettings) selectedShape).isMilling)
        ((DiemakerGrindingShapeSettings) selectedShape).isMilling = true;
      else
        ((DiemakerGrindingShapeSettings) selectedShape).isMilling = false;
      ((F_SewingSetProperties) this).\u0001.Checked = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      ((F_SewingPunteriz) this).parShape.isMillingHole = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      this.ShapeToDataGrid(((F_SewingPunteriz) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_SewingMove) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_SewingPunteriz) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2);
      }
    }
    if (control.Name == this.btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(((F_SewingPunteriz) this).CamPar);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) ((F_SewingPunteriz) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        ((F_SewingPunteriz) this).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (!(control.Name == this.btn_top.Name | control.Name == this.btn_bottom.Name | control.Name == ((F_SewingPunteriz) this).btn_left.Name | control.Name == ((F_SewingPunteriz) this).btn_right.Name | control.Name == ((F_SewingPunteriz) this).btn_front.Name | control.Name == ((F_SewingPunteriz) this).btn_back.Name))
      return;
    if (control.Name == this.btn_top.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Top;
    if (control.Name == this.btn_bottom.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Bottom;
    if (control.Name == ((F_SewingPunteriz) this).btn_left.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Left;
    if (control.Name == ((F_SewingPunteriz) this).btn_right.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Right;
    if (control.Name == ((F_SewingPunteriz) this).btn_front.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Front;
    if (control.Name == ((F_SewingPunteriz) this).btn_back.Name)
      ((F_SewingPunteriz) this).parShape.selectedPlane = planeBoxNames.Back;
    ((F_SewingPunteriz) this).PlaneColorUpdate();
    int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
    if (valueGridIndex >= 0 & valueGridIndex <= ((F_SewingPunteriz) this).\u0001.Rows.Count - 1)
    {
      ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
      ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName);
      this.ShapeToDataGrid(((F_SewingPunteriz) this).\u0001);
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
      for (int index = 0; index <= ((F_SewingPunteriz) this).\u0001.Rows.Count - 1; ++index)
      {
        ((F_SewingPunteriz) this).\u0001.Rows[index].Cells[0].Selected = false;
        ((F_SewingPunteriz) this).\u0001.Rows[index].Cells[1].Selected = false;
      }
      ((F_SewingPunteriz) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_SewingMove) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_SewingPunteriz) this).parShape);
    ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).planeName = ((F_SewingPunteriz) this).parShape.selectedPlane;
    ((buClipper) ((F_SewingPunteriz) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((F_SewingPunteriz) this).parShape.selectedPlane);
    ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Corner = ((F_SewingPunteriz) this).parShape.selectedCorner;
    ((buClipperBase) ((F_SewingPunteriz) this).selectedShape).Alignment = ((F_SewingPunteriz) this).parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_SewingMove) this).\u0001((object) ((F_SewingPunteriz) this).selectedShape, (object) Data2_1);
  }
}
