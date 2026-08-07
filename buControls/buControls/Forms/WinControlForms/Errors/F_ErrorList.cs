// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Errors.F_ErrorList
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
namespace buControls.Forms.WinControlForms.Errors;

public class F_ErrorList : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer icontainer_0 = (IContainer) null;
  public ListBox lst_alarm;
  public Button btn_close;

  public F_ErrorList() => Class39.smethod_219(this);

  public void Init(List<CalculationError> AlarmList, bool UseJustText)
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
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
      {
        if (!UseJustText)
          this.lst_alarm.Items.Add((object) $"{AlarmList[index].Explanation}ID: {AlarmList[index].ID.ToString()}");
        else
          this.lst_alarm.Items.Add((object) AlarmList[index].Explanation);
      }
      this.LoadLanguage();
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Init(List<CalculationError> AlarmList)
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
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
        this.lst_alarm.Items.Add((object) AlarmList[index].Explanation);
      this.LoadLanguage();
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
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
      this.PropertiesForm.Inited = false;
      if (this.PropertiesForm.Height > 10)
        this.Height = this.PropertiesForm.Height;
      if (this.PropertiesForm.Width > 10)
        this.Width = this.PropertiesForm.Width;
      this.TopMost = this.PropertiesForm.TopMost;
      this.StartPosition = this.PropertiesForm.FormPosition;
      for (int index = 0; index <= AlarmList.Count - 1; ++index)
        this.lst_alarm.Items.Add((object) AlarmList[index]);
      this.LoadLanguage();
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
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
      if (F_ErrorList.Captions.Count < 3)
        return;
      this.Text = F_ErrorList.Captions[0];
      this.btn_close.Text = F_ErrorList.Captions[2];
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    string callMethod = "Report F_Report_FormClosing";
    try
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
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
