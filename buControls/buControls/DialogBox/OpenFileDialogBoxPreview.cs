// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.OpenFileDialogBoxPreview
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
using buCore;
using buDialogExtenders;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

[ToolboxItem(false)]
public class OpenFileDialogBoxPreview : FileDialogControlBase
{
  public bool SubFolder = false;
  public bool ShowPreviewDisable = true;
  public bool ShowInfoButton = false;
  public int PreviewWidth = 500;
  public FileOpenModes Properties = new FileOpenModes();
  private FileEventArg fileEventArg_0 = (FileEventArg) null;
  public List<string> Extensions = new List<string>();
  public static string SelectedFolder = Application.StartupPath;
  private IContainer icontainer_1 = (IContainer) null;
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

  public OpenFileDialogBoxPreview() => Class39.smethod_805(this);

  public void Init()
  {
    this.textBox_0.Text = this.Properties.TxtFileSeperatorChar;
    this.checkBox_0.Checked = this.Properties.TxtFileIsSeperatorCharSpace;
    this.checkBox_1.Checked = this.Properties.CreateMesh;
    this.checkBox_2.Checked = this.Properties.XYZMode;
  }

  protected override void OnPrepareMSDialog()
  {
    this.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    if (Environment.OSVersion.Version.Major < 6)
      this.MSDialog.SetPlaces(new object[5]
      {
        (object) "c:\\",
        (object) 17,
        (object) 6,
        (object) 4,
        (object) 20
      });
    base.OnPrepareMSDialog();
  }

  internal void method_3(IWin32Window iwin32Window_0, string string_6)
  {
    if ((string_6.ToLower().EndsWith(".dwc") || string_6.ToLower().EndsWith(".dxf") || string_6.ToLower().EndsWith(".cnc") || string_6.ToLower().EndsWith(".nc") || string_6.ToLower().EndsWith(".bucad") || string_6.ToLower().EndsWith(".txt") || string_6.ToLower().EndsWith(".u00") || string_6.ToLower().EndsWith(".cf2") ? 1 : (string_6.ToLower().EndsWith(".mpf") ? 1 : 0)) != 0)
    {
      if (this.buViewer_0.Entities.Count > 0)
        this.buViewer_0.Entities.Clear();
      try
      {
        FileDialogControlBase.SubFolderSelected = false;
        this.fileEventArg_0 = new FileEventArg();
        this.fileEventArg_0.FileName = string_6;
        this.fileEventArg_0.FilePath = Path.GetDirectoryName(string_6);
        OpenFileDialogBoxPreview.SelectedFolder = this.fileEventArg_0.FilePath;
        this.fileEventArg_0.FilePath = string_6;
        this.fileEventArg_0.JustFileName = Path.GetFileName(string_6);
        this.fileEventArg_0.Extension = Path.GetExtension(this.fileEventArg_0.FileName);
        this.buViewer_0.Entities.Clear();
        if (this.fileEventArg_0.Extension.ToLower() == ".bucad")
          buFile.OpenBuCadCam(this.fileEventArg_0.FileName, new buCadFileOpenOptions(), ref this.buViewer_0.Entities);
        if (this.fileEventArg_0.Extension.ToLower() == ".dxf")
        {
          buFile.Dxf dxf = new buFile.Dxf();
          List<LayerBase> Layers = new List<LayerBase>();
          dxf.ReadDXF(this.fileEventArg_0.FileName, ref this.buViewer_0.Entities, ref Layers);
        }
        if (this.fileEventArg_0.Extension.ToLower() == ".cf2")
        {
          buFile.Cf2 cf2 = new buFile.Cf2();
          List<LayerBase> layerBaseList = new List<LayerBase>();
          List<eEntities> Bridges = new List<eEntities>();
          cf2.ReadCf2(this.fileEventArg_0.FileName, ref this.buViewer_0.Entities, ref Bridges);
        }
        if (this.fileEventArg_0.Extension.ToLower() == ".txt")
          ;
        this.DrawPreview(this.buViewer_0.Entities);
        // ISSUE: reference to a compiler-generated field
        if (this.selectFile_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.selectFile_0(this.fileEventArg_0);
        }
        FileInfo fileInfo = new FileInfo(string_6);
        this.FileDlgEnableOkBtn = true;
      }
      catch (Exception ex)
      {
        this.FileDlgEnableOkBtn = false;
      }
    }
    else
    {
      if (this.buViewer_0.Entities.Count > 0)
        this.buViewer_0.Entities.Clear();
      this.buViewer_0.Entities.Clear();
    }
  }

  public void DrawPreview(List<eEntities> Entities)
  {
    GC.Collect();
    this.buViewer_0.Entities = new List<eEntities>();
    eEntities.CopyEntities(Entities, ref this.buViewer_0.Entities);
    this.buViewer_0.DrawEntities();
    this.buViewer_0.ZoomFit();
    this.buViewer_0.ZoomOut();
  }

  public event OpenFileDialogBoxPreview.SelectFile FileSelect;

  internal void method_4(object sender, CancelEventArgs e)
  {
    if (this.buViewer_0.Entities.Count > 0)
      this.buViewer_0.Entities.Clear();
    e.Cancel = false;
  }

  internal void method_5(IWin32Window iwin32Window_0, string string_6)
  {
    OpenFileDialogBoxPreview.SelectedFolder = string_6;
    if (this.buViewer_0.Entities.Count > 0)
      this.buViewer_0.Entities.Clear();
    this.buViewer_0.Entities.Clear();
  }

  internal void method_6(object sender, HelpEventArgs e)
  {
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (this.fileEventArg_0 == null || !(this.fileEventArg_0.Extension.ToLower() == ".txt"))
      return;
    if (!this.panel_0.Visible)
      this.panel_0.Visible = true;
    else
      this.panel_0.Visible = false;
  }

  internal void method_8(object sender, EventArgs e)
  {
    this.Properties.TxtFileSeperatorChar = this.textBox_0.Text;
    this.Properties.TxtFileIsSeperatorCharSpace = this.checkBox_0.Checked;
    this.Properties.CreateMesh = this.checkBox_1.Checked;
    this.Properties.XYZMode = this.checkBox_2.Checked;
    this.panel_0.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_1 != null ? 1 : 0)) != 0)
      this.icontainer_1.Dispose();
    base.Dispose(disposing);
  }

  public delegate void SelectFile(FileEventArg e);
}
