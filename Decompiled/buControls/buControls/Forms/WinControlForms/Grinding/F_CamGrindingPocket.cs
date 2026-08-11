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

public class F_CamGrindingPocket : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

	public camParameters camParsHole = new camParameters();

	public GrindingOperations Operation = new GrindingOperations();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int SelectedTool = 0;

	public bool IsInsideOperation = false;

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal ImageList imageList_0;

	public Button btn_next;

	public Button btn_pre;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabPage tabPage_4;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal CheckBox checkBox_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	internal CheckBox checkBox_1;

	internal Panel panel_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_7;

	internal Panel panel_2;

	internal CheckBox checkBox_2;

	internal Label label_8;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal Panel panel_3;

	internal Label label_9;

	internal NumericUpDown numericUpDown_8;

	internal Panel panel_4;

	internal Label label_10;

	internal NumericUpDown numericUpDown_9;

	internal Panel panel_5;

	internal Label label_11;

	internal NumericUpDown numericUpDown_10;

	internal Panel panel_6;

	internal Label label_12;

	internal NumericUpDown numericUpDown_11;

	internal PictureBox pictureBox_0;

	public Button btn_help;

	internal Label label_13;

	internal NumericUpDown numericUpDown_12;

	internal Label label_14;

	internal NumericUpDown numericUpDown_13;

	internal ComboBox comboBox_0;

	internal ComboBox comboBox_1;

	internal Label label_15;

	internal NumericUpDown numericUpDown_14;

	internal Label label_16;

	internal NumericUpDown numericUpDown_15;

	public F_CamGrindingPocket()
	{
		Class76.smethod_801(this);
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

		SetNumericValueSafe(numericUpDown_0, camPars.Operations.TargetZ);
		SetNumericValueSafe(numericUpDown_5, camPars.Offsets.Offset);
		checkBox_2.Checked = camPars.Offsets.AddToolDiameterAsOffset;
		SetNumericValueSafe(numericUpDown_10, camPars.Speeds.Feed);
		SetNumericValueSafe(numericUpDown_8, camPars.Speeds.Leave);
		SetNumericValueSafe(numericUpDown_9, camPars.Speeds.Plunge);
		SetNumericValueSafe(numericUpDown_11, camPars.Distances.Safe);

		buGeneral.GetEnumTypeValues(camPars.LeadIn.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadIn.LeadType), ref comboBox_1);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.LeadOut.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadOut.LeadType), ref comboBox_0);

		SetNumericValueSafe(numericUpDown_3, camPars.LeadIn.ExtendLength);
		SetNumericValueSafe(numericUpDown_4, camPars.LeadIn.ArcRadius);
		SetNumericValueSafe(numericUpDown_7, camPars.LeadIn.ArcSweepAngle);
		SetNumericValueSafe(numericUpDown_13, camPars.LeadIn.TangentAngle);
		SetNumericValueSafe(numericUpDown_15, camPars.LeadIn.Length);
		SetNumericValueSafe(numericUpDown_1, camPars.LeadOut.ExtendLength);
		SetNumericValueSafe(numericUpDown_2, camPars.LeadOut.ArcRadius);
		SetNumericValueSafe(numericUpDown_6, camPars.LeadOut.ArcSweepAngle);
		SetNumericValueSafe(numericUpDown_12, camPars.LeadOut.TangentAngle);
		SetNumericValueSafe(numericUpDown_14, camPars.LeadOut.Length);
		checkBox_1.Checked = camPars.LeadIn.Enable;
		checkBox_0.Checked = camPars.LeadOut.Enable;

		UpdateLeadInState();
		UpdateLeadOutState();
		RefreshToolState();

		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_538(this);
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

	private void RefreshToolState()
	{
		listBox_0.Items.Clear();
		listBox_0.SelectedIndex = -1;
		textBox_0.Clear();
		if (Tools == null)
		{
			return;
		}
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
		if (SelectedTool < 0 || SelectedTool >= Tools.Count)
		{
			return;
		}
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

	private void UpdateLeadInState()
	{
		bool tangent = comboBox_1.SelectedIndex == 1;
		label_14.Enabled = tangent;
		label_16.Enabled = tangent;
		label_4.Enabled = !tangent;
		label_7.Enabled = !tangent;
		numericUpDown_13.Enabled = tangent;
		numericUpDown_15.Enabled = tangent;
		numericUpDown_7.Enabled = !tangent;
		numericUpDown_4.Enabled = !tangent;
	}

	private void UpdateLeadOutState()
	{
		bool tangent = comboBox_0.SelectedIndex == 1;
		label_13.Enabled = tangent;
		label_15.Enabled = tangent;
		label_2.Enabled = !tangent;
		label_6.Enabled = !tangent;
		numericUpDown_12.Enabled = tangent;
		numericUpDown_14.Enabled = tangent;
		numericUpDown_6.Enabled = !tangent;
		numericUpDown_2.Enabled = !tangent;
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
			Class76.smethod_82(this);
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
		if (Properties.Inited)
		{
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.TouchPad && sender is NumericUpDown numericUpDown)
		{
			buControlCommands.ShowKeyPadWinControl(this, numericUpDown);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (!Properties.Inited)
		{
			return;
		}
		int index = listBox_0.SelectedIndex;
		if (Tools == null || index < 0 || index >= Tools.Count || Tools[index] == null)
		{
			SelectedTool = -1;
			textBox_0.Clear();
			return;
		}
		SelectedTool = index;
		textBox_0.Text = buGeneral.GetToolExplanation(Tools[index]);
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (!Properties.Inited || !(sender is Control control))
		{
			return;
		}
		if (control.Name == comboBox_1.Name)
		{
			UpdateLeadInState();
		}
		if (control.Name == comboBox_0.Name)
		{
			UpdateLeadOutState();
		}
	}

	internal void method_6(object sender, EventArgs e)
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