using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.Notepad;
using buControls.Viewer;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.FileLoad;

public class F_LoadWithPreview : Form
{
	private F_Notepad f_Notepad_0 = new F_Notepad();

	private bool bool_0 = false;

	internal List<string> list_0 = new List<string>();

	public string[] FileStrings = null;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	public List<string> Captions = new List<string>();

	public List<string> FileExtension = new List<string>();

	public bool FormTopMost = false;

	public bool ScreenCenter = true;

	public string PathJob = Application.StartupPath;

	public bool ClosePageAfterLoad = true;

	public bool ShowCountData = true;

	public bool DisablePreview = false;

	public bool ShowG0Draw = true;

	public bool SendFile = false;

	private string string_0 = Application.StartupPath;

	private string string_1 = Application.StartupPath;

	[CompilerGenerated]
	private LoadFileEventHandler loadFileEventHandler_0;

	[CompilerGenerated]
	private FileSelectedEventHandler fileSelectedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buListBox buListBox_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buTextBox buTextBox_0;

	internal buButton buButton_5;

	internal buPanel buPanel_0;

	internal buButton buButton_6;

	internal buButton buButton_7;

	internal buButton buButton_8;

	internal buButton buButton_9;

	internal buButton buButton_10;

	internal buButton buButton_11;

	internal buSpin buSpin_0;

	internal buButton buButton_12;

	internal buCheckBox buCheckBox_0;

	internal buButton buButton_13;

	internal buLabel buLabel_0;

	public buViewer viewer_preview;

	public buCheckBox chk_option3;

	public buCheckBox chk_option2;

	public buCheckBox chk_option1;

	public buSpin spn_data1;

