// Decompiled with JetBrains decompiler
// Type: buClass.DigitalInputData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DigitalInputData : buSerilization
{
  public bool Status = false;
  public string Name = "";
  public string Caption = "";
  public string FullAddress = "";
  public bool Invert = false;
  public int SourceIndex = -1;

  public DigitalInputData()
  {
  }

  public DigitalInputData(string name) => this.Name = name;

  public DigitalInputData(string name, string caption, int sourceindex, bool inverted)
  {
    this.Name = name;
    this.Caption = caption;
    this.SourceIndex = sourceindex;
    this.Invert = inverted;
  }

  public DigitalInputData(
    string name,
    string caption,
    int sourceindex,
    bool inverted,
    string fulladdrsss)
  {
    this.Name = name;
    this.Caption = caption;
    this.SourceIndex = sourceindex;
    this.Invert = inverted;
    this.FullAddress = fulladdrsss;
  }

  public DigitalInputData(DigitalInputData data)
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
    string str = $"{this.Name} : {this.Status.ToString()}";
    if (this.SourceIndex >= 0)
      str = $"{str} - Index: {this.SourceIndex.ToString()}";
    if (this.Invert)
      str = $"{str} - Invert: {this.Invert.ToString()}";
    return str;
  }
}
