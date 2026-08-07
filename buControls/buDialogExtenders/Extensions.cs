// Decompiled with JetBrains decompiler
// Type: buDialogExtenders.Extensions
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.DialogBox;
using ns7;
using System.Windows.Forms;
using Win32Types;

#nullable disable
namespace buDialogExtenders;

public static class Extensions
{
  public static DialogResult ShowDialog(
    this FileDialog fdlg,
    FileDialogControlBase ctrl,
    IWin32Window owner)
  {
    ctrl.FileDlgType = fdlg is SaveFileDialog ? FileDialogType.SaveFileDlg : FileDialogType.OpenFileDlg;
    OpenFileDialogBoxPreviewWithSubFolder.SelectedFolder = fdlg.InitialDirectory;
    return Class39.smethod_340(fdlg, ctrl, owner) != DialogResult.OK ? (FileDialogControlBase.SubFolderSelected ? DialogResult.OK : DialogResult.Ignore) : DialogResult.OK;
  }
}
