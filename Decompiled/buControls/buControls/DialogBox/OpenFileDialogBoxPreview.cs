using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Viewer;
using buCore;
using buDialogExtenders;
using ns27;

namespace buControls.DialogBox;

[ToolboxItem(false)]
public class OpenFileDialogBoxPreview : FileDialogControlBase
{
	public delegate void SelectFile(FileEventArg e);

	public bool SubFolder = false;

	public bool ShowPreviewDisable = true;

	public bool ShowInfoButton = false;

	public int PreviewWidth = 500;

	public FileOpenModes Properties = new FileOpenModes();

	private FileEventArg fileEventArg_0 = null;

	public List<string> Extensions = new List<string>();

	public static string SelectedFolder = Application.StartupPath;

	[CompilerGenerated]
	private SelectFile selectFile_0;

	private IContainer icontainer_1 = null;

	internal buViewer buViewer_0;

	internal Button button_0;

	internal Panel panel_0;

	internal Label label_0;

	internal TextBox textBox_0;

	internal Label label_1;

	internal CheckBox checkBox_0;

	internal Button button_1;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

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
		Class76.smethod_805(this);
	}

	public void Init()
	{
		textBox_0.Text = Properties.TxtFileSeperatorChar;
		checkBox_0.Checked = Properties.TxtFileIsSeperatorCharSpace;
		checkBox_1.Checked = Properties.CreateMesh;
		checkBox_2.Checked = Properties.XYZMode;
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

	internal void method_3(IWin32Window iwin32Window_0, string string_6)
	{
		if (!string_6.ToLower().EndsWith(".dwc") && !string_6.ToLower().EndsWith(".dxf") && !string_6.ToLower().EndsWith(".cnc") && !string_6.ToLower().EndsWith(".nc") && !string_6.ToLower().EndsWith(".bucad") && !string_6.ToLower().EndsWith(".txt") && !string_6.ToLower().EndsWith(".u00") && !string_6.ToLower().EndsWith(".cf2") && !string_6.ToLower().EndsWith(".mpf"))
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
			fileEventArg_0 = new FileEventArg();
			fileEventArg_0.FileName = string_6;
			fileEventArg_0.FilePath = Path.GetDirectoryName(string_6);
			SelectedFolder = fileEventArg_0.FilePath;
			fileEventArg_0.FilePath = string_6;
			fileEventArg_0.JustFileName = Path.GetFileName(string_6);
			fileEventArg_0.Extension = Path.GetExtension(fileEventArg_0.FileName);
			buViewer_0.Entities.Clear();
			if (fileEventArg_0.Extension.ToLower() == ".bucad")
			{
				buFile.OpenBuCadCam(fileEventArg_0.FileName, new buCadFileOpenOptions(), ref buViewer_0.Entities);
			}
			if (fileEventArg_0.Extension.ToLower() == ".dxf")
			{
				buFile.Dxf dxf = new buFile.Dxf();
				List<LayerBase> Layers = new List<LayerBase>();
				dxf.ReadDXF(fileEventArg_0.FileName, ref buViewer_0.Entities, ref Layers);
			}
			if (fileEventArg_0.Extension.ToLower() == ".cf2")
			{
				buFile.Cf2 cf = new buFile.Cf2();
				new List<LayerBase>();
				List<eEntities> Bridges = new List<eEntities>();
				cf.ReadCf2(fileEventArg_0.FileName, ref buViewer_0.Entities, ref Bridges);
			}
			if (!(fileEventArg_0.Extension.ToLower() == ".txt"))
			{
			}
			DrawPreview(buViewer_0.Entities);
			if (selectFile_0 != null)
			{
				selectFile_0(fileEventArg_0);
			}
			new FileInfo(string_6);
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

	internal void method_5(IWin32Window iwin32Window_0, string string_6)
	{
		SelectedFolder = string_6;
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
		if (fileEventArg_0 != null && fileEventArg_0.Extension.ToLower() == ".txt")
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
	}

	internal void method_8(object sender, EventArgs e)
	{
		Properties.TxtFileSeperatorChar = textBox_0.Text;
		Properties.TxtFileIsSeperatorCharSpace = checkBox_0.Checked;
		Properties.CreateMesh = checkBox_1.Checked;
		Properties.XYZMode = checkBox_2.Checked;
		panel_0.Visible = false;
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
