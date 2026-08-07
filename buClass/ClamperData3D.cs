// Decompiled with JetBrains decompiler
// Type: buClass.ClamperData3D
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ClamperData3D : buSerilization
{
  public double Width = 100.0;
  public double TipPointHeight = 120.0;
  public double ConstantPointHeight = 120.0;
  public double TipPointThickness = 30.0;
  public double ConstantPointThickness = 60.0;
  public double BottomThickness = 20.0;

  public ClamperData3D()
  {
  }

  public ClamperData3D(ClamperData3D data)
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
