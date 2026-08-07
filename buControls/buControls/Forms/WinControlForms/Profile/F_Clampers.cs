// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_Clampers
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_Clampers : Form
{
  public ProfileClamperSettings varProfileClamperSettings = new ProfileClamperSettings();
  public FormProperties Properties = new FormProperties();
  public string strPath = Application.StartupPath;
  public static List<string> Captions = new List<string>();
  public static string msgRemove = "Do You Want to Remove This Clamper";
  private int int_0 = 0;
  public List<ProfileClamper> Clampers = new List<ProfileClamper>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal CheckedListBox checkedListBox_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_3;
  internal Label label_4;
  internal NumericUpDown numericUpDown_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_5;
  internal Label label_6;
  internal Panel panel_1;
  internal Button button_0;
  internal Label label_7;
  internal Button button_1;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_8;
  internal NumericUpDown numericUpDown_6;
  internal Label label_9;
  internal NumericUpDown numericUpDown_7;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal Button button_2;
  internal Button button_3;

  public F_Clampers() => Class39.smethod_248(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ArrayList arrayList = new ArrayList();
    this.checkedListBox_0.Items.Clear();
    for (int index = 0; index <= this.Clampers.Count - 1; ++index)
      this.checkedListBox_0.Items.Add((object) $"{(index + 1).ToString()} - Min X: {this.Clampers[index].MinPositionRange.ToString()} - Max X: {this.Clampers[index].MaxPositionRange.ToString()} , W: {this.Clampers[index].Width.ToString()}", (this.Clampers[index].Enable ? 1 : 0) != 0);
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.numericUpDown_2.Value = (Decimal) this.varProfileClamperSettings.EndOffset;
    this.numericUpDown_3.Value = (Decimal) this.varProfileClamperSettings.StartOffset;
    this.numericUpDown_6.Value = (Decimal) this.varProfileClamperSettings.ClamperWidth;
    this.numericUpDown_4.Value = (Decimal) this.varProfileClamperSettings.MaxDistanceFor2Clamper;
    this.numericUpDown_5.Value = (Decimal) this.varProfileClamperSettings.MinDistanceFor2Clamper;
    this.numericUpDown_7.Value = (Decimal) this.varProfileClamperSettings.OperationMinDistance;
    this.numericUpDown_8.Value = (Decimal) this.varProfileClamperSettings.MaxFreeDistanceForProfile;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (control2.Name == this.btn_ok.Name)
      {
        Class39.smethod_211(this);
        this.Properties.Result = DialogResult.OK;
        if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == this.btn_cancel.Name)
      {
        this.Properties.Result = DialogResult.Cancel;
        if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == this.button_3.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = this.strPath;
        openFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        openFileDialog.FilterIndex = 1;
        openFileDialog.Multiselect = false;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
          try
          {
            this.strPath = buFile.GetPath(openFileDialog.FileName);
            ArrayList CalcList1 = new ArrayList();
            buString.ListToSpecificList("<ProfileSettings>", "</ProfileSettings>", true, StringList, ref CalcList1);
            if (CalcList1.Count > 0)
              buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) this.varProfileClamperSettings);
            List<List<string>> CalcList2 = new List<List<string>>();
            buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, StringList, ref CalcList2);
            this.Clampers.Clear();
            for (int index = 0; index <= CalcList2.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList2[index].ToArray());
              ProfileClamper profileClamper = new ProfileClamper();
              buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) profileClamper);
              this.Clampers.Add(profileClamper);
            }
            this.Init();
          }
          catch (Exception ex)
          {
            buLog.addLog("Profile Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Profile Settings Decoder Error");
          }
        }
      }
      if (control2.Name == this.button_2.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = this.strPath;
        saveFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.strPath = buFile.GetPath(saveFileDialog.FileName);
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Profile Settings");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<ProfileSettings>");
          StringList.AddRange((ICollection) this.varProfileClamperSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
          StringList.Add((object) "</ProfileSettings>");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Clampers ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  <Clampers>");
          for (int index = 0; index <= this.Clampers.Count - 1; ++index)
            StringList.AddRange((ICollection) this.Clampers[index].ToDefAll("", 4, SerilizationMode.MultiLine));
          StringList.Add((object) "  </Clampers>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (control2.Name == this.button_0.Name)
      {
        this.Clampers.Add(new ProfileClamper());
        this.checkedListBox_0.Items.Add((object) $"{this.Clampers.Count.ToString()} - Min X: {this.Clampers[this.Clampers.Count - 1].MinPositionRange.ToString()} - Max X: {this.Clampers[this.Clampers.Count - 1].MaxPositionRange.ToString()} , W: {this.Clampers[this.Clampers.Count - 1].Width.ToString()}", (this.Clampers[this.Clampers.Count - 1].Enable ? 1 : 0) != 0);
        this.checkedListBox_0.SelectedIndex = this.Clampers.Count - 1;
      }
      if (!(control2.Name == this.button_1.Name) || !(this.int_0 >= 0 & this.int_0 <= this.Clampers.Count - 1) || buString.MessageBoxQuestion(F_Clampers.msgRemove) != DialogResult.Yes)
        return;
      this.Clampers.RemoveAt(this.int_0);
      this.checkedListBox_0.Items.RemoveAt(this.int_0);
      --this.int_0;
      if (this.int_0 < 0)
        this.int_0 = 0;
      if (this.checkedListBox_0.Items.Count <= 0)
        return;
      this.checkedListBox_0.SelectedIndex = this.int_0;
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.numericUpDown_0.Name && this.int_0 >= 0 & this.int_0 <= this.Clampers.Count - 1)
      this.Clampers[this.checkedListBox_0.SelectedIndex].MinPositionRange = (double) this.numericUpDown_0.Value;
    if (!(control2.Name == this.numericUpDown_1.Name) || !(this.int_0 >= 0 & this.int_0 <= this.Clampers.Count - 1))
      return;
    this.Clampers[this.checkedListBox_0.SelectedIndex].MaxPositionRange = (double) this.numericUpDown_1.Value;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.Properties.Inited || !(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Clampers.Count - 1))
      return;
    this.Properties.Inited = false;
    this.int_0 = this.checkedListBox_0.SelectedIndex;
    this.numericUpDown_1.Value = (Decimal) this.Clampers[this.int_0].MaxPositionRange;
    this.numericUpDown_0.Value = (Decimal) this.Clampers[this.checkedListBox_0.SelectedIndex].MinPositionRange;
    this.Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
