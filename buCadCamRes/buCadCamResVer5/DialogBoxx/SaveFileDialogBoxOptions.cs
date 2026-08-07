// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.DialogBoxx.SaveFileDialogBoxOptions
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.ClassViewer;
using buDialogExtenders;
using buEyeBaseVer5;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.DialogBoxx;

[ToolboxItem(false)]
public class SaveFileDialogBoxOptions : FileDialogControlBase
{
  public bool SubFolder = false;
  public FileSaveModes Properties = new FileSaveModes();
  public List<string> Extensions = new List<string>();
  public static string SelectedFolder = Application.StartupPath;
  private FileEventArg fileEventArg_0 = (FileEventArg) null;
  private IContainer icontainer_1 = (IContainer) null;
  internal Button button_0;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal RadioButton radioButton_2;
  public CheckBox chk_savetools;
  public CheckBox chk_saveselected;
  internal Panel panel_1;

  public SaveFileDialogBoxOptions() => Class5.smethod_123(this);

  public void Init()
  {
    if (!this.Properties.SaveGeometry & !this.Properties.SaveTessellation)
    {
      this.Properties.SaveGeometry = true;
      this.Properties.SaveTessellation = true;
    }
    if (this.Properties.SaveGeometry & this.Properties.SaveTessellation)
      this.radioButton_0.Checked = true;
    if (this.Properties.SaveGeometry & !this.Properties.SaveTessellation)
      this.radioButton_2.Checked = true;
    if (!this.Properties.SaveGeometry & this.Properties.SaveTessellation)
      this.radioButton_1.Checked = true;
    this.chk_saveselected.Checked = this.Properties.SaveSelected;
    this.chk_savetools.Checked = this.Properties.SaveTools;
  }

  public event SaveFileDialogBoxOptions.SelectFile FileSelect;

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
      SaveFileDialogBoxOptions.SelectedFolder = this.fileEventArg_0.FilePath;
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

  internal void method_4(object sender, CancelEventArgs e)
  {
  }

  internal void method_5(IWin32Window iwin32Window_0, string string_6)
  {
    SaveFileDialogBoxOptions.SelectedFolder = string_6;
  }

  internal void method_6(object sender, HelpEventArgs e)
  {
  }

  internal void method_7(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == this.button_0.Name))
      return;
    if (this.fileEventArg_0 != null)
    {
      if (this.fileEventArg_0.Extension.ToLower() == ".bucadv5")
      {
        this.panel_1.Left = 2;
        if (!this.panel_1.Visible)
          this.panel_1.Visible = true;
        else
          this.panel_1.Visible = false;
      }
      if (!(this.fileEventArg_0.Extension.ToLower() == ".dxf" | this.fileEventArg_0.Extension.ToLower() == ".dwg"))
        return;
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Settings";
      classViewerDialog.Value = (object) clsVar.varAutoCadFileProps;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsVar.varAutoCadFileProps = new WriteDxfDwgPropeties((WriteDxfDwgPropeties) classViewerDialog.Value);
      clsFiles.SaveParameter();
    }
    else
      buString5.MessageBoxInfo(AppLanguage.CadCamMessages[131]);
  }

  internal void method_8(object sender, EventArgs e)
  {
    this.Properties.SaveTools = this.chk_savetools.Checked;
  }

  internal void method_9(object sender, EventArgs e)
  {
    this.Properties.SaveSelected = this.chk_saveselected.Checked;
  }

  internal void method_10(object sender, EventArgs e)
  {
    if (this.radioButton_2.Checked)
    {
      this.Properties.SaveGeometry = true;
      this.Properties.SaveTessellation = false;
    }
    if (this.radioButton_1.Checked)
    {
      this.Properties.SaveGeometry = false;
      this.Properties.SaveTessellation = true;
    }
    if (!this.radioButton_0.Checked)
      return;
    this.Properties.SaveGeometry = true;
    this.Properties.SaveTessellation = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_1 != null ? 1 : 0)) != 0)
      this.icontainer_1.Dispose();
    base.Dispose(disposing);
  }

  public delegate void SelectFile(FileEventArg e);
}
