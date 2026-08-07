// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRoughingAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMRoughingAdvanced : Form
{
  internal CheckBox \u0005;
  internal Button \u0005;
  internal CheckBox \u0006;
  internal Button \u0006;
  internal CheckBox \u0007;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  public ComboBox combo_type;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0004;
  public ComboBox combo_filterby;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0002;
  internal Panel \u0003;
  internal Panel \u0004;
  internal NumericUpDown \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0004;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0005;
  internal CheckBox \u0003;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0006;
  internal CheckBox \u0004;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u0007;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0010;
  internal CheckBox \u0006;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRoughing) this).Properties.Inited)
      return;
    ((F_MwTriMRoughing) this).Properties.Inited = false;
    ((F_MwTriMRoughing) this).Apply();
    ((F_MwTriMRoughing) this).UpdateControlFromType();
    ((F_MwTriMRoughing) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRoughing) this).Properties.Inited)
      return;
    ((F_MwTriMRoughing) this).Properties.Inited = false;
    ((F_MwTriMRoughing) this).Apply();
    ((F_MwTriMRoughing) this).UpdateControlFromType();
    ((F_MwTriMRoughing) this).Properties.Inited = true;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwTriMRoughing) this).\u0001.Name)
    {
      F_MwTriMStockDef fMwTriMstockDef = new F_MwTriMStockDef();
      fMwTriMstockDef.Par = new MachiningParams(((F_MwTriMRoughing) this).Par);
      fMwTriMstockDef.Init();
      int num = (int) fMwTriMstockDef.ShowDialog();
      if (fMwTriMstockDef.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMRoughing) this).Par = new MachiningParams(fMwTriMstockDef.Par);
        fMwTriMstockDef.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMRoughing) this).\u0002.Name)
    {
      F_MwTriMRoughingAdvanced mroughingAdvanced = new F_MwTriMRoughingAdvanced();
      mroughingAdvanced.Par = new MachiningParams(((F_MwTriMRoughing) this).Par);
      mroughingAdvanced.Init();
      int num = (int) mroughingAdvanced.ShowDialog();
      if (mroughingAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMRoughing) this).Par = new MachiningParams(mroughingAdvanced.Par);
        mroughingAdvanced.Dispose();
      }
    }
    if (control2.Name == this.\u0005.Name)
    {
      F_MwTriMRotate fMwTriMrotate = new F_MwTriMRotate();
      fMwTriMrotate.Par = new MachiningParams(((F_MwTriMRoughing) this).Par);
      fMwTriMrotate.Init();
      int num = (int) fMwTriMrotate.ShowDialog();
      if (fMwTriMrotate.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMRoughing) this).Par = new MachiningParams(fMwTriMrotate.Par);
        fMwTriMrotate.Dispose();
      }
    }
    if (!(control2.Name == this.\u0006.Name))
      return;
    F_MwTriMMirror fMwTriMmirror = new F_MwTriMMirror();
    fMwTriMmirror.Par = new MachiningParams(((F_MwTriMRoughing) this).Par);
    fMwTriMmirror.Init();
    int num1 = (int) fMwTriMmirror.ShowDialog();
    if (fMwTriMmirror.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMRoughing) this).Par = new MachiningParams(fMwTriMmirror.Par);
    fMwTriMmirror.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRoughing) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRoughing) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRoughingAdvanced() => \u0005.\u0002.\u0001(this);

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
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
    }
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFactor;
    this.\u0007.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFactor;
    this.\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinkGapSize;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionRadius;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinCurvatureRadiusForAdaptiveRough;
    ((F_MwTriMStockDef) this).\u0007.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimizeLinksFlg;
    this.\u0006.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RemoveCornerPegsFlg;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FinalContourPassFlg;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg;
    this.\u0004.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
      this.combo_filterby.SelectedIndex = 0;
    else
      this.combo_filterby.SelectedIndex = 1;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
      this.combo_type.SelectedIndex = 0;
    else
      this.combo_type.SelectedIndex = 1;
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
    ((F_MwTriMStockDef) this).Apply();
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
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
    {
      this.\u0005.Enabled = true;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = true;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0008.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      ((F_MwTriMStockDef) this).\u0007.Enabled = true;
      this.\u0006.Enabled = true;
      this.\u0002.Enabled = false;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0003.Enabled = false;
      ((F_MwTriMStockDef) this).\u0005.Enabled = false;
      this.combo_filterby.Enabled = true;
      this.\u0005.Enabled = true;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
      if (!buMWCalcs.AdvancedTriMesh)
      {
        this.\u0002.Enabled = false;
        this.\u0005.Enabled = false;
        this.\u0003.Enabled = false;
        this.\u0004.Enabled = false;
      }
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
    {
      this.\u0005.Enabled = false;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = false;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = true;
      this.\u0008.Enabled = this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0003.Checked;
      ((F_MwTriMStockDef) this).\u0007.Enabled = false;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = true;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0003.Enabled = true;
      ((F_MwTriMStockDef) this).\u0005.Enabled = false;
      this.combo_filterby.Enabled = false;
      this.\u0005.Enabled = false;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
      this.\u0002.Enabled = this.\u0001.Checked;
      this.\u0001.Enabled = this.\u0001.Checked;
      this.\u0003.Enabled = this.\u0001.Checked;
      if (!buMWCalcs.AdvancedTriMesh)
      {
        this.\u0002.Enabled = false;
        this.\u0005.Enabled = false;
        this.\u0003.Enabled = false;
        this.\u0004.Enabled = false;
      }
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
    {
      this.\u0005.Enabled = false;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = false;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = false;
      this.\u0008.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      ((F_MwTriMStockDef) this).\u0007.Enabled = false;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = true;
      this.\u0002.Enabled = true;
      this.\u0003.Enabled = false;
      ((F_MwTriMStockDef) this).\u0005.Enabled = true;
      this.combo_filterby.Enabled = false;
      this.\u0005.Enabled = false;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern != TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
      return;
    ((F_MwTriMStockDef) this).\u0005.Enabled = false;
    this.\u0002.Enabled = false;
    this.\u0006.Enabled = false;
    this.\u0001.Enabled = true;
    this.combo_filterby.Enabled = false;
    this.\u0005.Enabled = false;
    this.combo_type.Enabled = false;
    this.\u0002.Enabled = false;
  }
}
