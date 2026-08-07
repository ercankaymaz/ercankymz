// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCountertopEdgeMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopEdgeMenu : Form
{
  public buButton btn_stop;
  public buSpin spn_step;
  public buButton btn_start;
  public buButton btn_OPpauseafter;
  public buButton btn_menuclose;
  public buButton btn_opMenu;
  public Panel pnl_menu;
  public Panel pnl_coords;
  public buButton btn_coords;
  public buLabel lbl_x;
  public buLabel lbl_c;
  public buLabel lbl_y;
  public buLabel lbl_a;
  public buLabel lbl_z;
  internal buSeparator \u0001;
  public buButton btn_OPtoolchange;
  public buCheckBox chk_showdimensiondraws;
  public static byte f001AEA;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public int StartLine;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCoordinatesV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCoordinatesV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCountertopEdgeMenu() => F_MarbleCoordinatesV1.Captions = new List<string>();

  public F_MarbleCountertopEdgeMenu()
  {
    ((F_MarbleJobList) this).\u0001 = "F_MarbleCoordinatesV2";
    ((F_MarbleJobList) this).PropertiesForm = new FormProperties();
    ((F_MarbleJobList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleBottomPanelV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      if (!((F_MarbleJobList) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce && new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleJobList) this).pnl_base.Controls);
        controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCommandsV1) this).pnl_info.Controls);
        ((F_MarbleJobList) this).PropertiesForm.VisualUpdated = true;
      }
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleJobList) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleJobList) this).PropertiesForm.Inited = false;
    if (((F_MarbleJobList) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleJobList) this).PropertiesForm.Height;
    if (((F_MarbleJobList) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleJobList) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleJobList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleJobList) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleJobList) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleJobList) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleJobList) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleJobList) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleJobList) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleJobList) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
