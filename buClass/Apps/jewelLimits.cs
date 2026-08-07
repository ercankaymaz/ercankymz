// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelLimits
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class jewelLimits : buSerilization
{
  public double MinX = 0.0;
  public double MaxX = 0.0;
  public double MinY = 0.0;
  public double MaxY = 0.0;
  public double MinZ = 0.0;
  public double MaxZ = 0.0;
  public double MinA = 0.0;
  public double MaxA = 0.0;
  public double MinB = 0.0;
  public double MaxB = 0.0;
  public double MinC = 0.0;
  public double MaxC = 0.0;

  public jewelLimits()
  {
  }

  public jewelLimits(jewelLimits data)
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

  public override string ToString() => "Min X: " + this.MinX.ToString();
}
