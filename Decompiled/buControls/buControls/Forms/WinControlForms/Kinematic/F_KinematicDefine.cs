using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Kinematic;

public class F_KinematicDefine : Form
{
	public static List<string> Captions = new List<string>();

	public KinematicBase KinematicSettings = new KinematicBase();

	public DialogResult Result = DialogResult.None;

	public string LoadedKinematicFileName = "";

	public string PathKinematic = Application.StartupPath;

	public List<eEntities> CreatedEntities = new List<eEntities>();

	public bool SelectEntities = false;

	public bool SaveWithOkButton = false;

	[CompilerGenerated]
	private CreatMachineEventHandler creatMachineEventHandler_0;

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_save;

	internal Label label_0;

	internal TextBox textBox_0;

	internal ComboBox comboBox_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_4;

	internal NumericUpDown numericUpDown_6;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_7;

	internal NumericUpDown numericUpDown_8;

	internal Label label_8;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_9;

	internal NumericUpDown numericUpDown_10;

	internal Label label_9;

	internal NumericUpDown numericUpDown_11;

	internal NumericUpDown numericUpDown_12;

	internal NumericUpDown numericUpDown_13;

	internal Label label_10;

	internal NumericUpDown numericUpDown_14;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal NumericUpDown numericUpDown_15;

	internal NumericUpDown numericUpDown_16;

	internal Label label_14;

	internal Label label_15;

	internal NumericUpDown numericUpDown_17;

	internal Panel panel_2;

	internal NumericUpDown numericUpDown_18;

	internal NumericUpDown numericUpDown_19;

	internal Label label_16;

	internal NumericUpDown numericUpDown_20;

	internal NumericUpDown numericUpDown_21;

	internal NumericUpDown numericUpDown_22;

	internal Label label_17;

	internal NumericUpDown numericUpDown_23;

	internal Label label_18;

	internal Label label_19;

	internal Label label_20;

	internal NumericUpDown numericUpDown_24;

	internal NumericUpDown numericUpDown_25;

	internal Label label_21;

	internal Label label_22;

	internal NumericUpDown numericUpDown_26;

	internal Panel panel_3;

	internal Label label_23;

	internal Label label_24;

	internal Label label_25;

	internal NumericUpDown numericUpDown_27;

	internal Label label_26;

	internal NumericUpDown numericUpDown_28;

	internal NumericUpDown numericUpDown_29;

	internal Label label_27;

	internal NumericUpDown numericUpDown_30;

	internal NumericUpDown numericUpDown_31;

	internal Label label_28;

	internal Label label_29;

	internal NumericUpDown numericUpDown_32;

	internal PictureBox pictureBox_0;

	internal Panel panel_4;

	internal Label label_30;

	internal Panel panel_5;

	public Button btn_selectentities;

	internal Label label_31;

	internal ListBox listBox_0;

	internal Label label_32;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal Label label_33;

	internal Label label_34;

	internal buColorComboBox buColorComboBox_0;

	internal Label label_35;

	internal TextBox textBox_1;

	public Button btn_open;

	public Button btn_ok;

	internal Button button_0;

	internal Button button_1;

