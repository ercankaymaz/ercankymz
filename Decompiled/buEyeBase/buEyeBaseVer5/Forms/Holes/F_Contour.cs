using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_Contour : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public DrillRuntimeSettings settingRuntime = new DrillRuntimeSettings();

	public DrillJob Job = new DrillJob();

	public DrillCNCSettings settingCNC = new DrillCNCSettings();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	internal OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_1;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_1;

	internal Label label_0;

	internal Label label_1;

	internal Panel panel_0;

	public Button btn_top;

	public Button btn_bottom;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_1;

	public event OkCommandWithTwoDataEventHandler DataChanged
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event OkCommandWithTwoDataEventHandler DataOk
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler DataCancel
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_Contour()
	{
		Class186.smethod_100(this);
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
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void ControlUpdate()
	{
		numericUpDown_0.Value = (decimal)settingRuntime.ContourOffset;
		numericUpDown_1.Value = (decimal)settingRuntime.ContourDepth;
		btn_top.BackColor = Color.Gainsboro;
		btn_bottom.BackColor = Color.Gainsboro;
		if (settingRuntime.lastContourPlaneNames == planeBoxNames.Top)
		{
			btn_top.BackColor = Color.PaleGreen;
		}
		if (settingRuntime.lastContourPlaneNames == planeBoxNames.Bottom)
		{
			btn_bottom.BackColor = Color.PaleGreen;
		}
	}

	public void Apply()
	{
		settingRuntime.ContourOffset = (double)numericUpDown_0.Value;
		settingRuntime.ContourDepth = (double)numericUpDown_1.Value;
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
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!(control.Name == btn_ok.Name))
		{
			if (!(control.Name == btn_cancel.Name))
			{
				if (control.Name == btn_top.Name)
				{
					settingRuntime.lastContourPlaneNames = planeBoxNames.Top;
					btn_bottom.BackColor = Color.Gainsboro;
					btn_top.BackColor = Color.PaleGreen;
				}
				if (control.Name == btn_bottom.Name)
				{
					settingRuntime.lastContourPlaneNames = planeBoxNames.Bottom;
					btn_top.BackColor = Color.Gainsboro;
					btn_bottom.BackColor = Color.PaleGreen;
				}
			}
			else
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
				if (cancelCommandEventHandler_0 != null)
				{
					cancelCommandEventHandler_0();
				}
			}
			return;
		}
		if (settingRuntime.DrillCommand == drillCommands.CutHorizontal && settingRuntime.slotPoint.Y < settingCNC.ClamperCatchWidth)
		{
			if (settingRuntime.lastDrillPlaneNames == planeBoxNames.Top && Job.Material.Size.Width < settingCNC.ContourMinLengthForTopSpindleAtClamperArea)
			{
				buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[29] + " : " + settingCNC.ContourMinLengthForTopSpindleAtClamperArea.ToString("f1"));
				return;
			}
			if (settingRuntime.lastDrillPlaneNames == planeBoxNames.Bottom && Job.Material.Size.Width < settingCNC.ContourMinLengthForBottomSpindleAtClamperArea)
			{
				buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[30] + " : " + settingCNC.ContourMinLengthForBottomSpindleAtClamperArea.ToString("f1"));
				return;
			}
		}
		Apply();
		Class186.smethod_188(this, true);
		PropertiesForm.Result = DialogResult.OK;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
