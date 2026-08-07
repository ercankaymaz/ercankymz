// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCutRemailMaterial
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCutRemailMaterial : Form
{
  public buButton btn_viewiso;
  public buButton btn_viewzoomfit;
  public buButton btn_rotate;
  public buButton btn_pan;
  internal ImageList \u0001;
  public TreeView treeView1;
  public buLabel lbl_items;
  public buButton btn_leftup;
  public buButton btn_right;
  public buButton btn_rightdown;
  public buButton btn_left;
  public buButton btn_rightup;
  public buButton btn_up;
  public buButton btn_down;
  public buButton btn_leftdown;
  public buButton btn_undo;
  public buButton btn_clear;
  public buSpin spn_length;
  public static byte f001DE4;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<Point3D> pntList;
  public List<Entity> EntityList;

  public void Init()
  {
    ((F_Marble3DShapeMenu) this).PropertiesForm.Inited = false;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_Marble3DShapeMenu) this).PropertiesForm.Height;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_Marble3DShapeMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_Marble3DShapeMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Marble3DShapeMenu) this).PropertiesForm.FormPosition;
    ((F_Marble3DShapeMenu) this).lst_edges.textName = buLangTranslate.preDef.Name;
    ((F_Marble3DShapeMenu) this).lst_edges.textValue1 = buLangTranslate.preDef.Angle;
    ((F_Marble3DShapeMenu) this).lst_edges.Value1Width = 100;
    ((F_Marble3DShapeMenu) this).lst_edges.FormatType = ValuesFormatType.Double;
    ((F_Marble3DShapeMenu) this).lst_edges.ItemList.Clear();
    ((F_Marble3DShapeMenu) this).lst_edges.ItemList.AddRange((IEnumerable<ValuesItem>) ((F_Marble3DShapeMenu) this).ItemList);
    ((F_Marble3DShapeMenu) this).lst_edges.DrawControls();
    ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_Marble3DShapeMenu) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleEdgeAngleList) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Marble3DShapeMenu) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEdgeAngleList) this);
        ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_Marble3DShapeMenu) this).btn_cancel.Name | control2.Name == ((F_Marble3DShapeMenu) this).btn_close.Name))
        return;
      ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Marble3DShapeMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Marble3DShapeMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCutRemailMaterial() => F_Marble3DShapeMenu.Captions = new List<string>();

  public F_MarbleCutRemailMaterial()
  {
    ((F_Marble3DShapeMenu) this).PropertiesForm = new FormProperties();
    ((F_Marble3DAddMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarblePhotoCalibration) this);
  }

  public void Init()
  {
    ((F_Marble3DShapeMenu) this).PropertiesForm.Inited = false;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_Marble3DShapeMenu) this).PropertiesForm.Height;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_Marble3DShapeMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_Marble3DShapeMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Marble3DShapeMenu) this).PropertiesForm.FormPosition;
    ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_Marble3DShapeMenu) this).PropertiesForm.Inited = true;
    ((F_Marble3DAddMenu) this).spn_basex.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraBaseXPosition;
    ((F_Marble3DAddMenu) this).spn_bssey.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraBaseYPosition;
    ((F_Marble3DAddMenu) this).spn_firstx.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstXPosition;
    ((F_Marble3DAddMenu) this).spn_firsty.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstYPosition;
    ((F_Marble3DAddMenu) this).spn_firstthinckness.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraFirstMaterial;
    ((F_Marble3DAddMenu) this).spn_secondx.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraSecondXPosition;
    ((F_Marble3DAddMenu) this).spn_secondy.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraSecondYPosition;
    ((F_Marble3DAddMenu) this).spn_secondthickness.Value = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).CameraSecondMaterial;
    \u0007.\u0001.\u0001((F_MarblePhotoCalibration) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Marble3DShapeMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_Marble3DAddMenu) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarblePhotoCalibration) this);
        ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_Marble3DAddMenu) this).btn_cancel.Name | control2.Name == ((F_Marble3DAddMenu) this).\u0001.Name))
        return;
      ((F_Marble3DShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Marble3DShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Marble3DAddMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Marble3DAddMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCutRemailMaterial() => F_Marble3DShapeMenu.Captions = new List<string>();
}
