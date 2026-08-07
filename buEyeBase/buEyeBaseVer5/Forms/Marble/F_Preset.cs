// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Preset
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Preset : Form
{
  public FormProperties Properties;
  public static List<string> Captions;
  public camParameters5 varRoughSettings;
  public camParameters5 varContourCutSettings;
  public camParameters5 varCenterSettings;
  public camParameters5 varFaceSettings;
  public camParameters5 varFloorFinishSettings;
  public camParameters5 varChamferSettings;
  public camParameters5 varEngraveSettings;
  public camParameters5 varTextEngraveSettings;
  public camParameters5 varTrochoidalSettings;
  public CamWireFrameType CamType;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_roughcuttingvel;
  public buSpin spn_roughplungevel;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_roughsafedistance;
  public buSpin spn_roughrapiddistance;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;

  public void StrategyWaterToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void ToolToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyFromToolType()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorizontalCut) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorizontalCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorizontalCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorizontalCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleHorizontalCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorizontalCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorizontalCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleAxesSettings) this).chk_rotate180minus.Name)
    {
      ((F_MarbleAxesSettings) this).chk_rotate180plus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate90minus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleAxesSettings) this).chk_rotate180plus.Name)
    {
      ((F_MarbleAxesSettings) this).chk_rotate180minus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate90minus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleAxesSettings) this).chk_rotate90minus.Name)
    {
      ((F_MarbleAxesSettings) this).chk_rotate180minus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate180plus.Check = false;
      ((F_MarbleAxesSettings) this).chk_rotate90plus.Check = false;
    }
    if (!(control.Name == ((F_MarbleAxesSettings) this).chk_rotate90plus.Name))
      return;
    ((F_MarbleAxesSettings) this).chk_rotate180minus.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate180plus.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate90minus.Check = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorizontalCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorizontalCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
