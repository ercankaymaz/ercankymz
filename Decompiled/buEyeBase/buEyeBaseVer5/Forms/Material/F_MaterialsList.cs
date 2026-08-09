using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Material;

public class F_MaterialsList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public List<string> MaterialFiles = new List<string>();

	public string selectedMaterialName = "";

	public string pathString = Application.StartupPath;

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ListBox listBox_0;

	internal ImageList imageList_1;

	internal Panel panel_0;

	internal PictureBox pictureBox_0;

	public F_MaterialsList()
	{
		Class186.smethod_123(this);
		timer_0.Tick += timer_0_Tick;
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
		List<string> Files = new List<string>();
		buFile5.GetFilesInDirectory(pathString, ".png", ref Files);
		MaterialFiles.AddRange(Files);
		Files = new List<string>();
		buFile5.GetFilesInDirectory(pathString, ".jpg", ref Files);
		MaterialFiles.AddRange(Files);
		timer_0.Interval = 100;
		timer_0.Enabled = true;
		Class186.smethod_71(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		PropertiesForm.Inited = false;
		timer_0.Enabled = false;
		listBox_0.Items.Clear();
		int num = -1;
		for (int i = 0; i <= MaterialFiles.Count - 1; i++)
		{
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(MaterialFiles[i]);
			if (fileNameWithoutExtension.Length > 0)
			{
				listBox_0.Items.Add(fileNameWithoutExtension);
			}
			if (MaterialFiles[i] == selectedMaterialName)
			{
				num = i;
			}
		}
		PropertiesForm.Inited = true;
		if (num >= 0)
		{
			listBox_0.SelectedIndex = num;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		PropertiesForm.Inited = false;
		selectedMaterialName = MaterialFiles[listBox_0.SelectedIndex];
		Bitmap image = new Bitmap(selectedMaterialName);
		pictureBox_0.Image = image;
		PropertiesForm.Inited = true;
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
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
		if (control.Name == button_1.Name)
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
	}

	internal void method_3(object sender, FormClosingEventArgs e)
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
