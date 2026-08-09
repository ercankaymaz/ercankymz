using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Grinding;

public class F_GrindingAddVacuum : Form
{
	public FormProperties Properties = new FormProperties();

	public GrindingOperations Operation = new GrindingOperations();

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal ComboBox comboBox_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	public F_GrindingAddVacuum()
	{
		Class76.smethod_93(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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
		comboBox_0.SelectedIndex = 0;
		numericUpDown_1.Value = (decimal)Operation.VacuumThickness;
		numericUpDown_2.Value = (decimal)Operation.VacuumHeight;
		numericUpDown_0.Value = (decimal)Operation.VacuumDiameter;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_42(this);
	}

	internal void method_2(object sender, EventArgs e)
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
			Class76.smethod_528(this);
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
		if (Properties.Inited)
		{
			numericUpDown_0.Value = Convert.ToDecimal(comboBox_0.Text);
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
