// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.DialogBoxList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class DialogBoxList : Form
{
  public string FormCaption = "List";
  public string Caption = "List";
  public DialogResult Result = DialogResult.None;
  public List<string> Items = new List<string>();
  public int SelectedIndex = -1;
  public string SelectedItemText = "";
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList imageList_0;
  internal PictureBox pictureBox_0;
  internal ImageList imageList_1;
  internal Label label_0;
  public ListBox lst_items;

  public DialogBoxList() => Class39.smethod_318(this);

  public void Init()
  {
    this.lst_items.Items.Clear();
    this.lst_items.Font = this.Font;
    for (int index = 0; index <= this.Items.Count - 1; ++index)
      this.lst_items.Items.Add((object) this.Items[index]);
    if (this.SelectedIndex >= 0 & this.SelectedIndex <= this.lst_items.Items.Count - 1)
      this.lst_items.SelectedIndex = this.SelectedIndex;
    this.Text = this.Caption;
  }

  public void Init(string Info, int imageindex)
  {
    if (Info.Trim().Length > 0)
      this.label_0.Visible = true;
    else
      this.label_0.Visible = false;
    this.label_0.Text = Info;
    if (imageindex >= 0 & imageindex <= this.imageList_1.Images.Count - 1)
    {
      this.pictureBox_0.Image = this.imageList_1.Images[imageindex];
      this.pictureBox_0.Visible = true;
    }
    else
      this.pictureBox_0.Visible = false;
    for (int index = 0; index <= this.Items.Count - 1; ++index)
      this.lst_items.Items.Add((object) this.Items[index]);
    if (this.SelectedIndex >= 0 & this.SelectedIndex <= this.lst_items.Items.Count - 1)
      this.lst_items.SelectedIndex = this.SelectedIndex;
    this.Text = this.Caption;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.SelectedIndex = this.lst_items.SelectedIndex;
    this.SelectedItemText = this.lst_items.Text;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e) => this.method_0((object) this.btn_ok, e);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
