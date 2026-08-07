// Decompiled with JetBrains decompiler
// Type: buClass.FileEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class FileEventArg
{
  public string FileName = Application.StartupPath;
  public string FilePath = Application.StartupPath;
  public string JustFileName = "";
  public string JustFileNameWithoutExtension = "";
  public string Extension = "";
  public int Count = 1;

  public FileEventArg()
  {
  }

  public FileEventArg(string FileName)
  {
    this.FileName = FileName;
    this.JustFileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
    this.JustFileName = Path.GetFileName(FileName);
    this.FilePath = Path.GetDirectoryName(FileName);
  }

  public override string ToString() => this.JustFileName;
}
