// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_BendingRotaryDisk
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_BendingRotaryDisk : Form
{
  public buNestingVar SettingsPar;
  public int SelectedResultIndex;
  public int SelectedSheetIndex;
  public int SelectedPartIndex;
  private string \u0001;
  internal IContainer \u0001;
  public TreeView treeView1;
  internal ImageList \u0001;
  internal Label \u0001;
  public Button btn_preview;
  public Button btn_close;
  public TextBox txt_bestcount;
  public System.Windows.Forms.ProgressBar progress_execution;
  public Button btn_send;
  public Button btn_stop;
  public Label lbl_persentage;
  public TextBox txt_time;
  internal Label \u0002;
  public Label lbl_status;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal CheckBox \u0001;
  public Button btn_settings;
  internal Panel \u0002;
  public Button btn_closesettings;
  internal Label \u0003;
  internal RadioButton \u0003;
  public static byte f000D85;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public buNestingPart Part;
  public buNestingVar Settings;
  private Design \u0001;
  private Timer \u0001;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_NestedResults) this).\u0001.Value > 0M)
      ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerThickness = (float) ((F_NestedResults) this).\u0001.Value;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).Transparency = (int) ((F_NestedResults) this).\u0002.Value;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor = ((F_NestedResults) this).\u0008.BackColor;
    ((ScaleEventFormVars) ((F_NestedResults) this).layer).Enable = ((F_NestedResults) this).\u0001.Checked;
    ((ScaleEventFormVars) ((F_NestedResults) this).layer).Lock = ((F_NestedResults) this).\u0002.Checked;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).Name = ((F_NestedResults) this).\u0001.Text;
    if (((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX != null)
      ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX.Purpose = (Router3AXLayerPurpose) buCompare5.EnumValueFromString((object) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Router3AX.Purpose, ((F_NestedResults) this).\u0001.Text);
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ColorDialogBox.ShowDialog(((F_NestedResults) this).\u0008.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    ((F_NestedResults) this).\u0008.BackColor = ColorDialogBox.Color;
    ((F_NestedResults) this).\u0008.ForeColor = buFile5.InvertColorNoGray(((F_NestedResults) this).\u0008.BackColor);
    ((F_NestedResults) this).\u0008.Text = buFile5.GetColorKnownName(((F_NestedResults) this).\u0008.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestedResults) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestedResults) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_BendingRotaryDisk() => F_NestedResults.Captions = new List<string>();

  public F_BendingRotaryDisk()
  {
    ((F_NestedResults) this).PropertiesForm = new FormProperties();
    ((F_NestedResults) this).Layers = new List<LayerBase5>();
    ((F_NestedResults) this).SelectedLayerIndex = -1;
    ((F_NestedResults) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_LayerList) this);
  }

  public void Init()
  {
    ((F_NestedResults) this).PropertiesForm.Inited = false;
    if (((F_NestedResults) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestedResults) this).PropertiesForm.Height;
    if (((F_NestedResults) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestedResults) this).PropertiesForm.Width;
    this.TopMost = ((F_NestedResults) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestedResults) this).PropertiesForm.FormPosition;
    \u0007.\u0001.\u0001((F_LayerList) this);
    \u0007.\u0001.\u0001((F_LayerList) this);
    ((F_NestedResults) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_NestedResults) this).btn_ok.Name)
    {
      ((F_NestedResults) this).btn_ok.Focus();
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LayerList) this);
      ((F_NestedResults) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NestedResults) this).btn_cancel.Name))
      return;
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (((F_NestedResults) this).PropertiesForm.Inited)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NestedResults) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NestedResults) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_BendingRotaryDisk() => F_NestedResults.Captions = new List<string>();

  public F_BendingRotaryDisk()
  {
    ((F_NestedResults) this).layer = (LayerBase5) new EntityShapeInfo();
    ((F_NestedResults) this).Yarns = new List<TuftingYarn>();
    ((F_NestedResults) this).PropertiesForm = new FormProperties();
    ((F_NestedResults) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_LayerConvertToTufting) this);
  }

  public void Init()
  {
    ((F_NestedResults) this).PropertiesForm.Inited = false;
    if (((F_NestedResults) this).PropertiesForm.Height > 10)
      this.Height = ((F_NestedResults) this).PropertiesForm.Height;
    if (((F_NestedResults) this).PropertiesForm.Width > 10)
      this.Width = ((F_NestedResults) this).PropertiesForm.Width;
    this.TopMost = ((F_NestedResults) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_NestedResults) this).PropertiesForm.FormPosition;
    LayerBase5 layerBase5 = (LayerBase5) new EntityShapeInfo();
    ((F_NestedResults) this).\u000F.BackColor = ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor;
    ((F_NestedResults) this).\u000F.Text = buFile5.GetColorKnownName(((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor);
    ((F_NestedResults) this).\u000F.ForeColor = buFile5.InvertColorNoGray(((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor);
    ((F_NestedResults) this).\u0001.Value = (Decimal) ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerThickness;
    ((F_NestedResults) this).\u0003.Value = (Decimal) ((DevideEventFormVars) ((F_NestedResults) this).layer).Transparency;
    ((F_NestedResults) this).\u0002.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.PileHeight;
    ((F_NestOldResult) this).\u0004.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.StitchLength;
    ((F_NestOldResult) this).\u0005.Value = (Decimal) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.TuftingThickness;
    ((F_NestedResults) this).\u0001.Text = ((DevideEventFormVars) ((F_NestedResults) this).layer).Name;
    ((F_NestOldResult) this).\u0002.Text = ((DevideEventFormVars) ((F_NestedResults) this).layer).Defination;
    ((F_NestedResults) this).\u0001.Checked = ((ScaleEventFormVars) ((F_NestedResults) this).layer).Enable;
    ((F_NestOldResult) this).\u0002.Checked = ((ScaleEventFormVars) ((F_NestedResults) this).layer).Lock;
    ((F_NestedResults) this).\u0001.Enabled = true;
    ((F_NestedResults) this).\u0002.Enabled = true;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) ((DeleteTypeEventFormVars) layerBase5).Tufting.MixerMode, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.MixerMode), ref ((F_NestedResults) this).\u0003);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) ((DeleteTypeEventFormVars) layerBase5).Tufting.StitchMode, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.StitchMode), ref ((F_NestedResults) this).\u0001);
    ((F_NestedResults) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((F_NestedResults) this).Yarns.Count - 1; ++index)
      ((F_NestedResults) this).\u0002.Items.Add((object) ((F_NestedResults) this).Yarns[index].Name);
    ((F_NestedResults) this).\u0002.Text = ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.YarnType.Name;
    if (((F_NestedResults) this).\u0002.Text.Length == 0 & ((F_NestedResults) this).\u0002.Items.Count > 0)
      ((F_NestedResults) this).\u0002.SelectedIndex = 0;
    this.LoadLanguage();
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.None;
    ((F_NestedResults) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_NestedResults.Captions.Count <= 6)
        return;
      this.Text = F_NestedResults.Captions[0];
      ((F_NestedResults) this).\u0004.Text = F_NestedResults.Captions[1];
      ((F_NestedResults) this).\u0005.Text = F_NestedResults.Captions[2];
      ((F_NestedResults) this).\u0003.Text = F_NestedResults.Captions[4];
      ((F_NestedResults) this).\u0002.Text = F_NestedResults.Captions[5];
      ((F_NestedResults) this).\u0001.Text = F_NestedResults.Captions[6];
      ((F_NestedResults) this).\u0006.Text = F_NestedResults.Captions[7];
      ((F_NestedResults) this).\u0008.Text = F_NestedResults.Captions[8];
      ((F_NestedResults) this).\u0007.Text = F_NestedResults.Captions[9];
      ((F_NestedResults) this).btn_ok.Text = F_NestedResults.Captions[10];
      ((F_NestedResults) this).btn_cancel.Text = F_NestedResults.Captions[11];
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
    if (((F_NestedResults) this).\u0001.Value > 0M)
      ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerThickness = (float) ((F_NestedResults) this).\u0001.Value;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).Transparency = (int) ((F_NestedResults) this).\u0003.Value;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).LayerColor = ((F_NestedResults) this).\u000F.BackColor;
    ((ScaleEventFormVars) ((F_NestedResults) this).layer).Enable = ((F_NestedResults) this).\u0001.Checked;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).Name = ((F_NestedResults) this).\u0001.Text;
    ((DevideEventFormVars) ((F_NestedResults) this).layer).Defination = ((F_NestOldResult) this).\u0002.Text;
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.PileHeight = (double) ((F_NestedResults) this).\u0002.Value;
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.StitchLength = (double) ((F_NestOldResult) this).\u0004.Value;
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.TuftingThickness = (double) ((F_NestOldResult) this).\u0005.Value;
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.YarnType = new TuftingYarn(((F_NestedResults) this).Yarns[((F_NestedResults) this).\u0002.SelectedIndex]);
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.MixerMode = (tuftingMixerModeType) ((F_NestedResults) this).\u0003.SelectedIndex;
    ((DeleteTypeEventFormVars) ((F_NestedResults) this).layer).Tufting.StitchMode = (tuftingStitchModeType) ((F_NestedResults) this).\u0001.SelectedIndex;
    ((ScaleEventFormVars) ((F_NestedResults) this).layer).Lock = ((F_NestOldResult) this).\u0002.Checked;
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_NestedResults) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NestedResults) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
