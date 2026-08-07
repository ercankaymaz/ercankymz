// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventBreak
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventBreak : Form
{
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_viewleft;
  public buButton btn_viewfront;
  public buButton btn_zoomfit;
  public buButton btn_viewiso;
  public buButton btn_viewtop;
  public buButton btn_viewclose;
  public buButton btn_viewrotate;
  public buButton btn_viewpan;

  public void Init()
  {
    ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Inited = false;
    if (((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Height;
    if (((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_machine.Text = buLangTranslate.preDef.Machine;
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_part.Text = buLangTranslate.preDef.Part;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    MarbleDisplayViewportSettings.PartCoordShowModeChanged = true;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    MarbleDisplayViewportSettings.MachineCoordShowModeChanged = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditBaseHAndXYFrame) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditBaseHAndXYFrame) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventBreak() => F_MarbleEditBaseHAndXYFrame.Captions = new List<string>();

  public F_MarbleEventBreak()
  {
    ((F_MarbleEditLength) this).\u0001 = "F_MarbleGCodeViewV1";
    ((F_MarbleEditLength) this).PropertiesForm = new FormProperties();
    ((F_MarbleEditLength) this).BaseWidth = 555;
    ((F_MarbleEditLength) this).BaseHeight = 575;
    ((F_MarbleEditLength) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleGCodeViewV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      ((F_MarbleEventOffset) this).LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleEditLength) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleEditBaseH) this).ground_base.Controls);
      ((F_MarbleEditLength) this).PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEditLength) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
