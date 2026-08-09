using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.ClassViewer;
using buDialogExtenders;
using buEyeBaseVer5;
using ns8;

namespace buCadCamResVer5.DialogBoxx;

[ToolboxItem(false)]
public class SaveFileDialogBoxOptions : FileDialogControlBase
{
	public delegate void SelectFile(FileEventArg e);

	[CompilerGenerated]
	private SelectFile selectFile_0;

	public bool SubFolder = false;

	public FileSaveModes Properties = new FileSaveModes();

	public List<string> Extensions = new List<string>();

	public static string SelectedFolder = Application.StartupPath;

	private FileEventArg fileEventArg_0 = null;

	private IContainer icontainer_1 = null;

	internal Button button_0;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	public CheckBox chk_savetools;

	public CheckBox chk_saveselected;

	internal Panel panel_1;

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

	public SaveFileDialogBoxOptions()
	{
		Class5.smethod_123(this);
	}

	public void Init()
	{
		if (!Properties.SaveGeometry & !Properties.SaveTessellation)
		{
			Properties.SaveGeometry = true;
			Properties.SaveTessellation = true;
		}
		if (Properties.SaveGeometry & Properties.SaveTessellation)
		{
			radioButton_0.Checked = true;
		}
		if (Properties.SaveGeometry & !Properties.SaveTessellation)
		{
			radioButton_2.Checked = true;
		}
		if (!Properties.SaveGeometry & Properties.SaveTessellation)
		{
			radioButton_1.Checked = true;
		}
		chk_saveselected.Checked = Properties.SaveSelected;
		chk_savetools.Checked = Properties.SaveTools;
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
		if (!(control.Name == button_0.Name))
		{
			return;
		}
		if (fileEventArg_0 == null)
		{
			buString5.MessageBoxInfo(AppLanguage.CadCamMessages[131]);
			return;
		}
		if (fileEventArg_0.Extension.ToLower() == ".bucadv5")
		{
			panel_1.Left = 2;
			if (panel_1.Visible)
			{
				panel_1.Visible = false;
			}
			else
			{
				panel_1.Visible = true;
			}
		}
		if ((fileEventArg_0.Extension.ToLower() == ".dxf") | (fileEventArg_0.Extension.ToLower() == ".dwg"))
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Settings";
			f_ClassViewerDialog.Value = clsVar.varAutoCadFileProps;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				clsVar.varAutoCadFileProps = new WriteDxfDwgPropeties((WriteDxfDwgPropeties)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		Properties.SaveTools = chk_savetools.Checked;
	}

	internal void method_9(object sender, EventArgs e)
	{
		Properties.SaveSelected = chk_saveselected.Checked;
	}

	internal void method_10(object sender, EventArgs e)
	{
		if (radioButton_2.Checked)
		{
			Properties.SaveGeometry = true;
			Properties.SaveTessellation = false;
		}
		if (radioButton_1.Checked)
		{
			Properties.SaveGeometry = false;
			Properties.SaveTessellation = true;
		}
		if (radioButton_0.Checked)
		{
			Properties.SaveGeometry = true;
			Properties.SaveTessellation = true;
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