	public event CreatMachineEventHandler CreatMachine
	{
		[CompilerGenerated]
		add
		{
			CreatMachineEventHandler creatMachineEventHandler = creatMachineEventHandler_0;
			CreatMachineEventHandler creatMachineEventHandler2;
			do
			{
				creatMachineEventHandler2 = creatMachineEventHandler;
				CreatMachineEventHandler value2 = (CreatMachineEventHandler)Delegate.Combine(creatMachineEventHandler2, value);
				creatMachineEventHandler = Interlocked.CompareExchange(ref creatMachineEventHandler_0, value2, creatMachineEventHandler2);
			}
			while ((object)creatMachineEventHandler != creatMachineEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CreatMachineEventHandler creatMachineEventHandler = creatMachineEventHandler_0;
			CreatMachineEventHandler creatMachineEventHandler2;
			do
			{
				creatMachineEventHandler2 = creatMachineEventHandler;
				CreatMachineEventHandler value2 = (CreatMachineEventHandler)Delegate.Remove(creatMachineEventHandler2, value);
				creatMachineEventHandler = Interlocked.CompareExchange(ref creatMachineEventHandler_0, value2, creatMachineEventHandler2);
			}
			while ((object)creatMachineEventHandler != creatMachineEventHandler2);
		}
	}

	public F_KinematicDefine()
	{
		Class76.smethod_152(this);
	}

	public void Init()
	{
		numericUpDown_32.Value = (decimal)KinematicSettings.OffsetXYZ.X;
		numericUpDown_30.Value = (decimal)KinematicSettings.OffsetXYZ.Y;
		numericUpDown_28.Value = (decimal)KinematicSettings.OffsetXYZ.Z;
		numericUpDown_31.Value = (decimal)KinematicSettings.OffsetABC.A;
		numericUpDown_29.Value = (decimal)KinematicSettings.OffsetABC.B;
		numericUpDown_27.Value = (decimal)KinematicSettings.OffsetABC.C;
		numericUpDown_17.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.X;
		numericUpDown_16.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.Y;
		numericUpDown_15.Value = (decimal)KinematicSettings.RotateCenterOffsetOfA.Z;
		numericUpDown_14.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.X;
		numericUpDown_13.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.Y;
		numericUpDown_12.Value = (decimal)KinematicSettings.RotateCenterOffsetOfB.Z;
		numericUpDown_11.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.X;
		numericUpDown_10.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.Y;
		numericUpDown_9.Value = (decimal)KinematicSettings.RotateCenterOffsetOfC.Z;
		textBox_0.Text = KinematicSettings.Name;
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(KinematicSettings.Type, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(KinematicSettings.Type), ref comboBox_0);
		listBox_0.Items.Clear();
		for (int i = 0; i <= KinematicSettings.Items.Count - 1; i++)
		{
			listBox_0.Items.Add(KinematicSettings.Items[i]);
		}
		if (listBox_0.Items.Count > 0)
		{
			listBox_0.SelectedIndex = 0;
		}
		Class76.smethod_457(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class76.smethod_98(this);
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = PathKinematic;
		saveFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			buFile.SaveKinematicFile(saveFileDialog.FileName, KinematicSettings);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Class76.smethod_98(this);
		if (SaveWithOkButton)
		{
			FileInfo fileInfo = new FileInfo(LoadedKinematicFileName);
			if (fileInfo.Exists)
			{
				buFile.SaveKinematicFile(LoadedKinematicFileName, KinematicSettings);
			}
		}
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_3(object sender, EventArgs e)
	{
		Class76.smethod_98(this);
		Result = DialogResult.OK;
		SelectEntities = true;
		Dispose();
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (listBox_0.SelectedItem.GetType() == typeof(KinematicItem))
		{
			checkBox_5.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.X;
			checkBox_4.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.Y;
			checkBox_3.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.Z;
			checkBox_2.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.A;
			checkBox_1.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.B;
			checkBox_0.Checked = ((KinematicItem)listBox_0.SelectedItem).Axis.C;
			buColorComboBox_0.Color = ((KinematicItem)listBox_0.SelectedItem).Color;
			textBox_1.Text = ((KinematicItem)listBox_0.SelectedItem).PartName;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = PathKinematic;
		openFileDialog.Filter = "Kinematic File (*.bukinematic)|*.bukinematic";
		openFileDialog.Multiselect = false;
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			PathKinematic = buFile.GetPath(openFileDialog.FileName);
			buFile.OpenKinemticFile(openFileDialog.FileName, ref KinematicSettings);
			LoadedKinematicFileName = buFile.getFileName(openFileDialog.FileName);
			Init();
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		listBox_0.Items.Clear();
		KinematicSettings.Items.Clear();
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (creatMachineEventHandler_0 != null && KinematicSettings.Type == KinemeticType.CartezianXYZ_WristAC_5Axis)
		{
			buControlCoreClass.cVector.CreatMachine(KinematicSettings, ref CreatedEntities);
			creatMachineEventHandler_0(CreatedEntities, KinematicSettings);
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
