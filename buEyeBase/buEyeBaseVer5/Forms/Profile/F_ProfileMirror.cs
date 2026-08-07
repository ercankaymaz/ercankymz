// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileMirror
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.RollerBend;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileMirror : Form
{
  public RadioButton radio_kertmeLdown;
  public RadioButton radio_kertmeLup;
  internal Label \u0005;
  internal Panel \u0003;
  public RadioButton radio_back;
  public RadioButton radio_front;
  internal Panel \u0004;
  public Label lbl_Editing;
  public DataGridView dgv_list;
  public static byte f001608;
  public FormProperties Properties;
  public static List<string> Captions;
  public ProfileSettings VarSettings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Panel \u0001;
  internal Label \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0002;

  static F_ProfileMirror() => F_Settnigs.Captions = new List<string>();

  public F_ProfileMirror()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).ShapeType = ShapeTypes.None;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_RollerMenu) this);
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
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_RollerMenu) this);
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
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Settnigs) this).btn_circle.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Circle;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_rect.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Rectangle;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_slot.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Slot;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_triangle.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Triangle;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_ellipse.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Ellipse;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_rect2edge.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Rectangle2Edge;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_Settnigs) this).btn_rect3edge.Name)
      {
        ((F_Settnigs) this).ShapeType = ShapeTypes.Rectangle3Edge;
        this.Apply();
        ((F_Settnigs) this).Properties.Result = DialogResult.OK;
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_Settnigs) this).btn_halfcircle.Name))
        return;
      ((F_Settnigs) this).ShapeType = ShapeTypes.CircleHalf;
      this.Apply();
      ((F_Settnigs) this).Properties.Result = DialogResult.OK;
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

  static F_ProfileMirror() => F_Settnigs.Captions = new List<string>();
}
