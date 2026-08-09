using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Drawings;

public class F_RectangleRound : Form
{
	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public RectangleCornerFilletData Rect = new RectangleCornerFilletData();

	public bool VisibleRotate = true;

	public static List<string> Captions = new List<string>();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal NumericUpDown numericUpDown_0;

	internal ImageList imageList_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_4;

	internal PictureBox pictureBox_0;

	internal NumericUpDown numericUpDown_5;

	internal Label label_5;

	internal Button button_0;

	internal Button button_1;

	internal PictureBox pictureBox_1;

	public F_RectangleRound()
	{
		Class76.smethod_723(this);
	}

	public void Init()
	{
		bool_0 = false;
		numericUpDown_3.Value = (decimal)Rect.Height;
		numericUpDown_4.Value = (decimal)Rect.Width;
		numericUpDown_0.Value = (decimal)Rect.Radius;
		numericUpDown_2.Value = (decimal)Rect.CornerPoint.X;
		numericUpDown_1.Value = (decimal)Rect.CornerPoint.Y;
		numericUpDown_5.Value = (decimal)Rect.Rotation;
		Result = DialogResult.None;
		label_5.Visible = VisibleRotate;
		numericUpDown_5.Visible = VisibleRotate;
		pictureBox_0.Visible = VisibleRotate;
		bool_0 = true;
		Class76.smethod_575(this);
	}

	public void Init(ShapeData rect)
	{
		bool_0 = false;
		if (rect.GetType() == typeof(RectangleCornerFilletData))
		{
			Rect = new RectangleCornerFilletData((RectangleCornerFilletData)rect);
		}
		numericUpDown_3.Value = (decimal)Rect.Height;
		numericUpDown_4.Value = (decimal)Rect.Width;
		numericUpDown_0.Value = (decimal)Rect.Radius;
		numericUpDown_2.Value = (decimal)Rect.CornerPoint.X;
		numericUpDown_5.Value = (decimal)Rect.Rotation;
		numericUpDown_1.Value = (decimal)Rect.CornerPoint.Y;
		Result = DialogResult.None;
		label_5.Visible = VisibleRotate;
		numericUpDown_5.Visible = VisibleRotate;
		pictureBox_0.Visible = VisibleRotate;
		bool_0 = true;
	}

	public void Apply()
	{
		Rect.Height = (double)numericUpDown_3.Value;
		Rect.Width = (double)numericUpDown_4.Value;
		Rect.Rotation = (double)numericUpDown_5.Value;
		Rect.Radius = (double)numericUpDown_0.Value;
		Rect.CornerPoint = new Pnt3D((double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0);
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
