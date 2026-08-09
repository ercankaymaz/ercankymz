using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_ProducerSettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public JewelVar ParJewel = new JewelVar();

	public DialogResult Result = DialogResult.None;

	public bool ShowAxisButton = true;

	public bool ShowCncButton = true;

	private IContainer icontainer_0 = null;

	internal ComboBox comboBox_0;

	internal Label label_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Button button_13;

	internal Button button_14;

	internal Button button_15;

	internal Button button_16;

	internal Button button_17;

	public F_ProducerSettings()
	{
		Class76.smethod_709(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Init()
	{
		List<string> list = new List<string>();
		list.AddRange(buFile.FindFilesOneDirectory(ParJewel.PostPath, "bupost", FileFilterType.FileWithoutExtension));
		comboBox_0.Items.Clear();
		int selectedIndex = 0;
		for (int i = 0; i <= list.Count - 1; i++)
		{
			comboBox_0.Items.Add(list[i]);
			if (list[i].Trim() == ParJewel.PostName.Trim())
			{
				selectedIndex = i;
			}
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = selectedIndex;
		}
		button_7.Visible = ShowCncButton;
		button_8.Visible = ShowAxisButton;
		button_9.Visible = ShowAxisButton;
		button_10.Visible = ShowAxisButton;
		button_13.Visible = ShowAxisButton;
		button_12.Visible = ShowAxisButton;
		button_11.Visible = ShowAxisButton;
		button_16.Visible = ShowAxisButton;
		button_15.Visible = ShowAxisButton;
		button_14.Visible = ShowAxisButton;
		Class76.smethod_292(this);
		Result = DialogResult.None;
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex >= 0)
		{
			FileInfo fileInfo = new FileInfo(ParJewel.PostPath + "\\" + comboBox_0.Text + ".bupost");
			if (fileInfo.Exists)
			{
				ParJewel.PostName = comboBox_0.Text;
			}
		}
		Result = DialogResult.OK;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Material";
		f_ClassViewerDialog.Value = ParJewel.JewelMaterialProp;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.JewelMaterialProp = new jewelMaterial((jewelMaterial)f_ClassViewerDialog.Value);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Tangent";
		f_ClassViewerDialog.Value = ParJewel.JewelTangentProp;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.JewelTangentProp = new jewelTangent((jewelTangent)f_ClassViewerDialog.Value);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Scale";
		f_ClassViewerDialog.Value = ParJewel.JewelScaleProp;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.JewelScaleProp = new jewelScale((jewelScale)f_ClassViewerDialog.Value);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "Cam Rules";
		f_ClassViewerDialog.Value = ParJewel.JewelCamProp;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.JewelCamProp = new jewelCam((jewelCam)f_ClassViewerDialog.Value);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "General";
		f_ClassViewerDialog.Value = ParJewel.Settings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.Settings = new jewelSettings((jewelSettings)f_ClassViewerDialog.Value);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.Text = "CNC";
		f_ClassViewerDialog.Value = ParJewel.CNCSettings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.ValuePersentage = 30.0;
		f_ClassViewerDialog.DecimalPlace = 4;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.CNCSettings = new CodesysCNCSets((CodesysCNCSets)f_ClassViewerDialog.Value);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.ValuePersentage = 30.0;
		f_ClassViewerDialog.DecimalPlace = 4;
		if (control.Name == button_8.Name)
		{
			f_ClassViewerDialog.Text = "Axis X";
			f_ClassViewerDialog.Value = ParJewel.AxisXCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisXCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_9.Name)
		{
			f_ClassViewerDialog.Text = "Axis Y";
			f_ClassViewerDialog.Value = ParJewel.AxisYCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisYCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_10.Name)
		{
			f_ClassViewerDialog.Text = "Axis Z";
			f_ClassViewerDialog.Value = ParJewel.AxisZCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisZCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_13.Name)
		{
			f_ClassViewerDialog.Text = "Axis A";
			f_ClassViewerDialog.Value = ParJewel.AxisACncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisACncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_12.Name)
		{
			f_ClassViewerDialog.Text = "Axis B";
			f_ClassViewerDialog.Value = ParJewel.AxisBCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisBCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_11.Name)
		{
			f_ClassViewerDialog.Text = "Axis C";
			f_ClassViewerDialog.Value = ParJewel.AxisCCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisCCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_16.Name)
		{
			f_ClassViewerDialog.Text = "Axis U";
			f_ClassViewerDialog.Value = ParJewel.AxisUCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisUCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_15.Name)
		{
			f_ClassViewerDialog.Text = "Axis V";
			f_ClassViewerDialog.Value = ParJewel.AxisVCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisVCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
		if (control.Name == button_14.Name)
		{
			f_ClassViewerDialog.Text = "Axis W";
			f_ClassViewerDialog.Value = ParJewel.AxisWCncSetting;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog(this);
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParJewel.AxisWCncSetting = new CodesysAxCnc((CodesysAxCnc)f_ClassViewerDialog.Value);
			}
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
		F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.ValuePersentage = 30.0;
		f_ClassViewerDialog.DecimalPlace = 4;
		f_ClassViewerDialog.Text = "Limits";
		f_ClassViewerDialog.Value = ParJewel.Limits;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog(this);
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			ParJewel.Limits = new jewelLimits((jewelLimits)f_ClassViewerDialog.Value);
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
