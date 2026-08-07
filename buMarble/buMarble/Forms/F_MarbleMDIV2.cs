// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMDIV2
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMDIV2 : Form
{
  public FormProperties PropertiesForm;
  private string \u0001;
  public MarblePartZeroType PartZero;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_spindle;
  public buButton btn_laser;
  public buButton btn_saw;
  public static byte f000371;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private string \u0001 = "F_MarbleMDIV1";
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public ImageList IC32;
  public buButton btn_stop;
  public buLabel lbl_positions;
  public buLabel lbl_tools;
  public buLabel lbl_camra;
  public buLabel lbl_commands;
  public buButton btn_spindleheadpark;
  public buButton btn_photopos;
  public buButton btn_sawpark;
  public buButton btn_wagonpark;
  public buButton btn_cameraclose;
  public buButton btn_cameraopen;
  public buButton btn_spindlepistondown;
  public buButton btn_spindlepistonup;
  public buButton btn_spindlepark;
  public buButton btn_slabthickness;
  public buButton btn_pensopenclose;
  public buButton btn_toolmagazineopen;
  public buButton btn_toolmagazineClose;
  public buButton btn_rtcp;
  public buButton btn_crousecontrol;
  public buButton btn_gozero;
  public buButton btn_homing;
  public buButton btn_park;
  public buButton btn_camera;
  public buButton btn_water;
  public buButton btn_laser;
  public buButton btn_vacuumclose;

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

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMDIV2() => F_MarblePartZero.Captions = new List<string>();

  public F_MarbleMDIV2() => \u0005.\u0003.\u0001(this);

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
    \u0005.\u0003.\u0001(this);
    this.UpdateVisuals();
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (buEyeVars.parVisual == null)
        return;
      if (!this.PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce && new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = hmiUICommands.SetVisualItem(this.buGround1.Controls);
        this.PropertiesForm.VisualUpdated = true;
      }
      \u0005.\u0003.\u0001(this);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
