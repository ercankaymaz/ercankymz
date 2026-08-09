using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Events;

public class F_PolarArray : Form
{
	public FormProperties Properties = new FormProperties();

	public PolarArrayEventVar Data = new PolarArrayEventVar();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal CheckBox checkBox_0;

	public event OkCommandWithDataEventHandler CommandOk
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

	public event CancelCommandEventHandler CommandCancel
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

	public event ApplyCommandWithDataEventHandler CommandApply
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

	public F_PolarArray()
	{
		Class76.smethod_160(this);
	}

	public void Init(PolarArrayEventVar data)
	{
		Data = new PolarArrayEventVar(data);
		Init();
	}

	public void Init()
	{
		Properties.Inited = false;
		Properties.Result = DialogResult.None;
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		numericUpDown_0.Value = (decimal)Data.ItemAngle;
		numericUpDown_1.Value = Data.ItemCount;
		if (Data.Direction == ClockDirectionType.CW)
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		if (Data.Direction == ClockDirectionType.CCW)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		Properties.Inited = true;
		applyCommandWithDataEventHandler_0(Data);
		Class76.smethod_693(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Apply();
		Properties.Result = DialogResult.OK;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
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
		Properties.Result = DialogResult.Cancel;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
	}

	public void Apply()
	{
		if (Properties.Inited)
		{
			Data.ItemAngle = (double)numericUpDown_0.Value;
			Data.ItemCount = (int)numericUpDown_1.Value;
			if (!radioButton_0.Checked)
			{
				Data.Direction = ClockDirectionType.CW;
			}
			else
			{
				Data.Direction = ClockDirectionType.CCW;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited && applyCommandWithDataEventHandler_0 != null)
		{
			Apply();
			applyCommandWithDataEventHandler_0(Data);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (Properties.Inited && applyCommandWithDataEventHandler_0 != null)
		{
			Apply();
			applyCommandWithDataEventHandler_0(Data);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (Properties.Inited && applyCommandWithDataEventHandler_0 != null)
		{
			Apply();
			applyCommandWithDataEventHandler_0(Data);
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
