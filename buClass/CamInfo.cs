// Decompiled with JetBrains decompiler
// Type: buClass.CamInfo
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CamInfo : buSerilization
{
  public double TotalLength = 0.0;
  public double TotalProcessLength = 0.0;
  public double AirMoveLength = 0.0;
  public double TotalSecond = 0.0;
  public double ProcessSecond = 0.0;
  public double AirMoveSecond = 0.0;
  public double StartSecond = 0.0;
  public double EndSecond = 0.0;
  public string ProcessMinute = "";
  public string AllProcessTime = "";
  public double TotalOperationTimeSec = 0.0;
  public double TotalOperationDistance = 0.0;
  public double TotalOperationG1Distance = 0.0;
  public double TotalOperationG0Distance = 0.0;
  public static List<string> Captions = new List<string>();

  public CamInfo()
  {
  }

  public CamInfo(CamInfo info)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) info, ref CopiedClass);
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
    return $"Tot Len: {this.TotalLength.ToString("f3")} , Sec: {this.ProcessSecond.ToString()}";
  }
}
