// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRestFinish
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMRestFinish : Form
{
  internal Panel \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0003;
  internal Panel \u0003;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMProjectCurStd) this).Properties.Inited)
      return;
    ((F_MwTriMProjectCurStd) this).Properties.Inited = false;
    ((F_MwTriMProjectCurStd) this).Apply();
    ((F_MwTriMProjectCurStd) this).UpdateControlFromType();
    ((F_MwTriMProjectCurStd) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0002.Name)
    {
      F_MWTriMDynamicalHolderColl mdynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
      mdynamicalHolderColl.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      mdynamicalHolderColl.Init();
      int num = (int) mdynamicalHolderColl.ShowDialog();
      if (mdynamicalHolderColl.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(mdynamicalHolderColl.Par);
        mdynamicalHolderColl.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0005.Name)
    {
      F_MwTriMHeights fMwTriMheights = new F_MwTriMHeights();
      fMwTriMheights.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      fMwTriMheights.Init();
      int num = (int) fMwTriMheights.ShowDialog();
      if (fMwTriMheights.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwTriMheights.Par);
        fMwTriMheights.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0004.Name)
    {
      F_MwTriMOffset fMwTriMoffset = new F_MwTriMOffset();
      fMwTriMoffset.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      fMwTriMoffset.Init();
      int num = (int) fMwTriMoffset.ShowDialog();
      if (fMwTriMoffset.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwTriMoffset.Par);
        fMwTriMoffset.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0003.Name)
    {
      F_MwTriMRoughLink fMwTriMroughLink = new F_MwTriMRoughLink();
      fMwTriMroughLink.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      fMwTriMroughLink.Init();
      int num = (int) fMwTriMroughLink.ShowDialog();
      if (fMwTriMroughLink.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwTriMroughLink.Par);
        fMwTriMroughLink.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0006.Name)
    {
      F_MwTriMRoughing fMwTriMroughing = new F_MwTriMRoughing();
      fMwTriMroughing.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      fMwTriMroughing.Init();
      int num = (int) fMwTriMroughing.ShowDialog();
      if (fMwTriMroughing.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwTriMroughing.Par);
        fMwTriMroughing.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0001.Name)
    {
      F_MwGaugeCheck fMwGaugeCheck = new F_MwGaugeCheck();
      fMwGaugeCheck.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      fMwGaugeCheck.Init();
      int num = (int) fMwGaugeCheck.ShowDialog();
      if (fMwGaugeCheck.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwGaugeCheck.Par);
        fMwGaugeCheck.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0007.Name)
    {
      F_MwTriMAngleRange mwTriMangleRange = new F_MwTriMAngleRange();
      mwTriMangleRange.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      mwTriMangleRange.Init();
      int num = (int) mwTriMangleRange.ShowDialog();
      if (mwTriMangleRange.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(mwTriMangleRange.Par);
        mwTriMangleRange.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0011.Name)
    {
      F_MwTriMSurfaceQuality triMsurfaceQuality = new F_MwTriMSurfaceQuality();
      triMsurfaceQuality.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      triMsurfaceQuality.Init();
      int num = (int) triMsurfaceQuality.ShowDialog();
      if (triMsurfaceQuality.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(triMsurfaceQuality.Par);
        triMsurfaceQuality.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u000F.Name)
    {
      F_MwTriMSilhouette mwTriMsilhouette = new F_MwTriMSilhouette();
      mwTriMsilhouette.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      mwTriMsilhouette.Init();
      int num = (int) mwTriMsilhouette.ShowDialog();
      if (mwTriMsilhouette.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(mwTriMsilhouette.Par);
        mwTriMsilhouette.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u0008.Name)
    {
      F_MwTriMRestFinish mwTriMrestFinish = new F_MwTriMRestFinish();
      mwTriMrestFinish.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      mwTriMrestFinish.Init();
      int num = (int) mwTriMrestFinish.ShowDialog();
      if (mwTriMrestFinish.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(mwTriMrestFinish.Par);
        mwTriMrestFinish.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMProjectCurStd) this).\u000E.Name)
    {
      F_MwTriM2dContainment triM2dContainment = new F_MwTriM2dContainment();
      triM2dContainment.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
      triM2dContainment.Init();
      int num = (int) triM2dContainment.ShowDialog();
      if (triM2dContainment.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(triM2dContainment.Par);
        triM2dContainment.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwTriMProjectCurStd) this).\u0010.Name))
      return;
    F_MwTriMUtility fMwTriMutility = new F_MwTriMUtility();
    fMwTriMutility.Par = new MachiningParams(((F_MwTriMProjectCurStd) this).Par);
    fMwTriMutility.Init();
    int num1 = (int) fMwTriMutility.ShowDialog();
    if (fMwTriMutility.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMProjectCurStd) this).Par = new MachiningParams(fMwTriMutility.Par);
    fMwTriMutility.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMProjectCurStd) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMProjectCurStd) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRestFinish() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea;
    ((F_MwTriMRetract) this).\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type == MachiningAreaRestFinishingParamsType.RfBasedOnTool)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.UpdateControlFromType();
    this.\u0001.Image = (Image) null;
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
    if (this.\u0002.Checked)
    {
      this.\u0002.Enabled = true;
      this.\u0003.Enabled = false;
    }
    else
    {
      this.\u0002.Enabled = false;
      this.\u0003.Enabled = true;
    }
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea = (double) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan = (double) ((F_MwTriMRetract) this).\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia = (double) this.\u0001.Value;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnTool;
    else
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnStock;
  }
}
