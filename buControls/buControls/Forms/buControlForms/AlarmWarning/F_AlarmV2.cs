// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.AlarmWarning.F_AlarmV2
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
namespace buControls.Forms.buControlForms.AlarmWarning;

public class F_AlarmV2 : Form
{
  public List<string> Captions = new List<string>();
  public bool FormTopMost = false;
  public bool ScreenCenter = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  public buListBox lst_alarm;
  public buButton btn_alarmreset;

  public F_AlarmV2() => Class39.smethod_445(this);

  public event OkCommandWithDataEventHandler AlarmResetClick;

  internal void method_0(object sender, EventArgs e)
  {
  }

  public void Init(List<AppAlarm> AlarmList)
  {
    try
    {
      this.TopMost = this.FormTopMost;
      this.lst_alarm.Items.Clear();
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
        this.lst_alarm.Items.Add((object) AlarmList[index].Text);
      if (this.ScreenCenter)
        this.StartPosition = FormStartPosition.CenterScreen;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Init(List<string> AlarmList)
  {
    try
    {
      this.TopMost = this.FormTopMost;
      this.lst_alarm.Items.Clear();
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
        this.lst_alarm.Items.Add((object) AlarmList[index]);
      if (this.ScreenCenter)
        this.StartPosition = FormStartPosition.CenterScreen;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count < 2)
        return;
      this.Text = this.Captions[0];
      this.buButton_0.Text = this.Captions[1];
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    try
    {
      e.Cancel = true;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithDataEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithDataEventHandler_0((object) "AlarmReset");
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
