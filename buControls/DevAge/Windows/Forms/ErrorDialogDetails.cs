// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.ErrorDialogDetails
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class ErrorDialogDetails : Form
{
  internal TextBox textBox_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private Exception exception_0;

  public ErrorDialogDetails() => Class39.smethod_743(this);

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  public Exception Exception
  {
    get => this.exception_0;
    set => this.exception_0 = value;
  }

  public ErrorDialogDetails(Exception p_Exception, string p_Caption)
    : this()
  {
    this.Text = "Error Details - " + p_Caption;
    this.Exception = p_Exception;
  }

  public DialogResult ShowDialog(Exception p_Exception, string p_Caption)
  {
    this.Text = "Error Details - " + p_Caption;
    this.Exception = p_Exception;
    return this.ShowDialog();
  }

  public DialogResult ShowDialog(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
  {
    this.Text = "Error Details - " + p_Caption;
    this.Exception = p_Exception;
    return this.ShowDialog(p_Owner);
  }

  public static void Show(Exception p_Exception, string p_Caption)
  {
    int num = (int) new ErrorDialogDetails(p_Exception, p_Caption).ShowDialog();
  }

  internal void method_0(object sender, EventArgs e)
  {
    try
    {
      if (this.exception_0 != null)
        this.textBox_0.Text = this.exception_0.ToString();
      else
        this.textBox_0.Text = "Exception is null";
    }
    catch (Exception ex)
    {
      this.textBox_0.Text = "Error loading message:" + ex.ToString();
    }
  }

  public static void Show(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
  {
    int num = (int) new ErrorDialogDetails(p_Exception, p_Caption).ShowDialog(p_Owner);
  }
}
