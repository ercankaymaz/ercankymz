// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Sewing.F_SewingFootHeight
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingFootHeight : Form
{
  public static List<string> Captions;
  public bool ShowPolar;
  public planeBoxNames refPlane;
  private Color \u0001;
  private Color \u0002;
  public ShapeEdit Edit;
  internal IContainer \u0001;
  public Button btn_polararray;
  public Button btn_lineararray;
  public Button btn_mirrorver;
  public Button btn_mirrorhor;

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      this.Text = buLangTranslate.preDef.Profile;
      ((F_DrillList) this).\u0003.Text = buLangTranslate.preDef.Top;
      ((F_DrillList) this).\u0005.Text = buLangTranslate.preDef.Back;
      ((F_DrillList) this).\u0007.Text = buLangTranslate.preDef.Bottom;
      ((F_DrillList) this).\u0001.Text = buLangTranslate.preDef.Command;
      ((F_DrillList) this).\u0006.Text = buLangTranslate.preDef.Front;
      ((F_DrillList) this).\u0004.Text = buLangTranslate.preDef.Left;
      ((F_DrillList) this).\u0002.Text = buLangTranslate.preDef.Right;
      ((F_DrillList) this).btn_camsettings.Text = buLangTranslate.preDef.Cam;
      ((F_ShapeEdit) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_ShapeEdit) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
    ((F_DrillList) this).btn_back.BackColor = Color.Gainsboro;
    ((F_DrillList) this).btn_bottom.BackColor = Color.Gainsboro;
    ((F_DrillList) this).btn_front.BackColor = Color.Gainsboro;
    ((F_DrillList) this).btn_left.BackColor = Color.Gainsboro;
    ((F_DrillList) this).btn_right.BackColor = Color.Gainsboro;
    ((F_DrillList) this).btn_top.BackColor = Color.Gainsboro;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Top)
      ((F_DrillList) this).btn_top.BackColor = Color.PaleGreen;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Bottom)
      ((F_DrillList) this).btn_bottom.BackColor = Color.PaleGreen;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Front)
      ((F_DrillList) this).btn_front.BackColor = Color.PaleGreen;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Back)
      ((F_DrillList) this).btn_back.BackColor = Color.PaleGreen;
    if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Left)
      ((F_DrillList) this).btn_left.BackColor = Color.PaleGreen;
    if (((F_ShapeEdit) this).parShape.selectedPlane != planeBoxNames.Right)
      return;
    ((F_DrillList) this).btn_right.BackColor = Color.PaleGreen;
  }

  public void Apply()
  {
  }

  public void DataGridValuesToShape(int ColumnIndex, int RowIndex)
  {
    if (((F_DrillList) this).\u0001.Rows.Count < 2 || ColumnIndex >= 0 & RowIndex >= 0 && !buFile5.IsNumeric(((F_DrillList) this).\u0001.Rows[RowIndex].Cells[ColumnIndex].Value.ToString()))
      return;
    if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRectangle)
    {
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Width = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[0].Cells[1].Value);
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Height = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[1].Cells[1].Value);
      ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[2].Cells[1].Value);
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ((F_ShapeEdit) this).parShape.ProfilingType;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingWidth = ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Width;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingHeight = ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Height;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth = ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRound)
    {
      ((buCutter) ((F_ShapeEdit) this).selectedShape).Radius = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[0].Cells[1].Value);
      ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[1].Cells[1].Value);
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ((F_ShapeEdit) this).parShape.ProfilingType;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius = ((buCutter) ((F_ShapeEdit) this).selectedShape).Radius;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth = ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingChamfer)
    {
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Length = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[0].Cells[1].Value);
      ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[1].Cells[1].Value);
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ((F_ShapeEdit) this).parShape.ProfilingType;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingLength = ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Length;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth = ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth;
    }
    else if (((F_ShapeEdit) this).parShape.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
    {
      ((buCutter) ((F_ShapeEdit) this).selectedShape).Radius = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[0].Cells[1].Value);
      ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth = Convert.ToDouble(((F_DrillList) this).\u0001.Rows[1].Cells[1].Value);
      ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ((F_ShapeEdit) this).parShape.ProfilingType;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius = ((buCutter) ((F_ShapeEdit) this).selectedShape).Radius;
      ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth = ((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth;
    }
    if (((F_ShapeEdit) this).selectedShape is buShapeProfiling)
      ((buClipperBase) (((F_ShapeEdit) this).selectedShape as buShapeProfiling)).isPocket = ((F_DrillList) this).\u0001.Checked;
    ((F_ShapeEdit) this).parShape.pntBase.X = ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint.X;
    ((F_ShapeEdit) this).parShape.pntBase.Y = ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint.Y;
    ((F_ShapeEdit) this).parShape.pntBase.Z = ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint.Z;
  }

  public void ShapeToDataGrid(int Index)
  {
    ((F_DrillList) this).\u0001.Rows.Clear();
    if (Index > 3)
    {
      if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Top | ((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Bottom)
      {
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.X, (F_ProfilingList) this, "X"));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.Y, (F_ProfilingList) this, "Y"));
      }
      if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Left | ((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Right)
      {
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.Y, (F_ProfilingList) this, "Y"));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.Z, (F_ProfilingList) this, "Z"));
      }
      if (((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Front | ((F_ShapeEdit) this).parShape.selectedPlane == planeBoxNames.Back)
      {
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.X, (F_ProfilingList) this, "X"));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_ShapeEdit) this).parShape.pntBase.Z, (F_ProfilingList) this, "Z"));
      }
    }
    switch (Index)
    {
      case 0:
        ((F_ShapeEdit) this).selectedShape = (buShape) new buSelectionPoint(ProfilingTypes.ProfilingRectangle, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingLength, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingWidth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingHeight);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).isPocket = ((F_ShapeEdit) this).parShape.isProfilingPocket;
        ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ProfilingTypes.ProfilingRectangle;
        ((F_ShapeEdit) this).parShape.ProfilingType = ProfilingTypes.ProfilingRectangle;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint = new Point3D(((F_ShapeEdit) this).parShape.pntBase.X, ((F_ShapeEdit) this).parShape.pntBase.Y, ((F_ShapeEdit) this).parShape.pntBase.Z);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_ShapeEdit) this).parShape.objectAlignment;
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Width, (F_ProfilingList) this, buLangTranslate.preDef.Width));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Height, (F_ProfilingList) this, buLangTranslate.preDef.Height));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth, (F_ProfilingList) this, buLangTranslate.preDef.Depth));
        break;
      case 1:
        ((F_ShapeEdit) this).selectedShape = (buShape) new buSelectionPoint(ProfilingTypes.ProfilingRound, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingLength, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingWidth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingHeight);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).isPocket = ((F_ShapeEdit) this).parShape.isProfilingPocket;
        ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ProfilingTypes.ProfilingRound;
        ((F_ShapeEdit) this).parShape.ProfilingType = ProfilingTypes.ProfilingRound;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint = new Point3D(((F_ShapeEdit) this).parShape.pntBase.X, ((F_ShapeEdit) this).parShape.pntBase.Y, ((F_ShapeEdit) this).parShape.pntBase.Z);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_ShapeEdit) this).parShape.objectAlignment;
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((buCutter) ((F_ShapeEdit) this).selectedShape).Radius, (F_ProfilingList) this, buLangTranslate.preDef.Radius));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth, (F_ProfilingList) this, buLangTranslate.preDef.Depth));
        break;
      case 2:
        ((F_ShapeEdit) this).selectedShape = (buShape) new buSelectionPoint(ProfilingTypes.ProfilingChamfer, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingLength, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingWidth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingHeight);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).isPocket = ((F_ShapeEdit) this).parShape.isProfilingPocket;
        ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ProfilingTypes.ProfilingChamfer;
        ((F_ShapeEdit) this).parShape.ProfilingType = ProfilingTypes.ProfilingChamfer;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint = new Point3D(((F_ShapeEdit) this).parShape.pntBase.X, ((F_ShapeEdit) this).parShape.pntBase.Y, ((F_ShapeEdit) this).parShape.pntBase.Z);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_ShapeEdit) this).parShape.objectAlignment;
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).Length, (F_ProfilingList) this, buLangTranslate.preDef.Length));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth, (F_ProfilingList) this, buLangTranslate.preDef.Depth));
        break;
      case 3:
        ((F_ShapeEdit) this).selectedShape = (buShape) new buSelectionPoint(ProfilingTypes.ProfilingRoundConcave, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingRadius, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingDepth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingLength, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingWidth, ((CustomDataAdd) ((F_ShapeEdit) this).parShape).ProfilingHeight);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).isPocket = ((F_ShapeEdit) this).parShape.isProfilingPocket;
        ((CutterIsoEntities) ((F_ShapeEdit) this).selectedShape).ProfilingType = ProfilingTypes.ProfilingRoundConcave;
        ((F_ShapeEdit) this).parShape.ProfilingType = ProfilingTypes.ProfilingRoundConcave;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).BasePoint = new Point3D(((F_ShapeEdit) this).parShape.pntBase.X, ((F_ShapeEdit) this).parShape.pntBase.Y, ((F_ShapeEdit) this).parShape.pntBase.Z);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
        ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName);
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_ShapeEdit) this).parShape.objectAlignment;
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((buCutter) ((F_ShapeEdit) this).selectedShape).Radius, (F_ProfilingList) this, buLangTranslate.preDef.Radius));
        ((F_DrillList) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((\u0012.\u0002) ((F_ShapeEdit) this).selectedShape).Depth, (F_ProfilingList) this, buLangTranslate.preDef.Depth));
        break;
    }
    ((buClipper) ((F_ShapeEdit) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((F_ShapeEdit) this).CamPar);
    ((F_DrillList) this).\u0001.Text = ((buNestedSheet) buCall.\u0001).JobItemCommandToString(((F_ShapeEdit) this).selectedShape);
  }

  private void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeEdit) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
  }

  private void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeEdit) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_ShapeEdit) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
  }

  private void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!((F_ShapeEdit) this).PropertiesForm.Inited || !(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0))
      return;
    ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
    this.DataGridValuesToShape(obj1.ColumnIndex, obj1.RowIndex);
    ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = obj1.RowIndex;
    buCall.\u0001.FindShapeDataValueType(((F_ShapeEdit) this).selectedShape, obj1.RowIndex, ref ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueType);
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ShapeEdit) this).btn_ok.Name)
    {
      ((F_ShapeEdit) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ShapeEdit) this).ClosePageAfterOk)
      {
        if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeEdit) this).\u0001 != null)
      {
        this.DataGridValuesToShape(-1, -1);
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeEdit) this).parShape);
        ((ShapeRuntimeData) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
      }
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_ShapeEdit) this).btn_cancel.Name)
    {
      ((F_ShapeEdit) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ShapeEdit) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      if (this.Owner != null)
        this.Owner.Focus();
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeEdit) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeEdit) this).\u0001();
      }
    }
    if (control.Name == ((F_DrillList) this).\u0001.Name)
    {
      F_CornerLocation fCornerLocation = (F_CornerLocation) new F_Contour();
      ((F_CabinetSettings) fCornerLocation).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
      ((F_CabinetSettings) fCornerLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fCornerLocation).Init();
      int num = (int) fCornerLocation.ShowDialog((IWin32Window) this);
      if (((F_CabinetSettings) fCornerLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_ShapeEdit) this).parShape.selectedCorner = ((F_CabinetSettings) fCornerLocation).Corner;
        ((F_DrillList) this).\u0001.ImageIndex = Convert.ToInt32((object) ((F_ShapeEdit) this).parShape.selectedCorner);
        // ISSUE: reference to a compiler-generated field
        if (((F_ShapeEdit) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeEdit) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_DrillList) this).\u0002.Name)
    {
      F_ObjectLocation fObjectLocation = (F_ObjectLocation) new F_Contour();
      ((F_KeyPadNumV1) fObjectLocation).Alingnment = ((F_ShapeEdit) this).parShape.objectAlignment;
      ((F_KeyPadNumV1) fObjectLocation).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_Contour) fObjectLocation).Init();
      int num = (int) fObjectLocation.ShowDialog((IWin32Window) this);
      if (((F_KeyPadNumV1) fObjectLocation).Properties.Result == DialogResult.OK)
      {
        ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_ShapeEdit) this).parShape.objectAlignment = ((F_KeyPadNumV1) fObjectLocation).Alingnment;
        ((F_DrillList) this).\u0002.ImageIndex = Convert.ToInt32((object) ((F_ShapeEdit) this).parShape.objectAlignment);
        // ISSUE: reference to a compiler-generated field
        if (((F_ShapeEdit) this).\u0001 != null)
        {
          this.DataGridValuesToShape(-1, -1);
          ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeEdit) this).parShape);
          ((ShapeRuntimeData) Data2).Finished = false;
          // ISSUE: reference to a compiler-generated field
          ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
        }
      }
      this.Focus();
      if (this.Owner != null)
        this.Owner.Focus();
    }
    if (control.Name == ((F_DrillList) this).\u0003.Name && ((F_ShapeEdit) this).selectedShape is buShapeHole)
    {
      buShapeProfiling selectedShape = ((F_ShapeEdit) this).selectedShape as buShapeProfiling;
      if (!((buClipperBase) selectedShape).isPocket)
        ((buClipperBase) selectedShape).isPocket = true;
      else
        ((buClipperBase) selectedShape).isPocket = false;
      ((F_DrillList) this).\u0001.Checked = ((buClipperBase) selectedShape).isPocket;
      ((F_ShapeEdit) this).parShape.isProfilingPocket = ((buClipperBase) selectedShape).isPocket;
      this.ShapeToDataGrid(((F_ShapeEdit) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeEdit) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
      }
    }
    if (control.Name == ((F_DrillList) this).btn_camsettings.Name)
    {
      F_CamSettings1 fCamSettings1 = (F_CamSettings1) new buEntity();
      ((buMultilineText) fCamSettings1).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((buMultilineText) fCamSettings1).CamPar = (camParameters5) new camRuntime5(((F_ShapeEdit) this).CamPar);
      ((buEntity) fCamSettings1).Init();
      int num = (int) fCamSettings1.ShowDialog((IWin32Window) this);
      if (((buMultilineText) fCamSettings1).Properties.Result == DialogResult.OK)
      {
        ((buClipper) ((F_ShapeEdit) this).selectedShape).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
        ((F_ShapeEdit) this).CamPar = (camParameters5) new camRuntime5(((buMultilineText) fCamSettings1).CamPar);
      }
      this.Focus();
    }
    if (!(control.Name == ((F_DrillList) this).btn_top.Name | control.Name == ((F_DrillList) this).btn_bottom.Name | control.Name == ((F_DrillList) this).btn_left.Name | control.Name == ((F_DrillList) this).btn_right.Name | control.Name == ((F_DrillList) this).btn_front.Name | control.Name == ((F_DrillList) this).btn_back.Name))
      return;
    if (control.Name == ((F_DrillList) this).btn_top.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Top;
    if (control.Name == ((F_DrillList) this).btn_bottom.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Bottom;
    if (control.Name == ((F_DrillList) this).btn_left.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Left;
    if (control.Name == ((F_DrillList) this).btn_right.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Right;
    if (control.Name == ((F_DrillList) this).btn_front.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Front;
    if (control.Name == ((F_DrillList) this).btn_back.Name)
      ((F_ShapeEdit) this).parShape.selectedPlane = planeBoxNames.Back;
    this.PlaneColorUpdate();
    int valueGridIndex = ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex;
    if (valueGridIndex >= 0 & valueGridIndex <= ((F_DrillList) this).\u0001.Rows.Count - 1)
    {
      ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
      ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName);
      this.ShapeToDataGrid(((F_ShapeEdit) this).\u0001);
      ((dynamicInfo) F_NotchEdit.ShapeTempPar).ValueGridIndex = valueGridIndex;
      for (int index = 0; index <= ((F_DrillList) this).\u0001.Rows.Count - 1; ++index)
      {
        ((F_DrillList) this).\u0001.Rows[index].Cells[0].Selected = false;
        ((F_DrillList) this).\u0001.Rows[index].Cells[1].Selected = false;
      }
      ((F_DrillList) this).\u0001.Rows[valueGridIndex].Cells[0].Selected = true;
    }
    // ISSUE: reference to a compiler-generated field
    if (((F_ShapeEdit) this).\u0001 == null)
      return;
    ShapeUpdateArg Data2_1 = (ShapeUpdateArg) new hmiUICommands(((F_ShapeEdit) this).parShape);
    ((buClipperBase) ((F_ShapeEdit) this).selectedShape).planeName = ((F_ShapeEdit) this).parShape.selectedPlane;
    ((buClipper) ((F_ShapeEdit) this).selectedShape).planeOperation = buCall.\u0001.PlaneNameToPlane(((F_ShapeEdit) this).parShape.selectedPlane);
    ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Corner = ((F_ShapeEdit) this).parShape.selectedCorner;
    ((buClipperBase) ((F_ShapeEdit) this).selectedShape).Alignment = ((F_ShapeEdit) this).parShape.objectAlignment;
    // ISSUE: reference to a compiler-generated field
    ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2_1);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_ShapeEdit) this).PropertiesForm.Inited)
      return;
    if (control.Name == ((F_DrillList) this).\u0001.Name && ((F_ShapeEdit) this).selectedShape is buShapeProfiling)
    {
      buShapeProfiling selectedShape = ((F_ShapeEdit) this).selectedShape as buShapeProfiling;
      ((buClipperBase) selectedShape).isPocket = ((F_DrillList) this).\u0001.Checked;
      ((F_ShapeEdit) this).parShape.isProfilingPocket = ((buClipperBase) selectedShape).isPocket;
      this.ShapeToDataGrid(((F_ShapeEdit) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_ShapeEdit) this).\u0001 != null)
      {
        ShapeUpdateArg Data2 = (ShapeUpdateArg) new hmiUICommands();
        ((ShapeRuntimeData) Data2).Parameters = (ShapeRuntimeData) new hmiUICommands(((F_ShapeEdit) this).parShape);
        // ISSUE: reference to a compiler-generated field
        ((F_ShapeEdit) this).\u0001((object) ((F_ShapeEdit) this).selectedShape, (object) Data2);
      }
    }
    ((F_ShapeEdit) this).PropertiesForm.Inited = false;
    this.Apply();
    ((F_ShapeEdit) this).PropertiesForm.Inited = true;
    \u001F.\u0001.\u0001((EventArgs) null, obj0, (F_ProfilingList) this);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ShapeEdit) this).PropertiesForm.Inited || !((F_ShapeEdit) this).ShowTool || !(((F_DrillList) this).cmb_tools.SelectedIndex >= 0 & ((F_DrillList) this).cmb_tools.SelectedIndex <= ((F_ShapeEdit) this).Tools.Count - 1))
      return;
    ((F_ShapeEdit) this).activeTool = (ToolBase5) new ToolGeometry5(((F_ShapeEdit) this).Tools[((F_DrillList) this).cmb_tools.SelectedIndex]);
  }

  public event OkCommandWithTwoDataEventHandler MoveCommad;

  public event CancelCommandEventHandler CancelCommad;
}
