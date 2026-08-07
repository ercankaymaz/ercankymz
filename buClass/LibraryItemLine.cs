// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemLine
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemLine : LibraryItem
{
  public double Length = 0.0;
  public double Angle = 0.0;
  public Pnt3D PointStart = new Pnt3D();
  public Pnt3D PointEnd = new Pnt3D();

  public LibraryItemLine()
  {
  }

  public LibraryItemLine(LibraryItemLine data)
  {
    this.PointStart = new Pnt3D(data.PointStart);
    this.PointEnd = new Pnt3D(data.PointEnd);
    this.Length = data.Length;
    this.Angle = data.Angle;
  }

  public LibraryItemLine(Pnt3D startpoint, Pnt3D endpoint, double length, double angle)
  {
    this.PointStart = new Pnt3D(startpoint);
    this.PointEnd = new Pnt3D(endpoint);
    this.Length = length;
    this.Angle = angle;
  }

  public override string ToString()
  {
    return $"Line :  [X:{this.PointStart.X.ToString("f3")} Y:{this.PointStart.Y.ToString("f3")} Z:{this.PointStart.Z.ToString("f3")}] -  [X:{this.PointEnd.X.ToString("f3")} Y:{this.PointEnd.Y.ToString("f3")} Z:{this.PointEnd.Z.ToString("f3")}]";
  }
}
