// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditBaseHAndXYZ
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components.Marble;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEditBaseHAndXYZ : Form
{
  internal ImageList \u0002;
  public buPanel pnl_base;
  public buMarbleOPItem Op16;
  public buMarbleOPItem Op15;
  public buMarbleOPItem Op14;
  public buMarbleOPItem Op13;
  public buMarbleOPItem Op12;
  public buMarbleOPItem Op11;
  public buMarbleOPItem Op10;
  public buMarbleOPItem Op9;
  public buMarbleOPItem Op8;
  public buMarbleOPItem Op7;
  public buMarbleOPItem Op6;
  public buMarbleOPItem Op5;

  public void Init()
  {
    ((F_MarbleViewV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleViewV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleViewV1) this).PropertiesForm.Height;
    if (((F_MarbleViewV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleViewV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleViewV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleViewV1) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleViewV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleViewV1) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleViewV1) this).ground_base.Text = buLangTranslate.preDef.Drawing;
      ((F_MarbleViewV1) this).btn_polyline.Text = buLangTranslate.preDef.Polyline;
      ((F_MarbleViewV1) this).btn_arc.Text = buLangTranslate.preDef.Arc;
      ((F_MarbleViewV1) this).btn_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_MarbleCountertopCornerMenu) this).btn_delete.Text = buLangTranslate.preDef.Delete;
      ((F_MarbleViewV1) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleViewV1) this).btn_polyline.Text = buLangTranslate.preDef.Polyline;
      ((F_MarbleCountertopCornerMenu) this).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleViewV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleViewV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleViewV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleViewV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleViewV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleViewV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleViewV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleViewV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleViewV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditBaseHAndXYZ() => F_MarbleViewV1.Captions = new List<string>();

  public F_MarbleEditBaseHAndXYZ()
  {
    ((F_MarbleCountertopCornerMenu) this).\u0001 = "F_MarbleCoordinatesV1";
    ((F_MarbleCountertopCornerMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleCountertopCornerMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleJobOPListV2) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      ((F_MarbleEditBaseHAndXYFrame) this).LoadLanguage();
      if (!(!((F_MarbleCountertopCornerMenu) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCountertopCornerMenu) this).pnl_base.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCountertopEdgeMenu) this).pnl_menu.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCountertopEdgeMenu) this).pnl_coords.Controls);
      ((F_MarbleCountertopCornerMenu) this).PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopCornerMenu) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleCountertopCornerMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Height;
    if (((F_MarbleCountertopCornerMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCountertopCornerMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCountertopCornerMenu) this).PropertiesForm.FormPosition;
    ((F_MarbleEditBaseHAndXYFrame) this).LoadLanguage();
    ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Inited = true;
  }
}
