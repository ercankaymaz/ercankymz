// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.F_DrillMachSim
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Drill;

public class F_DrillMachSim : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  public DrillMachineType MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
  private Timer timer_0 = new Timer();
  public static bool OnlySimilator = false;
  public static bool Connected = false;
  private IContainer icontainer_0 = (IContainer) null;
  public buMultiTextBox txt_gcode;
  internal Button button_0;
  internal Button button_1;
  internal CheckBox checkBox_0;
  public Panel pnl_code;
  public Panel pnl_viewport;
  public Label lbl_x2;
  public Label lbl_y2;
  public Label lbl_y1;
  public Label lbl_z1;
  public Label lbl_y3;
  public Label lbl_z3;
  public Label lbl_z2;
  public Label lbl_x1;
  public SplitContainer splitContainer1;
  internal TrackBar trackBar_0;
  internal CheckBox checkBox_1;
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
  internal CheckBox checkBox_2;
  internal Button button_10;
  internal Button button_11;
  public Panel pnl_cmd;

  public F_DrillMachSim() => Class5.smethod_7(this);

  public event ValueChangedWithDataEventHandler ValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    this.trackBar_0.Value = clsDrill.varDrillRunSettings.SimStep;
    this.checkBox_0.Checked = clsDrill.varDrillRunSettings.StepRun;
    this.checkBox_1.Checked = clsDrill.varDrillRunSettings.CollisionCheck;
    this.checkBox_2.Checked = clsDrill.varDrillRunSettings.SimStopAtMatReady;
    clsDrill.viewportAuto.WaitCursorMode = waitCursorType.Never;
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      clsInit.appDrill.cGoUltra2Up1Down.DrawEntities(true);
    if (this.MachType == DrillMachineType.GoWithAtc)
      clsInit.appDrill.cGoAtc.DrawEntities(true);
    if (this.MachType == DrillMachineType.Sirius)
      clsInit.appDrill.cGoSirius.DrawEntities(true);
    clsDrill.viewportAuto.SetView(viewType.vcFrontFaceTopLeft);
    if (clsDrill.activeJob != null)
      this.txt_gcode.Text = buString5.StringListToString(clsDrill.activeJob.Codes, true);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_0.Interval = 50;
    this.timer_0.Enabled = true;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    this.Text = $"{buLangTranslate.preDef.Machine} {buLangTranslate.preDef.Simulation}";
    this.checkBox_1.Text = buLangTranslate.preDef.Collision;
    this.checkBox_0.Text = buLangTranslate.preDef.Step;
    this.checkBox_2.Text = buLangTranslate.preSentences.StopAtWaitCommand;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    clsDrill.viewportAuto.ZoomFit();
    clsDrill.viewportAuto.Invalidate();
    this.timer_0.Enabled = false;
    this.PropertiesForm.Inited = true;
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      clsInit.appDrill.cGoUltra2Up1Down.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
    if (this.MachType == DrillMachineType.GoWithAtc)
      clsInit.appDrill.cGoAtc.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
    if (this.MachType != DrillMachineType.Sirius)
      return;
    clsInit.appDrill.cGoSirius.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    clsDrill.varDrillRunSettings.SimStep = this.trackBar_0.Value;
    // ISSUE: reference to a compiler-generated field
    if (this.valueChangedWithDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.valueChangedWithDataEventHandler_0((double) clsDrill.varDrillRunSettings.SimStep, (object) "Track");
  }

  internal void method_1(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      clsDrill.varDrillRunSettings.StepRun = this.checkBox_0.Checked;
      if (!F_DrillMachSim.Connected)
      {
        clsDrill.varDrillRunSettings.SimStopAtMatReady = this.checkBox_2.Checked;
        clsInit.appDrill.cmdStartSimulation(this.checkBox_0.Checked);
      }
    }
    if (control2.Name == this.button_1.Name && !F_DrillMachSim.Connected)
      clsInit.appDrill.cmdStopSimulation();
    if (control2.Name == this.button_10.Name && !F_DrillMachSim.Connected)
      clsInit.appDrill.cmdPreSimulation();
    if (control2.Name == this.button_11.Name && !F_DrillMachSim.Connected)
      clsInit.appDrill.cmdNextSimulation();
    if (control2.Name == this.button_3.Name)
      clsInit.appDrill.cmdSetView(viewType.Rear, drillViewports.Simulation);
    if (control2.Name == this.button_8.Name)
      clsInit.appDrill.cmdSetView(viewType.Front, drillViewports.Simulation);
    if (control2.Name == this.button_2.Name)
      clsInit.appDrill.cmdSetView(viewType.Left, drillViewports.Simulation);
    if (control2.Name == this.button_6.Name)
      clsInit.appDrill.cmdSetView(viewType.Right, drillViewports.Simulation);
    if (control2.Name == this.button_7.Name)
      clsInit.appDrill.cmdSetView(viewType.Top, drillViewports.Simulation);
    if (control2.Name == this.button_4.Name)
      clsInit.appDrill.cmdSetView(viewType.Bottom, drillViewports.Simulation);
    if (control2.Name == this.button_5.Name)
      clsInit.appDrill.cmdSetView(viewType.Isometric, drillViewports.Simulation);
    if (!(control2.Name == this.button_9.Name))
      return;
    clsInit.appDrill.cmdZoomFit(drillViewports.Simulation);
  }

  internal void method_2(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    clsDrill.varDrillRunSettings.CollisionCheck = this.checkBox_1.Checked;
    clsDrill.varDrillRunSettings.SimStopAtMatReady = this.checkBox_2.Checked;
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      this.splitContainer1.SplitterDistance = Convert.ToInt32((double) this.Width / 1.4);
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (clsDrill.varDrillRunSettings.StepRun)
      clsDrill.varTemps.simRelease = true;
    clsInit.appDrill.cmdGoLineSimulation(this.txt_gcode.Selection.Start.iLine);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
