// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.buDialogBoxList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class buDialogBoxList : Form
{
  public string Caption = "List";
  public DialogResult Result = DialogResult.None;
  public List<string> Items = new List<string>();
  public int SelectedIndex = -1;
  public string SelectedItemText = "";
  internal IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  public buButton btn_close;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal ImageList imageList_0;
  internal buListBox buListBox_0;
  internal PictureBox pictureBox_0;

  public buDialogBoxList() => Class39.smethod_521(this);

  public void Init()
  {
    this.buListBox_0.Items.Clear();
    this.buListBox_0.Font = this.Font;
    for (int index = 0; index <= this.Items.Count - 1; ++index)
      this.buListBox_0.Items.Add((object) this.Items[index]);
    if (this.SelectedIndex >= 0 & this.SelectedIndex <= this.buListBox_0.Items.Count - 1)
      this.buListBox_0.SelectedIndex = this.SelectedIndex;
    this.buGround_0.Text = this.Caption;
  }

  public void Init(string Info, int imageindex)
  {
    this.buGround_0.Text = Info;
    if (imageindex >= 0 & imageindex <= this.imageList_0.Images.Count - 1)
    {
      this.pictureBox_0.Image = this.imageList_0.Images[imageindex];
      this.pictureBox_0.Visible = true;
    }
    else
      this.pictureBox_0.Visible = false;
    for (int index = 0; index <= this.Items.Count - 1; ++index)
      this.buListBox_0.Items.Add((object) this.Items[index]);
    if (!(this.SelectedIndex >= 0 & this.SelectedIndex <= this.buListBox_0.Items.Count - 1))
      return;
    this.buListBox_0.SelectedIndex = this.SelectedIndex;
  }

  public void Init(List<string> items, string Info, int imageindex)
  {
    this.buGround_0.Text = Info;
    if (imageindex >= 0 & imageindex <= this.imageList_0.Images.Count - 1)
    {
      this.pictureBox_0.Image = this.imageList_0.Images[imageindex];
      this.pictureBox_0.Visible = true;
    }
    else
      this.pictureBox_0.Visible = false;
    for (int index = 0; index <= items.Count - 1; ++index)
      this.buListBox_0.Items.Add((object) items[index]);
    if (!(this.SelectedIndex >= 0 & this.SelectedIndex <= this.buListBox_0.Items.Count - 1))
      return;
    this.buListBox_0.SelectedIndex = this.SelectedIndex;
  }

  internal void method_0(object sender, EventArgs e)
  {
    this.SelectedIndex = this.buListBox_0.SelectedIndex;
    this.SelectedItemText = this.buListBox_0.Text;
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e) => this.method_0((object) this.buButton_0, e);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
