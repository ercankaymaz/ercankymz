// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMStockDef
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buMW.CamForms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMStockDef : Form
{
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0011;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal CheckBox \u0007;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal Panel \u0002;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0003;
  public ComboBox combo_stocktype;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0004;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0003;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0005;
  public ComboBox combo_tool;
  internal System.Windows.Forms.Label \u0006;
  internal System.Windows.Forms.Label \u0007;

  public void Apply()
  {
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter = (double) (int) ((F_MwTriMRoughingAdvanced) this).\u0001.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFactor = (double) ((F_MwTriMRoughingAdvanced) this).\u0005.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFactor = (double) ((F_MwTriMRoughingAdvanced) this).\u0007.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinkGapSize = (double) ((F_MwTriMRoughingAdvanced) this).\u0006.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionRadius = (double) ((F_MwTriMRoughingAdvanced) this).\u0004.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing = (double) ((F_MwTriMRoughingAdvanced) this).\u0003.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinCurvatureRadiusForAdaptiveRough = (double) ((F_MwTriMRoughingAdvanced) this).\u0002.Value;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimizeLinksFlg = this.\u0007.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RemoveCornerPegsFlg = ((F_MwTriMRoughingAdvanced) this).\u0006.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg = ((F_MwTriMRoughingAdvanced) this).\u0002.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FinalContourPassFlg = ((F_MwTriMRoughingAdvanced) this).\u0001.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = ((F_MwTriMRoughingAdvanced) this).\u0003.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = ((F_MwTriMRoughingAdvanced) this).\u0004.Checked;
    ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = ((F_MwTriMRoughingAdvanced) this).\u0005.Checked;
    if (((F_MwTriMRoughingAdvanced) this).combo_filterby.SelectedIndex == 0)
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions;
    else if (((F_MwTriMRoughingAdvanced) this).combo_filterby.SelectedIndex == 1)
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours;
    if (((F_MwTriMRoughingAdvanced) this).combo_type.SelectedIndex == 0)
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle;
    else if (((F_MwTriMRoughingAdvanced) this).combo_type.SelectedIndex == 1)
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength;
    if (((F_MwTriMRoughingAdvanced) this).\u0002.Checked)
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices;
    else
      ((F_MwTriMRoughingAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRoughingAdvanced) this).Properties.Inited)
      return;
    ((F_MwTriMRoughingAdvanced) this).Properties.Inited = false;
    this.Apply();
    ((F_MwTriMRoughingAdvanced) this).UpdateControlFromType();
    ((F_MwTriMRoughingAdvanced) this).Properties.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRoughingAdvanced) this).Properties.Inited)
      return;
    ((F_MwTriMRoughingAdvanced) this).Properties.Inited = false;
    this.Apply();
    ((F_MwTriMRoughingAdvanced) this).UpdateControlFromType();
    ((F_MwTriMRoughingAdvanced) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRoughingAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRoughingAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMStockDef() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (!buMWCalcs.AdvancedTriMesh)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg = false;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg;
    ((F_FeedAdvanced) this).\u0004.Value = (Decimal) this.Par.CollCtrlOpStockParams.StockAreaLimitOffset;
    this.\u0002.Value = (Decimal) this.Par.CollCtrlOpStockParams.StockDefTolerance;
    this.\u0001.Value = (Decimal) this.Par.CollCtrlOpStockParams.StockDefTolerance;
    if (this.Par.CollCtrlOpStockParams.StockOffsetMode == CollCtrlOpStockParamsStockOffsetMode.SomExpand)
      this.\u0001.Checked = true;
    else
      this.\u0002.Checked = true;
    if (this.Par.CollCtrlOpStockParams.StockType == CollCtrlOpStockParamsStockType.StBoundingBox)
      this.combo_stocktype.SelectedIndex = 0;
    else if (this.Par.CollCtrlOpStockParams.StockType == CollCtrlOpStockParamsStockType.StSurfaces)
      this.combo_stocktype.SelectedIndex = 1;
    else
      this.combo_stocktype.SelectedIndex = 2;
    if (this.Par.CollCtrlOpStockParams.StockAreaLimitOffsetMethod == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside)
      this.combo_tool.SelectedIndex = 0;
    else if (this.Par.CollCtrlOpStockParams.StockAreaLimitOffsetMethod == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter)
      this.combo_tool.SelectedIndex = 1;
    else
      this.combo_tool.SelectedIndex = 2;
    if (this.Par.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInX)
      ((F_FeedAdvanced) this).combo_direction.SelectedIndex = 0;
    else if (this.Par.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInY)
      ((F_FeedAdvanced) this).combo_direction.SelectedIndex = 1;
    else if (this.Par.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInZ)
      ((F_FeedAdvanced) this).combo_direction.SelectedIndex = 2;
    else if (this.Par.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined)
      ((F_FeedAdvanced) this).combo_direction.SelectedIndex = 3;
    else
      ((F_FeedAdvanced) this).combo_direction.SelectedIndex = 4;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    ((F_FeedAdvanced) this).\u0001.Enabled = ((F_FeedAdvanced) this).\u0003.Checked;
    this.\u0007.Enabled = ((F_FeedAdvanced) this).\u0003.Checked;
    ((F_FeedAdvanced) this).\u0004.Enabled = ((F_FeedAdvanced) this).\u0003.Checked;
    this.\u0006.Enabled = ((F_FeedAdvanced) this).\u0003.Checked;
    this.combo_tool.Enabled = ((F_FeedAdvanced) this).\u0003.Checked;
    if (this.\u0001.Checked)
    {
      this.\u0001.Enabled = true;
      this.\u0002.Enabled = false;
    }
    else
    {
      this.\u0001.Enabled = false;
      this.\u0002.Enabled = true;
    }
    if (this.combo_stocktype.SelectedIndex == 0)
    {
      this.\u0001.Enabled = false;
      this.\u0003.Enabled = true;
    }
    if (this.combo_stocktype.SelectedIndex == 1)
    {
      this.\u0001.Enabled = true;
      this.\u0003.Enabled = true;
    }
    if (this.combo_stocktype.SelectedIndex == 2)
    {
      this.\u0001.Enabled = false;
      this.\u0003.Enabled = false;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0003.Enabled = false;
    this.\u0001.Enabled = false;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = (double) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg = this.\u0001.Checked;
    this.Par.CollCtrlOpStockParams.StockAreaLimitOffset = (double) ((F_FeedAdvanced) this).\u0004.Value;
    this.Par.CollCtrlOpStockParams.StockDefTolerance = (double) this.\u0002.Value;
    this.Par.CollCtrlOpStockParams.StockDefTolerance = (double) this.\u0001.Value;
    if (this.combo_stocktype.SelectedIndex == 0)
      this.Par.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
    else if (this.combo_stocktype.SelectedIndex == 1)
      this.Par.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
    else if (this.combo_stocktype.SelectedIndex == 2)
      this.Par.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.St2dContainment;
    if (this.combo_tool.SelectedIndex == 0)
      this.Par.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside;
    else if (this.combo_tool.SelectedIndex == 1)
      this.Par.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter;
    else if (this.combo_tool.SelectedIndex == 2)
      this.Par.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolOutside;
    if (((F_FeedAdvanced) this).combo_direction.SelectedIndex == 0)
      this.Par.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInX;
    else if (((F_FeedAdvanced) this).combo_direction.SelectedIndex == 1)
      this.Par.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInY;
    else if (((F_FeedAdvanced) this).combo_direction.SelectedIndex == 2)
      this.Par.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInZ;
    else if (((F_FeedAdvanced) this).combo_direction.SelectedIndex == 3)
      this.Par.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined;
    else if (((F_FeedAdvanced) this).combo_direction.SelectedIndex == 4)
      this.Par.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionMachiningDirection;
    if (this.\u0001.Checked)
      this.Par.CollCtrlOpStockParams.StockOffsetMode = CollCtrlOpStockParamsStockOffsetMode.SomExpand;
    else
      this.Par.CollCtrlOpStockParams.StockOffsetMode = CollCtrlOpStockParamsStockOffsetMode.SomShrink;
  }
}
