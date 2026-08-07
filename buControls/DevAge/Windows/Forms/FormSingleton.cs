// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.FormSingleton
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class FormSingleton
{
  private System.Type p_FormType;
  private object[] p_Args;
  private Form form_0 = (Form) null;

  public FormSingleton(System.Type p_FormType, object[] p_Args)
  {
    this.p_FormType = p_FormType;
    this.p_Args = p_Args;
  }

  public Form GetForm()
  {
    if (this.form_0 == null)
    {
      this.form_0 = (Form) Activator.CreateInstance(this.p_FormType, this.p_Args);
      this.form_0.CreateControl();
      this.form_0.Closed += new EventHandler(this.form_0_Closed);
    }
    return this.form_0;
  }

  public bool IsFormCreated => this.form_0 != null;

  private void form_0_Closed(object sender, EventArgs e)
  {
    this.form_0.Closed -= new EventHandler(this.form_0_Closed);
    this.form_0 = (Form) null;
  }
}
