// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Osnap.F_OsnapSettings
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
namespace buControls.Forms.WinControlForms.Osnap;

public class F_OsnapSettings : Form
{
  public static List<string> Captions = new List<string>();
  public OsnapProps OsnapSettings = new OsnapProps();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel panel_0;
  internal CheckBox checkBox_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal Panel panel_1;
  internal CheckBox checkBox_1;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal CheckBox checkBox_6;
  internal CheckBox checkBox_7;
  internal CheckBox checkBox_8;
  internal CheckBox checkBox_9;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_4;
  internal Label label_6;
  internal CheckBox checkBox_10;
  internal Label label_7;
  internal Panel panel_3;
  internal NumericUpDown numericUpDown_5;
  internal Label label_8;
  internal CheckBox checkBox_11;
  internal Label label_9;
  internal NumericUpDown numericUpDown_6;
  internal Label label_10;
  internal Panel panel_4;
  internal NumericUpDown numericUpDown_7;
  internal Label label_11;
  internal CheckBox checkBox_12;
  internal Label label_12;
  internal Panel panel_5;
  internal NumericUpDown numericUpDown_8;
  internal Label label_13;
  internal CheckBox checkBox_13;
  internal Label label_14;
  internal CheckBox checkBox_14;
  internal Panel panel_6;
  internal NumericUpDown numericUpDown_9;
  internal Label label_15;
  internal CheckBox checkBox_15;
  internal Label label_16;

  public F_OsnapSettings() => Class39.smethod_526(this);

