// Decompiled with JetBrains decompiler
// Type: buClass.eSolid3D
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class eSolid3D : eEntities
{
  public eSolid3D() => this.Triangles = new List<Triangle3D>();

  public eSolid3D(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eSolid3D)))
      return;
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= ent.Triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(ent.Triangles[index]));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
    }
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public eSolid3D(List<Triangle3D> triangles)
  {
    this.Triangles = new List<Triangle3D>();
    this.Vertice.Clear();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].ThirdPoint));
    }
    this.Update();
  }

  public eSolid3D(List<Triangle3D> triangles, Color Color)
  {
    this.Triangles = new List<Triangle3D>();
    this.Triangles.Clear();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].ThirdPoint));
    }
    this.dispColor = Color;
    this.Update();
  }

  public static eSolid3D DecodeSolid(List<string> Codes)
  {
    eSolid3D RefObject = new eSolid3D();
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariableValuesFromStringCodes(Codes, (object) RefObject, ref Vars);
    if (Vars.Count > 0)
    {
      object ObjPar = (object) RefObject;
      buSerilization.SetClassVariables(ref ObjPar, Vars);
    }
    RefObject.Update();
    return RefObject;
  }
}
