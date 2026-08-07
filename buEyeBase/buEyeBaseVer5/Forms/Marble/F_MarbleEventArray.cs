// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventArray
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventArray : Form
{
  public buButton btn_angle;
  public static byte f001BF5;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleRuntimeSettings varRuntime;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_baseheight;

  public F_MarbleEventArray()
  {
    ((F_MarbleEventMove) this).Properties = new FormProperties();
    ((F_MarbleEventMove) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleEventMove) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditOperation) this);
  }

  public void Init()
  {
    ((F_MarbleEventMove) this).Properties.Inited = false;
    if (((F_MarbleEventMove) this).Properties.Height > 10)
      this.Height = ((F_MarbleEventMove) this).Properties.Height;
    if (((F_MarbleEventMove) this).Properties.Width > 10)
      this.Width = ((F_MarbleEventMove) this).Properties.Width;
    this.TopMost = ((F_MarbleEventMove) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleEventMove) this).Properties.FormPosition;
    ((F_MarbleEventMove) this).Properties.Result = DialogResult.None;
    ((F_MarbleEventMove) this).Properties.Inited = true;
    ((F_MarbleCountertopEdge) this).spn_baseheight.Value = ((marbleCamPars) ((F_MarbleEventMove) this).varRuntime).ScaleBaseHeight;
    \u0007.\u0001.\u0001((F_MarbleEditOperation) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventMove) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventMove) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleEventMove) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventMove) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
        \u0007.\u0001.\u0001((F_MarbleEditOperation) this);
        ((F_MarbleEventMove) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleEventMove) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleEventMove) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleEventMove) this).btn_cancel.Name | control2.Name == ((F_MarbleEventMove) this).\u0001.Name))
        return;
      ((F_MarbleEventMove) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleEventMove) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEventMove) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventMove) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventMove) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventArray() => F_MarbleEventMove.Captions = new List<string>();

  public F_MarbleEventArray()
  {
    ((F_MarbleCountertopEdge) this).Properties = new FormProperties();
    ((F_MarbleCountertopEdge) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleCountertopEdge) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleEditLength) this);
  }

  public void Init()
  {
    ((F_MarbleCountertopEdge) this).Properties.Inited = false;
    if (((F_MarbleCountertopEdge) this).Properties.Height > 10)
      this.Height = ((F_MarbleCountertopEdge) this).Properties.Height;
    if (((F_MarbleCountertopEdge) this).Properties.Width > 10)
      this.Width = ((F_MarbleCountertopEdge) this).Properties.Width;
    this.TopMost = ((F_MarbleCountertopEdge) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleCountertopEdge) this).Properties.FormPosition;
    ((F_MarbleCountertopEdge) this).Properties.Result = DialogResult.None;
    ((F_MarbleCountertopEdge) this).Properties.Inited = true;
    ((F_MarbleCountertopEdge) this).spn_length.Value = ((marbleCamPars) ((F_MarbleCountertopEdge) this).varRuntime).ScaleLength;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditLength) this);
  }
}
