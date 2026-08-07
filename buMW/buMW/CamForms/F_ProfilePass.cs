// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_ProfilePass
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_ProfilePass : Form
{
  public ComboBox cmb_filteringtype;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0002;
  public ComboBox cmb_filteringfilterby;
  internal System.Windows.Forms.Label \u0005;
  public static byte f0007D3;
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
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0004;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_Filtering) this).PropertiesForm.Inited)
      return;
    if (((F_Filtering) this).PropertiesForm.Inited)
    {
      if (control2.Name == this.cmb_filteringfilterby.Name)
      {
        if (this.cmb_filteringfilterby.SelectedIndex == 0)
          ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilterByRegionsRough;
        else if (this.cmb_filteringfilterby.SelectedIndex == 1)
          ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilterByContoursRough;
      }
      if (control2.Name == this.cmb_filteringtype.Name)
      {
        if (this.cmb_filteringtype.SelectedIndex == 0)
          ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.InscribedCircleRough;
        else if (this.cmb_filteringtype.SelectedIndex == 1)
          ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.DiagonalLengthRough;
        else if (this.cmb_filteringtype.SelectedIndex == 2)
          ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.CircumscribedCircle;
      }
    }
    ((F_Filtering) this).PropertiesForm.Inited = false;
    ((F_Filtering) this).Apply();
    ((F_Filtering) this).ControlUpdate();
    ((F_Filtering) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Filtering) this).\u0001.Name)
      ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilteringMinimumSegmentTriMeshRough;
    else if (control2.Name == this.\u0002.Name)
      ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilteringThresholdValueTriMeshRough;
    else if (control2.Name == ((F_Filtering) this).\u0001.Name)
      ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilteringMinimumSegmentTriMeshRough;
    else if (control2.Name == this.\u0002.Name)
      ((F_Filtering) this).\u0001.Image = (Image) ResourceImage.FilteringThresholdValueTriMeshRough;
    ((F_Filtering) this).\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Filtering) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Filtering) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfilePass() => F_Filtering.Captions = new List<string>();

  public F_ProfilePass() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      ((F_RestRough) this).\u0002.Visible = true;
      ((F_RestRough) this).\u0001.Visible = true;
      ((F_RestRough) this).\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing;
      this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.SweepAngle;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.DiameterInPercOfToolDiameter;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.ExtensionLength;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationRadius;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices)
        ((F_RestRough) this).\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice)
        ((F_RestRough) this).\u0001.Checked = true;
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Clear();
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[0]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[1]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[2]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[3]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[4]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInComputer)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 0;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInControl)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 1;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtWear)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 2;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInverseWear)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 3;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 4;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      ((F_RestRough) this).\u0002.Visible = false;
      ((F_RestRough) this).\u0001.Visible = false;
      this.\u0003.Visible = false;
      this.\u0004.Visible = false;
      this.\u0004.Visible = false;
      ((F_RestRough) this).\u0005.Visible = false;
      this.\u0002.Visible = false;
      this.\u0003.Visible = false;
      ((F_RestRough) this).\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Spacing;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationRadius;
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Clear();
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[0]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[1]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[2]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[3]);
      ((F_RestRough) this).cmb_profilepassofsettype.Items.Add((object) buMWCaptions.CutterRadiusCompParamsCompensationType[4]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInComputer)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 0;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInControl)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 1;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtWear)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 2;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtInverseWear)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 3;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
        ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex = 4;
    }
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    this.\u0001.Enabled = false;
    this.\u0002.Enabled = false;
    if (!(((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 1 | ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 2 | ((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 3))
      return;
    this.\u0001.Enabled = true;
    this.\u0002.Enabled = true;
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing = (double) ((F_RestRough) this).\u0005.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.SweepAngle = (double) this.\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.DiameterInPercOfToolDiameter = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassLeadsParams.ExtensionLength = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationRadius = (double) this.\u0001.Value;
      if (((F_RestRough) this).\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices;
      else if (((F_RestRough) this).\u0001.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice;
      if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 0)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 1)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInControl;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 2)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtWear;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 3)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInverseWear;
      }
      else
      {
        if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex != 4)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
      }
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.Spacing = (double) ((F_RestRough) this).\u0005.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationRadius = (double) this.\u0001.Value;
      if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 0)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInComputer;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 1)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInControl;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 2)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtWear;
      else if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex == 3)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtInverseWear;
      }
      else
      {
        if (((F_RestRough) this).cmb_profilepassofsettype.SelectedIndex != 4)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ProfilePassCutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
      }
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
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

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }
}
