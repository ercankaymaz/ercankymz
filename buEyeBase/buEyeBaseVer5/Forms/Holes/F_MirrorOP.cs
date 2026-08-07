// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_MirrorOP
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.UserFiles.buCad;
using buControls.Controls;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Machine;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_MirrorOP : Form
{
  private bool \u0001;
  public setLibrary varLib;
  private string \u0001;
  public bool ShowAux;
  internal IContainer \u0001;
  internal Panel \u0001;
  internal Label \u0001;
  internal ImageList \u0001;
  public buGround ground_base;
  public buButton btn_topview;
  public buButton btn_zoomfit;
  public buButton btn_zoomout;
  public buButton lbl_name;
  public buButton btn_zoomin;
  public buButton btn_close;
  public buButton btn_cancel;
  public buButton btn_ok;
  internal Panel \u0002;
  internal DataGridView \u0001;
  internal buTextBox \u0001;
  internal buListBox \u0001;
  public buButton btn_settings;
  public buButton btn_folder;
  internal buLabel \u0001;
  public static byte f002E44;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<LayerOverride> LayerOptions;
  internal IContainer \u0001;
  internal Label \u0001;

  public void LoadLangueage()
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " LoadLangueage";
    try
    {
      this.Text = $"{buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Configuration}";
      ((F_KeyPadCharV1) this).\u0001.Text = buLangTranslate.preDef.Acceleration;
      ((F_KeyPadCharV1) this).\u0003.Text = buLangTranslate.preDef.Deceleration;
      ((F_KeyPadCharV1) this).\u0004.Text = buLangTranslate.preDef.Jerk;
      ((F_KeyPadCharV1) this).\u0002.Text = buLangTranslate.preDef.Name;
      ((F_KeyPadCharV1) this).\u0006.Text = buLangTranslate.preDef.Speed;
      ((F_KeyPadCharV1) this).\u0005.Text = buLangTranslate.preDef.Explanation;
      ((F_KeyPadCharV1) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_KeyPadCharV1) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " F_FormClosing";
    try
    {
      if (((F_KeyPadCharV1) this).Properties.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      ((F_KeyPadCharV1) this).Properties.Result = DialogResult.Cancel;
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " btn_Click";
    try
    {
      if (((F_KeyPadCharV1) this).Properties.Result == DialogResult.OK)
        return;
      Control control = obj0 as Control;
      if (control.Name == ((F_KeyPadCharV1) this).btn_ok.Name)
      {
        if (!((F_KeyPadCharV1) this).Properties.Inited)
          return;
        if (((F_KeyPadCharV1) this).Properties.ReadOnly)
        {
          this.Dispose();
          return;
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineAxisCfg) this);
        ((F_KeyPadCharV1) this).Properties.Result = DialogResult.OK;
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_KeyPadCharV1) this).btn_cancel.Name))
        return;
      ((F_KeyPadCharV1) this).Properties.Result = DialogResult.Cancel;
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KeyPadCharV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KeyPadCharV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MirrorOP() => F_KeyPadCharV1.Captions = new List<string>();

  public F_MirrorOP()
  {
    ((F_KeyPadCharV1) this).Properties = new FormProperties();
    ((F_KeyPadCharV1) this).GCodeCongif = (MachineGCodeConfigrasyon) new F_Move();
    ((F_KeyPadCharV1) this).\u0001 = "F_MachineGCodeCfg";
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MachineGCodeCfg) this);
  }

  public void Init()
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " Init";
    try
    {
      ((F_KeyPadCharV1) this).Properties.Inited = false;
      if (((F_KeyPadCharV1) this).Properties.Height > 10)
        this.Height = ((F_KeyPadCharV1) this).Properties.Height;
      if (((F_KeyPadCharV1) this).Properties.Width > 10)
        this.Width = ((F_KeyPadCharV1) this).Properties.Width;
      this.TopMost = ((F_KeyPadCharV1) this).Properties.TopMost;
      this.StartPosition = ((F_KeyPadCharV1) this).Properties.FormPosition;
      ((F_KeyPadCharV1) this).\u0001.Items.Clear();
      ((F_KeyPadNumV1) this).\u0002.Items.Clear();
      ((F_KeyPadNumV1) this).\u0003.Items.Clear();
      for (int index = 0; index <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList.Count - 1; ++index)
        ((F_KeyPadCharV1) this).\u0001.Items.Add((object) F_Devide.AxisToString(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).AxesList[index]));
      for (int index = 0; index <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList.Count - 1; ++index)
        ((F_KeyPadNumV1) this).\u0002.Items.Add((object) F_Devide.MCodeToString(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).MCodeList[index]));
      for (int index = 0; index <= ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList.Count - 1; ++index)
        ((F_KeyPadNumV1) this).\u0003.Items.Add((object) F_Devide.OtherCodeToString(((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).OtherCodeList[index]));
      ((F_KeyPadNumV1) this).spn_extratime.Value = (Decimal) ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).ExstraTime;
      List<string> stringList1 = new List<string>();
      stringList1.AddRange((IEnumerable<string>) buNumeric5.EnumToString(typeof (LengthUnit)));
      List<string> stringList2 = new List<string>();
      stringList2.AddRange((IEnumerable<string>) buNumeric5.EnumToString(typeof (SpeedUnit)));
      for (int index = 0; index <= stringList1.Count - 1; ++index)
        ((F_KeyPadNumV1) this).\u0001.Items.Add((object) stringList1[index]);
      ((F_KeyPadNumV1) this).\u0001.Text = ((F_CutterMachineSettings) ((F_KeyPadCharV1) this).GCodeCongif).LengthType.ToString();
      for (int index = 0; index <= stringList2.Count - 1; ++index)
        ((F_KeyPadNumV1) this).\u0002.Items.Add((object) stringList2[index]);
      ((F_KeyPadNumV1) this).\u0002.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).GCodeCongif).SpeedType.ToString();
      ((F_KeyPadCharV1) this).Properties.Result = DialogResult.None;
      ((F_KeyPadCharV1) this).Properties.Inited = true;
      this.LoadLangueage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  public void LoadLangueage()
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " LoadLangueage";
    try
    {
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = ((F_KeyPadCharV1) this).\u0001 + " F_FormClosing";
    try
    {
      if (((F_KeyPadCharV1) this).Properties.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      ((F_KeyPadCharV1) this).Properties.Result = DialogResult.Cancel;
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_KeyPadCharV1) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }
}
