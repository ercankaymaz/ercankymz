using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelG54 : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithValueEventHandler okCommandWithValueEventHandler_0;

	public Pnt9D[] G54List = new Pnt9D[10];

	private int int_0 = 0;

	private IContainer icontainer_0 = null;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	internal NumericUpDown numericUpDown_8;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal NumericUpDown numericUpDown_11;

	internal NumericUpDown numericUpDown_12;

	internal NumericUpDown numericUpDown_13;

	internal NumericUpDown numericUpDown_14;

	internal NumericUpDown numericUpDown_15;

	internal NumericUpDown numericUpDown_16;

	internal NumericUpDown numericUpDown_17;

	internal Button button_0;

	internal Button button_1;

	public Button btn_xassing;

	public Button btn_yassingn;

	public Button btn_zassign;

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

	public event OkCommandWithValueEventHandler SelectHead
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithValueEventHandler okCommandWithValueEventHandler = okCommandWithValueEventHandler_0;
			OkCommandWithValueEventHandler okCommandWithValueEventHandler2;
			do
			{
				okCommandWithValueEventHandler2 = okCommandWithValueEventHandler;
				OkCommandWithValueEventHandler value2 = (OkCommandWithValueEventHandler)Delegate.Combine(okCommandWithValueEventHandler2, value);
				okCommandWithValueEventHandler = Interlocked.CompareExchange(ref okCommandWithValueEventHandler_0, value2, okCommandWithValueEventHandler2);
			}
			while ((object)okCommandWithValueEventHandler != okCommandWithValueEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithValueEventHandler okCommandWithValueEventHandler = okCommandWithValueEventHandler_0;
			OkCommandWithValueEventHandler okCommandWithValueEventHandler2;
			do
			{
				okCommandWithValueEventHandler2 = okCommandWithValueEventHandler;
				OkCommandWithValueEventHandler value2 = (OkCommandWithValueEventHandler)Delegate.Remove(okCommandWithValueEventHandler2, value);
				okCommandWithValueEventHandler = Interlocked.CompareExchange(ref okCommandWithValueEventHandler_0, value2, okCommandWithValueEventHandler2);
			}
			while ((object)okCommandWithValueEventHandler != okCommandWithValueEventHandler2);
		}
	}

	public F_JewelG54()
	{
		Class76.smethod_150(this);
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

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		numericUpDown_0.Value = (decimal)G54List[0].X;
		numericUpDown_1.Value = (decimal)G54List[0].Y;
		numericUpDown_2.Value = (decimal)G54List[0].Z;
		numericUpDown_5.Value = (decimal)G54List[1].X;
		numericUpDown_4.Value = (decimal)G54List[1].Y;
		numericUpDown_3.Value = (decimal)G54List[1].Z;
		numericUpDown_11.Value = (decimal)G54List[2].X;
		numericUpDown_10.Value = (decimal)G54List[2].Y;
		numericUpDown_9.Value = (decimal)G54List[2].Z;
		numericUpDown_8.Value = (decimal)G54List[3].X;
		numericUpDown_7.Value = (decimal)G54List[3].Y;
		numericUpDown_6.Value = (decimal)G54List[3].Z;
		numericUpDown_17.Value = (decimal)G54List[4].X;
		numericUpDown_16.Value = (decimal)G54List[4].Y;
		numericUpDown_15.Value = (decimal)G54List[4].Z;
		numericUpDown_14.Value = (decimal)G54List[5].X;
		numericUpDown_13.Value = (decimal)G54List[5].Y;
		numericUpDown_12.Value = (decimal)G54List[5].Z;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	public void Assign(string Axis, Pnt9D Position)
	{
		if (Axis == "X")
		{
			if (int_0 == 1)
			{
				numericUpDown_0.Value = (decimal)Position.X;
			}
			if (int_0 == 2)
			{
				numericUpDown_5.Value = (decimal)Position.X;
			}
			if (int_0 == 3)
			{
				numericUpDown_11.Value = (decimal)Position.X;
			}
			if (int_0 == 4)
			{
				numericUpDown_8.Value = (decimal)Position.X;
			}
			if (int_0 == 5)
			{
				numericUpDown_17.Value = (decimal)Position.X;
			}
			if (int_0 == 6)
			{
				numericUpDown_14.Value = (decimal)Position.X;
			}
		}
		if (Axis == "Y")
		{
			if (int_0 == 11)
			{
				numericUpDown_1.Value = (decimal)Position.Y;
			}
			if (int_0 == 12)
			{
				numericUpDown_4.Value = (decimal)Position.Y;
			}
			if (int_0 == 13)
			{
				numericUpDown_10.Value = (decimal)Position.Y;
			}
			if (int_0 == 14)
			{
				numericUpDown_7.Value = (decimal)Position.Y;
			}
			if (int_0 == 15)
			{
				numericUpDown_16.Value = (decimal)Position.Y;
			}
			if (int_0 == 16)
			{
				numericUpDown_13.Value = (decimal)Position.Y;
			}
		}
		if (Axis == "Z")
		{
			if (int_0 == 21)
			{
				numericUpDown_2.Value = (decimal)Position.Z;
			}
			if (int_0 == 22)
			{
				numericUpDown_3.Value = (decimal)Position.W;
			}
			if (int_0 == 23)
			{
				numericUpDown_9.Value = (decimal)Position.Z;
			}
			if (int_0 == 24)
			{
				numericUpDown_6.Value = (decimal)Position.Z;
			}
			if (int_0 == 25)
			{
				numericUpDown_15.Value = (decimal)Position.W;
			}
			if (int_0 == 26)
			{
				numericUpDown_12.Value = (decimal)Position.W;
			}
		}
	}

	public void Assign(string Axis, Pnt12D Position)
	{
		if (Axis == "X")
		{
			if (int_0 == 1)
			{
				numericUpDown_0.Value = (decimal)Position.X;
			}
			if (int_0 == 2)
			{
				numericUpDown_5.Value = (decimal)Position.X;
			}
			if (int_0 == 3)
			{
				numericUpDown_11.Value = (decimal)Position.X;
			}
			if (int_0 == 4)
			{
				numericUpDown_8.Value = (decimal)Position.X;
			}
			if (int_0 == 5)
			{
				numericUpDown_17.Value = (decimal)Position.X;
			}
			if (int_0 == 6)
			{
				numericUpDown_14.Value = (decimal)Position.X;
			}
		}
		if (Axis == "Y")
		{
			if (int_0 == 11)
			{
				numericUpDown_1.Value = (decimal)Position.Y;
			}
			if (int_0 == 12)
			{
				numericUpDown_4.Value = (decimal)Position.Y;
			}
			if (int_0 == 13)
			{
				numericUpDown_10.Value = (decimal)Position.Y;
			}
			if (int_0 == 14)
			{
				numericUpDown_7.Value = (decimal)Position.Y;
			}
			if (int_0 == 15)
			{
				numericUpDown_16.Value = (decimal)Position.Y;
			}
			if (int_0 == 16)
			{
				numericUpDown_13.Value = (decimal)Position.Y;
			}
		}
		if (Axis == "Z")
		{
			if (int_0 == 21)
			{
				numericUpDown_2.Value = (decimal)Position.Z;
			}
			if (int_0 == 22)
			{
				numericUpDown_3.Value = (decimal)Position.W;
			}
			if (int_0 == 23)
			{
				numericUpDown_9.Value = (decimal)Position.Z;
			}
			if (int_0 == 24)
			{
				numericUpDown_6.Value = (decimal)Position.Z;
			}
			if (int_0 == 25)
			{
				numericUpDown_15.Value = (decimal)Position.W;
			}
			if (int_0 == 26)
			{
				numericUpDown_12.Value = (decimal)Position.W;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.OK;
		Class76.smethod_687(this);
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
	}

	internal void method_3(object sender, EventArgs e)
	{
		NumericUpDown numericUpDown = new NumericUpDown();
		numericUpDown = (NumericUpDown)sender;
		int_0 = Convert.ToInt32(numericUpDown.Tag);
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_3.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(1.0);
		}
		if (control.Name == label_4.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(2.0);
		}
		if (control.Name == label_5.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(3.0);
		}
		if (control.Name == label_6.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(4.0);
		}
		if (control.Name == label_7.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(5.0);
		}
		if (control.Name == label_8.Name && okCommandWithValueEventHandler_0 != null)
		{
			okCommandWithValueEventHandler_0(6.0);
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
