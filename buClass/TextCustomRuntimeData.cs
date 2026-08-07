// Decompiled with JetBrains decompiler
// Type: buClass.TextCustomRuntimeData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class TextCustomRuntimeData : ShapeData
{
  public double Height = 30.0;
  public double CharSpace = 5.0;
  public double SpaceValue = 30.0;
  public string Text = "buCad";
  public ContentAlignment Alignment = ContentAlignment.BottomLeft;
  public static List<string> Captions = new List<string>();

  public TextCustomRuntimeData()
  {
  }

  public TextCustomRuntimeData(TextCustomRuntimeData data)
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