  public void Init()
  {
    this.Result = DialogResult.None;
    this.checkBox_0.Checked = this.OsnapSettings.Snap;
    this.numericUpDown_0.Value = (Decimal) this.OsnapSettings.SnapDistance.X;
    this.numericUpDown_2.Value = (Decimal) this.OsnapSettings.SnapDistance.Y;
    this.numericUpDown_1.Value = (Decimal) this.OsnapSettings.SnapDistance.Z;
    this.checkBox_11.Checked = this.OsnapSettings.Track;
    this.numericUpDown_5.Value = (Decimal) this.OsnapSettings.TrackPerpendicularAngleLimit;
    this.numericUpDown_6.Value = (Decimal) this.OsnapSettings.TrackCatchTime;
    this.checkBox_10.Checked = this.OsnapSettings.Over;
    this.numericUpDown_4.Value = (Decimal) this.OsnapSettings.OverResolution;
    this.checkBox_13.Checked = this.OsnapSettings.LimitedDistance;
    this.numericUpDown_8.Value = (Decimal) this.OsnapSettings.LimitedValue;
    this.checkBox_12.Checked = this.OsnapSettings.ConstantPlaneEnable;
    this.numericUpDown_7.Value = (Decimal) this.OsnapSettings.ConstantPlaneHeight;
    this.checkBox_15.Checked = this.OsnapSettings.OrthoAuto;
    this.numericUpDown_9.Value = (Decimal) this.OsnapSettings.OrthoAutoAngle;
    this.checkBox_1.Checked = this.OsnapSettings.Osnap;
    this.checkBox_8.Checked = this.OsnapSettings.OsnapPoint;
    this.checkBox_7.Checked = this.OsnapSettings.OsnapMiddle;
    this.checkBox_6.Checked = this.OsnapSettings.OsnapCenter;
    this.checkBox_5.Checked = this.OsnapSettings.OsnapOutside;
    this.checkBox_2.Checked = this.OsnapSettings.OsnapZeroPoint;
    this.checkBox_4.Checked = this.OsnapSettings.OsnapIntersection;
    this.checkBox_3.Checked = this.OsnapSettings.OsnapBoxSize;
    this.checkBox_9.Checked = this.OsnapSettings.OsnapControlPoints;
    this.checkBox_14.Checked = this.OsnapSettings.OsnapVertice;
    this.numericUpDown_3.Value = (Decimal) this.OsnapSettings.CatchResolution;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "OsnapSettings LoadLanguage";
    try
    {
      if (F_OsnapSettings.Captions.Count < 24)
        return;
      this.Text = F_OsnapSettings.Captions[0];
      this.label_1.Text = F_OsnapSettings.Captions[1];
      this.label_7.Text = F_OsnapSettings.Captions[2];
      this.label_6.Text = F_OsnapSettings.Captions[3];
      this.label_9.Text = F_OsnapSettings.Captions[4];
      this.label_8.Text = F_OsnapSettings.Captions[5];
      this.label_10.Text = F_OsnapSettings.Captions[6];
      this.label_12.Text = F_OsnapSettings.Captions[7];
      this.label_11.Text = F_OsnapSettings.Captions[8];
      this.label_14.Text = F_OsnapSettings.Captions[9];
      this.label_13.Text = F_OsnapSettings.Captions[10];
      this.label_4.Text = F_OsnapSettings.Captions[11];
      this.label_5.Text = F_OsnapSettings.Captions[12];
      this.checkBox_8.Text = F_OsnapSettings.Captions[13];
      this.checkBox_7.Text = F_OsnapSettings.Captions[14];
      this.checkBox_6.Text = F_OsnapSettings.Captions[15];
      this.checkBox_5.Text = F_OsnapSettings.Captions[16 /*0x10*/];
      this.checkBox_4.Text = F_OsnapSettings.Captions[17];
      this.checkBox_3.Text = F_OsnapSettings.Captions[18];
      this.checkBox_2.Text = F_OsnapSettings.Captions[19];
      this.checkBox_9.Text = F_OsnapSettings.Captions[20];
      this.checkBox_14.Text = F_OsnapSettings.Captions[21];
      this.btn_ok.Text = F_OsnapSettings.Captions[22];
      this.btn_cancel.Text = F_OsnapSettings.Captions[23];
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
    this.OsnapSettings.Snap = this.checkBox_0.Checked;
    this.OsnapSettings.SnapDistance.X = (double) this.numericUpDown_0.Value;
    this.OsnapSettings.SnapDistance.Y = (double) this.numericUpDown_2.Value;
    this.OsnapSettings.SnapDistance.Z = (double) this.numericUpDown_1.Value;
    this.OsnapSettings.Track = this.checkBox_11.Checked;
    this.OsnapSettings.TrackPerpendicularAngleLimit = (double) this.numericUpDown_5.Value;
    this.OsnapSettings.TrackCatchTime = (int) this.numericUpDown_6.Value;
    this.OsnapSettings.Over = this.checkBox_10.Checked;
    this.OsnapSettings.OverResolution = (double) this.numericUpDown_4.Value;
    this.OsnapSettings.LimitedDistance = this.checkBox_13.Checked;
    this.OsnapSettings.LimitedValue = (double) this.numericUpDown_8.Value;
    this.OsnapSettings.ConstantPlaneEnable = this.checkBox_12.Checked;
    this.OsnapSettings.ConstantPlaneHeight = (double) this.numericUpDown_7.Value;
    this.OsnapSettings.OrthoAuto = this.checkBox_15.Checked;
    this.OsnapSettings.OrthoAutoAngle = (double) this.numericUpDown_9.Value;
    this.OsnapSettings.Osnap = this.checkBox_1.Checked;
    this.OsnapSettings.OsnapPoint = this.checkBox_8.Checked;
    this.OsnapSettings.OsnapMiddle = this.checkBox_7.Checked;
    this.OsnapSettings.OsnapCenter = this.checkBox_6.Checked;
    this.OsnapSettings.OsnapOutside = this.checkBox_5.Checked;
    this.OsnapSettings.OsnapZeroPoint = this.checkBox_2.Checked;
    this.OsnapSettings.OsnapIntersection = this.checkBox_4.Checked;
    this.OsnapSettings.OsnapBoxSize = this.checkBox_3.Checked;
    this.OsnapSettings.OsnapControlPoints = this.checkBox_9.Checked;
    this.OsnapSettings.OsnapVertice = this.checkBox_14.Checked;
    this.OsnapSettings.CatchResolution = (double) this.numericUpDown_3.Value;
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
