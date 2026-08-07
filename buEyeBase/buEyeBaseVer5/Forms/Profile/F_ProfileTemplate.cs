// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileTemplate
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.RollerBend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileTemplate : Form
{
  internal Label \u0001;
  public Button btn_front;
  internal Label \u0002;
  public Button btn_back;
  internal Label \u0003;
  internal Label \u0004;
  public Button btn_left;
  public Button btn_right;
  public Button btn_ok;
  public Button btn_cancel;
  public DataGridView dgv_data;

  static F_ProfileTemplate() => F_Settnigs.Captions = new List<string>();

  public F_ProfileTemplate()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).Width = 1000.0;
    ((F_Settnigs) this).Height = 800.0;
    ((F_Settnigs) this).Radius = 300.0;
    ((F_Settnigs) this).Length = 1000.0;
    ((F_Settnigs) this).Thickness = 5.0;
    ((F_Settnigs) this).isHorizontal = false;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_RollerRectangle) this);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      ((F_Settnigs) this).Height = (double) ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      ((F_Settnigs) this).Width = (double) ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).spn_width.Value = ((F_Settnigs) this).Width;
    ((F_Settnigs) this).spn_hegiht.Value = ((F_Settnigs) this).Height;
    ((F_Settnigs) this).spn_radius.Value = ((F_Settnigs) this).Radius;
    ((F_Settnigs) this).spn_length.Value = ((F_Settnigs) this).Length;
    ((F_Settnigs) this).spn_thickness.Value = ((F_Settnigs) this).Thickness;
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    \u001F.\u0001.\u0001((F_RollerRectangle) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Settnigs) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((F_Settnigs) this).Width = ((F_Settnigs) this).spn_width.Value;
    ((F_Settnigs) this).Height = ((F_Settnigs) this).spn_hegiht.Value;
    ((F_Settnigs) this).Radius = ((F_Settnigs) this).spn_radius.Value;
    ((F_Settnigs) this).Length = ((F_Settnigs) this).spn_length.Value;
    ((F_Settnigs) this).Thickness = ((F_Settnigs) this).spn_thickness.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Settnigs) this).btn_ok.Name)
      {
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_Settnigs) this).btn_close.Name | control2.Name == ((F_Settnigs) this).btn_cancel.Name))
        return;
      ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Settnigs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Settnigs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
