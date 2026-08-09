using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Drawings;

public class F_Barrel : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public BarrelData Barrel = new BarrelData();

	public bool VisibleRotate = true;

	public bool VisibleCoordinate = true;

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

	public F_Barrel()
	{
		Class76.smethod_201(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		numericUpDown_3.Value = (decimal)Barrel.Height;
		numericUpDown_4.Value = (decimal)Barrel.Width;
		numericUpDown_0.Value = (decimal)Barrel.HeadRadius;
		numericUpDown_2.Value = (decimal)Barrel.HeadCenterPoint.X;
		numericUpDown_1.Value = (decimal)Barrel.HeadCenterPoint.Y;
		numericUpDown_5.Value = (decimal)Barrel.Rotation;
		PropertiesForm.Result = DialogResult.None;
		label_5.Visible = VisibleRotate;
		numericUpDown_5.Visible = VisibleRotate;
		pictureBox_0.Visible = VisibleRotate;
		label_2.Visible = VisibleCoordinate;
		label_1.Visible = VisibleCoordinate;
		numericUpDown_2.Visible = VisibleCoordinate;
		numericUpDown_1.Visible = VisibleCoordinate;
		PropertiesForm.Inited = true;
		Class76.smethod_31(this);
	}

	public void Init(ShapeData barrel)
	{
		PropertiesForm.Inited = false;
		if (barrel.GetType() == typeof(BarrelData))
		{
			Barrel = new BarrelData((BarrelData)barrel);
		}
		numericUpDown_3.Value = (decimal)Barrel.Height;
		numericUpDown_4.Value = (decimal)Barrel.Width;
		numericUpDown_0.Value = (decimal)Barrel.HeadRadius;
		numericUpDown_2.Value = (decimal)Barrel.HeadCenterPoint.X;
		numericUpDown_1.Value = (decimal)Barrel.HeadCenterPoint.Y;
		numericUpDown_5.Value = (decimal)Barrel.Rotation;
		PropertiesForm.Result = DialogResult.None;
		label_5.Visible = VisibleRotate;
		numericUpDown_5.Visible = VisibleRotate;
		pictureBox_0.Visible = VisibleRotate;
		PropertiesForm.Inited = true;
	}

	public void Apply()
	{
		Barrel.Height = (double)numericUpDown_3.Value;
		Barrel.Width = (double)numericUpDown_4.Value;
		Barrel.Rotation = (double)numericUpDown_5.Value;
		Barrel.HeadRadius = (double)numericUpDown_0.Value;
		Barrel.HeadCenterPoint = new Pnt3D((double)numericUpDown_2.Value, (double)numericUpDown_1.Value, 0.0);
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
		PropertiesForm.Result = DialogResult.OK;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.Cancel;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_4(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Inited && PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
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
