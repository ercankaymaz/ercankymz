// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionLangDefination
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

[Serializable]
public static class buMotionLangDefination
{
  public string AxX2;
  public string AxY1;
  public string AxY2;
  public string AxZ1;
  public string AxZ2;
  public string AxZ3;
  public static byte f00010B;

  public abstract void m000079();

  public override string ToString()
  {
    string str1 = "";
    if (((AxesGroupChar) this).AxX.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += ((AxesGroupChar) this).AxX.ToString();
    }
    if (((AxesGroupChar) this).AxY.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += ((AxesGroupChar) this).AxY.ToString();
    }
    if (((AxesGroupChar) this).AxZ.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += ((AxesGroupChar) this).AxZ.ToString();
    }
    if (((AxesGroupChar) this).AxA.Length >= 0)
    {
      string str2;
      if (str1.Length > 0)
        str2 = str1 + " - ";
      str1 = str2 = ((AxesGroupChar) this).AxA.ToString();
    }
    if (((AxesGroupChar) this).AxC.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += ((AxesGroupChar) this).AxC.ToString();
    }
    if (((AxesGroupChar) this).AxX1.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += ((AxesGroupChar) this).AxX1.ToString();
    }
    if (this.AxX2.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxX2.ToString();
    }
    if (this.AxY1.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxY1.ToString();
    }
    if (this.AxY2.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxY2.ToString();
    }
    if (this.AxZ1.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxZ1.ToString();
    }
    if (this.AxZ2.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxZ2.ToString();
    }
    if (this.AxZ3.Length >= 0)
    {
      if (str1.Length > 0)
        str1 += " - ";
      str1 += this.AxZ3.ToString();
    }
    return str1;
  }

  public buMotionLangDefination()
  {
    ((AxesGroupChar) this).AxX = "";
    ((AxesGroupChar) this).AxY = "";
    ((AxesGroupChar) this).AxZ = "";
    ((AxesGroupChar) this).AxA = "";
    ((AxesGroupChar) this).AxB = "";
    ((AxesGroupChar) this).AxC = "";
    ((AxesGroupChar) this).AxX1 = "";
    this.AxX2 = "";
    this.AxY1 = "";
    this.AxY2 = "";
    this.AxZ1 = "";
    this.AxZ2 = "";
    this.AxZ3 = "";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m00007C();

  public static void LoadStatus(List<string> SL)
  {
    string str = nameof (LoadStatus);
    try
    {
      if (SL.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionStatusLang.sClassName, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }

  public static void LoadError(List<string> SL)
  {
    string str = nameof (LoadError);
    try
    {
      if (SL.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionStatusLang.sClassName, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }

  public static void LoadWarning(List<string> SL)
  {
    string str = nameof (LoadWarning);
    try
    {
      if (SL.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionStatusLang.sClassName, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }
}
