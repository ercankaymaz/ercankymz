using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_Move : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MoveEventFormVars Settings = new MoveEventFormVars();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ApplyCommandWithDataEventHandler applyCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Label label_3;

	public Button btn_rightbottom;

	public Button btn_bottom;

	public Button btn_leftbottom;

	public Button btn_right;

	public Button btn_center;

	public Button btn_left;

	public Button btn_righttop;

	public Button btn_top;

	public Button btn_lefttop;

	public Button btn_aligment;

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

	public F_Move()
	{
		Class186.smethod_731(this);
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
		Class186.smethod_120(this);
		numericUpDown_0.Value = (decimal)Settings.CatchPoint.X;
		numericUpDown_1.Value = (decimal)Settings.CatchPoint.Y;
		numericUpDown_2.Value = (decimal)Settings.CatchPoint.Z;
		checkBox_0.Checked = !Settings.isCoordinateMode;
		label_2.Visible = Settings.ShowZ;
		numericUpDown_2.Visible = Settings.ShowZ;
		btn_aligment.Visible = Settings.ShowAligment;
		Properties.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_lefttop.Name)
		{
			Settings.Alignment = ContentAlignment.TopLeft;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_left.Name)
		{
			Settings.Alignment = ContentAlignment.MiddleLeft;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_leftbottom.Name)
		{
			Settings.Alignment = ContentAlignment.BottomLeft;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_righttop.Name)
		{
			Settings.Alignment = ContentAlignment.TopRight;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_right.Name)
		{
			Settings.Alignment = ContentAlignment.MiddleRight;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_rightbottom.Name)
		{
			Settings.Alignment = ContentAlignment.BottomRight;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_center.Name)
		{
			Settings.Alignment = ContentAlignment.MiddleCenter;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_top.Name)
		{
			Settings.Alignment = ContentAlignment.TopCenter;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_bottom.Name)
		{
			Settings.Alignment = ContentAlignment.BottomCenter;
			Class186.smethod_120(this);
			panel_1.Visible = false;
		}
		if (control.Name == btn_ok.Name)
		{
			Properties.Result = DialogResult.OK;
			Class186.smethod_429(this);
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
				okCommandWithDataEventHandler_0(new Pnt3D((double)numericUpDown_0.Value, (double)numericUpDown_1.Value, (double)numericUpDown_2.Value));
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			Properties.Result = DialogResult.Cancel;
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
		if (control.Name == btn_aligment.Name)
		{
			panel_1.Visible = true;
		}
	}

	internal void method_1(object sender, KeyEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited && applyCommandWithDataEventHandler_0 != null)
		{
			Class186.smethod_429(this);
			applyCommandWithDataEventHandler_0(Settings);
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
