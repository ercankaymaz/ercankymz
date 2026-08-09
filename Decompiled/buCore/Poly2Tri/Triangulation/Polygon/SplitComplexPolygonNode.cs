using System;
using System.Collections.Generic;
using System.Text;
using Poly2Tri.Utility;
using ns54;

namespace Poly2Tri.Triangulation.Polygon;

public class SplitComplexPolygonNode
{
	private readonly List<SplitComplexPolygonNode> list_0 = new List<SplitComplexPolygonNode>();

	private Point2D pos = null;

	public int NumConnected => list_0.Count;

	public Point2D Position
	{
		get
		{
			return pos;
		}
		set
		{
			pos = value;
		}
	}

	public SplitComplexPolygonNode this[int index] => list_0[index];

	public SplitComplexPolygonNode(Point2D pos)
	{
		this.pos = pos;
	}

	public override bool Equals(object obj)
	{
		SplitComplexPolygonNode splitComplexPolygonNode = obj as SplitComplexPolygonNode;
		if (!(splitComplexPolygonNode != null))
		{
			return false;
		}
		return Equals(splitComplexPolygonNode);
	}

	public bool Equals(SplitComplexPolygonNode pn)
	{
		if ((object)pn != null)
		{
			if (pos != null && pn.Position != null)
			{
				return pos.Equals(pn.Position);
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return pos.GetHashCode();
	}

	public static bool operator ==(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
	{
		if ((object)lhs == null)
		{
			if ((object)rhs != null)
			{
				return false;
			}
			return true;
		}
		return lhs.Equals(rhs);
	}

	public static bool operator !=(SplitComplexPolygonNode lhs, SplitComplexPolygonNode rhs)
	{
		if ((object)lhs == null)
		{
			if ((object)rhs != null)
			{
				return true;
			}
			return false;
		}
		return !lhs.Equals(rhs);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		stringBuilder.Append(pos);
		stringBuilder.Append(" -> ");
		for (int i = 0; i < NumConnected; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(list_0[i].Position);
		}
		return stringBuilder.ToString();
	}

	public void AddConnection(SplitComplexPolygonNode toMe)
	{
		if (!list_0.Contains(toMe) && toMe != this)
		{
			list_0.Add(toMe);
		}
	}

	public void RemoveConnection(SplitComplexPolygonNode fromMe)
	{
		list_0.Remove(fromMe);
	}

	public void ClearConnections()
	{
		list_0.Clear();
	}

	public SplitComplexPolygonNode GetRightestConnection(SplitComplexPolygonNode incoming)
	{
		if (NumConnected != 0)
		{
			if (NumConnected != 1)
			{
				Point2D point2D = pos - incoming.pos;
				double num = point2D.Magnitude();
				point2D.Normalize();
				if (!(num <= 1E-12))
				{
					SplitComplexPolygonNode splitComplexPolygonNode = null;
					for (int i = 0; i < NumConnected; i++)
					{
						if (list_0[i] == incoming)
						{
							continue;
						}
						Point2D point2D2 = list_0[i].pos - pos;
						double num2 = point2D2.MagnitudeSquared();
						point2D2.Normalize();
						if (!(num2 <= 1E-24))
						{
							double double_ = Point2D.Dot(point2D, point2D2);
							double double_2 = Point2D.Cross(point2D, point2D2);
							if (!(splitComplexPolygonNode != null))
							{
								splitComplexPolygonNode = list_0[i];
								continue;
							}
							Point2D point2D3 = splitComplexPolygonNode.pos - pos;
							point2D3.Normalize();
							double double_3 = Point2D.Dot(point2D, point2D3);
							double double_4 = Point2D.Cross(point2D, point2D3);
							if (Class156.smethod_5(double_4, this, double_2, double_, double_3))
							{
								splitComplexPolygonNode = list_0[i];
							}
							continue;
						}
						throw new Exception("Length too small");
					}
					return splitComplexPolygonNode;
				}
				throw new Exception("Length too small");
			}
			return incoming;
		}
		throw new Exception("the connection graph is inconsistent");
	}

	public SplitComplexPolygonNode GetRightestConnection(Point2D incomingDir)
	{
		Point2D point2D = pos - incomingDir;
		SplitComplexPolygonNode incoming = new SplitComplexPolygonNode(point2D);
		return GetRightestConnection(incoming);
	}
}
