// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Holes.F_CabinetSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Viewer;
using buEyeBaseVer5.Forms.KeyPad;
using buEyeBaseVer5.Forms.Machine;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Holes;

public class F_CabinetSettings : Form
{
  internal Label \u000E;
  public FormProperties Properties;
  public static List<string> Captions;
  internal Color \u0001;
  internal Color \u0002;
  public CornerLocation Corner;
  private IContainer \u0001;
  public Button btn_bottomright;
  public Button btn_middleright;
  public Button btn_topright;
  public Button btn_bottomleft;
  public Button btn_middleleft;
  public Button btn_topleft;
  public Button btn_bottomcenter;
  public Button btn_topcenter;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal Label \u0008;
  internal ImageList \u0001;
  public FormProperties Properties;
  public static List<string> Captions;
  public List<CharLibrary5> Chars;
  internal IContainer \u0001;
  internal CheckedListBox \u0001;
  public buViewer buViewer1;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_remove;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;

  public F_CabinetSettings()
  {
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((buEyeBaseVer5.Forms.Marble.OperationData.Form1) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KeyPadCharV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KeyPadCharV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_CabinetSettings()
  {
    ((F_KeyPadCharV1) this).Properties = new FormProperties();
    ((F_KeyPadCharV1) this).OtherCode = (MachineOtherCodeInfo) new F_Devide();
    ((F_KeyPadCharV1) this).\u0001 = "MachineOtherCodeInfo";
    ((F_KeyPadCharV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MachineOtherCodeCfg) this);
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
      ((F_KeyPadCharV1) this).spn_time.Value = (Decimal) ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).OtherCode).TimeAsSec;
      ((F_KeyPadCharV1) this).\u0002.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).OtherCode).OtherCodeExplanation;
      ((F_KeyPadCharV1) this).\u0001.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).OtherCode).OtherCode;
      ((F_KeyPadCharV1) this).\u0003.Text = ((F_CutterOffsetEntities) ((F_KeyPadCharV1) this).OtherCode).ExtraCode;
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
      this.Text = $"{buLangTranslate.preDef.Other} {buLangTranslate.preDef.Code} {buLangTranslate.preDef.Configuration}";
      ((F_KeyPadCharV1) this).\u0001.Text = buLangTranslate.preDef.Extra;
      ((F_KeyPadCharV1) this).\u0002.Text = $"{buLangTranslate.preDef.Other} {buLangTranslate.preDef.Code}";
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
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MachineOtherCodeCfg) this);
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

  static F_CabinetSettings() => F_KeyPadCharV1.Captions = new List<string>();
}
