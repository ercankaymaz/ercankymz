// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.TriangulationConstraint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Utility;
using System;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation;

public class TriangulationConstraint : Edge
{
  public TriangulationPoint P
  {
    get => this.EdgeStart as TriangulationPoint;
    set
    {
      if ((value == null ? 0 : (!value.Equals(this.EdgeStart) ? 1 : 0)) == 0)
        return;
      this.EdgeStart = (Point2D) value;
      this.CalculateContraintCode();
    }
  }

  public TriangulationPoint Q
  {
    get => this.EdgeEnd as TriangulationPoint;
    set
    {
      if ((value == null ? 0 : (!value.Equals(this.EdgeEnd) ? 1 : 0)) == 0)
        return;
      this.EdgeEnd = (Point2D) value;
      this.CalculateContraintCode();
    }
  }

  public uint ConstraintCode { get; private set; }

  public TriangulationConstraint(Point2D p1, Point2D p2)
  {
    this.ConstraintCode = 0U;
    this.EdgeStart = p1;
    this.EdgeEnd = p2;
    if (p1.Y > p2.Y)
    {
      this.EdgeEnd = p1;
      this.EdgeStart = p2;
    }
    else if (p1.Y == p2.Y)
    {
      if (p1.X > p2.X)
      {
        this.EdgeEnd = p1;
        this.EdgeStart = p2;
      }
      else if (p1.X != p2.X)
        ;
    }
    this.CalculateContraintCode();
  }

  public override string ToString() => $"[P={this.P}, Q={this.Q} : {{{this.ConstraintCode}}}]";

  public void CalculateContraintCode()
  {
    this.ConstraintCode = TriangulationConstraint.CalculateContraintCode(this.P, this.Q);
  }

  public static uint CalculateContraintCode(TriangulationPoint p, TriangulationPoint q)
  {
    uint nInitialValue = (p == null ? 1 : (p == null ? 1 : 0)) == 0 ? MathUtil.Jenkins32Hash((IEnumerable<byte>) BitConverter.GetBytes(p.VertexCode), 0U) : throw new ArgumentNullException();
    return MathUtil.Jenkins32Hash((IEnumerable<byte>) BitConverter.GetBytes(q.VertexCode), nInitialValue);
  }
}
