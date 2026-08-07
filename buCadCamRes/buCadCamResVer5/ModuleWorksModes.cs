// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.ModuleWorksModes
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5;

public class ModuleWorksModes
{
  public bool Wireframe = false;
  public bool Drill = false;
  public bool TriangleMeshBasic = false;
  public bool TriangleMeshAdvanced = false;

  public ModuleWorksModes()
  {
  }

  public ModuleWorksModes(ModuleWorksModes data)
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
