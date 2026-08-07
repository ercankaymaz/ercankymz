// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleMaterialSize
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMaterialSize : Form
{
  public buSpin spn_twistSA;
  public buCheckBox chk_twistenable;
  internal buLabel \u0003;
  internal Panel \u0001;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public CamTriangularMeshType MeshType;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buCheckBox chk_constantZ;
  public buCheckBox chk_parallelcut;
  public buCheckBox chk_pencil;
  public buCheckBox chk_flatlands;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSweepMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSweepMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSweepMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSweepMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSweepMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMaterialSize() => F_MarbleSweepMenu.Captions = new List<string>();

  public F_MarbleMaterialSize()
  {
    // ISSUE: unable to decompile the method.
  }
}
