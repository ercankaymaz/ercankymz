// Decompiled with JetBrains decompiler
// Type: buMotion.AxesGroupChar
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class AxesGroupChar : buSerilization
{
  public int AxY1;
  public int AxY2;
  public int AxZ1;
  public int AxZ2;
  public int AxZ3;
  public static byte f0000FD;
  public string AxX;
  public string AxY;
  public string AxZ;
  public string AxA;
  public string AxB;
  public string AxC;
  public string AxX1;

  public override string ToString()
  {
    string str1 = "";
    if (((AxesGroupIndex) this).AxX >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}X: {((AxesGroupIndex) this).AxX.ToString()}";
    }
    if (((AxesGroupIndex) this).AxY >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Y: {((AxesGroupIndex) this).AxY.ToString()}";
    }
    if (((AxesGroupIndex) this).AxZ >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Z: {((AxesGroupIndex) this).AxZ.ToString()}";
    }
    if (((AxesGroupIndex) this).AxA >= 0)
    {
      string str2;
      if (str1.Length > 0)
        str2 = str1 + " - ";
      str1 = str2 = "A: " + ((AxesGroupIndex) this).AxA.ToString();
    }
    if (((AxesGroupIndex) this).AxC >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}C: {((AxesGroupIndex) this).AxC.ToString()}";
    }
    if (((AxesGroupIndex) this).AxX1 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}X1: {((AxesGroupIndex) this).AxX1.ToString()}";
    }
    if (((AxesGroupIndex) this).AxX2 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}X2: {((AxesGroupIndex) this).AxX2.ToString()}";
    }
    if (this.AxY1 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Y1: {this.AxY1.ToString()}";
    }
    if (this.AxY2 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Y2: {this.AxY2.ToString()}";
    }
    if (this.AxZ1 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Z1: {this.AxZ1.ToString()}";
    }
    if (this.AxZ2 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Z2: {this.AxZ2.ToString()}";
    }
    if (this.AxZ3 >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 = $"{str1}Z3: {this.AxZ3.ToString()}";
    }
    return str1;
  }

  public AxesGroupChar()
  {
    ((AxesGroupIndex) this).AxX = -1;
    ((AxesGroupIndex) this).AxY = -1;
    ((AxesGroupIndex) this).AxZ = -1;
    ((AxesGroupIndex) this).AxA = -1;
    ((AxesGroupIndex) this).AxB = -1;
    ((AxesGroupIndex) this).AxC = -1;
    ((AxesGroupIndex) this).AxX1 = -1;
    ((AxesGroupIndex) this).AxX2 = -1;
    this.AxY1 = -1;
    this.AxY2 = -1;
    this.AxZ1 = -1;
    this.AxZ2 = -1;
    this.AxZ3 = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
