// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Test.F_TestAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Test;

public class F_TestAll : Form
{
  public int DigitalInputCount = 32 /*0x20*/;
  public int DigitalInputColumbs = 4;
  public int DigitalOutputCount = 32 /*0x20*/;
  public int DigitalOutputColumbs = 4;
  public int AxisCount = 4;
  public int SelectedTab = 0;
  public List<string> AxisCaptions = new List<string>();
  public List<string> InputCaptions = new List<string>();
  public List<string> OutputCaptions = new List<string>();
  public bool AxisTabPageVisible = true;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buTab buTab_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal buPanel buPanel_0;
  internal buPanel buPanel_1;
  internal buPanel buPanel_2;
  internal buSeparator buSeparator_0;
  internal buLabel buLabel_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal buPanel buPanel_3;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buButton buButton_8;
  internal buButton buButton_9;
  public buCheckBox chk_i31;
  public buCheckBox chk_i23;
  public buCheckBox chk_i15;
  public buCheckBox chk_i7;
  public buCheckBox chk_i30;
  public buCheckBox chk_i22;
  public buCheckBox chk_i14;
  public buCheckBox chk_i6;
  public buCheckBox chk_i29;
  public buCheckBox chk_i21;
  public buCheckBox chk_i13;
  public buCheckBox chk_i5;
  public buCheckBox chk_i28;
  public buCheckBox chk_i20;
  public buCheckBox chk_i12;
  public buCheckBox chk_i4;
  public buCheckBox chk_i27;
  public buCheckBox chk_i19;
  public buCheckBox chk_i11;
  public buCheckBox chk_i3;
  public buCheckBox chk_i26;
  public buCheckBox chk_i18;
  public buCheckBox chk_i10;
  public buCheckBox chk_i2;
  public buCheckBox chk_i25;
  public buCheckBox chk_i17;
  public buCheckBox chk_i9;
  public buCheckBox chk_i1;
  public buCheckBox chk_i24;
  public buCheckBox chk_i16;
  public buCheckBox chk_i8;
  public buCheckBox chk_i0;
  public buCheckBox chk_o31;
  public buCheckBox chk_o23;
  public buCheckBox chk_o15;
  public buCheckBox chk_o7;
  public buCheckBox chk_o30;
  public buCheckBox chk_o22;
  public buCheckBox chk_o14;
  public buCheckBox chk_o6;
  public buCheckBox chk_o29;
  public buCheckBox chk_o21;
  public buCheckBox chk_o13;
  public buCheckBox chk_o5;
  public buCheckBox chk_o28;
  public buCheckBox chk_o20;
  public buCheckBox chk_o12;
  public buCheckBox chk_o4;
  public buCheckBox chk_o27;
  public buCheckBox chk_o19;
  public buCheckBox chk_o11;
  public buCheckBox chk_o3;
  public buCheckBox chk_o26;
  public buCheckBox chk_o18;
  public buCheckBox chk_o10;
  public buCheckBox chk_o2;
  public buCheckBox chk_o25;
  public buCheckBox chk_o17;
  public buCheckBox chk_o9;
  public buCheckBox chk_o1;
  public buCheckBox chk_o24;
  public buCheckBox chk_o16;
  public buCheckBox chk_o8;
  public buCheckBox chk_o0;
  public buListBox lst_axis;
  public buLabel lbl_axis;
  public buLabel lbl_pos;
  public buButton btn_auto;
  public buButton btn_pos1;
  public buButton btn_homing;
  public buButton btn_pos2;
  public buButton btn_stop;
  public buButton btn_fwd;
  public buButton btn_bwd;
  public buButton btn_relative;
  public buButton btn_write;
  public buCheckBox chk_Homing;
  public buCheckBox chk_capture;
  public buCheckBox chk_positive;
  public buCheckBox chk_negative;
  public buSpin spn_pos1;
  public buSpin spn_waittime;
  public buSpin spn_relative;
  public buSpin spn_pos2;

  public F_TestAll() => Class39.smethod_155(this);

