// Decompiled with JetBrains decompiler
// Type: buClass.InfoType
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
public class InfoType : buSerilization
{
  public string InfoName = "";
  public string Message = "";
  public string Axis = "";
  public int Code = 0;
  public double Value = 0.0;
  public bool ShowLabel = true;
  public DateTime Time = DateTime.Now;
  public Color ColorInfo = Color.Gold;
  public InfoTypeMode Mode = InfoTypeMode.None;
  public InfoTypeCodes CodeType = InfoTypeCodes.None;

  public InfoType()
  {
  }

  public InfoType(InfoType data)
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

  public InfoType(string name, string message, int code, double value, DateTime time)
  {
    this.InfoName = name;
    this.Message = message;
    this.Code = code;
    this.Value = value;
    this.Time = time;
  }

  public InfoType(
    string name,
    string message,
    int code,
    double value,
    DateTime time,
    InfoTypeMode mode,
    Color color)
  {
    this.InfoName = name;
    this.Message = message;
    this.Code = code;
    this.Value = value;
    this.Time = time;
    this.Mode = mode;
    this.ColorInfo = color;
  }

  public InfoType(
    string name,
    string message,
    int code,
    double value,
    DateTime time,
    InfoTypeMode mode,
    InfoTypeCodes codetype,
    string axis,
    Color color)
  {
    this.InfoName = name;
    this.Message = message;
    this.Code = code;
    this.Value = value;
    this.Time = time;
    this.Mode = mode;
    this.ColorInfo = color;
    this.CodeType = codetype;
    this.Axis = axis;
  }

  public static void Copy(List<InfoType> baseList, ref List<InfoType> copyList)
  {
    for (int index = 0; index <= baseList.Count - 1; ++index)
      copyList.Add(new InfoType(baseList[index]));
  }

  public override string ToString()
  {
    return $"{this.Mode.ToString()} : {this.Message} - Code: {this.Code.ToString()}";
  }
}
