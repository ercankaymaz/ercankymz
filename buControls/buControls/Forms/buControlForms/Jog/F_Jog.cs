// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Jog.F_Jog
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Jog;

public class F_Jog : Form
{
  public int AxisCount = 4;
  public bool ScreenCenter = false;
  public bool FormTopMost = true;
  public int PageWidth = 0;
  public int GroupWidth = 0;
  public double SelectedMolt = 1.0;
  public bool Disablex1000 = false;
  public bool ShowSettingsMenu = true;
  public List<string> AxisChars = new List<string>();
  public List<string> Captions = new List<string>();
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal buLabel buLabel_0;
  public buButton btn_absstop;
  public buButton btn_absgo;
  internal buButton buButton_0;
  public buTab tab_jog;
  public TabPage xtraTabPageSpeed;
  internal buLabel buLabel_1;
  public buButton btn_speedminus;
  public buButton btn_speedplus;
  public buButton btn_speedstop;
  public TabPage xtraTabPagePosition;
  internal buLabel buLabel_2;
  public buButton btn_incminus;
  public buButton btn_incplus;
  public buButton btn_incstop;
  public TabPage xtraTabPageAbsolute;
  public buSpin spn_JogAbsvalue;
  internal buGroup buGroup_0;
  internal buCheckBox buCheckBox_0;
  internal buCheckBox buCheckBox_1;
  internal buCheckBox buCheckBox_2;
  internal buCheckBox buCheckBox_3;
  internal buGround buGround_0;
  public buLabel led_position;
  public buCheckBox btn_ax16;
  public buCheckBox btn_ax15;
  public buCheckBox btn_ax14;
  public buCheckBox btn_ax13;
  public buCheckBox btn_ax12;
  public buCheckBox btn_ax11;
  public buCheckBox btn_ax10;
  public buCheckBox btn_ax9;
  public buCheckBox btn_ax8;
  public buCheckBox btn_ax7;
  public buCheckBox btn_ax6;
  public buCheckBox btn_ax5;
  public buCheckBox btn_ax4;
  public buCheckBox btn_ax3;
  public buCheckBox btn_ax2;
  public buCheckBox btn_ax1;
  internal buButton buButton_1;
  internal buPanel buPanel_0;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buButton buButton_7;
  internal buButton buButton_8;

