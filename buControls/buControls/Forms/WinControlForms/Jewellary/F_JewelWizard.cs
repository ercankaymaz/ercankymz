// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelWizard
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

public class F_JewelWizard : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public JewelVar ParJewel = new JewelVar();
  public List<ToolBase> Tools = new List<ToolBase>();
  public int ToolSelectedIndex = 0;
  public bool FreeFormEnable = false;
  public bool DemoMode = false;
  public string LangMessageDMode = "You Can't Do This Operation in Demo Mode";
  public string LangMessageFreeForm = "Fre From Mode Not Allowed";
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Panel panel_1;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Label label_0;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal Button button_12;
  internal Button button_13;
  internal Button button_14;
  internal Button button_15;
  internal Label label_3;
  internal ImageList imageList_0;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal Panel panel_3;
  internal Label label_5;
  internal Button button_16;
  internal ComboBox comboBox_0;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal NumericUpDown numericUpDown_3;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal Label label_7;
  internal NumericUpDown numericUpDown_5;
  internal Label label_8;
  internal Label label_9;
  internal Panel panel_4;
  internal Button button_17;
  internal Button button_18;
  internal CheckBox checkBox_2;
  internal NumericUpDown numericUpDown_6;
  internal Label label_10;
  internal Panel panel_5;
  internal Label label_11;
  internal NumericUpDown numericUpDown_7;
  internal Label label_12;
  internal Button button_19;
  internal CheckBox checkBox_3;
  internal NumericUpDown numericUpDown_8;
  internal Label label_13;
  internal Panel panel_6;
  internal ComboBox comboBox_1;
  internal Label label_14;
  internal Label label_15;
  internal CheckBox checkBox_4;
  internal NumericUpDown numericUpDown_9;
  internal Label label_16;
  internal Button button_20;
  internal Button button_21;
  internal Button button_22;
  internal Button button_23;
  internal Button button_24;
  internal ImageList imageList_1;
  internal CheckBox checkBox_5;
  internal CheckBox checkBox_6;
  internal NumericUpDown numericUpDown_10;
  internal Label label_17;
  internal NumericUpDown numericUpDown_11;
  internal Label label_18;
  internal CheckBox checkBox_7;
  internal Panel panel_7;
  internal Label label_19;

  public event OkCommandWithDataEventHandler OkPressed;

  public event CancelCommandEventHandler CancelPressed;

  public event ApplyCommandWithDataEventHandler ApplyPressed;

  public F_JewelWizard() => Class39.smethod_40(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.Owner == null)
      return;
    this.Owner.Focus();
  }

  public void Init()
  {
    this.button_2.BackColor = Color.Silver;
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    this.button_5.BackColor = Color.Silver;
    this.button_4.BackColor = Color.Silver;
    this.button_3.BackColor = Color.Silver;
    this.button_14.Enabled = this.FreeFormEnable;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Contour3AX)
      this.button_2.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Pocket3AX)
      this.button_1.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Punch3AX)
      this.button_0.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Contour5AX)
      this.button_5.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Pocket5AX)
      this.button_4.BackColor = Color.Red;
    if (this.ParJewel.JewelMode.CamMode == jewelCamModeType.Punch5AX)
      this.button_3.BackColor = Color.Red;
    this.button_11.BackColor = Color.Silver;
    this.button_10.BackColor = Color.Silver;
    this.button_7.BackColor = Color.Silver;
    this.button_6.BackColor = Color.Silver;
    this.button_9.BackColor = Color.Silver;
    this.button_8.BackColor = Color.Silver;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Spindle)
      this.button_11.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Engraving)
      this.button_10.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut1)
      this.button_7.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.DiamondCut2)
      this.button_6.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Lathe)
      this.button_9.BackColor = Color.Gold;
    if (this.ParJewel.JewelMode.OperationMode == jewelOperationModeType.Laser)
      this.button_8.BackColor = Color.Gold;
    this.button_12.BackColor = Color.Silver;
    this.button_13.BackColor = Color.Silver;
    this.button_14.BackColor = Color.Silver;
    this.button_15.BackColor = Color.Silver;
    if (this.ParJewel.JewelMode.FormMode == jewelCurveType.Flat)
      this.button_15.BackColor = Color.Lime;
    if (this.ParJewel.JewelMode.FormMode == jewelCurveType.Convex)
      this.button_13.BackColor = Color.Lime;
    if (this.ParJewel.JewelMode.FormMode == jewelCurveType.Concave)
      this.button_12.BackColor = Color.Lime;
    if (this.ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
      this.button_14.BackColor = Color.Lime;
    this.button_17.BackColor = Color.Silver;
    this.button_18.BackColor = Color.Silver;
    if (this.ParJewel.JewelTangentProp.Type == jewelTangentType.Point)
      this.button_17.BackColor = Color.Cyan;
    if (this.ParJewel.JewelTangentProp.Type == jewelTangentType.Continous)
      this.button_18.BackColor = Color.Cyan;
    this.checkBox_2.Checked = this.ParJewel.JewelTangentProp.UseContantAngle;
    this.numericUpDown_6.Value = (Decimal) this.ParJewel.JewelTangentProp.ContantAngle;
    this.numericUpDown_11.Value = (Decimal) this.ParJewel.JewelMaterialProp.MajorDiameter;
    this.numericUpDown_10.Value = (Decimal) this.ParJewel.JewelMaterialProp.MinorDiameter;
    this.numericUpDown_1.Value = (Decimal) this.ParJewel.JewelMaterialProp.Diameter;
    this.numericUpDown_0.Value = (Decimal) this.ParJewel.JewelMaterialProp.Width;
    this.numericUpDown_2.Value = (Decimal) this.ParJewel.JewelMaterialProp.CurveRadius;
    this.numericUpDown_8.Value = (Decimal) this.ParJewel.JewelScaleProp.ConstantX;
    this.numericUpDown_7.Value = (Decimal) this.ParJewel.JewelScaleProp.ConstantY;
    this.checkBox_3.Checked = this.ParJewel.JewelMode.SlideEnable;
    this.checkBox_0.Checked = this.ParJewel.OilEnable;
    this.checkBox_1.Checked = this.ParJewel.JewelSteppingProp.Enable;
    this.checkBox_7.Checked = false;
    if (this.ParJewel.JewelMaterialProp.ShapeType == jewelMaterialShapeType.Ellipse)
      this.checkBox_7.Checked = true;
    this.numericUpDown_4.Value = (Decimal) this.ParJewel.JewelCamProp.FeedSpeed;
    this.numericUpDown_3.Value = (Decimal) this.ParJewel.JewelCamProp.PlungeSpeed;
    this.numericUpDown_5.Value = (Decimal) this.ParJewel.JewelCamProp.Depth;
    this.numericUpDown_9.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
    this.checkBox_4.Checked = this.ParJewel.JewelCamProp.PolylineToSpline;
    this.checkBox_6.Checked = this.ParJewel.JewelCamProp.AngularMode;
    this.checkBox_5.Checked = this.ParJewel.JewelCamProp.TriangularCut;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.SortNextGRoupRules, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.ParJewel.SortNextGRoupRules), ref this.comboBox_1);
    this.comboBox_0.Items.Clear();
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
      this.comboBox_0.Items.Add((object) $"T{this.Tools[index].Data.No.ToString()} - {this.Tools[index].Data.Name}");
    if (this.ToolSelectedIndex >= 0 & this.ToolSelectedIndex <= this.Tools.Count - 1)
      this.comboBox_0.SelectedIndex = this.ToolSelectedIndex;
    this.Result = DialogResult.None;
    Class39.smethod_826(this);
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_2.BackColor = Color.Silver;
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    this.button_5.BackColor = Color.Silver;
    this.button_4.BackColor = Color.Silver;
    this.button_3.BackColor = Color.Silver;
    if (control2.Name == this.button_2.Name)
    {
      this.ParJewel.JewelMode.CamMode = jewelCamModeType.Contour3AX;
      this.button_2.BackColor = Color.Red;
    }
    if (control2.Name == this.button_1.Name)
    {
      this.ParJewel.JewelMode.CamMode = jewelCamModeType.Pocket3AX;
      this.button_1.BackColor = Color.Red;
    }
    if (control2.Name == this.button_0.Name)
    {
      this.ParJewel.JewelMode.CamMode = jewelCamModeType.Punch3AX;
      this.button_0.BackColor = Color.Red;
    }
    if (control2.Name == this.button_5.Name)
    {
      this.ParJewel.JewelMode.CamMode = jewelCamModeType.Contour5AX;
      this.button_5.BackColor = Color.Red;
    }
    if (control2.Name == this.button_4.Name)
    {
      this.ParJewel.JewelMode.CamMode = jewelCamModeType.Pocket5AX;
      this.button_4.BackColor = Color.Red;
    }
    if (!(control2.Name == this.button_3.Name))
      return;
    this.ParJewel.JewelMode.CamMode = jewelCamModeType.Punch5AX;
    this.button_3.BackColor = Color.Red;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_11.BackColor = Color.Silver;
    this.button_10.BackColor = Color.Silver;
    this.button_7.BackColor = Color.Silver;
    this.button_6.BackColor = Color.Silver;
    this.button_9.BackColor = Color.Silver;
    this.button_8.BackColor = Color.Silver;
    if (control2.Name == this.button_11.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Spindle;
      this.button_11.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_10.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Engraving;
      this.button_10.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_7.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut1;
      this.button_7.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_6.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.DiamondCut2;
      this.button_6.BackColor = Color.Gold;
    }
    if (control2.Name == this.button_9.Name)
    {
      this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Lathe;
      this.button_9.BackColor = Color.Gold;
    }
    if (!(control2.Name == this.button_8.Name))
      return;
    this.ParJewel.JewelMode.OperationMode = jewelOperationModeType.Laser;
    this.button_8.BackColor = Color.Gold;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_12.BackColor = Color.Silver;
    this.button_13.BackColor = Color.Silver;
    this.button_14.BackColor = Color.Silver;
    this.button_15.BackColor = Color.Silver;
    if (control2.Name == this.button_15.Name)
    {
      this.ParJewel.JewelMode.FormMode = jewelCurveType.Flat;
      this.ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Flat;
      this.button_15.BackColor = Color.Lime;
    }
    if (control2.Name == this.button_13.Name)
    {
      this.ParJewel.JewelMode.FormMode = jewelCurveType.Convex;
      this.ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Convex;
      this.button_13.BackColor = Color.Lime;
    }
    if (control2.Name == this.button_12.Name)
    {
      this.ParJewel.JewelMode.FormMode = jewelCurveType.Concave;
      this.ParJewel.JewelMaterialProp.CurveType = jewelCurveType.Concave;
      this.button_12.BackColor = Color.Lime;
    }
    if (!(control2.Name == this.button_14.Name))
      return;
    this.ParJewel.JewelMode.FormMode = jewelCurveType.FreeDraw;
    this.ParJewel.JewelMaterialProp.CurveType = jewelCurveType.FreeDraw;
    this.button_14.BackColor = Color.Lime;
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_17.BackColor = Color.Silver;
    this.button_18.BackColor = Color.Silver;
    if (control2.Name == this.button_17.Name)
    {
      this.ParJewel.JewelTangentProp.Type = jewelTangentType.Point;
      this.button_17.BackColor = Color.Cyan;
    }
    if (!(control2.Name == this.button_18.Name))
      return;
    this.ParJewel.JewelTangentProp.Type = jewelTangentType.Continous;
    this.button_18.BackColor = Color.Cyan;
  }

  internal void method_5(object sender, EventArgs e)
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

  internal void method_6(object sender, EventArgs e)
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

  internal void method_7(object sender, EventArgs e)
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
    this.numericUpDown_9.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.SortNextGRoupRules, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.ParJewel.SortNextGRoupRules), ref this.comboBox_1);
  }

  internal void method_8(object sender, EventArgs e)
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

  internal void method_9(object sender, EventArgs e)
  {
    if (!this.FreeFormEnable && this.ParJewel.JewelMode.FormMode == jewelCurveType.FreeDraw)
      buString.MessageBoxError(this.LangMessageFreeForm);
    if (this.DemoMode)
    {
      buString.MessageBoxError(this.LangMessageDMode);
    }
    else
    {
      this.method_10((object) this.button_23, e);
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) this.ParJewel);
    }
  }

  internal void method_10(object sender, EventArgs e)
  {
    this.ParJewel.JewelTangentProp.ContantAngle = (double) this.numericUpDown_6.Value;
    this.ParJewel.JewelMaterialProp.Diameter = (double) this.numericUpDown_1.Value;
    this.ParJewel.JewelMaterialProp.Width = (double) this.numericUpDown_0.Value;
    this.ParJewel.JewelMaterialProp.CurveRadius = (double) this.numericUpDown_2.Value;
    this.ParJewel.JewelScaleProp.ConstantX = (double) this.numericUpDown_8.Value;
    this.ParJewel.JewelScaleProp.ConstantY = (double) this.numericUpDown_7.Value;
    this.ParJewel.JewelMaterialProp.MajorDiameter = (double) this.numericUpDown_11.Value;
    this.ParJewel.JewelMaterialProp.MinorDiameter = (double) this.numericUpDown_10.Value;
    this.ParJewel.JewelMaterialProp.ShapeType = jewelMaterialShapeType.Circle;
    if (this.checkBox_7.Checked)
      this.ParJewel.JewelMaterialProp.ShapeType = jewelMaterialShapeType.Ellipse;
    this.ParJewel.JewelTangentProp.UseContantAngle = this.checkBox_2.Checked;
    this.ParJewel.JewelMode.SlideEnable = this.checkBox_3.Checked;
    this.ParJewel.OilEnable = this.checkBox_0.Checked;
    this.ParJewel.JewelSteppingProp.Enable = this.checkBox_1.Checked;
    this.ParJewel.JewelCamProp.FeedSpeed = (double) this.numericUpDown_4.Value;
    this.ParJewel.JewelCamProp.PlungeSpeed = (double) this.numericUpDown_3.Value;
    this.ParJewel.JewelCamProp.Depth = (double) this.numericUpDown_5.Value;
    this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset = (double) this.numericUpDown_9.Value;
    this.ParJewel.JewelCamProp.PolylineToSpline = this.checkBox_4.Checked;
    this.ParJewel.JewelCamProp.AngularMode = this.checkBox_6.Checked;
    this.ParJewel.JewelCamProp.TriangularCut = this.checkBox_5.Checked;
    this.ParJewel.SortNextGRoupRules = (SortingNextGroupFindRulesType) buGeneral.EnumValueFromInt((object) this.ParJewel.SortNextGRoupRules, this.comboBox_1.SelectedIndex);
    if (this.comboBox_0.SelectedIndex >= 0 & this.comboBox_0.SelectedIndex <= this.Tools.Count - 1)
      this.ToolSelectedIndex = this.comboBox_0.SelectedIndex;
    if (!this.ParJewel.JewelMode.SlideEnable)
    {
      this.ParJewel.JewelMaterialProp.EndSpaceX = 0.0;
      this.ParJewel.JewelMaterialProp.StartSpaceX = 0.0;
      this.ParJewel.JewelMaterialProp.SpaceY = 0.0;
    }
    else
    {
      this.ParJewel.JewelMaterialProp.EndSpaceX = this.ParJewel.PositionProp.XStartSpace;
      this.ParJewel.JewelMaterialProp.StartSpaceX = this.ParJewel.PositionProp.XEndSpace;
      this.ParJewel.JewelMaterialProp.SpaceY = this.ParJewel.PositionProp.YSpace;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.applyCommandWithDataEventHandler_0((object) this.ParJewel);
  }

  internal void method_11(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
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
