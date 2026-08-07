// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCollapse
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

public class F_MarbleCollapse : Form
{
  public buButton btn_zoomin;
  public buButton btn_viewsettings;
  public buCheckBox chk_snap;
  public buCheckBox chk_grid;
  public buGround ground_base;
  public buButton btn_close;
  public buCheckBox chk_viewportrotate;
  public buButton btn_viewback;
  public buButton btn_viewright;
  public buButton btn_panright;
  public buButton btn_panleft;
  public buButton btn_panup;
  public buButton btn_pandown;
  public buButton btn_zoomratio;
  public buButton btn_viewcube;
  internal Panel \u0001;
  public buButton btn_viewtopfrontleft;
  public buButton btn_viewtopfrontright;
  public buButton btn_viewtopfrontmiddle;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEventMirror) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventMirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventMirror) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventMirror) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventMirror) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCollapse() => F_MarbleEventMirror.Captions = new List<string>();

  public F_MarbleCollapse()
  {
    ((F_MarbleEventCopyMulti) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleEventCopyMulti) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleEventCopyMulti) this).PropertiesForm = new FormProperties();
    ((F_MarbleEventCopyMulti) this).Type = MarbleCountertopEdgeCommandTypes.Edge;
    ((F_MarbleEventCopy) this).clrLabel = Color.DarkSeaGreen;
    ((F_MarbleEventCopy) this).clrFormCaption = Color.LightBlue;
    ((F_MarbleEventCopy) this).clrFormBackUpper = Color.Black;
    ((F_MarbleEventCopy) this).clrFormBackDown = Color.DarkGray;
    ((F_MarbleEventCopy) this).clrButtonDisplay = Color.DarkGray;
    ((F_MarbleEventCopy) this).clrButtonOver = Color.Gold;
    ((F_MarbleEventCopy) this).clrButtonDown = Color.Goldenrod;
    ((F_MarbleEventCopy) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleCountertopEdgeMenu) this);
  }

  public void Init()
  {
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Inited = false;
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEventCopyMulti) this).PropertiesForm.Height;
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEventCopyMulti) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEventCopyMulti) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEventCopyMulti) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEventCopy) this).buGround1.DisplayTop.BackColor = ((F_MarbleEventCopy) this).clrFormCaption;
    ((F_MarbleEventCopy) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleEventCopy) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleEventCopy) this).clrFormBackUpper;
    ((F_MarbleEventCopy) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleEventCopy) this).clrFormBackDown;
    ((F_MarbleEventCopy) this).btn_close.Display.BackColor = ((F_MarbleEventCopy) this).clrFormCaption;
    ((F_MarbleEventCopy) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleEventCopy) this).clrFormCaption, 0.9);
    ((F_MarbleEventCopy) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleEventCopy) this).clrFormCaption, 0.95);
    ((F_MarbleEventCopy) this).btn_slat.Display.BackColor = ((F_MarbleEventCopy) this).clrButtonDisplay;
    ((F_MarbleEventCopy) this).btn_slat.ButtonDownDisplay.BackColor = ((F_MarbleEventCopy) this).clrButtonDown;
    ((F_MarbleEventCopy) this).btn_slat.ButtonOverDisplay.BackColor = ((F_MarbleEventCopy) this).clrButtonOver;
    ((F_MarbleEventCopy) this).btn_chamfer.Display.BackColor = ((F_MarbleEventCopy) this).clrButtonDisplay;
    ((F_MarbleEventCopy) this).btn_chamfer.ButtonDownDisplay.BackColor = ((F_MarbleEventCopy) this).clrButtonDown;
    ((F_MarbleEventCopy) this).btn_chamfer.ButtonOverDisplay.BackColor = ((F_MarbleEventCopy) this).clrButtonOver;
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEventCopy) this).btn_chamfer.Text = buLangTranslate.preDef.Chamfer;
      ((F_MarbleEventArray) this).btn_angle.Text = buLangTranslate.preDef.Angle;
      ((F_MarbleEventCopy) this).btn_slat.Text = buLangTranslate.preDef.Slat;
      ((F_MarbleEventCopy) this).btn_pocket.Text = buLangTranslate.preDef.Pocket;
      ((F_MarbleEventCopy) this).buGround1.Text = $"{buLangTranslate.preDef.Edge} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventCopyMulti) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventCopyMulti) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
