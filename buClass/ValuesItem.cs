// Decompiled with JetBrains decompiler
// Type: buClass.ValuesItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class ValuesItem : buSerilization
{
  public string Name = "";
  public bool Bool1 = false;
  public bool Bool2 = false;
  public bool Bool3 = false;
  public bool Bool4 = false;
  public double Value1 = 0.0;
  public double Value2 = 0.0;
  public double Value3 = 0.0;
  public double Value4 = 0.0;
  public double Value5 = 0.0;
  public double Value6 = 0.0;

  public ValuesItem()
  {
  }

  public ValuesItem(ValuesItem data)
  {
    this.Bool1 = data.Bool1;
    this.Bool2 = data.Bool2;
    this.Bool3 = data.Bool3;
    this.Bool4 = data.Bool4;
    this.Value1 = data.Value1;
    this.Value2 = data.Value2;
    this.Value3 = data.Value3;
    this.Value4 = data.Value4;
    this.Value5 = data.Value5;
    this.Value6 = data.Value6;
    this.Name = data.Name;
  }

  public ValuesItem(string name, double value1)
  {
    this.Name = name;
    this.Value1 = value1;
  }

  public ValuesItem(string name, bool bool1, double value1, double value2)
  {
    this.Name = name;
    this.Bool1 = bool1;
    this.Value1 = value1;
    this.Value2 = value2;
  }

  public ValuesItem(string name, bool bool1, double value1, double value2, double value3)
  {
    this.Name = name;
    this.Bool1 = bool1;
    this.Value1 = value1;
    this.Value2 = value2;
    this.Value3 = value3;
  }

  public ValuesItem(
    string name,
    bool bool1,
    double value1,
    double value2,
    double value3,
    double value4)
  {
    this.Name = name;
    this.Bool1 = bool1;
    this.Value1 = value1;
    this.Value2 = value2;
    this.Value3 = value3;
    this.Value4 = value4;
  }

  public ValuesItem(
    string name,
    bool bool1,
    bool bool2,
    double value1,
    double value2,
    double value3,
    double value4)
  {
    this.Name = name;
    this.Bool1 = bool1;
    this.Bool2 = bool2;
    this.Value1 = value1;
    this.Value2 = value2;
    this.Value3 = value3;
    this.Value4 = value4;
  }

  public override string ToString()
  {
    string str = "";
    if (this.Name.Length > 0)
      $"{$"{str}{this.Name}: "}V1: {this.Value1.ToString()} - V2: {this.Value2.ToString()} - V3: {this.Value2.ToString()} - V4: {this.Value2.ToString()} - B1: {this.Bool1.ToString()} - B2: {this.Bool2.ToString()}";
    return base.ToString();
  }
}
