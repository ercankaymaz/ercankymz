// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Helps.F_About
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Helps;

public class F_About : Form
{
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal TextBox textBox_0;
  internal Button button_0;
  internal PictureBox pictureBox_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;

  public F_About() => Class39.smethod_657(this);

  public void Init(
    string ProductName,
    string Version,
    string CopyRight,
    string Company,
    string Description,
    string Title,
    Image img)
  {
    this.Text = Title;
    this.label_0.Text = ProductName;
    this.label_1.Text = Version;
    this.label_2.Text = CopyRight;
    this.label_3.Text = Company;
    this.textBox_0.Text = Description;
    if (img != null)
      this.pictureBox_0.Image = img;
    Class39.smethod_119(this);
  }

  internal void method_0(object sender, EventArgs e) => this.Dispose();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