  public void Init()
  {
    try
    {
      this.lst_axis.Items.Clear();
      for (int index = 0; index <= this.AxisCount - 1; ++index)
      {
        if (index <= this.AxisCaptions.Count - 1)
          this.lst_axis.Items.Add((object) this.AxisCaptions[index]);
        else
          this.lst_axis.Items.Add((object) ("Axis " + (index + 1).ToString()));
      }
      for (int index1 = 0; index1 <= 48 /*0x30*/; ++index1)
      {
        for (int index2 = 0; index2 <= this.tabPage_0.Controls.Count - 1; ++index2)
        {
          Control control = new Control();
          if (this.tabPage_0.Controls[index2].Name == "chk_i" + index1.ToString() && this.InputCaptions.Count > 0 & index1 <= this.InputCaptions.Count - 1)
            this.tabPage_0.Controls[index2].Text = this.InputCaptions[index1];
        }
      }
      for (int index3 = 0; index3 <= 48 /*0x30*/; ++index3)
      {
        for (int index4 = 0; index4 <= this.tabPage_1.Controls.Count - 1; ++index4)
        {
          Control control = new Control();
          if (this.tabPage_1.Controls[index4].Name == "chk_o" + index3.ToString() && this.OutputCaptions.Count > 0 & index3 <= this.OutputCaptions.Count - 1)
            this.tabPage_1.Controls[index4].Text = this.OutputCaptions[index3];
        }
      }
      if (AppProcess.SelectedAxis >= 0 & AppProcess.SelectedAxis <= this.lst_axis.Items.Count - 1)
        this.lst_axis.SelectedIndex = AppProcess.SelectedAxis;
      if (!this.AxisTabPageVisible && this.buTab_0.TabPages.Count == 3)
        this.buTab_0.TabPages.RemoveAt(2);
      if (!(this.buTab_0.SelectedIndex == 0 | this.buTab_0.SelectedIndex == 1))
        return;
      this.buPanel_3.Visible = false;
      this.buButton_2.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_1.Name)
        this.Visible = false;
      if (!(control2.Name == this.buButton_0.Name))
        return;
      this.WindowState = FormWindowState.Minimized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_3.Name)
        this.buPanel_3.Visible = false;
      if (control2.Name == this.buButton_2.Name)
      {
        if (!this.buPanel_3.Visible)
          this.buPanel_3.Visible = true;
        else
          this.buPanel_3.Visible = false;
      }
      if (control2.Name == this.buButton_8.Name)
      {
        this.buPanel_3.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Moves, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_9.Name)
      {
        this.buPanel_3.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Jog, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_7.Name)
      {
        this.buPanel_3.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Gain, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_6.Name)
      {
        this.buPanel_3.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Drive, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_5.Name)
      {
        this.buPanel_3.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Homing, AppProcess.SelectedAxis);
        }
      }
      if (!(control2.Name == this.buButton_4.Name))
        return;
      this.buPanel_3.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.jogSelectedSettingsModeEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Sets, AppProcess.SelectedAxis);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      // ISSUE: reference to a compiler-generated field
      if (control2.Tag == null || this.setOutputEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.setOutputEventHandler_0(int.Parse(control2.Tag.ToString()));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 == null || this.lst_axis.SelectedIndex < 0)
        return;
      // ISSUE: reference to a compiler-generated field
      this.jogAxisChangedEventHandler_0((object) this, this.lst_axis.SelectedIndex);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.spn_pos1.Name && AppBool.TouchPad)
        buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_pos1);
      if (control2.Name == this.spn_pos2.Name && AppBool.TouchPad)
        buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_pos2);
      if (control2.Name == this.spn_relative.Name && AppBool.TouchPad)
        buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_relative);
      if (!(control2.Name == this.spn_waittime.Name) || !AppBool.TouchPad)
        return;
      buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_waittime);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_5(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.buPanel_0.Controls, result, e.Shift);
  }

  public void GetInput(int Index, bool State)
  {
    try
    {
      for (int index = 1; index <= this.tabPage_0.Controls.Count - 1; ++index)
      {
        if (this.tabPage_0.Controls[index].Tag != null && int.Parse(this.tabPage_0.Controls[index].Tag.ToString()) == Index)
          ((buCheckBox) this.tabPage_0.Controls[index]).Check = State;
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void GetOutput(int Index, bool State)
  {
    try
    {
      for (int index = 1; index <= this.tabPage_1.Controls.Count - 1; ++index)
      {
        if (this.tabPage_1.Controls[index].Tag != null && int.Parse(this.tabPage_1.Controls[index].Tag.ToString()) == Index)
          ((buCheckBox) this.tabPage_1.Controls[index]).Check = State;
      }
    }
    catch (Exception ex)
    {
      string str = $"Index: {Index.ToString()} - State: {State.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SetAxisInput(bool Homing, bool PosLim, bool NegLim, bool Capture)
  {
    this.chk_Homing.Check = Homing;
    this.chk_negative.Check = NegLim;
    this.chk_positive.Check = PosLim;
    this.chk_capture.Check = Capture;
  }

  public event EventHandler PageClosing;

  public event JogAxisChangedEventHandler AxisChanged;

  public event SetOutputEventHandler SetOutput;

  public event JogSelectedSettingsModeEventHandler SettingsClick;

  internal void method_6(object sender, EventArgs e)
  {
    this.SelectedTab = this.buTab_0.SelectedIndex;
    if (this.buTab_0.SelectedIndex == 0 | this.buTab_0.SelectedIndex == 1)
    {
      this.buPanel_3.Visible = false;
      this.buButton_2.Visible = false;
    }
    if (this.buTab_0.SelectedIndex != 2)
      return;
    this.buButton_2.Visible = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
