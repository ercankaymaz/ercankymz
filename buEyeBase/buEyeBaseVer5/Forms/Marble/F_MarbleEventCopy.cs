// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventCopy
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

public class F_MarbleEventCopy : Form
{
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_chamfer;
  public buButton btn_slat;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buButton btn_settings;
  public buButton btn_close;
  public buButton btn_pocket;

  public F_MarbleEventCopy()
  {
    ((F_MarbleEventRotate) this).Properties = new FormProperties();
    ((F_MarbleEventRotate) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleEventRotate) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleEditBaseHAndXYFrame) this);
  }

  public void Init()
  {
    ((F_MarbleEventRotate) this).Properties.Inited = false;
    if (((F_MarbleEventRotate) this).Properties.Height > 10)
      this.Height = ((F_MarbleEventRotate) this).Properties.Height;
    if (((F_MarbleEventRotate) this).Properties.Width > 10)
      this.Width = ((F_MarbleEventRotate) this).Properties.Width;
    this.TopMost = ((F_MarbleEventRotate) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleEventRotate) this).Properties.FormPosition;
    ((F_MarbleEventRotate) this).Properties.Result = DialogResult.None;
    ((F_MarbleEventRotate) this).Properties.Inited = true;
    ((F_MarbleEventMove) this).spn_scaleheight.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).ScaleHeight;
    ((F_MarbleEventMove) this).spn_scalewidth.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).ScaleWidth;
    ((F_MarbleEventMove) this).spn_baseheight.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).ScaleBaseHeight;
    ((F_MarbleEventMove) this).chk_keepratio.Check = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).ScaleKeepRatio;
    ((F_MarbleEventMove) this).spn_borderbottom.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).BorderBottom;
    ((F_MarbleEventMove) this).spn_borderleft.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).BorderLeft;
    ((F_MarbleEventMove) this).spn_bordertop.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).BorderTop;
    ((F_MarbleEventMove) this).spn_Borderright.Value = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).BorderRight;
    ((F_MarbleEventMove) this).chk_borderoffset.Check = ((marbleCamPars) ((F_MarbleEventRotate) this).varRuntime).BorderEnable;
    \u0007.\u0001.\u0001((F_MarbleEditBaseHAndXYFrame) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventRotate) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventRotate) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleEventRotate) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventRotate) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleEventMove) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditBaseHAndXYFrame) this);
        ((F_MarbleEventRotate) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleEventRotate) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleEventRotate) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleEventMove) this).btn_cancel.Name | control2.Name == ((F_MarbleEventMove) this).\u0001.Name))
        return;
      ((F_MarbleEventRotate) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleEventRotate) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEventRotate) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleEventRotate) this).Properties.Inited)
      ;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventRotate) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventRotate) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventCopy() => F_MarbleEventRotate.Captions = new List<string>();
}
