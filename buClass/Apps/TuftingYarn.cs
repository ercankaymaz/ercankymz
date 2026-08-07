// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftingYarn
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftingYarn : buSerilization
{
  public string Name = "";
  public double HundredMeterPerGram = 10.0;
  public double Kat = 1.0;
  public static List<string> Captions = new List<string>();

  public TuftingYarn()
  {
  }

  public TuftingYarn(TuftingYarn data)
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

  public static void Copy(TuftingYarn Base, ref TuftingYarn Copied)
  {
    Copied = new TuftingYarn(Base);
  }

  public static void Copy(List<TuftingYarn> Base, ref List<TuftingYarn> Copied)
  {
    Copied.Clear();
    Copied = new List<TuftingYarn>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add(new TuftingYarn(Base[index]));
  }

  public static List<TuftingYarn> Copy(List<TuftingYarn> Base)
  {
    List<TuftingYarn> tuftingYarnList = new List<TuftingYarn>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      tuftingYarnList.Add(new TuftingYarn(Base[index]));
    return tuftingYarnList;
  }

  public override string ToString()
  {
    return $"{this.Name} ; Gram : {this.HundredMeterPerGram.ToString()} ; Kat: {this.Kat.ToString()}";
  }
}
