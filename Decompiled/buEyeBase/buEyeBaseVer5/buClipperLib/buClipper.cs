using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns64;
using ns67;
using ns68;
using ns69;
using ns70;
using ns71;

namespace buEyeBaseVer5.buClipperLib;

public class buClipper : buClipperBase
{
	public delegate void ZFillCallback(IntPoint bot1, IntPoint top1, IntPoint bot2, IntPoint top2, ref IntPoint pt);

	internal enum Enum18
	{
		const_0,
		const_1,
		const_2
	}

	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	public const int ioReverseSolution = 1;

	public const int ioStrictlySimple = 2;

	public const int ioPreserveCollinear = 4;

	internal ClipType clipType_0;

	internal Class180 class180_0;

	internal Class177 class177_1;

	internal List<IntersectNode> list_2;

	internal IComparer<IntersectNode> icomparer_0;

	private bool bool_3;

	internal PolyFillType polyFillType_0;

	internal PolyFillType polyFillType_1;

	internal List<Class183> list_3;

	internal List<Class183> list_4;

	internal bool bool_4;

	[CompilerGenerated]
	private ZFillCallback zfillCallback_0;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	public ZFillCallback ZFillFunction
	{
		[CompilerGenerated]
		get
		{
			return zfillCallback_0;
		}
		[CompilerGenerated]
		set
		{
			zfillCallback_0 = value;
		}
	}

