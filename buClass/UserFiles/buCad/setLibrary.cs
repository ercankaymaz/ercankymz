// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setLibrary
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setLibrary : buSerilization
{
  public bool JoinAll = true;
  public bool MoveFromCenter = false;
  public bool ExtendOnlyNeighbor = false;
  public string pathLibrary = Application.StartupPath;

  public setLibrary()
  {
  }

  public setLibrary(setLibrary data)
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
