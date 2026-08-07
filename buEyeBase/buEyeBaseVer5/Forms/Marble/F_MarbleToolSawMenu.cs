// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSawMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMenu : Form
{
  public TabPage tabPage_saw;
  public buButton btn_saw_activate;
  public buButton btn_saw_zeroposition;
  public buButton btn_sawgonyele;
  public buButton btn_sawlimitdisable;
  public buButton btn_saw_measure;
  public buSpin spn_sawspeed;
  public buSpin spn_sawthickness;
  public buSpin spn_sawdia;

  public void Apply()
  {
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_milling_diameter.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).Geometry.Length = ((F_MarbleOperationCmds) this).spn_milling_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_milling_speed.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry.Length = ((F_MarbleProfileCamStrategyMenu) this).spn_toollen1.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry.Length = ((F_MarbleProfileCamStrategyMenu) this).spn_toollen2.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry.Length = ((F_MarbleOperationCmds) this).spn_toollen3.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry.Length = ((F_MarbleOperationCmds) this).spn_toollen4.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry.Length = ((F_MarbleOperationCmds) this).spn_toollen5.Value;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry.Length = ((F_MarbleOperationCmds) this).spn_toollen6.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry.Diameter = ((F_MarbleProfileCamStrategyMenu) this).spn_tooldia1.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_tooldia2.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_tooldia3.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_tooldia4.Value;
    ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_tooldia5.Value;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry.Diameter = ((F_MarbleOperationCmds) this).spn_tooldia6.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).CamData).SpindleSpeed = ((F_MarbleProfileCamStrategyMenu) this).spn_toolspeed1.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_toolspeed2.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_toolspeed3.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_toolspeed4.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_toolspeed5.Value;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).CamData).SpindleSpeed = ((F_MarbleOperationCmds) this).spn_toolspeed6.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.X = ((F_MarbleSheetMenu) this).spn_toolX1.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.X = ((F_MarbleSheetMenu) this).spn_toolX2.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.X = ((F_MarbleCounterTopMenu) this).spn_toolX3.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.X = ((F_MarbleCounterTopMenu) this).spn_toolX4.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.X = ((F_MarbleCounterTopMenu) this).spn_toolX5.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.X = ((F_MarbleCounterTopMenu) this).spn_toolX6.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.Y = ((F_MarbleSheetMenu) this).spn_toolY1.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.Y = ((F_MarbleSheetMenu) this).spn_toolY2.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.Y = ((F_MarbleCounterTopMenu) this).spn_toolY3.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.Y = ((F_MarbleCounterTopMenu) this).spn_toolY4.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.Y = ((F_MarbleCounterTopMenu) this).spn_toolY5.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.Y = ((F_MarbleCounterTopMenu) this).spn_toolY6.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.Z = ((F_MarbleSheetMenu) this).spn_toolZ1.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.Z = ((F_MarbleCounterTopMenu) this).spn_toolZ2.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.Z = ((F_MarbleCounterTopMenu) this).spn_toolZ3.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.Z = ((F_MarbleCounterTopMenu) this).spn_toolZ4.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.Z = ((F_MarbleCounterTopMenu) this).spn_toolZ5.Value;
    ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.Z = ((F_MarbleCounterTopMenu) this).spn_toolZ6.Value;
    if (!((F_MarbleImageMenu) this).chk_round1.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry).GeometryType = ToolType.Sphere;
    if (!((F_MarbleImageMenu) this).chk_round2.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry).GeometryType = ToolType.Sphere;
    if (!((F_MarbleImageMenu) this).chk_round3.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry).GeometryType = ToolType.Sphere;
    if (!((F_MarbleImageMenu) this).chk_round4.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry).GeometryType = ToolType.Sphere;
    if (!((F_MarbleImageMenu) this).chk_round5.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry).GeometryType = ToolType.Sphere;
    if (!((F_MarbleImageMenu) this).chk_round6.Check)
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry).GeometryType = ToolType.Flat;
    else
      ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry).GeometryType = ToolType.Sphere;
  }

  public void UpdateMagazineLength(int activetool, double Length)
  {
    if (!(activetool >= 1 & activetool <= 6) || Length <= 0.0)
      return;
    if (activetool == 1)
      ((F_MarbleProfileCamStrategyMenu) this).spn_toollen1.Value = Length;
    if (activetool == 2)
      ((F_MarbleProfileCamStrategyMenu) this).spn_toollen2.Value = Length;
    if (activetool == 3)
      ((F_MarbleOperationCmds) this).spn_toollen3.Value = Length;
    if (activetool == 4)
      ((F_MarbleOperationCmds) this).spn_toollen4.Value = Length;
    if (activetool == 5)
      ((F_MarbleOperationCmds) this).spn_toollen5.Value = Length;
    if (activetool != 6)
      return;
    ((F_MarbleOperationCmds) this).spn_toollen6.Value = Length;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleOperationCmds) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleOperationCmds) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buButton buButton = obj0 as buButton;
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleOperationCmds) this).\u0001 == null)
      return;
    if (buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve1.Name | buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve2.Name | buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve3.Name | buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve4.Name | buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve5.Name | buButton.Name == ((F_MarbleProfileCamStrategyMenu) this).btn_toolacitve6.Name)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 17, (object) buButton.Aux.Index, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake1.Name | buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake2.Name | buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake3.Name | buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake4.Name | buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake5.Name | buButton.Name == ((F_MarbleSheetMenu) this).btn_tooltake6.Name)
    {
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 18, (object) buButton.Aux.Index, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_doorclose.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 20, (object) null, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleImageMenu) this).btn_dooropen.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 19, (object) null, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_magazineclose.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 22, (object) null, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_magazineopen.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 21, (object) null, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_pensclose.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 24, (object) null, (object) null, (object) null, (object) null);
    }
    if (buButton.Name == ((F_MarbleSheetMenu) this).btn_pensopen.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 23, (object) null, (object) null, (object) null, (object) null);
    }
    if (!(buButton.Name == ((F_MarbleOperationCmds) this).btn_magazine_measure.Name))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_MarbleOperationCmds) this).\u0001((object) (MarbleHMICommands) 15, (object) null, (object) null, (object) null, (object) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleOperationCmds) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleOperationCmds) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolSawMenu() => F_MarbleOperationCmds.Captions = new List<string>();

  public F_MarbleToolSawMenu()
  {
    ((F_MarbleImageMenu) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleImageMenu) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleImageMenu) this).ToolSaw = (ToolBase5) new ToolGeometry5();
    ((F_MarbleImageMenu) this).ToolMillingHead = (ToolBase5) new ToolGeometry5();
    ((F_MarbleImageMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleImageMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleToolSawMillingHead) this);
  }

  public void Init()
  {
    ((F_MarbleImageMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleImageMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleImageMenu) this).PropertiesForm.Height;
    if (((F_MarbleImageMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleImageMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleImageMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleImageMenu) this).PropertiesForm.FormPosition;
    this.spn_sawdia.Value = ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).Geometry.Diameter;
    this.spn_sawthickness.Value = ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).Geometry).Thickness;
    this.spn_sawspeed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).CamData).SpindleSpeed;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_diameter.Value = ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_length.Value = ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).Geometry.Length;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).CamData).SpindleSpeed;
    ((F_MarbleDigitalInputOutput) this).LoadLanguage();
    ((F_MarbleImageMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleImageMenu) this).PropertiesForm.Inited = true;
  }
}
