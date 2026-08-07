// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Spining.F_MetalPipeSpinning
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Spining;

public class F_MetalPipeSpinning : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public SpinPipePattern varSpinPattern = new SpinPipePattern();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Button button_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal Button button_2;
  internal Button button_3;
  internal Panel panel_0;
  internal Label label_4;
  internal NumericUpDown numericUpDown_4;
  internal Label label_5;
  internal CheckBox checkBox_0;
  internal Button button_4;
  internal NumericUpDown numericUpDown_5;
  internal Panel panel_1;
  internal Label label_6;
  internal Panel panel_2;
  internal Label label_7;
  internal Label label_8;
  internal NumericUpDown numericUpDown_6;
  internal Label label_9;
  internal NumericUpDown numericUpDown_7;
  internal Button button_5;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal NumericUpDown numericUpDown_9;
  internal Label label_11;
  internal NumericUpDown numericUpDown_10;
  internal Label label_12;
  internal NumericUpDown numericUpDown_11;
  internal Label label_13;
  internal NumericUpDown numericUpDown_12;
  internal Label label_14;
  internal NumericUpDown numericUpDown_13;
  internal Label label_15;
  internal NumericUpDown numericUpDown_14;
  internal Label label_16;

  public F_MetalPipeSpinning() => Class39.smethod_102(this);

  public event ClickSenderDataEventHandler ShowPath;

  public event ApplyCommandWithDataEventHandler SpinValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.numericUpDown_0.Value = (Decimal) this.varSpinPattern.StepDepth;
    this.numericUpDown_3.Value = (Decimal) this.varSpinPattern.PipeLeftOffset;
    this.numericUpDown_4.Value = (Decimal) this.varSpinPattern.TubeRigthOffset;
    this.numericUpDown_9.Value = (Decimal) this.varSpinPattern.SetTubeLeftOffsetEachStep;
    this.numericUpDown_12.Value = (Decimal) this.varSpinPattern.SetTubeRightOffsetEachStep;
    this.numericUpDown_11.Value = (Decimal) this.varSpinPattern.TubeTopOffset;
    this.numericUpDown_10.Value = (Decimal) this.varSpinPattern.CenterLineOffset;
    this.numericUpDown_14.Value = (Decimal) this.varSpinPattern.FirstCurveLength;
    this.numericUpDown_13.Value = (Decimal) this.varSpinPattern.LeadinCurveLength;
    this.numericUpDown_2.Value = (Decimal) this.varSpinPattern.LeaveOffsetX;
    this.numericUpDown_1.Value = (Decimal) this.varSpinPattern.LeaveHeight;
    this.numericUpDown_5.Value = (Decimal) this.varSpinPattern.LeaveArcCornerRadius;
    this.numericUpDown_6.Value = (Decimal) this.varSpinPattern.CamFeed;
    this.numericUpDown_8.Value = (Decimal) this.varSpinPattern.SafeDistance;
    this.numericUpDown_7.Value = (Decimal) this.varSpinPattern.CamLeaveFeed;
    this.checkBox_0.Checked = this.varSpinPattern.isArcCorner;
    this.ControlUpdate();
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_MetalPipeSpinning.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.clickSenderDataEventHandler_0 != null)
      {
        this.Apply();
        // ISSUE: reference to a compiler-generated field
        this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
        {
          OK = true
        });
      }
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.clickSenderDataEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
        {
          Cancel = true
        });
      }
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_0.Name && this.clickSenderDataEventHandler_0 != null)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
      {
        ShowPattern = true
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_5.Name && this.clickSenderDataEventHandler_0 != null)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
      {
        Finish = true
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_4.Name && this.clickSenderDataEventHandler_0 != null)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
      {
        Undo = true
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_1.Name && this.clickSenderDataEventHandler_0 != null)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
      {
        NextPattern = true
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.button_3.Name && this.clickSenderDataEventHandler_0 != null)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
      {
        SimStart = true
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.button_2.Name) || this.clickSenderDataEventHandler_0 == null)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    this.clickSenderDataEventHandler_0((object) null, (object) new SpinPatternCommand()
    {
      SimStop = true
    });
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.varSpinPattern.StepDepth = (double) this.numericUpDown_0.Value;
    this.varSpinPattern.PipeLeftOffset = (double) this.numericUpDown_3.Value;
    this.varSpinPattern.TubeRigthOffset = (double) this.numericUpDown_4.Value;
    this.varSpinPattern.SetTubeLeftOffsetEachStep = (double) this.numericUpDown_9.Value;
    this.varSpinPattern.SetTubeRightOffsetEachStep = (double) this.numericUpDown_12.Value;
    this.varSpinPattern.TubeTopOffset = (double) this.numericUpDown_11.Value;
    this.varSpinPattern.CenterLineOffset = (double) this.numericUpDown_10.Value;
    this.varSpinPattern.FirstCurveLength = (double) this.numericUpDown_14.Value;
    this.varSpinPattern.LeadinCurveLength = (double) this.numericUpDown_13.Value;
    this.varSpinPattern.LeaveOffsetX = (double) this.numericUpDown_2.Value;
    this.varSpinPattern.LeaveHeight = (double) this.numericUpDown_1.Value;
    this.varSpinPattern.LeaveArcCornerRadius = (double) this.numericUpDown_5.Value;
    this.varSpinPattern.CamFeed = (double) this.numericUpDown_6.Value;
    this.varSpinPattern.SafeDistance = (double) this.numericUpDown_8.Value;
    this.varSpinPattern.CamLeaveFeed = (double) this.numericUpDown_7.Value;
    this.varSpinPattern.isArcCorner = this.checkBox_0.Checked;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithDataEventHandler_0((object) this.varSpinPattern);
    }
    this.PropertiesForm.Inited = true;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (this.applyCommandWithDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.applyCommandWithDataEventHandler_0((object) this.varSpinPattern);
    }
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
    this.method_4(sender, (EventArgs) null);
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control = new Control();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
