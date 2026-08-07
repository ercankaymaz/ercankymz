// Decompiled with JetBrains decompiler
// Type: buClass.RulRule
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class RulRule : buSerilization
{
  public int No = 0;
  public List<Pnt3D> Position = new List<Pnt3D>();

  public RulRule()
  {
  }

  public RulRule(RulRule data)
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
    this.Position.Clear();
    for (int index = 0; index <= data.Position.Count - 1; ++index)
      this.Position.Add(new Pnt3D(data.Position[index]));
  }

  public override string ToString() => "No : " + this.No.ToString();
}
