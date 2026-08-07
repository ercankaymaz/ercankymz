// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.License.F_AskLicense
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.License;

public class F_AskLicense : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public ReportProgram Report = new ReportProgram();
  public string strName = "You Must Enter Your Name";
  public string strMail = "You Must Enter Your Contact Mail";
  public string strMailError = "You Mail Address is not correct format";
  public string strCompany = "You Must Enter Your Company Name";
  public string strExplanation = "You Must Enter Your Explanation and Comments";
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal TextBox textBox_0;
  internal Label label_0;
  internal TextBox textBox_1;
  internal Label label_1;
  internal TextBox textBox_2;
  internal Label label_2;
  internal TextBox textBox_3;
  internal Label label_3;
  public Button btn_cancel;
  public Button btn_send;

  public F_AskLicense() => Class39.smethod_618(this);

  public void Init()
  {
    this.textBox_2.Text = this.Report.Company;
    this.textBox_1.Text = this.Report.email;
    this.textBox_3.Text = this.Report.Name;
    this.Properties.Result = DialogResult.None;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "Report LoadLanguage";
    try
    {
      if (F_AskLicense.Captions.Count < 7)
        return;
      this.Text = F_AskLicense.Captions[0];
      this.label_3.Text = F_AskLicense.Captions[1];
      this.label_2.Text = F_AskLicense.Captions[2];
      this.label_1.Text = F_AskLicense.Captions[3];
      this.label_0.Text = F_AskLicense.Captions[4];
      this.btn_send.Text = F_AskLicense.Captions[5];
      this.btn_cancel.Text = F_AskLicense.Captions[6];
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
    string callMethod = "Report F_Report_FormClosing";
    try
    {
      if (this.Properties.Result == DialogResult.OK)
        return;
      e.Cancel = true;
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
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
    string callMethod = "Report btn_cancel_Click";
    try
    {
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void method_2(object sender, EventArgs e)
  {
    string callMethod = "Report btn_send_Click";
    try
    {
      if (this.textBox_3.Text.Trim().Length <= 0)
      {
        int num = (int) MessageBox.Show(this.strName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      if (this.textBox_1.Text.Trim().Length <= 0)
      {
        int num = (int) MessageBox.Show(this.strMail, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      if (this.textBox_2.Text.Trim().Length <= 0)
      {
        int num = (int) MessageBox.Show(this.strCompany, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      if (!buNet.IsValidEmail(this.textBox_1.Text.Trim()))
      {
        int num = (int) MessageBox.Show(this.strMailError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
    this.Report = new ReportProgram();
    this.Report.Name = this.textBox_3.Text.Trim();
    this.Report.Company = this.textBox_2.Text.Trim();
    this.Report.email = this.textBox_1.Text.Trim();
    this.Report.Explanation = this.textBox_0.Text.Trim();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
