// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCircularShapeResolution
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCircularShapeResolution : Form
{
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buSpin spn_itemlen1;
  public buButton btn_minimise;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_open;
  public buButton btn_itemdown;
  public buButton btn_itemup;

  public F_MarbleCircularShapeResolution()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleHorVerCutV2) this).varSurfaceClean = (marbleSurfaceCleanPars) new \u0007.\u0001();
    ((F_MarbleHorVerCutV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleStockClear) this);
  }

  public void Init()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorVerCutV2) this).PropertiesForm.Height;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorVerCutV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorVerCutV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorVerCutV2) this).PropertiesForm.FormPosition;
    ((F_MarbleHorVerCutV2) this).spn_safedis.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).SafeDistance;
    ((F_MarbleHorVerCutV2) this).spn_rapiddis.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).RapidDistance;
    ((F_MarbleHorVerCutV2) this).spn_stepdistance.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).StepDownDistance;
    ((F_MarbleHorVerCutV2) this).spn_cuttingfeed.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).CuttingFeed;
    ((F_MarbleHorVerCutV2) this).spn_plunfefeed.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).PlungeFeed;
    ((F_MarbleHorVerCutV2) this).spn_zoffset.Value = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).ZOffset;
    ((F_MarbleHorVerCutV2) this).chk_zigzag.Check = ((MarbleCamType) ((F_MarbleHorVerCutV2) this).varSurfaceClean).ZigzagMode;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleStockClear) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleStockClear) this);
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleHorVerCutV2) this).btn_cancel.Name))
        return;
      ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleHorVerCutV2) this).PropertiesForm.Inited)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCircularShapeResolution() => F_MarbleHorVerCutV2.Captions = new List<string>();

  [CompilerGenerated]
  [SpecialName]
  public void add_VacuumCommand(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorVerCutV2) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorVerCutV2) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_VacuumCommand(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorVerCutV2) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorVerCutV2) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_MarbleCircularShapeResolution()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleHorVerCutV2) this).\u0001 = "F_MarbleVacuumMove";
    ((F_MarbleHorVerCutV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleVacuumMove) this);
  }

  public void Init()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorVerCutV2) this).PropertiesForm.Height;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorVerCutV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorVerCutV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorVerCutV2) this).PropertiesForm.FormPosition;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleVacuumMove) this);
    ((F_MarbleCuttingSequence) this).UpdateVisuals();
  }
}
