using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Grinding;

public class F_GrindingSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public GrindingSettings Settings = new GrindingSettings();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal ComboBox comboBox_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	public F_GrindingSettings()
	{
		Class76.smethod_472(this);
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
		ArrayList arrayList = new ArrayList();
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
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Settings.OffsetCornerType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Settings.OffsetCornerType), ref comboBox_0);
		numericUpDown_1.Value = (decimal)Settings.EntityCathResolutionPersentage;
		numericUpDown_0.Value = (decimal)Settings.GlassThickness;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_328(this);
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_777(this);
			Properties.Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.TouchPad)
		{
			NumericUpDown numericUpDown = new NumericUpDown();
			numericUpDown = (NumericUpDown)sender;
			buControlCommands.ShowKeyPadWinControl(this, numericUpDown);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		new Control();
		if (Properties.Inited)
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
