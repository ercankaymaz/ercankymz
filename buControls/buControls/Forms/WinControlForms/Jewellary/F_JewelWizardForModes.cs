// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelWizardForModes
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.CAM.CamItems;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelWizardForModes : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public JewelVar ParJewel = new JewelVar();
  public List<ToolBase> Tools = new List<ToolBase>();
  public int ToolSelectedIndex = 0;
  public bool FreeFormEnable = false;
  public bool DemoMode = false;
  public bool SpindleEnable = true;
  public bool Dia1Enable = true;
  public bool Dia2Enable = true;
  public bool EngraveEnable = true;
  public bool LaserEnable = true;
  public bool LatheEnable = true;
  public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";
  public string LangMessageFreeForm = "Fre From Mode Not Allowed";
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Panel panel_1;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Label label_0;
  internal ImageList imageList_0;
  internal Panel panel_2;
  internal Button button_6;
  internal CheckBox checkBox_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal Label label_3;
  internal Panel panel_3;
  internal Button button_7;
  internal Button button_8;
  internal CheckBox checkBox_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal Panel panel_4;
  internal ComboBox comboBox_0;
  internal Label label_5;
  internal Label label_6;
  internal CheckBox checkBox_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_7;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Button button_12;
  internal ImageList imageList_1;
  internal CheckBox checkBox_3;
  internal Label label_8;
  internal TextBox textBox_0;
  internal TextBox textBox_1;
  internal Label label_9;
  internal Button button_13;
  internal Button button_14;
  internal CheckBox checkBox_4;
  internal Button button_15;
  internal CheckBox checkBox_5;
  internal Label label_10;
  internal NumericUpDown numericUpDown_4;
  internal CheckBox checkBox_6;
  internal Label label_11;
  internal NumericUpDown numericUpDown_5;
  internal CheckBox checkBox_7;
  internal NumericUpDown numericUpDown_6;
  internal Label label_12;
  internal NumericUpDown numericUpDown_7;
  internal Label label_13;
  internal CheckBox checkBox_8;
  internal CheckBox checkBox_9;
  internal CheckBox checkBox_10;

  public event OkCommandWithDataEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public event ApplyCommandWithDataEventHandler ApplyPressed;

  public F_JewelWizardForModes() => Class39.smethod_444(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    this.button_14.BackColor = Color.Silver;
    this.button_13.BackColor = Color.Silver;
    if (this.ParJewel.JewelMode.CamOperation == jewelCamOperationType.Contour)
      this.button_14.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamOperation == jewelCamOperationType.Punch)
      this.button_13.BackColor = Color.Red;
    this.checkBox_4.Checked = this.ParJewel.JewelMode.ConvexMachiningFor3Axis;
    this.checkBox_5.Checked = this.ParJewel.JewelMode.SlideEnable;
    this.textBox_0.Text = this.ParJewel.ModeName;
    this.textBox_1.Text = this.ParJewel.ModePreparedBy;
    this.button_5.BackColor = Color.Silver;
    this.button_4.BackColor = Color.Silver;
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    this.button_3.BackColor = Color.Silver;
    this.button_2.BackColor = Color.Silver;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Spindle)
      this.button_5.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Engraving)
      this.button_4.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut1)
      this.button_1.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut2)
      this.button_0.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Lathe)
      this.button_3.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Laser)
      this.button_2.BackColor = Color.Gold;
    this.button_7.BackColor = Color.Silver;
    this.button_8.BackColor = Color.Silver;
    if (this.ParJewel.JewelTangentProp.Type == jewelTangentType.Point)
      this.button_7.BackColor = Color.Cyan;
    if (this.ParJewel.JewelTangentProp.Type == jewelTangentType.Continous)
      this.button_8.BackColor = Color.Cyan;
    this.checkBox_1.Checked = this.ParJewel.JewelTangentProp.UseContantAngle;
    this.numericUpDown_2.Value = (Decimal) this.ParJewel.JewelTangentProp.ContantAngle;
    this.checkBox_0.Checked = this.ParJewel.JewelSteppingProp.Enable;
    this.button_5.Enabled = this.SpindleEnable;
    this.button_1.Enabled = this.Dia1Enable;
    this.button_0.Enabled = this.Dia2Enable;
    this.button_4.Enabled = this.EngraveEnable;
    this.button_2.Enabled = this.LaserEnable;
    this.button_3.Enabled = this.LatheEnable;
    this.numericUpDown_7.Value = (Decimal) this.ParJewel.JewelMaterialProp.MajorDiameter;
    this.numericUpDown_6.Value = (Decimal) this.ParJewel.JewelMaterialProp.MinorDiameter;
    this.checkBox_8.Checked = false;
    if (this.ParJewel.JewelMaterialProp.ShapeType == jewelMaterialShapeType.Ellipse)
      this.checkBox_8.Checked = true;
    this.numericUpDown_1.Value = (Decimal) this.ParJewel.JewelCamProp.FeedSpeed;
    this.numericUpDown_0.Value = (Decimal) this.ParJewel.JewelCamProp.PlungeSpeed;
    this.numericUpDown_3.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
    this.checkBox_2.Checked = this.ParJewel.JewelCamProp.PolylineToSpline;
    this.checkBox_3.Checked = this.ParJewel.JewelCamProp.AngularMode;
    this.checkBox_6.Checked = this.ParJewel.JewelCamProp.FlatSheetMode;
    this.checkBox_10.Checked = this.ParJewel.JewelCamProp.SurfaceReadMode;
    this.numericUpDown_5.Value = (Decimal) this.ParJewel.JewelMode.SyncRatio;
    this.checkBox_7.Checked = this.ParJewel.JewelMode.SyncMode;
    this.checkBox_9.Checked = this.ParJewel.JewelMode.BAxisFor3Axis;
    this.numericUpDown_4.Value = (Decimal) this.ParJewel.JewelCamProp.AngluarModeBAngle;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.SortNextGRoupRules, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.ParJewel.SortNextGRoupRules), ref this.comboBox_0);
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    Class39.smethod_489(this);
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_14.BackColor = Color.Silver;
    this.button_13.BackColor = Color.Silver;
    if (control2.Name == this.button_14.Name)
    {
      this.ParJewel.JewelMode.CamOperation = jewelCamOperationType.Contour;
      this.button_14.BackColor = Color.Red;
    }
    if (!(control2.Name == this.button_13.Name))
      return;
    this.ParJewel.JewelMode.CamOperation = jewelCamOperationType.Punch;
    this.button_13.BackColor = Color.Red;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_5.BackColor = Color.Silver;
    this.button_4.BackColor = Color.Silver;
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    this.button_3.BackColor = Color.Silver;
    this.button_2.BackColor = Color.Silver;
    if (control2.Name == this.button_5.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Spindle;
      this.button_5.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_4.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Engraving;
      this.button_4.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_1.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut1;
      this.button_1.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_0.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut2;
      this.button_0.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_3.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Lathe;
      this.button_3.BackColor = Color.Gold;
    }
    if (!(control2.Name == this.button_2.Name))
      return;
    this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Laser;
    this.button_2.BackColor = Color.Gold;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_7.BackColor = Color.Silver;
    this.button_8.BackColor = Color.Silver;
    if (control2.Name == this.button_7.Name)
    {
      this.ParJewel.JewelTangentProp.Type = jewelTangentType.Point;
      this.button_7.BackColor = Color.Cyan;
    }
    if (!(control2.Name == this.button_8.Name))
      return;
    this.ParJewel.JewelTangentProp.Type = jewelTangentType.Continous;
    this.button_8.BackColor = Color.Cyan;
  }

  internal void method_4(object sender, EventArgs e)
  {
    F_CamStepAll fCamStepAll = new F_CamStepAll();
    fCamStepAll.Data = new camStep(this.ParJewel.JewelSteppingProp);
    fCamStepAll.FormCloseMode = FormCloseModeType.Dispose;
    fCamStepAll.DataEnable = new camStepEnable(false, false, false, false, true, false, false, true, true);
    fCamStepAll.Init();
    fCamStepAll.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fCamStepAll.ShowDialog((IWin32Window) this);
    if (fCamStepAll.Result != DialogResult.OK)
      return;
    this.ParJewel.JewelSteppingProp = new camStep(fCamStepAll.Data);
  }

  internal void method_5(object sender, EventArgs e)
  {
    F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
    classViewerDialog.Text = "Position";
    classViewerDialog.OkCaption = AppLanguage.CadCamDynamic[8];
    classViewerDialog.CancelCaption = AppLanguage.CadCamDynamic[9];
    classViewerDialog.Value = (object) this.ParJewel.PositionProp;
    classViewerDialog.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog.ParCaptions.AddRange((IEnumerable<string>) buGeneral.CopyLists(buJewelary.LangjewelPositioningSettings).ToArray());
    classViewerDialog.Init();
    int num = (int) classViewerDialog.ShowDialog((IWin32Window) this);
    if (classViewerDialog.Result != DialogResult.OK)
      return;
    this.ParJewel.PositionProp = new jewelPositioningSettings((jewelPositioningSettings) classViewerDialog.Value);
  }

  internal void method_6(object sender, EventArgs e)
  {
    F_AdvancedSettings advancedSettings = new F_AdvancedSettings();
    advancedSettings.FormCloseMode = FormCloseModeType.Invisible;
    advancedSettings.ParJewel = new JewelVar(this.ParJewel);
    advancedSettings.Init();
    advancedSettings.StartPosition = FormStartPosition.CenterParent;
    int num = (int) advancedSettings.ShowDialog((IWin32Window) this);
    if (advancedSettings.Result != DialogResult.OK)
      return;
    this.ParJewel = new JewelVar(advancedSettings.ParJewel);
    this.numericUpDown_3.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.SortNextGRoupRules, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.ParJewel.SortNextGRoupRules), ref this.comboBox_0);
  }

  internal void method_7(object sender, EventArgs e)
  {
    F_ProducerSettings producerSettings = new F_ProducerSettings();
    producerSettings.FormCloseMode = FormCloseModeType.Invisible;
    producerSettings.ParJewel = new JewelVar(this.ParJewel);
    producerSettings.Init();
    producerSettings.StartPosition = FormStartPosition.CenterParent;
    int num = (int) producerSettings.ShowDialog((IWin32Window) this);
    if (producerSettings.Result != DialogResult.OK)
      return;
    this.ParJewel = new JewelVar(producerSettings.ParJewel);
  }

  internal void method_8(object sender, EventArgs e)
  {
    if (!this.FreeFormEnable && this.ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
      buString.MessageBoxError(this.LangMessageFreeForm);
    if (this.DemoMode)
    {
      buString.MessageBoxError(this.LangMessageDMode);
    }
    else
    {
      Class39.smethod_630(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) this.ParJewel);
    }
  }

  internal void method_9(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.Owner != null)
      this.Owner.Focus();
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
