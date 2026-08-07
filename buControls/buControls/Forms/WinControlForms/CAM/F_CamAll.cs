// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.CAM.F_CamAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Forms.WinControlForms.CAM.CamItems;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.CAM;

public class F_CamAll : Form
{
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public camParameters Parameters = new camParameters();
  public PostProcessor Post = new PostProcessor();
  public bool ShowHelps = true;
  public bool ShowNextButton = true;
  public bool ShowPreButton = true;
  public bool ReadOnly = false;
  public int FormHeight = 0;
  public int FormWidth = 0;
  public DialogResult Result = DialogResult.None;
  private bool bool_0 = false;
  internal NumericUpDown numericUpDown_0 = new NumericUpDown();
  internal NumericUpDown numericUpDown_1 = new NumericUpDown();
  internal NumericUpDown numericUpDown_2 = new NumericUpDown();
  internal NumericUpDown numericUpDown_3 = new NumericUpDown();
  internal NumericUpDown numericUpDown_4 = new NumericUpDown();
  internal NumericUpDown numericUpDown_5 = new NumericUpDown();
  internal NumericUpDown numericUpDown_6 = new NumericUpDown();
  internal NumericUpDown numericUpDown_7 = new NumericUpDown();
  internal NumericUpDown numericUpDown_8 = new NumericUpDown();
  internal NumericUpDown numericUpDown_9 = new NumericUpDown();
  internal CheckBox checkBox_0 = new CheckBox();
  internal NumericUpDown numericUpDown_10 = new NumericUpDown();
  internal NumericUpDown numericUpDown_11 = new NumericUpDown();
  internal NumericUpDown numericUpDown_12 = new NumericUpDown();
  internal NumericUpDown numericUpDown_13 = new NumericUpDown();
  internal NumericUpDown numericUpDown_14 = new NumericUpDown();
  internal NumericUpDown numericUpDown_15 = new NumericUpDown();
  internal CheckBox checkBox_1 = new CheckBox();
  internal CheckBox checkBox_2 = new CheckBox();
  internal RadioButton radioButton_0 = new RadioButton();
  internal RadioButton radioButton_1 = new RadioButton();
  internal RadioButton radioButton_2 = new RadioButton();
  internal RadioButton radioButton_3 = new RadioButton();
  internal NumericUpDown numericUpDown_16 = new NumericUpDown();
  internal RadioButton radioButton_4 = new RadioButton();
  internal RadioButton radioButton_5 = new RadioButton();
  internal RadioButton radioButton_6 = new RadioButton();
  internal RadioButton radioButton_7 = new RadioButton();
  internal RadioButton radioButton_8 = new RadioButton();
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabPage tabPage_0;
  public Button btn_pre;
  internal ImageList imageList_0;
  internal TabPage tabPage_1;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabPage tabPage_2;
  public Button btn_next;
  internal TabPage tabPage_3;
  internal TabPage tabPage_4;
  internal TabPage tabPage_5;
  internal TabControl tabControl_0;
  internal TabPage tabPage_6;
  internal TabPage tabPage_7;
  internal TabPage tabPage_8;

  public F_CamAll() => Class39.smethod_95(this);

