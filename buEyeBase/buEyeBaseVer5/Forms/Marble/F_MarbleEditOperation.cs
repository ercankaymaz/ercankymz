// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditOperation
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

public class F_MarbleEditOperation : Form
{
  public buLabel lbl_machinea;
  public buLabel lbl_parta;
  public buLabel lbl_z;
  public buLabel lbl_machinez;
  public buLabel lbl_partz;
  public buLabel lbl_y;
  public buLabel lbl_machiney;
  public buLabel lbl_party;
  public buLabel lbl_x;
  public buLabel lbl_machinex;
  public buLabel lbl_partx;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleEditBaseHAndOffsetXY) this).btn_cancel.Name | control.Name == ((F_MarbleEditBaseHAndOffsetXY) this).btn_close.Name)
    {
      ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_MarbleEditBaseHAndOffsetXY) this).btn_ok.Name))
      return;
    ((F_MarbleCountertopEdgeMenu) this).StartLine = (int) ((F_MarbleEditBaseHAndOffsetXY) this).spn_startline.Value;
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditBaseHAndOffsetXY) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditBaseHAndOffsetXY) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditOperation() => F_MarbleCountertopEdgeMenu.Captions = new List<string>();

  public F_MarbleEditOperation()
  {
    ((F_MarbleEditBaseHAndOffsetXY) this).\u0001 = "F_MarbleGCodeViewV1";
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm = new FormProperties();
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleWarnings) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      if (clsVisualVars.parVisual.hmiPopup1LabelsProps != null)
        ;
      if (clsVisualVars.parVisual.hmiPopup1TextProps != null)
        ;
      ((F_MarbleEditLength) this).LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEditBaseHAndOffsetXY) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Inited = false;
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Height;
    if (((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.FormPosition;
    ((F_MarbleEditLength) this).LoadLanguage();
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEditBaseHAndOffsetXY) this).PropertiesForm.Inited = true;
  }
}
