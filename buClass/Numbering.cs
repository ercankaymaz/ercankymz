// Decompiled with JetBrains decompiler
// Type: buClass.Numbering
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class Numbering : buSerilization
{
  public double Start = 1.0;
  public double Step = 1.0;
  public double Max = -1.0;
  public bool Enable = true;

  public Numbering()
  {
  }

  public Numbering(Numbering data)
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

  public Numbering(double start, double step, double max, bool enable)
  {
    this.Start = start;
    this.Step = step;
    this.Max = max;
    this.Enable = enable;
  }
}
