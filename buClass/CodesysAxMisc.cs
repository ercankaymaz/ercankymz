// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxMisc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxMisc : buSerilization
{
  public double TestPosition1 = 20.0;
  public double TestPosition2 = 1000.0;
  public double TestWaitTime = 1000.0;
  public double TestReleativePosition = 2500.0;
  public static List<string> Captions = new List<string>();

  public CodesysAxMisc()
  {
  }

  public CodesysAxMisc(CodesysAxMisc data)
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
    return $"Pos1 : {this.TestPosition1.ToString()} , Pos2: {this.TestPosition2.ToString()}";
  }

  public string ToFileString(int Version)
  {
    return $"{$"{this.TestPosition1.ToString()};{this.TestPosition2.ToString()};{this.TestWaitTime.ToString()}"};{this.TestReleativePosition.ToString()}";
  }
}
