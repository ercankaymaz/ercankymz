// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Report.F_Report
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
namespace buControls.Forms.WinControlForms.Report;

public class F_Report : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public ReportProgram Report = new ReportProgram();
  public string strName = "You Must Enter Your Name";
  public string strMail = "You Must Enter Your Contact Mail";
  public string strMailError = "You Mail Address is not correct format";
  public string strCompany = "You Must Enter Your Company Name";
  public string strBuy = "You Must Enter Where did You Buy Information";
  public string strExplanation = "You Must Enter Your Explanation and Comments";
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_send;
  internal TextBox textBox_0;
  internal Label label_0;
  internal TextBox textBox_1;
  internal Label label_1;
  internal TextBox textBox_2;
  internal Label label_2;
  internal TextBox textBox_3;
  internal Label label_3;
  internal TextBox textBox_4;
  internal Label label_4;

  public F_Report() => Class39.smethod_622(this);

  public void Init()
  {
    this.textBox_2.Text = this.Report.Buy;
    this.textBox_1.Text = this.Report.Company;
    this.textBox_3.Text = this.Report.email;
    this.textBox_0.Text = this.Report.Name;
    this.Result = DialogResult.None;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "Report LoadLanguage";
    try
    {
      if (F_Report.Captions.Count < 8)
        return;
      this.Text = F_Report.Captions[0];
      this.label_0.Text = F_Report.Captions[1];
      this.label_1.Text = F_Report.Captions[2];
      this.label_2.Text = F_Report.Captions[3];
      this.label_3.Text = F_Report.Captions[4];
      this.label_4.Text = F_Report.Captions[5];
      this.btn_send.Text = F_Report.Captions[6];
      this.btn_cancel.Text = F_Report.Captions[7];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    if (this.textBox_0.Text.Trim().Length <= 0)
    {
      int num1 = (int) MessageBox.Show(this.strName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else if (this.textBox_3.Text.Trim().Length <= 0)
    {
      int num2 = (int) MessageBox.Show(this.strMail, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else if (this.textBox_1.Text.Trim().Length <= 0)
    {
      int num3 = (int) MessageBox.Show(this.strCompany, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else if (this.textBox_2.Text.Trim().Length <= 0)
    {
      int num4 = (int) MessageBox.Show(this.strBuy, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else if (this.textBox_4.Text.Trim().Length <= 0)
    {
      int num5 = (int) MessageBox.Show(this.strExplanation, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else if (!buNet.IsValidEmail(this.textBox_3.Text.Trim()))
    {
      int num6 = (int) MessageBox.Show(this.strMailError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    else
    {
      this.Report = new ReportProgram();
      this.Report.Name = this.textBox_0.Text.Trim();
      this.Report.Company = this.textBox_1.Text.Trim();
      this.Report.email = this.textBox_3.Text.Trim();
      this.Report.Buy = this.textBox_2.Text.Trim();
      this.Report.Explanation = this.textBox_4.Text.Trim();
      this.Result = DialogResult.OK;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
