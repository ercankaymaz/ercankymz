// Decompiled with JetBrains decompiler
// Type: buControls.DialogBox.DialogBoxes
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Windows.Forms;

#nullable disable
namespace buControls.DialogBox;

public class DialogBoxes
{
  public static string FileName = "";

  public static DialogResult OpenImageFileDialog(string InitDir)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = InitDir;
    openFileDialog.Filter = "Image Files(*.bmp,*.png,*.jpg)|*.bmp;*.png;*.jpg";
    openFileDialog.FilterIndex = 1;
    openFileDialog.FileName = "";
    DialogResult dialogResult = openFileDialog.ShowDialog();
    DialogBoxes.FileName = "";
    if (dialogResult == DialogResult.OK)
      DialogBoxes.FileName = openFileDialog.FileName;
    return dialogResult;
  }
}
