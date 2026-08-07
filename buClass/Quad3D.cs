// Decompiled with JetBrains decompiler
// Type: buClass.Quad3D
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
public class Quad3D
{
  public Pnt3D FirstPoint = new Pnt3D();
  public Pnt3D SecondPoint = new Pnt3D();
  public Pnt3D ThirdPoint = new Pnt3D();
  public Pnt3D FourthPoint = new Pnt3D();

  public Quad3D()
  {
  }

  public Quad3D(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, Pnt3D FourthPoint)
  {
    this.FirstPoint = new Pnt3D(FirstPoint);
    this.SecondPoint = new Pnt3D(SecondPoint);
    this.ThirdPoint = new Pnt3D(ThirdPoint);
    this.FourthPoint = new Pnt3D(FourthPoint);
  }

  public Quad3D(Quad3D Quad)
  {
    this.FirstPoint = new Pnt3D(Quad.FirstPoint);
    this.SecondPoint = new Pnt3D(Quad.SecondPoint);
    this.ThirdPoint = new Pnt3D(Quad.ThirdPoint);
    this.FourthPoint = new Pnt3D(Quad.FourthPoint);
  }

  public static Quad3D Copy(Quad3D P)
  {
    return new Quad3D(P.FirstPoint, P.SecondPoint, P.ThirdPoint, P.FourthPoint);
  }

  public static Quad3D[] Copy(Quad3D[] pts)
  {
    Quad3D[] quad3DArray = new Quad3D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      quad3DArray[index] = Quad3D.Copy(pts[index]);
    return quad3DArray;
  }

  public static List<Quad3D> Copy(List<Quad3D> pts)
  {
    List<Quad3D> quad3DList = new List<Quad3D>();
    for (int index = 0; index < pts.Count; ++index)
      quad3DList.Add(Quad3D.Copy(pts[index]));
    return quad3DList;
  }

  public static void Copy(List<Quad3D> pts, ref List<Quad3D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Quad3D.Copy(pts[index]));
  }

  public static bool IsValid(Quad3D quad)
  {
    try
    {
      if (quad == null)
        return false;
      Pnt3D MinPoint = new Pnt3D();
      Pnt3D MidPoint = new Pnt3D();
      Pnt3D MaxPoint = new Pnt3D();
      Pnt3D.BoxSizeOfPoint(new List<Pnt3D>()
      {
        new Pnt3D(quad.FirstPoint),
        new Pnt3D(quad.SecondPoint),
        new Pnt3D(quad.ThirdPoint),
        new Pnt3D(quad.FourthPoint)
      }, ref MinPoint, ref MidPoint, ref MaxPoint);
      return !(MinPoint == MaxPoint);
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public override string ToString()
  {
    return $"First  [ X:{this.FirstPoint.X.ToString("f4")}; Y:{this.FirstPoint.Y.ToString("f4")}; Z:{this.FirstPoint.Z.ToString("f4")} ]  |  Second  [ X:{this.SecondPoint.X.ToString("f4")}; Y:{this.SecondPoint.Y.ToString("f4")}; Z:{this.SecondPoint.Z.ToString("f4")} ]  |  Third  [ X:{this.ThirdPoint.X.ToString("f4")}; Y:{this.ThirdPoint.Y.ToString("f4")}; Z:{this.ThirdPoint.Z.ToString("f4")} ]  |  Fourth  [ X:{this.FourthPoint.X.ToString("f4")}; Y:{this.FourthPoint.Y.ToString("f4")}; Z:{this.FourthPoint.Z.ToString("f4")} ]";
  }

  public static Quad3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo cultureInfo = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      string[] strArray = Value.Split('|');
      return strArray.Length == 4 ? new Quad3D(new Pnt3D(Pnt3D.DecodeFromString(strArray[0])), new Pnt3D(Pnt3D.DecodeFromString(strArray[1])), new Pnt3D(Pnt3D.DecodeFromString(strArray[2])), new Pnt3D(Pnt3D.DecodeFromString(strArray[3]))) : new Quad3D();
    }
    catch (Exception ex)
    {
      return new Quad3D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.FirstPoint.X.ToString("")}; Y:{this.FirstPoint.Y.ToString("")}; Z:{this.FirstPoint.Z.ToString("")} | X:{this.SecondPoint.X.ToString("")}; Y:{this.SecondPoint.Y.ToString("")}; Z:{this.SecondPoint.Z.ToString("")} | X:{this.ThirdPoint.X.ToString("")}; Y:{this.ThirdPoint.Y.ToString("")}; Z:{this.ThirdPoint.Z.ToString("")} | X:{this.FourthPoint.X.ToString("")}; Y:{this.FourthPoint.Y.ToString("")}; Z:{this.FourthPoint.Z.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.FirstPoint.X.ToString("")}; Y:{this.FirstPoint.Y.ToString("")}; Z:{this.FirstPoint.Z.ToString("")} | X:{this.SecondPoint.X.ToString("")}; Y:{this.SecondPoint.Y.ToString("")}; Z:{this.SecondPoint.Z.ToString("")} | X:{this.ThirdPoint.X.ToString("")}; Y:{this.ThirdPoint.Y.ToString("")}; Z:{this.ThirdPoint.Z.ToString("")} | X:{this.FourthPoint.X.ToString("")}; Y:{this.FourthPoint.Y.ToString("")}; Z:{this.FourthPoint.Z.ToString("")}";
  }
}
