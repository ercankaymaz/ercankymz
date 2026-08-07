// Decompiled with JetBrains decompiler
// Type: buClass.Triangle3D
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
public class Triangle3D
{
  public Pnt3D FirstPoint = new Pnt3D();
  public Pnt3D SecondPoint = new Pnt3D();
  public Pnt3D ThirdPoint = new Pnt3D();

  public Triangle3D()
  {
  }

  public Triangle3D(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint)
  {
    this.FirstPoint = new Pnt3D(FirstPoint);
    this.SecondPoint = new Pnt3D(SecondPoint);
    this.ThirdPoint = new Pnt3D(ThirdPoint);
  }

  public Triangle3D(Triangle3D Triangle)
  {
    this.FirstPoint = new Pnt3D(Triangle.FirstPoint);
    this.SecondPoint = new Pnt3D(Triangle.SecondPoint);
    this.ThirdPoint = new Pnt3D(Triangle.ThirdPoint);
  }

  public static Triangle3D Copy(Triangle3D P)
  {
    return new Triangle3D(P.FirstPoint, P.SecondPoint, P.ThirdPoint);
  }

  public static Triangle3D[] Copy(Triangle3D[] pts)
  {
    Triangle3D[] triangle3DArray = new Triangle3D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      triangle3DArray[index] = Triangle3D.Copy(pts[index]);
    return triangle3DArray;
  }

  public static List<Triangle3D> Copy(List<Triangle3D> pts)
  {
    List<Triangle3D> triangle3DList = new List<Triangle3D>();
    for (int index = 0; index < pts.Count; ++index)
      triangle3DList.Add(Triangle3D.Copy(pts[index]));
    return triangle3DList;
  }

  public static void Copy(List<Triangle3D> pts, ref List<Triangle3D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Triangle3D.Copy(pts[index]));
  }

  public static void Add(List<Triangle3D> pts, ref List<Triangle3D> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Triangle3D.Copy(pts[index]));
  }

  public override string ToString()
  {
    return $"First  [ X:{this.FirstPoint.X.ToString("f4")}; Y:{this.FirstPoint.Y.ToString("f4")}; Z:{this.FirstPoint.Z.ToString("f4")} ]  |  Second  [ X:{this.SecondPoint.X.ToString("f4")}; Y:{this.SecondPoint.Y.ToString("f4")}; Z:{this.SecondPoint.Z.ToString("f4")} ]  |  Third  [ X:{this.ThirdPoint.X.ToString("f4")}; Y:{this.ThirdPoint.Y.ToString("f4")}; Z:{this.ThirdPoint.Z.ToString("f4")} ]";
  }

  public static Triangle3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo cultureInfo = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      string[] strArray = Value.Split('|');
      return strArray.Length == 3 ? new Triangle3D(new Pnt3D(Pnt3D.DecodeFromString(strArray[0])), new Pnt3D(Pnt3D.DecodeFromString(strArray[1])), new Pnt3D(Pnt3D.DecodeFromString(strArray[2]))) : new Triangle3D();
    }
    catch (Exception ex)
    {
      return new Triangle3D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.FirstPoint.X.ToString("")}; Y:{this.FirstPoint.Y.ToString("")}; Z:{this.FirstPoint.Z.ToString("")} | X:{this.SecondPoint.X.ToString("")}; Y:{this.SecondPoint.Y.ToString("")}; Z:{this.SecondPoint.Z.ToString("")} | X:{this.ThirdPoint.X.ToString("")}; Y:{this.ThirdPoint.Y.ToString("")}; Z:{this.ThirdPoint.Z.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.FirstPoint.X.ToString("")}; Y:{this.FirstPoint.Y.ToString("")}; Z:{this.FirstPoint.Z.ToString("")} | X:{this.SecondPoint.X.ToString("")}; Y:{this.SecondPoint.Y.ToString("")}; Z:{this.SecondPoint.Z.ToString("")} | X:{this.ThirdPoint.X.ToString("")}; Y:{this.ThirdPoint.Y.ToString("")}; Z:{this.ThirdPoint.Z.ToString("")}";
  }
}
