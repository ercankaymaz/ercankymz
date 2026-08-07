// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.TriangulationPoint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Poly2Tri.Triangulation;

public class TriangulationPoint : Point2D, IEquatable<TriangulationPoint>
{
  public const double VERTEX_CODE_DEFAULT_PRECISION = 3.0;

  public override double X
  {
    get => base.X;
    set
    {
      if (value == base.X)
        return;
      base.X = value;
      this.VertexCode = TriangulationPoint.CreateVertexCode(base.X, base.Y, 3.0);
    }
  }

  public override double Y
  {
    get => base.Y;
    set
    {
      if (value == base.Y)
        return;
      base.Y = value;
      this.VertexCode = TriangulationPoint.CreateVertexCode(base.X, base.Y, 3.0);
    }
  }

  public uint VertexCode { get; private set; }

  public List<DTSweepConstraint> Edges { get; private set; }

  public bool HasEdges => this.Edges != null;

  public TriangulationPoint(double x, double y, double precision = 3.0)
    : base(x, y)
  {
    this.VertexCode = TriangulationPoint.CreateVertexCode(x, y, precision);
  }

  public override string ToString() => $"{base.ToString()}:{{{this.VertexCode.ToString()}}}";

  public override int GetHashCode() => (int) this.VertexCode;

  public override bool Equals(object obj) => this.Equals(obj as TriangulationPoint);

  public bool Equals(TriangulationPoint other)
  {
    return other != null && (int) this.VertexCode == (int) other.VertexCode && this.Equals((Point2D) other);
  }

  public override void Set(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }

  public static uint CreateVertexCode(double x, double y, double precision)
  {
    float num1 = (float) MathUtil.RoundWithPrecision(x, precision);
    float num2 = (float) MathUtil.RoundWithPrecision(y, precision);
    uint nInitialValue = MathUtil.Jenkins32Hash((IEnumerable<byte>) BitConverter.GetBytes(num1), 0U);
    return MathUtil.Jenkins32Hash((IEnumerable<byte>) BitConverter.GetBytes(num2), nInitialValue);
  }

  public void AddEdge(DTSweepConstraint e)
  {
    if (this.Edges == null)
      this.Edges = new List<DTSweepConstraint>();
    this.Edges.Add(e);
  }

  public bool HasEdge(TriangulationPoint p) => this.GetEdge(p, out DTSweepConstraint _);

  public bool GetEdge(TriangulationPoint p, out DTSweepConstraint edge)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    TriangulationPoint.Class1 class1 = new TriangulationPoint.Class1();
    // ISSUE: reference to a compiler-generated field
    class1.triangulationPoint_0 = this;
    // ISSUE: reference to a compiler-generated field
    class1.triangulationPoint_1 = p;
    edge = (DTSweepConstraint) null;
    bool edge1;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if ((this.Edges == null || this.Edges.Count < 1 || class1.triangulationPoint_1 == null ? 1 : (class1.triangulationPoint_1.Equals(this) ? 1 : 0)) != 0)
    {
      edge1 = false;
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      using (IEnumerator<DTSweepConstraint> enumerator = this.Edges.Where<DTSweepConstraint>(class1.func_0 ?? (class1.func_0 = new Func<DTSweepConstraint, bool>(class1.method_0))).GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          DTSweepConstraint current = enumerator.Current;
          edge = current;
          edge1 = true;
          goto label_9;
        }
      }
      edge1 = false;
    }
label_9:
    return edge1;
  }
}
