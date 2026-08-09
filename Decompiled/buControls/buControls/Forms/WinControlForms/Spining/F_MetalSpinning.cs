using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Spining;

public class F_MetalSpinning : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public SpinPattern varSpinPattern = new SpinPattern();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ClickSenderDataEventHandler clickSenderDataEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal CheckBox checkBox_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Button button_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal Button button_2;

	internal Button button_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal Label label_6;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_6;

	internal Label label_7;

	internal CheckBox checkBox_2;

	internal Button button_4;

	internal NumericUpDown numericUpDown_7;

	internal Panel panel_1;

	internal Label label_8;

	internal Panel panel_2;

	internal Label label_9;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal Label label_11;

	internal NumericUpDown numericUpDown_9;

	internal CheckBox checkBox_3;

	internal Button button_5;

	internal CheckBox checkBox_4;

	internal Label label_12;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	public event ClickSenderDataEventHandler ShowPath
	{
		[CompilerGenerated]
		add
		{
			ClickSenderDataEventHandler clickSenderDataEventHandler = clickSenderDataEventHandler_0;
			ClickSenderDataEventHandler clickSenderDataEventHandler2;
			do
			{
				clickSenderDataEventHandler2 = clickSenderDataEventHandler;
				ClickSenderDataEventHandler value2 = (ClickSenderDataEventHandler)Delegate.Combine(clickSenderDataEventHandler2, value);
				clickSenderDataEventHandler = Interlocked.CompareExchange(ref clickSenderDataEventHandler_0, value2, clickSenderDataEventHandler2);
			}
			while ((object)clickSenderDataEventHandler != clickSenderDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickSenderDataEventHandler clickSenderDataEventHandler = clickSenderDataEventHandler_0;
			ClickSenderDataEventHandler clickSenderDataEventHandler2;
			do
			{
				clickSenderDataEventHandler2 = clickSenderDataEventHandler;
				ClickSenderDataEventHandler value2 = (ClickSenderDataEventHandler)Delegate.Remove(clickSenderDataEventHandler2, value);
				clickSenderDataEventHandler = Interlocked.CompareExchange(ref clickSenderDataEventHandler_0, value2, clickSenderDataEventHandler2);
			}
			while ((object)clickSenderDataEventHandler != clickSenderDataEventHandler2);
		}
	}

	public event ApplyCommandWithDataEventHandler SpinValueChanged
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Combine(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler = applyCommandWithDataEventHandler_0;
			ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler2;
			do
			{
				applyCommandWithDataEventHandler2 = applyCommandWithDataEventHandler;
				ApplyCommandWithDataEventHandler value2 = (ApplyCommandWithDataEventHandler)Delegate.Remove(applyCommandWithDataEventHandler2, value);
				applyCommandWithDataEventHandler = Interlocked.CompareExchange(ref applyCommandWithDataEventHandler_0, value2, applyCommandWithDataEventHandler2);
			}
			while ((object)applyCommandWithDataEventHandler != applyCommandWithDataEventHandler2);
		}
	}

	public F_MetalSpinning()
	{
		Class76.smethod_470(this);
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
		numericUpDown_0.Value = (decimal)varSpinPattern.StepCatchLength;
		numericUpDown_3.Value = (decimal)varSpinPattern.StepReturnLength;
		numericUpDown_6.Value = varSpinPattern.RepeatCount;
		numericUpDown_2.Value = (decimal)varSpinPattern.LeaveOffsetX;
		numericUpDown_1.Value = (decimal)varSpinPattern.LeaveHeight;
		numericUpDown_5.Value = (decimal)varSpinPattern.LeaveOffsetAngle;
		numericUpDown_4.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight;
		numericUpDown_7.Value = (decimal)varSpinPattern.LeaveArcCornerRadius;
		checkBox_1.Checked = varSpinPattern.isLeaveArc;
		checkBox_2.Checked = varSpinPattern.isArcCorner;
		checkBox_3.Checked = varSpinPattern.HidePrevious;
		numericUpDown_8.Value = (decimal)varSpinPattern.CamFeed;
		numericUpDown_10.Value = (decimal)varSpinPattern.SafeDistance;
		numericUpDown_9.Value = (decimal)varSpinPattern.CamLeaveFeed;
		checkBox_4.Checked = varSpinPattern.ReturnSameWay;
		numericUpDown_11.Value = (decimal)varSpinPattern.ReturnSameWayOffset;
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (clickSenderDataEventHandler_0 != null)
			{
				Apply();
				SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
				spinPatternCommand.OK = true;
				clickSenderDataEventHandler_0(null, spinPatternCommand);
			}
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
		if (control.Name == btn_cancel.Name)
		{
			if (clickSenderDataEventHandler_0 != null)
			{
				SpinPatternCommand spinPatternCommand2 = new SpinPatternCommand();
				spinPatternCommand2.Cancel = true;
				clickSenderDataEventHandler_0(null, spinPatternCommand2);
			}
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
		if (control.Name == button_0.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand3 = new SpinPatternCommand();
			spinPatternCommand3.ShowPattern = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand3);
		}
		if (control.Name == button_5.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand4 = new SpinPatternCommand();
			spinPatternCommand4.Finish = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand4);
		}
		if (control.Name == button_4.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand5 = new SpinPatternCommand();
			spinPatternCommand5.Undo = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand5);
		}
		if (control.Name == button_1.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand6 = new SpinPatternCommand();
			spinPatternCommand6.NextPattern = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand6);
		}
		if (control.Name == button_3.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand7 = new SpinPatternCommand();
			spinPatternCommand7.SimStart = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand7);
		}
		if (control.Name == button_2.Name && clickSenderDataEventHandler_0 != null)
		{
			Apply();
			SpinPatternCommand spinPatternCommand8 = new SpinPatternCommand();
			spinPatternCommand8.SimStop = true;
			clickSenderDataEventHandler_0(null, spinPatternCommand8);
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		varSpinPattern.RepeatCount = (int)numericUpDown_6.Value;
		varSpinPattern.StepCatchLength = (double)numericUpDown_0.Value;
		varSpinPattern.StepReturnLength = (double)numericUpDown_3.Value;
		varSpinPattern.LeaveOffsetX = (double)numericUpDown_2.Value;
		varSpinPattern.LeaveHeight = (double)numericUpDown_1.Value;
		varSpinPattern.LeaveOffsetAngle = (double)numericUpDown_5.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight = (double)numericUpDown_4.Value;
		varSpinPattern.LeaveArcCornerRadius = (double)numericUpDown_7.Value;
		varSpinPattern.isLeaveArc = checkBox_1.Checked;
		varSpinPattern.isArcCorner = checkBox_2.Checked;
		varSpinPattern.HidePrevious = checkBox_3.Checked;
		varSpinPattern.CamFeed = (double)numericUpDown_8.Value;
		varSpinPattern.CamLeaveFeed = (double)numericUpDown_9.Value;
		varSpinPattern.SafeDistance = (double)numericUpDown_10.Value;
		varSpinPattern.ReturnSameWay = checkBox_4.Checked;
		varSpinPattern.ReturnSameWayOffset = (double)numericUpDown_11.Value;
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			Apply();
			if (applyCommandWithDataEventHandler_0 != null)
			{
				applyCommandWithDataEventHandler_0(varSpinPattern);
			}
			PropertiesForm.Inited = true;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
	}

	internal void method_4(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			PropertiesForm.Inited = false;
			Apply();
			if (applyCommandWithDataEventHandler_0 != null)
			{
				applyCommandWithDataEventHandler_0(varSpinPattern);
			}
			ControlUpdate();
			PropertiesForm.Inited = true;
			method_5(sender, null);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		new Control();
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
