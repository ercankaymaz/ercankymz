using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal struct Segment
{
	private bool _isP1Excluded;

	private bool _isP2Excluded;

	private Point _p1;

	private Point _p2;

	public static Segment Empty
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			Segment result = new Segment(new Point(0.0, 0.0));
			result._isP1Excluded = true;
			result._isP2Excluded = true;
			return result;
		}
	}

	public Point P1 => _p1;

	public Point P2 => _p2;

	public bool IsP1Excluded => _isP1Excluded;

	public bool IsP2Excluded => _isP2Excluded;

	public bool IsEmpty
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			if (DoubleHelper.AreVirtuallyEqual(_p1, _p2))
			{
				if (!_isP1Excluded)
				{
					return _isP2Excluded;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsPoint => DoubleHelper.AreVirtuallyEqual(_p1, _p2);

	public double Length
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			Vector val = P2 - P1;
			return ((Vector)(ref val)).Length;
		}
	}

	public double Slope
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			Point val = P2;
			double x = ((Point)(ref val)).X;
			val = P1;
			if (x != ((Point)(ref val)).X)
			{
				val = P2;
				double y = ((Point)(ref val)).Y;
				val = P1;
				double num = y - ((Point)(ref val)).Y;
				val = P2;
				double x2 = ((Point)(ref val)).X;
				val = P1;
				return num / (x2 - ((Point)(ref val)).X);
			}
			return double.NaN;
		}
	}

	public Segment(Point point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = point;
		_p2 = point;
		_isP1Excluded = false;
		_isP2Excluded = false;
	}

	public Segment(Point p1, Point p2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = p1;
		_p2 = p2;
		_isP1Excluded = false;
		_isP2Excluded = false;
	}

	public Segment(Point p1, Point p2, bool excludeP1, bool excludeP2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = p1;
		_p2 = p2;
		_isP1Excluded = excludeP1;
		_isP2Excluded = excludeP2;
	}

	public bool Contains(Point point)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (IsEmpty)
		{
			return false;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, point))
		{
			return _isP1Excluded;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p2, point))
		{
			return _isP2Excluded;
		}
		bool result = false;
		if (DoubleHelper.AreVirtuallyEqual(Slope, new Segment(_p1, point).Slope))
		{
			result = ((Point)(ref point)).X >= Math.Min(((Point)(ref _p1)).X, ((Point)(ref _p2)).X) && ((Point)(ref point)).X <= Math.Max(((Point)(ref _p1)).X, ((Point)(ref _p2)).X) && ((Point)(ref point)).Y >= Math.Min(((Point)(ref _p1)).Y, ((Point)(ref _p2)).Y) && ((Point)(ref point)).Y <= Math.Max(((Point)(ref _p1)).Y, ((Point)(ref _p2)).Y);
		}
		return result;
	}

	public bool Contains(Segment segment)
	{
		return segment == Intersection(segment);
	}

	public override bool Equals(object o)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (!(o is Segment segment))
		{
			return false;
		}
		if (IsEmpty)
		{
			return segment.IsEmpty;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, segment._p1))
		{
			if (DoubleHelper.AreVirtuallyEqual(_p2, segment._p2) && _isP1Excluded == segment._isP1Excluded)
			{
				return _isP2Excluded == segment._isP2Excluded;
			}
			return false;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, segment._p2) && DoubleHelper.AreVirtuallyEqual(_p2, segment._p1) && _isP1Excluded == segment._isP2Excluded)
		{
			return _isP2Excluded == segment._isP1Excluded;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((object)Unsafe.As<Point, Point>(ref _p1)/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)Unsafe.As<Point, Point>(ref _p2)/*cast due to constrained. prefix*/).GetHashCode() ^ _isP1Excluded.GetHashCode() ^ _isP2Excluded.GetHashCode();
	}

	public Segment Intersection(Segment segment)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		if (IsEmpty || segment.IsEmpty)
		{
			return Empty;
		}
		if (this == segment)
		{
			return new Segment(_p1, _p2, _isP1Excluded, _isP2Excluded);
		}
		if (IsPoint)
		{
			if (!segment.Contains(_p1))
			{
				return Empty;
			}
			return new Segment(_p1);
		}
		if (segment.IsPoint)
		{
			if (!Contains(segment._p1))
			{
				return Empty;
			}
			return new Segment(segment._p1);
		}
		Point p = _p1;
		Vector val = _p2 - _p1;
		Point p2 = segment._p1;
		Vector val2 = segment._p2 - segment._p1;
		Vector val3 = p2 - p;
		double num = Vector.CrossProduct(val, val2);
		if (!DoubleHelper.AreVirtuallyEqual(Slope, segment.Slope))
		{
			double num2 = Vector.CrossProduct(val3, val) / num;
			if (num2 < 0.0 || num2 > 1.0)
			{
				return Empty;
			}
			num2 = Vector.CrossProduct(val3, val2) / num;
			if (num2 < 0.0 || num2 > 1.0)
			{
				return Empty;
			}
			return new Segment(p + num2 * val);
		}
		num = Vector.CrossProduct(val3, val);
		if (num * num > 1E-06 * ((Vector)(ref val)).LengthSquared * ((Vector)(ref val3)).LengthSquared)
		{
			return Empty;
		}
		Segment result = default(Segment);
		Segment segment2 = new Segment(_p1, _p2);
		Segment segment3 = new Segment(segment._p1, segment._p2);
		bool flag = segment3.Contains(segment2._p1);
		bool flag2 = segment3.Contains(segment2._p2);
		if (flag && flag2)
		{
			result._p1 = _p1;
			result._p2 = _p2;
			result._isP1Excluded = _isP1Excluded || !segment.Contains(_p1);
			result._isP2Excluded = _isP2Excluded || !segment.Contains(_p2);
			return result;
		}
		bool flag3 = segment2.Contains(segment3._p1);
		bool flag4 = segment2.Contains(segment3._p2);
		if (flag3 && flag4)
		{
			result._p1 = segment._p1;
			result._p2 = segment._p2;
			result._isP1Excluded = segment._isP1Excluded || !Contains(segment._p1);
			result._isP2Excluded = segment._isP2Excluded || !Contains(segment._p2);
			return result;
		}
		if (flag)
		{
			result._p1 = _p1;
			result._isP1Excluded = _isP1Excluded || !segment.Contains(_p1);
		}
		else
		{
			result._p1 = _p2;
			result._isP1Excluded = _isP2Excluded || !segment.Contains(_p2);
		}
		if (flag3)
		{
			result._p2 = segment._p1;
			result._isP2Excluded = segment._isP1Excluded || !Contains(segment._p1);
		}
		else
		{
			result._p2 = segment._p2;
			result._isP2Excluded = segment._isP2Excluded || !Contains(segment._p2);
		}
		return result;
	}

	public override string ToString()
	{
		string text = base.ToString();
		if (IsEmpty)
		{
			return text + ": {Empty}";
		}
		if (IsPoint)
		{
			return text + ", Point: " + ((object)Unsafe.As<Point, Point>(ref _p1)/*cast due to constrained. prefix*/).ToString();
		}
		return text + ": " + ((object)Unsafe.As<Point, Point>(ref _p1)/*cast due to constrained. prefix*/).ToString() + (_isP1Excluded ? " (excl)" : " (incl)") + " to " + ((object)Unsafe.As<Point, Point>(ref _p2)/*cast due to constrained. prefix*/).ToString() + (_isP2Excluded ? " (excl)" : " (incl)");
	}

	public static bool operator ==(Segment s1, Segment s2)
	{
		if ((object)s1 == null)
		{
			return (object)s2 == null;
		}
		if ((object)s2 == null)
		{
			return (object)s1 == null;
		}
		return s1.Equals(s2);
	}

	public static bool operator !=(Segment s1, Segment s2)
	{
		return !(s1 == s2);
	}
}
