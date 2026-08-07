// Decompiled with JetBrains decompiler
// Type: buClass.camOptions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camOptions : buSerilization
{
  public bool SelectAllPoints = false;
  public bool SelectAllDrawings = false;
  public double PocketNextContourMaxDistance = 10.0;
  public camAxesLimits AxesLimit = new camAxesLimits();
  public static List<string> Captions = new List<string>();

  public camOptions()
  {
  }

  public camOptions(camOptions data)
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
    ((camOptions) CopiedClass).AxesLimit = new camAxesLimits(data.AxesLimit);
  }

  public override string ToString() => "SelectAllPoints: " + this.SelectAllPoints.ToString();
}
