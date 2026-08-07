// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditBaseHAndOffsetXY
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
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

public class F_MarbleEditBaseHAndOffsetXY : Form
{
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_startline;
  public static byte f001AF7;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleSpeedsV1) this).btn_motorcurrent.Name)
      ((F_MarbleSpeedsV1) this).buTab_Main.SelectedIndex = 0;
    if (control.Name == ((F_MarbleSpeedsV1) this).btn_gcode.Name)
      ((F_MarbleSpeedsV1) this).buTab_Main.SelectedIndex = 1;
    if (control.Name == ((F_MarbleSpeedsV1) this).btn_operation.Name)
      ((F_MarbleSpeedsV1) this).buTab_Main.SelectedIndex = 2;
    this.MenuButtonColors(((F_MarbleSpeedsV1) this).buTab_Main.SelectedIndex);
  }

  public void MenuButtonColors(int PageIndex)
  {
    if (clsVisualVars.parVisual == null)
      return;
    buEyeShotFunctions.SetVisualItem(((F_MarbleCommandsV1) this).pnl_info.Controls);
    if (PageIndex == 0)
    {
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonDownDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonDownDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonDownDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonOverDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonOverDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_motorcurrent.ButtonOverDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      ((F_MarbleSpeedsV1) this).btn_gcode.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonDownDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonDownDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonDownDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonOverDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonOverDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSpeedsV1) this).btn_gcode.ButtonOverDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (PageIndex != 2)
      return;
    ((F_MarbleSpeedsV1) this).btn_operation.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonDownDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonDownDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonDownDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonOverDisplay.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonOverDisplay.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleSpeedsV1) this).btn_operation.ButtonOverDisplay.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleJobList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleJobList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditBaseHAndOffsetXY() => F_MarbleJobList.Captions = new List<string>();

  public F_MarbleEditBaseHAndOffsetXY()
  {
    ((F_MarbleCommandsV1) this).\u0001 = "F_MarbleCoordinatesV2";
    ((F_MarbleCommandsV1) this).PropertiesForm = new FormProperties();
    ((F_MarbleCommandsV1) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCoordinatesV2) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      this.LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleCommandsV1) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce))
        return;
      if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleViewV1) this).pnl_base.Controls);
        ((F_MarbleCommandsV1) this).PropertiesForm.VisualUpdated = true;
      }
      ((F_MarbleViewV1) this).lbl_x.Display.Border.Visible = false;
      ((F_MarbleViewV1) this).lbl_x.Display.BackColor = Color.Transparent;
      ((F_MarbleViewV1) this).lbl_y.Display.Border.Visible = false;
      ((F_MarbleViewV1) this).lbl_y.Display.BackColor = Color.Transparent;
      ((F_MarbleViewV1) this).lbl_z.Display.Border.Visible = false;
      ((F_MarbleViewV1) this).lbl_z.Display.BackColor = Color.Transparent;
      ((F_MarbleViewV1) this).lbl_a.Display.Border.Visible = false;
      ((F_MarbleViewV1) this).lbl_a.Display.BackColor = Color.Transparent;
      ((F_MarbleViewV1) this).lbl_c.Display.Border.Visible = false;
      ((F_MarbleViewV1) this).lbl_c.Display.BackColor = Color.Transparent;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCommandsV1) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleCommandsV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleCommandsV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCommandsV1) this).PropertiesForm.Height;
    if (((F_MarbleCommandsV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCommandsV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCommandsV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCommandsV1) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleCommandsV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCommandsV1) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCommandsV1) this).lbl_machine.Text = buLangTranslate.preDef.Machine;
      ((F_MarbleViewV1) this).lbl_part.Text = buLangTranslate.preDef.Part;
    }
    catch (Exception ex)
    {
    }
  }
}
