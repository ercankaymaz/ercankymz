using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.File;

public class F_DxfPropertiesList : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<Cf2FileProperties> Cf2Properties = new List<Cf2FileProperties>();

	public string pathCf2File = Application.StartupPath;

	public string fileCf2SettingsName = "";

	public string strRemoveCaption = "Do You Want to Remove Item";

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

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

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal CheckBox checkBox_0;

	internal TextBox textBox_0;

	internal ComboBox comboBox_0;

	internal CheckBox checkBox_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Label label_12;

	internal Label label_13;

	internal Label label_14;

	internal NumericUpDown numericUpDown_4;

	internal Label label_15;

	public F_DxfPropertiesList()
	{
		Class76.smethod_140(this);
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
		Class76.smethod_180(this);
		Class76.smethod_271(this);
		Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(cf2FileProperties.CodeType, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(cf2FileProperties.CodeType), ref comboBox_0);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		if (control.Name == btn_add.Name)
		{
			Cf2FileProperties cf2FileProperties_ = new Cf2FileProperties();
			Class76.smethod_15(ref cf2FileProperties_, this);
			Cf2Properties.Add(cf2FileProperties_);
			listBox_0.Items.Add(cf2FileProperties_.Explanation);
		}
		if (control.Name == btn_remove.Name && listBox_0.SelectedIndex >= 0 && buString.MessageBoxQuestion(strRemoveCaption + "  " + listBox_0.Text) == DialogResult.Yes)
		{
			Cf2Properties.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
		}
		if (control.Name == btn_copy.Name)
		{
			Cf2FileProperties cf2FileProperties = new Cf2FileProperties(Cf2Properties[listBox_0.SelectedIndex]);
			Cf2Properties.Add(cf2FileProperties);
			listBox_0.Items.Add(cf2FileProperties.Explanation);
		}
		if (control.Name == btn_up.Name && ((listBox_0.SelectedIndex > 0) & (Cf2Properties.Count >= 2)))
		{
			int selectedIndex = listBox_0.SelectedIndex;
			Cf2FileProperties item = new Cf2FileProperties(Cf2Properties[listBox_0.SelectedIndex]);
			Cf2Properties.RemoveAt(listBox_0.SelectedIndex);
			Cf2Properties.Insert(listBox_0.SelectedIndex - 1, item);
			selectedIndex--;
			Class76.smethod_271(this);
			listBox_0.SelectedIndex = selectedIndex;
		}
		if (control.Name == btn_down.Name && listBox_0.SelectedIndex < Cf2Properties.Count - 1)
		{
			int selectedIndex2 = listBox_0.SelectedIndex;
			Cf2FileProperties item2 = new Cf2FileProperties(Cf2Properties[listBox_0.SelectedIndex]);
			Cf2Properties.RemoveAt(selectedIndex2);
			Cf2Properties.Insert(selectedIndex2 + 1, item2);
			selectedIndex2++;
			Class76.smethod_271(this);
			listBox_0.SelectedIndex = selectedIndex2;
		}
		if (control.Name == btn_update.Name && PropertiesForm.Inited && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Cf2Properties.Count - 1)))
		{
			Cf2FileProperties cf2FileProperties_2 = new Cf2FileProperties();
			Class76.smethod_15(ref cf2FileProperties_2, this);
			Cf2Properties[listBox_0.SelectedIndex] = cf2FileProperties_2;
			listBox_0.Items[listBox_0.SelectedIndex] = Cf2Properties[listBox_0.SelectedIndex].Explanation;
		}
		if (control.Name == btn_save.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathCf2File;
			saveFileDialog.Filter = "CF2 Type Settings File (*.bucf2set)|*.bucf2set";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileCf2SettingsName = saveFileDialog.FileName;
				pathCf2File = buFile.GetPath(saveFileDialog.FileName);
				buFile.Cf2.SaveCf2Properties(saveFileDialog.FileName, Cf2Properties);
			}
		}
		if (!(control.Name == btn_open.Name))
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = pathCf2File;
		openFileDialog.Filter = "CF2 Type Settings File (*.bucf2set)|*.bucf2set";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			fileCf2SettingsName = openFileDialog.FileName;
			pathCf2File = buFile.GetPath(openFileDialog.FileName);
			buFile.Cf2.OpenCf2Properties(openFileDialog.FileName, ref Cf2Properties);
			listBox_0.Items.Clear();
			for (int i = 0; i <= Cf2Properties.Count - 1; i++)
			{
				listBox_0.Items.Add(Cf2Properties[i].Explanation);
			}
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
		if (PropertiesForm.Inited && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Cf2Properties.Count - 1)))
		{
			Cf2FileProperties props = new Cf2FileProperties(Cf2Properties[listBox_0.SelectedIndex]);
			ValueToControls(props);
		}
	}

	public void ValueToControls(Cf2FileProperties props)
	{
		numericUpDown_4.Value = props.ToolNo;
		numericUpDown_1.Value = (decimal)props.PtIndex;
		numericUpDown_0.Value = (decimal)props.PtRealValue;
		label_3.BackColor = props.MatchColor;
		numericUpDown_2.Value = (decimal)props.SelectedThickness;
		numericUpDown_3.Value = (decimal)props.Thickness;
		textBox_0.Text = props.Explanation;
		checkBox_0.Checked = props.Selectable;
		checkBox_1.Checked = props.Visible;
		label_2.BackColor = props.Color;
		label_1.BackColor = props.SelectedColor;
		comboBox_0.SelectedIndex = Convert.ToInt32(props.CodeType);
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_2.Name)
		{
			ColorDialogBox.ShowDialog(label_2.BackColor);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				label_2.BackColor = ColorDialogBox.Color;
				label_2.ForeColor = buImage.InvertColorNoGray(label_2.BackColor);
				label_2.Text = buImage.GetColorKnownName(label_2.BackColor);
			}
		}
		if (control.Name == label_1.Name)
		{
			ColorDialogBox.ShowDialog(label_2.BackColor);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				label_1.BackColor = ColorDialogBox.Color;
				label_1.ForeColor = buImage.InvertColorNoGray(label_1.BackColor);
				label_1.Text = buImage.GetColorKnownName(label_1.BackColor);
			}
		}
		if (control.Name == label_3.Name)
		{
			ColorDialogBox.ShowDialog(label_3.BackColor);
			if (ColorDialogBox.Result == DialogResult.OK)
			{
				label_3.BackColor = ColorDialogBox.Color;
				label_3.ForeColor = buImage.InvertColorNoGray(label_3.BackColor);
				label_3.Text = buImage.GetColorKnownName(label_3.BackColor);
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
