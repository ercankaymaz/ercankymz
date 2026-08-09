using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Drawings;

public class F_Slot : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public SlotData Slot = new SlotData();

	public static List<string> Captions = new List<string>();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal ImageList imageList_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal PictureBox pictureBox_1;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal Button button_0;

	internal Button button_1;

	public F_Slot()
	{
		Class76.smethod_827(this);
	}

	public void Init()
	{
		bool_0 = false;
		numericUpDown_3.Value = (decimal)Slot.Width;
		numericUpDown_2.Value = (decimal)Slot.Height;
		numericUpDown_4.Value = (decimal)Slot.Rotation;
		numericUpDown_1.Value = (decimal)Slot.BasePoint.X;
		numericUpDown_0.Value = (decimal)Slot.BasePoint.Y;
		Result = DialogResult.None;
		bool_0 = true;
		Class76.smethod_833(this);
	}

	public void Init(ShapeData slot)
	{
		bool_0 = false;
		if (slot.GetType() == typeof(SlotData))
		{
			Slot = new SlotData((SlotData)slot);
		}
		numericUpDown_3.Value = (decimal)Slot.Width;
		numericUpDown_2.Value = (decimal)Slot.Height;
		numericUpDown_4.Value = (decimal)Slot.Rotation;
		numericUpDown_1.Value = (decimal)Slot.BasePoint.X;
		numericUpDown_0.Value = (decimal)Slot.BasePoint.Y;
		Result = DialogResult.None;
		bool_0 = true;
	}

	public void Apply()
	{
		Slot.Width = (double)numericUpDown_3.Value;
		Slot.Height = (double)numericUpDown_2.Value;
		Slot.Rotation = (double)numericUpDown_4.Value;
		Slot.BasePoint = new Pnt3D((double)numericUpDown_1.Value, (double)numericUpDown_0.Value, 0.0);
	}

	internal void method_0(object sender, KeyEventArgs e)
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

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				if (sender.GetType() == typeof(TextBox))
				{
					TextBox textBox = new TextBox();
					textBox = (TextBox)sender;
					buControlCommands.ShowKeyPad(this, textBox);
				}
				if (sender.GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = new NumericUpDown();
					numericUpDown = (NumericUpDown)sender;
					buControlCommands.ShowKeyPad(this, numericUpDown);
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_2(object sender, EventArgs e)
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
	}

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, FormClosingEventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
