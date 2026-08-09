using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Simulation;

public class F_SimulationPanel : Form
{
	public System.Windows.Forms.Timer timWarning = null;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_start;

	public buButton btn_close;

	public buSpin spn_step;

	public buButton btn_next;

	public buButton btn_pre;

	public buButton btn_pause;

	public buButton btn_stop;

	internal buLabel buLabel_0;

	public event OkCommandWithThreeDataEventHandler CommandExecute
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public F_SimulationPanel()
	{
		Class186.smethod_594(this);
		timWarning = new System.Windows.Forms.Timer();
		timWarning.Tick += timWarning_Tick;
		timWarning.Interval = 800;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.Simulation;
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	private void timWarning_Tick(object sender, EventArgs e)
	{
		buLabel_0.Visible = false;
		timWarning.Enabled = false;
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	public void Apply()
	{
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (okCommandWithThreeDataEventHandler_0 == null)
		{
			return;
		}
		if (control.Name == btn_start.Name)
		{
			if (spn_step.Value <= 0.0)
			{
				buLabel_0.Text = buLangTranslate.preSentences.SimuationStepisZero;
				buLabel_0.Visible = true;
				timWarning.Enabled = true;
			}
			okCommandWithThreeDataEventHandler_0(SimulationCommands.Start, spn_step.Value, null);
		}
		if (control.Name == btn_stop.Name)
		{
			okCommandWithThreeDataEventHandler_0(SimulationCommands.Stop, spn_step.Value, null);
		}
		if (control.Name == btn_pause.Name)
		{
			okCommandWithThreeDataEventHandler_0(SimulationCommands.Pause, spn_step.Value, null);
		}
		if (control.Name == btn_pre.Name)
		{
			if (spn_step.Value <= 0.0)
			{
				buLabel_0.Text = buLangTranslate.preSentences.SimuationStepisZero;
				buLabel_0.Visible = true;
				timWarning.Enabled = true;
			}
			okCommandWithThreeDataEventHandler_0(SimulationCommands.Previous, spn_step.Value, null);
		}
		if (control.Name == btn_next.Name)
		{
			if (spn_step.Value <= 0.0)
			{
				buLabel_0.Text = buLangTranslate.preSentences.SimuationStepisZero;
				buLabel_0.Visible = true;
				timWarning.Enabled = true;
			}
			okCommandWithThreeDataEventHandler_0(SimulationCommands.Next, spn_step.Value, null);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.Cancel;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_4(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (okCommandWithThreeDataEventHandler_0 != null && control.Name == spn_step.Name)
		{
			okCommandWithThreeDataEventHandler_0(SimulationCommands.StepChanged, spn_step.Value, null);
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
