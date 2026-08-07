// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventScale
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventScale : Form
{
  public buButton btn_viewtopbackleft;
  public buButton btn_viewtopleftmiddle;
  public buSpin spn_zoomratio;
  public buButton btn_camerapos;
  public buButton btn_zoomselected;
  public buSpin spn_zoomy1;
  public buSpin spn_zoomx1;
  public buButton btn_zoomwindowcoords;
  public buSpin spn_pandis;
  public buSpin spn_zoomy2;
  public buSpin spn_zoomx2;
  public Panel pnl_settings;
  public static byte f001BC8;
  public Color SpinBaseColor;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Result = DialogResult.OK;
    if (control.Name == ((F_MarbleEventCopy) this).btn_chamfer.Name)
      ((F_MarbleEventCopyMulti) this).Type = MarbleCountertopEdgeCommandTypes.Chamfer;
    if (control.Name == ((F_MarbleEventArray) this).btn_angle.Name)
      ((F_MarbleEventCopyMulti) this).Type = MarbleCountertopEdgeCommandTypes.Angle;
    if (control.Name == ((F_MarbleEventCopy) this).btn_slat.Name)
      ((F_MarbleEventCopyMulti) this).Type = MarbleCountertopEdgeCommandTypes.Slat;
    if (control.Name == ((F_MarbleEventCopy) this).btn_pocket.Name)
      ((F_MarbleEventCopyMulti) this).Type = MarbleCountertopEdgeCommandTypes.Pocket;
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventCopy) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventCopy) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventScale() => F_MarbleEventCopyMulti.Captions = new List<string>();

  public F_MarbleEventScale()
  {
    ((F_MarbleEventArray) this).Properties = new FormProperties();
    ((F_MarbleEventArray) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleEventArray) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleEditBaseHAndOffsetXY) this);
  }

  public void Init()
  {
    ((F_MarbleEventArray) this).Properties.Inited = false;
    if (((F_MarbleEventArray) this).Properties.Height > 10)
      this.Height = ((F_MarbleEventArray) this).Properties.Height;
    if (((F_MarbleEventArray) this).Properties.Width > 10)
      this.Width = ((F_MarbleEventArray) this).Properties.Width;
    this.TopMost = ((F_MarbleEventArray) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleEventArray) this).Properties.FormPosition;
    ((F_MarbleEventArray) this).Properties.Result = DialogResult.None;
    ((F_MarbleEventArray) this).Properties.Inited = true;
    ((F_MarbleSlat) this).spn_offsetY.Value = ((marbleCamPars) ((F_MarbleEventArray) this).varRuntime).Shape3DOffsetY;
    ((F_MarbleSlat) this).spn_offsetX.Value = ((marbleCamPars) ((F_MarbleEventArray) this).varRuntime).Shape3DOffsetX;
    ((F_MarbleEventArray) this).spn_baseheight.Value = ((marbleCamPars) ((F_MarbleEventArray) this).varRuntime).Shape3DHeight;
    \u0007.\u0001.\u0001((F_MarbleEditBaseHAndOffsetXY) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventArray) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventArray) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleEventArray) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventArray) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleEventArray) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditBaseHAndOffsetXY) this);
        ((F_MarbleEventArray) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleEventArray) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleEventArray) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleEventArray) this).btn_cancel.Name | control2.Name == ((F_MarbleEventArray) this).\u0001.Name))
        return;
      ((F_MarbleEventArray) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleEventArray) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEventArray) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }
}
