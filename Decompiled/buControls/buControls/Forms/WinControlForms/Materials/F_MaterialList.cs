using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Materials;

public class F_MaterialList : Form
{
	public static List<string> Captions = new List<string>();

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public DialogResult Result = DialogResult.None;

	public List<MaterialSkin> Materials = new List<MaterialSkin>();

	private bool bool_0 = false;

	internal IContainer icontainer_0 = null;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal Label label_0;

	internal buColorComboBox buColorComboBox_0;

	internal TextBox textBox_0;

	internal Label label_1;

	internal ListBox listBox_0;

	public Button btn_update;

	public Button btn_remove;

	public Button btn_add;

	public F_MaterialList()
	{
		Class76.smethod_712(this);
	}

	public void Init()
	{
		bool_0 = false;
		Result = DialogResult.None;
		listBox_0.Items.Clear();
		for (int i = 0; i <= Materials.Count - 1; i++)
		{
			listBox_0.Items.Add(Materials[i].Name);
		}
		bool_0 = true;
		if (listBox_0.Items.Count > 0)
		{
			listBox_0.SelectedIndex = 0;
		}
		Class76.smethod_250(this);
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_add.Name)
		{
			MaterialSkin materialSkin = new MaterialSkin();
			materialSkin.Name = textBox_0.Text;
			materialSkin.MaterialColor = buColorComboBox_0.Color;
			Materials.Add(materialSkin);
			listBox_0.Items.Add(materialSkin.Name);
		}
		if (control.Name == btn_remove.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && buString.MessageBoxQuestion(AppLanguage.SystemMessages[12]) == DialogResult.Yes)
		{
			Materials.RemoveAt(listBox_0.SelectedIndex);
			listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
		}
		if (control.Name == btn_update.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)) && buString.MessageBoxQuestion(AppLanguage.SystemMessages[13]) == DialogResult.Yes)
		{
			Materials[listBox_0.SelectedIndex].Name = textBox_0.Text;
			Materials[listBox_0.SelectedIndex].MaterialColor = buColorComboBox_0.Color;
			listBox_0.Items[listBox_0.SelectedIndex] = textBox_0.Text;
		}
		if (control.Name == btn_cancel.Name)
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
		if (control.Name == btn_ok.Name)
		{
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (bool_0 && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Materials.Count - 1)))
		{
			textBox_0.Text = Materials[listBox_0.SelectedIndex].Name;
			buColorComboBox_0.Color = Materials[listBox_0.SelectedIndex].MaterialColor;
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
