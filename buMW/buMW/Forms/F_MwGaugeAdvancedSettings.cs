// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwGaugeAdvancedSettings
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

public class F_MwGaugeAdvancedSettings : Form
{
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  internal Panel \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal System.Windows.Forms.Label \u0002;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0003;
  internal CheckBox \u0004;
  internal CheckBox \u0005;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Tag == null)
      return;
    ((F_MwTriMHeights) this).\u0001.Image = ((F_MwTriMHeights) this).\u0002.Images[Convert.ToInt32(control2.Tag)];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMHeights) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMHeights) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwGaugeAdvancedSettings() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0003.Checked = this.Par.CollControl.TrimContourForSafeRetractFlg;
    this.\u0002.Checked = this.Par.CollControl.CheckLinksAgainstContainmentFlg;
    this.\u0001.Checked = this.Par.CollControl.CheckLinkMotionsFlg;
    ((F_MwGaugeClearanceForTool) this).\u0006.Checked = this.Par.CollControl.ExtendToolToInfinityFlg;
    this.\u0005.Checked = this.Par.CollControl.CheckTipRadiusForContoursFlg;
    this.\u0004.Checked = this.Par.CollControl.CheckTipRadiusForLinksFlg;
    ((F_MwGaugeClearanceForTool) this).\u0007.Checked = this.Par.CollControl.CheckBetweenPts;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.LinksCheckContainmentType == TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.Lct2dContainmentGeo)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
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
    this.\u0003.Enabled = this.\u0001.Checked;
    this.\u0002.Enabled = this.\u0002.Checked;
    this.\u0005.Enabled = false;
    this.\u0004.Enabled = false;
  }

  public void Apply()
  {
    this.Par.CollControl.TrimContourForSafeRetractFlg = this.\u0003.Checked;
    this.Par.CollControl.CheckLinksAgainstContainmentFlg = this.\u0002.Checked;
    this.Par.CollControl.CheckLinkMotionsFlg = this.\u0001.Checked;
    this.Par.CollControl.ExtendToolToInfinityFlg = ((F_MwGaugeClearanceForTool) this).\u0006.Checked;
    this.Par.CollControl.CheckTipRadiusForContoursFlg = this.\u0005.Checked;
    this.Par.CollControl.CheckTipRadiusForLinksFlg = this.\u0004.Checked;
    this.Par.CollControl.CheckBetweenPts = ((F_MwGaugeClearanceForTool) this).\u0007.Checked;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.LinksCheckContainmentType = TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.Lct2dContainmentGeo;
    else
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.LinksCheckContainmentType = TriangleMeshBasedTpCalcParamsLinksCheckContainmentType.LctCustomGeo;
  }
}
