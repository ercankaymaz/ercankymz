// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.KeyPad.F_KeyPadNumV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Kinematic;
using buEyeBaseVer5.Forms.Layer;
using buEyeBaseVer5.Forms.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.KeyPad;

public class F_KeyPadNumV1 : Form
{
  public NumericUpDown spn_extratime;
  internal Label \u0002;
  internal Label \u0003;
  internal ListBox \u0002;
  internal Label \u0004;
  internal ListBox \u0003;
  public Button btn_addaxis;
  public Button btn_removeaxis;
  public Button btn_removemcodes;
  public Button btn_addmcodes;
  public Button btn_removeothercodes;
  public Button btn_addothercodes;
  internal ComboBox \u0001;
  internal Label \u0005;
  internal Label \u0006;
  internal ComboBox \u0002;
  public static byte f002DDE;
  public FormProperties Properties;
  public static List<string> Captions;
  internal Color \u0001;
  internal Color \u0002;
  public ObjectAlignment Alingnment;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_bottomright;
  public Button btn_middleright;
  public Button btn_topright;
  public Button btn_bottomleft;
  public Button btn_middleleft;
  public Button btn_topleft;
  public Button btn_bottomcenter;
  public Button btn_middlecenter;
  public Button btn_topcenter;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_LayerOptionList) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_LayerOptionList) this).Properties.Result = DialogResult.Cancel;
    if (((F_LayerOptionList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_LayerOptionList) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_LayerOptionList) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleProfileCurveSettings) this);
        ((F_LayerOptionList) this).Properties.Result = DialogResult.OK;
        if (((F_LayerOptionList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_LayerOptionList) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_LayerOptionList) this).btn_cancel.Name | control2.Name == ((F_LayerOptionList) this).\u0001.Name))
        return;
      ((F_LayerOptionList) this).Properties.Result = DialogResult.Cancel;
      if (((F_LayerOptionList) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_LayerOptionList) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1 fKeyPadNumV1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerOptionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerOptionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_KeyPadNumV1() => F_LayerOptionList.Captions = new List<string>();

  public F_KeyPadNumV1()
  {
    ((F_LayerOptionList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleTempCodes) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerOptionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerOptionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_KeyPadNumV1()
  {
    ((F_KinematicBasic) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleTempMovements) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KinematicBasic) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KinematicBasic) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_KeyPadNumV1()
  {
    ((F_KinematicBasic) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleTempWaterjet) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_KinematicBasic) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_KinematicBasic) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
