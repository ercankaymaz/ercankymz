using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Spining;

public class F_MetalSpinningSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public SpinPattern varSpinPattern = new SpinPattern();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Panel panel_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	public Button btn_ok;

	internal ImageList imageList_0;

	public Button btn_cancel;

	internal NumericUpDown numericUpDown_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal NumericUpDown numericUpDown_9;

	internal Label label_11;

	internal Label label_12;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal Label label_13;

	internal NumericUpDown numericUpDown_12;

	internal Label label_14;

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

	public F_MetalSpinningSettings()
	{
		Class76.smethod_744(this);
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
		numericUpDown_1.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight90To100;
		numericUpDown_2.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight100To110;
		numericUpDown_0.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight110To120;
		numericUpDown_4.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight120To130;
		numericUpDown_3.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight130To150;
		numericUpDown_5.Value = (decimal)varSpinPattern.LeaveArcRadiusRatioFromHeight150To180;
		numericUpDown_8.Value = (decimal)varSpinPattern.LeaveDeltaAngleRatio;
		numericUpDown_6.Value = (decimal)varSpinPattern.CurveEndExtend;
		numericUpDown_9.Value = (decimal)varSpinPattern.LeaveMaxAngle;
		numericUpDown_10.Value = (decimal)varSpinPattern.LeaveMinAngle;
		numericUpDown_7.Value = (decimal)varSpinPattern.CurveStartExtend;
		numericUpDown_11.Value = (decimal)varSpinPattern.CurveOffset;
		numericUpDown_12.Value = (decimal)varSpinPattern.CurveFinishOffset;
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
			Apply();
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

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		varSpinPattern.LeaveArcRadiusRatioFromHeight90To100 = (double)numericUpDown_1.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight100To110 = (double)numericUpDown_2.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight110To120 = (double)numericUpDown_0.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight120To130 = (double)numericUpDown_4.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight130To150 = (double)numericUpDown_3.Value;
		varSpinPattern.LeaveArcRadiusRatioFromHeight150To180 = (double)numericUpDown_5.Value;
		varSpinPattern.LeaveDeltaAngleRatio = (double)numericUpDown_8.Value;
		varSpinPattern.CurveEndExtend = (double)numericUpDown_6.Value;
		varSpinPattern.LeaveMaxAngle = (double)numericUpDown_9.Value;
		varSpinPattern.LeaveMinAngle = (double)numericUpDown_10.Value;
		varSpinPattern.CurveStartExtend = (double)numericUpDown_7.Value;
		varSpinPattern.CurveOffset = (double)numericUpDown_11.Value;
		varSpinPattern.CurveFinishOffset = (double)numericUpDown_12.Value;
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
