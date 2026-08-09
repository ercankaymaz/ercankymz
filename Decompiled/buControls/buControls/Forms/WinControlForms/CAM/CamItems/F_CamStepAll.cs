using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepAll : Form
{
	public static List<string> Captions = new List<string>();

	public int DecimalCount = 2;

	public bool ShowExplanation = false;

	public bool ShowImages = true;

	public bool ShowOkButton = true;

	public bool ShowCancelButton = true;

	public Size FormSize = default(Size);

	public camStep Data = new camStep();

	public camStepEnable DataEnable = new camStepEnable();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal Label label_3;

	internal CheckBox checkBox_0;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_1;

	internal Label label_5;

	internal CheckBox checkBox_1;

	internal Label label_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_2;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_3;

	internal Label label_10;

	internal Label label_11;

	internal Panel panel_2;

	internal Panel panel_3;

	internal Panel panel_4;

	internal Label label_12;

	internal Label label_13;

	internal NumericUpDown numericUpDown_4;

	internal Label label_14;

	internal Panel panel_5;

	internal Label label_15;

	internal Label label_16;

	internal NumericUpDown numericUpDown_5;

	internal Label label_17;

	internal Panel panel_6;

	internal RadioButton radioButton_0;

	internal Label label_18;

	internal RadioButton radioButton_1;

	internal Label label_19;

	internal Label label_20;

	internal Panel panel_7;

	internal RadioButton radioButton_2;

	internal Label label_21;

	internal RadioButton radioButton_3;

	internal Label label_22;

	internal Label label_23;

	internal ImageList imageList_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_8;

	public event OkCommandWithDataEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelPressed
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

	public F_CamStepAll()
	{
		Class76.smethod_763(this);
	}

	public F_CamStepAll(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_763(this);
		label_2.Visible = ShowExplanation;
		label_8.Visible = ShowExplanation;
		label_14.Visible = ShowExplanation;
		label_5.Visible = ShowExplanation;
		label_23.Visible = ShowExplanation;
		label_20.Visible = ShowExplanation;
		label_10.Visible = ShowExplanation;
		label_17.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_2.DecimalPlaces = DecimalCount;
			numericUpDown_4.DecimalPlaces = DecimalCount;
			numericUpDown_1.DecimalPlaces = DecimalCount;
			numericUpDown_3.DecimalPlaces = DecimalCount;
			numericUpDown_5.DecimalPlaces = DecimalCount;
		}
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
		int num = 0;
		numericUpDown_0.DecimalPlaces = 0;
		numericUpDown_2.DecimalPlaces = DecimalCount;
		numericUpDown_4.DecimalPlaces = DecimalCount;
		numericUpDown_1.DecimalPlaces = DecimalCount;
		numericUpDown_3.DecimalPlaces = DecimalCount;
		numericUpDown_5.DecimalPlaces = DecimalCount;
		panel_2.Visible = DataEnable.StartValue;
		if (DataEnable.StartValue)
		{
			panel_2.Top = 40 + num * 32;
			num++;
		}
		panel_4.Visible = DataEnable.EndValue;
		if (DataEnable.EndValue)
		{
			panel_4.Top = 40 + num * 32;
			num++;
		}
		panel_5.Visible = DataEnable.Step;
		if (DataEnable.Step)
		{
			panel_5.Top = 40 + num * 32;
			num++;
		}
		panel_0.Visible = DataEnable.Count;
		if (DataEnable.Count)
		{
			panel_0.Top = 40 + num * 32;
			num++;
		}
		panel_3.Visible = DataEnable.Distance;
		if (DataEnable.Distance)
		{
			panel_3.Top = 40 + num * 32;
			num++;
		}
		panel_1.Visible = DataEnable.MoveUp;
		if (DataEnable.MoveUp)
		{
			panel_1.Top = 40 + num * 32;
			num++;
		}
		panel_7.Visible = DataEnable.MoveUpType;
		if (DataEnable.MoveUpType)
		{
			panel_7.Top = 40 + num * 32;
			num++;
		}
		panel_6.Visible = DataEnable.Sequence;
		if (DataEnable.Sequence)
		{
			panel_6.Top = 40 + num * 32;
			num++;
		}
		if (num > 0)
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = 385;
			int num5 = 0;
			if (ShowCancelButton | ShowOkButton)
			{
				num5 = 50;
			}
			if (ShowExplanation)
			{
				num2 = label_2.Width;
			}
			if (ShowImages)
			{
				num3 = label_0.Width;
			}
			base.Height = num * 32 + 80 + num5;
			base.Width = num4 + num2 + num3;
		}
		label_2.Visible = ShowExplanation;
		label_8.Visible = ShowExplanation;
		label_14.Visible = ShowExplanation;
		label_5.Visible = ShowExplanation;
		label_23.Visible = ShowExplanation;
		label_20.Visible = ShowExplanation;
		label_10.Visible = ShowExplanation;
		label_17.Visible = ShowExplanation;
		label_0.Visible = ShowImages;
		label_6.Visible = ShowImages;
		label_12.Visible = ShowImages;
		label_3.Visible = ShowImages;
		label_21.Visible = ShowImages;
		label_11.Visible = ShowImages;
		label_15.Visible = ShowImages;
		btn_ok.Visible = ShowOkButton;
		btn_cancel.Visible = ShowCancelButton;
		checkBox_1.Checked = Data.Enable;
		numericUpDown_0.Value = Data.Count;
		numericUpDown_2.Value = (decimal)Data.Distance;
		numericUpDown_4.Value = (decimal)Data.EndValue;
		numericUpDown_3.Value = (decimal)Data.StartValue;
		numericUpDown_5.Value = (decimal)Data.Step;
		numericUpDown_1.Value = (decimal)Data.MoveUp;
		checkBox_0.Checked = Data.MoveUpEnable;
		radioButton_3.Checked = false;
		radioButton_2.Checked = false;
		if (Data.MoveUpType == CamMoveUpType.Absolute)
		{
			radioButton_3.Checked = true;
		}
		if (Data.MoveUpType == CamMoveUpType.Incremental)
		{
			radioButton_2.Checked = true;
		}
		radioButton_1.Checked = false;
		radioButton_0.Checked = false;
		if (Data.Sequence == CamMachiningSequenceType.Level)
		{
			radioButton_1.Checked = true;
		}
		if (Data.Sequence == CamMachiningSequenceType.Region)
		{
			radioButton_0.Checked = true;
		}
		if (FormSize.Width > 1)
		{
			base.Width = FormSize.Width;
		}
		if (FormSize.Height > 1)
		{
			base.Height = FormSize.Height;
		}
		Class76.smethod_312(this);
		Result = DialogResult.None;
	}

	public void Apply()
	{
		Data.Enable = checkBox_1.Checked;
		Data.Count = (int)numericUpDown_0.Value;
		Data.Distance = (double)numericUpDown_2.Value;
		Data.EndValue = (double)numericUpDown_4.Value;
		Data.StartValue = (double)numericUpDown_3.Value;
		Data.Step = (double)numericUpDown_5.Value;
		Data.MoveUp = (double)numericUpDown_1.Value;
		Data.MoveUpEnable = checkBox_0.Checked;
		if (radioButton_3.Checked)
		{
			Data.MoveUpType = CamMoveUpType.Absolute;
		}
		if (radioButton_2.Checked)
		{
			Data.MoveUpType = CamMoveUpType.Incremental;
		}
		if (radioButton_1.Checked)
		{
			Data.Sequence = CamMachiningSequenceType.Level;
		}
		if (radioButton_0.Checked)
		{
			Data.Sequence = CamMachiningSequenceType.Region;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Apply();
		Result = DialogResult.OK;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(Data);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
	}

	internal void method_3(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(base.Controls, result, e.Shift);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
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
