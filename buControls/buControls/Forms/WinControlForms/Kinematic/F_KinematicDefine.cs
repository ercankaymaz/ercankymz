// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Kinematic.F_KinematicDefine
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Kinematic;

public class F_KinematicDefine : Form
{
  public static List<string> Captions = new List<string>();
  public KinematicBase KinematicSettings = new KinematicBase();
  public DialogResult Result = DialogResult.None;
  public string LoadedKinematicFileName = "";
  public string PathKinematic = Application.StartupPath;
  public List<eEntities> CreatedEntities = new List<eEntities>();
  public bool SelectEntities = false;
  public bool SaveWithOkButton = false;
  private IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  public Button btn_save;
  internal Label label_0;
  internal TextBox textBox_0;
  internal ComboBox comboBox_0;
  internal Label label_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_0;
  internal Panel panel_0;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal NumericUpDown numericUpDown_5;
  internal Label label_4;
  internal NumericUpDown numericUpDown_6;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal NumericUpDown numericUpDown_7;
  internal NumericUpDown numericUpDown_8;
  internal Label label_8;
  internal Panel panel_1;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal Label label_9;
  internal NumericUpDown numericUpDown_11;
  internal NumericUpDown numericUpDown_12;
  internal NumericUpDown numericUpDown_13;
  internal Label label_10;
  internal NumericUpDown numericUpDown_14;
  internal Label label_11;
  internal Label label_12;
  internal Label label_13;
  internal NumericUpDown numericUpDown_15;
  internal NumericUpDown numericUpDown_16;
  internal Label label_14;
  internal Label label_15;
  internal NumericUpDown numericUpDown_17;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_18;
  internal NumericUpDown numericUpDown_19;
  internal Label label_16;
  internal NumericUpDown numericUpDown_20;
  internal NumericUpDown numericUpDown_21;
  internal NumericUpDown numericUpDown_22;
  internal Label label_17;
  internal NumericUpDown numericUpDown_23;
  internal Label label_18;
  internal Label label_19;
  internal Label label_20;
  internal NumericUpDown numericUpDown_24;
  internal NumericUpDown numericUpDown_25;
  internal Label label_21;
  internal Label label_22;
  internal NumericUpDown numericUpDown_26;
  internal Panel panel_3;
  internal Label label_23;
  internal Label label_24;
  internal Label label_25;
  internal NumericUpDown numericUpDown_27;
  internal Label label_26;
  internal NumericUpDown numericUpDown_28;
  internal NumericUpDown numericUpDown_29;
  internal Label label_27;
  internal NumericUpDown numericUpDown_30;
  internal NumericUpDown numericUpDown_31;
  internal Label label_28;
  internal Label label_29;
  internal NumericUpDown numericUpDown_32;
  internal PictureBox pictureBox_0;
  internal Panel panel_4;
  internal Label label_30;
  internal Panel panel_5;
  public Button btn_selectentities;
  internal Label label_31;
  internal ListBox listBox_0;
  internal Label label_32;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal Label label_33;
  internal Label label_34;
  internal buColorComboBox buColorComboBox_0;
  internal Label label_35;
  internal TextBox textBox_1;
  public Button btn_open;
  public Button btn_ok;
  internal Button button_0;
  internal Button button_1;

  public F_KinematicDefine() => Class39.smethod_152(this);

  public event CreatMachineEventHandler CreatMachine;

  public void Init()
  {
    this.numericUpDown_32.Value = (Decimal) this.KinematicSettings.OffsetXYZ.X;
    this.numericUpDown_30.Value = (Decimal) this.KinematicSettings.OffsetXYZ.Y;
    this.numericUpDown_28.Value = (Decimal) this.KinematicSettings.OffsetXYZ.Z;
    this.numericUpDown_31.Value = (Decimal) this.KinematicSettings.OffsetABC.A;
    this.numericUpDown_29.Value = (Decimal) this.KinematicSettings.OffsetABC.B;
    this.numericUpDown_27.Value = (Decimal) this.KinematicSettings.OffsetABC.C;
    this.numericUpDown_17.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.X;
    this.numericUpDown_16.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.Y;
    this.numericUpDown_15.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.Z;
    this.numericUpDown_14.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.X;
    this.numericUpDown_13.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.Y;
    this.numericUpDown_12.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.Z;
    this.numericUpDown_11.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.X;
    this.numericUpDown_10.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.Y;
    this.numericUpDown_9.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.Z;
    this.textBox_0.Text = this.KinematicSettings.Name;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.KinematicSettings.Type, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.KinematicSettings.Type), ref this.comboBox_0);
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.KinematicSettings.Items.Count - 1; ++index)
      this.listBox_0.Items.Add((object) this.KinematicSettings.Items[index]);
    if (this.listBox_0.Items.Count > 0)
      this.listBox_0.SelectedIndex = 0;
    Class39.smethod_457(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Class39.smethod_98(this);
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = this.PathKinematic;
    saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buFile.SaveKinematicFile(saveFileDialog.FileName, this.KinematicSettings);
  }

  internal void method_1(object sender, EventArgs e)
  {
    Class39.smethod_98(this);
    if (this.SaveWithOkButton && new FileInfo(this.LoadedKinematicFileName).Exists)
      buFile.SaveKinematicFile(this.LoadedKinematicFileName, this.KinematicSettings);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_3(object sender, EventArgs e)
  {
    Class39.smethod_98(this);
    this.Result = DialogResult.OK;
    this.SelectEntities = true;
    this.Dispose();
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!(this.listBox_0.SelectedItem.GetType() == typeof (KinematicItem)))
      return;
    this.checkBox_5.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.X;
    this.checkBox_4.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.Y;
    this.checkBox_3.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.Z;
    this.checkBox_2.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.A;
    this.checkBox_1.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.B;
    this.checkBox_0.Checked = ((KinematicItem) this.listBox_0.SelectedItem).Axis.C;
    this.buColorComboBox_0.Color = ((KinematicItem) this.listBox_0.SelectedItem).Color;
    this.textBox_1.Text = ((KinematicItem) this.listBox_0.SelectedItem).PartName;
  }

  internal void method_5(object sender, EventArgs e)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = this.PathKinematic;
    openFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
    openFileDialog.Multiselect = false;
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    this.PathKinematic = buFile.GetPath(openFileDialog.FileName);
    buFile.OpenKinemticFile(openFileDialog.FileName, ref this.KinematicSettings);
    this.LoadedKinematicFileName = buFile.getFileName(openFileDialog.FileName);
    this.Init();
  }

  internal void method_6(object sender, EventArgs e)
  {
    this.listBox_0.Items.Clear();
    this.KinematicSettings.Items.Clear();
  }

  internal void method_7(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.creatMachineEventHandler_0 == null || this.KinematicSettings.Type != KinemeticType.CartezianXYZ_WristAC_5Axis)
      return;
    buControlCoreClass.cVector.CreatMachine(this.KinematicSettings, ref this.CreatedEntities);
    // ISSUE: reference to a compiler-generated field
    this.creatMachineEventHandler_0(this.CreatedEntities, this.KinematicSettings);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
