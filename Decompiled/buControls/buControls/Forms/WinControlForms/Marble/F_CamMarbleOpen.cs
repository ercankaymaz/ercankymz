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

public class F_CamMarbleOpen : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

	public marbleOperation Operation = new marbleOperation();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int SelectedTool = 0;

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Panel panel_1;

	internal ComboBox comboBox_0;

	internal Label label_1;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

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

	internal CheckBox checkBox_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal TabPage tabPage_5;

	internal Panel panel_3;

	internal Panel panel_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_7;

	internal Label label_7;

	internal NumericUpDown numericUpDown_6;

	internal CheckBox checkBox_2;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal Label label_8;

	internal NumericUpDown numericUpDown_7;

	internal Label label_9;

	internal NumericUpDown numericUpDown_8;

	internal Label label_10;

	internal NumericUpDown numericUpDown_9;

	internal Label label_11;

	internal NumericUpDown numericUpDown_10;

	internal ComboBox comboBox_1;

	internal ComboBox comboBox_2;

	internal PictureBox pictureBox_0;

	internal Label label_12;

	internal NumericUpDown numericUpDown_11;

	internal Label label_13;

	internal NumericUpDown numericUpDown_12;

	internal Label label_14;

	internal NumericUpDown numericUpDown_13;

	internal Label label_15;

	internal NumericUpDown numericUpDown_14;

	internal CheckBox checkBox_3;

	internal Label label_16;

	internal NumericUpDown numericUpDown_15;

	internal Label label_17;

	internal NumericUpDown numericUpDown_16;

	internal CheckBox checkBox_4;

	internal Panel panel_8;

	internal Label label_18;

	internal NumericUpDown numericUpDown_17;

	internal Panel panel_9;

	internal NumericUpDown numericUpDown_18;

	internal Label label_19;

	internal Panel panel_10;

	internal NumericUpDown numericUpDown_19;

	internal Label label_20;

	internal Panel panel_11;

	internal NumericUpDown numericUpDown_20;

	internal Label label_21;

	internal Panel panel_12;

	internal Label label_22;

	internal NumericUpDown numericUpDown_21;

	public F_CamMarbleOpen()
	{
		Class76.smethod_401(this);
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
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.Offsets.OpenContourOld, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.Offsets.OpenContourOld), ref comboBox_0);
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.Items.RemoveAt(comboBox_0.Items.Count - 1);
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.Items.RemoveAt(comboBox_0.Items.Count - 1);
		}
		numericUpDown_1.Value = (decimal)camPars.Operations.TargetZ;
		numericUpDown_0.Value = (decimal)Operation.InnerCutSafeDistance;
		numericUpDown_2.Value = (decimal)camPars.Offsets.OverlapDistance;
		checkBox_1.Checked = Operation.CutSawDistanceFromEndPoint;
		checkBox_0.Checked = Operation.CutSawDistanceFromStartPoint;
		numericUpDown_2.Value = (decimal)Operation.CutSawDistanceOverlap;
		numericUpDown_17.Value = (decimal)camPars.Offsets.Offset;
		numericUpDown_20.Value = (decimal)camPars.Speeds.Feed;
		numericUpDown_18.Value = (decimal)camPars.Speeds.Leave;
		numericUpDown_19.Value = (decimal)camPars.Speeds.Plunge;
		numericUpDown_3.Value = (decimal)camPars.Distances.Safe;
		numericUpDown_21.Value = (decimal)camPars.Distances.StepUp;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.LeadIn.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadIn.LeadType), ref comboBox_2);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.LeadOut.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadOut.LeadType), ref comboBox_1);
		numericUpDown_15.Value = (decimal)camPars.LeadIn.ExtendLength;
		numericUpDown_16.Value = (decimal)camPars.LeadIn.ArcRadius;
		numericUpDown_12.Value = (decimal)camPars.LeadIn.ArcSweepAngle;
		numericUpDown_10.Value = (decimal)camPars.LeadIn.TangentAngle;
		numericUpDown_8.Value = (decimal)camPars.LeadIn.Length;
		numericUpDown_13.Value = (decimal)camPars.LeadOut.ExtendLength;
		numericUpDown_14.Value = (decimal)camPars.LeadOut.ArcRadius;
		numericUpDown_11.Value = (decimal)camPars.LeadOut.ArcSweepAngle;
		numericUpDown_9.Value = (decimal)camPars.LeadOut.TangentAngle;
		numericUpDown_7.Value = (decimal)camPars.LeadOut.Length;
		checkBox_4.Checked = camPars.LeadIn.Enable;
		checkBox_3.Checked = camPars.LeadOut.Enable;
		if (comboBox_2.SelectedIndex == 0)
		{
			label_11.Enabled = false;
			label_17.Enabled = true;
			label_13.Enabled = true;
			numericUpDown_10.Enabled = false;
			numericUpDown_12.Enabled = true;
			numericUpDown_16.Enabled = true;
		}
		if (comboBox_2.SelectedIndex == 1)
		{
			label_11.Enabled = true;
			label_17.Enabled = false;
			label_13.Enabled = false;
			numericUpDown_10.Enabled = true;
			numericUpDown_12.Enabled = false;
			numericUpDown_16.Enabled = false;
		}
		if (comboBox_1.SelectedIndex == 0)
		{
			label_10.Enabled = false;
			label_15.Enabled = true;
			label_12.Enabled = true;
			numericUpDown_9.Enabled = false;
			numericUpDown_11.Enabled = true;
			numericUpDown_14.Enabled = true;
		}
		if (comboBox_1.SelectedIndex == 1)
		{
			label_10.Enabled = true;
			label_15.Enabled = false;
			label_12.Enabled = false;
			numericUpDown_9.Enabled = true;
			numericUpDown_11.Enabled = false;
			numericUpDown_14.Enabled = false;
		}
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
		numericUpDown_6.Value = (decimal)camPars.Steps.StartValue;
		numericUpDown_5.Value = (decimal)camPars.Steps.EndValue;
		numericUpDown_4.Value = camPars.Steps.Count;
		checkBox_2.Checked = camPars.Steps.Enable;
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class76.smethod_357(this);
	}

	public void ControlUpdate()
	{
		if (!checkBox_4.Checked)
		{
			label_11.Enabled = false;
			label_9.Enabled = false;
			label_17.Enabled = false;
			label_13.Enabled = false;
			numericUpDown_10.Enabled = false;
			numericUpDown_8.Enabled = false;
			numericUpDown_12.Enabled = false;
			numericUpDown_16.Enabled = false;
		}
		else
		{
			if (comboBox_2.SelectedIndex == 0)
			{
				label_11.Enabled = false;
				label_9.Enabled = false;
				label_17.Enabled = true;
				label_13.Enabled = true;
				numericUpDown_10.Enabled = false;
				numericUpDown_8.Enabled = false;
				numericUpDown_12.Enabled = true;
				numericUpDown_16.Enabled = true;
			}
			if (comboBox_2.SelectedIndex == 1)
			{
				label_11.Enabled = true;
				label_9.Enabled = true;
				label_17.Enabled = false;
				label_13.Enabled = false;
				numericUpDown_10.Enabled = true;
				numericUpDown_8.Enabled = true;
				numericUpDown_12.Enabled = false;
				numericUpDown_16.Enabled = false;
			}
		}
		if (!checkBox_3.Checked)
		{
			label_10.Enabled = false;
			label_8.Enabled = false;
			label_15.Enabled = false;
			label_12.Enabled = false;
			numericUpDown_9.Enabled = false;
			numericUpDown_7.Enabled = false;
			numericUpDown_11.Enabled = false;
			numericUpDown_14.Enabled = false;
		}
		else
		{
			if (comboBox_1.SelectedIndex == 0)
			{
				label_10.Enabled = false;
				label_8.Enabled = false;
				label_15.Enabled = true;
				label_12.Enabled = true;
				numericUpDown_9.Enabled = false;
				numericUpDown_7.Enabled = false;
				numericUpDown_11.Enabled = true;
				numericUpDown_14.Enabled = true;
			}
			if (comboBox_1.SelectedIndex == 1)
			{
				label_10.Enabled = true;
				label_8.Enabled = true;
				label_15.Enabled = false;
				label_12.Enabled = false;
				numericUpDown_9.Enabled = true;
				numericUpDown_7.Enabled = true;
				numericUpDown_11.Enabled = false;
				numericUpDown_14.Enabled = false;
			}
		}
		panel_7.Enabled = checkBox_2.Checked;
		panel_6.Enabled = checkBox_2.Checked;
		panel_5.Enabled = checkBox_2.Checked;
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
			Class76.smethod_321(this);
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
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == checkBox_2.Name)
			{
				ControlUpdate();
			}
			if (control.Name == checkBox_4.Name)
			{
				ControlUpdate();
			}
			if (control.Name == checkBox_3.Name)
			{
				ControlUpdate();
			}
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == comboBox_2.Name)
			{
				ControlUpdate();
			}
			if (control.Name == comboBox_1.Name)
			{
				ControlUpdate();
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
