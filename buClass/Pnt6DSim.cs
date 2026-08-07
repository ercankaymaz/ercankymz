// Decompiled with JetBrains decompiler
// Type: buClass.Pnt6DSim
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
public class Pnt6DSim : Pnt6D
{
  public double FeedRate;
  public double SpindleRpm;
  public double ToolNo;
  public string ToolName;
  public Pnt3D Offset = new Pnt3D();
  public int Index = -1;
  public bool isMCode = false;
  public int MCode = -1;

  public Pnt6DSim()
  {
  }

  public Pnt6DSim(Pnt6DSim Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
    this.FeedRate = Pnt.FeedRate;
    this.SpindleRpm = Pnt.SpindleRpm;
    this.ToolNo = Pnt.ToolNo;
    this.ToolName = Pnt.ToolName;
    this.Offset = new Pnt3D(Pnt.Offset);
    this.Index = Pnt.Index;
  }

  public Pnt6DSim(Pnt6D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public Pnt6DSim(Pnt9D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Pnt.A;
    this.B = Pnt.B;
    this.C = Pnt.C;
  }

  public Pnt6DSim(Pnt9DCam Pnt)
  {
    this.X = Pnt.P9.X;
    this.Y = Pnt.P9.Y;
    this.Z = Pnt.P9.Z;
    this.A = Pnt.P9.A;
    this.B = Pnt.P9.B;
    this.C = Pnt.P9.C;
    this.FeedRate = Pnt.Feed;
    this.SpindleRpm = Pnt.SpindleSpeed;
    this.ToolNo = Pnt.ToolNo;
  }

  public Pnt6DSim(Pnt3D Pnt)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
  }

  public Pnt6DSim(Pnt3D Pnt, double a, double b, double c)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public Pnt6DSim(Pnt3D Pnt, OrientationAngle Angles)
  {
    this.X = Pnt.X;
    this.Y = Pnt.Y;
    this.Z = Pnt.Z;
    this.A = Angles.A;
    this.B = Angles.B;
    this.C = Angles.C;
  }

  public Pnt6DSim(double x, double y, double z, double a, double b, double c)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
  }

  public Pnt6DSim(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double f,
    double t,
    double s,
    Pnt3D offset)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.FeedRate = f;
    this.SpindleRpm = s;
    this.ToolNo = t;
    this.Offset = new Pnt3D(offset);
  }

  public Pnt6DSim(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double f,
    double t,
    double s,
    Pnt3D offset,
    int index,
    string toolname)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = a;
    this.B = b;
    this.C = c;
    this.FeedRate = f;
    this.SpindleRpm = s;
    this.ToolNo = t;
    this.Offset = new Pnt3D(offset);
    this.Index = index;
    this.ToolName = toolname;
  }

  public Pnt6DSim(double x, double y, double z)
  {
    this.X = x;
    this.Y = y;
    this.Z = z;
    this.A = 0.0;
    this.B = 0.0;
    this.C = 0.0;
  }

  public override int GetHashCode() => base.GetHashCode();

  public static Pnt6DSim Copy(Pnt6DSim P)
  {
    return new Pnt6DSim(P.X, P.Y, P.Z, P.A, P.B, P.C, P.FeedRate, P.ToolNo, P.SpindleRpm, P.Offset, P.Index, P.ToolName);
  }

  public static Pnt6DSim[] Copy(Pnt6DSim[] pts)
  {
    Pnt6DSim[] pnt6DsimArray = new Pnt6DSim[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt6DsimArray[index] = Pnt6DSim.Copy(pts[index]);
    return pnt6DsimArray;
  }

  public static List<Pnt6DSim> Copy(List<Pnt6DSim> pts)
  {
    List<Pnt6DSim> pnt6DsimList = new List<Pnt6DSim>();
    for (int index = 0; index < pts.Count; ++index)
      pnt6DsimList.Add(Pnt6DSim.Copy(pts[index]));
    return pnt6DsimList;
  }

  public static void Copy(List<Pnt6DSim> pts, ref List<Pnt6DSim> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6DSim(Pnt6DSim.Copy(pts[index])));
  }

  public static void Copy(List<Pnt3D> pts, ref List<Pnt6DSim> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6DSim(pts[index]));
  }

  public static void Copy(List<List<Pnt6DSim>> pts, ref List<List<Pnt6DSim>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6DSim> pnt6DsimList1 = new List<Pnt6DSim>();
      List<Pnt6DSim> pnt6DsimList2 = Pnt6DSim.Copy(pts[index]);
      CopiedPnt.Add(pnt6DsimList2);
    }
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6DSim>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6DSim> CopiedPnt1 = new List<Pnt6DSim>();
      Pnt6DSim.Copy(pts[index], ref CopiedPnt1);
      CopiedPnt.Add(CopiedPnt1);
    }
  }

  public static void Copy(
    List<Pnt3D> pts,
    OrientationAngle Orientation,
    ref List<Pnt6DSim> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(new Pnt6DSim(new Pnt3D(pts[index]), new OrientationAngle(Orientation)));
  }

  public static void Add(List<Pnt6DSim> pts, ref List<Pnt6DSim> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Pnt6DSim.Copy(pts[index]));
  }

  public static void Add(List<Pnt6DSim> pts, ref List<List<Pnt6DSim>> CopiedPnt)
  {
    List<Pnt6DSim> CopiedPnt1 = new List<Pnt6DSim>();
    Pnt6DSim.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(List<List<Pnt6DSim>> SourceList, ref List<List<Pnt6DSim>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pnt6DSim> CopiedPnt = new List<Pnt6DSim>();
        Pnt6DSim.Copy(SourceList[index], ref CopiedPnt);
        TargetList.Add(CopiedPnt);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    return $"X:{this.X.ToString("f4")}; Y:{this.Y.ToString("f4")}; Z:{this.Z.ToString("f4")}; A:{this.A.ToString("f4")}; B:{this.B.ToString("f4")}; C:{this.C.ToString("f4")}; F:{this.FeedRate.ToString("f2")}; S:{this.SpindleRpm.ToString("f2")}; T:{this.ToolNo.ToString("f0")}";
  }

  public static Pnt6DSim DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt6DSim pnt6Dsim = new Pnt6DSim();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("A:", "");
      Value = Value.Replace("B:", "");
      Value = Value.Replace("C:", "");
      Value = Value.Replace("F:", "");
      Value = Value.Replace("S:", "");
      Value = Value.Replace("T:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6Dsim.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length >= 6)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6Dsim.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt6Dsim.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length >= 7)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6Dsim.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt6Dsim.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt6Dsim.FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length >= 8)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6Dsim.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt6Dsim.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt6Dsim.FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt6Dsim.SpindleRpm = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt6Dsim.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt6Dsim.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt6Dsim.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt6Dsim.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt6Dsim.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt6Dsim.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt6Dsim.FeedRate = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt6Dsim.SpindleRpm = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt6Dsim.ToolNo = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      return pnt6Dsim;
    }
    catch (Exception ex)
    {
      return new Pnt6DSim();
    }
  }

  public new string ToDef()
  {
    return $"X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; F:{this.FeedRate.ToString()}; S:{this.SpindleRpm.ToString()}; T:{this.ToolNo.ToString()}";
  }

  public new string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.X.ToString()}; Y:{this.Y.ToString()}; Z:{this.Z.ToString()}; A:{this.A.ToString()}; B:{this.B.ToString()}; C:{this.C.ToString()}; F:{this.FeedRate.ToString()}; S:{this.SpindleRpm.ToString()}; T:{this.ToolNo.ToString()}";
  }
}
