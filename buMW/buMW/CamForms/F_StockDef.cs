// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_StockDef
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_StockDef : Form
{
  internal CheckBox \u0005;
  public Button btn_transformrotate;
  public CheckBox chk_transformrotate;
  public Button btn_mirror;
  public CheckBox chk_mirror;
  internal CheckBox \u0006;
  internal Button \u0004;
  internal Button \u0005;
  internal ListBox \u0001;
  public static byte f000E91;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
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
  internal System.Windows.Forms.Label \u0004;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0005;
  public ComboBox combo_tool;
  internal System.Windows.Forms.Label \u0006;
  internal System.Windows.Forms.Label \u0007;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_Roughing) this).PropertiesForm.Inited)
      return;
    ((F_Roughing) this).ControlUpdate();
    if (control2.Name == ((F_Roughing) this).\u0002.Name)
    {
      if (((F_Roughing) this).\u0002.Checked)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.AllowToolOutsideStockOnRough;
      else
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.AllowToolOutsideStockOffRough;
    }
    else if (control2.Name == ((F_Roughing) this).\u0004.Name)
      ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.HelicalRampTypeLengthRough;
    else if (control2.Name == ((F_Roughing) this).\u0003.Name)
      ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.CenterCuttingToolRough;
    else if (control2.Name == this.\u0005.Name)
      ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.DrillPositionsRough;
    else if (control2.Name == this.chk_transformrotate.Name)
      ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.TransformRotateRough;
    else if (control2.Name == this.chk_mirror.Name)
      ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.MirrorRough;
    ((F_Roughing) this).PropertiesForm.Inited = false;
    ((F_Roughing) this).Apply();
    ((F_Roughing) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_Roughing) this).PropertiesForm.Inited)
      return;
    ((F_Roughing) this).ControlUpdate();
    if (control2.Name == ((F_Roughing) this).cmb_ramptype.Name)
    {
      if (((F_Roughing) this).cmb_ramptype.SelectedIndex == 0)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.AutomaticRampTypeRough;
      else if (((F_Roughing) this).cmb_ramptype.SelectedIndex == 1)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.HelicalRampTypeRough;
      else if (((F_Roughing) this).cmb_ramptype.SelectedIndex == 2)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.ZigzagRampTypeRough;
      else if (((F_Roughing) this).cmb_ramptype.SelectedIndex == 3)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.LineRampTypeRough;
      else if (((F_Roughing) this).cmb_ramptype.SelectedIndex == 4)
        ((F_Roughing) this).\u0001.Image = (Image) ResourceImage.ProfileRampTypeRough;
    }
    ((F_Roughing) this).PropertiesForm.Inited = false;
    ((F_Roughing) this).Apply();
    ((F_Roughing) this).PropertiesForm.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Roughing) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Roughing) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_StockDef() => F_Roughing.Captions = new List<string>();

  public F_StockDef() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (!this.Configration.isTriangularMeshAdvanced)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg = false;
    ((MemberRefsProxy) this).\u0005.Value = (Decimal) this.buCamParameter.Options.StockHeight;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance;
    ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg;
    // ISSUE: reference to a compiler-generated field
    ((\u0008.\u0001) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffset;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDefTolerance;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDefTolerance;
    if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockOffsetMode == CollCtrlOpStockParamsStockOffsetMode.SomExpand)
      this.\u0001.Checked = true;
    else
      this.\u0002.Checked = true;
    if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockType == CollCtrlOpStockParamsStockType.StBoundingBox)
      this.combo_stocktype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockType == CollCtrlOpStockParamsStockType.StSurfaces)
      this.combo_stocktype.SelectedIndex = 1;
    else
      this.combo_stocktype.SelectedIndex = 2;
    if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffsetMethod == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside)
      this.combo_tool.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffsetMethod == CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter)
      this.combo_tool.SelectedIndex = 1;
    else
      this.combo_tool.SelectedIndex = 2;
    if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInX)
      ((\u0006.\u0001) this).combo_direction.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInY)
      ((\u0006.\u0001) this).combo_direction.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionInZ)
      ((\u0006.\u0001) this).combo_direction.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection == CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined)
      ((\u0006.\u0001) this).combo_direction.SelectedIndex = 3;
    else
      ((\u0006.\u0001) this).combo_direction.SelectedIndex = 4;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    ((\u0006.\u0001) this).\u0001.Enabled = ((\u0006.\u0001) this).\u0002.Checked;
    this.\u0007.Enabled = ((\u0006.\u0001) this).\u0002.Checked;
    // ISSUE: reference to a compiler-generated field
    ((\u0008.\u0001) this).\u0004.Enabled = ((\u0006.\u0001) this).\u0002.Checked;
    this.\u0006.Enabled = ((\u0006.\u0001) this).\u0002.Checked;
    this.combo_tool.Enabled = ((\u0006.\u0001) this).\u0002.Checked;
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
    ((MemberRefsProxy) this).\u0005.Enabled = false;
    ((MemberRefsProxy) this).\u000E.Enabled = false;
    if (this.combo_stocktype.SelectedIndex == 0)
    {
      ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Enabled = false;
      ((\u0006.\u0001.\u0001) this).pnl_area.Enabled = true;
    }
    if (this.combo_stocktype.SelectedIndex == 1)
    {
      ((MemberRefsProxy) this).\u0005.Enabled = true;
      ((MemberRefsProxy) this).\u000E.Enabled = true;
      ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Enabled = true;
      ((\u0006.\u0001.\u0001) this).pnl_area.Enabled = true;
    }
    if (this.combo_stocktype.SelectedIndex == 2)
    {
      ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Enabled = false;
      ((\u0006.\u0001.\u0001) this).pnl_area.Enabled = false;
    }
    if (this.Configration.isTriangularMeshAdvanced)
      return;
    ((\u0006.\u0001.\u0001) this).pnl_area.Enabled = false;
    ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Enabled = false;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = (double) this.\u0003.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockHasUndercutsFlg = ((\u0006.\u0001.\u0001) this).chk_stovkhasundercut.Checked;
    // ISSUE: reference to a compiler-generated field
    this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffset = (double) ((\u0008.\u0001) this).\u0004.Value;
    this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDefTolerance = (double) this.\u0002.Value;
    this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDefTolerance = (double) this.\u0001.Value;
    this.buCamParameter.Options.StockHeight = (double) ((MemberRefsProxy) this).\u0005.Value;
    if (this.combo_stocktype.SelectedIndex == 0)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
    else if (this.combo_stocktype.SelectedIndex == 1)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
    else if (this.combo_stocktype.SelectedIndex == 2)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.St2dContainment;
    if (this.combo_tool.SelectedIndex == 0)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolInside;
    else if (this.combo_tool.SelectedIndex == 1)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolCenter;
    else if (this.combo_tool.SelectedIndex == 2)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockAreaLimitOffsetMethod = CollCtrlOpStockParamsStockAreaLimitOffsetMethod.SalOffsetToolOutside;
    if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 0)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInX;
    else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 1)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInY;
    else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 2)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionInZ;
    else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 3)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionCustomDefined;
    else if (((\u0006.\u0001) this).combo_direction.SelectedIndex == 4)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockDirection = CollCtrlOpStockParamsStockDirection.StDirectionMachiningDirection;
    if (this.\u0001.Checked)
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockOffsetMode = CollCtrlOpStockParamsStockOffsetMode.SomExpand;
    else
      this.mwCamParameter.MachParam.CollCtrlOpStockParams.StockOffsetMode = CollCtrlOpStockParamsStockOffsetMode.SomShrink;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
  }
}
