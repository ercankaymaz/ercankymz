using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns54;

namespace buCore.buClipperLib;

public class ClipperOffset
{
	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	internal List<List<IntPoint>> list_0;

	internal List<IntPoint> list_1;

	internal List<IntPoint> list_2;

	internal List<DoublePoint> list_3 = new List<DoublePoint>();

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal double double_4;

	internal double double_5;

	internal IntPoint intPoint_0;

	internal PolyNode polyNode_0 = new PolyNode();

	[CompilerGenerated]
	private double double_6;

	[CompilerGenerated]
	private double double_7;

	public double ArcTolerance
	{
		[CompilerGenerated]
		get
		{
			return double_6;
		}
		[CompilerGenerated]
		set
		{
			double_6 = value;
		}
	}

	public double MiterLimit
	{
		[CompilerGenerated]
		get
		{
			return double_7;
		}
		[CompilerGenerated]
		set
		{
			double_7 = value;
		}
	}

	public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
	{
		MiterLimit = miterLimit;
		ArcTolerance = arcTolerance;
		intPoint_0.X = -1L;
	}

	public void Clear()
	{
		polyNode_0.Childs.Clear();
		intPoint_0.X = -1L;
	}

	public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
	{
		int num = path.Count - 1;
		if (num < 0)
		{
			return;
		}
		PolyNode polyNode = new PolyNode();
		polyNode.joinType_0 = joinType;
		polyNode.endType_0 = endType;
		if (endType == EndType.etClosedLine || endType == EndType.etClosedPolygon)
		{
			while (num > 0 && path[0] == path[num])
			{
				num--;
			}
		}
		polyNode.list_0.Capacity = num + 1;
		polyNode.list_0.Add(path[0]);
		int num2 = 0;
		int num3 = 0;
		for (int i = 1; i <= num; i++)
		{
			if (polyNode.list_0[num2] != path[i])
			{
				num2++;
				polyNode.list_0.Add(path[i]);
				if (path[i].Y > polyNode.list_0[num3].Y || (path[i].Y == polyNode.list_0[num3].Y && path[i].X < polyNode.list_0[num3].X))
				{
					num3 = num2;
				}
			}
		}
		if (endType == EndType.etClosedPolygon && num2 < 2)
		{
			return;
		}
		Class156.smethod_212(polyNode_0, polyNode);
		if (endType != EndType.etClosedPolygon)
		{
			return;
		}
		if (intPoint_0.X >= 0L)
		{
			IntPoint intPoint = polyNode_0.Childs[(int)intPoint_0.X].list_0[(int)intPoint_0.Y];
			if (polyNode.list_0[num3].Y > intPoint.Y || (polyNode.list_0[num3].Y == intPoint.Y && polyNode.list_0[num3].X < intPoint.X))
			{
				intPoint_0 = new IntPoint(polyNode_0.ChildCount - 1, num3);
			}
		}
		else
		{
			intPoint_0 = new IntPoint(polyNode_0.ChildCount - 1, num3);
		}
	}

	public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
	{
		foreach (List<IntPoint> path in paths)
		{
			AddPath(path, joinType, endType);
		}
	}

	public void Execute(ref List<List<IntPoint>> solution, double delta)
	{
		solution.Clear();
		Class156.smethod_152(this);
		Class156.smethod_141(this, delta);
		buClipper buClipper2 = new buClipper();
		buClipper2.AddPaths(list_0, PolyType.ptSubject, closed: true);
		if (!(delta > 0.0))
		{
			IntRect bounds = buClipperBase.GetBounds(list_0);
			List<IntPoint> list = new List<IntPoint>(4);
			list.Add(new IntPoint(bounds.left - 10L, bounds.bottom + 10L));
			list.Add(new IntPoint(bounds.right + 10L, bounds.bottom + 10L));
			list.Add(new IntPoint(bounds.right + 10L, bounds.top - 10L));
			list.Add(new IntPoint(bounds.left - 10L, bounds.top - 10L));
			buClipper2.AddPath(list, PolyType.ptSubject, Closed: true);
			buClipper2.ReverseSolution = true;
			buClipper2.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (solution.Count > 0)
			{
				solution.RemoveAt(0);
			}
		}
		else
		{
			buClipper2.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
		}
	}

	public void Execute(ref PolyTree solution, double delta)
	{
		solution.Clear();
		Class156.smethod_152(this);
		Class156.smethod_141(this, delta);
		buClipper buClipper2 = new buClipper();
		buClipper2.AddPaths(list_0, PolyType.ptSubject, closed: true);
		if (!(delta > 0.0))
		{
			IntRect bounds = buClipperBase.GetBounds(list_0);
			List<IntPoint> list = new List<IntPoint>(4);
			list.Add(new IntPoint(bounds.left - 10L, bounds.bottom + 10L));
			list.Add(new IntPoint(bounds.right + 10L, bounds.bottom + 10L));
			list.Add(new IntPoint(bounds.right + 10L, bounds.top - 10L));
			list.Add(new IntPoint(bounds.left - 10L, bounds.top - 10L));
			buClipper2.AddPath(list, PolyType.ptSubject, Closed: true);
			buClipper2.ReverseSolution = true;
			buClipper2.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (solution.ChildCount != 1 || solution.Childs[0].ChildCount <= 0)
			{
				solution.Clear();
				return;
			}
			PolyNode polyNode = solution.Childs[0];
			solution.Childs.Capacity = polyNode.ChildCount;
			solution.Childs[0] = polyNode.Childs[0];
			solution.Childs[0].polyNode_0 = solution;
			for (int i = 1; i < polyNode.ChildCount; i++)
			{
				Class156.smethod_212((PolyNode)solution, polyNode.Childs[i]);
			}
		}
		else
		{
			buClipper2.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
		}
	}
}
