// Decompiled with JetBrains decompiler
// Type: buClass.IJK
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class IJK : buSerilization
{
  public double I;
  public double J;
  public double K;

  public IJK()
  {
  }

  public IJK(IJK Pnt)
  {
    this.I = Pnt.I;
    this.J = Pnt.J;
    this.K = Pnt.K;
  }

  public IJK(double i, double j, double k)
  {
    this.I = i;
    this.J = j;
    this.K = k;
  }

  public static bool Equal(IJK RefP1, IJK RefP2) => RefP1.Equal(RefP2);

  public static bool Equal(IJK RefP1, IJK RefP2, double Resolution)
  {
    return RefP1.Equal(RefP2, Resolution);
  }

  public bool Equal(IJK RefP) => this.Equal(RefP, buSystem.resolutionCompare);

  public bool Equal(IJK RefP, double Resolution)
  {
    double num1 = this.I - RefP.I;
    double num2 = this.J - RefP.J;
    double num3 = this.K - RefP.K;
    return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3) < Resolution;
  }

  public static IJK Copy(IJK P) => new IJK(P.I, P.J, P.K);

  public static IJK[] Copy(IJK[] pts)
  {
    IJK[] ijkArray = new IJK[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      ijkArray[index] = IJK.Copy(pts[index]);
    return ijkArray;
  }

  public static List<IJK> Copy(List<IJK> pts)
  {
    List<IJK> ijkList = new List<IJK>();
    for (int index = 0; index < pts.Count; ++index)
      ijkList.Add(IJK.Copy(pts[index]));
    return ijkList;
  }

  public static void Copy(List<IJK> pts, ref List<IJK> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new IJK(IJK.Copy(pts[index])));
  }

  public static void Copy(List<IJK> pts, ref List<List<IJK>> CopiedPnt)
  {
    CopiedPnt.Clear();
    List<IJK> CopiedPnt1 = new List<IJK>();
    IJK.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Copy(List<List<IJK>> pts, ref List<List<IJK>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<IJK> ijkList1 = new List<IJK>();
      List<IJK> ijkList2 = IJK.Copy(pts[index]);
      CopiedPnt.Add(ijkList2);
    }
  }

  public static void Copy(List<IJK> pts, ref IJK[] CopiedPnt)
  {
    try
    {
      CopiedPnt = new IJK[pts.Count];
      if (pts.Count <= 0)
        return;
      for (int index = 0; index <= pts.Count - 1; ++index)
        CopiedPnt[index] = new IJK(pts[index]);
    }
    catch (Exception ex)
    {
    }
  }

  public static void Copy(List<List<IJK>> SourceList, ref List<IJK> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<IJK>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
          TargetList.Add(new IJK(SourceList[index1][index2]));
      }
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    return $"I:{this.I.ToString("")}; J:{this.J.ToString("")}; K:{this.K.ToString("")}";
  }

  public static IJK DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      IJK ijk = new IJK();
      Value = Value.Replace("I:", "");
      Value = Value.Replace("J:", "");
      Value = Value.Replace("K:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        ijk.I = double.Parse(strArray[0], (IFormatProvider) provider);
        ijk.J = double.Parse(strArray[1], (IFormatProvider) provider);
        ijk.K = 0.0;
      }
      if (strArray.Length > 2)
      {
        ijk.I = double.Parse(strArray[0], (IFormatProvider) provider);
        ijk.J = double.Parse(strArray[1], (IFormatProvider) provider);
        ijk.K = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      return ijk;
    }
    catch (Exception ex)
    {
      return new IJK();
    }
  }

  public string ToDef()
  {
    return $"I:{this.I.ToString("")}; J:{this.J.ToString("")}; K:{this.K.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}I:{this.I.ToString("")}; J:{this.J.ToString("")}; K:{this.K.ToString("")}";
  }
}
