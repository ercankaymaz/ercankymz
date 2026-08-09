using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_RouterOperations : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public camParameters5 varCamPars = null;

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public ToolBase5 ToolSelected = null;

	public string strRemoveCaption = "Do You Want to Remove Item";

	public int SelectedToolIndex = -1;

	internal IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal Label label_6;

	internal NumericUpDown numericUpDown_5;

	internal ImageList imageList_1;

	internal Label label_7;

	internal CheckBox checkBox_0;

	internal NumericUpDown numericUpDown_6;

	internal Label label_8;

	internal NumericUpDown numericUpDown_7;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal CheckBox checkBox_1;

	internal Label label_13;

	internal CheckBox checkBox_2;

	internal Label label_14;

	internal Label label_15;

	public Button btn_vacuumall;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal NumericUpDown numericUpDown_8;

	internal Label label_16;

	internal NumericUpDown numericUpDown_9;

	internal Label label_17;

	internal Label label_18;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_5;

	internal Label label_19;

	public F_RouterOperations()
	{
		Class186.smethod_50(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		PropertiesForm.Result = DialogResult.None;
		Class186.smethod_269(this);
		ToolSelected = null;
		listBox_0.Items.Clear();
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			listBox_0.Items.Add(Tools[i].Data.Name);
		}
		if ((SelectedToolIndex >= 0) & (Tools.Count > 0) & (SelectedToolIndex <= Tools.Count - 1))
		{
			listBox_0.SelectedIndex = SelectedToolIndex;
		}
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add("Level");
		comboBox_0.Items.Add("Region");
		ParametersToControl();
		PropertiesForm.Inited = true;
	}

	public void ParametersToControl()
	{
		if ((SelectedToolIndex >= 0) & (Tools.Count > 0) & (SelectedToolIndex <= Tools.Count - 1))
		{
			ToolSelected = new ToolBase5(Tools[SelectedToolIndex]);
		}
		if (varCamPars.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByLanes)
		{
			comboBox_0.SelectedIndex = 1;
		}
		else
		{
			comboBox_0.SelectedIndex = 0;
		}
		checkBox_5.Checked = varCamPars.Operations.SpiralMode;
		numericUpDown_7.Value = (decimal)varCamPars.Material.Thickness;
		numericUpDown_1.Value = (decimal)varCamPars.Operations.Depth;
		numericUpDown_6.Value = (decimal)varCamPars.Operations.BaseThickness;
		numericUpDown_8.Value = (decimal)varCamPars.Operations.Width;
		numericUpDown_9.Value = varCamPars.Steps.Count;
		checkBox_0.Checked = varCamPars.Options.Vacuum1;
		checkBox_2.Checked = varCamPars.Options.Vacuum2;
		checkBox_1.Checked = varCamPars.Options.Vacuum2;
		if (ToolSelected != null)
		{
			numericUpDown_4.Value = (decimal)ToolSelected.CamData.FeedSpeed;
			numericUpDown_3.Value = (decimal)ToolSelected.CamData.PlungeSpeed;
			numericUpDown_2.Value = (decimal)ToolSelected.CamData.SafeDistance;
			numericUpDown_5.Value = (decimal)ToolSelected.CamData.SpindleSpeed;
			numericUpDown_0.Value = ToolSelected.Data.No;
			checkBox_4.Checked = ToolSelected.CamData.Air;
			checkBox_3.Checked = ToolSelected.CamData.Dust;
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			Class186.smethod_424(this);
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
		if (control.Name == btn_cancel.Name)
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
		if (control.Name == btn_vacuumall.Name)
		{
			checkBox_0.Checked = true;
			checkBox_2.Checked = true;
			checkBox_1.Checked = true;
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
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

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			SelectedToolIndex = listBox_0.SelectedIndex;
			ToolSelected = new ToolBase5(Tools[SelectedToolIndex]);
			if (ToolSelected != null)
			{
				numericUpDown_4.Value = (decimal)ToolSelected.CamData.FeedSpeed;
				numericUpDown_3.Value = (decimal)ToolSelected.CamData.PlungeSpeed;
				numericUpDown_2.Value = (decimal)ToolSelected.CamData.SafeDistance;
				numericUpDown_5.Value = (decimal)ToolSelected.CamData.SpindleSpeed;
				numericUpDown_0.Value = ToolSelected.Data.No;
				checkBox_4.Checked = ToolSelected.CamData.Air;
				checkBox_3.Checked = ToolSelected.CamData.Dust;
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
