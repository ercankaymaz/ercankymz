// Decompiled with JetBrains decompiler
// Type: buClass.G3Properties
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class G3Properties : buSerilization
{
  public CodeUsing AuxCodeForFirstRisingG3 = new CodeUsing();
  public CodeUsing AuxCodeForAllG3 = new CodeUsing();

  public G3Properties()
  {
  }

  public G3Properties(G3Properties data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    this.AuxCodeForFirstRisingG3 = new CodeUsing(data.AuxCodeForFirstRisingG3);
    this.AuxCodeForAllG3 = new CodeUsing(data.AuxCodeForAllG3);
  }
}
