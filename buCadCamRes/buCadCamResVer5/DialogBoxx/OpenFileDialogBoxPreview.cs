// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buDialogExtenders;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.DialogBoxx;

[ToolboxItem(false)]
public class OpenFileDialogBoxPreview : FileDialogControlBase
{
  public bool SubFolder = false;
  public bool ShowPreviewDisable = true;
  public bool ShowInfoButton = false;
  public FileOpenModes Properties = new FileOpenModes();
  public ViewportViewType ViewType = ViewportViewType.Top;
  public bool PreviewEnable = true;
  public string SelectedExtension = "";
  public List<string> Extensions = new List<string>();
  public static string SelectedFolder = Application.StartupPath;
  private FileEventArg fileEventArg_0 = (FileEventArg) null;
  private IContainer icontainer_1 = (IContainer) null;
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

  public OpenFileDialogBoxPreview()
  {
    Class5.smethod_202(this);
    this.EventFilterChanged += new FileDialogControlBase.FilterChangedEventHandler(this.FilterChanged);
    this.EventFileNameChanged += new FileDialogControlBase.PathChangedEventHandler(this.FileNameChanged);
    this.EventFolderNameChanged += new FileDialogControlBase.PathChangedEventHandler(this.FolderNameChanged);
  }

  public void Init()
  {
    if (this.ViewType == ViewportViewType.Top)
    {
      this.radio_top.Checked = true;
      this.radio_iso.Checked = false;
      this.radio_trimetric.Checked = false;
    }
    else if (this.ViewType == ViewportViewType.Isometric)
    {
      this.radio_top.Checked = false;
      this.radio_iso.Checked = true;
      this.radio_trimetric.Checked = false;
    }
    else
    {
      this.radio_top.Checked = false;
      this.radio_iso.Checked = false;
      this.radio_trimetric.Checked = true;
    }
    this.chk_preview.Checked = this.PreviewEnable;
    this.picture_preview.Image = (Image) null;
  }

  public void ShowLoading(bool Show) => this.lbl_previeloading.Visible = Show;

  public void DrawPreviewImage(Image refImage) => this.picture_preview.Image = refImage;

  public event OpenFileDialogBoxPreview.SelectFile FileSelect;

  protected override void OnPrepareMSDialog()
  {
    this.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    if (Environment.OSVersion.Version.Major >= 6)
      return;
    base.OnPrepareMSDialog();
  }

  internal void method_3(IWin32Window iwin32Window_0, string string_6)
  {
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
      // ISSUE: reference to a compiler-generated field
      if (this.selectFile_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.selectFile_0(this.fileEventArg_0);
      }
      this.FileDlgEnableOkBtn = true;
    }
    catch (Exception ex)
    {
      this.FileDlgEnableOkBtn = false;
    }
  }

  public void DrawPreview(List<eEntities> Entities)
  {
  }

  public void FilterChanged(IWin32Window sender, int index)
  {
    int index1 = index - 1;
    string initialDirectory = this.FileDlgInitialDirectory;
    if (!(index1 >= 0 & index1 <= this.Extensions.Count - 1))
      return;
    this.SelectedExtension = this.Extensions[index1];
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
    OpenFileDialogBoxPreview.SelectedFolder = string_6;
  }

  internal void method_6(object sender, HelpEventArgs e)
  {
  }

  internal void method_7(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_1.Name)
    {
      if (!this.panel_0.Visible)
        this.panel_0.Visible = true;
      else
        this.panel_0.Visible = false;
    }
    if (!(control2.Name == this.button_0.Name) || this.fileEventArg_0 == null || this.fileEventArg_0.Extension.ToLower() == ".txt")
      ;
  }

  internal void method_8(object sender, EventArgs e)
  {
    if (!this.radio_top.Checked)
      return;
    this.ViewType = ViewportViewType.Top;
  }

  internal void method_9(object sender, EventArgs e)
  {
    if (!this.radio_iso.Checked)
      return;
    this.ViewType = ViewportViewType.Isometric;
  }

  internal void method_10(object sender, EventArgs e)
  {
    if (!this.radio_trimetric.Checked)
      return;
    this.ViewType = ViewportViewType.Trimetric;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_1 != null ? 1 : 0)) != 0)
      this.icontainer_1.Dispose();
    base.Dispose(disposing);
  }

  public delegate void SelectFile(FileEventArg e);
}
