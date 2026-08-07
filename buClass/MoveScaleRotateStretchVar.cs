// Decompiled with JetBrains decompiler
// Type: buClass.MoveScaleRotateStretchVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MoveScaleRotateStretchVar : buSerilization
{
  public double MoveX = 1.0;
  public double MoveY = 1.0;
  public double MoveZ = 1.0;
  public double Rotate = 5.0;
  public double Scale = 1.0;
  public double StretchX = 1.0;
  public double StretchY = 1.0;
  public double XConstantValue = 0.0;
  public double YConstantValue = 0.0;
  public bool XConstantEnable = false;
  public bool YConstantEnable = false;
  public double RangeMinX = 0.0;
  public double RangeMaxX = 0.0;
  public double RangeMinY = 0.0;
  public double RangeMaxY = 0.0;
  public static List<string> Captions = new List<string>();

  public MoveScaleRotateStretchVar()
  {
  }

  public MoveScaleRotateStretchVar(MoveScaleRotateStretchVar data)
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
}
