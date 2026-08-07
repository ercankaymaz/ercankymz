// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.FileOpenModesOptions
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5;

public class FileOpenModesOptions
{
  public bool buCadVer5 = false;
  public bool buCadVer4 = false;
  public bool DrawWorks = false;
  public bool Dxf = false;
  public bool Dwg = false;
  public bool Dwf = false;
  public bool Asc = false;
  public bool cf2 = false;
  public bool cnc = false;
  public bool Iges = false;
  public bool Icf = false;
  public bool Jt = false;
  public bool Las = false;
  public bool Lucas = false;
  public bool Nastran = false;
  public bool Obj = false;
  public bool Pdf = false;
  public bool Ply = false;
  public bool Rcp = false;
  public bool Rcs = false;
  public bool Step = false;
  public bool Stl = false;
  public bool Xyz = false;
  public bool Medit = false;
  public bool _3DS = false;
  public double Mode1 = 0.0;
  public double Mode2 = 0.0;
  public string Mode3 = "";
  public string Mode4 = "";
  public string Mode1Exp = "";
  public string Mode2Exp = "";
  public string Mode3Exp = "";
  public string Mode4Exp = "";

  public FileOpenModesOptions()
  {
  }

  public FileOpenModesOptions(FileOpenModesOptions data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
