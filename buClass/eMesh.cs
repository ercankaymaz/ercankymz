// Decompiled with JetBrains decompiler
// Type: buClass.eMesh
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class eMesh : eEntities
{
  public List<TriangleIndex> TriIndex = new List<TriangleIndex>();

  public eMesh()
  {
  }

  public eMesh(eEntities ent)
  {
    this.TriIndex.Clear();
    for (int index = 0; index <= ((eMesh) ent).TriIndex.Count - 1; ++index)
      this.TriIndex.Add(new TriangleIndex(((eMesh) ent).TriIndex[index]));
    this.Vertice.Clear();
    this.Vertice = new List<Pnt3D>();
    for (int index = 0; index <= ent.Vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(ent.Vertice[index]));
    if (!(ent.GetType() == typeof (eMesh)))
      return;
    if (ent.Triangles != null)
    {
      if (this.Triangles == null)
        this.Triangles = new List<Triangle3D>();
      this.Triangles.Clear();
      this.Triangles = new List<Triangle3D>();
      for (int index = 0; index <= ent.Triangles.Count - 1; ++index)
      {
        this.Triangles.Add(new Triangle3D(ent.Triangles[index]));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
      }
    }
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public eMesh(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= trianglesindex.Count - 1; ++index)
      this.TriIndex.Add(new TriangleIndex(trianglesindex[index]));
    for (int index = 0; index <= vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertices[index]));
    this.Update();
  }

  public eMesh(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices, Color Color)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= trianglesindex.Count - 1; ++index)
      this.TriIndex.Add(new TriangleIndex(trianglesindex[index]));
    for (int index = 0; index <= vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertices[index]));
    this.dispColor = Color;
    this.Update();
  }

  public static eMesh DecodeMesh(List<string> Codes)
  {
    eMesh RefObject = new eMesh();
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
