using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Coordinate;

public class F_CoordsSingleAxis : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	public DialogResult Result = DialogResult.None;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	[CompilerGenerated]
	private ValueChangedWithDataEventHandler valueChangedWithDataEventHandler_0;

	public double Value = 1.0;

	public bool Inited = false;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	public NumericUpDown spn_z;

	internal Button button_1;

	internal Button button_2;

	public event OkCommandEventHandler OkExecuted
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

	public event CancelCommandEventHandler CancelExecuted
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

	public event ValueChangedWithDataEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Combine(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Remove(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
	}

	public F_CoordsSingleAxis()
	{
		Class76.smethod_48(this);
	}

	public void Init()
	{
		Inited = false;
		spn_z.Value = (decimal)Value;
		Inited = true;
		Class76.smethod_181(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (!Inited)
		{
			return;
		}
		if (cancelCommandEventHandler_0 != null)
		{
			cancelCommandEventHandler_0();
		}
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
		Value = (double)spn_z.Value;
		if (valueChangedWithDataEventHandler_0 != null)
		{
			valueChangedWithDataEventHandler_0(Math.Abs((double)spn_z.Value), ValueChangesMode.Up);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Value = (double)spn_z.Value;
		if (valueChangedWithDataEventHandler_0 != null)
		{
			valueChangedWithDataEventHandler_0(-1.0 * Math.Abs((double)spn_z.Value), ValueChangesMode.Down);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Value = (double)spn_z.Value;
		if (valueChangedWithDataEventHandler_0 != null)
		{
			valueChangedWithDataEventHandler_0((double)spn_z.Value, ValueChangesMode.Contant);
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
