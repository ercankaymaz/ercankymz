// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditBaseH
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buMutliTextbox;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEditBaseH : Form
{
  public buGround ground_base;
  public buButton btn_close;
  public buMultiTextBox txt_gcode;
  public buLabel lbl_slash;
  public buLabel lbl_totalline;
  public buLabel lbl_actualline;
  public buButton btn_size_2_0;
  public buButton btn_size_1_5;
  public buButton btn_normalsize;
  public static byte f001B48;

  public void Init()
  {
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Inited = false;
    if (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Height;
    if (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Inited = true;
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
    if (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditBaseDepthAndOffsetXYPlanes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditBaseH()
  {
    F_MarbleEditBaseDepthAndOffsetXYPlanes.Captions = new List<string>();
  }

  public F_MarbleEditBaseH()
  {
    ((F_MarbleEditBaseHAndXYFrame) this).\u0001 = "F_MarbleCoordinatesV1";
    ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm = new FormProperties();
    ((F_MarbleEditBaseHAndXYFrame) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCoordinatesV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      ((F_MarbleEventBreak) this).LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce))
        return;
      if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleEditLength) this).pnl_base.Controls);
        ((F_MarbleEditBaseHAndXYFrame) this).PropertiesForm.VisualUpdated = true;
      }
      ((F_MarbleEditOperation) this).lbl_x.Display.Border.Visible = false;
      ((F_MarbleEditOperation) this).lbl_x.Display.BackColor = Color.Transparent;
      ((F_MarbleEditOperation) this).lbl_y.Display.Border.Visible = false;
      ((F_MarbleEditOperation) this).lbl_y.Display.BackColor = Color.Transparent;
      ((F_MarbleEditOperation) this).lbl_z.Display.Border.Visible = false;
      ((F_MarbleEditOperation) this).lbl_z.Display.BackColor = Color.Transparent;
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_a.Display.Border.Visible = false;
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_a.Display.BackColor = Color.Transparent;
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_c.Display.Border.Visible = false;
      ((F_MarbleEditBaseHAndXYFrame) this).lbl_c.Display.BackColor = Color.Transparent;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEditBaseHAndXYFrame) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
