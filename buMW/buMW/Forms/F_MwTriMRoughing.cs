// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRoughing
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

public class F_MwTriMRoughing : Form
{
  internal Button \u0015;
  internal System.Windows.Forms.Label \u0018;
  internal CheckBox \u0010;
  internal CheckBox \u0011;
  internal CheckBox \u0012;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal CheckBox \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0001;
  public ComboBox combo_ramptype;
  internal System.Windows.Forms.Label \u0004;
  internal Button \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0002;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0003;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal NumericUpDown \u0004;
  internal Panel \u0002;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Button \u0004;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMConstantCusp) this).Properties.Inited)
      return;
    ((F_MwTriMConstantCusp) this).Properties.Inited = false;
    ((F_MwTriMConstantCusp) this).Apply();
    ((F_MwTriMConstantCusp) this).UpdateControlFromType();
    ((F_MwTriMConstantCusp) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMConstantCusp) this).Properties.Inited)
      return;
    ((F_MwTriMConstantCusp) this).Properties.Inited = false;
    ((F_MwTriMConstantCusp) this).Apply();
    ((F_MwTriMConstantCusp) this).UpdateControlFromType();
    ((F_MwTriMConstantCusp) this).Properties.Inited = true;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0002.Name)
    {
      F_MWTriMDynamicalHolderColl mdynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
      mdynamicalHolderColl.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      mdynamicalHolderColl.Init();
      int num = (int) mdynamicalHolderColl.ShowDialog();
      if (mdynamicalHolderColl.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(mdynamicalHolderColl.Par);
        mdynamicalHolderColl.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0004.Name)
    {
      F_MwTriMHeights fMwTriMheights = new F_MwTriMHeights();
      fMwTriMheights.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      fMwTriMheights.Init();
      int num = (int) fMwTriMheights.ShowDialog();
      if (fMwTriMheights.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwTriMheights.Par);
        fMwTriMheights.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0005.Name)
    {
      F_MwTriMOffset fMwTriMoffset = new F_MwTriMOffset();
      fMwTriMoffset.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      fMwTriMoffset.Init();
      int num = (int) fMwTriMoffset.ShowDialog();
      if (fMwTriMoffset.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwTriMoffset.Par);
        fMwTriMoffset.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0014.Name)
    {
      F_MwTriMRoughLink fMwTriMroughLink = new F_MwTriMRoughLink();
      fMwTriMroughLink.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      fMwTriMroughLink.Init();
      int num = (int) fMwTriMroughLink.ShowDialog();
      if (fMwTriMroughLink.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwTriMroughLink.Par);
        fMwTriMroughLink.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0003.Name)
    {
      F_MwTriMRoughing fMwTriMroughing = new F_MwTriMRoughing();
      fMwTriMroughing.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      fMwTriMroughing.Init();
      int num = (int) fMwTriMroughing.ShowDialog();
      if (fMwTriMroughing.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwTriMroughing.Par);
        fMwTriMroughing.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0012.Name)
    {
      F_MwGaugeCheck fMwGaugeCheck = new F_MwGaugeCheck();
      fMwGaugeCheck.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      fMwGaugeCheck.Init();
      int num = (int) fMwGaugeCheck.ShowDialog();
      if (fMwGaugeCheck.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwGaugeCheck.Par);
        fMwGaugeCheck.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0006.Name)
    {
      F_MwTriMAngleRange mwTriMangleRange = new F_MwTriMAngleRange();
      mwTriMangleRange.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      mwTriMangleRange.Init();
      int num = (int) mwTriMangleRange.ShowDialog();
      if (mwTriMangleRange.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(mwTriMangleRange.Par);
        mwTriMangleRange.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0013.Name)
    {
      F_MwTriMSurfaceQuality triMsurfaceQuality = new F_MwTriMSurfaceQuality();
      triMsurfaceQuality.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      triMsurfaceQuality.Init();
      int num = (int) triMsurfaceQuality.ShowDialog();
      if (triMsurfaceQuality.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(triMsurfaceQuality.Par);
        triMsurfaceQuality.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0010.Name)
    {
      F_MwTriMSilhouette mwTriMsilhouette = new F_MwTriMSilhouette();
      mwTriMsilhouette.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      mwTriMsilhouette.Init();
      int num = (int) mwTriMsilhouette.ShowDialog();
      if (mwTriMsilhouette.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(mwTriMsilhouette.Par);
        mwTriMsilhouette.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u0008.Name)
    {
      F_MwTriMRoundCorner mwTriMroundCorner = new F_MwTriMRoundCorner();
      mwTriMroundCorner.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      mwTriMroundCorner.Init();
      int num = (int) mwTriMroundCorner.ShowDialog();
      if (mwTriMroundCorner.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(mwTriMroundCorner.Par);
        mwTriMroundCorner.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u000E.Name)
    {
      F_MwTriMRestFinish mwTriMrestFinish = new F_MwTriMRestFinish();
      mwTriMrestFinish.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      mwTriMrestFinish.Init();
      int num = (int) mwTriMrestFinish.ShowDialog();
      if (mwTriMrestFinish.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(mwTriMrestFinish.Par);
        mwTriMrestFinish.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantCusp) this).\u000F.Name)
    {
      F_MwTriM2dContainment triM2dContainment = new F_MwTriM2dContainment();
      triM2dContainment.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
      triM2dContainment.Init();
      int num = (int) triM2dContainment.ShowDialog();
      if (triM2dContainment.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantCusp) this).Par = new MachiningParams(triM2dContainment.Par);
        triM2dContainment.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwTriMConstantCusp) this).\u0011.Name))
      return;
    F_MwTriMUtility fMwTriMutility = new F_MwTriMUtility();
    fMwTriMutility.Par = new MachiningParams(((F_MwTriMConstantCusp) this).Par);
    fMwTriMutility.Init();
    int num1 = (int) fMwTriMutility.ShowDialog();
    if (fMwTriMutility.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMConstantCusp) this).Par = new MachiningParams(fMwTriMutility.Par);
    fMwTriMutility.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMConstantCusp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMConstantCusp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRoughing() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AllowToolOutsideStockFlg;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockClearancePercent;
    ((F_MwTriMRoughingAdvanced) this).\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DrillPositionsFlg;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CenterCuttingToolFlg;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinRampDiameterPercent;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampLengthPercent;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampPitch;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle;
    this.\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle;
    this.\u0001.Checked = this.Par.CollCtrlOpStockParams.Status;
    ((F_MwTriMRoughingAdvanced) this).\u0006.Checked = this.Par.RoughingParams.TPRotationRoughParams.IsUsedFlg;
    ((F_MwTriMRoughingAdvanced) this).\u0007.Checked = this.Par.RoughingParams.MirrorTpRoughParams.IsUsedFlg;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode == TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic)
      this.combo_ramptype.SelectedIndex = 0;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtLine)
      this.combo_ramptype.SelectedIndex = 1;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical)
      this.combo_ramptype.SelectedIndex = 2;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag)
      this.combo_ramptype.SelectedIndex = 3;
    else
      this.combo_ramptype.SelectedIndex = 4;
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
    if (this.combo_ramptype.SelectedIndex == 0)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown1 = this.\u0006;
      int num1 = this.\u0003.Checked ? 1 : 0;
      numericUpDown1.Enabled = false;
      RadioButton radioButton1 = this.\u0002;
      int num2 = this.\u0003.Checked ? 1 : 0;
      radioButton1.Enabled = false;
      NumericUpDown numericUpDown2 = this.\u0005;
      int num3 = this.\u0003.Checked ? 1 : 0;
      numericUpDown2.Enabled = false;
      RadioButton radioButton2 = this.\u0001;
      int num4 = this.\u0003.Checked ? 1 : 0;
      radioButton2.Enabled = false;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.combo_ramptype.SelectedIndex == 1)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown3 = this.\u0006;
      int num5 = this.\u0003.Checked ? 1 : 0;
      numericUpDown3.Enabled = false;
      RadioButton radioButton3 = this.\u0002;
      int num6 = this.\u0003.Checked ? 1 : 0;
      radioButton3.Enabled = false;
      NumericUpDown numericUpDown4 = this.\u0005;
      int num7 = this.\u0003.Checked ? 1 : 0;
      numericUpDown4.Enabled = false;
      RadioButton radioButton4 = this.\u0001;
      int num8 = this.\u0003.Checked ? 1 : 0;
      radioButton4.Enabled = false;
      CheckBox checkBox = this.\u0004;
      int num9 = this.\u0003.Checked ? 1 : 0;
      checkBox.Enabled = false;
      NumericUpDown numericUpDown5 = this.\u0003;
      int num10 = this.\u0003.Checked ? 1 : 0;
      numericUpDown5.Enabled = false;
      NumericUpDown numericUpDown6 = this.\u0004;
      int num11 = this.\u0003.Checked ? 1 : 0;
      numericUpDown6.Enabled = false;
      System.Windows.Forms.Label label = this.\u0006;
      int num12 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
    }
    if (this.combo_ramptype.SelectedIndex == 2)
    {
      NumericUpDown numericUpDown = this.\u0001;
      int num13 = this.\u0003.Checked ? 1 : 0;
      numericUpDown.Enabled = false;
      System.Windows.Forms.Label label = this.\u0003;
      int num14 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
      this.\u0006.Enabled = this.\u0003.Checked;
      this.\u0002.Enabled = this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0003.Checked;
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.combo_ramptype.SelectedIndex == 3)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown7 = this.\u0006;
      int num15 = this.\u0003.Checked ? 1 : 0;
      numericUpDown7.Enabled = false;
      RadioButton radioButton5 = this.\u0002;
      int num16 = this.\u0003.Checked ? 1 : 0;
      radioButton5.Enabled = false;
      NumericUpDown numericUpDown8 = this.\u0005;
      int num17 = this.\u0003.Checked ? 1 : 0;
      numericUpDown8.Enabled = false;
      RadioButton radioButton6 = this.\u0001;
      int num18 = this.\u0003.Checked ? 1 : 0;
      radioButton6.Enabled = false;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.combo_ramptype.SelectedIndex == 4)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown9 = this.\u0006;
      int num19 = this.\u0003.Checked ? 1 : 0;
      numericUpDown9.Enabled = false;
      RadioButton radioButton7 = this.\u0002;
      int num20 = this.\u0003.Checked ? 1 : 0;
      radioButton7.Enabled = false;
      NumericUpDown numericUpDown10 = this.\u0005;
      int num21 = this.\u0003.Checked ? 1 : 0;
      numericUpDown10.Enabled = false;
      RadioButton radioButton8 = this.\u0001;
      int num22 = this.\u0003.Checked ? 1 : 0;
      radioButton8.Enabled = false;
      CheckBox checkBox = this.\u0004;
      int num23 = this.\u0003.Checked ? 1 : 0;
      checkBox.Enabled = false;
      NumericUpDown numericUpDown11 = this.\u0003;
      int num24 = this.\u0003.Checked ? 1 : 0;
      numericUpDown11.Enabled = false;
      NumericUpDown numericUpDown12 = this.\u0004;
      int num25 = this.\u0003.Checked ? 1 : 0;
      numericUpDown12.Enabled = false;
      System.Windows.Forms.Label label = this.\u0006;
      int num26 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
    }
    if (this.\u0002.Checked)
    {
      this.\u0006.Enabled = this.\u0002.Enabled & this.\u0001.Enabled;
      NumericUpDown numericUpDown = this.\u0005;
      int num27 = this.\u0002.Enabled ? 1 : 0;
      int num28 = 0 & (this.\u0001.Enabled ? 1 : 0);
      numericUpDown.Enabled = num28 != 0;
    }
    else
    {
      NumericUpDown numericUpDown = this.\u0006;
      int num29 = this.\u0002.Enabled ? 1 : 0;
      int num30 = 0 & (this.\u0001.Enabled ? 1 : 0);
      numericUpDown.Enabled = num30 != 0;
      this.\u0005.Enabled = this.\u0002.Enabled & this.\u0001.Enabled;
    }
    ((F_MwTriMRoughingAdvanced) this).\u0006.Enabled = ((F_MwTriMRoughingAdvanced) this).\u0007.Checked;
    this.\u0004.Enabled = ((F_MwTriMRoughingAdvanced) this).\u0005.Checked;
    this.\u0001.Enabled = this.\u0001.Checked;
    ((F_MwTriMRoughingAdvanced) this).\u0005.Enabled = ((F_MwTriMRoughingAdvanced) this).\u0006.Checked;
    this.\u0003.Enabled = this.\u0004.Checked & this.\u0003.Checked;
    this.\u0004.Enabled = this.\u0003.Checked;
    this.combo_ramptype.Enabled = this.\u0003.Checked;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
    {
      this.\u0001.Enabled = true;
      ((F_MwTriMRoughingAdvanced) this).\u0005.Enabled = true;
      this.\u0004.Enabled = true;
      this.\u0002.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
    {
      this.\u0001.Enabled = false;
      ((F_MwTriMRoughingAdvanced) this).\u0005.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0002.Enabled = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
    {
      this.\u0001.Enabled = false;
      ((F_MwTriMRoughingAdvanced) this).\u0005.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0002.Enabled = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern != TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
      return;
    this.\u0001.Enabled = false;
    ((F_MwTriMRoughingAdvanced) this).\u0005.Enabled = false;
    this.\u0004.Enabled = false;
    this.\u0002.Enabled = true;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AllowToolOutsideStockFlg = this.\u0002.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockClearancePercent = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DrillPositionsFlg = ((F_MwTriMRoughingAdvanced) this).\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CenterCuttingToolFlg = this.\u0003.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinRampDiameterPercent = (double) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampLengthPercent = (double) this.\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampPitch = (double) this.\u0005.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle = (double) this.\u0006.Value;
    this.Par.CollCtrlOpStockParams.Status = this.\u0001.Checked;
    this.Par.RoughingParams.TPRotationRoughParams.IsUsedFlg = ((F_MwTriMRoughingAdvanced) this).\u0006.Checked;
    this.Par.RoughingParams.MirrorTpRoughParams.IsUsedFlg = ((F_MwTriMRoughingAdvanced) this).\u0007.Checked;
    if (this.combo_ramptype.SelectedIndex == 0)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic;
    else if (this.combo_ramptype.SelectedIndex == 1)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtLine;
    else if (this.combo_ramptype.SelectedIndex == 2)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical;
    else if (this.combo_ramptype.SelectedIndex == 3)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag;
    else if (this.combo_ramptype.SelectedIndex == 4)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtProfile;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode = TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle;
    else
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode = TriangleMeshBasedTpCalcParamsRampMode.TmbRmPitch;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.UpdateControlFromType();
}