	public event LoadFileEventHandler FileLoad
	{
		[CompilerGenerated]
		add
		{
			LoadFileEventHandler loadFileEventHandler = loadFileEventHandler_0;
			LoadFileEventHandler loadFileEventHandler2;
			do
			{
				loadFileEventHandler2 = loadFileEventHandler;
				LoadFileEventHandler value2 = (LoadFileEventHandler)Delegate.Combine(loadFileEventHandler2, value);
				loadFileEventHandler = Interlocked.CompareExchange(ref loadFileEventHandler_0, value2, loadFileEventHandler2);
			}
			while ((object)loadFileEventHandler != loadFileEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LoadFileEventHandler loadFileEventHandler = loadFileEventHandler_0;
			LoadFileEventHandler loadFileEventHandler2;
			do
			{
				loadFileEventHandler2 = loadFileEventHandler;
				LoadFileEventHandler value2 = (LoadFileEventHandler)Delegate.Remove(loadFileEventHandler2, value);
				loadFileEventHandler = Interlocked.CompareExchange(ref loadFileEventHandler_0, value2, loadFileEventHandler2);
			}
			while ((object)loadFileEventHandler != loadFileEventHandler2);
		}
	}

	public event FileSelectedEventHandler FileSelected
	{
		[CompilerGenerated]
		add
		{
			FileSelectedEventHandler fileSelectedEventHandler = fileSelectedEventHandler_0;
			FileSelectedEventHandler fileSelectedEventHandler2;
			do
			{
				fileSelectedEventHandler2 = fileSelectedEventHandler;
				FileSelectedEventHandler value2 = (FileSelectedEventHandler)Delegate.Combine(fileSelectedEventHandler2, value);
				fileSelectedEventHandler = Interlocked.CompareExchange(ref fileSelectedEventHandler_0, value2, fileSelectedEventHandler2);
			}
			while ((object)fileSelectedEventHandler != fileSelectedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			FileSelectedEventHandler fileSelectedEventHandler = fileSelectedEventHandler_0;
			FileSelectedEventHandler fileSelectedEventHandler2;
			do
			{
				fileSelectedEventHandler2 = fileSelectedEventHandler;
				FileSelectedEventHandler value2 = (FileSelectedEventHandler)Delegate.Remove(fileSelectedEventHandler2, value);
				fileSelectedEventHandler = Interlocked.CompareExchange(ref fileSelectedEventHandler_0, value2, fileSelectedEventHandler2);
			}
			while ((object)fileSelectedEventHandler != fileSelectedEventHandler2);
		}
	}

	public F_LoadWithPreview()
	{
		Class76.smethod_123(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		try
		{
			e.Cancel = true;
			base.Visible = false;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (base.Visible)
			{
				Init();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void Init()
	{
		try
		{
			base.TopMost = FormTopMost;
			buSpin_0.Visible = ShowCountData;
			DirectoryInfo directoryInfo = new DirectoryInfo(PathJob);
			if (!directoryInfo.Exists)
			{
				PathJob = Application.StartupPath;
				Directory.CreateDirectory(PathJob);
			}
			buListBox_0.Font = new Font("Arial", 14f);
			bool_0 = false;
			buCheckBox_0.Visible = ShowG0Draw;
			if (!ShowG0Draw)
			{
				buCheckBox_0.Check = false;
			}
			Class76.smethod_558(this);
			LoadLanguage();
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void Init(string Path)
	{
		PathJob = Path;
		Init();
	}

	public void Init(string Path, List<string> Extensions)
	{
		PathJob = Path;
		FileExtension.Clear();
		FileExtension.AddRange(Extensions);
		Init();
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 35)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void Lst_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (bool_0)
			{
				return;
			}
			FileInfo fileInfo = null;
			SendFile = false;
			buLabel_0.Visible = false;
			fileInfo = new FileInfo(PathJob + "\\" + buListBox_0.Text);
			if (fileInfo.Exists & f_Notepad_0.Visible)
			{
				string Str = "";
				buFile.OpenFromFile(fileInfo.FullName, ref Str);
				f_Notepad_0.Init(Str);
				f_Notepad_0.Location = new Point(2, 5);
			}
			string_0 = fileInfo.FullName;
			string_1 = buFile.GetPath(fileInfo.FullName);
			if (!DisablePreview)
			{
				List<eEntities> list = new List<eEntities>();
				viewer_preview.Entities.Clear();
				for (int i = 0; i <= list.Count - 1; i++)
				{
					eEntities copiedEnt = new eEntities();
					eEntities.CopyEntity(list[i], ref copiedEnt);
					viewer_preview.Entities.Add(copiedEnt);
				}
				viewer_preview.setView(ViewportViewType.Top);
				viewer_preview.ZoomFit();
				viewer_preview.ZoomOut();
				if (fileSelectedEventHandler_0 != null)
				{
					FileEventArg fileName = new FileEventArg(fileInfo.FullName);
					fileSelectedEventHandler_0(fileName);
				}
			}
			else if (fileSelectedEventHandler_0 != null)
			{
				FileEventArg fileName2 = new FileEventArg(fileInfo.FullName);
				fileSelectedEventHandler_0(fileName2);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void DrawEntities(List<eEntities> Entities)
	{
		try
		{
			viewer_preview.Entities.Clear();
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				eEntities copiedEnt = new eEntities();
				eEntities.CopyEntity(Entities[i], ref copiedEnt);
				viewer_preview.Entities.Add(copiedEnt);
			}
			viewer_preview.setView(ViewportViewType.Top);
			viewer_preview.ZoomFit();
			viewer_preview.ZoomOut();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			new List<Pnt3D>();
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == buButton_9.Name)
			{
				Process.Start(PathJob);
			}
			if (control.Name == buButton_4.Name && buListBox_0.Items.Count > 0)
			{
				if (buListBox_0.SelectedIndex < 0)
				{
					buListBox_0.SelectedIndex = 0;
				}
				if (buListBox_0.SelectedIndex < buListBox_0.Items.Count - 1)
				{
					buListBox_0.SelectedIndex++;
				}
			}
			if (control.Name == buButton_3.Name && buListBox_0.Items.Count > 0)
			{
				if (buListBox_0.SelectedIndex < 0)
				{
					buListBox_0.SelectedIndex = 0;
				}
				if (buListBox_0.SelectedIndex > 0)
				{
					buListBox_0.SelectedIndex--;
				}
			}
			if (control.Name == buButton_11.Name)
			{
				text = PathJob + "\\" + buListBox_0.Text;
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Exists)
				{
					string text2 = "Do You Want To Delete This File ";
					if (AppLanguage.SystemMessages.Count > 1)
					{
						text2 = AppLanguage.SystemMessages[1];
					}
					if (buString.MessageBoxQuestion(text + text2) == DialogResult.Yes)
					{
						buLog.addLog(buListBox_0.Text + "  -  File Deleted", "Delete", MethodBase.GetCurrentMethod().Name);
						fileInfo.Delete();
						Class76.smethod_558(this);
					}
				}
			}
			if (control.Name == buButton_10.Name)
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.SelectedPath = PathJob;
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					PathJob = folderBrowserDialog.SelectedPath;
					buLog.addLog("Folder Changed  = " + PathJob, "Folder Changed", MethodBase.GetCurrentMethod().Name);
				}
				Init();
			}
			if (control.Name == buButton_8.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = PathJob;
				for (int i = 0; i <= FileExtension.Count - 1; i++)
				{
					string text3 = FileExtension[i].Trim();
					string text4 = "";
					if (text3.IndexOf("*.") <= 0)
					{
						text3 = "*." + text3;
					}
					if (i > 0)
					{
						text4 = "|";
					}
					openFileDialog.Filter = openFileDialog.Filter + text4 + FileExtension[i] + " Files (*." + FileExtension[i] + ")|" + text3;
				}
				openFileDialog.FilterIndex = 1;
				openFileDialog.FileName = "";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					SendFile = false;
					AppProcess.LastLoadedFileName = openFileDialog.FileName;
					AppProcess.LastLoadedFolder = buFile.GetPath(openFileDialog.FileName);
					method_3(buButton_12, null);
				}
			}
			if (control.Name == buButton_7.Name)
			{
				text = PathJob + "\\" + buListBox_0.Text;
				FileInfo fileInfo2 = new FileInfo(text);
				if (fileInfo2.Exists)
				{
					string Str = "";
					buFile.OpenFromFile(fileInfo2.FullName, ref Str);
					f_Notepad_0 = new F_Notepad();
					f_Notepad_0.Init(Str);
					f_Notepad_0.ShowDialog(this);
				}
			}
		}
		catch (Exception mSException)
		{
			string text5 = "";
			buLog.addLog(text5, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text5);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			FileEventArg fileEventArg = new FileEventArg();
			fileEventArg.FileName = string_0;
			fileEventArg.FilePath = string_1;
			AppProcess.LastLoadedFolder = string_1;
			AppProcess.LastLoadedFileName = string_0;
			fileEventArg.Count = Convert.ToInt32(buSpin_0.Value);
			fileEventArg.JustFileName = buFile.getFileName(fileEventArg.FileName);
			if (loadFileEventHandler_0 != null)
			{
				loadFileEventHandler_0(fileEventArg);
			}
			if (ClosePageAfterLoad)
			{
				base.Visible = false;
			}
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
		method_3(buButton_12, null);
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_2.Name) | (control.Name == buButton_0.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_1.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
			if (control.Name == buButton_13.Name)
			{
				if (base.WindowState != FormWindowState.Maximized)
				{
					base.WindowState = FormWindowState.Maximized;
				}
				else
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == buButton_6.Name)
			{
				buPanel_0.Visible = false;
			}
			if (control.Name == buButton_5.Name)
			{
				if (buPanel_0.Visible)
				{
					buPanel_0.Visible = false;
				}
				else
				{
					buPanel_0.Visible = true;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		try
		{
			bool_0 = true;
			if (buTextBox_0.Text.Length != 0)
			{
				buListBox_0.Items.Clear();
				for (int i = 0; i <= list_0.Count - 1; i++)
				{
					if (list_0[i].ToLower().IndexOf(buTextBox_0.Text.ToLower()) == 0)
					{
						buListBox_0.Items.Add(list_0[i]);
					}
				}
			}
			else
			{
				Class76.smethod_558(this);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
