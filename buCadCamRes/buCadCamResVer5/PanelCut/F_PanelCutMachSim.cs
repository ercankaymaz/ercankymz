// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.PanelCut.F_PanelCutMachSim
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.PanelCut;

public class F_PanelCutMachSim : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  private Timer timer_0 = new Timer();
  public static bool OnlySimilator = false;
  public static bool Connected = false;
  internal IContainer icontainer_0 = (IContainer) null;
  public buMultiTextBox txt_gcode;
  internal Button button_0;
  internal Button button_1;
  internal CheckBox checkBox_0;
  public Panel pnl_code;
  public Panel pnl_viewport;
  public Label lbl_ycoord;
  public Label lbl_zcoord;
  public Label lbl_xcoord;
  public SplitContainer splitContainer1;
  internal TrackBar trackBar_0;
  public Label lbl_z;
  public Label lbl_y;
  public Label lbl_x;
  internal Button button_2;
  internal ImageList imageList_0;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Button button_8;
  internal Button button_9;
  public Panel pnl_viewportpanel;
  public Panel pnl_viewportwaiting;
  public Panel pnl_viewportdone;

  public F_PanelCutMachSim()
  {
    Class5.smethod_203(this);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
  }

  public event ValueChangedWithDataEventHandler ValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    this.trackBar_0.Value = clsPanelCut.varPanelCutRunSettings.SimStep;
    this.checkBox_0.Checked = clsPanelCut.varPanelCutRunSettings.StepRun;
    clsPanelCut.viewportAuto.WaitCursorMode = waitCursorType.Never;
    this.timer_0.Interval = 100;
    this.timer_0.Enabled = true;
    this.PropertiesForm.Inited = true;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    clsInit.appPanelCut.DrawEntities(true);
    clsPanelCut.viewportAuto.SetView(viewType.vcTopFaceLeft);
    clsPanelCut.viewportAuto.ZoomFit();
    clsPanelCut.viewportAuto.Invalidate();
    clsPanelCut.viewportAutoPanel.SetView(viewType.Top);
    clsPanelCut.viewportAutoPanel.ZoomFit();
    clsPanelCut.viewportAutoPanel.Invalidate();
    this.timer_0.Enabled = false;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    clsPanelCut.varPanelCutRunSettings.SimStep = this.trackBar_0.Value;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedWithDataEventHandler_0((double) clsPanelCut.varPanelCutRunSettings.SimStep, (object) "Track");
  }

  internal void method_1(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      clsPanelCut.varPanelCutRunSettings.StepRun = this.checkBox_0.Checked;
      if (!F_PanelCutMachSim.Connected)
        clsInit.appPanelCut.cmdStartSimulation(this.checkBox_0.Checked);
    }
    if (control2.Name == this.button_1.Name && !F_PanelCutMachSim.Connected)
      clsInit.appPanelCut.cmdStopSimulation();
    if (control2.Name == this.button_3.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Rear);
    if (control2.Name == this.button_8.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Front);
    if (control2.Name == this.button_2.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Left);
    if (control2.Name == this.button_6.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Right);
    if (control2.Name == this.button_7.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Top);
    if (control2.Name == this.button_4.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Bottom);
    if (control2.Name == this.button_5.Name)
      clsInit.appPanelCut.cmdSetView(viewType.Isometric);
    if (!(control2.Name == this.button_9.Name))
      return;
    clsInit.appPanelCut.cmdZoomFit();
  }

  internal void method_2(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      this.splitContainer1.SplitterDistance = Convert.ToInt32((double) this.Width / 1.4);
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
