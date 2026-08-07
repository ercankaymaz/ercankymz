// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerSelectAllParts
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerSelectAllParts : buSerilization
{
  public double PtValue = 2.0;
  public bool SelectAll = true;
  public bool SelectVertical = true;
  public bool SelectHorizontal = true;
  public bool SelectAngle = true;
  public bool SelectHeight = true;
  public bool SelectNegative = true;
  public static List<string> Captions = new List<string>();

  public DiemakerSelectAllParts()
  {
  }

  public DiemakerSelectAllParts(DiemakerSelectAllParts data)
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

  public static void Copy(DiemakerSelectAllParts Source, ref DiemakerSelectAllParts Target)
  {
    Target = new DiemakerSelectAllParts(Source);
  }

  public override string ToString()
  {
    return $"PtValue : {this.PtValue.ToString()} - SelectAll : {this.SelectAll.ToString()}";
  }
}
