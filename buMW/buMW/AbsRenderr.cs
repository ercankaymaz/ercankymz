// Decompiled with JetBrains decompiler
// Type: buMW.AbsRenderr
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buMW;

public class AbsRenderr : IndexedAbstractRenderer
{
  public const mwTriangleMeshBasedTpCalcParamsPattern TcbTmbRotary = mwTriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ | mwTriangleMeshBasedTpCalcParamsPattern.TcTmbProjection;
  public const mwTriangleMeshBasedTpCalcParamsPattern TcTmbTrochoidal = mwTriangleMeshBasedTpCalcParamsPattern.TcTmbConstantCusp | mwTriangleMeshBasedTpCalcParamsPattern.TcTmbProjection;
  public static Dictionary<int, List<RenderedTriangle>> Triangles;
  public static Dictionary<int, List<RenderedLine>> Lines;
  public static Dictionary<int, bool> Visiblity;
  public static List<TriangleIndex> MeshTriangles;

  public AbsRenderr(ModuleWorksMeshData data)
  {
    ((ModuleWorksMeshData) this).Triangles = new List<TriangleIndex>();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices = new List<Pnt3D>();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals = new List<Pnt3D>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
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
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals.Clear();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices.Clear();
    ((ModuleWorksMeshData) this).Triangles.Clear();
    Pnt3D.Copy(((mwTriangleMeshBasedTpCalcParamsPattern) data).Normals, ref ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals);
    Pnt3D.Copy(((mwTriangleMeshBasedTpCalcParamsPattern) data).Vertices, ref ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices);
    for (int index = 0; index <= data.Triangles.Count - 1; ++index)
      ((ModuleWorksMeshData) this).Triangles.Add(new TriangleIndex(data.Triangles[index].V1, data.Triangles[index].V2, data.Triangles[index].V3));
  }

  public AbsRenderr(List<Pnt3D> vertices, List<TriangleIndex> triangles, List<Pnt3D> normals)
  {
    ((ModuleWorksMeshData) this).Triangles = new List<TriangleIndex>();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices = new List<Pnt3D>();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals = new List<Pnt3D>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals.Clear();
    ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices.Clear();
    ((ModuleWorksMeshData) this).Triangles.Clear();
    Pnt3D.Copy(normals, ref ((mwTriangleMeshBasedTpCalcParamsPattern) this).Normals);
    Pnt3D.Copy(vertices, ref ((mwTriangleMeshBasedTpCalcParamsPattern) this).Vertices);
    for (int index = 0; index <= triangles.Count - 1; ++index)
      ((ModuleWorksMeshData) this).Triangles.Add(new TriangleIndex(triangles[index].V1, triangles[index].V2, triangles[index].V3));
  }

  public override void DeleteGroup(int groupId)
  {
  }

  public override void DrawLines(int groupId, RenderedLineVertex[] vertices, int[] indices)
  {
    AbsRenderr.Lines[groupId] = new List<RenderedLine>();
    for (int index = 0; index <= indices.Length - 1; index += 2)
    {
      RenderedLine renderedLine = new RenderedLine();
      RenderedLineVertex vertex1 = vertices[indices[index]];
      RenderedLineVertex vertex2 = vertices[indices[index + 1]];
      renderedLine.Vertices = new RenderedVector[2]
      {
        new RenderedVector(vertex1.Position.X, vertex1.Position.Y, vertex1.Position.Z)
        {
          Color = vertex1.VertexColor
        },
        new RenderedVector(vertex2.Position.X, vertex2.Position.Y, vertex2.Position.Z)
        {
          Color = vertex2.VertexColor
        }
      };
      AbsRenderr.Lines[groupId].Add(renderedLine);
    }
  }

  public override void DrawTriangles(
    int groupId,
    RenderedTriangleVertex[] vertices,
    int[] indices,
    VertexAttributes attributes)
  {
    AbsRenderr.Triangles[groupId] = new List<RenderedTriangle>();
    for (int index = 0; index <= vertices.Length - 1; ++index)
      buMwCutSim.MeshVertices.Add(new Pnt3D((double) vertices[index].Position.X, (double) vertices[index].Position.Y, (double) vertices[index].Position.Z));
    for (int index = 0; index <= indices.Length - 1; index += 3)
    {
      RenderedTriangle renderedTriangle = new RenderedTriangle();
      RenderedTriangleVertex vertex1 = vertices[indices[index]];
      RenderedTriangleVertex vertex2 = vertices[indices[index + 1]];
      RenderedTriangleVertex vertex3 = vertices[indices[index + 2]];
      AbsRenderr.MeshTriangles.Add(new TriangleIndex()
      {
        V1 = indices[index],
        V2 = indices[index + 1],
        V3 = indices[index + 2]
      });
      renderedTriangle.Vertices = new RenderedVector[3]
      {
        new RenderedVector(vertex1.Position.X, vertex1.Position.Y, vertex1.Position.Z)
        {
          Color = vertex1.VertexColor
        },
        new RenderedVector(vertex2.Position.X, vertex2.Position.Y, vertex2.Position.Z)
        {
          Color = vertex2.VertexColor
        },
        new RenderedVector(vertex3.Position.X, vertex3.Position.Y, vertex3.Position.Z)
        {
          Color = vertex3.VertexColor
        }
      };
      renderedTriangle.Normals = new RenderedVector[3]
      {
        new RenderedVector(vertex1.Normal.X, vertex1.Normal.Y, vertex1.Normal.Z),
        new RenderedVector(vertex2.Normal.X, vertex2.Normal.Y, vertex2.Normal.Z),
        new RenderedVector(vertex3.Normal.X, vertex3.Normal.Y, vertex3.Normal.Z)
      };
      AbsRenderr.Triangles[groupId].Add(renderedTriangle);
    }
  }

  public override void SetGroupVisibility(int groupId, bool isVisible)
  {
    AbsRenderr.Visiblity[groupId] = isVisible;
  }

  public static void Dr()
  {
  }

  public static void Draw() => AbsRenderr.DrawAllTriangles();

  public static void DrawAllTriangles()
  {
    int num = 0;
    buMwCutSim.MeshTri.Clear();
    foreach (int key in AbsRenderr.Triangles.Keys)
    {
      foreach (RenderedTriangle renderedTriangle in AbsRenderr.Triangles[key])
      {
        Triangle3D triangle3D = new Triangle3D(new Pnt3D((double) renderedTriangle.Vertices[0].X, (double) renderedTriangle.Vertices[0].Y, (double) renderedTriangle.Vertices[0].Z), new Pnt3D((double) renderedTriangle.Vertices[1].X, (double) renderedTriangle.Vertices[1].Y, (double) renderedTriangle.Vertices[1].Z), new Pnt3D((double) renderedTriangle.Vertices[2].X, (double) renderedTriangle.Vertices[2].Y, (double) renderedTriangle.Vertices[2].Z));
        buMwCutSim.MeshTri.Add(triangle3D);
        ++num;
      }
    }
  }
}
