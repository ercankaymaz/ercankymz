// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_RotatePanel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Machine;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_RotatePanel : Form
{
  internal Label \u0002;
  public Button btn_removeall;
  public Button btn_selectall;
  public Button btn_unlsectall;
  public static byte f002E20;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<EditorCustomData> OpenCustomData;
  public Design viewport;
  internal int \u0001;
  private int \u0002;
  internal List<string> \u0001;
  public List<buEntity> LibraryEntities;
  private Timer \u0001;
  private Timer \u0002;
  public Entity selectedEntity;

  public F_RotatePanel()
  {
    ((F_KeyPadCharV1) this).Properties = new FormProperties();
    ((F_KeyPadCharV1) this).MCode = (MachineMCodeInfo) new F_Devide();
    ((F_KeyPadCharV1) this).\u0001 = "F_MachineMCodeCfg";
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineMCodeCfg) this);
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
      ((F_KeyPadCharV1) this).spn_time.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).MCode).TimeAsSec;
      ((F_KeyPadCharV1) this).\u0002.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).MCode).MCodeExplanation;
      ((F_KeyPadCharV1) this).\u0001.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).MCode).MCode;
      ((F_KeyPadCharV1) this).\u0003.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).MCode).ExtraCode;
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
      this.Text = $"M {buLangTranslate.preDef.Code} {buLangTranslate.preDef.Configuration}";
      ((F_KeyPadCharV1) this).\u0001.Text = buLangTranslate.preDef.Extra;
      ((F_KeyPadCharV1) this).\u0002.Text = "M " + buLangTranslate.preDef.Code;
      ((F_KeyPadCharV1) this).\u0004.Text = buLangTranslate.preDef.Time;
      ((F_KeyPadCharV1) this).\u0003.Text = buLangTranslate.preDef.Explanation;
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
      System.Windows.Forms.Control control = obj0 as System.Windows.Forms.Control;
      if (control.Name == ((F_KeyPadCharV1) this).btn_ok.Name)
      {
        if (!((F_KeyPadCharV1) this).Properties.Inited)
          return;
        if (((F_KeyPadCharV1) this).Properties.ReadOnly)
        {
          this.Dispose();
          return;
        }
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineMCodeCfg) this);
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

  static F_RotatePanel() => F_KeyPadCharV1.Captions = new List<string>();

  public F_RotatePanel()
  {
    ((F_KeyPadCharV1) this).Properties = new FormProperties();
    ((F_KeyPadCharV1) this).Axis = (MachineAxisInfo) new F_Move();
    ((F_KeyPadCharV1) this).\u0001 = "F_MachineAxisCfg";
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineAxisCfg) this);
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
      ((F_KeyPadCharV1) this).spn_acc.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).Acceleration;
      ((F_KeyPadCharV1) this).spn_dec.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).Deceleration;
      ((F_KeyPadCharV1) this).spn_jerk.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).Jerk;
      ((F_KeyPadCharV1) this).spn_speed.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).MaxSpeed;
      ((F_KeyPadCharV1) this).\u0002.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).AxisExplanation;
      ((F_KeyPadCharV1) this).\u0001.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).Axis).AxisName;
      ((F_KeyPadCharV1) this).Properties.Result = DialogResult.None;
      ((F_KeyPadCharV1) this).Properties.Inited = true;
      ((F_MirrorOP) this).LoadLangueage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_KeyPadCharV1) this).\u0001, str, "Exception", ex.Message);
      buException.throwException(ex, str, true);
    }
  }
}
