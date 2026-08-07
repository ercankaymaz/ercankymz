// Decompiled with JetBrains decompiler
// Type: buClass.Line3D
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
public class Line3D
{
  public Pnt3D Start = new Pnt3D();
  public Pnt3D End = new Pnt3D();

  public Line3D()
  {
  }

  public Line3D(Pnt3D StartPoint, Pnt3D EndPoint)
  {
    this.Start = new Pnt3D(StartPoint);
    this.End = new Pnt3D(EndPoint);
  }

  public Line3D(Line3D Line)
  {
    this.Start = new Pnt3D(Line.Start);
    this.End = new Pnt3D(Line.End);
  }

  public static Line3D Copy(Line3D P) => new Line3D(P.Start, P.End);

  public static Line3D[] Copy(Line3D[] pts)
  {
    Line3D[] line3DArray = new Line3D[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      line3DArray[index] = Line3D.Copy(pts[index]);
    return line3DArray;
  }

  public static List<Line3D> Copy(List<Line3D> pts)
  {
    List<Line3D> line3DList = new List<Line3D>();
    for (int index = 0; index < pts.Count; ++index)
      line3DList.Add(Line3D.Copy(pts[index]));
    return line3DList;
  }

  public static void Copy(List<Line3D> pts, ref List<Line3D> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(Line3D.Copy(pts[index]));
  }

  public override string ToString()
  {
    return $"Start  [ X:{this.Start.X.ToString("f4")}; Y:{this.Start.Y.ToString("f4")}; Z:{this.Start.Z.ToString("f4")} ]  |  End  [ X:{this.End.X.ToString("f4")}; Y:{this.End.Y.ToString("f4")}; Z:{this.End.Z.ToString("f4")} ]";
  }

  public static Line3D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo cultureInfo = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      string[] strArray = Value.Split('|');
      return strArray.Length == 2 ? new Line3D(new Pnt3D(Pnt3D.DecodeFromString(strArray[0])), new Pnt3D(Pnt3D.DecodeFromString(strArray[1]))) : new Line3D();
    }
    catch (Exception ex)
    {
      return new Line3D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.Start.X.ToString("")}; Y:{this.Start.Y.ToString("")}; Z:{this.Start.Z.ToString("")} | X:{this.End.X.ToString("")}; Y:{this.End.Y.ToString("")}; Z:{this.End.Z.ToString("")}";
  }

  public string ToDef(int Space)
  {
    return $"{new string(' ', Space)}X:{this.Start.X.ToString("")}; Y:{this.Start.Y.ToString("")}; Z:{this.Start.Z.ToString("")} | X:{this.End.X.ToString("")}; Y:{this.End.Y.ToString("")}; Z:{this.End.Z.ToString("")}";
  }
}
