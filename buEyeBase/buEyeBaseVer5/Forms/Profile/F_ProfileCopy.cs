// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileCopy
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.RollerBend;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileCopy : Form
{
  internal Label \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  public static byte f001618;
  public FormProperties Properties;
  public static List<string> Captions;
  public camParameters5 CamPar;
  internal IContainer \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0001;
  public NumericUpDown spn_areaclearancevelocity;
  internal Label \u0002;
  public NumericUpDown spn_finishvelocity;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  public NumericUpDown spn_velplunge;
  internal Label \u0006;
  public NumericUpDown spn_vellfeed;
  internal Label \u0007;
  internal Label \u0008;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal PictureBox \u0003;
  internal PictureBox \u0004;
  internal Label \u000E;
  public NumericUpDown spn_stepstep;
  internal Label \u000F;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal PictureBox \u0005;
  internal Label \u0010;
  internal Label \u0011;
  internal NumericUpDown \u0001;
  internal Label \u0012;
  public NumericUpDown spn_stepcount;

  public F_ProfileCopy()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).Diameter = 300.0;
    ((F_Settnigs) this).Length = 1000.0;
    ((F_Settnigs) this).Thickness = 5.0;
    ((F_Settnigs) this).isHorizontal = false;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_RollerCircle) this);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).spn_diameter.Value = ((F_Settnigs) this).Diameter;
    ((F_Settnigs) this).spn_length.Value = ((F_Settnigs) this).Length;
    ((F_Settnigs) this).spn_thickness.Value = ((F_Settnigs) this).Thickness;
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    \u0007.\u0001.\u0001((F_RollerCircle) this);
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
    ((F_Settnigs) this).Diameter = ((F_Settnigs) this).spn_diameter.Value;
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

  static F_ProfileCopy() => F_Settnigs.Captions = new List<string>();
}
