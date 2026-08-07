// Decompiled with JetBrains decompiler
// Type: buClass.InfoCount
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class InfoCount : buSerilization
{
  public string Info;
  public double Count;

  public InfoCount()
  {
  }

  public InfoCount(double count, string info)
  {
    this.Count = count;
    this.Info = info;
  }

  public InfoCount(InfoCount size)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) size, ref CopiedClass);
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

  public override string ToString()
  {
    return $"Info {this.Info.ToString()} - Count: {this.Count.ToString()}";
  }
}
