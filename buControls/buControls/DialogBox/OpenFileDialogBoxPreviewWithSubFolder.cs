// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.OpenFileDialogBoxPreviewWithSubFolder
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
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
public class OpenFileDialogBoxPreviewWithSubFolder : FileDialogControlBase
{
  public bool SubFolder = false;
  public bool ShowPreviewDisable = true;
  public bool ShowInfoButton = false;
  public int PreviewWidth = 500;
  public List<string> Extensions = new List<string>();
  private string string_6 = "";
  public static string SelectedFolder = Application.StartupPath;
  private IContainer icontainer_1 = (IContainer) null;
  internal Button button_0;
  internal CheckBox checkBox_0;
  public Label lbl_subfolder;
  internal ListBox listBox_0;
  public Label lbl_info;
  internal buViewer buViewer_0;
  internal Button button_1;
  internal CheckBox checkBox_1;

  public OpenFileDialogBoxPreviewWithSubFolder() => Class39.smethod_522(this);

  public void Init()
  {
    if (!this.SubFolder)
    {
      this.listBox_0.Visible = false;
      this.lbl_subfolder.Visible = false;
      this.button_0.Visible = false;
      this.checkBox_0.Visible = false;
      this.buViewer_0.Left = 0;
      this.buViewer_0.Top = 0;
      this.Width = this.PreviewWidth;
      this.buViewer_0.Width = this.Width;
      this.buViewer_0.Height = this.Height + 10;
    }
    this.checkBox_1.Left = 10;
    this.button_1.Left = this.Width - this.button_1.Width - 5;
    this.checkBox_1.Visible = this.ShowPreviewDisable;
    this.button_1.Visible = this.ShowInfoButton;
    FileDialogControlBase.SubFolderSelected = false;
    this.checkBox_0.Checked = this.SubFolder;
    Class39.smethod_399(this);
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

  internal void method_3(IWin32Window iwin32Window_0, string string_7)
  {
    this.checkBox_0.Checked = this.SubFolder;
    if (this.checkBox_1.Checked)
      return;
    if ((string_7.ToLower().EndsWith(".dwc") || string_7.ToLower().EndsWith(".dxf") || string_7.ToLower().EndsWith(".cnc") || string_7.ToLower().EndsWith(".nc") || string_7.ToLower().EndsWith(".bucad") || string_7.ToLower().EndsWith(".u00") ? 1 : (string_7.ToLower().EndsWith(".mpf") ? 1 : 0)) != 0)
    {
      if (this.buViewer_0.Entities.Count > 0)
        this.buViewer_0.Entities.Clear();
      try
      {
        FileDialogControlBase.SubFolderSelected = false;
        FileEventArg e = new FileEventArg();
        e.FileName = string_7;
        e.FilePath = Path.GetDirectoryName(string_7);
        OpenFileDialogBoxPreviewWithSubFolder.SelectedFolder = e.FilePath;
        e.FilePath = string_7;
        e.JustFileName = Path.GetFileName(string_7);
        if (this.checkBox_0.Checked)
          Class39.smethod_399(this);
        // ISSUE: reference to a compiler-generated field
        if (this.selectFile_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.selectFile_0(e);
        }
        this.lbl_info.Text = (new FileInfo(string_7).Length / 1024L /*0x0400*/).ToString() + "KB";
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

  public event OpenFileDialogBoxPreviewWithSubFolder.SelectFile FileSelect;

  public event OpenFileDialogBoxPreviewWithSubFolder.SubFolderFileOkEvent SubFolderFileOk;

  internal void method_4(object sender, CancelEventArgs e)
  {
    if (this.buViewer_0.Entities.Count > 0)
      this.buViewer_0.Entities.Clear();
    e.Cancel = false;
  }

  internal void method_5(IWin32Window iwin32Window_0, string string_7)
  {
    this.checkBox_0.Checked = this.SubFolder;
    OpenFileDialogBoxPreviewWithSubFolder.SelectedFolder = string_7;
    if (this.checkBox_0.Checked)
      Class39.smethod_399(this);
    if (this.buViewer_0.Entities.Count > 0)
      this.buViewer_0.Entities.Clear();
    this.buViewer_0.Entities.Clear();
  }

  internal void method_6(object sender, HelpEventArgs e)
  {
  }

  internal void method_7(object sender, EventArgs e)
  {
  }

  internal void method_8(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.string_6.Length <= 3 || this.subFolderFileOkEvent_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.subFolderFileOkEvent_0(this.string_6);
  }

  internal void method_9(object sender, EventArgs e)
  {
    if (this.string_6.Length <= 3)
      return;
    FileDialogControlBase.SubFolderSelected = true;
    this.MSDialog.FileName = this.string_6;
    // ISSUE: reference to a compiler-generated field
    if (this.subFolderFileOkEvent_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.subFolderFileOkEvent_0(this.string_6);
  }

  internal void method_10(object sender, EventArgs e)
  {
    this.string_6 = "";
    if (!(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.listBox_0.Items.Count - 1))
      return;
    this.string_6 = $"{OpenFileDialogBoxPreviewWithSubFolder.SelectedFolder}\\{this.listBox_0.Items[this.listBox_0.SelectedIndex].ToString()}";
    FileEventArg e1 = new FileEventArg()
    {
      FileName = this.string_6,
      FilePath = Path.GetDirectoryName(this.string_6)
    };
    e1.FilePath = this.string_6;
    e1.JustFileName = Path.GetFileName(this.string_6);
    // ISSUE: reference to a compiler-generated field
    if (this.selectFile_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.selectFile_0(e1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_1 != null ? 1 : 0)) != 0)
      this.icontainer_1.Dispose();
    base.Dispose(disposing);
  }

  public delegate void SelectFile(FileEventArg e);

  public delegate void SubFolderFileOkEvent(string FileName);
}
