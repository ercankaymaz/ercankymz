// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.AlarmWarning.F_Warning
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

public class F_Warning : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public bool ShowReset = true;
  public bool ShowOk = false;
  internal IContainer icontainer_0 = (IContainer) null;
  public ListBox lst_warnig;
  public Button btn_alarmreset;
  public Button btn_close;
  internal ImageList imageList_0;
  public Button btn_ok;

  public F_Warning() => Class39.smethod_332(this);

  public void Init(List<AppWarning> WarningList)
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
      this.lst_warnig.Items.Clear();
      for (int index = 0; index <= WarningList.Count - 1; ++index)
        this.lst_warnig.Items.Add((object) $"{WarningList[index].Text}ID: {WarningList[index].ID.ToString()}");
      this.btn_alarmreset.Visible = this.ShowReset;
      this.btn_ok.Visible = this.ShowOk;
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Init(List<string> WarningList)
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
      this.lst_warnig.Items.Clear();
      this.lst_warnig.Items.Clear();
      for (int index = 0; index <= WarningList.Count - 1; ++index)
        this.lst_warnig.Items.Add((object) WarningList[index]);
      this.btn_alarmreset.Visible = this.ShowReset;
      this.btn_ok.Visible = this.ShowOk;
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
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
      if (F_Warning.Captions.Count < 3)
        return;
      this.Text = F_Warning.Captions[0];
      this.btn_alarmreset.Text = F_Warning.Captions[1];
      this.btn_close.Text = F_Warning.Captions[2];
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
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
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

  internal void method_3(object sender, EventArgs e)
  {
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event EventHandler WarningResetClick;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
