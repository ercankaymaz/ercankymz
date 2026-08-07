// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCut : Form
{
  public buButton btn_editor;
  public buButton btn_fromfile;
  public buButton btn_close;
  public buButton btn_fromtable;
  public buButton btn_coordinate;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public static byte f0028E0;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleMatrialCleanPars varMaterialClean;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_safedis;
  public buSpin spn_operationz;
  public buSpin spn_baseheight;
  public buCheckBox chk_zigzag;
  public buSpin spn_basewidth;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  internal ImageList \u0002;
  public buSpin spn_stepdistance;
  public buSpin spn_cuttingfeed;
  public buSpin spn_plunfefeed;
  public buSpin spn_spindlespeed;
  public buSpin spn_startY;
  public buSpin spn_startX;
  public buSpin spn_rapiddis;
  public buSpin spn_zdownstep;
  public buCheckBox chk_toolmillinghead;
  public buCheckBox chk_toolsaw;
  public buCheckBox chk_toolmilling;
  public buSpin spn_starthegiht;
  public buSpin spn_cangle;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public MaterialBase5 Mat;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_matdepth;
  public buSpin spn_matheight;
  public buSpin spn_matWdith;
  public buButton btn_ok;
  public buButton btn_cancel;

  public void StrategySawToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyWaterToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void ToolToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyFromToolType()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCutting) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCutting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCutting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCutting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
