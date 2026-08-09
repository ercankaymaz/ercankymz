using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_LaserStartOrder : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<LaserMaterialData> MaterialOrders = new List<LaserMaterialData>();

	public string pathCf2File = Application.StartupPath;

	public string fileCf2SettingsName = "";

	public string strRemoveCaption = "Do You Want to Remove Item";

	public int SelectedMaterialIndex = -1;

	public int DirType = 0;

	private bool bool_0 = false;

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public Button btn_down;

	public Button btn_up;

	internal ImageList imageList_1;

	internal CheckedListBox checkedListBox_0;

	public F_LaserStartOrder()
	{
		Class186.smethod_488(this);
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
		Class186.smethod_336(this);
		Class186.smethod_16(this);
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			btn_ok.Focus();
			for (int i = 0; i <= MaterialOrders.Count - 1; i++)
			{
				if (checkedListBox_0.GetItemCheckState(i) != CheckState.Checked)
				{
					MaterialOrders[i].Enable = false;
				}
				else
				{
					MaterialOrders[i].Enable = true;
				}
			}
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
		if (control.Name == btn_up.Name && ((checkedListBox_0.SelectedIndex > 0) & (MaterialOrders.Count >= 2)))
		{
			int selectedIndex = checkedListBox_0.SelectedIndex;
			LaserMaterialData item = new LaserMaterialData(MaterialOrders[checkedListBox_0.SelectedIndex]);
			MaterialOrders.RemoveAt(checkedListBox_0.SelectedIndex);
			MaterialOrders.Insert(checkedListBox_0.SelectedIndex - 1, item);
			selectedIndex--;
			Class186.smethod_16(this);
			checkedListBox_0.SelectedIndex = selectedIndex;
		}
		if (control.Name == btn_down.Name && checkedListBox_0.SelectedIndex < MaterialOrders.Count - 1)
		{
			int selectedIndex2 = checkedListBox_0.SelectedIndex;
			LaserMaterialData item2 = new LaserMaterialData(MaterialOrders[checkedListBox_0.SelectedIndex]);
			MaterialOrders.RemoveAt(selectedIndex2);
			MaterialOrders.Insert(selectedIndex2 + 1, item2);
			selectedIndex2++;
			Class186.smethod_16(this);
			checkedListBox_0.SelectedIndex = selectedIndex2;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
