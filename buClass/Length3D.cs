// Decompiled with JetBrains decompiler
// Type: buClass.Length3D
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class Length3D : buSerilization
{
  public double dX = 0.0;
  public double dY = 0.0;
  public double dZ = 0.0;
  public static List<string> Captions = new List<string>();

  public Length3D()
  {
  }

  public Length3D(Length3D lengths)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) lengths, ref CopiedClass);
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

  public Length3D(double dx, double dy, double dz)
  {
    this.dX = dx;
    this.dY = dy;
    this.dZ = dz;
  }

  public override string ToString()
  {
    return $"dX: {this.dX.ToString("f4")} ; dY: {this.dY.ToString("f4")} ; dZ: {this.dZ.ToString("f4")}";
  }

  public static Length3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Length3D length3D = new Length3D();
      Value = Value.Replace("dX:", "");
      Value = Value.Replace("dY:", "");
      Value = Value.Replace("dZ:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        length3D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length3D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length3D.dZ = 0.0;
      }
      if (strArray.Length > 2)
      {
        length3D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length3D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length3D.dZ = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      return length3D;
    }
    catch (Exception ex)
    {
      return new Length3D();
    }
  }

  public string ToDef()
  {
    return $"dX: {this.dX.ToString()} ; dY: {this.dY.ToString()} ; dZ: {this.dZ.ToString()}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}dX:{this.dX.ToString("")}; dY:{this.dY.ToString("")}; dZ:{this.dZ.ToString("")}";
  }
}
