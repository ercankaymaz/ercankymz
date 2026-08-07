// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItemPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItemPoint : LibraryItem
{
  public Pnt3D PointStart = new Pnt3D();

  public LibraryItemPoint()
  {
  }

  public LibraryItemPoint(LibraryItemPoint data) => this.PointStart = new Pnt3D(data.PointStart);

  public LibraryItemPoint(Pnt3D startpoint) => this.PointStart = new Pnt3D(startpoint);

  public override string ToString()
  {
    return $"Point :  [X:{this.PointStart.X.ToString("f3")} Y:{this.PointStart.Y.ToString("f3")} Z:{this.PointStart.Z.ToString("f3")}]";
  }
}
