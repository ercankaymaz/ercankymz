// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.RollerBend.F_RollerMachSim
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
namespace buCadCamResVer5.RollerBend;

public class F_RollerMachSim : Form
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

  public F_RollerMachSim() => Class5.smethod_86(this);

  public event ValueChangedWithDataEventHandler ValueChanged;

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    clsRollerBend.viewportAuto.WaitCursorMode = waitCursorType.Never;
    clsRollerBend.viewportAuto.SetView(viewType.vcFrontFaceTopLeft);
    this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    this.timer_0.Interval = 50;
    this.timer_0.Enabled = true;
    this.PropertiesForm.Inited = true;
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    clsRollerBend.viewportAuto.ZoomFit();
    clsRollerBend.viewportAuto.Invalidate();
    this.timer_0.Enabled = false;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.PropertiesForm.Inited)
      ;
  }

  internal void method_1(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.button_0.Name)
      clsInit.appRollerBend.cmdStartSimulation(false);
    if (control2.Name == this.button_1.Name)
    {
      clsInit.appRollerBend.cmdStopSimulation();
      if (!F_RollerMachSim.Connected)
        ;
    }
    if (control2.Name == this.button_10.Name)
    {
      clsInit.appRollerBend.cmdPreSimulation();
      if (!F_RollerMachSim.Connected)
        ;
    }
    if (control2.Name == this.button_11.Name)
    {
      clsInit.appRollerBend.cmdNextSimulation();
      if (!F_RollerMachSim.Connected)
        ;
    }
    if (control2.Name == this.button_3.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Rear);
    if (control2.Name == this.button_8.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Front);
    if (control2.Name == this.button_2.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Left);
    if (control2.Name == this.button_6.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Right);
    if (control2.Name == this.button_7.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Top);
    if (control2.Name == this.button_4.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Bottom);
    if (control2.Name == this.button_5.Name)
      clsInit.appRollerBend.cmdSetView(viewType.Isometric);
    if (!(control2.Name == this.button_9.Name))
      return;
    clsInit.appRollerBend.cmdZoomFit();
  }

  internal void method_2(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (this.PropertiesForm.Inited)
      ;
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
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
