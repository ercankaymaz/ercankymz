using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Diemaker;

public class F_CreasingCornerItems : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public CreasingCornerItem CreasingCorner = new CreasingCornerItem();

	public string strBridge = "Creasing Corner";

	public string strRemove = "Do You Want to Remove";

	public bool ShowAddRemove = true;

	[CompilerGenerated]
	private ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler_0;

	private IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	public event ApplyCommandWithBoolEventHandler ApplyPressed
	{
		[CompilerGenerated]
		add
		{
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler = applyCommandWithBoolEventHandler_0;
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler2;
			do
			{
				applyCommandWithBoolEventHandler2 = applyCommandWithBoolEventHandler;
				ApplyCommandWithBoolEventHandler value2 = (ApplyCommandWithBoolEventHandler)Delegate.Combine(applyCommandWithBoolEventHandler2, value);
				applyCommandWithBoolEventHandler = Interlocked.CompareExchange(ref applyCommandWithBoolEventHandler_0, value2, applyCommandWithBoolEventHandler2);
			}
			while ((object)applyCommandWithBoolEventHandler != applyCommandWithBoolEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler = applyCommandWithBoolEventHandler_0;
			ApplyCommandWithBoolEventHandler applyCommandWithBoolEventHandler2;
			do
			{
				applyCommandWithBoolEventHandler2 = applyCommandWithBoolEventHandler;
				ApplyCommandWithBoolEventHandler value2 = (ApplyCommandWithBoolEventHandler)Delegate.Remove(applyCommandWithBoolEventHandler2, value);
				applyCommandWithBoolEventHandler = Interlocked.CompareExchange(ref applyCommandWithBoolEventHandler_0, value2, applyCommandWithBoolEventHandler2);
			}
			while ((object)applyCommandWithBoolEventHandler != applyCommandWithBoolEventHandler2);
		}
	}

	public F_CreasingCornerItems()
	{
		Class76.smethod_138(this);
	}

	public void Init()
	{
		Result = DialogResult.Cancel;
		numericUpDown_1.Value = (decimal)CreasingCorner.LeftHeight;
		numericUpDown_0.Value = (decimal)CreasingCorner.LeftWidth;
		numericUpDown_2.Value = (decimal)CreasingCorner.RightHeight;
		numericUpDown_3.Value = (decimal)CreasingCorner.RightWidth;
		checkBox_0.Checked = CreasingCorner.LeftEnable;
		checkBox_1.Checked = CreasingCorner.RightEnable;
		Class76.smethod_481(this);
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

	internal void method_1(object sender, EventArgs e)
	{
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		CreasingCorner.LeftHeight = (double)numericUpDown_1.Value;
		CreasingCorner.LeftWidth = (double)numericUpDown_0.Value;
		CreasingCorner.RightHeight = (double)numericUpDown_2.Value;
		CreasingCorner.RightWidth = (double)numericUpDown_3.Value;
		CreasingCorner.LeftEnable = checkBox_0.Checked;
		CreasingCorner.RightEnable = checkBox_1.Checked;
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: false);
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

	internal void method_3(object sender, EventArgs e)
	{
		CreasingCorner.LeftHeight = (double)numericUpDown_1.Value;
		CreasingCorner.LeftWidth = (double)numericUpDown_0.Value;
		CreasingCorner.RightHeight = (double)numericUpDown_2.Value;
		CreasingCorner.RightWidth = (double)numericUpDown_3.Value;
		CreasingCorner.LeftEnable = checkBox_0.Checked;
		CreasingCorner.RightEnable = checkBox_1.Checked;
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: false);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		CreasingCorner.LeftHeight = (double)numericUpDown_1.Value;
		CreasingCorner.LeftWidth = (double)numericUpDown_0.Value;
		CreasingCorner.RightHeight = (double)numericUpDown_2.Value;
		CreasingCorner.RightWidth = (double)numericUpDown_3.Value;
		CreasingCorner.LeftEnable = checkBox_0.Checked;
		CreasingCorner.RightEnable = checkBox_1.Checked;
		if (applyCommandWithBoolEventHandler_0 != null)
		{
			applyCommandWithBoolEventHandler_0(Data: true);
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