  public void Init()
  {
    this.bool_0 = false;
    ArrayList arrayList = new ArrayList();
    if (this.FormHeight > 10)
      this.Height = this.FormHeight;
    if (this.FormWidth > 10)
      this.Width = this.FormWidth;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    if (!this.Post.CamPageTab.ShowMisc && this.tabControl_0.TabPages.Count >= 9)
      this.tabControl_0.TabPages.RemoveAt(8);
    if (!this.Post.CamPageTab.ShowTools && this.tabControl_0.TabPages.Count >= 8)
      this.tabControl_0.TabPages.RemoveAt(7);
    if (!this.Post.CamPageTab.ShowLeadOut && this.tabControl_0.TabPages.Count >= 7)
      this.tabControl_0.TabPages.RemoveAt(6);
    if (!this.Post.CamPageTab.ShowLeadIn && this.tabControl_0.TabPages.Count >= 6)
      this.tabControl_0.TabPages.RemoveAt(5);
    if (!this.Post.CamPageTab.ShowOffset && this.tabControl_0.TabPages.Count >= 5)
      this.tabControl_0.TabPages.RemoveAt(4);
    if (!this.Post.CamPageTab.ShowStep && this.tabControl_0.TabPages.Count >= 4)
      this.tabControl_0.TabPages.RemoveAt(3);
    if (!this.Post.CamPageTab.ShowDistance && this.tabControl_0.TabPages.Count >= 3)
      this.tabControl_0.TabPages.RemoveAt(2);
    if (!this.Post.CamPageTab.ShowVelocity && this.tabControl_0.TabPages.Count >= 2)
      this.tabControl_0.TabPages.RemoveAt(1);
    if (!this.Post.CamPageTab.ShowOperation && this.tabControl_0.TabPages.Count >= 1)
      this.tabControl_0.TabPages.RemoveAt(0);
    F_CamOperationAll fCamOperationAll = new F_CamOperationAll(false, 2);
    this.tabPage_2.Controls.Clear();
    int num1 = 0;
    for (int index1 = 0; index1 <= this.Post.CamPageOperation.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= fCamOperationAll.Controls.Count - 1; ++index2)
      {
        Control control = fCamOperationAll.Controls[index2];
        bool flag = false;
        if (control.GetType() == typeof (Panel))
        {
          if (control.Tag != null && this.Post.CamPageOperation[index1].ToString().ToLower() == control.Tag.ToString())
            flag = true;
          if (flag)
          {
            for (int index3 = 0; index3 <= control.Controls.Count - 1; ++index3)
            {
              if (control.Controls[index3].GetType() == typeof (NumericUpDown))
              {
                control.Controls[index3].KeyDown += new KeyEventHandler(this.method_2);
                control.Controls[index3].Click += new EventHandler(this.method_3);
                ((NumericUpDown) control.Controls[index3]).ValueChanged += new EventHandler(this.method_1);
                if (control.Tag.ToString() == "height")
                {
                  this.numericUpDown_16 = (NumericUpDown) control.Controls[index3];
                  ((NumericUpDown) control.Controls[index3]).Value = (Decimal) this.Parameters.Operations.Height;
                }
              }
              if (control.Controls[index3].GetType() == typeof (RadioButton) && control.Tag.ToString() == "direction")
              {
                if (control.Controls[index3].Tag.ToString() == "cw")
                  this.radioButton_4 = (RadioButton) control.Controls[index3];
                if (control.Controls[index3].Tag.ToString() == "ccw")
                  this.radioButton_5 = (RadioButton) control.Controls[index3];
                if (this.Parameters.Operations.Direction == ClockDirectionType.CW)
                {
                  this.radioButton_4.Checked = true;
                  this.radioButton_5.Checked = false;
                }
                if (this.Parameters.Operations.Direction == ClockDirectionType.CCW)
                {
                  this.radioButton_4.Checked = false;
                  this.radioButton_5.Checked = true;
                }
              }
              if (control.Controls[index3].GetType() == typeof (RadioButton) && control.Tag.ToString() == "opencontour")
              {
                if (control.Controls[index3].Tag.ToString() == "left")
                  this.radioButton_6 = (RadioButton) control.Controls[index3];
                if (control.Controls[index3].Tag.ToString() == "right")
                  this.radioButton_7 = (RadioButton) control.Controls[index3];
                if (control.Controls[index3].Tag.ToString() == "center")
                  this.radioButton_8 = (RadioButton) control.Controls[index3];
                if (this.Parameters.Offsets.OpenContourOld == CamOpenContourType2.Left)
                {
                  this.radioButton_6.Checked = true;
                  this.radioButton_7.Checked = false;
                  this.radioButton_8.Checked = false;
                }
                if (this.Parameters.Offsets.OpenContourOld == CamOpenContourType2.Right)
                {
                  this.radioButton_6.Checked = false;
                  this.radioButton_7.Checked = true;
                  this.radioButton_8.Checked = false;
                }
                if (this.Parameters.Offsets.OpenContourOld == CamOpenContourType2.Center)
                {
                  this.radioButton_6.Checked = false;
                  this.radioButton_7.Checked = false;
                  this.radioButton_8.Checked = true;
                }
              }
            }
            control.Top = 6 + num1 * 32 /*0x20*/;
            this.tabPage_2.Controls.Add(control);
            ++num1;
            index2 = 2147483637;
          }
        }
      }
    }
    F_CamVelocityAll fCamVelocityAll = new F_CamVelocityAll(false, 2);
    this.tabPage_1.Controls.Clear();
    int num2 = 0;
    for (int index4 = 0; index4 <= this.Post.CamPageVelocity.Count - 1; ++index4)
    {
      for (int index5 = 0; index5 <= fCamVelocityAll.Controls.Count - 1; ++index5)
      {
        Control control = fCamVelocityAll.Controls[index5];
        bool flag = false;
        if (control.GetType() == typeof (Panel))
        {
          if (control.Tag != null && this.Post.CamPageVelocity[index4].ToString().ToLower() == control.Tag.ToString())
            flag = true;
          if (flag)
          {
            for (int index6 = 0; index6 <= control.Controls.Count - 1; ++index6)
            {
              if (control.Controls[index6].GetType() == typeof (NumericUpDown))
              {
                control.Controls[index6].KeyDown += new KeyEventHandler(this.method_2);
                control.Controls[index6].Click += new EventHandler(this.method_3);
                ((NumericUpDown) control.Controls[index6]).ValueChanged += new EventHandler(this.method_1);
                if (control.Tag.ToString() == "feed")
                {
                  this.numericUpDown_0 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.Feed;
                }
                if (control.Tag.ToString() == "plunge")
                {
                  this.numericUpDown_2 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.Plunge;
                }
                if (control.Tag.ToString() == "leave")
                {
                  this.numericUpDown_3 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.Leave;
                }
                if (control.Tag.ToString() == "rapid")
                {
                  this.numericUpDown_4 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.Rapid;
                }
                if (control.Tag.ToString() == "finish")
                {
                  this.numericUpDown_5 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.Finish;
                }
                if (control.Tag.ToString() == "backfeed")
                {
                  this.numericUpDown_1 = (NumericUpDown) control.Controls[index6];
                  ((NumericUpDown) control.Controls[index6]).Value = (Decimal) this.Parameters.Speeds.BackwardFeed;
                }
              }
            }
            control.Top = 6 + num2 * 32 /*0x20*/;
            this.tabPage_1.Controls.Add(control);
            ++num2;
            --index5;
          }
        }
      }
    }
    F_CamDistanceAll fCamDistanceAll = new F_CamDistanceAll(false, 2);
    this.tabPage_3.Controls.Clear();
    int num3 = 0;
    for (int index7 = 0; index7 <= this.Post.CamPageDistance.Count - 1; ++index7)
    {
      for (int index8 = 0; index8 <= fCamDistanceAll.Controls.Count - 1; ++index8)
      {
        Control control = fCamDistanceAll.Controls[index8];
        bool flag = false;
        if (control.GetType() == typeof (Panel))
        {
          if (control.Tag != null && this.Post.CamPageDistance[index7].ToString().ToLower() == control.Tag.ToString())
            flag = true;
          if (flag)
          {
            for (int index9 = 0; index9 <= control.Controls.Count - 1; ++index9)
            {
              if (control.Controls[index9].GetType() == typeof (NumericUpDown))
              {
                control.Controls[index9].KeyDown += new KeyEventHandler(this.method_2);
                control.Controls[index9].Click += new EventHandler(this.method_3);
                ((NumericUpDown) control.Controls[index9]).ValueChanged += new EventHandler(this.method_1);
                if (control.Tag.ToString() == "safe")
                {
                  this.numericUpDown_6 = (NumericUpDown) control.Controls[index9];
                  ((NumericUpDown) control.Controls[index9]).Value = (Decimal) this.Parameters.Distances.Safe;
                }
                if (control.Tag.ToString() == "air")
                {
                  this.numericUpDown_7 = (NumericUpDown) control.Controls[index9];
                  ((NumericUpDown) control.Controls[index9]).Value = (Decimal) this.Parameters.Distances.Air;
                }
                if (control.Tag.ToString() == "stepup")
                {
                  this.numericUpDown_8 = (NumericUpDown) control.Controls[index9];
                  ((NumericUpDown) control.Controls[index9]).Value = (Decimal) this.Parameters.Distances.StepUp;
                }
                if (control.Tag.ToString() == "smallsafe")
                {
                  this.numericUpDown_9 = (NumericUpDown) control.Controls[index9];
                  ((NumericUpDown) control.Controls[index9]).Value = (Decimal) this.Parameters.Distances.SafeSmall;
                }
              }
              if (control.Controls[index9].GetType() == typeof (CheckBox) && control.Tag.ToString() == "safeincremental")
              {
                this.checkBox_0 = (CheckBox) control.Controls[index9];
                ((CheckBox) control.Controls[index9]).Checked = this.Parameters.Distances.IncrementalSafe;
              }
            }
            control.Top = 6 + num3 * 32 /*0x20*/;
            this.tabPage_3.Controls.Add(control);
            ++num3;
            --index8;
          }
        }
      }
    }
    F_CamStepAll fCamStepAll = new F_CamStepAll(false, 2);
    this.tabPage_0.Controls.Clear();
    int num4 = 0;
    for (int index10 = 0; index10 <= this.Post.CamPageStep.Count - 1; ++index10)
    {
      for (int index11 = 0; index11 <= fCamStepAll.Controls.Count - 1; ++index11)
      {
        Control control = fCamStepAll.Controls[index11];
        bool flag = false;
        if (control.GetType() == typeof (Panel))
        {
          if (control.Tag != null && this.Post.CamPageStep[index10].ToString().ToLower() == control.Tag.ToString())
            flag = true;
          if (flag)
          {
            for (int index12 = 0; index12 <= control.Controls.Count - 1; ++index12)
            {
              if (control.Controls[index12].GetType() == typeof (NumericUpDown))
              {
                control.Controls[index12].KeyDown += new KeyEventHandler(this.method_2);
                control.Controls[index12].Click += new EventHandler(this.method_3);
                ((NumericUpDown) control.Controls[index12]).ValueChanged += new EventHandler(this.method_1);
                if (control.Tag.ToString() == "start")
                {
                  this.numericUpDown_10 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.StartValue;
                }
                if (control.Tag.ToString() == "end")
                {
                  this.numericUpDown_11 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.EndValue;
                }
                if (control.Tag.ToString() == "count")
                {
                  this.numericUpDown_12 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.Count;
                }
                if (control.Tag.ToString() == "step")
                {
                  this.numericUpDown_12 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.Step;
                }
                if (control.Tag.ToString() == "distance")
                {
                  this.numericUpDown_14 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.Distance;
                }
                if (control.Tag.ToString() == "moveup")
                {
                  this.numericUpDown_15 = (NumericUpDown) control.Controls[index12];
                  ((NumericUpDown) control.Controls[index12]).Value = (Decimal) this.Parameters.Steps.MoveUp;
                }
              }
              if (control.Controls[index12].GetType() == typeof (CheckBox) && control.Tag.ToString() == "moveup")
              {
                this.checkBox_2 = (CheckBox) control.Controls[index12];
                ((CheckBox) control.Controls[index12]).Checked = this.Parameters.Steps.MoveUpEnable;
              }
              if (control.Controls[index12].GetType() == typeof (CheckBox) && control.Tag.ToString() == "enable")
              {
                this.checkBox_1 = (CheckBox) control.Controls[index12];
                ((CheckBox) control.Controls[index12]).Checked = this.Parameters.Steps.Enable;
              }
              if (control.Controls[index12].GetType() == typeof (RadioButton))
              {
                if (control.Tag.ToString() == "moveuptype")
                {
                  if (control.Controls[index12].Tag.ToString() == "abs")
                    this.radioButton_0 = (RadioButton) control.Controls[index12];
                  if (control.Controls[index12].Tag.ToString() == "rel")
                    this.radioButton_1 = (RadioButton) control.Controls[index12];
                  if (this.Parameters.Steps.MoveUpType == CamMoveUpType.Absolute)
                  {
                    this.radioButton_0.Checked = true;
                    this.radioButton_1.Checked = false;
                  }
                  if (this.Parameters.Steps.MoveUpType == CamMoveUpType.Incremental)
                  {
                    this.radioButton_0.Checked = false;
                    this.radioButton_1.Checked = true;
                  }
                }
                if (control.Tag.ToString() == "sequence")
                {
                  if (control.Controls[index12].Tag.ToString() == "level")
                    this.radioButton_2 = (RadioButton) control.Controls[index12];
                  if (control.Controls[index12].Tag.ToString() == "region")
                    this.radioButton_3 = (RadioButton) control.Controls[index12];
                  if (this.Parameters.Steps.Sequence == CamMachiningSequenceType.Level)
                  {
                    this.radioButton_2.Checked = true;
                    this.radioButton_3.Checked = false;
                  }
                  if (this.Parameters.Steps.Sequence == CamMachiningSequenceType.Region)
                  {
                    this.radioButton_2.Checked = false;
                    this.radioButton_3.Checked = true;
                  }
                }
              }
            }
            control.Top = 6 + num4 * 32 /*0x20*/;
            this.tabPage_0.Controls.Add(control);
            ++num4;
            index11 = 2147483637;
          }
        }
      }
    }
    this.Refresh();
    this.Result = DialogResult.None;
    this.bool_0 = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.bool_0)
        return;
      if (this.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_589(this);
      this.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Result = DialogResult.Cancel;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_pre.Name && this.tabControl_0.SelectedIndex > 0)
      --this.tabControl_0.SelectedIndex;
    if (!(control2.Name == this.btn_next.Name) || this.tabControl_0.SelectedIndex >= this.tabControl_0.TabPages.Count - 1)
      return;
    ++this.tabControl_0.SelectedIndex;
  }

  private void method_1(object sender, EventArgs e)
  {
    if (this.bool_0)
      ;
  }

  private void method_2(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabControl_0.SelectedTab.Controls, result, e.Shift);
  }

  private void method_3(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
