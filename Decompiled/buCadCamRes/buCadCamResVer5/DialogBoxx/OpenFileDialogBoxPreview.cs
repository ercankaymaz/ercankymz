using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buDialogExtenders;
using ns8;

namespace buCadCamResVer5.DialogBoxx;

[ToolboxItem(false)]
public class OpenFileDialogBoxPreview : FileDialogControlBase
{
	public delegate void SelectFile(FileEventArg e);

	[CompilerGenerated]
	private SelectFile selectFile_0;

	public bool SubFolder = false;

	public bool ShowPreviewDisable = true;

	public bool ShowInfoButton = false;

	public FileOpenModes Properties = new FileOpenModes();

	public ViewportViewType ViewType = ViewportViewType.Top;

	public bool PreviewEnable = true;

	public string SelectedExtension = "";

	public List<string> Extensions = new List<string>();

	public static string SelectedFolder = Application.StartupPath;

	private FileEventArg fileEventArg_0 = null;

	private IContainer icontainer_1 = null;

	internal Button button_0;

	public PictureBox picture_preview;

	public Label lbl_previeloading;

	internal Button button_1;

	internal Panel panel_0;

	internal Label label_0;

	public RadioButton radio_trimetric;

	public RadioButton radio_iso;

	public RadioButton radio_top;

	public CheckBox chk_preview;

	public Label lbl_info;

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

	public OpenFileDialogBoxPreview()
	{
		Class5.smethod_202(this);
		base.EventFilterChanged += FilterChanged;
		base.EventFileNameChanged += FileNameChanged;
		base.EventFolderNameChanged += FolderNameChanged;
	}

	public void Init()
	{
		if (ViewType != ViewportViewType.Top)
		{
			if (ViewType != ViewportViewType.Isometric)
			{
				radio_top.Checked = false;
				radio_iso.Checked = false;
				radio_trimetric.Checked = true;
			}
			else
			{
				radio_top.Checked = false;
				radio_iso.Checked = true;
				radio_trimetric.Checked = false;
			}
		}
		else
		{
			radio_top.Checked = true;
			radio_iso.Checked = false;
			radio_trimetric.Checked = false;
		}
		chk_preview.Checked = PreviewEnable;
		picture_preview.Image = null;
	}

	public void ShowLoading(bool Show)
	{
		lbl_previeloading.Visible = Show;
	}

	public void DrawPreviewImage(Image refImage)
	{
		picture_preview.Image = refImage;
	}

	protected override void OnPrepareMSDialog()
	{
		base.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		if (Environment.OSVersion.Version.Major < 6)
		{
			base.OnPrepareMSDialog();
		}
	}

	internal void method_3(IWin32Window iwin32Window_0, string string_6)
	{
		try
		{
			FileDialogControlBase.SubFolderSelected = false;
			fileEventArg_0 = new FileEventArg();
			fileEventArg_0.FileName = string_6;
			fileEventArg_0.FilePath = Path.GetDirectoryName(string_6);
			SelectedFolder = fileEventArg_0.FilePath;
			fileEventArg_0.FilePath = string_6;
			fileEventArg_0.JustFileName = Path.GetFileName(string_6);
			fileEventArg_0.Extension = Path.GetExtension(fileEventArg_0.FileName);
			if (selectFile_0 != null)
			{
				selectFile_0(fileEventArg_0);
			}
			base.FileDlgEnableOkBtn = true;
		}
		catch (Exception)
		{
			base.FileDlgEnableOkBtn = false;
		}
	}

	public void DrawPreview(List<eEntities> Entities)
	{
	}

	public void FilterChanged(IWin32Window sender, int index)
	{
		int num = index - 1;
		_ = base.FileDlgInitialDirectory;
		if ((num >= 0) & (num <= Extensions.Count - 1))
		{
			SelectedExtension = Extensions[num];
		}
	}

	public void FolderNameChanged(IWin32Window sender, string folderName)
	{
	}

	public void FileNameChanged(IWin32Window sender, string fileName)
	{
	}

	internal void method_4(object sender, CancelEventArgs e)
	{
	}

	internal void method_5(IWin32Window iwin32Window_0, string string_6)
	{
		SelectedFolder = string_6;
	}

	internal void method_6(object sender, HelpEventArgs e)
	{
	}

	internal void method_7(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name)
		{
			if (panel_0.Visible)
			{
				panel_0.Visible = false;
			}
			else
			{
				panel_0.Visible = true;
			}
		}
		if (control.Name == button_0.Name && fileEventArg_0 != null && fileEventArg_0.Extension.ToLower() == ".txt")
		{
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (radio_top.Checked)
		{
			ViewType = ViewportViewType.Top;
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		if (radio_iso.Checked)
		{
			ViewType = ViewportViewType.Isometric;
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
		if (radio_trimetric.Checked)
		{
			ViewType = ViewportViewType.Trimetric;
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
