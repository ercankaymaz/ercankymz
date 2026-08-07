// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_FeedAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buEyeBaseVer5;
using buMW.Forms;
using ModuleWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_FeedAdvanced : Form
{
  internal NumericUpDown \u0004;
  internal Button \u0001;
  internal CheckBox \u0003;
  public ComboBox combo_direction;
  internal System.Windows.Forms.Label \u0008;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  internal CheckBox \u0001;
  internal Panel \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMStockDef) this).UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMStockDef) this).Properties.Inited)
      return;
    ((F_MwTriMStockDef) this).Properties.Inited = false;
    ((F_MwTriMStockDef) this).Apply();
    ((F_MwTriMStockDef) this).UpdateControlFromType();
    ((F_MwTriMStockDef) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMStockDef) this).Properties.Inited)
      return;
    ((F_MwTriMStockDef) this).Properties.Inited = false;
    ((F_MwTriMStockDef) this).Apply();
    ((F_MwTriMStockDef) this).UpdateControlFromType();
    ((F_MwTriMStockDef) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMStockDef) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMStockDef) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_FeedAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.\u0003.Enabled = true;
    this.\u0002.Enabled = true;
    ((F_ExtendTrim) this).\u0004.Enabled = true;
    this.\u0001.Enabled = true;
    ((F_ExtendTrim) this).\u0006.Checked = this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinksFlg;
    ((F_ExtendTrim) this).\u0004.Checked = this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegionsFlg;
    ((F_ExtendTrim) this).\u0005.Checked = this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlicesFlg;
    ((F_ExtendTrim) this).\u0003.Value = (Decimal) this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinks;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegions;
    ((F_ExtendTrim) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlices;
    if (this.Configration.Mode == CamMode.TriangularMesh && this.Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
    {
      this.\u0003.Enabled = false;
      this.\u0002.Enabled = false;
      ((F_ExtendTrim) this).\u0004.Enabled = false;
      this.\u0001.Enabled = false;
    }
    this.ControlUpdate();
    this.\u0001.Image = (Image) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
    ((F_ExtendTrim) this).\u0003.Enabled = ((F_ExtendTrim) this).\u0006.Checked;
    this.\u0002.Enabled = ((F_ExtendTrim) this).\u0006.Enabled;
    this.\u0003.Enabled = ((F_ExtendTrim) this).\u0006.Checked;
    ((F_ExtendTrim) this).\u0002.Enabled = ((F_ExtendTrim) this).\u0005.Checked;
    this.\u0001.Enabled = ((F_ExtendTrim) this).\u0004.Checked;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.Configration.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        this.\u0001.Enabled = false;
      else if (this.Configration.CamTriMeshType == CamTriangularMeshType.Rough)
      {
        this.\u0001.Enabled = true;
      }
      else
      {
        if (this.Configration.CamTriMeshType != CamTriangularMeshType.ConstantZ)
          return;
        this.\u0001.Enabled = true;
        this.\u0002.Enabled = false;
        this.\u0003.Enabled = false;
        this.\u0001.Enabled = false;
      }
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      if (this.Configration.CamWireframeType == CamWireFrameType.Pocket)
      {
        this.\u0002.Enabled = false;
        this.\u0003.Enabled = false;
      }
      else
      {
        if (this.Configration.CamWireframeType != CamWireFrameType.Contour)
          return;
        this.\u0001.Enabled = false;
      }
    }
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinksFlg = ((F_ExtendTrim) this).\u0006.Checked;
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegionsFlg = ((F_ExtendTrim) this).\u0004.Checked;
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlicesFlg = ((F_ExtendTrim) this).\u0005.Checked;
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinks = (double) ((F_ExtendTrim) this).\u0003.Value;
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegions = (double) this.\u0001.Value;
    this.mwCamParameter.MachParam.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlices = (double) ((F_ExtendTrim) this).\u0002.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }
}
