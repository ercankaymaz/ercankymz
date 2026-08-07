// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Machine.F_MachineMCodeCfg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineMCodeCfg : Form
{
  public buSpin spn_facerapiddis;
  public buSpin spn_faceplungevel;
  public buSpin spn_facecuttingvel;
  internal buLabel \u0005;
  public buSpin spn_floorfinishsafedis;
  public buSpin spn_floorfinishrapiddis;
  public buSpin spn_floorfinishplungevel;
  public buSpin spn_floorfinishcuttingvel;
  internal TabPage \u0006;
  internal TabPage \u0007;
  internal TabPage \u0008;
  internal TabPage \u000E;
  internal buLabel \u0006;
  public buSpin spn_chamfersafedis;
  public buSpin spn_chamferrapiddis;
  public buSpin spn_chamferplungevel;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleSawMillingContourSetting) this).btn_minus.Name)
    {
      ((F_MarbleSawMillingContourSetting) this).spn_cutangle.Value = -((F_MarbleSawMillingContourSetting) this).spn_cutangle.Value;
    }
    else
    {
      double result = 0.0;
      double.TryParse(control.Text, out result);
      ((F_MarbleSawMillingContourSetting) this).spn_cutangle.Value = result;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawMillingContourSetting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawMillingContourSetting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MachineMCodeCfg() => F_MarbleSawMillingContourSetting.Captions = new List<string>();

  public F_MachineMCodeCfg()
  {
    ((F_MarbleSawMillingContourSetting) this).Properties = new FormProperties();
    ((F_MarbleSawMillingContourSetting) this).isHorizontal = false;
    ((F_MarbleSawMillingContourSetting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorVerCut) this);
  }

  public void Init()
  {
    ((F_MarbleSawMillingContourSetting) this).Properties.Inited = false;
    if (((F_MarbleSawMillingContourSetting) this).Properties.Height > 10)
      this.Height = ((F_MarbleSawMillingContourSetting) this).Properties.Height;
    if (((F_MarbleSawMillingContourSetting) this).Properties.Width > 10)
      this.Width = ((F_MarbleSawMillingContourSetting) this).Properties.Width;
    this.TopMost = ((F_MarbleSawMillingContourSetting) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleSawMillingContourSetting) this).Properties.FormPosition;
    ((F_MarbleSawMillingContourSetting) this).Properties.Result = DialogResult.None;
    ((F_MarbleSawMillingContourSetting) this).Properties.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleHorVerCut) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawMillingContourSetting) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawMillingContourSetting) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleMillingCamSetting) this).btn_okVer.Name)
      {
        ((F_MarbleSawMillingContourSetting) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMillingCamSetting) this).btn_close.Name)
      {
        ((F_MarbleSawMillingContourSetting) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSawMillingContourSetting) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleMillingCamSetting) this).btn_maximize.Name)
        this.WindowState = FormWindowState.Maximized;
      if (!(control2.Name == ((F_MarbleMillingCamSetting) this).btn_minimize.Name))
        return;
      this.WindowState = FormWindowState.Normal;
    }
    catch (Exception ex)
    {
    }
  }
}
