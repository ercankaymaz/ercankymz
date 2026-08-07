// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.AlarmWarning.F_Alarm
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.AlarmWarning;

public class F_Alarm : Form
{
  public static List<string> Captions = new List<string>();
  public bool FormTopMost = false;
  public bool ScreenCenter = false;
  private IContainer icontainer_0 = (IContainer) null;
  public ListBox lst_alarm;
  public Button btn_alarmreset;
  public Button btn_close;

  public F_Alarm() => Class39.smethod_218(this);

  public void Init(List<AppAlarm> AlarmList, bool UseJustText)
  {
    try
    {
      this.TopMost = this.FormTopMost;
      this.lst_alarm.Items.Clear();
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
      {
        if (!UseJustText)
          this.lst_alarm.Items.Add((object) $"{AlarmList[index].Text}ID: {AlarmList[index].ID.ToString()}");
        else
          this.lst_alarm.Items.Add((object) AlarmList[index].Text);
      }
      if (!this.ScreenCenter)
        return;
      this.StartPosition = FormStartPosition.CenterScreen;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Init(List<AppAlarm> AlarmList)
  {
    try
    {
      this.TopMost = this.FormTopMost;
      this.lst_alarm.Items.Clear();
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
        this.lst_alarm.Items.Add((object) $"{AlarmList[index].Text}ID: {AlarmList[index].ID.ToString()}");
      if (!this.ScreenCenter)
        return;
      this.StartPosition = FormStartPosition.CenterScreen;
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
      if (F_Alarm.Captions.Count < 3)
        return;
      this.Text = F_Alarm.Captions[0];
      this.btn_alarmreset.Text = F_Alarm.Captions[1];
      this.btn_close.Text = F_Alarm.Captions[2];
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
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

  internal void method_1(object sender, EventArgs e)
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

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.eventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0((object) this, e);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public event EventHandler AlarmResetClick;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
