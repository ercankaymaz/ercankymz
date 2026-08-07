// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoParameterTool
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TheoParameterTool : buSerilization
{
  public double No = 0.0;
  public string Name = "";
  public double Radius = 0.0;
  public double Mode1OverrideY = 100.0;
  public double MaxYPosition = 50.0;
  public List<TheoParameterItem> CornerBendingList = new List<TheoParameterItem>();
  public static List<string> Captions = new List<string>();

  public TheoParameterTool()
  {
  }

  public TheoParameterTool(TheoParameterTool data)
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
    this.CornerBendingList.Clear();
    for (int index = 0; index <= data.CornerBendingList.Count - 1; ++index)
      this.CornerBendingList.Add(new TheoParameterItem(data.CornerBendingList[index]));
  }

  public override string ToString() => "No: " + this.No.ToString();
}
