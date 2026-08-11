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

public class F_CamGrindingHole : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

	public GrindingOperations Operation = new GrindingOperations();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int SelectedTool = 0;

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal TabPage tabPage_0;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal TabPage tabPage_1;

	internal ImageList imageList_0;

	public Button btn_next;

	public Button btn_pre;

	public Button btn_cancel;

	public Button btn_help;

	internal TabControl tabControl_0;

	internal TabPage tabPage_2;

	internal Panel panel_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_2;

	internal ComboBox comboBox_0;

	internal Label label_2;

	internal Panel panel_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal TabPage tabPage_3;

	internal Panel panel_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	public Button btn_ok;

	internal Panel panel_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_7;

	internal Label label_7;

	internal NumericUpDown numericUpDown_6;

	internal Panel panel_8;

	internal Label label_8;

	internal NumericUpDown numericUpDown_7;

	public F_CamGrindingHole()
	{
		Class76.smethod_601(this);
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
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		btn_help.Visible = ShowHelps;
		buGeneral.GetEnumTypeValues(camPars.Hole.HoleType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.Hole.HoleType), ref comboBox_0);
		SetNumericValueSafe(numericUpDown_5, camPars.Hole.DownStep);
		SetNumericValueSafe(numericUpDown_6, camPars.Hole.UpStep);
		SetNumericValueSafe(numericUpDown_1, camPars.Hole.EndHeight);
		SetNumericValueSafe(numericUpDown_2, camPars.Hole.StartHeight);
		SetNumericValueSafe(numericUpDown_3, camPars.Speeds.Leave);
		SetNumericValueSafe(numericUpDown_4, camPars.Speeds.Plunge);
		SetNumericValueSafe(numericUpDown_0, camPars.Distances.Safe);
		SetNumericValueSafe(numericUpDown_7, camPars.Distances.FirstApproach);

		listBox_0.Items.Clear();
		listBox_0.SelectedIndex = -1;
		textBox_0.Clear();
		if (Tools != null)
		{
			for (int i = 0; i < Tools.Count; i++)
			{
				ToolBase tool = Tools[i];
				if (tool != null && tool.Data != null)
				{
					listBox_0.Items.Add(tool.Data.Name + " - No : " + tool.Data.No);
				}
				else
				{
					listBox_0.Items.Add(string.Empty);
				}
			}
			if (SelectedTool >= 0 && SelectedTool < Tools.Count)
			{
				ToolBase selected = Tools[SelectedTool];
				if (selected != null)
				{
					textBox_0.Text = buGeneral.GetToolExplanation(selected);
				}
				if (SelectedTool < listBox_0.Items.Count)
				{
					listBox_0.SelectedIndex = SelectedTool;
				}
			}
		}

		UpdateHoleTypePanels();
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_334(this);
	}

	private static void SetNumericValueSafe(NumericUpDown control, double value)
	{
		if (control == null || double.IsNaN(value) || double.IsInfinity(value))
		{
			return;
		}
		decimal converted;
		try
		{
			converted = Convert.ToDecimal(value);
		}
		catch (OverflowException)
		{
			return;
		}
		if (converted < control.Minimum)
		{
			converted = control.Minimum;
		}
		else if (converted > control.Maximum)
		{
			converted = control.Maximum;
		}
		control.Value = converted;
	}

	private void UpdateHoleTypePanels()
	{
		bool steppedHole = comboBox_0.SelectedIndex == 1;
		panel_6.Enabled = steppedHole;
		panel_7.Enabled = steppedHole;
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (!(sender is Control control))
		{
			return;
		}
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
			Class76.smethod_603(this);
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.TouchPad && sender is NumericUpDown numericUpDown)
		{
			buControlCommands.ShowKeyPadWinControl(this, numericUpDown);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		UpdateHoleTypePanels();
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