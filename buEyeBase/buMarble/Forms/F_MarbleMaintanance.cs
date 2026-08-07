// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMaintanance
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
namespace buMarble.Forms;

public class F_MarbleMaintanance : Form
{
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_cancel;
  public buButton btn_clearX;
  internal ImageList \u0001;
  internal buLabel \u0001;
  public buSpin spn_limitMAchineClean;
  public buSpin spn_actualMAchineClean;
  internal buLabel \u0002;
  public buButton btn_clearMachineClean;
  public buSpin spn_limitCabinet;
  public buSpin spn_actualCabinet;
  internal buLabel \u0003;
  public buButton btn_clearCabinet;
  public buSpin spn_limitLubricate;
  public buSpin spn_actualLuricate;
  internal buLabel \u0004;
  public buButton btn_clearLubricate;
  public buSpin spn_limitAir;
  public buSpin spn_actualAir;
  internal buLabel \u0005;
  public buButton btn_clearAir;
  public buSpin spn_limitHidro;
  public buSpin spn_actualHidro;
  internal buLabel \u0006;
  public buButton btn_clearHidro;
  public buSpin spn_limitC;
  public buSpin spn_actualC;
  internal buLabel \u0007;
  public buButton btn_clearC;
  public buSpin spn_limitA;
  public buSpin spn_actualA;
  internal buLabel \u0008;
  public buButton btn_clearA;
  public buSpin spn_limitZ;
  public buSpin spn_actualZ;
  internal buLabel \u000E;
  public buButton btn_clearZ;
  public buSpin spn_limitY;
  public buSpin spn_actualY;
  internal buLabel \u000F;
  public buButton btn_clearY;
  internal buLabel \u0010;
  internal buLabel \u0011;
  public buSpin spn_limitX;
  public buSpin spn_actualX;

  static F_MarbleMaintanance() => F_MarbleCounters.Captions = new List<string>();

  public F_MarbleMaintanance() => \u0007.\u0001.\u0001(this);

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
    \u0007.\u0001.\u0001(this);
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

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (!(control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name))
        return;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }
}
