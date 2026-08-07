// Decompiled with JetBrains decompiler
// Type: buClass.ToolData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolData : buSerilization
{
  public string Name = "Tool";
  public int No = 1;
  public int Sector = 1;
  public int HeightOffsetIndex = 0;
  public string Tag = "";
  public bool Clone = false;
  public int CloneToolNo = 1;
  public bool Broken = false;
  public double MaxUsageHour = 100.0;
  public double ActiveUsageHour = 0.0;
  public bool TimeLimitExceed = false;
  public int Priority = 10;
  public bool isAgregateLeft = false;
  public bool isAgregate = false;
  public int GroupIndex = -1;
  public int GroupItemIndex = -1;
  public double LengthCorrection = 0.0;
  public double DepthOffset = 0.0;

  public ToolData()
  {
  }

  public ToolData(ToolData data)
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
    return $"Name: {this.Name.ToString()} - No: {this.No.ToString()} - Sector: {this.Sector.ToString()}";
  }
}
