using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_Offsets : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public double LeftOffsetValue = 0.0;

	public double RightOffsetValue = 0.0;

	public double LeftSpecialValue1 = 2.0;

	public double LeftSpecialValue2 = 3.0;

	public double LeftSpecialValue3 = 4.0;

	public double RightSpecialValue1 = 2.0;

	public double RightSpecialValue2 = 3.0;

	public double RightSpecialValue3 = 4.0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal Button button_15;

	internal Button button_16;

	internal Button button_17;

	internal Button button_18;

	internal Button button_19;

	internal Button button_20;

	internal Button button_21;

	internal Button button_22;

	internal Button button_23;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal Button button_24;

	internal Button button_25;

	internal Button button_26;

	internal Button button_27;

	internal Button button_28;

	internal Button button_29;

	internal Button button_30;

	internal Button button_31;

	internal Button button_32;

	internal Button button_33;

	internal Button button_34;

	internal Button button_35;

	internal Button button_36;

	internal Button button_37;

	internal Button button_38;

	internal Button button_39;

	internal Button button_40;

	internal Button button_41;

	internal Button button_42;

	internal Button button_43;

	internal Button button_44;

	internal Button button_45;

	internal Button button_46;

	internal Button button_47;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal Button button_48;

	internal Button button_49;

	public event ApplyCommandWithDataEventHandler ApplyPressed
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

	public F_Offsets()
	{
		Class76.smethod_33(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Init()
	{
		numericUpDown_0.Value = (decimal)LeftOffsetValue;
		numericUpDown_1.Value = (decimal)RightOffsetValue;
		button_23.Text = LeftSpecialValue1.ToString();
		button_22.Text = LeftSpecialValue2.ToString();
		button_21.Text = LeftSpecialValue3.ToString();
		button_26.Text = RightSpecialValue1.ToString();
		button_25.Text = RightSpecialValue2.ToString();
		button_24.Text = RightSpecialValue3.ToString();
		Class76.smethod_848(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Text.Length > 0 && buNumeric.IsNumeric(control.Text))
		{
			numericUpDown_0.Value = Convert.ToDecimal(control.Text);
			if (applyCommandWithDataEventHandler_0 != null)
			{
				DiemakerOffsetValues diemakerOffsetValues = new DiemakerOffsetValues();
				diemakerOffsetValues.LeftOffset = Convert.ToDouble(numericUpDown_0.Value);
				diemakerOffsetValues.RightOffset = Convert.ToDouble(numericUpDown_1.Value);
				diemakerOffsetValues.ApplyType = DiemakerOffsetApplyType.Left;
				applyCommandWithDataEventHandler_0(diemakerOffsetValues);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Text.Length > 0 && buNumeric.IsNumeric(control.Text))
		{
			numericUpDown_1.Value = Convert.ToDecimal(control.Text);
			if (applyCommandWithDataEventHandler_0 != null)
			{
				DiemakerOffsetValues diemakerOffsetValues = new DiemakerOffsetValues();
				diemakerOffsetValues.LeftOffset = Convert.ToDouble(numericUpDown_0.Value);
				diemakerOffsetValues.RightOffset = Convert.ToDouble(numericUpDown_1.Value);
				diemakerOffsetValues.ApplyType = DiemakerOffsetApplyType.Right;
				applyCommandWithDataEventHandler_0(diemakerOffsetValues);
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (applyCommandWithDataEventHandler_0 != null)
		{
			DiemakerOffsetValues diemakerOffsetValues = new DiemakerOffsetValues();
			diemakerOffsetValues.LeftOffset = Convert.ToDouble(numericUpDown_0.Value);
			diemakerOffsetValues.RightOffset = Convert.ToDouble(numericUpDown_1.Value);
			diemakerOffsetValues.ApplyType = DiemakerOffsetApplyType.Left;
			applyCommandWithDataEventHandler_0(diemakerOffsetValues);
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (applyCommandWithDataEventHandler_0 != null)
		{
			DiemakerOffsetValues diemakerOffsetValues = new DiemakerOffsetValues();
			diemakerOffsetValues.LeftOffset = Convert.ToDouble(numericUpDown_0.Value);
			diemakerOffsetValues.RightOffset = Convert.ToDouble(numericUpDown_1.Value);
			diemakerOffsetValues.ApplyType = DiemakerOffsetApplyType.Right;
			applyCommandWithDataEventHandler_0(diemakerOffsetValues);
		}
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
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
