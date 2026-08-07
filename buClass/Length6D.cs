// Decompiled with JetBrains decompiler
// Type: buClass.Length6D
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
public class Length6D : buSerilization
{
  public double dX = 0.0;
  public double dY = 0.0;
  public double dZ = 0.0;
  public double dA = 0.0;
  public double dB = 0.0;
  public double dC = 0.0;
  public static List<string> Captions = new List<string>();

  public Length6D()
  {
  }

  public Length6D(Length6D lengths)
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

  public Length6D(double dx, double dy, double dz)
  {
    this.dX = dx;
    this.dY = dy;
    this.dZ = dz;
  }

  public Length6D(double dx, double dy, double dz, double da, double db, double dc)
  {
    this.dX = dx;
    this.dY = dy;
    this.dZ = dz;
    this.dA = da;
    this.dB = db;
    this.dC = dc;
  }

  public override string ToString()
  {
    return $"dX: {this.dX.ToString("f4")} ; dY: {this.dY.ToString("f4")} ; dZ: {this.dZ.ToString("f4")} ; dA: {this.dA.ToString("f4")} ; dB: {this.dB.ToString("f4")} ; dC: {this.dC.ToString("f4")}";
  }

  public static Length6D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Length6D length6D = new Length6D();
      Value = Value.Replace("dX:", "");
      Value = Value.Replace("dY:", "");
      Value = Value.Replace("dZ:", "");
      Value = Value.Replace("dA:", "");
      Value = Value.Replace("dB:", "");
      Value = Value.Replace("dC:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        length6D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length6D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length6D.dZ = 0.0;
      }
      if (strArray.Length == 3)
      {
        length6D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length6D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length6D.dZ = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        length6D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length6D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length6D.dZ = double.Parse(strArray[2], (IFormatProvider) provider);
        length6D.dA = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        length6D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length6D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length6D.dZ = double.Parse(strArray[2], (IFormatProvider) provider);
        length6D.dA = double.Parse(strArray[3], (IFormatProvider) provider);
        length6D.dB = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        length6D.dX = double.Parse(strArray[0], (IFormatProvider) provider);
        length6D.dY = double.Parse(strArray[1], (IFormatProvider) provider);
        length6D.dZ = double.Parse(strArray[2], (IFormatProvider) provider);
        length6D.dA = double.Parse(strArray[3], (IFormatProvider) provider);
        length6D.dB = double.Parse(strArray[4], (IFormatProvider) provider);
        length6D.dC = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      return length6D;
    }
    catch (Exception ex)
    {
      return new Length6D();
    }
  }

  public string ToDef()
  {
    return $"dX: {this.dX.ToString()} ; dY: {this.dY.ToString()} ; dZ: {this.dZ.ToString()} ; dA: {this.dA.ToString()} ; dB: {this.dB.ToString()} ; dC: {this.dC.ToString()}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}dX:{this.dX.ToString("")}; dY:{this.dY.ToString("")}; dZ:{this.dZ.ToString("")} ; dA: {this.dA.ToString()} ; dB: {this.dB.ToString()} ; dC: {this.dC.ToString()}";
  }
}
