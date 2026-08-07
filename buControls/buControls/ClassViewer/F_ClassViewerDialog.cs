// Decompiled with JetBrains decompiler
// Type: buControls.ClassViewer.F_ClassViewerDialog
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.ClassViewer;

public class F_ClassViewerDialog : Form
{
  public string OkCaption = "Ok";
  public string CancelCaption = "Cancel";
  public string FormCaption = "";
  public List<string> ParCaptions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public double ValuePersentage = 50.0;
  public int DecimalPlace = 3;
  public int CaptionWidthOffset = 0;
  public bool ColorComboBoxMode = false;
  public object Value = (object) null;
  private object object_0 = (object) null;
  private IContainer icontainer_0 = (IContainer) null;
  internal buClassViewer buClassViewer_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_ClassViewerDialog() => Class39.smethod_715(this);

  public void Init()
  {
    if (this.FormCaption.Length > 0)
      this.Text = this.FormCaption;
    if (this.OkCaption.Length > 0)
      this.btn_ok.Text = this.OkCaption;
    if (this.CancelCaption.Length > 0)
      this.btn_cancel.Text = this.CancelCaption;
    buSerilization.CopyClass(this.Value, ref this.object_0);
    this.buClassViewer_0.ClassObject = this.object_0;
    this.buClassViewer_0.RowSpace = 1;
    this.buClassViewer_0.Width = this.Width - 15;
    this.buClassViewer_0.CaptionWidthOffset = this.CaptionWidthOffset;
    this.buClassViewer_0.ColorComboBoxMode = this.ColorComboBoxMode;
    this.buClassViewer_0.Visible = true;
    this.buClassViewer_0.DecimalPlace = this.DecimalPlace;
    this.buClassViewer_0.ValueWidth = Convert.ToInt32((double) this.Width * (this.ValuePersentage / 100.0)) - 8;
    this.buClassViewer_0.ParCaptions.Clear();
    for (int index = 0; index <= this.ParCaptions.Count - 1; ++index)
      this.buClassViewer_0.ParCaptions.Add(this.ParCaptions[index]);
    this.buClassViewer_0.Init();
  }

  internal void method_0(object sender, EventArgs e)
  {
    buSerilization.CopyClass(this.object_0, ref this.Value);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
