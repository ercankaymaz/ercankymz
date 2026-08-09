using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Events;

public class F_MoveRotateWith3Point : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MoveAndRotateWith3PointData Data = new MoveAndRotateWith3PointData();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	public Button btn_selectmovepos;

	public Button btn_selectrotApos;

	public Button btn_selectrotCpos;

	public NumericUpDown spn_newArotatez;

	public NumericUpDown spn_newArotatey;

	public NumericUpDown spn_newArotatex;

	public NumericUpDown spn_newCrotatez;

	public NumericUpDown spn_newCrotatey;

	public NumericUpDown spn_newCrotatex;

	public NumericUpDown spn_selectedmovex;

	public NumericUpDown spn_selectedmovey;

	public NumericUpDown spn_selectedmovez;

	public NumericUpDown spn_selectedArotatez;

	public NumericUpDown spn_selectedArotatey;

	public NumericUpDown spn_selectedArotatex;

	public NumericUpDown spn_selectedCrotatez;

	public NumericUpDown spn_selectedCrotatey;

	public NumericUpDown spn_selectedCrotatex;

	public NumericUpDown spn_newmovez;

	public NumericUpDown spn_newmovey;

	public NumericUpDown spn_newmovex;

	public CheckBox chk_rotA;

	public CheckBox chk_rotC;

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

	public F_MoveRotateWith3Point()
	{
		Class76.smethod_190(this);
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
		spn_selectedmovex.Value = (decimal)Data.PntMoveSelected.X;
		spn_selectedmovey.Value = (decimal)Data.PntMoveSelected.Y;
		spn_selectedmovez.Value = (decimal)Data.PntMoveSelected.Z;
		spn_newmovex.Value = (decimal)Data.PntMoveNew.X;
		spn_newmovey.Value = (decimal)Data.PntMoveNew.Y;
		spn_newmovez.Value = (decimal)Data.PntMoveNew.Z;
		spn_selectedArotatex.Value = (decimal)Data.PntRotateASelected.X;
		spn_selectedArotatey.Value = (decimal)Data.PntRotateASelected.Y;
		spn_selectedArotatez.Value = (decimal)Data.PntRotateASelected.Z;
		spn_newArotatex.Value = (decimal)Data.PntRotateANew.X;
		spn_newArotatey.Value = (decimal)Data.PntRotateANew.Y;
		spn_newArotatez.Value = (decimal)Data.PntRotateANew.Z;
		spn_selectedCrotatex.Value = (decimal)Data.PntRotateCSelected.X;
		spn_selectedCrotatey.Value = (decimal)Data.PntRotateCSelected.Y;
		spn_selectedCrotatez.Value = (decimal)Data.PntRotateCSelected.Z;
		spn_newCrotatex.Value = (decimal)Data.PntRotateCNew.X;
		spn_newCrotatey.Value = (decimal)Data.PntRotateCNew.Y;
		spn_newCrotatez.Value = (decimal)Data.PntRotateCNew.Z;
		if (!(Data.PntRotateCSelected.Option > 0.0))
		{
			chk_rotC.Checked = false;
		}
		else
		{
			chk_rotC.Checked = true;
		}
		if (!(Data.PntRotateASelected.Option > 0.0))
		{
			chk_rotA.Checked = false;
		}
		else
		{
			chk_rotA.Checked = true;
		}
		Properties.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		if (control.Name == btn_ok.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(null);
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
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
		if (!(control.Name == btn_selectmovepos.Name))
		{
		}
		if (!(control.Name == btn_selectrotApos.Name))
		{
		}
		if (control.Name == btn_selectrotCpos.Name)
		{
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
