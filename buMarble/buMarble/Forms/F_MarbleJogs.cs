// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleJogs
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleJogs : Form
{
  public buButton btn_spindlepark;
  public buButton btn_camera;
  public buLabel buLabel3;
  public buButton btn_cameraclose;
  public buButton btn_cameraopen;
  public buButton btn_photopos;
  public buButton btn_vacuumdown;
  public buButton btn_vacuumrightpad;
  public buButton btn_vacuumleftpad;
  public buLabel buLabel4;
  public buButton btn_vacuumair;
  public buButton btn_vacuumup;
  public buLabel buLabel5;
  public buButton btn_toolmagazineopen;
  public buButton btn_toolmagazineClose;
  public buButton btn_pensopenclose;
  public static byte f000499;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buCheckBox chk_partzero;
  public buCheckBox chk_machinezero;
  public buCheckBox chk_addsawthickness;
  public buCheckBox chk_incremental;
  public buSpin spn_apos;
  public buCheckBox chk_absolute;
  public buSpin spn_cpos;
  public buSpin spn_zpos;
  public buSpin spn_ypos;
  public buSpin spn_xpos;
  public buButton btn_xplus;
  public buButton btn_xminus;
  public buButton btn_yplus;
  public buButton btn_yminus;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleMDIV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMDIV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      if (!((obj0 as Control).Name == ((F_MarbleMDIV1) this).btn_close.Name))
        return;
      ((F_MarbleMDIV1) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleMDIV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMDIV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMDIV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleJogs() => F_MarbleMDIV1.Captions = new List<string>();

  public F_MarbleJogs() => \u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
