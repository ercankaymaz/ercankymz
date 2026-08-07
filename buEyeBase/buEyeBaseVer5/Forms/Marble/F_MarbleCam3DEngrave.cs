// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCam3DEngrave
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Location;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.MortiseTenon;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.Forms.Profile;
using buEyeBaseVer5.Forms.Sewing;
using buEyeBaseVer5.Forms.Shape;
using dummy_ptr;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCam3DEngrave : Form
{
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal ToolStripMenuItem \u0007;
  public CheckBox chk_preview;
  internal ToolStripSeparator \u0003;
  internal ToolStripMenuItem \u0008;
  internal Label \u0003;
  internal Panel \u0003;
  internal ToolStripSeparator \u0004;
  internal Panel \u0004;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;
  internal NumericUpDown \u0002;
  internal CheckBox \u0002;
  internal NumericUpDown \u0003;
  internal CheckBox \u0003;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal CheckBox \u0004;
  internal TextBox \u0003;
  internal Label \u0005;
  internal Label \u0006;

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_PanelCutMaterials) this).dgv_data.Rows.Count < 2)
      return;
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Top | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Bottom | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Free)
    {
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.X = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[0].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Y = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[1].Cells[1].Value);
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Front | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Back)
    {
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.X = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[0].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Z = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[1].Cells[1].Value);
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Left | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Right)
    {
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Y = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[0].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Z = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[1].Cells[1].Value);
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Rectangle)
    {
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleWidth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleHeight = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleRadius = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[7].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Circle)
    {
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CircleRadius = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value) / 2.0;
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CircleDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Circle;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Ellipse)
    {
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseRadiusX = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value) / 2.0;
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseRadiusY = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value) / 2.0;
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Ellipse;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.KeyHole)
    {
      ((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleHeadDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleLength = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[7].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.KeyHole;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Polygon)
    {
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonRadius = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value) / 2.0;
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonSide = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Polygon;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Slot)
    {
      ((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotLength = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Slot;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Hole)
    {
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).HoleDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).HoleDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isTapping = false;
      if (((F_PanelCutMaterials) this).dgv_data.Rows.Count >= 7)
      {
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isTapping = true;
        ((MeasureItem) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      }
      if (((F_PanelCutMaterials) this).dgv_data.Rows.Count >= 8)
        ((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[7].Cells[1].Value);
      if (((F_PanelCutMaterials) this).dgv_data.Rows.Count >= 9)
        ((MeasureItem) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingPitch = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[8].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Hole;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Cut)
    {
      ((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutDiameter = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutLength = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Cut;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.FreeDraw)
    {
      ((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawWidth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawHeight = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      if (((F_PanelCutMaterials) this).dgv_data.Rows.Count >= 6 & ((dynamicInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).DepthLevels.Count >= 2)
        ((dynamicInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).DepthLevels[1] = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
      if (((F_PanelCutMaterials) this).dgv_data.Rows.Count >= 7 & ((dynamicInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).DepthLevels.Count >= 3)
        ((dynamicInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).DepthLevels[2] = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType == ShapeTypes.Text)
    {
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextWidth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[2].Cells[1].Value);
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextHeight = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[3].Cells[1].Value);
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextString = Convert.ToString(((F_PanelCutMaterials) this).dgv_data.Rows[4].Cells[1].Value);
      if (!((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire)
      {
        ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextFont = buNumeric5.StringToFont(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value.ToString());
        ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
        ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[7].Cells[1].Value);
        ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[8].Cells[1].Value);
      }
      else
      {
        ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value);
        ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth = Convert.ToDouble(((F_PanelCutMaterials) this).dgv_data.Rows[6].Cells[1].Value);
        ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority = Convert.ToInt32(((F_PanelCutMaterials) this).dgv_data.Rows[7].Cells[1].Value);
      }
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Text;
    }
    ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EachLayer = ((F_PanelCutMaterials) this).\u0003.Checked;
    ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isIncrementalMode = ((F_PanelCutMaterials) this).\u0002.Checked;
    ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthEnable = ((F_SlotNoDepth) this).chk_manuelmode.Checked;
    ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket = ((F_PanelCutMaterials) this).\u0001.Checked;
    ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthStart = (double) ((F_SlotNoDepth) this).spn_manuelzstart.Value;
  }

  public void ShapeToDataGrid(int Index)
  {
    bool inited = ((F_PanelCutSheetList) this).PropertiesForm.Inited;
    ((F_PanelCutMaterials) this).dgv_data.Rows.Clear();
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Top | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Bottom | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Free)
    {
      DataGridViewRowCollection rows1 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str1 = "X";
      object[] objArray1 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.X), (F_OperationList) this, str1);
      rows1.Add(objArray1);
      DataGridViewRowCollection rows2 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str2 = "Y";
      object[] objArray2 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Y), (F_OperationList) this, str2);
      rows2.Add(objArray2);
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Left | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Right)
    {
      DataGridViewRowCollection rows3 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str3 = "Y";
      object[] objArray3 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Y), (F_OperationList) this, str3);
      rows3.Add(objArray3);
      DataGridViewRowCollection rows4 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str4 = "Z";
      object[] objArray4 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Z), (F_OperationList) this, str4);
      rows4.Add(objArray4);
    }
    if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Front | ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Back)
    {
      DataGridViewRowCollection rows5 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str5 = "X";
      object[] objArray5 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.X), (F_OperationList) this, str5);
      rows5.Add(objArray5);
      DataGridViewRowCollection rows6 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str6 = "Z";
      object[] objArray6 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.pntBase.Z), (F_OperationList) this, str6);
      rows6.Add(objArray6);
    }
    if (Index == 0)
    {
      DataGridViewRowCollection rows7 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string width = buLangTranslate.preDef.Width;
      object[] objArray7 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleWidth), (F_OperationList) this, width);
      rows7.Add(objArray7);
      DataGridViewRowCollection rows8 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string height = buLangTranslate.preDef.Height;
      object[] objArray8 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleHeight), (F_OperationList) this, height);
      rows8.Add(objArray8);
      DataGridViewRowCollection rows9 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string radius = buLangTranslate.preDef.Radius;
      object[] objArray9 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleRadius), (F_OperationList) this, radius);
      rows9.Add(objArray9);
      DataGridViewRowCollection rows10 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray10 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).RectangleDepth), (F_OperationList) this, depth);
      rows10.Add(objArray10);
      DataGridViewRowCollection rows11 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray11 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str);
      rows11.Add(objArray11);
      DataGridViewRowCollection rows12 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray12 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows12.Add(objArray12);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 1)
    {
      DataGridViewRowCollection rows13 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str7 = AppLanguage.CadCamDynamic[57];
      object[] objArray13 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CircleRadius * 2.0), (F_OperationList) this, str7);
      rows13.Add(objArray13);
      DataGridViewRowCollection rows14 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray14 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CircleDepth), (F_OperationList) this, depth);
      rows14.Add(objArray14);
      DataGridViewRowCollection rows15 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str8 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray15 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str8);
      rows15.Add(objArray15);
      DataGridViewRowCollection rows16 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray16 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows16.Add(objArray16);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Circle;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 2)
    {
      DataGridViewRowCollection rows17 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str9 = AppLanguage.CadCamDynamic[20];
      object[] objArray17 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseRadiusX * 2.0), (F_OperationList) this, str9);
      rows17.Add(objArray17);
      DataGridViewRowCollection rows18 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str10 = AppLanguage.CadCamDynamic[21];
      object[] objArray18 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseRadiusY * 2.0), (F_OperationList) this, str10);
      rows18.Add(objArray18);
      DataGridViewRowCollection rows19 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray19 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EllipseDepth), (F_OperationList) this, depth);
      rows19.Add(objArray19);
      DataGridViewRowCollection rows20 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str11 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray20 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str11);
      rows20.Add(objArray20);
      DataGridViewRowCollection rows21 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray21 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows21.Add(objArray21);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Ellipse;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 3)
    {
      DataGridViewRowCollection rows22 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str12 = AppLanguage.CadCamDynamic[128 /*0x80*/];
      object[] objArray22 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleHeadDiameter), (F_OperationList) this, str12);
      rows22.Add(objArray22);
      DataGridViewRowCollection rows23 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str13 = AppLanguage.CadCamDynamic[57];
      object[] objArray23 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleDiameter), (F_OperationList) this, str13);
      rows23.Add(objArray23);
      DataGridViewRowCollection rows24 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str14 = AppLanguage.CadCamDynamic[0];
      object[] objArray24 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleLength), (F_OperationList) this, str14);
      rows24.Add(objArray24);
      DataGridViewRowCollection rows25 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray25 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).KeyHoleDepth), (F_OperationList) this, depth);
      rows25.Add(objArray25);
      DataGridViewRowCollection rows26 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str15 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray26 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str15);
      rows26.Add(objArray26);
      DataGridViewRowCollection rows27 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray27 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows27.Add(objArray27);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.KeyHole;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 4)
    {
      DataGridViewRowCollection rows28 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str16 = AppLanguage.CadCamDynamic[57];
      object[] objArray28 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonRadius * 2.0), (F_OperationList) this, str16);
      rows28.Add(objArray28);
      DataGridViewRowCollection rows29 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str17 = AppLanguage.CadCamDynamic[71];
      object[] objArray29 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit((double) ((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonSide), (F_OperationList) this, str17);
      rows29.Add(objArray29);
      DataGridViewRowCollection rows30 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray30 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).PolygonDepth), (F_OperationList) this, depth);
      rows30.Add(objArray30);
      DataGridViewRowCollection rows31 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str18 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray31 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str18);
      rows31.Add(objArray31);
      DataGridViewRowCollection rows32 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray32 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows32.Add(objArray32);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Polygon;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 5)
    {
      DataGridViewRowCollection rows33 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str19 = AppLanguage.CadCamDynamic[57];
      object[] objArray33 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotDiameter), (F_OperationList) this, str19);
      rows33.Add(objArray33);
      DataGridViewRowCollection rows34 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str20 = AppLanguage.CadCamDynamic[0];
      object[] objArray34 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectedPlaneInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotLength), (F_OperationList) this, str20);
      rows34.Add(objArray34);
      DataGridViewRowCollection rows35 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray35 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntityTypes) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SlotDepth), (F_OperationList) this, depth);
      rows35.Add(objArray35);
      DataGridViewRowCollection rows36 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str21 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray36 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str21);
      rows36.Add(objArray36);
      DataGridViewRowCollection rows37 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray37 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows37.Add(objArray37);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Slot;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 6 | Index == 11)
    {
      DataGridViewRowCollection rows38 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string diameter = buLangTranslate.preDef.Diameter;
      object[] objArray38 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).HoleDiameter), (F_OperationList) this, diameter);
      rows38.Add(objArray38);
      DataGridViewRowCollection rows39 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray39 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).HoleDepth), (F_OperationList) this, depth);
      rows39.Add(objArray39);
      DataGridViewRowCollection rows40 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str22 = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray40 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str22);
      rows40.Add(objArray40);
      DataGridViewRowCollection rows41 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray41 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows41.Add(objArray41);
      if (Index == 11)
      {
        DataGridViewRowCollection rows42 = ((F_PanelCutMaterials) this).dgv_data.Rows;
        string str23 = $"{buLangTranslate.preDef.Tapping} {buLangTranslate.preDef.Diameter}";
        object[] objArray42 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureItem) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingDiameter), (F_OperationList) this, str23);
        rows42.Add(objArray42);
        DataGridViewRowCollection rows43 = ((F_PanelCutMaterials) this).dgv_data.Rows;
        string str24 = $"{buLangTranslate.preDef.Tapping} {buLangTranslate.preDef.Depth}";
        object[] objArray43 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingDepth), (F_OperationList) this, str24);
        rows43.Add(objArray43);
        DataGridViewRowCollection rows44 = ((F_PanelCutMaterials) this).dgv_data.Rows;
        string str25 = $"{buLangTranslate.preDef.Tapping} {buLangTranslate.preDef.Pitch}";
        object[] objArray44 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureItem) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TappingPitch), (F_OperationList) this, str25);
        rows44.Add(objArray44);
      }
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Hole;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 7)
    {
      DataGridViewRowCollection rows45 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string width = buLangTranslate.preDef.Width;
      object[] objArray45 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutDiameter), (F_OperationList) this, width);
      rows45.Add(objArray45);
      DataGridViewRowCollection rows46 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string length = buLangTranslate.preDef.Length;
      object[] objArray46 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutLength), (F_OperationList) this, length);
      rows46.Add(objArray46);
      DataGridViewRowCollection rows47 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray47 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((MeasureData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).CutDepth), (F_OperationList) this, depth);
      rows47.Add(objArray47);
      DataGridViewRowCollection rows48 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray48 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str);
      rows48.Add(objArray48);
      DataGridViewRowCollection rows49 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray49 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows49.Add(objArray49);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Cut;
      if (MarbleItemCam.SelectedOperations.Count >= 2)
        this.UpdateGridsFromMultiSelect(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType);
    }
    if (Index == 8)
    {
      DataGridViewRowCollection rows50 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string width = buLangTranslate.preDef.Width;
      object[] objArray50 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawWidth), (F_OperationList) this, width);
      rows50.Add(objArray50);
      DataGridViewRowCollection rows51 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string height = buLangTranslate.preDef.Height;
      object[] objArray51 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawHeight), (F_OperationList) this, height);
      rows51.Add(objArray51);
      DataGridViewRowCollection rows52 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray52 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionOperation) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).FreeDrawDepth), (F_OperationList) this, depth);
      rows52.Add(objArray52);
      DataGridViewRowCollection rows53 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray53 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str);
      rows53.Add(objArray53);
      DataGridViewRowCollection rows54 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray54 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows54.Add(objArray54);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
    }
    if (Index == 9 | Index == 10)
    {
      DataGridViewRowCollection rows55 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string width = buLangTranslate.preDef.Width;
      object[] objArray55 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextWidth), (F_OperationList) this, width);
      rows55.Add(objArray55);
      DataGridViewRowCollection rows56 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string height = buLangTranslate.preDef.Height;
      object[] objArray56 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextHeight), (F_OperationList) this, height);
      rows56.Add(objArray56);
      DataGridViewRowCollection rows57 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string text = buLangTranslate.preDef.Text;
      object[] objArray57 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextString, (F_OperationList) this, text);
      rows57.Add(objArray57);
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType = ShapeTypes.Text;
      ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire = false;
      if (Index == 9)
      {
        DataGridViewRowCollection rows58 = ((F_PanelCutMaterials) this).dgv_data.Rows;
        string font = buLangTranslate.preDef.Font;
        object[] objArray58 = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(buNumeric5.FontToString(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextFont), (F_OperationList) this, font);
        rows58.Add(objArray58);
      }
      if (Index == 10)
        ((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire = true;
      DataGridViewRowCollection rows59 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string depth = buLangTranslate.preDef.Depth;
      object[] objArray59 = \u0007.\u0001.\u0001(((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextDepth, (F_OperationList) this, depth);
      rows59.Add(objArray59);
      DataGridViewRowCollection rows60 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string str = $"{buLangTranslate.preDef.Extra} {buLangTranslate.preDef.Depth}";
      object[] objArray60 = \u0007.\u0001.\u0001(buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ExtraDepth), (F_OperationList) this, str);
      rows60.Add(objArray60);
      DataGridViewRowCollection rows61 = ((F_PanelCutMaterials) this).dgv_data.Rows;
      string priority = buLangTranslate.preDef.Priority;
      object[] objArray61 = \u0007.\u0001.\u0001((double) ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).Priority, (F_OperationList) this, priority);
      rows61.Add(objArray61);
    }
    ((F_SlotNoDepth) this).spn_manuelzstart.Value = (Decimal) buFile5.RoundThreeDigit(((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthStart);
    ((F_PanelCutMaterials) this).\u0003.Checked = ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EachLayer;
    ((F_PanelCutMaterials) this).\u0002.Checked = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isIncrementalMode;
    ((F_SlotNoDepth) this).chk_manuelmode.Checked = ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthEnable;
    ((F_PanelCutMaterials) this).\u0001.Checked = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket;
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = inited;
  }

  public void UpdateGridsFromMultiSelect(ShapeTypes OperationType)
  {
    if (OperationType == ShapeTypes.Rectangle)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[4].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
      {
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
        ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = true;
        ((F_PanelCutMaterials) this).dgv_data.Rows[4].Visible = true;
      }
    }
    if (OperationType == ShapeTypes.Circle)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
    }
    if (OperationType == ShapeTypes.Ellipse)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
      {
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
        ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = true;
      }
    }
    if (OperationType == ShapeTypes.KeyHole)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[4].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
      {
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
        ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = true;
        ((F_PanelCutMaterials) this).dgv_data.Rows[4].Visible = true;
      }
    }
    if (OperationType == ShapeTypes.Polygon)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
    }
    if (OperationType == ShapeTypes.Hole)
    {
      ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
      ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
      if (MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize)
        ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
    }
    if (OperationType != ShapeTypes.Cut)
      return;
    ((F_PanelCutMaterials) this).dgv_data.Rows[0].Visible = false;
    ((F_PanelCutMaterials) this).dgv_data.Rows[1].Visible = false;
    ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = false;
    ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = false;
    if (!(MarbleItemCam.MultiSelectedProps.AllSameShape & MarbleItemCam.MultiSelectedProps.AllSameSize))
      return;
    ((F_PanelCutMaterials) this).dgv_data.Rows[2].Visible = true;
    ((F_PanelCutMaterials) this).dgv_data.Rows[3].Visible = true;
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      if (!((F_PanelCutSheetList) this).PropertiesForm.Inited)
        return;
      ((F_PanelCutSheetList) this).CellFirstSelected = true;
      if (!(obj1.ColumnIndex >= 1 & obj1.RowIndex >= 0))
        return;
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 == null)
        return;
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      if (MarbleItem.OperationEditing & ((dynamicInfo) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).UpdateEditOperationWithoutOk)
        ((ShapeRuntimeData) Data2).Finished = true;
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      if (!((F_PanelCutSheetList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0 & ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex != obj1.RowIndex))
        return;
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
      ((ProfileSettings) buCall.\u0001).FindShapeDataValueType(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 == null)
        return;
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      ((ShapeRuntimeData) Data2).Command = "DrawDim";
      ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    catch (Exception ex)
    {
    }
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      if (!((F_PanelCutSheetList) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0) || ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ShapeType != ShapeTypes.Text || !(!((SelectionEntity) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).TextIsWire & obj1.RowIndex == 5))
        return;
      FontDialog fontDialog = new FontDialog();
      fontDialog.Font = buNumeric5.StringToFont(((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value.ToString());
      int num = (int) fontDialog.ShowDialog();
      ((F_PanelCutMaterials) this).dgv_data.Rows[5].Cells[1].Value = (object) buNumeric5.FontToString(fontDialog.Font);
    }
    catch (Exception ex)
    {
    }
  }

  private void \u0004([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    try
    {
      if (!((F_PanelCutSheetList) this).PropertiesForm.Inited)
        return;
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0 & ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex != obj1.RowIndex)
      {
        ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
        ((ProfileSettings) buCall.\u0001).FindShapeDataValueType(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
        // ISSUE: reference to a compiler-generated field
        if (((F_PanelCutSheetList) this).\u0001 != null)
        {
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
          ((ShapeRuntimeData) Data2).Command = "DrawDim";
          ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
          // ISSUE: reference to a compiler-generated field
          ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
        }
      }
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_PanelCutMaterials) this).btn_ok.Name)
    {
      ((F_PanelCutSheetList) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_PanelCutSheetList) this).ClosePageAfterOk)
      {
        if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_cancel.Name)
    {
      ((F_PanelCutSheetList) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_PanelCutSheetList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      {
        this.Visible = false;
        if (this.Owner != null)
          this.Owner.Focus();
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001();
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).\u0004.Name)
    {
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      if (!((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket)
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket = true;
      else
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket = false;
      ((F_PanelCutMaterials) this).\u0001.Checked = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket;
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).\u0005.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_CabinetSettings) fCornerLocation).Properties.FormPosition = FormStartPosition.Manual;
      fCornerLocation.Top = 100;
      fCornerLocation.Left = Screen.PrimaryScreen.Bounds.Width - fCornerLocation.Width;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_PanelCutMaterials) this).\u0005.ImageIndex = Convert.ToInt32((object) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_PanelCutSheetList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_PanelCutMaterials) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormPosition = FormStartPosition.Manual;
      fObjectLocation.Top = 100;
      fObjectLocation.Left = Screen.PrimaryScreen.Bounds.Width - fObjectLocation.Width;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_PanelCutMaterials) this).\u0002.ImageIndex = Convert.ToInt32((object) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_PanelCutSheetList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_PanelCutMaterials) this).\u0001.Name)
    {
      F_ShapeEdit fShapeEdit = (F_ShapeEdit) new F_SewingMove();
      ((F_SewingFootHeight) fShapeEdit).Edit = (ShapeEdit) new ColorType(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.Edit);
      ((F_SewingSpeed) fShapeEdit).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_SewingSpeed) fShapeEdit).Properties.FormPosition = FormStartPosition.Manual;
      ((F_SewingFootHeight) fShapeEdit).ShowPolar = false;
      ((F_SewingFootHeight) fShapeEdit).refPlane = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane;
      fShapeEdit.Height = 300;
      fShapeEdit.Top = 100;
      fShapeEdit.Left = Screen.PrimaryScreen.Bounds.Width - fShapeEdit.Width - 100;
      ((F_SewingMove) fShapeEdit).Init();
      int num = (int) fShapeEdit.ShowDialog((IWin32Window) this);
      if (((F_SewingSpeed) fShapeEdit).Properties.Result == DialogResult.OK)
      {
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.Edit = (ShapeEdit) new ColorType(((F_SewingFootHeight) fShapeEdit).Edit);
        // ISSUE: reference to a compiler-generated field
        if (((F_PanelCutSheetList) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_camsettings.Name)
    {
      F_CamSettings fCamSettings = (F_CamSettings) new F_ProfileAdd();
      ((F_ProfileCopy) fCamSettings).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_ProfileCopy) fCamSettings).CamPar = (camParameters5) new camRuntime5(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars);
      ((F_ProfileAdd) fCamSettings).Init();
      int num = (int) fCamSettings.ShowDialog((IWin32Window) this);
      if (((F_ProfileCopy) fCamSettings).Properties.Result == DialogResult.OK)
      {
        ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars = (camParameters5) new camRuntime5(((F_ProfileCopy) fCamSettings).CamPar);
        MarbleItem.CamAssinged = true;
        // ISSUE: reference to a compiler-generated field
        if (((F_PanelCutSheetList) this).\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_PanelCutSheetList) this).\u0001((object) null, (object) (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters), (object) null);
        }
      }
      this.Focus();
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_PanelCutMaterials) this).btn_toolsettings.Name && ((F_PanelCutSheetList) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) "ToolEdit", (object) "");
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_top.Name)
    {
      int indexRow = -1;
      int indexCol = -1;
      ((F_MarbleCamProfile) this).GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane = planeBoxNames.Top;
      ((F_Material3D) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ((F_MarbleCamProfile) this).SetRowColIndex(indexRow, indexCol);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Command = "PlaneChanged";
        ((ShapeRuntimeData) Data2).ValueType = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_bottom.Name)
    {
      int indexRow = -1;
      int indexCol = -1;
      ((F_MarbleCamProfile) this).GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane = planeBoxNames.Bottom;
      ((F_Material3D) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ((F_MarbleCamProfile) this).SetRowColIndex(indexRow, indexCol);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Command = "PlaneChanged";
        ((ShapeRuntimeData) Data2).ValueType = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ValueType;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_free.Name)
    {
      int indexRow = -1;
      int indexCol = -1;
      ((F_MarbleCamProfile) this).GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane = planeBoxNames.Free;
      ((F_Material3D) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ((F_MarbleCamProfile) this).SetRowColIndex(indexRow, indexCol);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Command = "PlaneChanged";
        ((ShapeRuntimeData) Data2).ValueType = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ValueType;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_front.Name)
    {
      int indexRow = -1;
      int indexCol = -1;
      ((F_MarbleCamProfile) this).GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane = planeBoxNames.Front;
      ((F_Material3D) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ((F_MarbleCamProfile) this).SetRowColIndex(indexRow, indexCol);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Command = "PlaneChanged";
        ((ShapeRuntimeData) Data2).ValueType = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ValueType;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    if (control2.Name == ((F_PanelCutMaterials) this).btn_back.Name)
    {
      int indexRow = -1;
      int indexCol = -1;
      ((F_MarbleCamProfile) this).GetRowColIndex(ref indexRow, ref indexCol);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane = planeBoxNames.Back;
      ((F_Material3D) this).PlaneColorUpdate();
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ((F_MarbleCamProfile) this).SetRowColIndex(indexRow, indexCol);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        ((ShapeRuntimeData) Data2).Command = "PlaneChanged";
        ((ShapeRuntimeData) Data2).ValueType = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.ValueType;
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((F_PanelCutMaterials) this).\u0003.Name) || ((F_PanelCutSheetList) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_PanelCutSheetList) this).\u0001((object) "PlaneSelect", (object) "");
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_PanelCutSheetList) this).PropertiesForm.Inited)
      return;
    ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthStart = (double) ((F_SlotNoDepth) this).spn_manuelzstart.Value;
    // ISSUE: reference to a compiler-generated field
    if (((F_PanelCutSheetList) this).\u0001 != null)
    {
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_PanelCutSheetList) this).PropertiesForm.Inited || AppBool.Started)
      return;
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_SlotNoDepth) this).chk_locked.Name && ((F_PanelCutSheetList) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) "Locked", (object) ((F_SlotNoDepth) this).chk_locked.Checked);
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    if (control.Name == ((F_PanelCutMaterials) this).\u0001.Name)
    {
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket = ((F_PanelCutMaterials) this).\u0001.Checked;
      ((camOperation5) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.CamPars.Pockets).Enable = ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isShapePocket;
      this.ShapeToDataGrid(((F_PanelCutMaterials) this).\u0001);
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_PanelCutMaterials) this).\u0002.Name && ((F_PanelCutSheetList) this).\u0001 != null)
    {
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.isIncrementalMode = ((F_PanelCutMaterials) this).\u0002.Checked;
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_PanelCutMaterials) this).\u0003.Name && ((F_PanelCutSheetList) this).\u0001 != null)
    {
      if (((F_PanelCutMaterials) this).\u0003.Checked)
      {
        ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
        ((F_SlotNoDepth) this).chk_manuelmode.Checked = false;
        ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthEnable = false;
      }
      ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
      ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
      ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EachLayer = ((F_PanelCutMaterials) this).\u0003.Checked;
      ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
      // ISSUE: reference to a compiler-generated field
      ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
    }
    if (control.Name == ((F_SlotNoDepth) this).chk_manuelmode.Name)
    {
      if (((F_SlotNoDepth) this).chk_manuelmode.Checked)
      {
        ((F_PanelCutSheetList) this).PropertiesForm.Inited = false;
        ((F_PanelCutMaterials) this).\u0003.Checked = false;
        ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).EachLayer = false;
        ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
        if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Front)
        {
          if ((double) ((F_SlotNoDepth) this).spn_manuelzstart.Value > -((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailHeight / 3.0)
            ((F_SlotNoDepth) this).spn_manuelzstart.Value = (Decimal) -((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailHeight;
        }
        else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Back)
        {
          if ((double) ((F_SlotNoDepth) this).spn_manuelzstart.Value < -((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailHeight / 3.0)
            ((F_SlotNoDepth) this).spn_manuelzstart.Value = 0M;
          if ((double) ((F_SlotNoDepth) this).spn_manuelzstart.Value > 1.0)
            ((F_SlotNoDepth) this).spn_manuelzstart.Value = 0M;
        }
        else if (((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters.selectedPlane == planeBoxNames.Bottom)
        {
          if ((double) ((F_SlotNoDepth) this).spn_manuelzstart.Value > ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailDepth / 3.0)
            ((F_SlotNoDepth) this).spn_manuelzstart.Value = 0M;
        }
        else if ((double) ((F_SlotNoDepth) this).spn_manuelzstart.Value < ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailDepth / 3.0)
          ((F_SlotNoDepth) this).spn_manuelzstart.Value = (Decimal) -((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).SizeMaterailDepth;
        ((CurveToSurfaceSettingsType) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthStart = (double) ((F_SlotNoDepth) this).spn_manuelzstart.Value;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_PanelCutSheetList) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeTempData) ((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters).ManuelDepthEnable = ((F_SlotNoDepth) this).chk_manuelmode.Checked;
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) ProfileSettings.varProfileRunSettings).ShapeDataParameters);
        // ISSUE: reference to a compiler-generated field
        ((F_PanelCutSheetList) this).\u0001((object) null, (object) Data2, (object) null);
      }
    }
    this.Apply();
    ((F_PanelCutSheetList) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001(obj0, (EventArgs) null, (F_OperationList) this);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
