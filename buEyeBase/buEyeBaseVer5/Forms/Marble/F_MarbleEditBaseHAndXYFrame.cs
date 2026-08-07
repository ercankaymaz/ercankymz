// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditBaseHAndXYFrame
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components.Marble;
using buControls.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEditBaseHAndXYFrame : Form
{
  public buMarbleOPItem Op4;
  public buMarbleOPItem Op3;
  public buMarbleOPItem Op2;
  public buMarbleOPItem Op1;
  public buMarbleOPItem Op18;
  public buMarbleOPItem Op17;
  public static byte f001B1D;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buLabel lbl_machine;
  public buLabel lbl_part;
  public buLabel lbl_c;
  public buLabel lbl_machinec;
  public buLabel lbl_partc;
  public buLabel lbl_a;

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCountertopEdgeMenu) this).spn_step.Caption.Caption = buLangTranslate.preDef.Simulation;
      ((F_MarbleCountertopEdgeMenu) this).btn_coords.Text = buLangTranslate.preDef.Coordinate;
      ((F_MarbleCountertopEdgeMenu) this).btn_OPpauseafter.Text = buLangTranslate.preSentencesMarble.PauseAfterOperation;
      ((F_MarbleCountertopEdgeMenu) this).btn_OPtoolchange.Text = buLangTranslate.preDef.ToolChange;
      ((F_MarbleCountertopEdgeMenu) this).btn_menuclose.Text = $"{buLangTranslate.preDef.Menu} {buLangTranslate.preDef.Close}";
      ((F_MarbleCountertopEdgeMenu) this).chk_showdimensiondraws.Text = $"{buLangTranslate.preDef.Show} {buLangTranslate.preDef.Dimension} {buLangTranslate.preDef.Draw}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCountertopCornerMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCountertopCornerMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCountertopCornerMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCountertopCornerMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCountertopEdgeMenu) this).btn_menuclose.Name)
      ((F_MarbleCountertopEdgeMenu) this).pnl_menu.Visible = false;
    if (!(control.Name == ((F_MarbleCountertopEdgeMenu) this).btn_coords.Name))
      return;
    if (!((F_MarbleCountertopEdgeMenu) this).pnl_coords.Visible)
      ((F_MarbleCountertopEdgeMenu) this).pnl_coords.Visible = true;
    else
      ((F_MarbleCountertopEdgeMenu) this).pnl_coords.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCountertopCornerMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCountertopCornerMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditBaseHAndXYFrame()
  {
    F_MarbleCountertopCornerMenu.Captions = new List<string>();
  }

  public F_MarbleEditBaseHAndXYFrame()
  {
    ((F_MarbleCountertopEdgeMenu) this).\u0001 = "F_MarbleStartLine";
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleCountertopEdgeMenu) this).StartLine = 0;
    ((F_MarbleEditBaseHAndOffsetXY) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleStartLine) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      this.LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleCountertopEdgeMenu) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleEditBaseHAndOffsetXY) this).ground_base.Controls);
      ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopEdgeMenu) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Height;
    if (((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.FormPosition;
    ((F_MarbleEditBaseHAndOffsetXY) this).spn_startline.Value = (double) ((F_MarbleCountertopEdgeMenu) this).StartLine;
    this.LoadLanguage();
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCountertopEdgeMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEditBaseHAndOffsetXY) this).ground_base.Text = "";
      ((F_MarbleEditBaseHAndOffsetXY) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleEditBaseHAndOffsetXY) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleEditBaseHAndOffsetXY) this).spn_startline.Caption.Caption = buLangTranslate.preDef.StartLine;
    }
    catch (Exception ex)
    {
    }
  }
}
