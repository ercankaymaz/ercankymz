using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_TuftingImageList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<Picture> Images = new List<Picture>();

	public List<int> ImageIndex = new List<int>();

	private int int_0 = -1;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal ListView listView_0;

	internal PictureBox pictureBox_0;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	public F_TuftingImageList()
	{
		Class186.smethod_782(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		listView_0.HeaderStyle = ColumnHeaderStyle.None;
		listView_0.View = System.Windows.Forms.View.Details;
		listView_0.FullRowSelect = true;
		listView_0.Columns.Add("", -2);
		listView_0.Columns[0].Width = listView_0.Width - 5;
		for (int i = 0; i <= Images.Count - 1; i++)
		{
			string text = "Img" + (i + 1);
			if (((CustomData)Images[i].EntityData).infoString != null && ((CustomData)Images[i].EntityData).infoString.Length > 0)
			{
				string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(((CustomData)Images[i].EntityData).infoString);
				if (fileNameWithoutExtension.Length > 0)
				{
					text = fileNameWithoutExtension;
				}
			}
			ListViewItem value = new ListViewItem(text);
			listView_0.Items.Add(value);
		}
		if (listView_0.Items.Count > 0)
		{
			listView_0.Items[0].Selected = true;
		}
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetPart LoadLanguage";
		try
		{
			if (Captions.Count >= 33)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	public void Apply()
	{
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		if ((sender.GetType() == typeof(Control)) | (sender.GetType() == typeof(Button)))
		{
			control = (Control)sender;
			_ = control.Name;
		}
		if (sender.GetType() == typeof(ToolStripMenuItem))
		{
			_ = ((ToolStripMenuItem)sender).Name;
		}
		if (control.Name == button_0.Name)
		{
			Apply();
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

	internal void method_1(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && listView_0.SelectedItems.Count > 0 && ((listView_0.SelectedItems[0].Index >= 0) & (listView_0.SelectedItems[0].Index <= Images.Count - 1)))
		{
			PropertiesForm.Inited = false;
			int_0 = listView_0.SelectedItems[0].Index;
			using (MemoryStream stream = new MemoryStream(Images[int_0].Image))
			{
				pictureBox_0.Image = Image.FromStream(stream);
			}
			checkBox_0.Checked = Images[int_0].Selectable;
			checkBox_1.Checked = Images[int_0].Visible;
			PropertiesForm.Inited = true;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && int_0 >= 0)
		{
			Images[int_0].Visible = checkBox_1.Checked;
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && int_0 >= 0)
		{
			Images[int_0].Selectable = checkBox_0.Checked;
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
