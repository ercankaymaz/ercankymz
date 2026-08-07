// Decompiled with JetBrains decompiler
// Type: buClass.Apps.marbleCutItems
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class marbleCutItems : buSerilization
{
  public bool Enable = false;
  public double Length = 0.0;
  public int Count = 0;
  public double StartAngle = 0.0;
  public double EndAngle = 0.0;
  public static List<string> Captions = new List<string>();
  public static List<string> CaptionsUnits = new List<string>();

  public marbleCutItems()
  {
  }

  public marbleCutItems(marbleCutItems data)
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

  public static void Copy(marbleCutItems Source, ref marbleCutItems Target)
  {
    Target = new marbleCutItems(Source);
  }

  public static marbleCutItems Copy(marbleCutItems Source)
  {
    marbleCutItems Target = new marbleCutItems();
    marbleCutItems.Copy(Source, ref Target);
    return Target;
  }

  public static void Copy(List<marbleCutItems> Source, ref List<marbleCutItems> Target)
  {
    Source.Clear();
    for (int index = 0; index <= Source.Count - 1; ++index)
    {
      marbleCutItems Target1 = new marbleCutItems();
      marbleCutItems.Copy(Source[index], ref Target1);
      Target.Add(Target1);
    }
  }

  public override string ToString()
  {
    return $"Length : {this.Length.ToString()} , Count : {this.Count.ToString()} , Enable : {this.Enable.ToString()}";
  }
}