	public bool ReverseSolution
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool StrictlySimple
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public buClipper(int InitOptions = 0)
	{
		class179_0 = null;
		class180_0 = null;
		class177_0 = null;
		class177_1 = null;
		list_2 = new List<IntersectNode>();
		icomparer_0 = new MyIntersectNodeSort();
		bool_3 = false;
		bool_4 = false;
		list_1 = new List<Class181>();
		list_3 = new List<Class183>();
		list_4 = new List<Class183>();
		ReverseSolution = (1 & InitOptions) != 0;
		StrictlySimple = (2 & InitOptions) != 0;
		base.PreserveCollinear = (4 & InitOptions) != 0;
		ZFillFunction = null;
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType FillType = PolyFillType.pftEvenOdd)
	{
		return Execute(clipType, solution, FillType, FillType);
	}

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType FillType = PolyFillType.pftEvenOdd)
	{
		return Execute(clipType, polytree, FillType, FillType);
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (!bool_3)
		{
			if (!bool_1)
			{
				bool_3 = true;
				solution.Clear();
				polyFillType_1 = subjFillType;
				polyFillType_0 = clipFillType;
				clipType_0 = clipType;
				bool_4 = false;
				bool result;
				try
				{
					if (result = method_0())
					{
						Class186.smethod_205(solution, this);
					}
				}
				finally
				{
					Class186.smethod_257(this);
					bool_3 = false;
				}
				return result;
			}
			throw new Exception1("Error: PolyTree struct is needed for open path clipping.");
		}
		return false;
	}

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (!bool_3)
		{
			bool_3 = true;
			polyFillType_1 = subjFillType;
			polyFillType_0 = clipFillType;
			clipType_0 = clipType;
			bool_4 = true;
			bool result;
			try
			{
				if (result = method_0())
				{
					Class186.smethod_363(polytree, this);
				}
			}
			finally
			{
				Class186.smethod_257(this);
				bool_3 = false;
			}
			return result;
		}
		return false;
	}

	private bool method_0()
	{
		try
		{
			vmethod_0();
			class177_1 = null;
			class180_0 = null;
			long long_ = default(long);
			if (Class186.smethod_245((buClipperBase)this, ref long_))
			{
				Class186.smethod_562(this, long_);
				long long_2 = default(long);
				while (Class186.smethod_245((buClipperBase)this, ref long_2) || Class186.smethod_682((buClipperBase)this))
				{
					Class186.smethod_2(this);
					list_4.Clear();
					if (Class186.smethod_754(this, long_2))
					{
						Class186.smethod_359(this, long_2);
						long_ = long_2;
						Class186.smethod_562(this, long_);
						continue;
					}
					return false;
				}
				foreach (Class181 item in list_1)
				{
					if (item.class182_0 != null && !item.bool_1 && (item.bool_0 ^ ReverseSolution) == Class186.smethod_657(this, item) > 0.0)
					{
						Class186.smethod_15(item.class182_0, this);
					}
				}
				Class186.smethod_758(this);
				foreach (Class181 item2 in list_1)
				{
					if (item2.class182_0 != null)
					{
						if (!item2.bool_1)
						{
							Class186.smethod_153(this, item2);
						}
						else
						{
							Class186.smethod_61(item2, this);
						}
					}
				}
				if (StrictlySimple)
				{
					Class186.smethod_242(this);
				}
				return true;
			}
			return false;
		}
		finally
		{
			list_3.Clear();
			list_4.Clear();
		}
	}

	public static void ReversePaths(List<List<IntPoint>> polys)
	{
		foreach (List<IntPoint> poly in polys)
		{
			poly.Reverse();
		}
	}

	public static bool Orientation(List<IntPoint> poly)
	{
		return Area(poly) >= 0.0;
	}

	public static int PointInPolygon(IntPoint pt, List<IntPoint> path)
	{
		int num = 0;
		int count = path.Count;
		if (count >= 3)
		{
			IntPoint intPoint = path[0];
			for (int i = 1; i <= count; i++)
			{
				IntPoint intPoint2 = ((i != count) ? path[i] : path[0]);
				if (intPoint2.Y != pt.Y || (intPoint2.X != pt.X && (intPoint.Y != pt.Y || intPoint2.X > pt.X != intPoint.X < pt.X)))
				{
					if (intPoint.Y < pt.Y != intPoint2.Y < pt.Y)
					{
						if (intPoint.X < pt.X)
						{
							if (intPoint2.X > pt.X)
							{
								double num2 = (double)(intPoint.X - pt.X) * (double)(intPoint2.Y - pt.Y) - (double)(intPoint2.X - pt.X) * (double)(intPoint.Y - pt.Y);
								if (num2 == 0.0)
								{
									return -1;
								}
								if (num2 > 0.0 == intPoint2.Y > intPoint.Y)
								{
									num = 1 - num;
								}
							}
						}
						else if (intPoint2.X <= pt.X)
						{
							double num3 = (double)(intPoint.X - pt.X) * (double)(intPoint2.Y - pt.Y) - (double)(intPoint2.X - pt.X) * (double)(intPoint.Y - pt.Y);
							if (num3 == 0.0)
							{
								return -1;
							}
							if (num3 > 0.0 == intPoint2.Y > intPoint.Y)
							{
								num = 1 - num;
							}
						}
						else
						{
							num = 1 - num;
						}
					}
					intPoint = intPoint2;
					continue;
				}
				return -1;
			}
			return num;
		}
		return 0;
	}

	internal void method_1(Class181 class181_0, Class181 class181_1)
	{
		foreach (Class181 item in list_1)
		{
			Class181 @class = Class186.smethod_119(item.class181_0);
			if (item.class182_0 != null && @class == class181_0 && Class186.smethod_710(item.class182_0, class181_1.class182_0))
			{
				item.class181_0 = class181_1;
			}
		}
	}

	internal void method_2(Class181 class181_0, Class181 class181_1)
	{
		Class181 class181_2 = class181_1.class181_0;
		foreach (Class181 item in list_1)
		{
			if (item.class182_0 == null || item == class181_1 || item == class181_0)
			{
				continue;
			}
			Class181 @class = Class186.smethod_119(item.class181_0);
			if (@class != class181_2 && @class != class181_0 && @class != class181_1)
			{
				continue;
			}
			if (!Class186.smethod_710(item.class182_0, class181_0.class182_0))
			{
				if (!Class186.smethod_710(item.class182_0, class181_1.class182_0))
				{
					if (item.class181_0 == class181_0 || item.class181_0 == class181_1)
					{
						item.class181_0 = class181_2;
					}
				}
				else
				{
					item.class181_0 = class181_1;
				}
			}
			else
			{
				item.class181_0 = class181_0;
			}
		}
	}

	internal void method_3(Class181 class181_0, Class181 class181_1)
	{
		foreach (Class181 item in list_1)
		{
			Class181 @class = Class186.smethod_119(item.class181_0);
			if (item.class182_0 != null && @class == class181_0)
			{
				item.class181_0 = class181_1;
			}
		}
	}

	public static double Area(List<IntPoint> poly)
	{
		int count = poly.Count;
		if (count >= 3)
		{
			double num = 0.0;
			int i = 0;
			int index = count - 1;
			for (; i < count; i++)
			{
				num += ((double)poly[index].X + (double)poly[i].X) * ((double)poly[index].Y - (double)poly[i].Y);
				index = i;
			}
			return (0.0 - num) * 0.5;
		}
		return 0.0;
	}

	public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		buClipper buClipper2 = new buClipper();
		buClipper2.StrictlySimple = true;
		buClipper2.AddPath(poly, PolyType.ptSubject, Closed: true);
		buClipper2.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	public static List<List<IntPoint>> SimplifyPolygons(List<List<IntPoint>> polys, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		buClipper buClipper2 = new buClipper();
		buClipper2.StrictlySimple = true;
		buClipper2.AddPaths(polys, PolyType.ptSubject, closed: true);
		buClipper2.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
	{
		int num = path.Count;
		if (num != 0)
		{
			Class182[] array = new Class182[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new Class182();
			}
			for (int j = 0; j < num; j++)
			{
				array[j].intPoint_0 = path[j];
				array[j].class182_0 = array[(j + 1) % num];
				array[j].class182_0.class182_1 = array[j];
				array[j].int_0 = 0;
			}
			double double_ = distance * distance;
			Class182 @class = array[0];
			while (@class.int_0 == 0 && @class.class182_0 != @class.class182_1)
			{
				if (!Class186.smethod_821(@class.intPoint_0, @class.class182_1.intPoint_0, double_))
				{
					if (!Class186.smethod_821(@class.class182_1.intPoint_0, @class.class182_0.intPoint_0, double_))
					{
						if (!Class186.smethod_268(@class.class182_1.intPoint_0, @class.intPoint_0, @class.class182_0.intPoint_0, double_))
						{
							@class.int_0 = 1;
							@class = @class.class182_0;
						}
						else
						{
							@class = Class186.smethod_373(@class);
							num--;
						}
					}
					else
					{
						Class186.smethod_373(@class.class182_0);
						@class = Class186.smethod_373(@class);
						num -= 2;
					}
				}
				else
				{
					@class = Class186.smethod_373(@class);
					num--;
				}
			}
			if (num < 3)
			{
				num = 0;
			}
			List<IntPoint> list = new List<IntPoint>(num);
			for (int k = 0; k < num; k++)
			{
				list.Add(@class.intPoint_0);
				@class = @class.class182_0;
			}
			array = null;
			return list;
		}
		return new List<IntPoint>();
	}

	public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>(polys.Count);
		for (int i = 0; i < polys.Count; i++)
		{
			list.Add(CleanPolygon(polys[i], distance));
		}
		return list;
	}

	internal static List<List<IntPoint>> smethod_0(List<IntPoint> list_5, List<IntPoint> list_6, bool bool_7, bool bool_8)
	{
		int num = (bool_8 ? 1 : 0);
		int count = list_5.Count;
		int count2 = list_6.Count;
		List<List<IntPoint>> list = new List<List<IntPoint>>(count2);
		if (!bool_7)
		{
			for (int i = 0; i < count2; i++)
			{
				List<IntPoint> list2 = new List<IntPoint>(count);
				foreach (IntPoint item in list_5)
				{
					list2.Add(new IntPoint(list_6[i].X - item.X, list_6[i].Y - item.Y));
				}
				list.Add(list2);
			}
		}
		else
		{
			for (int j = 0; j < count2; j++)
			{
				List<IntPoint> list3 = new List<IntPoint>(count);
				foreach (IntPoint item2 in list_5)
				{
					list3.Add(new IntPoint(list_6[j].X + item2.X, list_6[j].Y + item2.Y));
				}
				list.Add(list3);
			}
		}
		List<List<IntPoint>> list4 = new List<List<IntPoint>>((count2 + num) * (count + 1));
		for (int k = 0; k < count2 - 1 + num; k++)
		{
			for (int l = 0; l < count; l++)
			{
				List<IntPoint> list5 = new List<IntPoint>(4);
				list5.Add(list[k % count2][l % count]);
				list5.Add(list[(k + 1) % count2][l % count]);
				list5.Add(list[(k + 1) % count2][(l + 1) % count]);
				list5.Add(list[k % count2][(l + 1) % count]);
				if (!Orientation(list5))
				{
					list5.Reverse();
				}
				list4.Add(list5);
			}
		}
		return list4;
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<IntPoint> path, bool pathIsClosed)
	{
		List<List<IntPoint>> list = smethod_0(pattern, path, bool_7: true, pathIsClosed);
		buClipper buClipper2 = new buClipper();
		buClipper2.AddPaths(list, PolyType.ptSubject, closed: true);
		buClipper2.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<List<IntPoint>> paths, bool pathIsClosed)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		buClipper buClipper2 = new buClipper();
		for (int i = 0; i < paths.Count; i++)
		{
			List<List<IntPoint>> ppg = smethod_0(pattern, paths[i], bool_7: true, pathIsClosed);
			buClipper2.AddPaths(ppg, PolyType.ptSubject, closed: true);
			if (pathIsClosed)
			{
				List<IntPoint> list2 = paths[i];
				IntPoint intPoint_ = pattern[0];
				List<IntPoint> pg = Class186.smethod_763(intPoint_, list2);
				buClipper2.AddPath(pg, PolyType.ptClip, Closed: true);
			}
		}
		buClipper2.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2)
	{
		List<List<IntPoint>> list = smethod_0(poly1, poly2, bool_7: false, bool_8: true);
		buClipper buClipper2 = new buClipper();
		buClipper2.AddPaths(list, PolyType.ptSubject, closed: true);
		buClipper2.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		smethod_1(polytree, Enum18.const_0, list);
		return list;
	}

	internal static void smethod_1(PolyNode polyNode_0, Enum18 enum18_0, List<List<IntPoint>> list_5)
	{
		bool flag = true;
		switch (enum18_0)
		{
		case Enum18.const_2:
			flag = !polyNode_0.IsOpen;
			break;
		case Enum18.const_1:
			return;
		}
		if (polyNode_0.list_0.Count > 0 && flag)
		{
			list_5.Add(polyNode_0.list_0);
		}
		foreach (PolyNode child in polyNode_0.Childs)
		{
			smethod_1(child, enum18_0, list_5);
		}
	}

	public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.ChildCount;
		for (int i = 0; i < polytree.ChildCount; i++)
		{
			if (polytree.Childs[i].IsOpen)
			{
				list.Add(polytree.Childs[i].list_0);
			}
		}
		return list;
	}

	public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		smethod_1(polytree, Enum18.const_2, list);
		return list;
	}
}
