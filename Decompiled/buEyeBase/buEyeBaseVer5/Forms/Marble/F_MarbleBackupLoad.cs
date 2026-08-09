using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleBackupLoad : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public string BackupFolder = "";

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buButton btn_close;

	internal buListBox buListBox_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	public F_MarbleBackupLoad()
	{
		Class186.smethod_697(this);
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
		FillList();
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			buGround_0.Text = buLangTranslate.preDef.BackUp;
			buButton_0.Text = buLangTranslate.preDef.Cancel;
		}
		catch (Exception)
		{
		}
	}

	public void FillList()
	{
		buListBox_0.Items.Clear();
		List<string> Paths = new List<string>();
		buFile5.getPathsInPath(AppPath.Backup, ref Paths);
		for (int i = 0; i <= Paths.Count - 1; i++)
		{
			buListBox_0.Items.Add(Paths[i]);
		}
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buButton_2.Name && buListBox_0.SelectedIndex >= 0)
		{
			buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
			buDialogMessageBoxYesNo2.Init(buLangTranslate.preDef.BackUp, buLangTranslate.preSentences.DoYouWantToDelete + " [ " + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + " ]");
			buDialogMessageBoxYesNo2.ShowDialog();
			if (buDialogMessageBoxYesNo2.Result == DialogResult.Yes)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Backup + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString());
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				FillList();
			}
		}
		if (control.Name == buButton_1.Name)
		{
			Process.Start(AppPath.Backup);
		}
		if (control.Name == buButton_3.Name && buListBox_0.SelectedIndex >= 0)
		{
			buDialogMessageBoxYesNo buDialogMessageBoxYesNo3 = new buDialogMessageBoxYesNo();
			buDialogMessageBoxYesNo3.Init(buLangTranslate.preDef.BackUp, buLangTranslate.preSentences.DoYouWantToRestoreFromBackup + " [ " + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + " ]");
			buDialogMessageBoxYesNo3.ShowDialog();
			if (buDialogMessageBoxYesNo3.Result == DialogResult.Yes)
			{
				DirectoryInfo directoryInfo2 = new DirectoryInfo(AppPath.Backup + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString());
				if (directoryInfo2.Exists)
				{
					BackupFolder = directoryInfo2.FullName;
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
		}
		if (control.Name == buButton_4.Name)
		{
			string text = AppPath.MachineSettings + "\\Machine.prm";
			string text2 = AppPath.Backup + "\\" + buListBox_0.Items[buListBox_0.SelectedIndex].ToString() + "\\Machine.prm";
			string[] array = new string[2] { text, text2 };
			string arguments = text + " " + text2;
			Process.Start(buMarbleCalc.varMarbleSettings.CompareProgramName, arguments);
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
