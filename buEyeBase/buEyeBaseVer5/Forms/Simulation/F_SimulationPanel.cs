// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Simulation.F_SimulationPanel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Viewport;
using buEyeBaseVer5.Forms.Vision;
using buEyeBaseVer5.Forms.Watch;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Simulation;

public class F_SimulationPanel : Form
{
  internal Button \u0004;
  internal Button \u0005;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Button \u0006;
  internal Button \u0007;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  public static byte f0010BE;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<Picture> Images;
  public List<int> ImageIndex;
  private int \u0001;

  public void ControlUpdate()
  {
    ((F_CameraLive) this).\u0001.Enabled = false;
    if (((F_ViewportMouseCfg) this).\u0002.SelectedIndex == 11)
      ((F_CameraLive) this).\u0001.Enabled = true;
    ((F_ViewportMouseCfg) this).\u0002.Enabled = false;
    if (!(((F_ViewportMouseCfg) this).\u0002.SelectedIndex == 12 | ((F_ViewportMouseCfg) this).\u0002.SelectedIndex == 13))
      return;
    ((F_ViewportMouseCfg) this).\u0002.Enabled = true;
  }

  public void Apply()
  {
    ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).NextGroupRules = (SortingNextGroupFindRulesType) ((F_ViewportMouseCfg) this).\u0002.SelectedIndex;
    ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).IntersectionRules = (SortingIntersectionRulesType) ((F_CameraLive) this).\u0001.SelectedIndex;
    ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).isFirstPointCatchFromStartPointForDrawSequence = ((F_CameraLive) this).\u0001.Checked;
    ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).Resolution = (double) ((F_CameraLive) this).\u0001.Value;
    ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).ConstantPoint = new Point3D((double) ((F_ViewportMouseCfg) this).\u0002.Value, (double) ((F_ViewportMouseCfg) this).\u0004.Value, (double) ((F_ViewportMouseCfg) this).\u0003.Value);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_WatchByGrid) this).PropertiesForm.Inited)
      return;
    ((F_WatchByGrid) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_WatchByGrid) this).PropertiesForm.TouchPad & !((F_CameraLive) this).\u0002.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    if (((Control) obj0).Enabled)
      ;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_WatchByGrid) this).PropertiesForm.Inited)
      return;
    ((F_WatchByGrid) this).PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    ((F_WatchByGrid) this).PropertiesForm.Inited = true;
    this.\u0006(obj0, (EventArgs) null);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_WatchByGrid) this).PropertiesForm.Inited)
      return;
    ((F_WatchByGrid) this).PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    ((F_WatchByGrid) this).PropertiesForm.Inited = true;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    ((F_CameraLive) this).\u0002.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_WatchByGrid) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_WatchByGrid) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SimulationPanel() => F_WatchByGrid.Captions = new List<string>();

  public F_SimulationPanel()
  {
    ((F_ViewportMouseCfg) this).PropertiesForm = new FormProperties();
    ((F_ViewportMouseCfg) this).Tools = new List<ToolBase5>();
    ((F_ViewportMouseCfg) this).SelectedTool = (ToolBase5) new ToolGeometry5();
    ((F_ViewportMouseCfg) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ToolList) this);
  }

  public void Init()
  {
    ((F_ViewportMouseCfg) this).PropertiesForm.Inited = false;
    if (((F_ViewportMouseCfg) this).PropertiesForm.Height > 10)
      this.Height = ((F_ViewportMouseCfg) this).PropertiesForm.Height;
    if (((F_ViewportMouseCfg) this).PropertiesForm.Width > 10)
      this.Width = ((F_ViewportMouseCfg) this).PropertiesForm.Width;
    this.TopMost = ((F_ViewportMouseCfg) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ViewportMouseCfg) this).PropertiesForm.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ToolList) this);
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ToolList) this);
    ((F_ViewportMouseCfg) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ViewportMouseCfg) this).btn_ok.Name)
    {
      ((F_ViewportMouseCfg) this).btn_ok.Focus();
      \u0007.\u0001.\u0001((F_ToolList) this);
      ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_ViewportMouseCfg) this).btn_cancel.Name))
      return;
    ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ViewportMouseCfg) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ViewportMouseCfg) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ViewportMouseCfg) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithThreeDataEventHandler CommandExecute;
}
