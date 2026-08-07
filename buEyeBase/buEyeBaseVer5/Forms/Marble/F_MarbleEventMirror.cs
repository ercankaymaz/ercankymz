// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventMirror
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

public class F_MarbleEventMirror : Form
{
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleCountertopCornerTypes Type;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_rectangle;
  public buButton btn_chamfer;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventArray) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventArray) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventMirror() => F_MarbleEventArray.Captions = new List<string>();

  public F_MarbleEventMirror()
  {
    ((F_MarbleSlat) this).Properties = new FormProperties();
    ((F_MarbleSlat) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleSlat) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleEditBaseDepthAndOffsetXYPlanes) this);
  }

  public void Init()
  {
    ((F_MarbleSlat) this).Properties.Inited = false;
    if (((F_MarbleSlat) this).Properties.Height > 10)
      this.Height = ((F_MarbleSlat) this).Properties.Height;
    if (((F_MarbleSlat) this).Properties.Width > 10)
      this.Width = ((F_MarbleSlat) this).Properties.Width;
    this.TopMost = ((F_MarbleSlat) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleSlat) this).Properties.FormPosition;
    ((F_MarbleSlat) this).Properties.Result = DialogResult.None;
    ((F_MarbleSlat) this).Properties.Inited = true;
    ((F_MarbleSlat) this).spn_offsetY.Value = ((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DInOffsetY;
    ((F_MarbleSlat) this).spn_offsetX.Value = ((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DInOffsetX;
    ((F_MarbleSlat) this).spn_depth.Value = ((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DDepth;
    if (((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DPlane == planeNames.Top)
    {
      ((F_MarbleSlat) this).btn_topplane.Display.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_topplane.ButtonDownDisplay.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_topplane.ButtonOverDisplay.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_bottomplane.Display.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonDownDisplay.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonOverDisplay.BackColor = Color.Red;
    }
    else
    {
      ((F_MarbleSlat) this).btn_topplane.Display.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_topplane.ButtonDownDisplay.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_topplane.ButtonOverDisplay.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_bottomplane.Display.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonDownDisplay.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonOverDisplay.BackColor = Color.Green;
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditBaseDepthAndOffsetXYPlanes) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSlat) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSlat) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleSlat) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSlat) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleSlat) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleEditBaseDepthAndOffsetXYPlanes) this);
        ((F_MarbleSlat) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleSlat) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSlat) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleSlat) this).btn_cancel.Name | control2.Name == ((F_MarbleSlat) this).\u0001.Name)
      {
        ((F_MarbleSlat) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleSlat) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSlat) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleSlat) this).btn_topplane.Name)
      {
        ((F_MarbleSlat) this).btn_topplane.Display.BackColor = Color.Green;
        ((F_MarbleSlat) this).btn_topplane.ButtonDownDisplay.BackColor = Color.Green;
        ((F_MarbleSlat) this).btn_topplane.ButtonOverDisplay.BackColor = Color.Green;
        ((F_MarbleSlat) this).btn_bottomplane.Display.BackColor = Color.Red;
        ((F_MarbleSlat) this).btn_bottomplane.ButtonDownDisplay.BackColor = Color.Red;
        ((F_MarbleSlat) this).btn_bottomplane.ButtonOverDisplay.BackColor = Color.Red;
        ((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DPlane = planeNames.Top;
      }
      if (!(control2.Name == ((F_MarbleSlat) this).btn_bottomplane.Name))
        return;
      ((F_MarbleSlat) this).btn_topplane.Display.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_topplane.ButtonDownDisplay.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_topplane.ButtonOverDisplay.BackColor = Color.Red;
      ((F_MarbleSlat) this).btn_bottomplane.Display.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonDownDisplay.BackColor = Color.Green;
      ((F_MarbleSlat) this).btn_bottomplane.ButtonOverDisplay.BackColor = Color.Green;
      ((marbleCamPars) ((F_MarbleSlat) this).varRuntime).Shape3DPlane = planeNames.Bottom;
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSlat) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSlat) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventMirror() => F_MarbleSlat.Captions = new List<string>();
}
