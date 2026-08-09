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

namespace buCadCamResVer5.RollerBend;

public class F_RollerMachSim : Form
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

	public F_RollerMachSim()
	{
		Class5.smethod_86(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		clsRollerBend.viewportAuto.WaitCursorMode = waitCursorType.Never;
		clsRollerBend.viewportAuto.SetView(viewType.vcFrontFaceTopLeft);
		timer_0.Tick += timer_0_Tick;
		timer_0.Interval = 50;
		timer_0.Enabled = true;
		PropertiesForm.Inited = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		clsRollerBend.viewportAuto.ZoomFit();
		clsRollerBend.viewportAuto.Invalidate();
		timer_0.Enabled = false;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			clsInit.appRollerBend.cmdStartSimulation(Step: false);
		}
		if (control.Name == button_1.Name)
		{
			clsInit.appRollerBend.cmdStopSimulation();
			if (Connected)
			{
			}
		}
		if (control.Name == button_10.Name)
		{
			clsInit.appRollerBend.cmdPreSimulation();
			if (Connected)
			{
			}
		}
		if (control.Name == button_11.Name)
		{
			clsInit.appRollerBend.cmdNextSimulation();
			if (Connected)
			{
			}
		}
		if (control.Name == button_3.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Rear);
		}
		if (control.Name == button_8.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Front);
		}
		if (control.Name == button_2.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Left);
		}
		if (control.Name == button_6.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Right);
		}
		if (control.Name == button_7.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Top);
		}
		if (control.Name == button_4.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Bottom);
		}
		if (control.Name == button_5.Name)
		{
			clsInit.appRollerBend.cmdSetView(viewType.Isometric);
		}
		if (control.Name == button_9.Name)
		{
			clsInit.appRollerBend.cmdZoomFit();
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
