using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public struct Interval
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Interval, double> _0023_003DzDoSgWJdj1Kh_0024xAwwFQ_003D_003D;

		internal double _0023_003DzZSoRA1I9GgfKAQ_0024Hpg_003D_003D(Interval _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D.t0;
		}
	}

	public double t0;

	public double t1;

	public double Low => t0;

	public double Left => t0;

	public double High => t1;

	public double Right => t1;

	public bool IsDecreasing => t0 > t1;

	public bool IsIncreasing => t0 < t1;

	public double Length => t1 - t0;

	public double Mid => 0.5 * (t0 + t1);

	public double Min
	{
		get
		{
			if (!IsDecreasing)
			{
				return t0;
			}
			return t1;
		}
	}

	public double Max
	{
		get
		{
			if (!IsDecreasing)
			{
				return t1;
			}
			return t0;
		}
	}

	public bool IsTwoPI => Math.Abs(Math.Abs(Length) - Math.PI * 2.0) < 1E-15;

	public Interval(double t0, double t1)
	{
		this.t0 = t0;
		this.t1 = t1;
	}

	public Interval(double[] tArray)
	{
		t0 = tArray[0];
		t1 = tArray[1];
	}

	public void Swap()
	{
		double num = t0;
		t0 = t1;
		t1 = num;
	}

	public void Reverse()
	{
		double num = 0.0 - t0;
		t0 = 0.0 - t1;
		t1 = num;
	}

	public double ParameterAt(double x)
	{
		return (1.0 - x) * t0 + x * t1;
	}

	public bool Includes(double t, bool testOpenInterval)
	{
		bool flag = false;
		int num = ((!(t0 <= t1)) ? 1 : 0);
		if (testOpenInterval)
		{
			if (num == 0)
			{
				return t0 < t && t < t1;
			}
			return t1 < t && t < t0;
		}
		if (num == 0)
		{
			return t0 <= t && t <= t1;
		}
		return t1 <= t && t <= t0;
	}

	internal bool _0023_003DzNoPt9TsyzDMJ(double _0023_003DzNDQ_E88_003D)
	{
		bool num = !(t0 <= t1);
		double num2 = Utility._0023_003DzheSR8QM7q9ya * Length;
		if (!num)
		{
			return t0 - num2 < _0023_003DzNDQ_E88_003D && _0023_003DzNDQ_E88_003D < t1 + num2;
		}
		return t1 + num2 < _0023_003DzNDQ_E88_003D && _0023_003DzNDQ_E88_003D < t0 - num2;
	}

	public bool Includes(double t, double tol)
	{
		tol = Math.Abs(tol);
		if (t0 <= t1)
		{
			return t0 - tol <= t && t <= t1 + tol;
		}
		return t1 - tol <= t && t <= t0 + tol;
	}

	public static Interval[] Merge(IList<Interval> intervals, double tol = 1E-12)
	{
		IList<Interval> list = new List<Interval>();
		if (intervals == null || intervals.Count == 0)
		{
			return list.ToArray();
		}
		IList<Interval> list2 = intervals.OrderBy((Interval _0023_003DzhidJeNw_003D) => _0023_003DzhidJeNw_003D.t0).ToList();
		Interval item = list2[0];
		for (int num = 1; num < list2.Count; num++)
		{
			Interval interval = list2[num];
			if (!(interval.Length < 1E-12))
			{
				if (item.t1 < interval.t0 && Math.Abs(item.t1 - interval.t0) > tol)
				{
					list.Add(item);
					item = interval;
				}
				else
				{
					item = new Interval(item.t0, Math.Max(item.t1, interval.t1));
				}
			}
		}
		list.Add(item);
		return list.ToArray();
	}

	public static Interval Intersection(Interval a, Interval b)
	{
		Interval result = default(Interval);
		if (b.t0 > a.t1 || a.t0 > b.t1)
		{
			return result;
		}
		result.t0 = Math.Max(a.t0, b.t0);
		result.t1 = Math.Min(a.t1, b.t1);
		return result;
	}

	public void Clamp(ref double t)
	{
		Utility.LimitRange(t0, ref t, t1);
	}

	public override string ToString()
	{
		return t0.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + t1.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747), CultureInfo.InvariantCulture.NumberFormat);
	}

	internal IntervalSurrogate _0023_003Dz_0024xHo97pGU7zE()
	{
		return new IntervalSurrogate(this);
	}
}
