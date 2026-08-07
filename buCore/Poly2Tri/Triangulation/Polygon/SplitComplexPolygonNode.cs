// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.SplitComplexPolygonNode
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class SplitComplexPolygonNode
{
  private readonly List<SplitComplexPolygonNode> list_0 = new List<SplitComplexPolygonNode>();
  private Point2D pos = (Point2D) null;

  public int NumConnected => this.list_0.Count;

  public Point2D Position
  {
    get => this.pos;
    set => this.pos = value;
  }

  public SplitComplexPolygonNode this[int index] => this.list_0[index];

  public SplitComplexPolygonNode(Point2D pos) => this.pos = pos;

  public override bool Equals(object obj)
  {
    SplitComplexPolygonNode pn = obj as SplitComplexPolygonNode;
    return pn != (SplitComplexPolygonNode) null && this.Equals(pn);
  }

  public bool Equals(SplitComplexPolygonNode pn)
  {
    return (object) pn != null && (this.pos == null ? 1 : (pn.Position == null ? 1 : 0)) == 0 && this.pos.Equals(pn.Position);
  }

  public override int GetHashCode() => this.pos.GetHashCode();

  public static bool operator ==(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
  {
    return lhs == null ? (object) rhs == null : lhs.Equals(rhs);
  }

  public static bool operator !=(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
  {
    return lhs == null ? (object) rhs != null : !lhs.Equals(rhs);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder(256 /*0x0100*/);
    stringBuilder.Append((object) this.pos);
    stringBuilder.Append(" -> ");
    for (int index = 0; index < this.NumConnected; ++index)
    {
      if (index != 0)
        stringBuilder.Append(", ");
      stringBuilder.Append((object) this.list_0[index].Position);
    }
    return stringBuilder.ToString();
  }

  public void AddConnection(SplitComplexPolygonNode toMe)
  {
    if ((this.list_0.Contains(toMe) ? 0 : (toMe != this ? 1 : 0)) == 0)
      return;
    this.list_0.Add(toMe);
  }

  public void RemoveConnection(SplitComplexPolygonNode fromMe) => this.list_0.Remove(fromMe);

  public void ClearConnections() => this.list_0.Clear();

  public SplitComplexPolygonNode GetRightestConnection(SplitComplexPolygonNode incoming)
  {
    if (this.NumConnected == 0)
      throw new Exception("the connection graph is inconsistent");
    if (this.NumConnected == 1)
      return incoming;
    Point2D lhs = this.pos - incoming.pos;
    double num1 = lhs.Magnitude();
    lhs.Normalize();
    if (num1 <= 1E-12)
      throw new Exception("Length too small");
    SplitComplexPolygonNode rightestConnection = (SplitComplexPolygonNode) null;
    for (int index = 0; index < this.NumConnected; ++index)
    {
      if (!(this.list_0[index] == incoming))
      {
        Point2D rhs1 = this.list_0[index].pos - this.pos;
        double num2 = rhs1.MagnitudeSquared();
        rhs1.Normalize();
        if (num2 <= 1E-24)
          throw new Exception("Length too small");
        double double_2 = Point2D.Dot(lhs, rhs1);
        double double_1 = Point2D.Cross(lhs, rhs1);
        if (rightestConnection != (SplitComplexPolygonNode) null)
        {
          Point2D rhs2 = rightestConnection.pos - this.pos;
          rhs2.Normalize();
          double double_3 = Point2D.Dot(lhs, rhs2);
          if (Class30.smethod_5(Point2D.Cross(lhs, rhs2), this, double_1, double_2, double_3))
            rightestConnection = this.list_0[index];
        }
        else
          rightestConnection = this.list_0[index];
      }
    }
    return rightestConnection;
  }

  public SplitComplexPolygonNode GetRightestConnection(Point2D incomingDir)
  {
    return this.GetRightestConnection(new SplitComplexPolygonNode(this.pos - incomingDir));
  }
}
