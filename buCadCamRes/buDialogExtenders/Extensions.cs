// Decompiled with JetBrains decompiler
// Type: buDialogExtenders.Extensions
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.DialogBox;
using ns8;
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
    return Class5.smethod_69(fdlg, ctrl, owner) != DialogResult.OK ? (FileDialogControlBase.SubFolderSelected ? DialogResult.OK : DialogResult.Ignore) : DialogResult.OK;
  }
}
