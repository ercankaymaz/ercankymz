// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Chars.F_CharList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Chars;

public class F_CharList : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public List<CharLibrary> Chars = new List<CharLibrary>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal CheckedListBox checkedListBox_0;
  public buViewer buViewer1;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_remove;
  public Button btn_add;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;

  public F_CharList() => Class39.smethod_703(this);

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (!(this.Properties.Result != DialogResult.OK & this.Properties.Result != DialogResult.Ignore))
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    List<char> charList = new List<char>();
    for (int index1 = 0; index1 <= (int) ushort.MaxValue; ++index1)
    {
      char c = Convert.ToChar(index1);
      if (!char.IsControl(c))
      {
        string str = c.ToString().Trim();
        if (str.Length == 1 & index1 >= 33 & index1 <= 1260)
        {
          bool isChecked = false;
          for (int index2 = 0; index2 <= this.Chars.Count - 1; ++index2)
          {
            if (this.Chars[index2].Char == str)
              isChecked = true;
          }
          if (isChecked)
            this.checkedListBox_0.Items.Add((object) str, isChecked);
        }
        charList.Add(c);
      }
    }
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.ControlUpdate();
    Class39.smethod_838(this);
  }

  public void ControlUpdate()
  {
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_371(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_add.Name)
      ;
    if (control2.Name == this.btn_remove.Name)
      ;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    bool flag = false;
    if (this.checkedListBox_0.SelectedIndex < 0)
      return;
    if (this.checkedListBox_0.GetItemChecked(this.checkedListBox_0.SelectedIndex))
    {
      for (int index = 0; index <= this.Chars.Count - 1; ++index)
      {
        string str = this.checkedListBox_0.Items[this.checkedListBox_0.SelectedIndex].ToString();
        if (this.Chars[index].Char == str)
        {
          Pnt3D MinPnt = new Pnt3D();
          Pnt3D MaxPnt = new Pnt3D();
          buControlCoreClass.cVector.BoxSizeCalculate(this.Chars[index].CharEntities, ref MinPnt, ref MaxPnt);
          this.buViewer1.Entities.Clear();
          List<eEntities> EEntities = new List<eEntities>();
          geoEntity.GeoEntitiyToEEntity(this.Chars[index].CharEntities, ref EEntities);
          this.buViewer1.AddEntities(EEntities);
          this.buViewer1.DrawEntities();
          this.buViewer1.ZoomFit();
          this.buViewer1.ZoomOut();
          flag = true;
          this.numericUpDown_0.Value = Convert.ToDecimal(MaxPnt.X - MinPnt.X);
          this.numericUpDown_1.Value = Convert.ToDecimal(MaxPnt.Y - MinPnt.Y);
        }
      }
    }
    if (flag)
      return;
    this.buViewer1.Entities.Clear();
    this.buViewer1.DrawEntities();
    this.numericUpDown_0.Value = Convert.ToDecimal(0);
    this.numericUpDown_1.Value = Convert.ToDecimal(0);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
