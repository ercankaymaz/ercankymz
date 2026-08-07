// Decompiled with JetBrains decompiler
// Type: buClass.Pnt9DCam
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class Pnt9DCam
{
  public ArrayList PreCodes = new ArrayList();
  public ArrayList AfterCodes = new ArrayList();
  public double Feed;
  public int Type = 0;
  public double Radius = 0.0;
  public geoArc ArcData = new geoArc();
  public bool IsArc = false;
  public int ArcType = 0;
  public double ToolNo = 1.0;
  public double SpindleSpeed = 0.0;
  public bool LeaveAxisMovement = false;
  public bool PlungeAxisMovement = false;
  public string PlungeAxis = "Z";
  public double PlungeValue = 0.0;
  public CamPlungeActionType PlungeAction = CamPlungeActionType.None;
  public bool DontUseAdditionalCommand = false;
  public AxesEnableWithUVW EnableAxes = new AxesEnableWithUVW(true, true, true, true, true, true, true, true, true);
  public Pnt9D P9 = new Pnt9D();
  public Pnt9D Offsets = new Pnt9D();

  public Pnt9DCam()
  {
  }

  public Pnt9DCam(double x, double y, double z)
  {
    this.P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
  }

  public Pnt9DCam(double x, double y, double z, double feed, int type)
  {
    this.P9 = new Pnt9D(x, y, z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public Pnt9DCam(double x, double y, double z, double a, double b, double c)
  {
    this.P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
  }

  public Pnt9DCam(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double feed,
    int type)
  {
    this.P9 = new Pnt9D(x, y, z, a, b, c, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public Pnt9DCam(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double u,
    double v,
    double w)
  {
    this.P9 = new Pnt9D(x, y, z, a, b, c, u, v, w);
  }

  public Pnt9DCam(Pnt3D P, OrientationAngle Orientation, double feed, int type)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, Orientation.A, Orientation.B, Orientation.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public Pnt9DCam(Pnt6D P) => this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);

  public Pnt9DCam(Pnt6D P, double feed, int type)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
  }

  public Pnt9DCam(Pnt6D P, double feed, int type, bool plungemove)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
  }

  public Pnt9DCam(Pnt6D P, double feed, int type, bool plungemove, bool Leavemove)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
    this.LeaveAxisMovement = Leavemove;
  }

  public Pnt9DCam(Pnt9D P) => this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);

  public Pnt9DCam(Pnt9D P, double feed, int type)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
  }

  public Pnt9DCam(Pnt9D P, double feed, int type, bool plungemove)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
  }

  public Pnt9DCam(Pnt9D P, double feed, int type, bool plungemove, bool Leavemove)
  {
    this.P9 = new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
    this.Feed = feed;
    this.Type = type;
    this.PlungeAxisMovement = plungemove;
    this.LeaveAxisMovement = Leavemove;
  }

  public Pnt9DCam(Pnt9DCam Pnt)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Pnt, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.P9 = new Pnt9D(Pnt.P9);
    this.ArcData = new geoArc(Pnt.ArcData);
    this.AfterCodes.Clear();
    this.PreCodes.Clear();
    for (int index = 0; index <= Pnt.AfterCodes.Count - 1; ++index)
      this.AfterCodes.Add(Pnt.AfterCodes[index]);
    for (int index = 0; index <= Pnt.PreCodes.Count - 1; ++index)
      this.PreCodes.Add(Pnt.PreCodes[index]);
  }

  public static Pnt9DCam Copy(Pnt9DCam P) => new Pnt9DCam(P);

  public static Pnt9DCam[] Copy(Pnt9DCam[] pts)
  {
    Pnt9DCam[] pnt9DcamArray = new Pnt9DCam[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt9DcamArray[index] = Pnt9DCam.Copy(pts[index]);
    return pnt9DcamArray;
  }

  public static List<Pnt9DCam> Copy(List<Pnt9DCam> pts)
  {
    List<Pnt9DCam> pnt9DcamList = new List<Pnt9DCam>();
    for (int index = 0; index < pts.Count; ++index)
      pnt9DcamList.Add(Pnt9DCam.Copy(pts[index]));
    return pnt9DcamList;
  }

  public override string ToString()
  {
    string str1 = $"X:{this.P9.X.ToString("f4")} ; Y:{this.P9.Y.ToString("f4")} ; Z:{this.P9.Z.ToString("f4")}";
    if (this.P9.A != 0.0)
      str1 = $"{str1} ; A:{this.P9.A.ToString("f4")}";
    if (this.P9.B != 0.0)
      str1 = $"{str1} ; B:{this.P9.B.ToString("f4")}";
    if (this.P9.C != 0.0)
      str1 = $"{str1} ; C:{this.P9.C.ToString("f4")}";
    if (this.P9.U != 0.0)
      str1 = $"{str1} ; U:{this.P9.U.ToString("f4")}";
    if (this.P9.V != 0.0)
      str1 = $"{str1}; V:{this.P9.V.ToString("f4")}";
    if (this.P9.W != 0.0)
      str1 = $"{str1}; W:{this.P9.W.ToString("f4")}";
    if (this.Radius != 0.0)
      str1 = $"{str1}; R:{this.Radius.ToString("f3")}";
    string str2 = $"{str1}; Feed: {this.Feed.ToString()} ; Type: {this.Type.ToString()}";
    if (this.PlungeAxisMovement)
      str2 = $"{str2}; Plunge: {this.PlungeAxis}";
    return str2;
  }

  public static Pnt9D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt9D pnt9D = new Pnt9D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length == 7)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length == 8)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt9D.W = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      return pnt9D;
    }
    catch (Exception ex)
    {
      return new Pnt9D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.P9.X.ToString()}; Y:{this.P9.Y.ToString()}; Z:{this.P9.Z.ToString()}; A:{this.P9.A.ToString()}; B:{this.P9.B.ToString()}; C:{this.P9.C.ToString()}; U:{this.P9.U.ToString()}; V:{this.P9.V.ToString()}; W:{this.P9.W.ToString()}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.P9.X.ToString()}; Y:{this.P9.Y.ToString()}; Z:{this.P9.Z.ToString()}; A:{this.P9.A.ToString()}; B:{this.P9.B.ToString()}; C:{this.P9.C.ToString()}; U:{this.P9.U.ToString()}; V:{this.P9.V.ToString()}; W:{this.P9.W.ToString()}";
  }
}
