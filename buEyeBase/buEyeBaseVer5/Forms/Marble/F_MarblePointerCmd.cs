// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarblePointerCmd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.buEntities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarblePointerCmd : Form
{
  private List<buEntity> \u0001;
  internal IContainer \u0001;
  public buButton buButton1;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public Panel pnl_base;
  public Panel pnl_data;
  public buButton btn_cancel;
  public buButton btn_settings;
  public Panel pnl_viewport;
  public buButton btn_viewtop;
  public buButton btn_viewback;
  public buButton btn_viewfront;
  public buButton btn_viewleft;
  public buButton btn_viewright;

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSlice) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSlice) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Marble3DShapeMenu) this).btn_okVer.Name)
      {
        this.Apply();
        ((F_MarbleSlice) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleSlice) this).btn_close.Name | control2.Name == ((F_Marble3DShapeMenu) this).btn_cancel.Name))
        return;
      ((F_MarbleSlice) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleSlice) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleSlice) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = clsVisualVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
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
    if ((!disposing ? 0 : (((F_MarbleSlice) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSlice) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarblePointerCmd() => F_MarbleSlice.Captions = new List<string>();

  public F_MarblePointerCmd()
  {
    ((F_Marble3DShapeMenu) this).PropertiesForm = new FormProperties();
    ((F_Marble3DShapeMenu) this).ItemList = new List<ValuesItem>();
    ((F_Marble3DShapeMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEdgeAngleList) this);
  }
}
