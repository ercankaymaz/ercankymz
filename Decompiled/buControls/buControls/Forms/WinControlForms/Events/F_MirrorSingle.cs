using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Events;

public class F_MirrorSingle : Form
{
	public FormProperties Properties = new FormProperties();

	public MirrorSingleEventVar Data = new MirrorSingleEventVar();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal ImageList imageList_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal RadioButton radioButton_2;

	internal CheckBox checkBox_0;

	internal Panel panel_0;

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

	public F_MirrorSingle()
	{
		Class76.smethod_37(this);
	}

	public void Init(MirrorSingleEventVar data)
	{
		Data = new MirrorSingleEventVar(data);
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
		checkBox_0.Checked = Data.MaterialCenter;
		numericUpDown_0.Value = (decimal)Data.Offset;
		if (Data.Catch != MinCenterMaxType.Min)
		{
			if (Data.Catch != MinCenterMaxType.Center)
			{
				if (Data.Catch == MinCenterMaxType.Max)
				{
					radioButton_1.Checked = false;
					radioButton_0.Checked = false;
					radioButton_2.Checked = true;
				}
			}
			else
			{
				radioButton_1.Checked = false;
				radioButton_0.Checked = true;
				radioButton_2.Checked = false;
			}
		}
		else
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
			radioButton_2.Checked = false;
		}
		if (!checkBox_0.Checked)
		{
			panel_0.Enabled = true;
		}
		else
		{
			panel_0.Enabled = false;
		}
		Properties.Inited = true;
		applyCommandWithDataEventHandler_0(Data);
		Class76.smethod_108(this);
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
		if (!Properties.Inited)
		{
			return;
		}
		Data.Offset = (double)numericUpDown_0.Value;
		if (!radioButton_1.Checked)
		{
			if (!radioButton_0.Checked)
			{
				Data.Catch = MinCenterMaxType.Max;
			}
			else
			{
				Data.Catch = MinCenterMaxType.Center;
			}
		}
		else
		{
			Data.Catch = MinCenterMaxType.Min;
		}
		Data.MaterialCenter = checkBox_0.Checked;
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (!checkBox_0.Checked)
		{
			panel_0.Enabled = true;
		}
		else
		{
			panel_0.Enabled = false;
		}
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
