using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Coordinate;

public class F_MoveXYZ : Form
{
	public Pnt3D Point = new Pnt3D();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;

	public DialogResult Result = DialogResult.None;

	public double Increament = 0.1;

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_1;

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_2;

	[CompilerGenerated]
	private Pnt3DValueChangedEventHandler pnt3DValueChangedEventHandler_0;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	public static List<string> Captions = new List<string>();

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	public NumericUpDown spn_x;

	public NumericUpDown spn_y;

	public NumericUpDown spn_z;

	internal ImageList imageList_1;

	public Button btn_cancel;

	public Button btn_ok;

	public event ValueChangedEventHandler XValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public event ValueChangedEventHandler YValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_1;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_1, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_1;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_1, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public event ValueChangedEventHandler ZValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_2;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_2, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_2;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_2, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

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

	public F_MoveXYZ()
	{
		Class76.smethod_642(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Init(Pnt3D Pnt)
	{
		bool_0 = false;
		Point = new Pnt3D(Pnt);
		spn_x.Value = (decimal)Point.X;
		spn_y.Value = (decimal)Point.Y;
		spn_z.Value = (decimal)Point.Z;
		bool_0 = true;
		Class76.smethod_431(this);
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		if (bool_0 && Result != DialogResult.OK)
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

	internal void method_2(object sender, EventArgs e)
	{
		if (bool_0)
		{
			if (valueChangedEventHandler_0 != null)
			{
				valueChangedEventHandler_0((double)spn_x.Value);
			}
			if (pnt3DValueChangedEventHandler_0 != null)
			{
				Pnt3DValueChangedEventArg pnt3DValueChangedEventArg = new Pnt3DValueChangedEventArg();
				pnt3DValueChangedEventArg.Enable = new AxesEnableXYZ(x: true, y: false, z: false);
				pnt3DValueChangedEventArg.X = (double)spn_x.Value;
				pnt3DValueChangedEventArg.Point = new Pnt3D((double)spn_x.Value, (double)spn_y.Value, (double)spn_z.Value);
				pnt3DValueChangedEventHandler_0(pnt3DValueChangedEventArg);
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (bool_0)
		{
			if (valueChangedEventHandler_1 != null)
			{
				valueChangedEventHandler_1((double)spn_y.Value);
			}
			if (pnt3DValueChangedEventHandler_0 != null)
			{
				Pnt3DValueChangedEventArg pnt3DValueChangedEventArg = new Pnt3DValueChangedEventArg();
				pnt3DValueChangedEventArg.Enable = new AxesEnableXYZ(x: false, y: true, z: false);
				pnt3DValueChangedEventArg.Y = (double)spn_y.Value;
				pnt3DValueChangedEventArg.Point = new Pnt3D((double)spn_x.Value, (double)spn_y.Value, (double)spn_z.Value);
				pnt3DValueChangedEventHandler_0(pnt3DValueChangedEventArg);
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (bool_0)
		{
			if (valueChangedEventHandler_2 != null)
			{
				valueChangedEventHandler_2((double)spn_z.Value);
			}
			if (pnt3DValueChangedEventHandler_0 != null)
			{
				Pnt3DValueChangedEventArg pnt3DValueChangedEventArg = new Pnt3DValueChangedEventArg();
				pnt3DValueChangedEventArg.Enable = new AxesEnableXYZ(x: false, y: false, z: true);
				pnt3DValueChangedEventArg.Z = (double)spn_z.Value;
				pnt3DValueChangedEventArg.Point = new Pnt3D((double)spn_x.Value, (double)spn_y.Value, (double)spn_z.Value);
				pnt3DValueChangedEventHandler_0(pnt3DValueChangedEventArg);
			}
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		spn_x.Value -= (decimal)Increament;
	}

	internal void method_6(object sender, EventArgs e)
	{
		spn_y.Value -= (decimal)Increament;
	}

	internal void method_7(object sender, EventArgs e)
	{
		spn_z.Value -= (decimal)Increament;
	}

	internal void method_8(object sender, EventArgs e)
	{
		spn_x.Value += (decimal)Increament;
	}

	internal void method_9(object sender, EventArgs e)
	{
		spn_y.Value += (decimal)Increament;
	}

	internal void method_10(object sender, EventArgs e)
	{
		spn_z.Value += (decimal)Increament;
	}

	internal void method_11(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		if (okCommandEventHandler_0 != null)
		{
			okCommandEventHandler_0();
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

	internal void method_12(object sender, EventArgs e)
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
