// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoNoToolData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TheoNoToolData
{
  public double Radius = 0.0;
  public double MaleTool = 0.0;
  public double FemaleTool = 0.0;
  public double YPosition = 0.0;
  public string Explanation = "";
  public static List<string> Captions = new List<string>();

  public TheoNoToolData()
  {
  }

  public TheoNoToolData(TheoNoToolData data)
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

  public override string ToString()
  {
    return $"Radius: {this.Radius.ToString()} - MaleTool: {this.MaleTool.ToString()} - FemaleTool: {this.FemaleTool.ToString()} - Y Position: {this.YPosition.ToString()}";
  }
}
