// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingRotate
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
using dummy_ptr;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingRotate : Form
{
  internal NumericUpDown \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0004;
  internal CheckBox \u0002;
  internal Panel \u0003;
  internal Label \u0005;
  internal NumericUpDown \u0005;
  public Button btn_rotate;
  internal Panel \u0004;
  internal Label \u0006;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Cut;
      ((F_ShapeList) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_ShapeList) this).\u0005.Text = buLangTranslate.preDef.Back;
      ((F_ShapeList) this).\u0007.Text = buLangTranslate.preDef.Bottom;
      ((F_ShapeList) this).\u0001.Text = buLangTranslate.preDef.Command;
      ((F_ShapeList) this).\u0006.Text = buLangTranslate.preDef.Front;
      ((F_ShapeList) this).\u0004.Text = buLangTranslate.preDef.Left;
      ((F_ShapeList) this).\u0002.Text = buLangTranslate.preDef.Right;
      ((F_ShapeList) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_DrillList) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_DrillList) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void PlaneColorUpdate()
  {
    ((F_ShapeList) this).btn_back.BackColor = Color.Gainsboro;
    ((F_ShapeList) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_ShapeList) this).btn_front.BackColor = Color.Gainsboro;
    ((F_ShapeList) this).btn_left.BackColor = Color.Gainsboro;
    ((F_ShapeList) this).btn_right.BackColor = Color.Gainsboro;
    ((F_ShapeList) this).btn_top.BackColor = Color.Gainsboro;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_ShapeList) this).btn_top.BackColor = Color.PaleGreen;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_ShapeList) this).btn_bottom.BackColor = Color.PaleGreen;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_ShapeList) this).btn_front.BackColor = Color.PaleGreen;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_ShapeList) this).btn_back.BackColor = Color.PaleGreen;
    if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_ShapeList) this).btn_left.BackColor = Color.PaleGreen;
    if (((F_DrillList) this).parShape.selectedPlane != planeBoxNames.Right)
      return;
    ((F_ShapeList) this).btn_right.BackColor = Color.PaleGreen;
  }

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_ShapeList) this).\u0001.Rows.Count < 2 || ColumnIndex >= 0 & RowIndex >= 0 && !buFile5.IsNumeric(((F_ShapeList) this).\u0001.Rows[RowIndex].Cells[ColumnIndex].Value.ToString()))
      return;
    if (((F_DrillList) this).parShape.CutType == CutTypes.CutHorizontalLine)
    {
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutVerticalLine)
    {
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
    }
    else
    {
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
      {
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[1].Cells[1].Value);
      }
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
      {
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.X = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[1].Cells[1].Value);
      }
      if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
      {
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Y = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[0].Cells[1].Value);
        ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Z = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[1].Cells[1].Value);
      }
    }
    if (((F_DrillList) this).parShape.CutType == CutTypes.CutHorizontal | ((F_DrillList) this).parShape.CutType == CutTypes.CutVertical)
    {
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = ((F_DrillList) this).parShape.CutType;
      ((MeasureData) ((F_DrillList) this).parShape).CutDiameter = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter;
      ((MeasureData) ((F_DrillList) this).parShape).CutLength = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length;
      ((MeasureData) ((F_DrillList) this).parShape).CutDepth = ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutHorizontalLine | ((F_DrillList) this).parShape.CutType == CutTypes.CutVerticalLine)
    {
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[1].Cells[1].Value);
      ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[2].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).StartDistance = (double) Convert.ToInt32(((F_ShapeList) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).EndDistance = (double) Convert.ToInt32(((F_ShapeList) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = ((F_DrillList) this).parShape.CutType;
      ((MeasureData) ((F_DrillList) this).parShape).CutDiameter = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter;
      ((MeasureData) ((F_DrillList) this).parShape).CutLength = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length;
      ((MeasureData) ((F_DrillList) this).parShape).CutStartDistance = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).StartDistance;
      ((MeasureData) ((F_DrillList) this).parShape).CutEndDistance = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).EndDistance;
      ((MeasureData) ((F_DrillList) this).parShape).CutDepth = ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth;
    }
    else if (((F_DrillList) this).parShape.CutType == CutTypes.CutFree)
    {
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[2].Cells[1].Value);
      ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[3].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[4].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Angle = Convert.ToDouble(((F_ShapeList) this).\u0001.Rows[5].Cells[1].Value);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = ((F_DrillList) this).parShape.CutType;
      ((MeasureData) ((F_DrillList) this).parShape).CutDiameter = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter;
      ((MeasureData) ((F_DrillList) this).parShape).CutLength = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length;
      ((CustomDataAdd) ((F_DrillList) this).parShape).CutAngle = ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Angle;
      ((MeasureData) ((F_DrillList) this).parShape).CutDepth = ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth;
    }
    if (((F_DrillList) this).selectedShape is buShapeCut)
      ((DiemakerGrindingShapeSettings) (((F_DrillList) this).selectedShape as buShapeCut)).isMilling = ((F_ShapeList) this).\u0001.Checked;
    ((F_DrillList) this).parShape.pntBase.X = ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.X;
    ((F_DrillList) this).parShape.pntBase.Y = ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Y;
    ((F_DrillList) this).parShape.pntBase.Z = ((buClipper) ((F_DrillList) this).selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_ShapeList) this).\u0001.Rows.Clear();
    switch (Index)
    {
      case 1:
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Y", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Y));
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Z", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Z));
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Z", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Z));
          break;
        }
        break;
      case 3:
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("X", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.X));
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Y", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Y));
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("X", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.X));
          break;
        }
        break;
      default:
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Top | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Bottom)
        {
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("X", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.X));
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Y", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Y));
        }
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Left | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Right)
        {
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Y", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Y));
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Z", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Z));
        }
        if (((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Front | ((F_DrillList) this).parShape.selectedPlane == planeBoxNames.Back)
        {
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("X", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.X));
          ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001("Z", (F_CutList) this, ((F_DrillList) this).parShape.pntBase.Z));
          break;
        }
        break;
    }
    if (Index == 0 | Index == 2)
    {
      CutTypes slotType = CutTypes.CutHorizontal;
      if (Index == 0)
      {
        ((F_DrillList) this).parShape.CutType = CutTypes.CutHorizontal;
        slotType = CutTypes.CutHorizontal;
      }
      if (Index == 2)
      {
        ((F_DrillList) this).parShape.CutType = CutTypes.CutVertical;
        slotType = CutTypes.CutVertical;
      }
      ((F_DrillList) this).selectedShape = (buShape) new buSelectionPoint(slotType, ((MeasureData) ((F_DrillList) this).parShape).CutDiameter, ((MeasureData) ((F_DrillList) this).parShape).CutDepth, ((MeasureData) ((F_DrillList) this).parShape).CutLength, ((MeasureData) ((F_DrillList) this).parShape).CutStartDistance, ((MeasureData) ((F_DrillList) this).parShape).CutEndDistance, ((CustomDataAdd) ((F_DrillList) this).parShape).CutAngle);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = slotType;
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).isMilling = ((F_DrillList) this).parShape.isMillingCut;
      ((F_DrillList) this).parShape.CutType = slotType;
      ((buClipper) ((F_DrillList) this).selectedShape).BasePoint = new Point3D(((F_DrillList) this).parShape.pntBase.X, ((F_DrillList) this).parShape.pntBase.Y, ((F_DrillList) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_DrillList) this).selectedShape).planeName = ((F_DrillList) this).parShape.selectedPlane;
      ((buClipper) ((F_DrillList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_DrillList) this).selectedShape).planeName);
      ((buClipperBase) ((F_DrillList) this).selectedShape).Corner = ((F_DrillList) this).parShape.selectedCorner;
      ((buClipperBase) ((F_DrillList) this).selectedShape).Alignment = ((F_DrillList) this).parShape.objectAlignment;
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Diameter, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Depth, (F_CutList) this, ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Length, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length));
    }
    else if (Index == 1 | Index == 3)
    {
      CutTypes slotType = CutTypes.CutHorizontalLine;
      if (Index == 1)
      {
        ((F_DrillList) this).parShape.CutType = CutTypes.CutHorizontalLine;
        slotType = CutTypes.CutHorizontalLine;
      }
      if (Index == 3)
      {
        ((F_DrillList) this).parShape.CutType = CutTypes.CutVerticalLine;
        slotType = CutTypes.CutVerticalLine;
      }
      ((F_DrillList) this).selectedShape = (buShape) new buSelectionPoint(slotType, ((MeasureData) ((F_DrillList) this).parShape).CutDiameter, ((MeasureData) ((F_DrillList) this).parShape).CutDepth, ((MeasureData) ((F_DrillList) this).parShape).CutLength, ((MeasureData) ((F_DrillList) this).parShape).CutStartDistance, ((MeasureData) ((F_DrillList) this).parShape).CutEndDistance, ((CustomDataAdd) ((F_DrillList) this).parShape).CutAngle);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = slotType;
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).isMilling = ((F_DrillList) this).parShape.isMillingCut;
      ((F_DrillList) this).parShape.CutType = slotType;
      ((buClipper) ((F_DrillList) this).selectedShape).BasePoint = new Point3D(((F_DrillList) this).parShape.pntBase.X, ((F_DrillList) this).parShape.pntBase.Y, ((F_DrillList) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_DrillList) this).selectedShape).planeName = ((F_DrillList) this).parShape.selectedPlane;
      ((buClipper) ((F_DrillList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_DrillList) this).selectedShape).planeName);
      ((buClipperBase) ((F_DrillList) this).selectedShape).Corner = ((F_DrillList) this).parShape.selectedCorner;
      ((buClipperBase) ((F_DrillList) this).selectedShape).Alignment = ((F_DrillList) this).parShape.objectAlignment;
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Diameter, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Depth, (F_CutList) this, ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001($"{buLangTranslate.preDef.Start} {buLangTranslate.preDef.Distance}", (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).StartDistance));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001($"{buLangTranslate.preDef.End} {buLangTranslate.preDef.Distance}", (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).EndDistance));
    }
    else if (Index == 4)
    {
      ((F_DrillList) this).parShape.CutType = CutTypes.CutFree;
      ((F_DrillList) this).selectedShape = (buShape) new buSelectionPoint(CutTypes.CutFree, ((MeasureData) ((F_DrillList) this).parShape).CutDiameter, ((MeasureData) ((F_DrillList) this).parShape).CutDepth, ((MeasureData) ((F_DrillList) this).parShape).CutLength, ((MeasureData) ((F_DrillList) this).parShape).CutStartDistance, ((MeasureData) ((F_DrillList) this).parShape).CutEndDistance, ((CustomDataAdd) ((F_DrillList) this).parShape).CutAngle);
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).CutType = CutTypes.CutFree;
      ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).isMilling = ((F_DrillList) this).parShape.isMillingCut;
      ((F_DrillList) this).parShape.CutType = CutTypes.CutFree;
      ((buClipper) ((F_DrillList) this).selectedShape).BasePoint = new Point3D(((F_DrillList) this).parShape.pntBase.X, ((F_DrillList) this).parShape.pntBase.Y, ((F_DrillList) this).parShape.pntBase.Z);
      ((buClipperBase) ((F_DrillList) this).selectedShape).planeName = ((F_DrillList) this).parShape.selectedPlane;
      ((buClipper) ((F_DrillList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_DrillList) this).selectedShape).planeName);
      ((buClipperBase) ((F_DrillList) this).selectedShape).Corner = ((F_DrillList) this).parShape.selectedCorner;
      ((buClipperBase) ((F_DrillList) this).selectedShape).Alignment = ((F_DrillList) this).parShape.objectAlignment;
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Diameter, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Diameter));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Depth, (F_CutList) this, ((\u0012.\u0002) ((F_DrillList) this).selectedShape).Depth));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Length, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Length));
      ((F_ShapeList) this).\u0001.Rows.Add(\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buLangTranslate.preDef.Angle, (F_CutList) this, ((DiemakerGrindingShapeSettings) ((F_DrillList) this).selectedShape).Angle));
    }
    ((F_ShapeList) this).\u0001.Checked = ((F_DrillList) this).parShape.isMillingCut;
    ((buClipper) ((F_DrillList) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((F_DrillList) this).CamPar);
    ((F_ShapeList) this).\u0001.Text = ((buNestedSheet) buCall.\u0001).JobItemCommandToString(((F_DrillList) this).selectedShape);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_DrillList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_DrillList) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_DrillList) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_DrillList) this).btn_ok.Name)
    {
      ((F_DrillList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_DrillList) this).ClosePageAfterOk)
      {
        if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_DrillList) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_DrillList) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
      }
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_DrillList) this).btn_cancel.Name)
    {
      ((F_DrillList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DrillList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
      // ISSUE: reference to a compiler-generated field
      if (((F_DrillList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_DrillList) this).\u0001();
      }
    }
    if (control.Name == ((F_ShapeList) this).\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((F_DrillList) this).parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_DrillList) this).selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_DrillList) this).parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_ShapeList) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_DrillList) this).parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_DrillList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_DrillList) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeList) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((F_DrillList) this).parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_DrillList) this).selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_DrillList) this).parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_ShapeList) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_DrillList) this).parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_DrillList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_DrillList) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeList) this).\u0003.Name && ((F_DrillList) this).selectedShape is buShapeCut)
    {
      buShapeCut selectedShape = ((F_DrillList) this).selectedShape as buShapeCut;
      if (!((DiemakerGrindingShapeSettings) selectedShape).isMilling)
        ((DiemakerGrindingShapeSettings) selectedShape).isMilling = true;
      else
        ((DiemakerGrindingShapeSettings) selectedShape).isMilling = false;
      ((F_ShapeList) this).\u0001.Checked = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      ((F_DrillList) this).parShape.isMillingCut = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      this.ShapeToDataGrid(((F_DrillList) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_DrillList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_DrillList) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
      }
    }
    if (control.Name == ((F_ShapeList) this).btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(((F_DrillList) this).CamPar);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) ((F_DrillList) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        ((F_DrillList) this).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (!(control.Name == ((F_ShapeList) this).btn_top.Name | control.Name == ((F_ShapeList) this).btn_bottom.Name | control.Name == ((F_ShapeList) this).btn_left.Name | control.Name == ((F_ShapeList) this).btn_right.Name | control.Name == ((F_ShapeList) this).btn_front.Name | control.Name == ((F_ShapeList) this).btn_back.Name))
      return;
    if (control.Name == ((F_ShapeList) this).btn_top.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Top;
    if (control.Name == ((F_ShapeList) this).btn_bottom.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Bottom;
    if (control.Name == ((F_ShapeList) this).btn_left.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Left;
    if (control.Name == ((F_ShapeList) this).btn_right.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Right;
    if (control.Name == ((F_ShapeList) this).btn_front.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Front;
    if (control.Name == ((F_ShapeList) this).btn_back.Name)
      ((F_DrillList) this).parShape.selectedPlane = planeBoxNames.Back;
    this.PlaneColorUpdate();
    int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
    if (valueGridIndex >= 0 & valueGridIndex <= ((F_ShapeList) this).\u0001.Rows.Count - 1)
    {
      ((buClipperBase) ((F_DrillList) this).selectedShape).planeName = ((F_DrillList) this).parShape.selectedPlane;
      ((buClipper) ((F_DrillList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_DrillList) this).selectedShape).planeName);
      this.ShapeToDataGrid(((F_DrillList) this).\u0001);
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
      for (int index = 0; index <= ((F_ShapeList) this).\u0001.Rows.Count - 1; ++index)
      {
        ((F_ShapeList) this).\u0001.Rows[index].Cells[0].Selected = false;
        ((F_ShapeList) this).\u0001.Rows[index].Cells[1].Selected = false;
      }
      ((F_ShapeList) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_DrillList) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_DrillList) this).parShape);
    ((buClipperBase) ((F_DrillList) this).selectedShape).planeName = ((F_DrillList) this).parShape.selectedPlane;
    ((buClipper) ((F_DrillList) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((F_DrillList) this).parShape.selectedPlane);
    ((buClipperBase) ((F_DrillList) this).selectedShape).Corner = ((F_DrillList) this).parShape.selectedCorner;
    ((buClipperBase) ((F_DrillList) this).selectedShape).Alignment = ((F_DrillList) this).parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2_1);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_DrillList) this).PropertiesForm.Inited)
      return;
    if (control.Name == ((F_ShapeList) this).\u0001.Name && ((F_DrillList) this).selectedShape is buShapeCut)
    {
      buShapeCut selectedShape = ((F_DrillList) this).selectedShape as buShapeCut;
      ((DiemakerGrindingShapeSettings) selectedShape).isMilling = ((F_ShapeList) this).\u0001.Checked;
      ((F_DrillList) this).parShape.isMillingCut = ((DiemakerGrindingShapeSettings) selectedShape).isMilling;
      this.ShapeToDataGrid(((F_DrillList) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_DrillList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_DrillList) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_DrillList) this).\u0001((object) ((F_DrillList) this).selectedShape, (object) Data2);
      }
    }
    ((F_DrillList) this).PropertiesForm.Inited = false;
    this.Apply();
    ((F_DrillList) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((EventArgs) null, obj0, (F_CutList) this);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_DrillList) this).PropertiesForm.Inited || !((F_DrillList) this).ShowTool || !(((F_ShapeList) this).cmb_tools.SelectedIndex >= 0 & ((F_ShapeList) this).cmb_tools.SelectedIndex <= ((F_DrillList) this).Tools.Count - 1))
      return;
    ((F_DrillList) this).activeTool = (ToolBase5) new ToolGeometry5(((F_DrillList) this).Tools[((F_ShapeList) this).cmb_tools.SelectedIndex]);
  }

  public event OkCommandWithTwoDataEventHandler RotateCommad;

  public event CancelCommandEventHandler CancelCommad;
}
