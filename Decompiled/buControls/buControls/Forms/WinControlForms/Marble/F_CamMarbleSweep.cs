using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_CamMarbleSweep : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

	public marbleOperation Operation = new marbleOperation();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int SelectedTool = 0;

	public static List<string> Captions = new List<string>();

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public int FormHeight = 0;

	public int FormWidth = 0;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal Panel panel_1;

	internal Label label_1;

	internal Panel panel_2;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal ImageList imageList_0;

	public Button btn_next;

	public Button btn_pre;

	public Button btn_cancel;

	public Button btn_ok;

	internal CheckBox checkBox_0;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal Panel panel_4;

	internal CheckBox checkBox_1;

	internal Label label_4;

	internal Panel panel_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_7;

	internal Label label_7;

	internal NumericUpDown numericUpDown_5;

	internal CheckBox checkBox_2;

	internal Panel panel_8;

	internal NumericUpDown numericUpDown_6;

	internal Label label_8;

	internal Panel panel_9;

	internal NumericUpDown numericUpDown_7;

	internal Label label_9;

	internal Panel panel_10;

	internal NumericUpDown numericUpDown_8;

	internal Label label_10;

	internal Panel panel_11;

	internal Label label_11;

	internal NumericUpDown numericUpDown_9;

	internal Panel panel_12;

	internal Label label_12;

	internal NumericUpDown numericUpDown_10;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal Panel panel_13;

	internal Label label_13;

	internal ComboBox comboBox_0;

	internal Label label_14;

	internal NumericUpDown numericUpDown_11;

	public Button btn_rampok;

	public Button btn_rampcancel;

	internal Label label_15;

	internal NumericUpDown numericUpDown_12;

	internal Label label_16;

	internal Panel panel_14;

	public Button btn_rampsetshow;

	internal CheckBox checkBox_3;

	internal Label label_17;

	public Button btn_profilecurve;

	public F_CamMarbleSweep()
	{
		Class76.smethod_751(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if ((Properties.Result != DialogResult.OK) & (Properties.Result != DialogResult.Ignore))
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
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		numericUpDown_1.Value = (decimal)Operation.TargetZ;
		numericUpDown_0.Value = (decimal)Operation.SweepConstantAngle;
		numericUpDown_2.Value = (decimal)Operation.SweepOffsetAngleForTangent;
		checkBox_0.Checked = Operation.SweepFollowTangent;
		checkBox_1.Checked = Operation.SweepZUpSharpCorner;
		numericUpDown_8.Value = (decimal)camPars.Speeds.Feed;
		numericUpDown_6.Value = (decimal)camPars.Speeds.Leave;
		numericUpDown_7.Value = (decimal)camPars.Speeds.Plunge;
		numericUpDown_10.Value = (decimal)camPars.Distances.Safe;
		numericUpDown_9.Value = (decimal)camPars.Distances.StepUp;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Operation.SawRampType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Operation.SawRampType), ref comboBox_0);
		numericUpDown_12.Value = (decimal)Operation.SawRampHeight;
		numericUpDown_11.Value = (decimal)Operation.SawRampLenght;
		checkBox_3.Checked = Operation.SawRampEnable;
		if ((SelectedTool >= 0) & (SelectedTool <= Tools.Count - 1))
		{
			textBox_0.Text = buGeneral.GetToolExplanation(Tools[SelectedTool]);
			listBox_0.Items.Clear();
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				listBox_0.Items.Add(Tools[i].Data.Name + " - No : " + Tools[i].Data.No);
			}
			listBox_0.SelectedIndex = SelectedTool;
		}
		numericUpDown_5.Value = (decimal)camPars.Steps.StartValue;
		numericUpDown_4.Value = (decimal)camPars.Steps.EndValue;
		numericUpDown_3.Value = camPars.Steps.Count;
		checkBox_2.Checked = camPars.Steps.Enable;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class76.smethod_280(this);
	}

	public void ControlUpdate()
	{
		panel_7.Enabled = checkBox_2.Checked;
		panel_6.Enabled = checkBox_2.Checked;
		panel_5.Enabled = checkBox_2.Checked;
		panel_3.Enabled = checkBox_0.Checked;
		panel_0.Enabled = !checkBox_0.Checked;
		btn_rampsetshow.Enabled = checkBox_3.Checked;
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
			Class76.smethod_590(this);
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
		if (control.Name == btn_pre.Name && tabControl_0.SelectedIndex > 0)
		{
			tabControl_0.SelectedIndex--;
		}
		if (control.Name == btn_next.Name && tabControl_0.SelectedIndex < tabControl_0.TabPages.Count - 1)
		{
			tabControl_0.SelectedIndex++;
		}
		if (control.Name == btn_rampsetshow.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (panel_13.Visible)
			{
				panel_13.Visible = false;
			}
			else
			{
				panel_13.Visible = true;
			}
		}
		if (control.Name == btn_rampcancel.Name)
		{
			panel_13.Visible = false;
		}
		if (control.Name == btn_rampok.Name)
		{
			Operation.SawRampHeight = (double)numericUpDown_12.Value;
			Operation.SawRampLenght = (double)numericUpDown_11.Value;
			Operation.SawRampEnable = checkBox_3.Checked;
			Operation.SawRampType = (CamZRampType)buGeneral.EnumValueFromInt(Operation.SawRampType, comboBox_0.SelectedIndex);
			panel_13.Visible = false;
		}
		if (control.Name == btn_profilecurve.Name)
		{
			Properties.Result = DialogResult.Ignore;
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
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == checkBox_2.Name)
			{
				ControlUpdate();
			}
			if (control.Name == checkBox_0.Name)
			{
				ControlUpdate();
			}
			if (control.Name == checkBox_3.Name)
			{
				ControlUpdate();
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
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