  public F_Jog() => Class39.smethod_532(this);

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
      this.bool_0 = false;
      this.buButton_1.Visible = this.ShowSettingsMenu;
      if (this.AxisCount <= 4)
      {
        this.Width = 660;
        this.buGroup_0.Width = 150;
      }
      if (this.AxisCount >= 5 & this.AxisCount <= 8)
      {
        this.Width = 810;
        this.buGroup_0.Width = 300;
      }
      if (this.AxisCount >= 9 & this.AxisCount <= 12)
      {
        this.Width = 830;
        this.buGroup_0.Width = 332;
      }
      if (this.AxisCount >= 13 & this.AxisCount <= 16 /*0x10*/)
      {
        this.Width = 830;
        this.buGroup_0.Width = 442;
      }
      if (this.PageWidth > 10 & this.GroupWidth > 10)
      {
        this.Width = this.PageWidth;
        this.buGroup_0.Width = this.GroupWidth;
      }
      if (AppProcess.SelectedAxis < 0)
        AppProcess.SelectedAxis = 0;
      if (this.ScreenCenter)
        this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = this.FormTopMost;
      this.btn_ax1.Visible = false;
      this.btn_ax2.Visible = false;
      this.btn_ax3.Visible = false;
      this.btn_ax4.Visible = false;
      this.btn_ax5.Visible = false;
      this.btn_ax6.Visible = false;
      this.btn_ax7.Visible = false;
      this.btn_ax8.Visible = false;
      this.btn_ax9.Visible = false;
      this.btn_ax10.Visible = false;
      this.btn_ax11.Visible = false;
      this.btn_ax12.Visible = false;
      this.btn_ax13.Visible = false;
      this.btn_ax14.Visible = false;
      this.btn_ax15.Visible = false;
      this.btn_ax16.Visible = false;
      if (this.AxisCount >= 1)
        this.btn_ax1.Visible = true;
      if (this.AxisCount >= 2)
        this.btn_ax2.Visible = true;
      if (this.AxisCount >= 3)
        this.btn_ax3.Visible = true;
      if (this.AxisCount >= 4)
        this.btn_ax4.Visible = true;
      if (this.AxisCount >= 5)
        this.btn_ax5.Visible = true;
      if (this.AxisCount >= 6)
        this.btn_ax6.Visible = true;
      if (this.AxisCount >= 7)
        this.btn_ax7.Visible = true;
      if (this.AxisCount >= 8)
        this.btn_ax8.Visible = true;
      if (this.AxisCount >= 9)
        this.btn_ax9.Visible = true;
      if (this.AxisCount >= 10)
        this.btn_ax10.Visible = true;
      if (this.AxisCount >= 11)
        this.btn_ax11.Visible = true;
      if (this.AxisCount >= 12)
        this.btn_ax12.Visible = true;
      if (this.AxisCount >= 13)
        this.btn_ax13.Visible = true;
      if (this.AxisCount >= 14)
        this.btn_ax14.Visible = true;
      if (this.AxisCount >= 15)
        this.btn_ax15.Visible = true;
      if (this.AxisCount >= 16 /*0x10*/)
        this.btn_ax16.Visible = true;
      this.buCheckBox_3.Check = false;
      this.buCheckBox_2.Check = false;
      this.buCheckBox_2.Check = false;
      this.buCheckBox_0.Check = false;
      if (this.SelectedMolt == 0.001)
        this.buCheckBox_3.Check = true;
      if (this.SelectedMolt == 0.01)
        this.buCheckBox_2.Check = true;
      if (this.SelectedMolt == 0.1)
        this.buCheckBox_1.Check = true;
      if (this.SelectedMolt == 1.0)
        this.buCheckBox_0.Check = true;
      this.btn_ax1.Check = false;
      this.btn_ax2.Check = false;
      this.btn_ax3.Check = false;
      this.btn_ax4.Check = false;
      this.btn_ax5.Check = false;
      this.btn_ax6.Check = false;
      this.btn_ax7.Check = false;
      this.btn_ax8.Check = false;
      this.btn_ax9.Check = false;
      this.btn_ax10.Check = false;
      this.btn_ax11.Check = false;
      this.btn_ax12.Check = false;
      this.btn_ax13.Check = false;
      this.btn_ax14.Check = false;
      this.btn_ax15.Check = false;
      this.btn_ax16.Check = false;
      if (AppProcess.SelectedAxis == 0)
        this.btn_ax1.Check = true;
      if (AppProcess.SelectedAxis == 1)
        this.btn_ax2.Check = true;
      if (AppProcess.SelectedAxis == 2)
        this.btn_ax3.Check = true;
      if (AppProcess.SelectedAxis == 3)
        this.btn_ax4.Check = true;
      if (AppProcess.SelectedAxis == 4)
        this.btn_ax5.Check = true;
      if (AppProcess.SelectedAxis == 5)
        this.btn_ax6.Check = true;
      if (AppProcess.SelectedAxis == 6)
        this.btn_ax7.Check = true;
      if (AppProcess.SelectedAxis == 7)
        this.btn_ax8.Check = true;
      if (AppProcess.SelectedAxis == 8)
        this.btn_ax9.Check = true;
      if (AppProcess.SelectedAxis == 9)
        this.btn_ax10.Check = true;
      if (AppProcess.SelectedAxis == 10)
        this.btn_ax11.Check = true;
      if (AppProcess.SelectedAxis == 11)
        this.btn_ax12.Check = true;
      if (AppProcess.SelectedAxis == 12)
        this.btn_ax13.Check = true;
      if (AppProcess.SelectedAxis == 13)
        this.btn_ax14.Check = true;
      if (AppProcess.SelectedAxis == 14)
        this.btn_ax15.Check = true;
      if (AppProcess.SelectedAxis == 15)
        this.btn_ax16.Check = true;
      this.LoadLanguage();
      if (this.Disablex1000)
        this.buCheckBox_0.Enabled = false;
      this.bool_0 = true;
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
      if (this.AxisChars.Count >= 1)
        this.btn_ax1.Text = this.AxisChars[0];
      if (this.AxisChars.Count >= 2)
        this.btn_ax2.Text = this.AxisChars[1];
      if (this.AxisChars.Count >= 3)
        this.btn_ax3.Text = this.AxisChars[2];
      if (this.AxisChars.Count >= 4)
        this.btn_ax4.Text = this.AxisChars[3];
      if (this.AxisChars.Count >= 5)
        this.btn_ax5.Text = this.AxisChars[4];
      if (this.AxisChars.Count >= 6)
        this.btn_ax6.Text = this.AxisChars[5];
      if (this.AxisChars.Count >= 7)
        this.btn_ax7.Text = this.AxisChars[6];
      if (this.AxisChars.Count >= 8)
        this.btn_ax8.Text = this.AxisChars[7];
      if (this.AxisChars.Count >= 9)
        this.btn_ax9.Text = this.AxisChars[8];
      if (this.AxisChars.Count >= 10)
        this.btn_ax10.Text = this.AxisChars[9];
      if (this.AxisChars.Count >= 11)
        this.btn_ax11.Text = this.AxisChars[10];
      if (this.AxisChars.Count >= 12)
        this.btn_ax12.Text = this.AxisChars[11];
      if (this.AxisChars.Count >= 13)
        this.btn_ax13.Text = this.AxisChars[12];
      if (this.AxisChars.Count >= 14)
        this.btn_ax14.Text = this.AxisChars[13];
      if (this.AxisChars.Count >= 15)
        this.btn_ax15.Text = this.AxisChars[14];
      if (this.AxisChars.Count >= 16 /*0x10*/)
        this.btn_ax16.Text = this.AxisChars[15];
      if (this.Captions.Count < 12)
        return;
      this.Text = this.Captions[0];
      this.buGroup_0.Text = this.Captions[1];
      this.xtraTabPageSpeed.Text = this.Captions[2];
      this.xtraTabPagePosition.Text = this.Captions[3];
      this.xtraTabPageAbsolute.Text = this.Captions[4];
      this.buLabel_1.Text = this.Captions[5];
      this.buLabel_2.Text = this.Captions[6];
      this.buLabel_0.Text = this.Captions[7];
      this.btn_speedplus.Text = this.Captions[8];
      this.btn_speedminus.Text = this.Captions[9];
      this.btn_incplus.Text = this.Captions[8];
      this.btn_incminus.Text = this.Captions[9];
      this.btn_speedstop.Text = this.Captions[10];
      this.btn_absstop.Text = this.Captions[10];
      this.btn_incstop.Text = this.Captions[10];
      this.btn_absgo.Text = this.Captions[11];
      this.buButton_0.Text = this.Captions[12];
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
      Control control = new Control();
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

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      this.bool_0 = false;
      Control control1 = new Control();
      Control control2 = (Control) sender;
      this.btn_ax1.Check = false;
      this.btn_ax2.Check = false;
      this.btn_ax3.Check = false;
      this.btn_ax4.Check = false;
      this.btn_ax5.Check = false;
      this.btn_ax6.Check = false;
      this.btn_ax7.Check = false;
      this.btn_ax8.Check = false;
      this.btn_ax9.Check = false;
      this.btn_ax10.Check = false;
      this.btn_ax11.Check = false;
      this.btn_ax12.Check = false;
      this.btn_ax13.Check = false;
      this.btn_ax14.Check = false;
      this.btn_ax15.Check = false;
      this.btn_ax16.Check = false;
      if (control2.Name == this.btn_ax1.Name)
      {
        AppProcess.SelectedAxis = 0;
        this.btn_ax1.Check = true;
      }
      if (control2.Name == this.btn_ax2.Name)
      {
        AppProcess.SelectedAxis = 1;
        this.btn_ax2.Check = true;
      }
      if (control2.Name == this.btn_ax3.Name)
      {
        AppProcess.SelectedAxis = 2;
        this.btn_ax3.Check = true;
      }
      if (control2.Name == this.btn_ax4.Name)
      {
        AppProcess.SelectedAxis = 3;
        this.btn_ax4.Check = true;
      }
      if (control2.Name == this.btn_ax5.Name)
      {
        AppProcess.SelectedAxis = 4;
        this.btn_ax5.Check = true;
      }
      if (control2.Name == this.btn_ax6.Name)
      {
        AppProcess.SelectedAxis = 5;
        this.btn_ax6.Check = true;
      }
      if (control2.Name == this.btn_ax7.Name)
      {
        AppProcess.SelectedAxis = 6;
        this.btn_ax7.Check = true;
      }
      if (control2.Name == this.btn_ax8.Name)
      {
        AppProcess.SelectedAxis = 7;
        this.btn_ax8.Check = true;
      }
      if (control2.Name == this.btn_ax9.Name)
      {
        AppProcess.SelectedAxis = 8;
        this.btn_ax9.Check = true;
      }
      if (control2.Name == this.btn_ax10.Name)
      {
        AppProcess.SelectedAxis = 9;
        this.btn_ax10.Check = true;
      }
      if (control2.Name == this.btn_ax11.Name)
      {
        AppProcess.SelectedAxis = 10;
        this.btn_ax11.Check = true;
      }
      if (control2.Name == this.btn_ax12.Name)
      {
        AppProcess.SelectedAxis = 11;
        this.btn_ax12.Check = true;
      }
      if (control2.Name == this.btn_ax13.Name)
      {
        AppProcess.SelectedAxis = 12;
        this.btn_ax13.Check = true;
      }
      if (control2.Name == this.btn_ax14.Name)
      {
        AppProcess.SelectedAxis = 13;
        this.btn_ax14.Check = true;
      }
      if (control2.Name == this.btn_ax15.Name)
      {
        AppProcess.SelectedAxis = 14;
        this.btn_ax15.Check = true;
      }
      if (control2.Name == this.btn_ax16.Name)
      {
        AppProcess.SelectedAxis = 15;
        this.btn_ax16.Check = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.jogAxisChangedEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.jogAxisChangedEventHandler_0((object) this, AppProcess.SelectedAxis);
      }
      this.bool_0 = true;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      this.buCheckBox_3.Check = false;
      this.buCheckBox_2.Check = false;
      this.buCheckBox_1.Check = false;
      this.buCheckBox_0.Check = false;
      if (control2.Name == this.buCheckBox_3.Name)
      {
        this.SelectedMolt = 0.001;
        this.buCheckBox_3.Check = true;
      }
      if (control2.Name == this.buCheckBox_2.Name)
      {
        this.SelectedMolt = 0.01;
        this.buCheckBox_2.Check = true;
      }
      if (control2.Name == this.buCheckBox_1.Name)
      {
        this.SelectedMolt = 0.1;
        this.buCheckBox_1.Check = true;
      }
      if (control2.Name == this.buCheckBox_0.Name)
      {
        this.SelectedMolt = 1.0;
        this.buCheckBox_0.Check = true;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.jogMoltChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.jogMoltChangedEventHandler_0((object) this, this.SelectedMolt);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.jogModeChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.jogModeChangedEventHandler_0((object) this, (JogModeType) buGeneral.EnumValueFromInt((object) JogModeType.Velocity, this.tab_jog.SelectedIndex));
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (!(AppBool.TouchPad & this.bool_0) || !(control2.Name == this.spn_JogAbsvalue.Name))
        return;
      buControlCommands.ShowKeyPad((Form) this, (Control) this.spn_JogAbsvalue);
      this.buGround_0.Focus();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
  }

