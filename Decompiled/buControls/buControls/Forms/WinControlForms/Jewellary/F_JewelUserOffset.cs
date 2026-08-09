using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelUserOffset : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public Pnt3D SpindleUserOffset = new Pnt3D();

	public Pnt3D DiaCut1UserOffset = new Pnt3D();

	public Pnt3D DiaCut2UserOffset = new Pnt3D();

	public Pnt3D EngraveUserOffset = new Pnt3D();

	public Pnt3D LaserUserOffset = new Pnt3D();

	public Pnt3D LatheUserOffset = new Pnt3D();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

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

	public Button btn_cancel;

	public Button btn_save;

	public F_JewelUserOffset()
	{
		Class76.smethod_534(this);
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
		try
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
			numericUpDown_0.Value = (decimal)SpindleUserOffset.X;
			numericUpDown_1.Value = (decimal)SpindleUserOffset.Y;
			numericUpDown_2.Value = (decimal)SpindleUserOffset.Z;
			numericUpDown_5.Value = (decimal)DiaCut1UserOffset.X;
			numericUpDown_4.Value = (decimal)DiaCut1UserOffset.Y;
			numericUpDown_3.Value = (decimal)DiaCut1UserOffset.Z;
			numericUpDown_11.Value = (decimal)DiaCut2UserOffset.X;
			numericUpDown_10.Value = (decimal)DiaCut2UserOffset.Y;
			numericUpDown_9.Value = (decimal)DiaCut2UserOffset.Z;
			numericUpDown_8.Value = (decimal)EngraveUserOffset.X;
			numericUpDown_7.Value = (decimal)EngraveUserOffset.Y;
			numericUpDown_6.Value = (decimal)EngraveUserOffset.Z;
			numericUpDown_17.Value = (decimal)LaserUserOffset.X;
			numericUpDown_16.Value = (decimal)LaserUserOffset.Y;
			numericUpDown_15.Value = (decimal)LaserUserOffset.Z;
			numericUpDown_14.Value = (decimal)LatheUserOffset.X;
			numericUpDown_13.Value = (decimal)LatheUserOffset.Y;
			numericUpDown_12.Value = (decimal)LatheUserOffset.Z;
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Properties.Result = DialogResult.OK;
		Class76.smethod_755(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
