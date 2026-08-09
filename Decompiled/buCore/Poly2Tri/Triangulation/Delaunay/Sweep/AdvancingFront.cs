using System;
using System.Text;
using ns54;

namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class AdvancingFront
{
	public AdvancingFrontNode Head;

	public AdvancingFrontNode Tail;

	internal AdvancingFrontNode head;

	public AdvancingFront(AdvancingFrontNode head, AdvancingFrontNode tail)
	{
		Head = head;
		Tail = tail;
		this.head = head;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (AdvancingFrontNode next = Head; next != Tail; next = next.Next)
		{
			stringBuilder.Append(next.Point.X).Append("->");
		}
		stringBuilder.Append(Tail.Point.X);
		return stringBuilder.ToString();
	}

	public AdvancingFrontNode LocateNode(TriangulationPoint point)
	{
		return Class156.smethod_175(this, point.X);
	}

	public AdvancingFrontNode LocatePoint(TriangulationPoint point)
	{
		double x = point.X;
		AdvancingFrontNode advancingFrontNode = head;
		double x2 = advancingFrontNode.Point.X;
		if (x != x2)
		{
			if (!(x < x2))
			{
				while ((advancingFrontNode = advancingFrontNode.Next) != null && !point.Equals(advancingFrontNode.Point))
				{
				}
			}
			else
			{
				while ((advancingFrontNode = advancingFrontNode.Prev) != null && !point.Equals(advancingFrontNode.Point))
				{
				}
			}
		}
		else if (!point.Equals(advancingFrontNode.Point))
		{
			if (!point.Equals(advancingFrontNode.Prev.Point))
			{
				if (!point.Equals(advancingFrontNode.Next.Point))
				{
					throw new Exception("Failed to find Node for given afront point");
				}
				advancingFrontNode = advancingFrontNode.Next;
			}
			else
			{
				advancingFrontNode = advancingFrontNode.Prev;
			}
		}
		head = advancingFrontNode;
		return advancingFrontNode;
	}
}
