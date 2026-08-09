using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.File;

public class F_AddImageFromFile : Form
{
	[CompilerGenerated]
	internal OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	public FormProperties PropertiesForm = new FormProperties();

	public Image refImage = null;

	public string Path = Application.StartupPath;

	public string FileName = Application.StartupPath;

	public bool KeepRatio = true;

	public bool MoveEntities = true;

	public bool MoveReverse = false;

	public MinMaxType MoveRef = MinMaxType.Min;

	public List<string> ExtensionList = new List<string>();

	private List<string> list_0 = new List<string>();

	private int int_0 = -1;

	private int int_1 = -1;

	private string string_0 = "";

	private bool bool_0 = false;

	internal List<string> list_1 = new List<string>();

	private System.Windows.Forms.Timer timer_0 = null;

	private IContainer icontainer_0 = null;

	internal TextBox textBox_0;

	internal Label label_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Panel panel_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal NumericUpDown numericUpDown_0;

	internal Button button_7;

	internal Label label_2;

	internal Label label_3;

	internal TextBox textBox_1;

	internal Button button_8;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	public DataGridView grid_files;

	internal Panel panel_2;

	internal CheckBox checkBox_0;

	internal PictureBox pictureBox_0;

	public event OkCommandWithTwoDataEventHandler ReadFile
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public F_AddImageFromFile()
	{
		Class186.smethod_102(this);
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
		checkBox_0.Checked = KeepRatio;
		LoadLanguage();
		grid_files.AllowUserToAddRows = false;
		grid_files.AllowUserToDeleteRows = false;
		grid_files.AllowUserToResizeRows = false;
		grid_files.RowHeadersVisible = false;
		grid_files.Columns.Clear();
		grid_files.Rows.Clear();
		grid_files.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 60;
		dataGridViewColumn.HeaderText = "No";
		dataGridViewColumn.Name = "No";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		grid_files.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 250;
		dataGridViewColumn2.HeaderText = "FileName";
		dataGridViewColumn2.Name = "FileName";
		dataGridViewColumn2.ReadOnly = true;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		grid_files.Columns.Add(dataGridViewColumn2);
		bool_0 = false;
		if (ExtensionList.Count == 0)
		{
			ExtensionList.Add(".png");
			ExtensionList.Add(".jpeg");
			ExtensionList.Add(".jpg");
			ExtensionList.Add(".bmp");
		}
		list_1 = new List<string>();
		for (int i = 0; i <= ExtensionList.Count - 1; i++)
		{
			List<string> Files = new List<string>();
			buFile.GetFilesInDirectory(Path, ExtensionList[i], ref Files);
			for (int j = 0; j <= Files.Count - 1; j++)
			{
				list_1.Add(Files[j]);
			}
		}
		Class186.smethod_290(this);
		if (timer_0 == null)
		{
			timer_0 = new System.Windows.Forms.Timer();
			timer_0.Tick += Init_Tick;
			timer_0.Interval = 100;
		}
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		if (list_1.Count > 0)
		{
			grid_files.CurrentCell = grid_files.Rows[0].Cells[0];
			method_5(null, new DataGridViewCellEventArgs(0, 0));
		}
	}

	public void LoadLanguage()
	{
		Text = buLangTranslate.preDef.File + " " + buLangTranslate.preDef.Add;
		label_1.Text = buLangTranslate.preDef.Files;
		label_3.Text = buLangTranslate.preDef.Height;
		label_0.Text = buLangTranslate.preDef.Search;
		label_2.Text = buLangTranslate.preDef.Width;
		button_2.Text = buLangTranslate.preDef.Cancel;
		button_0.Text = buLangTranslate.preDef.Folder;
		button_1.Text = buLangTranslate.preDef.Ok;
		button_8.Text = buLangTranslate.preDef.Other + " " + buLangTranslate.preDef.Files;
		button_7.Text = buLangTranslate.preDef.Delete;
		checkBox_0.Text = buLangTranslate.preDef.KeepRatio;
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
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = Path;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Path = folderBrowserDialog.SelectedPath;
			}
			Init();
		}
		if (control.Name == button_8.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "All Files |";
			for (int i = 0; i <= ExtensionList.Count - 1; i++)
			{
				if (i <= ExtensionList.Count - 1)
				{
					openFileDialog.Filter = openFileDialog.Filter + "*" + ExtensionList[i] + ";";
				}
			}
			openFileDialog.InitialDirectory = Path;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Class186.smethod_43(openFileDialog.FileName, this);
				string_0 = buFile5.getFileNameWithoutExtension(openFileDialog.FileName);
				Path = buFile5.GetPath(openFileDialog.FileName);
				list_0.Clear();
				list_0 = new List<string>();
			}
		}
		if (control.Name == button_7.Name && int_1 >= 0)
		{
			FileInfo fileInfo = new FileInfo(Path + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString());
			if (fileInfo.Exists)
			{
				string fileName = buFile.getFileName(fileInfo.FullName);
				if (buString.MessageBoxQuestion(AppLanguage.CadCamMessages[107] + " : " + fileName) == DialogResult.Yes)
				{
					fileInfo.Delete();
					Class186.smethod_290(this);
				}
			}
		}
		if (control.Name == button_3.Name)
		{
			list_0.Add("RotateLeft");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_4.Name)
		{
			list_0.Add("RotateRight");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_5.Name)
		{
			list_0.Add("MirrorHorizontal");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_6.Name)
		{
			list_0.Add("MirrorVertical");
			PropertiesForm.Inited = true;
		}
		if (control.Name == button_2.Name)
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
		if (control.Name == button_1.Name)
		{
			refImage = pictureBox_0.Image;
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
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			new Control();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			int num = 1;
			bool_0 = true;
			if (textBox_0.Text.Length != 0)
			{
				grid_files.Rows.Clear();
				for (int i = 0; i <= list_1.Count - 1; i++)
				{
					string fileName = buFile.getFileName(list_1[i]);
					if (fileName.ToLower().IndexOf(textBox_0.Text.ToLower()) >= 0)
					{
						grid_files.Rows.Add(num, fileName);
						num++;
					}
				}
			}
			else
			{
				Class186.smethod_290(this);
			}
			bool_0 = false;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			KeepRatio = checkBox_0.Checked;
		}
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.ColumnIndex;
		int_1 = e.RowIndex;
		if (int_1 >= 0)
		{
			Class186.smethod_43(Path + "\\" + grid_files.Rows[int_1].Cells[1].Value.ToString(), this);
			string_0 = grid_files.Rows[int_1].Cells[1].Value.ToString();
			list_0.Clear();
			list_0 = new List<string>();
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
