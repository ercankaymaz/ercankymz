// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Kinematic.F_KinematicBasic
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
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

public class F_KinematicBasic : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public KinematicBase KinematicSettings = new KinematicBase();
  public DialogResult Result = DialogResult.None;
  public string LoadedKinematicFileName = "";
  public string PathKinematic = Application.StartupPath;
  public List<eEntities> CreatedEntities = new List<eEntities>();
  public bool SelectEntities = false;
  public bool SaveWithOkButton = false;
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_ok;
  public Button btn_open;
  internal Panel panel_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal ComboBox comboBox_0;
  internal TextBox textBox_0;
  internal Panel panel_1;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_0;
  internal Label label_6;
  internal NumericUpDown numericUpDown_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_7;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_8;
  internal Label label_9;
  internal NumericUpDown numericUpDown_5;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_6;
  internal NumericUpDown numericUpDown_7;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal Label label_11;
  internal NumericUpDown numericUpDown_11;
  internal Label label_12;
  internal Label label_13;
  internal Label label_14;
  internal NumericUpDown numericUpDown_12;
  internal NumericUpDown numericUpDown_13;
  internal Label label_15;
  internal Label label_16;
  internal NumericUpDown numericUpDown_14;
  public Button btn_cancel;
  public Button btn_save;
  internal ImageList imageList_0;

  public F_KinematicBasic() => Class39.smethod_83(this);

  public event CreatMachineEventHandler CreatMachine;

  public void Init()
  {
    this.numericUpDown_5.Value = (Decimal) this.KinematicSettings.OffsetXYZ.X;
    this.numericUpDown_3.Value = (Decimal) this.KinematicSettings.OffsetXYZ.Y;
    this.numericUpDown_1.Value = (Decimal) this.KinematicSettings.OffsetXYZ.Z;
    this.numericUpDown_4.Value = (Decimal) this.KinematicSettings.OffsetABC.A;
    this.numericUpDown_2.Value = (Decimal) this.KinematicSettings.OffsetABC.B;
    this.numericUpDown_0.Value = (Decimal) this.KinematicSettings.OffsetABC.C;
    this.numericUpDown_14.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.X;
    this.numericUpDown_13.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.Y;
    this.numericUpDown_12.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfA.Z;
    this.numericUpDown_11.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.X;
    this.numericUpDown_10.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.Y;
    this.numericUpDown_9.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfB.Z;
    this.numericUpDown_8.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.X;
    this.numericUpDown_7.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.Y;
    this.numericUpDown_6.Value = (Decimal) this.KinematicSettings.RotateCenterOffsetOfC.Z;
    this.textBox_0.Text = this.KinematicSettings.Name;
    this.Result = DialogResult.None;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.KinematicSettings.Type, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.KinematicSettings.Type), ref this.comboBox_0);
    Class39.smethod_117(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Class39.smethod_752(this);
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = this.PathKinematic;
    saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buFile.SaveKinematicFile(saveFileDialog.FileName, this.KinematicSettings);
  }

  internal void method_2(object sender, EventArgs e)
  {
    Class39.smethod_752(this);
    if (this.SaveWithOkButton && new FileInfo(this.LoadedKinematicFileName).Exists)
      buFile.SaveKinematicFile(this.LoadedKinematicFileName, this.KinematicSettings);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_3(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, EventArgs e)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
