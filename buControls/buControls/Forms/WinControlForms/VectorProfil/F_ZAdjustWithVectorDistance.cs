// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.VectorProfil.F_ZAdjustWithVectorDistance
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.VectorProfil;

public class F_ZAdjustWithVectorDistance : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  public DialogResult Result = DialogResult.None;
  public ZHeightAdjustmentByDistance ZHeightData = new ZHeightAdjustmentByDistance();
  public Pnt3D LevelPoint = new Pnt3D();
  public List<Pnt3D> RefPoints = new List<Pnt3D>();
  public List<Pnt3D> CalcPoints = new List<Pnt3D>();
  public bool DrawSpline = false;
  public entityBSplineType SplineType = entityBSplineType.BSplineQuadratic;
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal Panel panel_0;
  internal Label label_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_1;
  internal Panel panel_1;
  internal Label label_2;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal buViewer buViewer_0;
  internal Label label_3;
  public Button btn_apply;
  public NumericUpDown spn_levelcenter;
  public NumericUpDown spn_height;
  internal Label label_4;
  public NumericUpDown spn_levelmin;
  internal Label label_5;
  public NumericUpDown spn_levelmax;
  internal RadioButton radioButton_4;

  public F_ZAdjustWithVectorDistance() => Class39.smethod_702(this);

  public event OkCommandEventHandler OkCommand;

  public event CancelCommandEventHandler CancelCommand;

  public event ApplyCommandEventHandler ApplyCommand;

  public void Init()
  {
    this.spn_levelcenter.Value = (Decimal) this.ZHeightData.LevelCenter;
    this.spn_levelmin.Value = (Decimal) this.ZHeightData.LevelMin;
    this.spn_levelmax.Value = (Decimal) this.ZHeightData.LevelMax;
    this.spn_height.Value = (Decimal) this.ZHeightData.ZHeightValue;
    if (this.ZHeightData.ZType == ZHeightProfileType.Linear)
    {
      this.radioButton_0.Checked = true;
      this.radioButton_1.Checked = false;
      this.radioButton_4.Checked = false;
    }
    if (this.ZHeightData.ZType == ZHeightProfileType.Circular)
    {
      this.radioButton_0.Checked = false;
      this.radioButton_1.Checked = true;
      this.radioButton_4.Checked = false;
    }
    if (this.ZHeightData.ZType == ZHeightProfileType.Constant)
    {
      this.radioButton_0.Checked = false;
      this.radioButton_1.Checked = false;
      this.radioButton_4.Checked = true;
    }
    if (this.ZHeightData.Direction == VectorXYType.XVector)
    {
      this.radioButton_2.Checked = true;
      this.radioButton_3.Checked = false;
    }
    if (this.ZHeightData.Direction == VectorXYType.YVector)
    {
      this.radioButton_2.Checked = false;
      this.radioButton_3.Checked = true;
    }
    Class39.smethod_234(this, this.RefPoints, this.RefPoints);
    this.bool_0 = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (!this.bool_0 || this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Apply();
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandEventHandler_0();
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_3(object sender, EventArgs e) => this.Apply();

  public void Apply()
  {
    this.ZHeightData.LevelCenter = (double) this.spn_levelcenter.Value;
    this.ZHeightData.LevelMin = (double) this.spn_levelmin.Value;
    this.ZHeightData.LevelMax = (double) this.spn_levelmax.Value;
    this.ZHeightData.ZHeightValue = (double) this.spn_height.Value;
    if (this.radioButton_0.Checked)
      this.ZHeightData.ZType = ZHeightProfileType.Linear;
    if (this.radioButton_1.Checked)
      this.ZHeightData.ZType = ZHeightProfileType.Circular;
    if (this.radioButton_4.Checked)
      this.ZHeightData.ZType = ZHeightProfileType.Constant;
    if (this.radioButton_2.Checked)
      this.ZHeightData.Direction = VectorXYType.XVector;
    if (this.radioButton_3.Checked)
      this.ZHeightData.Direction = VectorXYType.YVector;
    this.CalcPoints = new List<Pnt3D>();
    List<Pnt3D> SortedOriginalPoints = new List<Pnt3D>();
    buControlCoreClass.cVector.ProfileZHeightFromDistance(this.ZHeightData, this.LevelPoint, this.RefPoints, ref SortedOriginalPoints, ref this.CalcPoints);
    Class39.smethod_234(this, SortedOriginalPoints, this.CalcPoints);
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandEventHandler_0();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
