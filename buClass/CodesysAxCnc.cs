// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxCnc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxCnc : buSerilization
{
  public double cncMaxAccDec = 1000.0;
  public double cncMaxFeed = 100.0;
  public double cncMaxDifferance = 0.01;
  public bool cncIncludePathSettings = false;
  public bool cncStrictlyHoldAccDecABC = false;
  public static List<string> Captions = new List<string>();

  public CodesysAxCnc()
  {
  }

  public CodesysAxCnc(CodesysAxCnc data)
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

  public override string ToString() => "cncMaxAccDec: " + this.cncMaxAccDec.ToString();

  public string ToFileString(int Version)
  {
    return $"{$"{this.cncMaxAccDec.ToString()};{this.cncMaxFeed.ToString()};{this.cncMaxDifferance.ToString()}"};{buSerilization.BoolToString(this.cncIncludePathSettings)};{buSerilization.BoolToString(this.cncStrictlyHoldAccDecABC)}";
  }
}
