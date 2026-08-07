// Decompiled with JetBrains decompiler
// Type: buClass.ToolDrawVertices
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolDrawVertices : buSerilization
{
  public List<Triangle3D> TrianglesCutter = new List<Triangle3D>();
  public List<Triangle3D> TrianglesLength = new List<Triangle3D>();
  public List<Triangle3D> TrianglesSphere = new List<Triangle3D>();
  public List<Triangle3D> TrianglesHolder = new List<Triangle3D>();
  public List<Triangle3D> TrianglesArbor = new List<Triangle3D>();
  public List<List<Pnt3D>> Vertices = new List<List<Pnt3D>>();

  public ToolDrawVertices()
  {
  }

  public ToolDrawVertices(ToolDrawVertices data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.TrianglesHolder.Clear();
    this.TrianglesHolder = new List<Triangle3D>();
    Triangle3D.Copy(data.TrianglesHolder, ref this.TrianglesHolder);
    this.TrianglesCutter.Clear();
    this.TrianglesCutter = new List<Triangle3D>();
    Triangle3D.Copy(data.TrianglesCutter, ref this.TrianglesCutter);
    this.TrianglesArbor.Clear();
    this.TrianglesArbor = new List<Triangle3D>();
    Triangle3D.Copy(data.TrianglesArbor, ref this.TrianglesArbor);
    this.TrianglesLength.Clear();
    this.TrianglesLength = new List<Triangle3D>();
    Triangle3D.Copy(data.TrianglesLength, ref this.TrianglesLength);
    this.TrianglesSphere.Clear();
    this.TrianglesSphere = new List<Triangle3D>();
    Triangle3D.Copy(data.TrianglesSphere, ref this.TrianglesSphere);
    this.Vertices.Clear();
    this.Vertices = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.Vertices, ref this.Vertices);
  }
}
