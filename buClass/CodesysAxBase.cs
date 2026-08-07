// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxBase : buSerilization
{
  public int baseNo = 0;
  public string baseName = "Axis";
  public string baseChar = "";
  public string baseUnit = "mm";
  public bool baseRotaryAxis = false;
  public bool baseEnable = true;
  public static List<string> Captions = new List<string>();

  public CodesysAxBase()
  {
  }

  public CodesysAxBase(CodesysAxBase data)
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
    return $"Name: {this.baseName.ToString()} , Char: {this.baseChar.ToString()} , No: {this.baseNo.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{$"{this.baseNo.ToString()};{this.baseName.ToString()};{this.baseChar.ToString()}"};{this.baseUnit.ToString()}"};{buSerilization.BoolToString(this.baseRotaryAxis)}";
  }
}
