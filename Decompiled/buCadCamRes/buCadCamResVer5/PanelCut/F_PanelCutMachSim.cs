using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using ns8;

namespace buCadCamResVer5.PanelCut;

public class F_PanelCutMachSim : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ValueChangedWithDataEventHandler valueChangedWithDataEventHandler_0;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	public static bool OnlySimilator = false;

	public static bool Connected = false;

	internal IContainer icontainer_0 = null;

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

	public F_PanelCutMachSim()
	{
		Class5.smethod_203(this);
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		trackBar_0.Value = clsPanelCut.varPanelCutRunSettings.SimStep;
		checkBox_0.Checked = clsPanelCut.varPanelCutRunSettings.StepRun;
		clsPanelCut.viewportAuto.WaitCursorMode = waitCursorType.Never;
		timer_0.Interval = 100;
		timer_0.Enabled = true;
		PropertiesForm.Inited = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		clsInit.appPanelCut.DrawEntities(ZoomFit: true);
		clsPanelCut.viewportAuto.SetView(viewType.vcTopFaceLeft);
		clsPanelCut.viewportAuto.ZoomFit();
		clsPanelCut.viewportAuto.Invalidate();
		clsPanelCut.viewportAutoPanel.SetView(viewType.Top);
		clsPanelCut.viewportAutoPanel.ZoomFit();
		clsPanelCut.viewportAutoPanel.Invalidate();
		timer_0.Enabled = false;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			clsPanelCut.varPanelCutRunSettings.SimStep = trackBar_0.Value;
			if (valueChangedWithDataEventHandler_0 != null)
			{
				valueChangedWithDataEventHandler_0(clsPanelCut.varPanelCutRunSettings.SimStep, "Track");
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			clsPanelCut.varPanelCutRunSettings.StepRun = checkBox_0.Checked;
			if (!Connected)
			{
				clsInit.appPanelCut.cmdStartSimulation(checkBox_0.Checked);
			}
		}
		if (control.Name == button_1.Name && !Connected)
		{
			clsInit.appPanelCut.cmdStopSimulation();
		}
		if (control.Name == button_3.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Rear);
		}
		if (control.Name == button_8.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Front);
		}
		if (control.Name == button_2.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Left);
		}
		if (control.Name == button_6.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Right);
		}
		if (control.Name == button_7.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Top);
		}
		if (control.Name == button_4.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Bottom);
		}
		if (control.Name == button_5.Name)
		{
			clsInit.appPanelCut.cmdSetView(viewType.Isometric);
		}
		if (control.Name == button_9.Name)
		{
			clsInit.appPanelCut.cmdZoomFit();
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		base.Visible = false;
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			splitContainer1.SplitterDistance = Convert.ToInt32((double)base.Width / 1.4);
		}
		catch (Exception)
		{
		}
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
