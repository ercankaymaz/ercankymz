using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using ns8;

namespace buCadCamResVer5.Drill;

public class F_DrillMachSim : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public DrillMachineType MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;

	[CompilerGenerated]
	private ValueChangedWithDataEventHandler valueChangedWithDataEventHandler_0;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	public static bool OnlySimilator = false;

	public static bool Connected = false;

	private IContainer icontainer_0 = null;

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

	public event ValueChangedWithDataEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Combine(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Remove(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
	}

	public F_DrillMachSim()
	{
		Class5.smethod_7(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		trackBar_0.Value = clsDrill.varDrillRunSettings.SimStep;
		checkBox_0.Checked = clsDrill.varDrillRunSettings.StepRun;
		checkBox_1.Checked = clsDrill.varDrillRunSettings.CollisionCheck;
		checkBox_2.Checked = clsDrill.varDrillRunSettings.SimStopAtMatReady;
		clsDrill.viewportAuto.WaitCursorMode = waitCursorType.Never;
		if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
		{
			clsInit.appDrill.cGoUltra2Up1Down.DrawEntities(ZoomFit: true);
		}
		if (MachType == DrillMachineType.GoWithAtc)
		{
			clsInit.appDrill.cGoAtc.DrawEntities(ZoomFit: true);
		}
		if (MachType == DrillMachineType.Sirius)
		{
			clsInit.appDrill.cGoSirius.DrawEntities(ZoomFit: true);
		}
		clsDrill.viewportAuto.SetView(viewType.vcFrontFaceTopLeft);
		if (clsDrill.activeJob != null)
		{
			txt_gcode.Text = buString5.StringListToString(clsDrill.activeJob.Codes, NewLineEnable: true);
		}
		timer_0.Tick += timer_0_Tick;
		timer_0.Interval = 50;
		timer_0.Enabled = true;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		Text = buLangTranslate.preDef.Machine + " " + buLangTranslate.preDef.Simulation;
		checkBox_1.Text = buLangTranslate.preDef.Collision;
		checkBox_0.Text = buLangTranslate.preDef.Step;
		checkBox_2.Text = buLangTranslate.preSentences.StopAtWaitCommand;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		clsDrill.viewportAuto.ZoomFit();
		clsDrill.viewportAuto.Invalidate();
		timer_0.Enabled = false;
		PropertiesForm.Inited = true;
		if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
		{
			clsInit.appDrill.cGoUltra2Up1Down.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
		}
		if (MachType == DrillMachineType.GoWithAtc)
		{
			clsInit.appDrill.cGoAtc.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
		}
		if (MachType == DrillMachineType.Sirius)
		{
			clsInit.appDrill.cGoSirius.MoveSimPart(clsDrill.activeJob.SimulationMoves[0]);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			clsDrill.varDrillRunSettings.SimStep = trackBar_0.Value;
			if (valueChangedWithDataEventHandler_0 != null)
			{
				valueChangedWithDataEventHandler_0(clsDrill.varDrillRunSettings.SimStep, "Track");
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			clsDrill.varDrillRunSettings.StepRun = checkBox_0.Checked;
			if (!Connected)
			{
				clsDrill.varDrillRunSettings.SimStopAtMatReady = checkBox_2.Checked;
				clsInit.appDrill.cmdStartSimulation(checkBox_0.Checked);
			}
		}
		if (control.Name == button_1.Name && !Connected)
		{
			clsInit.appDrill.cmdStopSimulation();
		}
		if (control.Name == button_10.Name && !Connected)
		{
			clsInit.appDrill.cmdPreSimulation();
		}
		if (control.Name == button_11.Name && !Connected)
		{
			clsInit.appDrill.cmdNextSimulation();
		}
		if (control.Name == button_3.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Rear, drillViewports.Simulation);
		}
		if (control.Name == button_8.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Front, drillViewports.Simulation);
		}
		if (control.Name == button_2.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Left, drillViewports.Simulation);
		}
		if (control.Name == button_6.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Right, drillViewports.Simulation);
		}
		if (control.Name == button_7.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Top, drillViewports.Simulation);
		}
		if (control.Name == button_4.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Bottom, drillViewports.Simulation);
		}
		if (control.Name == button_5.Name)
		{
			clsInit.appDrill.cmdSetView(viewType.Isometric, drillViewports.Simulation);
		}
		if (control.Name == button_9.Name)
		{
			clsInit.appDrill.cmdZoomFit(drillViewports.Simulation);
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			clsDrill.varDrillRunSettings.CollisionCheck = checkBox_1.Checked;
			clsDrill.varDrillRunSettings.SimStopAtMatReady = checkBox_2.Checked;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			splitContainer1.SplitterDistance = Convert.ToInt32((double)base.Width / 1.4);
		}
		catch (Exception)
		{
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (clsDrill.varDrillRunSettings.StepRun)
		{
			clsDrill.varTemps.simRelease = true;
		}
		clsInit.appDrill.cmdGoLineSimulation(txt_gcode.Selection.Start.iLine);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