  internal void method_8(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.buButton_8.Name)
        this.buPanel_0.Visible = false;
      if (control2.Name == this.buButton_1.Name)
      {
        if (!this.buPanel_0.Visible)
          this.buPanel_0.Visible = true;
        else
          this.buPanel_0.Visible = false;
      }
      if (control2.Name == this.buButton_5.Name)
      {
        this.buPanel_0.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Moves, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_6.Name)
      {
        this.buPanel_0.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Jog, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_4.Name)
      {
        this.buPanel_0.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Gain, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_3.Name)
      {
        this.buPanel_0.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Drive, AppProcess.SelectedAxis);
        }
      }
      if (control2.Name == this.buButton_2.Name)
      {
        this.buPanel_0.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (this.jogSelectedSettingsModeEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.jogSelectedSettingsModeEventHandler_0(AxisSettingsType.Homing, AppProcess.SelectedAxis);
        }
      }
      if (!(control2.Name == this.buButton_7.Name))
        return;
      this.buPanel_0.Visible = false;
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

  public event EventHandler PageClose;

  public event JogModeChangedEventHandler ModeChanged;

  public event JogAxisChangedEventHandler AxisChanged;

  public event JogMoltChangedEventHandler MoltChanged;

  public event JogSelectedSettingsModeEventHandler SettingsClick;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
