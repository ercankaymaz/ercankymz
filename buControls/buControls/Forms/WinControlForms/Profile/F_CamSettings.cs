// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_CamSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_CamSettings : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public ProfileOperationData OperationData = new ProfileOperationData();
  public camParameters CamPar = new camParameters();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_0;
  public NumericUpDown spn_areaclearancevelocity;
  internal Label label_1;
  public NumericUpDown spn_finishvelocity;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  public NumericUpDown spn_velplunge;
  internal Label label_5;
  public NumericUpDown spn_vellfeed;
  internal Label label_6;
  internal Label label_7;
  internal Panel panel_1;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal PictureBox pictureBox_3;
  internal Label label_8;
  public NumericUpDown spn_stepstep;
  internal Label label_9;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal PictureBox pictureBox_4;
  internal Label label_10;
  internal Label label_11;
  internal NumericUpDown numericUpDown_0;
  internal Label label_12;
  public NumericUpDown spn_stepcount;
  internal CheckBox checkBox_0;
  internal Label label_13;
  internal CheckBox checkBox_1;
  internal Label label_14;
  internal CheckBox checkBox_2;
  internal Label label_15;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal Panel panel_2;
  internal Panel panel_3;
  internal RadioButton radioButton_4;
  internal Label label_16;
  internal RadioButton radioButton_5;
  internal RadioButton radioButton_6;
  internal PictureBox pictureBox_5;
  internal Panel panel_4;
  internal RadioButton radioButton_7;
  internal Label label_17;
  internal RadioButton radioButton_8;
  internal RadioButton radioButton_9;
  internal Label label_18;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal CheckBox checkBox_6;
  internal Label label_19;
  public NumericUpDown spn_finishoffset;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal Label label_20;
  public NumericUpDown spn_dissafetop;
  public NumericUpDown spn_disapproachtop;
  internal Label label_21;
  internal TabPage tabPage_1;
  internal TabPage tabPage_2;
  internal Label label_22;
  public NumericUpDown spn_dissafeleft;
  public NumericUpDown spn_disapproachleft;
  internal Label label_23;
  internal Label label_24;
  public NumericUpDown spn_dissaferight;
  public NumericUpDown spn_disapproachright;
  internal Label label_25;
  internal Label label_26;
  public NumericUpDown spn_dissmallsafetop;
  internal Label label_27;
  public NumericUpDown spn_dissmallsafeleft;
  internal Label label_28;
  public NumericUpDown spn_dissmallsaferight;
  internal TabControl tabControl_1;
  internal TabPage tabPage_3;
  internal TabPage tabPage_4;
  internal CheckBox checkBox_7;
  internal Label label_29;

  public F_CamSettings() => Class39.smethod_625(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.spn_vellfeed.Value = (Decimal) this.CamPar.Speeds.Feed;
    this.spn_velplunge.Value = (Decimal) this.CamPar.Speeds.Plunge;
    this.spn_finishvelocity.Value = (Decimal) this.CamPar.Speeds.Finish;
    this.spn_areaclearancevelocity.Value = (Decimal) this.CamPar.Speeds.AreaClearance;
    this.spn_disapproachtop.Value = (Decimal) this.CamPar.Distances.FirstApproach;
    this.spn_dissmallsafetop.Value = (Decimal) this.CamPar.Distances.SafeSmall;
    this.spn_dissafetop.Value = (Decimal) this.CamPar.Distances.Safe;
    this.spn_disapproachleft.Value = (Decimal) this.CamPar.Distances.LeftFirstApproach;
    this.spn_dissmallsafeleft.Value = (Decimal) this.CamPar.Distances.LeftSafeSmall;
    this.spn_dissafeleft.Value = (Decimal) this.CamPar.Distances.LeftSafe;
    this.spn_disapproachright.Value = (Decimal) this.CamPar.Distances.RightFirstApproach;
    this.spn_dissmallsaferight.Value = (Decimal) this.CamPar.Distances.RightSafeSmall;
    this.spn_dissaferight.Value = (Decimal) this.CamPar.Distances.RightSafe;
    this.spn_stepstep.Value = (Decimal) this.CamPar.Steps.Step;
    this.spn_stepcount.Value = (Decimal) this.CamPar.Steps.Count;
    this.numericUpDown_0.Value = (Decimal) this.OperationData.NotchData.NotchCutPersentage;
    this.spn_finishoffset.Value = (Decimal) this.CamPar.Offsets.FinishOffset;
    if (this.CamPar.Operations.AreaClearanceDirection == InToOutType.InToOut)
    {
      this.radioButton_1.Checked = true;
      this.radioButton_0.Checked = false;
    }
    if (this.CamPar.Operations.AreaClearanceDirection == InToOutType.OutToIn)
    {
      this.radioButton_1.Checked = false;
      this.radioButton_0.Checked = true;
    }
    this.checkBox_1.Checked = this.CamPar.Operations.AreaClearanceEnable;
    this.checkBox_2.Checked = this.CamPar.Operations.FinishEnable;
    this.checkBox_0.Checked = this.CamPar.Steps.Enable;
    this.checkBox_7.Checked = this.CamPar.Strategy.OpenContourTwoDirectionCut;
    this.checkBox_6.Checked = this.CamPar.Speeds.FeedEnable;
    this.checkBox_5.Checked = this.CamPar.Speeds.PlungeEnable;
    this.checkBox_2.Checked = this.CamPar.Speeds.FinishEnable;
    this.checkBox_1.Checked = this.CamPar.Speeds.AreaClearanceEnable;
    if (this.CamPar.Operations.Direction == ClockDirectionType.CW)
    {
      this.radioButton_3.Checked = true;
      this.radioButton_2.Checked = false;
    }
    if (this.CamPar.Operations.Direction == ClockDirectionType.CCW)
    {
      this.radioButton_3.Checked = false;
      this.radioButton_2.Checked = true;
    }
    if (this.CamPar.Offsets.ClosedContour == CamClosedContourType.Inner)
    {
      this.radioButton_5.Checked = false;
      this.radioButton_4.Checked = false;
      this.radioButton_6.Checked = true;
    }
    if (this.CamPar.Offsets.ClosedContour == CamClosedContourType.Outter)
    {
      this.radioButton_5.Checked = false;
      this.radioButton_4.Checked = true;
      this.radioButton_6.Checked = false;
    }
    if (this.CamPar.Offsets.ClosedContour == CamClosedContourType.Center)
    {
      this.radioButton_5.Checked = true;
      this.radioButton_4.Checked = false;
      this.radioButton_6.Checked = false;
    }
    if (this.CamPar.Offsets.OpenContourOld == CamOpenContourType2.Center)
    {
      this.radioButton_8.Checked = true;
      this.radioButton_9.Checked = false;
      this.radioButton_7.Checked = false;
    }
    else if (this.CamPar.Offsets.OpenContourOld == CamOpenContourType2.Left)
    {
      this.radioButton_8.Checked = false;
      this.radioButton_9.Checked = true;
      this.radioButton_7.Checked = false;
    }
    else
    {
      this.radioButton_8.Checked = false;
      this.radioButton_9.Checked = false;
      this.radioButton_7.Checked = true;
    }
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_CamSettings.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
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
      Class39.smethod_307(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
