using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Coordinate;

public class F_CoordinateXYZ : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler_0;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public Pnt3D RefPoint = new Pnt3D();

	public bool ShowZ = false;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Label label_0;

	internal Label label_1;

	public Button btn_cancel;

	public Button btn_ok;

	public NumericUpDown spn_y;

	public NumericUpDown spn_x;

	internal Label label_2;

	public NumericUpDown spn_z;

	public event Pnt3DValueChangedEventHandler PointValueChanged
	{
		[CompilerGenerated]
		add
		{
			Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler = pnt3DValueChangedEventHandler_0;
			Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler2;
			do
			{
				pnt3DValueChangedEventHandler2 = pnt3DValueChangedEventHandler;
				Pnt3DValueChangedEventHandler value2 = (Pnt3DValueChangedEventHandler)Delegate.Combine(pnt3DValueChangedEventHandler2, value);
				pnt3DValueChangedEventHandler = Interlocked.CompareExchange(ref pnt3DValueChangedEventHandler_0, value2, pnt3DValueChangedEventHandler2);
			}
			while ((object)pnt3DValueChangedEventHandler != pnt3DValueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler = pnt3DValueChangedEventHandler_0;
			Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler2;
			do
			{
				pnt3DValueChangedEventHandler2 = pnt3DValueChangedEventHandler;
				Pnt3DValueChangedEventHandler value2 = (Pnt3DValueChangedEventHandler)Delegate.Remove(pnt3DValueChangedEventHandler2, value);
				pnt3DValueChangedEventHandler = Interlocked.CompareExchange(ref pnt3DValueChangedEventHandler_0, value2, pnt3DValueChangedEventHandler2);
			}
			while ((object)pnt3DValueChangedEventHandler != pnt3DValueChangedEventHandler2);
		}
	}

	public event OkCommandEventHandler OkPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
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

	public F_CoordinateXYZ()
	{
		Class76.smethod_397(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		spn_x.Value = (decimal)RefPoint.X;
		spn_y.Value = (decimal)RefPoint.Y;
		spn_z.Value = (decimal)RefPoint.Z;
		spn_z.Visible = ShowZ;
		label_2.Visible = ShowZ;
		spn_x.Focus();
		spn_x.Select(0, 100);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "F_FreeLineerDraw LoadLanguage";
		try
		{
			if (Captions.Count >= 67)
			{
				Text = Captions[0];
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

	internal void method_1(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == spn_x.Name && e.KeyCode == Keys.Return)
		{
			spn_y.Focus();
			spn_y.Select(0, 100);
		}
		if (control.Name == spn_y.Name && pnt3DValueChangedEventHandler_0 != null && e.KeyCode == Keys.Return)
		{
			if (ShowZ)
			{
				spn_z.Focus();
				spn_z.Select(0, 100);
			}
			else
			{
				Pnt3DValueChangedEventArg pnt3DValueChangedEventArg = new Pnt3DValueChangedEventArg();
				pnt3DValueChangedEventArg.Point = new Pnt3D((double)spn_x.Value, (double)spn_y.Value, RefPoint.Z);
				pnt3DValueChangedEventHandler_0(pnt3DValueChangedEventArg);
				spn_x.Focus();
				spn_x.Select(0, 100);
			}
		}
		if (control.Name == spn_z.Name && pnt3DValueChangedEventHandler_0 != null && e.KeyCode == Keys.Return)
		{
			Pnt3DValueChangedEventArg pnt3DValueChangedEventArg2 = new Pnt3DValueChangedEventArg();
			pnt3DValueChangedEventArg2.Point = new Pnt3D((double)spn_x.Value, (double)spn_y.Value, (double)spn_z.Value);
			pnt3DValueChangedEventHandler_0(pnt3DValueChangedEventArg2);
			spn_x.Focus();
			spn_x.Select(0, 100);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.Cancel;
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.OK;
		if (okCommandEventHandler_0 != null)
		{
			okCommandEventHandler_0();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
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
