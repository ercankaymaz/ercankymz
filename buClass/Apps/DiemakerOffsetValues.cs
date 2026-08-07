// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerOffsetValues
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerOffsetValues : buSerilization
{
  public double LeftOffset = 0.0;
  public double RightOffset = 0.0;
  public DiemakerOffsetApplyType ApplyType = DiemakerOffsetApplyType.Left;
  public static List<string> Captions = new List<string>();

  public DiemakerOffsetValues()
  {
  }

  public DiemakerOffsetValues(DiemakerOffsetValues data)
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

  public static void Copy(DiemakerOffsetValues Source, ref DiemakerOffsetValues Target)
  {
    Target = new DiemakerOffsetValues(Source);
  }

  public override string ToString()
  {
    return $"LeftOffset : {this.LeftOffset.ToString()} - RightOffset : {this.RightOffset.ToString()} - ApplyType : {this.ApplyType.ToString()}";
  }
}
