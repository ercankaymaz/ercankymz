using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_LaserMaterial : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<LaserMaterial> Materials = new List<LaserMaterial>();

	public List<Cf2FileProperties> Cf2Properties = new List<Cf2FileProperties>();

	public string pathMaterialFile = Application.StartupPath;

	public string strRemoveCaption = "Do You Want to Remove Item";

	public int SelectedMaterialIndex = -1;

	public int DirType = 0;

	public bool EditMode = false;

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_add;

	public Button btn_remove;

	public Button btn_down;

	public Button btn_up;

	public Button btn_copy;

	public Button btn_save;

	public Button btn_open;

	public Button btn_update;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_1;

	internal Label label_4;

	internal ComboBox comboBox_0;

	internal Label label_5;

	internal NumericUpDown numericUpDown_2;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal NumericUpDown numericUpDown_4;

	internal Label label_8;

	internal NumericUpDown numericUpDown_5;

	internal TextBox textBox_0;

	internal Label label_9;

	public Button btn_orderremove;

	public Button btn_orderadd;

	internal ListBox listBox_1;

	internal Panel panel_1;

	public Button btn_namecancel;

	public Button btn_nameok;

	internal Panel panel_2;

	public Button btn_codetypecancel;

	public Button btn_codetypeok;

	internal Label label_10;

	internal ComboBox comboBox_1;

	internal Label label_11;

	internal ComboBox comboBox_2;

	internal TextBox textBox_1;

	internal Label label_12;

	internal ImageList imageList_1;

	internal Label label_13;

	internal CheckBox checkBox_0;

	internal Label label_14;

	internal CheckBox checkBox_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	public Button btn_dirpower;

	public Button btn_dirfeed;

	public Button btn_dirfocus;

	internal Label label_15;

	internal Label label_16;

	internal Label label_17;

	internal Panel panel_3;

	internal Label label_18;

	internal NumericUpDown numericUpDown_6;

	internal Label label_19;

	internal NumericUpDown numericUpDown_7;

	internal Label label_20;

	internal NumericUpDown numericUpDown_8;

	internal Label label_21;

	internal NumericUpDown numericUpDown_9;

	public Button btn_dircancel;

	public Button btn_dirok;

	internal Label label_22;

	public Button btn_edit;

	public Button btn_ordermoveup;

	public Button btn_ordermovedown;

	internal NumericUpDown numericUpDown_10;

	internal Label label_23;

	internal NumericUpDown numericUpDown_11;

	internal Label label_24;

	internal NumericUpDown numericUpDown_12;

	internal Label label_25;

	public F_LaserMaterial()
	{
		Class186.smethod_232(this);
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
		Class186.smethod_677(this);
		Class186.smethod_721(this);
		LaserMaterialData laserMaterialData = new LaserMaterialData();
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(laserMaterialData.Type, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(laserMaterialData.Type), ref comboBox_0);
		comboBox_1.Items.Clear();
		comboBox_2.Items.Clear();
		for (int i = 0; i <= Cf2Properties.Count - 1; i++)
		{
			comboBox_1.Items.Add("Pt: " + Cf2Properties[i].PtIndex + " - " + Cf2Properties[i].CodeType);
			comboBox_2.Items.Add("Pt: " + Cf2Properties[i].PtIndex + " - " + Cf2Properties[i].CodeType);
		}
		if (comboBox_1.Items.Count > 0)
		{
			comboBox_1.SelectedIndex = 0;
			comboBox_2.SelectedIndex = 0;
		}
		if ((SelectedMaterialIndex >= 0) & (Materials.Count > 0) & (SelectedMaterialIndex <= Materials.Count - 1))
		{
			listBox_0.SelectedIndex = SelectedMaterialIndex;
		}
		panel_2.Visible = false;
		panel_1.Visible = false;
		panel_3.Visible = false;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		if (Materials.Count <= 0)
		{
			return;
		}
		Class186.smethod_505(listBox_0.SelectedIndex, this);
		if (listBox_1.Items.Count <= 0)
		{
			return;
		}
		for (int j = 0; j <= Cf2Properties.Count - 1; j++)
		{
			for (int k = 0; k <= Materials[listBox_0.SelectedIndex].Orders.Count - 1; k++)
			{
				if ((Materials[listBox_0.SelectedIndex].Orders[k].PtRealValue == Cf2Properties[j].PtRealValue) & (Materials[listBox_0.SelectedIndex].Orders[k].CodeType == Cf2Properties[j].CodeType))
				{
					comboBox_1.SelectedIndex = j;
					comboBox_2.SelectedIndex = j;
				}
			}
		}
		listBox_1.SelectedIndex = 0;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
			SelectedMaterialIndex = listBox_0.SelectedIndex;
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
		if (control.Name == btn_dirfeed.Name)
		{
			DirType = 1;
			label_18.Text = "Feed Direction";
			if (((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= Materials[listBox_0.SelectedIndex].Orders.Count - 1)))
			{
				numericUpDown_8.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXMinus;
				numericUpDown_7.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXPlus;
				numericUpDown_6.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYMinus;
				numericUpDown_9.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYPlus;
				numericUpDown_11.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXY;
				panel_3.Visible = true;
			}
		}
		if (control.Name == btn_dirfocus.Name)
		{
			DirType = 2;
			label_18.Text = "Focus Direction";
			if (((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= Materials[listBox_0.SelectedIndex].Orders.Count - 1)))
			{
				numericUpDown_8.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXMinus;
				numericUpDown_7.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXPlus;
				numericUpDown_6.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYMinus;
				numericUpDown_9.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYPlus;
				numericUpDown_11.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXY;
				panel_3.Visible = true;
			}
		}
		if (control.Name == btn_dirpower.Name)
		{
			DirType = 3;
			label_18.Text = "Power Direction";
			if (((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= Materials[listBox_0.SelectedIndex].Orders.Count - 1)))
			{
				numericUpDown_8.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXMinus;
				numericUpDown_7.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXPlus;
				numericUpDown_6.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYMinus;
				numericUpDown_9.Value = (decimal)Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYPlus;
				panel_3.Visible = true;
			}
		}
		if (control.Name == btn_dircancel.Name)
		{
			panel_3.Visible = false;
		}
		if (control.Name == btn_dirok.Name)
		{
			if (DirType == 1)
			{
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXMinus = (double)numericUpDown_8.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXPlus = (double)numericUpDown_7.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYMinus = (double)numericUpDown_6.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYPlus = (double)numericUpDown_9.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXY = (double)numericUpDown_11.Value;
			}
			if (DirType == 2)
			{
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXMinus = (double)numericUpDown_8.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXPlus = (double)numericUpDown_7.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYMinus = (double)numericUpDown_6.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYPlus = (double)numericUpDown_9.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXY = (double)numericUpDown_11.Value;
			}
			if (DirType == 3)
			{
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXMinus = (double)numericUpDown_8.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXPlus = (double)numericUpDown_7.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYMinus = (double)numericUpDown_6.Value;
				Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYPlus = (double)numericUpDown_9.Value;
			}
			panel_3.Visible = false;
		}
		if (control.Name == btn_edit.Name)
		{
			textBox_0.Text = Materials[listBox_0.SelectedIndex].Name;
			panel_1.Visible = true;
			EditMode = true;
		}
		if (control.Name == btn_add.Name)
		{
			panel_1.Visible = true;
			EditMode = false;
		}
		if (control.Name == btn_remove.Name && listBox_0.SelectedIndex >= 0 && buString.MessageBoxQuestion(strRemoveCaption + "  " + listBox_0.Text) == DialogResult.Yes)
		{
			Materials.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
		}
		if (control.Name == btn_nameok.Name)
		{
			if (EditMode)
			{
				Materials[listBox_0.SelectedIndex].Name = textBox_0.Text;
				Class186.smethod_721(this);
			}
			else
			{
				LaserMaterial laserMaterial = new LaserMaterial();
				laserMaterial.Name = textBox_0.Text;
				Materials.Add(laserMaterial);
				listBox_0.Items.Add(laserMaterial.Name);
				listBox_0.SelectedIndex = listBox_0.Items.Count - 1;
			}
			panel_1.Visible = false;
		}
		if (control.Name == btn_namecancel.Name)
		{
			panel_1.Visible = false;
			EditMode = false;
		}
		if (control.Name == btn_copy.Name)
		{
			LaserMaterial laserMaterial2 = new LaserMaterial(Materials[listBox_0.SelectedIndex]);
			laserMaterial2.Name += " - Copy";
			Materials.Add(laserMaterial2);
			listBox_0.Items.Add(laserMaterial2.Name);
		}
		if (control.Name == btn_up.Name && ((listBox_0.SelectedIndex > 0) & (Materials.Count >= 2)))
		{
			int selectedIndex = listBox_0.SelectedIndex;
			LaserMaterial item = new LaserMaterial(Materials[listBox_0.SelectedIndex]);
			Materials.RemoveAt(listBox_0.SelectedIndex);
			Materials.Insert(listBox_0.SelectedIndex - 1, item);
			selectedIndex--;
			Class186.smethod_721(this);
			listBox_0.SelectedIndex = selectedIndex;
		}
		if (control.Name == btn_down.Name && listBox_0.SelectedIndex < Materials.Count - 1)
		{
			int selectedIndex2 = listBox_0.SelectedIndex;
			LaserMaterial item2 = new LaserMaterial(Materials[listBox_0.SelectedIndex]);
			Materials.RemoveAt(selectedIndex2);
			Materials.Insert(selectedIndex2 + 1, item2);
			selectedIndex2++;
			Class186.smethod_721(this);
			listBox_0.SelectedIndex = selectedIndex2;
		}
		if (control.Name == btn_orderadd.Name)
		{
			panel_2.Visible = true;
		}
		if (control.Name == btn_orderremove.Name && listBox_1.SelectedIndex >= 0 && buString.MessageBoxQuestion(strRemoveCaption + "  " + listBox_1.Text) == DialogResult.Yes)
		{
			Materials[listBox_0.SelectedIndex].Orders.RemoveAt(listBox_1.SelectedIndex);
			listBox_1.Items.RemoveAt(listBox_1.SelectedIndex);
		}
		if (control.Name == btn_codetypeok.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)))
		{
			LaserMaterialData laserMaterialData = new LaserMaterialData();
			laserMaterialData.DefineationName = comboBox_0.Text;
			if (Cf2Properties.Count > 0)
			{
				laserMaterialData.PtRealValue = Cf2Properties[comboBox_1.SelectedIndex].PtRealValue;
				laserMaterialData.CodeType = Cf2Properties[comboBox_1.SelectedIndex].CodeType;
			}
			laserMaterialData.ApplyAll = checkBox_0.Checked;
			Materials[listBox_0.SelectedIndex].Orders.Add(laserMaterialData);
			Class186.smethod_505(listBox_0.SelectedIndex, this);
			ValueToControls(laserMaterialData);
			panel_2.Visible = false;
		}
		if (control.Name == btn_codetypecancel.Name)
		{
			panel_2.Visible = false;
		}
		if (control.Name == btn_ordermoveup.Name && ((listBox_1.SelectedIndex > 0) & (Materials[listBox_0.SelectedIndex].Orders.Count >= 2)))
		{
			int selectedIndex3 = listBox_1.SelectedIndex;
			LaserMaterialData item3 = new LaserMaterialData(Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex]);
			Materials[listBox_0.SelectedIndex].Orders.RemoveAt(listBox_1.SelectedIndex);
			Materials[listBox_0.SelectedIndex].Orders.Insert(listBox_1.SelectedIndex - 1, item3);
			selectedIndex3--;
			Class186.smethod_505(listBox_0.SelectedIndex, this);
			listBox_1.SelectedIndex = selectedIndex3;
		}
		if (control.Name == btn_ordermovedown.Name && listBox_1.SelectedIndex < Materials[listBox_0.SelectedIndex].Orders.Count - 1)
		{
			int selectedIndex4 = listBox_1.SelectedIndex;
			LaserMaterialData item4 = new LaserMaterialData(Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex]);
			Materials[listBox_0.SelectedIndex].Orders.RemoveAt(selectedIndex4);
			Materials[listBox_0.SelectedIndex].Orders.Insert(selectedIndex4 + 1, item4);
			selectedIndex4++;
			Class186.smethod_505(listBox_0.SelectedIndex, this);
			listBox_1.SelectedIndex = selectedIndex4;
		}
		if (control.Name == btn_update.Name && PropertiesForm.Inited && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= Materials[listBox_0.SelectedIndex].Orders.Count - 1)))
		{
			LaserMaterialData laserMaterialData_ = new LaserMaterialData(Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex]);
			Class186.smethod_243(this, ref laserMaterialData_);
			Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex] = laserMaterialData_;
		}
		if (control.Name == btn_save.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathMaterialFile;
			saveFileDialog.Filter = "Laser MaterialsSettings File (*.bulasmat)|*.bulasmat";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				pathMaterialFile = buFile.GetPath(saveFileDialog.FileName);
				ArrayList arrayList = new ArrayList();
				arrayList.Add("<LaserMaterials>");
				for (int i = 0; i <= Materials.Count - 1; i++)
				{
					arrayList.Add("  <LaserMaterial>");
					arrayList.Add("    " + Materials[i].Name);
					for (int j = 0; j <= Materials[i].Orders.Count - 1; j++)
					{
						arrayList.AddRange(Materials[i].Orders[j].ToDefAll("", 4, SerilizationMode.MultiLine));
					}
					arrayList.Add("  </LaserMaterial>");
				}
				arrayList.Add("</LaserMaterials>");
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
			}
		}
		if (!(control.Name == btn_open.Name))
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = pathMaterialFile;
		openFileDialog.Filter = "Laser MaterialsSettings File (*.bulasmat)|*.bulasmat";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		Materials.Clear();
		ArrayList StringList = new ArrayList();
		buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
		List<List<string>> CalcList = new List<List<string>>();
		buString.ListToSpecificList("<LaserMaterial>", "</LaserMaterial>", AddStartEndKey: true, StringList, ref CalcList);
		if (CalcList.Count <= 0)
		{
			return;
		}
		for (int k = 0; k <= CalcList.Count - 1; k++)
		{
			LaserMaterial laserMaterial3 = new LaserMaterial();
			laserMaterial3.Name = CalcList[k][1];
			buSerilization.Decode(CalcList[k], "", SerilizationMode.MultiLine, laserMaterial3);
			List<List<string>> CalcList2 = new List<List<string>>();
			buString.ListToSpecificList("<LaserMaterialData>", "</LaserMaterialData>", AddStartEndKey: true, CalcList[k], ref CalcList2);
			for (int l = 0; l <= CalcList2.Count - 1; l++)
			{
				LaserMaterialData laserMaterialData2 = new LaserMaterialData();
				buSerilization.Decode(CalcList2[l], "", SerilizationMode.MultiLine, laserMaterialData2);
				laserMaterial3.Orders.Add(laserMaterialData2);
			}
			Materials.Add(laserMaterial3);
		}
	}

	public void ChangeMinusPlusData(ref LaserMaterialData data)
	{
		data.FeedXMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXMinus;
		data.FeedXPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXPlus;
		data.FeedYMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYMinus;
		data.FeedYPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedYPlus;
		data.FeedXY = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FeedXY;
		data.PowerXMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXMinus;
		data.PowerXPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerXPlus;
		data.PowerYMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYMinus;
		data.PowerYPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].PowerYPlus;
		data.FocusXMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXMinus;
		data.FocusXPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXPlus;
		data.FocusYMinus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYMinus;
		data.FocusYPlus = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusYPlus;
		data.FocusXY = Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex].FocusXY;
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
		if (PropertiesForm.Inited && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)))
		{
			Class186.smethod_505(listBox_0.SelectedIndex, this);
			if (listBox_1.Items.Count > 0)
			{
				listBox_1.SelectedIndex = 0;
			}
		}
	}

	public void ValueToControls(LaserMaterialData props)
	{
		numericUpDown_12.Value = (decimal)props.Height;
		numericUpDown_1.Value = (decimal)props.Acceleration;
		numericUpDown_10.Value = (decimal)props.Jerk;
		numericUpDown_0.Value = (decimal)props.CuttingPower;
		numericUpDown_2.Value = (decimal)props.EndPower;
		textBox_1.Text = props.DefineationName;
		numericUpDown_4.Value = (decimal)props.PowerDelayTime;
		numericUpDown_5.Value = (decimal)props.PowerStopTime;
		numericUpDown_3.Value = (decimal)props.StartPower;
		checkBox_1.Checked = props.ApplyAll;
		if (props.LaserSelect == LaserSelection.Laser1)
		{
			radioButton_2.Checked = true;
		}
		if (props.LaserSelect == LaserSelection.Laser2)
		{
			radioButton_1.Checked = true;
		}
		if (props.LaserSelect == LaserSelection.Laser3)
		{
			radioButton_0.Checked = true;
		}
		for (int i = 0; i <= Cf2Properties.Count - 1; i++)
		{
			if ((props.PtRealValue == Cf2Properties[i].PtRealValue) & (props.CodeType == Cf2Properties[i].CodeType))
			{
				comboBox_2.SelectedIndex = i;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= Materials[listBox_0.SelectedIndex].Orders.Count - 1)))
		{
			LaserMaterialData props = new LaserMaterialData(Materials[listBox_0.SelectedIndex].Orders[listBox_1.SelectedIndex]);
			ValueToControls(props);
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
