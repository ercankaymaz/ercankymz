using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using buDialogExtenders;
using ns27;

namespace buControls.DialogBox;

[ToolboxItem(false)]
public class OpenFileDialogBoxPreviewWithSubFolder : FileDialogControlBase
{
	public delegate void SelectFile(FileEventArg e);

	public delegate void SubFolderFileOkEvent(string FileName);

	public bool SubFolder = false;

	public bool ShowPreviewDisable = true;

	public bool ShowInfoButton = false;

	public int PreviewWidth = 500;

	public List<string> Extensions = new List<string>();

	private string string_6 = "";

	public static string SelectedFolder = Application.StartupPath;

	[CompilerGenerated]
	private SelectFile selectFile_0;

	[CompilerGenerated]
	private SubFolderFileOkEvent subFolderFileOkEvent_0;

	private IContainer icontainer_1 = null;

	internal Button button_0;

	internal CheckBox checkBox_0;

	public Label lbl_subfolder;

	internal ListBox listBox_0;

	public Label lbl_info;

	internal buViewer buViewer_0;

	internal Button button_1;

	internal CheckBox checkBox_1;

	public event SelectFile FileSelect
	{
		[CompilerGenerated]
		add
		{
			SelectFile selectFile = selectFile_0;
			SelectFile selectFile2;
			do
			{
				selectFile2 = selectFile;
				SelectFile value2 = (SelectFile)Delegate.Combine(selectFile2, value);
				selectFile = Interlocked.CompareExchange(ref selectFile_0, value2, selectFile2);
			}
			while ((object)selectFile != selectFile2);
		}
		[CompilerGenerated]
		remove
		{
			SelectFile selectFile = selectFile_0;
			SelectFile selectFile2;
			do
			{
				selectFile2 = selectFile;
				SelectFile value2 = (SelectFile)Delegate.Remove(selectFile2, value);
				selectFile = Interlocked.CompareExchange(ref selectFile_0, value2, selectFile2);
			}
			while ((object)selectFile != selectFile2);
		}
	}

	public event SubFolderFileOkEvent SubFolderFileOk
	{
		[CompilerGenerated]
		add
		{
			SubFolderFileOkEvent subFolderFileOkEvent = subFolderFileOkEvent_0;
			SubFolderFileOkEvent subFolderFileOkEvent2;
			do
			{
				subFolderFileOkEvent2 = subFolderFileOkEvent;
				SubFolderFileOkEvent value2 = (SubFolderFileOkEvent)Delegate.Combine(subFolderFileOkEvent2, value);
				subFolderFileOkEvent = Interlocked.CompareExchange(ref subFolderFileOkEvent_0, value2, subFolderFileOkEvent2);
			}
			while ((object)subFolderFileOkEvent != subFolderFileOkEvent2);
		}
		[CompilerGenerated]
		remove
		{
			SubFolderFileOkEvent subFolderFileOkEvent = subFolderFileOkEvent_0;
			SubFolderFileOkEvent subFolderFileOkEvent2;
			do
			{
				subFolderFileOkEvent2 = subFolderFileOkEvent;
				SubFolderFileOkEvent value2 = (SubFolderFileOkEvent)Delegate.Remove(subFolderFileOkEvent2, value);
				subFolderFileOkEvent = Interlocked.CompareExchange(ref subFolderFileOkEvent_0, value2, subFolderFileOkEvent2);
			}
			while ((object)subFolderFileOkEvent != subFolderFileOkEvent2);
		}
	}

	public OpenFileDialogBoxPreviewWithSubFolder()
	{
		Class76.smethod_522(this);
	}

	public void Init()
	{
		if (!SubFolder)
		{
			listBox_0.Visible = false;
			lbl_subfolder.Visible = false;
			button_0.Visible = false;
			checkBox_0.Visible = false;
			buViewer_0.Left = 0;
			buViewer_0.Top = 0;
			base.Width = PreviewWidth;
			buViewer_0.Width = base.Width;
			buViewer_0.Height = base.Height + 10;
		}
		checkBox_1.Left = 10;
		button_1.Left = base.Width - button_1.Width - 5;
		checkBox_1.Visible = ShowPreviewDisable;
		button_1.Visible = ShowInfoButton;
		FileDialogControlBase.SubFolderSelected = false;
		checkBox_0.Checked = SubFolder;
		Class76.smethod_399(this);
	}

