using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.Kinematic;

public class F_KinematicBasic : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public KinematicBase5 KinematicSettings = new KinematicBase5();

	public string LoadedKinematicFileName = "";

	public string LoadedKinematicFullFileName = "";

	public string PathKinematic = Application.StartupPath;

	internal IContainer icontainer_0 = null;

	public Button btn_ok;

	public Button btn_open;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal ComboBox comboBox_0;

	internal TextBox textBox_0;

	internal Panel panel_1;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_0;

	internal Label label_6;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_7;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_6;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal Label label_11;

	internal NumericUpDown numericUpDown_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal NumericUpDown numericUpDown_12;

	internal NumericUpDown numericUpDown_13;

	internal Label label_15;

	internal Label label_16;

	internal NumericUpDown numericUpDown_14;

	public Button btn_cancel;

	public Button btn_save;

	internal ImageList imageList_0;

	public F_KinematicBasic()
	{
		Class186.smethod_524(this);
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
		numericUpDown_5.Value = (decimal)KinematicSettings.OffsetXYZ.X;
		numericUpDown_3.Value = (decimal)KinematicSettings.OffsetXYZ.Y;
		numericUpDown_1.Value = (decimal)KinematicSettings.OffsetXYZ.Z;
		numericUpDown_4.Value = (decimal)KinematicSettings.OffsetABC.A;
		numericUpDown_2.Value = (decimal)KinematicSettings.OffsetABC.B;
		numericUpDown_0.Value = (decimal)KinematicSettings.OffsetABC.C;
		numericUpDown_14.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.X;
		numericUpDown_13.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.Y;
		numericUpDown_12.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.Z;
		numericUpDown_11.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.X;
		numericUpDown_10.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.Y;
		numericUpDown_9.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.Z;
		numericUpDown_8.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.X;
		numericUpDown_7.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.Y;
		numericUpDown_6.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.Z;
		textBox_0.Text = KinematicSettings.Name;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(KinematicSettings.Type, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(KinematicSettings.Type), ref comboBox_0);
		Class186.smethod_371(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
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

	internal void method_1(object sender, EventArgs e)
	{
		Class186.smethod_585(this);
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = PathKinematic;
		saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			buFile5.SaveKinematicFile(saveFileDialog.FileName, KinematicSettings);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Class186.smethod_585(this);
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

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = PathKinematic;
		openFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
		openFileDialog.Multiselect = false;
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			PathKinematic = buFile.GetPath(openFileDialog.FileName);
			buFile5.OpenKinemticFile(openFileDialog.FileName, ref KinematicSettings);
			LoadedKinematicFileName = buFile.getFileName(openFileDialog.FileName);
			LoadedKinematicFullFileName = openFileDialog.FileName;
			Init();
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
