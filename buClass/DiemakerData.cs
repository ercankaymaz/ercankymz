// Decompiled with JetBrains decompiler
// Type: buClass.DiemakerData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DiemakerData : buSerilization
{
  public double Pt = 2.0;
  public double PtReal = 2.0;
  public DiemakerType DiemakerType = DiemakerType.Cutting;
  public int DiemakerTYpeAsInteger = 0;
  public double RuleHeight = 0.0;
  public bool IsBridge = false;
  public bool IsNick = false;
  public bool IsBroach = false;
  public bool IsSameEntity = false;
  public bool IsMirrorEntity = false;

  public DiemakerData()
  {
  }

  public DiemakerData(DiemakerData data)
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

  public override string ToString() => $"Pt: {this.Pt.ToString()} - {this.DiemakerType.ToString()}";
}
