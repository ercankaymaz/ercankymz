// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_BendingLRAList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls;
using buControls.DialogBox;
using buCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_BendingLRAList : Form
{
  private IContainer \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Panel \u0002;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Button \u0002;
  internal Panel \u0003;
  internal ComboBox \u0001;
  internal Label \u0003;
  internal Label \u0004;
  internal NumericUpDown \u0002;
  internal Panel \u0004;
  internal Label \u0005;
  internal NumericUpDown \u0003;
  internal Panel \u0005;
  internal Label \u0006;
  internal Panel \u0006;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public TextBox txt_name;
  internal Label \u0007;
  internal Panel \u0007;
  internal Label \u0008;
  internal Panel \u0008;
  internal Label \u000E;
  internal Label \u000F;
  internal NumericUpDown \u0004;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  public static byte f000DAC;
  public FormProperties PropertiesForm;
  internal Timer \u0001;
  private int \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ColorDialogBox.ShowDialog(((F_NestedResults) this).\u000F.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    ((F_NestedResults) this).\u000F.BackColor = ColorDialogBox.Color;
    ((F_NestedResults) this).\u000F.ForeColor = buFile5.InvertColorNoGray(((F_NestedResults) this).\u000F.BackColor);
    ((F_NestedResults) this).\u000F.Text = buFile5.GetColorKnownName(((F_NestedResults) this).\u000F.BackColor);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestedResults) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestedResults) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestedResults) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_BendingLRAList() => F_NestedResults.Captions = new List<string>();

  public F_BendingLRAList()
  {
    ((F_NestOldResult) this).layer = (LayerBase5) new EntityShapeInfo();
    ((F_NestOldResult) this).Yarns = new List<TuftingYarn>();
    ((F_NestOldResult) this).PropertiesForm = new FormProperties();
    ((F_NestOldResult) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_LayerTufting) this);
  }

  public void Init()
  {
    ((F_NestOldResult) this).PropertiesForm.Inited = false;
    if (((F_NestOldResult) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestOldResult) this).PropertiesForm.Height;
    if (((F_NestOldResult) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestOldResult) this).PropertiesForm.Width;
    this.TopMost = ((F_NestOldResult) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestOldResult) this).PropertiesForm.FormPosition;
    LayerBase5 layerBase5 = (LayerBase5) new EntityShapeInfo();
    ((F_NestOnlineCalc) this).\u000F.BackColor = ((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerColor;
    ((F_NestOnlineCalc) this).\u000F.Text = buFile5.GetColorKnownName(((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerColor);
    ((F_NestOnlineCalc) this).\u000F.ForeColor = buFile5.InvertColorNoGray(((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerColor);
    ((F_NestOldResult) this).\u0001.Value = (Decimal) ((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerThickness;
    ((F_NestOldResult) this).\u0003.Value = (Decimal) ((DevideEventFormVars) ((F_NestOldResult) this).layer).Transparency;
    ((F_NestOldResult) this).\u0002.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.PileHeight;
    ((F_NestOnlineCalc) this).\u0004.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.StitchLength;
    ((F_NestOnlineCalc) this).\u0005.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.TuftingThickness;
    ((F_NestOldResult) this).\u0001.Text = ((DevideEventFormVars) ((F_NestOldResult) this).layer).Name;
    ((F_NestOnlineCalc) this).\u0002.Text = ((DevideEventFormVars) ((F_NestOldResult) this).layer).Defination;
    ((F_NestOldResult) this).\u0001.Checked = ((ScaleEventFormVars) ((F_NestOldResult) this).layer).Enable;
    ((F_NestOnlineCalc) this).\u0002.Checked = ((ScaleEventFormVars) ((F_NestOldResult) this).layer).Lock;
    ((F_NestOldResult) this).\u0001.Enabled = true;
    ((F_NestOldResult) this).\u0002.Enabled = true;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) ((DeleteTypeEventFormVars) layerBase5).Tufting.MixerMode, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.MixerMode), ref ((F_NestOnlineCalc) this).\u0003);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) ((DeleteTypeEventFormVars) layerBase5).Tufting.StitchMode, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.StitchMode), ref ((F_NestOldResult) this).\u0001);
    ((F_NestOldResult) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((F_NestOldResult) this).Yarns.Count - 1; ++index)
      ((F_NestOldResult) this).\u0002.Items.Add((object) ((F_NestOldResult) this).Yarns[index].Name);
    ((F_NestOldResult) this).\u0002.Text = ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.YarnType.Name;
    if (((F_NestOldResult) this).\u0002.Text.Length == 0 & ((F_NestOldResult) this).\u0002.Items.Count > 0)
      ((F_NestOldResult) this).\u0002.SelectedIndex = 0;
    this.LoadLanguage();
    ((F_NestOldResult) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestOldResult) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_NestOldResult.Captions.Count <= 6)
        return;
      this.Text = F_NestOldResult.Captions[0];
      ((F_NestOldResult) this).\u0004.Text = F_NestOldResult.Captions[1];
      ((F_NestOldResult) this).\u0005.Text = F_NestOldResult.Captions[2];
      ((F_NestOldResult) this).\u0003.Text = F_NestOldResult.Captions[4];
      ((F_NestOldResult) this).\u0002.Text = F_NestOldResult.Captions[5];
      ((F_NestOldResult) this).\u0001.Text = F_NestOldResult.Captions[6];
      ((F_NestOldResult) this).\u0006.Text = F_NestOldResult.Captions[7];
      ((F_NestOldResult) this).\u0008.Text = F_NestOldResult.Captions[8];
      ((F_NestOldResult) this).\u0007.Text = F_NestOldResult.Captions[9];
      ((F_NestOldResult) this).btn_ok.Text = F_NestOldResult.Captions[10];
      ((F_NestOldResult) this).btn_cancel.Text = F_NestOldResult.Captions[11];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_NestOldResult) this).\u0001.Value > 0M)
      ((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerThickness = (float) ((F_NestOldResult) this).\u0001.Value;
    ((DevideEventFormVars) ((F_NestOldResult) this).layer).Transparency = (int) ((F_NestOldResult) this).\u0003.Value;
    ((DevideEventFormVars) ((F_NestOldResult) this).layer).LayerColor = ((F_NestOnlineCalc) this).\u000F.BackColor;
    ((ScaleEventFormVars) ((F_NestOldResult) this).layer).Enable = ((F_NestOldResult) this).\u0001.Checked;
    ((DevideEventFormVars) ((F_NestOldResult) this).layer).Name = ((F_NestOldResult) this).\u0001.Text;
    ((DevideEventFormVars) ((F_NestOldResult) this).layer).Defination = ((F_NestOnlineCalc) this).\u0002.Text;
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.PileHeight = (double) ((F_NestOldResult) this).\u0002.Value;
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.StitchLength = (double) ((F_NestOnlineCalc) this).\u0004.Value;
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.TuftingThickness = (double) ((F_NestOnlineCalc) this).\u0005.Value;
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.YarnType = new TuftingYarn(((F_NestOldResult) this).Yarns[((F_NestOldResult) this).\u0002.SelectedIndex]);
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.MixerMode = (tuftingMixerModeType) ((F_NestOnlineCalc) this).\u0003.SelectedIndex;
    ((DeleteTypeEventFormVars) ((F_NestOldResult) this).layer).Tufting.StitchMode = (tuftingStitchModeType) ((F_NestOldResult) this).\u0001.SelectedIndex;
    ((ScaleEventFormVars) ((F_NestOldResult) this).layer).Lock = ((F_NestOnlineCalc) this).\u0002.Checked;
    ((F_NestOldResult) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_NestOldResult) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ColorDialogBox.ShowDialog(((F_NestOnlineCalc) this).\u000F.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    ((F_NestOnlineCalc) this).\u000F.BackColor = ColorDialogBox.Color;
    ((F_NestOnlineCalc) this).\u000F.ForeColor = buFile5.InvertColorNoGray(((F_NestOnlineCalc) this).\u000F.BackColor);
    ((F_NestOnlineCalc) this).\u000F.Text = buFile5.GetColorKnownName(((F_NestOnlineCalc) this).\u000F.BackColor);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NestOldResult) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NestOldResult) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestOldResult) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestOldResult) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestOldResult) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