	protected override void OnPrepareMSDialog()
	{
		base.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		if (Environment.OSVersion.Version.Major < 6)
		{
			base.MSDialog.SetPlaces(new object[5] { "c:\\", 17, 6, 4, 20 });
		}
		base.OnPrepareMSDialog();
	}

	internal void method_3(IWin32Window iwin32Window_0, string string_7)
	{
		checkBox_0.Checked = SubFolder;
		if (checkBox_1.Checked)
		{
			return;
		}
		if (!string_7.ToLower().EndsWith(".dwc") && !string_7.ToLower().EndsWith(".dxf") && !string_7.ToLower().EndsWith(".cnc") && !string_7.ToLower().EndsWith(".nc") && !string_7.ToLower().EndsWith(".bucad") && !string_7.ToLower().EndsWith(".u00") && !string_7.ToLower().EndsWith(".mpf"))
		{
			if (buViewer_0.Entities.Count > 0)
			{
				buViewer_0.Entities.Clear();
			}
			buViewer_0.Entities.Clear();
			return;
		}
		if (buViewer_0.Entities.Count > 0)
		{
			buViewer_0.Entities.Clear();
		}
		try
		{
			FileDialogControlBase.SubFolderSelected = false;
			FileEventArg fileEventArg = new FileEventArg();
			fileEventArg.FileName = string_7;
			fileEventArg.FilePath = Path.GetDirectoryName(string_7);
			SelectedFolder = fileEventArg.FilePath;
			fileEventArg.FilePath = string_7;
			fileEventArg.JustFileName = Path.GetFileName(string_7);
			if (checkBox_0.Checked)
			{
				Class76.smethod_399(this);
			}
			if (selectFile_0 != null)
			{
				selectFile_0(fileEventArg);
			}
			FileInfo fileInfo = new FileInfo(string_7);
			lbl_info.Text = fileInfo.Length / 1024L + "KB";
			base.FileDlgEnableOkBtn = true;
		}
		catch (Exception)
		{
			base.FileDlgEnableOkBtn = false;
		}
	}

	public void DrawPreview(List<eEntities> Entities)
	{
		GC.Collect();
		buViewer_0.Entities = new List<eEntities>();
		eEntities.CopyEntities(Entities, ref buViewer_0.Entities);
		buViewer_0.DrawEntities();
		buViewer_0.ZoomFit();
		buViewer_0.ZoomOut();
	}

	internal void method_4(object sender, CancelEventArgs e)
	{
		if (buViewer_0.Entities.Count > 0)
		{
			buViewer_0.Entities.Clear();
		}
		e.Cancel = false;
	}

	internal void method_5(IWin32Window iwin32Window_0, string string_7)
	{
		checkBox_0.Checked = SubFolder;
		SelectedFolder = string_7;
		if (checkBox_0.Checked)
		{
			Class76.smethod_399(this);
		}
		if (buViewer_0.Entities.Count > 0)
		{
			buViewer_0.Entities.Clear();
		}
		buViewer_0.Entities.Clear();
	}

	internal void method_6(object sender, HelpEventArgs e)
	{
	}

	internal void method_7(object sender, EventArgs e)
	{
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (string_6.Length > 3 && subFolderFileOkEvent_0 != null)
		{
			subFolderFileOkEvent_0(string_6);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		if (string_6.Length > 3)
		{
			FileDialogControlBase.SubFolderSelected = true;
			base.MSDialog.FileName = string_6;
			if (subFolderFileOkEvent_0 != null)
			{
				subFolderFileOkEvent_0(string_6);
			}
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
		string_6 = "";
		if ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= listBox_0.Items.Count - 1))
		{
			string_6 = SelectedFolder + "\\" + listBox_0.Items[listBox_0.SelectedIndex].ToString();
			FileEventArg fileEventArg = new FileEventArg();
			fileEventArg.FileName = string_6;
			fileEventArg.FilePath = Path.GetDirectoryName(string_6);
			fileEventArg.FilePath = string_6;
			fileEventArg.JustFileName = Path.GetFileName(string_6);
			if (selectFile_0 != null)
			{
				selectFile_0(fileEventArg);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}
}
