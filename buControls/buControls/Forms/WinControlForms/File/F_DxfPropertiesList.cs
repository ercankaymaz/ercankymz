// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.File.F_DxfPropertiesList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.File;

public class F_DxfPropertiesList : Form
{
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  public List<Cf2FileProperties> Cf2Properties = new List<Cf2FileProperties>();
  public string pathCf2File = Application.StartupPath;
  public string fileCf2SettingsName = "";
  public string strRemoveCaption = "Do You Want to Remove Item";
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal ListBox listBox_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_add;
  public Button btn_remove;
  public Button btn_down;
  public Button btn_up;
  public Button btn_copy;
  public Button btn_save;
  public Button btn_open;
  public Button btn_update;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal CheckBox checkBox_0;
  internal TextBox textBox_0;
  internal ComboBox comboBox_0;
  internal CheckBox checkBox_1;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal Label label_11;
  internal Label label_12;
  internal Label label_13;
  internal Label label_14;
  internal NumericUpDown numericUpDown_4;
  internal Label label_15;

  public F_DxfPropertiesList() => Class39.smethod_140(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    Class39.smethod_180(this);
    Class39.smethod_271(this);
    Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) cf2FileProperties.CodeType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) cf2FileProperties.CodeType), ref this.comboBox_0);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_add.Name)
    {
      Cf2FileProperties cf2FileProperties_0 = new Cf2FileProperties();
      Class39.smethod_15(ref cf2FileProperties_0, this);
      this.Cf2Properties.Add(cf2FileProperties_0);
      this.listBox_0.Items.Add((object) cf2FileProperties_0.Explanation);
    }
    if (control2.Name == this.btn_remove.Name && this.listBox_0.SelectedIndex >= 0 && buString.MessageBoxQuestion($"{this.strRemoveCaption}  {this.listBox_0.Text}") == DialogResult.Yes)
    {
      this.Cf2Properties.RemoveAt(this.listBox_0.SelectedIndex);
      this.listBox_0.Items.RemoveAt(this.listBox_0.SelectedIndex);
    }
    if (control2.Name == this.btn_copy.Name)
    {
      Cf2FileProperties cf2FileProperties = new Cf2FileProperties(this.Cf2Properties[this.listBox_0.SelectedIndex]);
      this.Cf2Properties.Add(cf2FileProperties);
      this.listBox_0.Items.Add((object) cf2FileProperties.Explanation);
    }
    if (control2.Name == this.btn_up.Name && this.listBox_0.SelectedIndex > 0 & this.Cf2Properties.Count >= 2)
    {
      int selectedIndex = this.listBox_0.SelectedIndex;
      Cf2FileProperties cf2FileProperties = new Cf2FileProperties(this.Cf2Properties[this.listBox_0.SelectedIndex]);
      this.Cf2Properties.RemoveAt(this.listBox_0.SelectedIndex);
      this.Cf2Properties.Insert(this.listBox_0.SelectedIndex - 1, cf2FileProperties);
      int num = selectedIndex - 1;
      Class39.smethod_271(this);
      this.listBox_0.SelectedIndex = num;
    }
    if (control2.Name == this.btn_down.Name && this.listBox_0.SelectedIndex < this.Cf2Properties.Count - 1)
    {
      int selectedIndex = this.listBox_0.SelectedIndex;
      Cf2FileProperties cf2FileProperties = new Cf2FileProperties(this.Cf2Properties[this.listBox_0.SelectedIndex]);
      this.Cf2Properties.RemoveAt(selectedIndex);
      this.Cf2Properties.Insert(selectedIndex + 1, cf2FileProperties);
      int num = selectedIndex + 1;
      Class39.smethod_271(this);
      this.listBox_0.SelectedIndex = num;
    }
    if (control2.Name == this.btn_update.Name && this.PropertiesForm.Inited && this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Cf2Properties.Count - 1)
    {
      Cf2FileProperties cf2FileProperties_0 = new Cf2FileProperties();
      Class39.smethod_15(ref cf2FileProperties_0, this);
      this.Cf2Properties[this.listBox_0.SelectedIndex] = cf2FileProperties_0;
      this.listBox_0.Items[this.listBox_0.SelectedIndex] = (object) this.Cf2Properties[this.listBox_0.SelectedIndex].Explanation;
    }
    if (control2.Name == this.btn_save.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = this.pathCf2File;
      saveFileDialog.Filter = "CF2 Type Settings File (*.bucf2set)|*.bucf2set";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        this.fileCf2SettingsName = saveFileDialog.FileName;
        this.pathCf2File = buFile.GetPath(saveFileDialog.FileName);
        buFile.Cf2.SaveCf2Properties(saveFileDialog.FileName, this.Cf2Properties);
      }
    }
    if (!(control2.Name == this.btn_open.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = this.pathCf2File;
    openFileDialog.Filter = "CF2 Type Settings File (*.bucf2set)|*.bucf2set";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    this.fileCf2SettingsName = openFileDialog.FileName;
    this.pathCf2File = buFile.GetPath(openFileDialog.FileName);
    buFile.Cf2.OpenCf2Properties(openFileDialog.FileName, ref this.Cf2Properties);
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Cf2Properties.Count - 1; ++index)
      this.listBox_0.Items.Add((object) this.Cf2Properties[index].Explanation);
  }

  internal void method_1(object sender, FormClosingEventArgs e)
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

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited || !(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Cf2Properties.Count - 1))
      return;
    this.ValueToControls(new Cf2FileProperties(this.Cf2Properties[this.listBox_0.SelectedIndex]));
  }

  public void ValueToControls(Cf2FileProperties props)
  {
    this.numericUpDown_4.Value = (Decimal) props.ToolNo;
    this.numericUpDown_1.Value = (Decimal) props.PtIndex;
    this.numericUpDown_0.Value = (Decimal) props.PtRealValue;
    this.label_3.BackColor = props.MatchColor;
    this.numericUpDown_2.Value = (Decimal) props.SelectedThickness;
    this.numericUpDown_3.Value = (Decimal) props.Thickness;
    this.textBox_0.Text = props.Explanation;
    this.checkBox_0.Checked = props.Selectable;
    this.checkBox_1.Checked = props.Visible;
    this.label_2.BackColor = props.Color;
    this.label_1.BackColor = props.SelectedColor;
    this.comboBox_0.SelectedIndex = Convert.ToInt32((object) props.CodeType);
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.label_2.Name)
    {
      ColorDialogBox.ShowDialog(this.label_2.BackColor);
      if (ColorDialogBox.Result == DialogResult.OK)
      {
        this.label_2.BackColor = ColorDialogBox.Color;
        this.label_2.ForeColor = buImage.InvertColorNoGray(this.label_2.BackColor);
        this.label_2.Text = buImage.GetColorKnownName(this.label_2.BackColor);
      }
    }
    if (control2.Name == this.label_1.Name)
    {
      ColorDialogBox.ShowDialog(this.label_2.BackColor);
      if (ColorDialogBox.Result == DialogResult.OK)
      {
        this.label_1.BackColor = ColorDialogBox.Color;
        this.label_1.ForeColor = buImage.InvertColorNoGray(this.label_1.BackColor);
        this.label_1.Text = buImage.GetColorKnownName(this.label_1.BackColor);
      }
    }
    if (!(control2.Name == this.label_3.Name))
      return;
    ColorDialogBox.ShowDialog(this.label_3.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    this.label_3.BackColor = ColorDialogBox.Color;
    this.label_3.ForeColor = buImage.InvertColorNoGray(this.label_3.BackColor);
    this.label_3.Text = buImage.GetColorKnownName(this.label_3.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
