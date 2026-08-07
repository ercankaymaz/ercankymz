// Decompiled with JetBrains decompiler
// Type: buClass.FileItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class FileItem : buSerilization
{
  public string FileFullName = Application.StartupPath;
  public string FileName = "";
  public string FileNameWithoutExtension = "";
  public string FileFolder = Application.StartupPath;
  public bool Enable = true;
  public List<FileSubItem> SubFiles = new List<FileSubItem>();

  public FileItem()
  {
  }

  public FileItem(string FullFileName)
  {
    this.FileFullName = FullFileName;
    this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FullFileName);
    this.FileName = Path.GetFileName(FullFileName);
  }

  public FileItem(FileItem data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.SubFiles.Clear();
    for (int index = 0; index <= data.SubFiles.Count - 1; ++index)
      this.SubFiles.Add(new FileSubItem(data.SubFiles[index]));
  }

  public override string ToString() => this.FileNameWithoutExtension;
}
