// Decompiled with JetBrains decompiler
// Type: buClass.camAxesLimits
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camAxesLimits : buSerilization
{
  public Pnt9D MaxLimit = new Pnt9D();
  public Pnt9D MinLimit = new Pnt9D();

  public camAxesLimits()
  {
  }

  public camAxesLimits(Pnt9D minLimit, Pnt9D maxLimit)
  {
    this.MinLimit = new Pnt9D(minLimit);
    this.MaxLimit = new Pnt9D(maxLimit);
  }

  public camAxesLimits(camAxesLimits Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
