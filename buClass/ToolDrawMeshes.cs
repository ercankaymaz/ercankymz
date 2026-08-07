// Decompiled with JetBrains decompiler
// Type: buClass.ToolDrawMeshes
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolDrawMeshes : buSerilization, IDisposable
{
  public List<TriangleIndex> TrianglesIndexCutter = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeCutter = new List<Pnt3D>();
  public List<TriangleIndex> TrianglesIndexLength = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeLength = new List<Pnt3D>();
  public List<TriangleIndex> TrianglesIndexSphere = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeSphere = new List<Pnt3D>();
  public List<TriangleIndex> TrianglesIndexHolder = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeHolder = new List<Pnt3D>();
  public List<TriangleIndex> TrianglesIndexArbor = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeArbor = new List<Pnt3D>();
  public List<TriangleIndex> TrianglesIndexAgregate = new List<TriangleIndex>();
  public List<Pnt3D> TrianglesVerticeAgregate = new List<Pnt3D>();
  private bool Disposed = false;

  public ToolDrawMeshes()
  {
  }

  public ToolDrawMeshes(ToolDrawMeshes data)
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
    this.TrianglesIndexArbor.Clear();
    this.TrianglesIndexArbor = new List<TriangleIndex>();
    TriangleIndex.Copy(data.TrianglesIndexArbor, ref this.TrianglesIndexArbor);
    this.TrianglesIndexCutter.Clear();
    this.TrianglesIndexCutter = new List<TriangleIndex>();
    TriangleIndex.Copy(data.TrianglesIndexCutter, ref this.TrianglesIndexCutter);
    this.TrianglesIndexHolder.Clear();
    this.TrianglesIndexHolder = new List<TriangleIndex>();
    TriangleIndex.Copy(data.TrianglesIndexHolder, ref this.TrianglesIndexHolder);
    this.TrianglesIndexLength.Clear();
    this.TrianglesIndexLength = new List<TriangleIndex>();
    TriangleIndex.Copy(data.TrianglesIndexLength, ref this.TrianglesIndexLength);
    this.TrianglesIndexSphere.Clear();
    this.TrianglesIndexSphere = new List<TriangleIndex>();
    TriangleIndex.Copy(data.TrianglesIndexSphere, ref this.TrianglesIndexSphere);
    this.TrianglesVerticeArbor.Clear();
    this.TrianglesVerticeArbor = new List<Pnt3D>();
    Pnt3D.Copy(data.TrianglesVerticeArbor, ref this.TrianglesVerticeArbor);
    this.TrianglesVerticeCutter.Clear();
    this.TrianglesVerticeCutter = new List<Pnt3D>();
    Pnt3D.Copy(data.TrianglesVerticeCutter, ref this.TrianglesVerticeCutter);
    this.TrianglesVerticeHolder.Clear();
    this.TrianglesVerticeHolder = new List<Pnt3D>();
    Pnt3D.Copy(data.TrianglesVerticeHolder, ref this.TrianglesVerticeHolder);
    this.TrianglesVerticeLength.Clear();
    this.TrianglesVerticeLength = new List<Pnt3D>();
    Pnt3D.Copy(data.TrianglesVerticeLength, ref this.TrianglesVerticeLength);
    this.TrianglesVerticeSphere.Clear();
    this.TrianglesVerticeSphere = new List<Pnt3D>();
    Pnt3D.Copy(data.TrianglesVerticeSphere, ref this.TrianglesVerticeSphere);
  }

  ~ToolDrawMeshes() => this.Dispose(false);

  public void Clear()
  {
    this.TrianglesIndexCutter.Clear();
    this.TrianglesIndexArbor.Clear();
    this.TrianglesIndexHolder.Clear();
    this.TrianglesIndexLength.Clear();
    this.TrianglesIndexSphere.Clear();
    this.TrianglesVerticeArbor.Clear();
    this.TrianglesVerticeCutter.Clear();
    this.TrianglesVerticeHolder.Clear();
    this.TrianglesVerticeLength.Clear();
    this.TrianglesVerticeSphere.Clear();
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  private void Dispose(bool disposing)
  {
    if (this.Disposed)
      return;
    if (disposing)
    {
      this.TrianglesIndexCutter.Clear();
      this.TrianglesIndexArbor.Clear();
      this.TrianglesIndexHolder.Clear();
      this.TrianglesIndexLength.Clear();
      this.TrianglesIndexSphere.Clear();
      this.TrianglesVerticeArbor.Clear();
      this.TrianglesVerticeCutter.Clear();
      this.TrianglesVerticeHolder.Clear();
      this.TrianglesVerticeLength.Clear();
      this.TrianglesVerticeSphere.Clear();
    }
    this.Disposed = true;
  }
}
