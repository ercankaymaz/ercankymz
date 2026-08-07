// Decompiled with JetBrains decompiler
// Type: buClass.camOperationEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camOperationEnable : buSerilization
{
  public bool Height = true;
  public bool Direction = true;
  public static List<string> Captions = new List<string>();

  public camOperationEnable()
  {
  }

  public camOperationEnable(bool height, bool direction)
  {
    this.Height = height;
    this.Direction = direction;
  }

  public camOperationEnable(camOperationEnable Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    return $"Height: {this.Height.ToString()} , Direction: {this.Direction.ToString()}";
  }
}
