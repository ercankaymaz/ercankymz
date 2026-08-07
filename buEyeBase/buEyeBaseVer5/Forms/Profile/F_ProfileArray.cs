// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileArray
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileArray : Form
{
  internal Label \u0018;
  internal Label \u0019;
  public NumericUpDown spn_finishoffset;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal CheckBox \u0004;
  internal Label \u001A;
  internal Label \u001B;
  public NumericUpDown spn_dissmallsafe;
  internal Label \u001C;
  public NumericUpDown spn_dissafe;
  public NumericUpDown spn_disapproach;
  internal Label \u001D;
  internal Label \u001E;
  public NumericUpDown spn_spindlespeed;
  internal CheckBox \u0005;
  internal Label \u001F;
  internal CheckBox \u0006;
  internal Label \u007F;

  public void Init()
  {
    ((F_CamSettings) this).Properties.Inited = false;
    if (((F_CamSettings) this).Properties.Height > 10)
      this.Height = ((F_CamSettings) this).Properties.Height;
    if (((F_CamSettings) this).Properties.Width > 10)
      this.Width = ((F_CamSettings) this).Properties.Width;
    this.TopMost = ((F_CamSettings) this).Properties.TopMost;
    this.StartPosition = ((F_CamSettings) this).Properties.FormPosition;
    ArrayList arrayList = new ArrayList();
    ((F_Clampers) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_CamSettings) this).Lengths.Count - 1; ++index)
      ((F_Clampers) this).\u0001.Items.Add((object) $"{(index + 1).ToString()} - {this.\u0001(((F_CamSettings) this).Lengths[index])}");
    this.Text = buLangTranslate.preDef.Clamp;
    ((F_Clampers) this).\u0003.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Length}";
    ((F_Clampers) this).\u0001.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Length}";
    ((F_Clampers) this).\u0002.Text = $"{buLangTranslate.preDef.Clamp} {buLangTranslate.preDef.Count}";
    ((F_Clampers) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    ((F_Clampers) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_CamSettings) this).Properties.Result = DialogResult.None;
    ((F_CamSettings) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamSettings) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamSettings) this).Properties.Result = DialogResult.Cancel;
    if (((F_CamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamSettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Clampers) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ClamperProfileLength) this);
        ((F_CamSettings) this).Properties.Result = DialogResult.OK;
        if (((F_CamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamSettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Clampers) this).btn_cancel.Name)
      {
        ((F_CamSettings) this).Properties.Result = DialogResult.Cancel;
        if (((F_CamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamSettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Clampers) this).\u0005.Name)
      {
        ((buMarbleCalc) ((F_CamSettings) this).Lengths[((F_CamSettings) this).\u0001]).ProfileLength = (double) ((F_Clampers) this).\u0001.Value;
        // ISSUE: reference to a compiler-generated field
        ((buMarbleCalc.\u003C\u003Ec) ((F_CamSettings) this).Lengths[((F_CamSettings) this).\u0001]).ClamperCount = (int) ((F_Clampers) this).\u0002.Value;
        ArrayList arrayList = new ArrayList();
        ((F_Clampers) this).\u0001.Items.Clear();
        for (int index = 0; index <= ((F_CamSettings) this).Lengths.Count - 1; ++index)
          ((F_Clampers) this).\u0001.Items.Add((object) $"{(index + 1).ToString()} - {this.\u0001(((F_CamSettings) this).Lengths[index])}");
      }
      if (control2.Name == ((F_Clampers) this).\u0004.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_CamSettings) this).strPath;
        openFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        openFileDialog.FilterIndex = 1;
        openFileDialog.Multiselect = false;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
          try
          {
            ((F_CamSettings) this).strPath = buFile.GetPath(openFileDialog.FileName);
            ArrayList CalcList1 = new ArrayList();
            buString.ListToSpecificList("<ProfileSettings>", "</ProfileSettings>", true, StringList, ref CalcList1);
            if (CalcList1.Count > 0)
              buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((F_CamSettings) this).varProfileClamperSettings);
            List<List<string>> CalcList2 = new List<List<string>>();
            buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, StringList, ref CalcList2);
            ((F_CamSettings) this).Clampers.Clear();
            for (int index = 0; index <= CalcList2.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList2[index].ToArray());
              ProfileClamper profileClamper = (ProfileClamper) new MarbleVacuumCut();
              buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) profileClamper);
              ((F_CamSettings) this).Clampers.Add(profileClamper);
            }
            List<List<string>> CalcList3 = new List<List<string>>();
            buImage5.ListToSpecificList("<ProfileLengthCountData>", "</ProfileLengthCountData>", true, StringList, ref CalcList3);
            ((F_CamSettings) this).Lengths.Clear();
            for (int index = 0; index <= CalcList3.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList3[index].ToArray());
              ProfileLengthClamperCount lengthClamperCount = (ProfileLengthClamperCount) new MarbleItemExtend();
              buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) lengthClamperCount);
              ((F_CamSettings) this).Lengths.Add(lengthClamperCount);
            }
            this.Init();
            CalcList3.Clear();
            StringList.Clear();
          }
          catch (Exception ex)
          {
            buLog.addLog("Profile Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Profile Settings Decoder Error");
          }
        }
      }
      if (control2.Name == ((F_Clampers) this).\u0003.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_CamSettings) this).strPath;
        saveFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_CamSettings) this).strPath = buFile.GetPath(saveFileDialog.FileName);
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Profile Settings");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<ProfileSettings>");
          StringList.AddRange((ICollection) ((F_CamSettings) this).varProfileClamperSettings.ToDefAll("", 2, (SerilizationMode5) 1));
          StringList.Add((object) "</ProfileSettings>");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Clampers ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  <Clampers>");
          for (int index = 0; index <= ((F_CamSettings) this).Clampers.Count - 1; ++index)
            StringList.AddRange((ICollection) ((F_CamSettings) this).Clampers[index].ToDefAll("", 4, (SerilizationMode5) 1));
          StringList.Add((object) "  </Clampers>");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   ProfileLengthCount ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  <ProfileLengthCountData>");
          for (int index = 0; index <= ((F_CamSettings) this).Lengths.Count - 1; ++index)
            StringList.AddRange((ICollection) ((F_CamSettings) this).Lengths[index].ToDefAll("", 4, (SerilizationMode5) 1));
          StringList.Add((object) "  </ProfileLengthCountData>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
          StringList.Clear();
        }
      }
      if (control2.Name == ((F_Clampers) this).\u0001.Name)
      {
        ((F_CamSettings) this).Lengths.Add((ProfileLengthClamperCount) new MarbleItemExtend((double) ((F_Clampers) this).\u0001.Value, (int) ((F_Clampers) this).\u0002.Value));
        ((F_Clampers) this).\u0001.Items.Add((object) $"{((F_CamSettings) this).Lengths.Count.ToString()} - {this.\u0001(((F_CamSettings) this).Lengths[((F_CamSettings) this).Lengths.Count - 1])}");
        ((F_Clampers) this).\u0001.SelectedIndex = ((F_CamSettings) this).Clampers.Count - 1;
      }
      if (!(control2.Name == ((F_Clampers) this).\u0002.Name) || !(((F_CamSettings) this).\u0001 >= 0 & ((F_CamSettings) this).\u0001 <= ((F_CamSettings) this).Lengths.Count - 1) || buString.MessageBoxQuestion($"{buLangTranslate.preSentences.DoYouWantToDelete} {buLangTranslate.preDef.Length}") != DialogResult.Yes)
        return;
      ((F_CamSettings) this).Lengths.RemoveAt(((F_CamSettings) this).\u0001);
      ((F_Clampers) this).\u0001.Items.RemoveAt(((F_CamSettings) this).\u0001);
      ((F_CamSettings) this).\u0001 = ((F_CamSettings) this).\u0001 - 1;
      if (((F_CamSettings) this).\u0001 < 0)
        ((F_CamSettings) this).\u0001 = 0;
      if (((F_Clampers) this).\u0001.Items.Count <= 0)
        return;
      ((F_Clampers) this).\u0001.SelectedIndex = ((F_CamSettings) this).\u0001;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_CamSettings) this).Properties.Inited)
      return;
    if (control2.Name == ((F_Clampers) this).\u0001.Name && ((F_CamSettings) this).\u0001 >= 0 & ((F_CamSettings) this).\u0001 <= ((F_CamSettings) this).Clampers.Count - 1)
      ((buMarbleCalc) ((F_CamSettings) this).Lengths[((F_Clampers) this).\u0001.SelectedIndex]).ProfileLength = (double) ((F_Clampers) this).\u0001.Value;
    if (!(control2.Name == ((F_Clampers) this).\u0002.Name) || !(((F_CamSettings) this).\u0001 >= 0 & ((F_CamSettings) this).\u0001 <= ((F_CamSettings) this).Clampers.Count - 1))
      return;
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u003C\u003Ec) ((F_CamSettings) this).Lengths[((F_Clampers) this).\u0001.SelectedIndex]).ClamperCount = (int) ((F_Clampers) this).\u0002.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_CamSettings) this).Properties.Inited || !(((F_Clampers) this).\u0001.SelectedIndex >= 0 & ((F_Clampers) this).\u0001.SelectedIndex <= ((F_CamSettings) this).Lengths.Count - 1))
      return;
    ((F_CamSettings) this).Properties.Inited = false;
    ((F_CamSettings) this).\u0001 = ((F_Clampers) this).\u0001.SelectedIndex;
    // ISSUE: reference to a compiler-generated field
    ((F_Clampers) this).\u0002.Value = (Decimal) ((buMarbleCalc.\u003C\u003Ec) ((F_CamSettings) this).Lengths[((F_CamSettings) this).\u0001]).ClamperCount;
    ((F_Clampers) this).\u0001.Value = (Decimal) ((buMarbleCalc) ((F_CamSettings) this).Lengths[((F_Clampers) this).\u0001.SelectedIndex]).ProfileLength;
    ((F_CamSettings) this).Properties.Inited = true;
  }

  private string \u0001([In] ProfileLengthClamperCount obj0)
  {
    // ISSUE: reference to a compiler-generated field
    return $"{buLangTranslate.preDef.Profile}{buLangTranslate.preDef.Length} : {((buMarbleCalc) obj0).ProfileLength.ToString()} - {buLangTranslate.preDef.Clamp} {buLangTranslate.preDef.Count} : {((buMarbleCalc.\u003C\u003Ec) obj0).ClamperCount.ToString()}";
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Clampers) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Clampers) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
