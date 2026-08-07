// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Jog.F_JogBasic
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
namespace buControls.Forms.buControlForms.Jog;

public class F_JogBasic : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public List<CodesysAxesData> Axes = new List<CodesysAxesData>();
  public bool ShowSettingsMenu = true;
  public List<string> AxisChars = new List<string>();
  public List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal buLabel buLabel_0;
  public buButton btn_stop;
  public buButton btn_absgo;
  public buTab tab_jog;
  public TabPage tabpage_speed;
  internal buLabel buLabel_1;
  public buButton btn_speedminus;
  public buButton btn_speedplus;
  public TabPage tabpage_incremental;
  internal buLabel buLabel_2;
  public buButton btn_incminus;
  public buButton btn_incplus;
  public TabPage tabpage_absolute;
  public buSpin spn_abspos;
  internal buGroup buGroup_0;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buComboBox buComboBox_0;
  internal ImageList imageList_0;
  internal buButton buButton_1;
  internal buSeparator buSeparator_0;
  public buSpin spn_actspeed;
  public buSpin spn_actpos;
  public buButton btn_axisselectminus;
  public buButton btn_axisselectplus;
  public buSpin spn_incpos;
  internal buComboBox buComboBox_1;
  internal TabPage tabPage_0;
  public buSpin spn_autopos2;
  public buButton btn_auto;
  public buSpin spn_autopos1;
  internal buLabel buLabel_3;
  public buSpin spn_autowaittime;
  internal buLabel buLabel_4;
  internal buLabel buLabel_5;
  internal buLabel buLabel_6;
  internal buLabel buLabel_7;
  internal buLabel buLabel_8;
  internal buLabel buLabel_9;
  internal buLabel buLabel_10;
  public buButton btn_homing;
  public buLabel lbl_enableled;
  public buPanel pnl_error;
  public buLabel lbl_ledpositivelimit;
  public buLabel lbl_lednegativelimit;
  public buLabel lbl_ledcapture;
  public buLabel lbl_ledhoming;
  public buLabel lbl_homeled;
  internal buLabel buLabel_11;

  public F_JogBasic() => Class39.smethod_619(this);

  public event EventHandler PageClose;

  public event JogSelectedSettingsModeEventHandler SettingsClick;

  public event JogCommandEventHandler Command;

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    try
    {
      e.Cancel = true;
      this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, new EventArgs());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void Init()
  {
    try
    {
      this.PropertiesForm.Inited = false;
      if (this.PropertiesForm.Height > 10)
        this.Height = this.PropertiesForm.Height;
      if (this.PropertiesForm.Width > 10)
        this.Width = this.PropertiesForm.Width;
      this.TopMost = this.PropertiesForm.TopMost;
      this.StartPosition = this.PropertiesForm.FormPosition;
      this.buButton_0.Visible = this.ShowSettingsMenu;
      if (AppProcess.SelectedAxis < 0)
        AppProcess.SelectedAxis = 0;
      this.buComboBox_0.Items.Clear();
      for (int index = 0; index <= this.Axes.Count - 1; ++index)
        this.buComboBox_0.Items.Add((object) $"{(index + 1).ToString()}-{this.Axes[index].AxisPar.Base.baseName}");
      if (AppProcess.SelectedAxis <= this.Axes.Count - 1)
        this.buComboBox_0.SelectedIndex = AppProcess.SelectedAxis;
      this.buComboBox_1.Items.Clear();
      this.buComboBox_1.Items.Add((object) 10);
      this.buComboBox_1.Items.Add((object) 1);
      this.buComboBox_1.Items.Add((object) 0.1);
      this.buComboBox_1.Items.Add((object) 0.01);
      this.buComboBox_1.Items.Add((object) 0.001);
      this.buComboBox_1.SelectedIndex = 1;
      this.LoadLanguage();
      this.PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count < 12)
        return;
      this.Text = this.Captions[0];
      this.buGroup_0.Text = this.Captions[1];
      this.tabpage_speed.Text = this.Captions[2];
      this.tabpage_incremental.Text = this.Captions[3];
      this.tabpage_absolute.Text = this.Captions[4];
      this.buLabel_1.Text = this.Captions[5];
      this.buLabel_2.Text = this.Captions[6];
      this.buLabel_0.Text = this.Captions[7];
      this.btn_speedplus.Text = this.Captions[8];
      this.btn_speedminus.Text = this.Captions[9];
      this.btn_incplus.Text = this.Captions[8];
      this.btn_incminus.Text = this.Captions[9];
      this.btn_stop.Text = this.Captions[10];
      this.btn_absgo.Text = this.Captions[11];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
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
      Control control = new Control();
      if (AppBool.TouchPad & this.PropertiesForm.Inited)
        ;
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
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(AppBool.TouchPad & this.PropertiesForm.Inited) || !(control2.Name == this.spn_abspos.Name))
      return;
    buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_abspos);
    this.buGround_0.Focus();
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_1.Name)
      {
        this.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.eventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.eventHandler_0(sender, e);
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.buButton_0.Name && this.jogSelectedSettingsModeEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.All, AppProcess.SelectedAxis);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_homing.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.Home,
          SelectedAxis = this.buComboBox_0.SelectedIndex
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_stop.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.Stop,
          SelectedAxis = this.buComboBox_0.SelectedIndex
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_absgo.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.Absolute,
          Position = this.spn_abspos.Value,
          SelectedAxis = this.buComboBox_0.SelectedIndex
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_incplus.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.Incremental,
          IncrementalPosition = this.spn_incpos.Value,
          SelectedAxis = this.buComboBox_0.SelectedIndex,
          Direction = 1.0
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_incminus.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.Incremental,
          IncrementalPosition = this.spn_incpos.Value,
          SelectedAxis = this.buComboBox_0.SelectedIndex,
          Direction = -1.0
        });
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.btn_auto.Name && this.jogCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
        {
          Command = JogCommandType.AutoTest,
          Position1 = this.spn_autopos1.Value,
          Position2 = this.spn_autopos2.Value,
          SelectedAxis = this.buComboBox_0.SelectedIndex,
          Direction = 1.0
        });
      }
      if (control2.Name == this.btn_axisselectminus.Name && this.buComboBox_0.SelectedIndex > 0)
      {
        --this.buComboBox_0.SelectedIndex;
        AppProcess.SelectedAxis = this.buComboBox_0.SelectedIndex;
      }
      if (!(control2.Name == this.btn_axisselectplus.Name) || this.buComboBox_0.SelectedIndex >= this.buComboBox_0.Items.Count - 1)
        return;
      ++this.buComboBox_0.SelectedIndex;
      AppProcess.SelectedAxis = this.buComboBox_0.SelectedIndex;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_6(object sender, MouseEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_speedminus.Name && this.jogCommandEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
      {
        Command = JogCommandType.VelocityMinus,
        SelectedAxis = this.buComboBox_0.SelectedIndex
      });
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.btn_speedplus.Name) || this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.VelocityPlus,
      SelectedAxis = this.buComboBox_0.SelectedIndex
    });
  }

  internal void method_7(object sender, MouseEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.JogStop,
      SelectedAxis = this.buComboBox_0.SelectedIndex
    });
  }

  internal void method_8(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.jogCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.jogCommandEventHandler_0(sender, new JogCommandEventArg()
    {
      Command = JogCommandType.JogStop,
      SelectedAxis = this.buComboBox_0.SelectedIndex
    });
  }

  internal void method_9(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buComboBox_0.Name && this.PropertiesForm.Inited && this.buComboBox_0.SelectedIndex >= 0 && this.Axes[this.buComboBox_0.SelectedIndex].AxisPar.Base.baseNo >= 0)
    {
      AppProcess.SelectedAxis = this.buComboBox_0.SelectedIndex;
      this.buComboBox_0.Invalidate();
    }
    if (!(control2.Name == this.buComboBox_1.Name) || !this.PropertiesForm.Inited || this.buComboBox_1.SelectedIndex < 0)
      return;
    this.spn_incpos.Value = Convert.ToDouble(this.buComboBox_1.Text);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
