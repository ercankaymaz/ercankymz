// Decompiled with JetBrains decompiler
// Type: buClass.RulProperties
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class RulProperties : buSerilization
{
  public string Version = "";
  public string Author = "";
  public string Date = "";
  public string Time = "";
  public string Unit = "";
  public string RuleTable = "";
  public string SampleSize = "";
  public int NumberOfSize = 0;
  public List<string> SizeList = new List<string>();
  public List<RulRule> RuleList = new List<RulRule>();

  public RulProperties()
  {
  }

  public RulProperties(RulProperties data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    this.RuleList.Clear();
    this.RuleList.Clear();
    for (int index = 0; index <= data.RuleList.Count - 1; ++index)
      this.RuleList.Add(new RulRule(data.RuleList[index]));
  }

  public override string ToString() => "Sample Size : " + this.SampleSize;
}
