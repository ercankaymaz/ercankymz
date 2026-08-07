// Decompiled with JetBrains decompiler
// Type: buClass.FileSaveModes
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class FileSaveModes : buSerilization
{
  public int FileFilterIndex = 0;
  public string InitPath = Application.StartupPath;
  public bool SaveTools = true;
  public bool SaveGeometry = false;
  public bool SaveTessellation = true;
  public bool SaveSelected = false;
  public string TxtFileSeperatorChar = ";";
  public bool TxtFileIsSeperatorCharSpace = true;
  public string InitPathBuCadV5 = Application.StartupPath;
  public string InitPathBuCadV4 = Application.StartupPath;
  public string InitPathDwc = Application.StartupPath;
  public string InitPathDxf = Application.StartupPath;
  public string InitPathDwg = Application.StartupPath;
  public string InitPathCnc = Application.StartupPath;
  public string InitPathStep = Application.StartupPath;
  public string InitPathIges = Application.StartupPath;
  public string InitPathStl = Application.StartupPath;
  public string InitPathXyz = Application.StartupPath;
  public string InitPathObj = Application.StartupPath;
  public string InitPathPly = Application.StartupPath;
  public string InitPathCf2 = Application.StartupPath;
  public string InitPathAsc = Application.StartupPath;
  public string InitPathDwf = Application.StartupPath;
  public string InitPathIfc = Application.StartupPath;
  public string InitPathJt = Application.StartupPath;
  public string InitPathPdf = Application.StartupPath;
  public string InitPath3dc = Application.StartupPath;
  public string InitPathLucas = Application.StartupPath;
  public string InitPathMedit = Application.StartupPath;
  public string InitPathNastran = Application.StartupPath;
  public string InitPathRcp = Application.StartupPath;
  public string InitPathRcs = Application.StartupPath;

  public FileSaveModes()
  {
  }

  public FileSaveModes(FileSaveModes data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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
}
