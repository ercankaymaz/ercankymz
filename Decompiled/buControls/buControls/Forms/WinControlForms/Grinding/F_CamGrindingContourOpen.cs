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

public class F_CamGrindingContourOpen : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

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

	internal Panel panel_1;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_2;

	internal CheckBox checkBox_0;

	internal Label label_2;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	public Button btn_help;

	internal Panel panel_3;

	internal ComboBox comboBox_0;

	internal Label label_3;

	internal Panel panel_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_5;

	internal Label label_5;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_6;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_7;

	internal Label label_7;

	internal NumericUpDown numericUpDown_5;

	internal Label label_8;

	internal NumericUpDown numericUpDown_6;

	internal Label label_9;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal Label label_11;

	internal NumericUpDown numericUpDown_9;

	internal ComboBox comboBox_1;

	internal ComboBox comboBox_2;

	internal PictureBox pictureBox_0;

	internal Label label_12;

	internal NumericUpDown numericUpDown_10;

	internal Label label_13;

	internal NumericUpDown numericUpDown_11;

	internal Label label_14;

	internal NumericUpDown numericUpDown_12;

	internal Label label_15;

	internal NumericUpDown numericUpDown_13;

	internal CheckBox checkBox_1;

	internal Label label_16;

	internal NumericUpDown numericUpDown_14;

	internal Label label_17;

	internal NumericUpDown numericUpDown_15;

	internal CheckBox checkBox_2;

	public F_CamGrindingContourOpen()
	{
		Class76.smethod_46(this);
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
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.Offsets.OpenContourOld, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.Offsets.OpenContourOld), ref comboBox_0);
		comboBox_0.Items.RemoveAt(4);
		comboBox_0.Items.RemoveAt(3);
		numericUpDown_0.Value = (decimal)camPars.Operations.TargetZ;
		numericUpDown_1.Value = (decimal)camPars.Offsets.Offset;
		checkBox_0.Checked = camPars.Offsets.AddToolDiameterAsOffset;
		numericUpDown_4.Value = (decimal)camPars.Speeds.Feed;
		numericUpDown_2.Value = (decimal)camPars.Speeds.Leave;
		numericUpDown_3.Value = (decimal)camPars.Speeds.Plunge;
		numericUpDown_5.Value = (decimal)camPars.Distances.Safe;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.LeadIn.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadIn.LeadType), ref comboBox_2);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(camPars.LeadOut.LeadType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(camPars.LeadOut.LeadType), ref comboBox_1);
		numericUpDown_14.Value = (decimal)camPars.LeadIn.ExtendLength;
		numericUpDown_15.Value = (decimal)camPars.LeadIn.ArcRadius;
		numericUpDown_11.Value = (decimal)camPars.LeadIn.ArcSweepAngle;
		numericUpDown_9.Value = (decimal)camPars.LeadIn.TangentAngle;
		numericUpDown_7.Value = (decimal)camPars.LeadIn.Length;
		numericUpDown_12.Value = (decimal)camPars.LeadOut.ExtendLength;
		numericUpDown_13.Value = (decimal)camPars.LeadOut.ArcRadius;
		numericUpDown_10.Value = (decimal)camPars.LeadOut.ArcSweepAngle;
		numericUpDown_8.Value = (decimal)camPars.LeadOut.TangentAngle;
		numericUpDown_6.Value = (decimal)camPars.LeadOut.Length;
		checkBox_2.Checked = camPars.LeadIn.Enable;
		checkBox_1.Checked = camPars.LeadOut.Enable;
		if (comboBox_2.SelectedIndex == 0)
		{
			label_11.Enabled = false;
			label_17.Enabled = true;
			label_13.Enabled = true;
			numericUpDown_9.Enabled = false;
			numericUpDown_11.Enabled = true;
			numericUpDown_15.Enabled = true;
		}
		if (comboBox_2.SelectedIndex == 1)
		{
			label_11.Enabled = true;
			label_17.Enabled = false;
			label_13.Enabled = false;
			numericUpDown_9.Enabled = true;
			numericUpDown_11.Enabled = false;
			numericUpDown_15.Enabled = false;
		}
		if (comboBox_1.SelectedIndex == 0)
		{
			label_10.Enabled = false;
			label_15.Enabled = true;
			label_12.Enabled = true;
			numericUpDown_8.Enabled = false;
			numericUpDown_10.Enabled = true;
			numericUpDown_13.Enabled = true;
		}
		if (comboBox_1.SelectedIndex == 1)
		{
			label_10.Enabled = true;
			label_15.Enabled = false;
			label_12.Enabled = false;
			numericUpDown_8.Enabled = true;
			numericUpDown_10.Enabled = false;
			numericUpDown_13.Enabled = false;
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
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		Class76.smethod_467(this);
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
			Class76.smethod_624(this);
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
			SelectedTool = listBox_0.SelectedIndex;
			textBox_0.Text = buGeneral.GetToolExplanation(Tools[SelectedTool]);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (control.Name == comboBox_2.Name)
		{
			if (comboBox_2.SelectedIndex == 0)
			{
				label_11.Enabled = false;
				label_9.Enabled = false;
				label_17.Enabled = true;
				label_13.Enabled = true;
				numericUpDown_9.Enabled = false;
				numericUpDown_7.Enabled = false;
				numericUpDown_11.Enabled = true;
				numericUpDown_15.Enabled = true;
			}
			if (comboBox_2.SelectedIndex == 1)
			{
				label_11.Enabled = true;
				label_9.Enabled = true;
				label_17.Enabled = false;
				label_13.Enabled = false;
				numericUpDown_9.Enabled = true;
				numericUpDown_7.Enabled = true;
				numericUpDown_11.Enabled = false;
				numericUpDown_15.Enabled = false;
			}
		}
		if (control.Name == comboBox_1.Name)
		{
			if (comboBox_1.SelectedIndex == 0)
			{
				label_10.Enabled = false;
				label_8.Enabled = false;
				label_15.Enabled = true;
				label_12.Enabled = true;
				numericUpDown_8.Enabled = false;
				numericUpDown_6.Enabled = false;
				numericUpDown_10.Enabled = true;
				numericUpDown_13.Enabled = true;
			}
			if (comboBox_1.SelectedIndex == 1)
			{
				label_10.Enabled = true;
				label_8.Enabled = true;
				label_15.Enabled = false;
				label_12.Enabled = false;
				numericUpDown_8.Enabled = true;
				numericUpDown_6.Enabled = true;
				numericUpDown_10.Enabled = false;
				numericUpDown_13.Enabled = false;
			}
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
