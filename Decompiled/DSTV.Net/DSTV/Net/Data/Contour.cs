using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DSTV.Net.Enums;
using DSTV.Net.Exceptions;

namespace DSTV.Net.Data;

public record Contour : DstvElement
{
	public IReadOnlyList<DstvContourPoint> PointList => _pointList;

	public ContourType Type { get; }

	public IEnumerable<DstvContourPoint> Points => _pointList.AsEnumerable();

	private readonly List<DstvContourPoint> _pointList;

	private Contour(List<DstvContourPoint> pointList, ContourType type)
	{
		_pointList = pointList;
		Type = type;
	}

	public static IEnumerable<Contour> CreateSeveralContours(List<DstvContourPoint> pointList, ContourType type)
	{
		if (pointList == null)
		{
			throw new ArgumentNullException("pointList");
		}
		List<Contour> list = new List<Contour>();
		if ((uint)(type - 1) <= 1u)
		{
			list.Add(new Contour(pointList, type));
			return list;
		}
		DstvContourPoint other = pointList[0];
		int num = 0;
		for (int i = 1; i < pointList.Count; i++)
		{
			if (pointList[i].FlCode.Equals("x", StringComparison.OrdinalIgnoreCase))
			{
				if (i == 0)
				{
					throw new DstvParseException("First point of AK/IK block haven't flange mark, processing aborted");
				}
				if (i == num)
				{
					Console.WriteLine("Warning: first point of contour haven't flange mark, mark will be taken from previous contour in section");
				}
				pointList[i].FlCode = pointList[i - 1].FlCode;
			}
			if (pointList[i].Equals(other))
			{
				int num2 = i;
				list.Add(new Contour(pointList.GetRange(num, num2 + 1 - num), type));
				num = ++i;
				if (num == pointList.Count)
				{
					break;
				}
				other = pointList[num];
			}
			if (i == pointList.Count - 1)
			{
				Console.WriteLine("Warning: there are non-closed part of points in end of contour section");
			}
		}
		return list;
	}

	public override string ToSvg()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		DstvContourPoint dstvContourPoint = new DstvContourPoint("x", 0.0, 0.0, IsNotch: false, 0.0);
		foreach (DstvContourPoint point in _pointList)
		{
			if (_pointList.IndexOf(point) == 0)
			{
				stringBuilder.Append("M ").Append(point.XCoord).Append(' ')
					.Append(point.YCoord);
				dstvContourPoint = point;
				continue;
			}
			stringBuilder.Append(' ');
			double radius = dstvContourPoint.Radius;
			double num = radius;
			if (!(num > 0.0))
			{
				if (num < 0.0)
				{
					goto IL_021d;
				}
				stringBuilder.Append('L').Append(point.XCoord).Append(',')
					.Append(point.YCoord);
			}
			else if (dstvContourPoint.YCoord < point.YCoord && point.XCoord > dstvContourPoint.XCoord)
			{
				stringBuilder.Append("Q ").Append(point.XCoord).Append(' ')
					.Append(dstvContourPoint.YCoord)
					.Append(' ')
					.Append(point.XCoord)
					.Append(' ')
					.Append(point.YCoord);
			}
			else if (dstvContourPoint.YCoord < point.YCoord && point.XCoord < dstvContourPoint.XCoord)
			{
				stringBuilder.Append("Q ").Append(dstvContourPoint.XCoord).Append(' ')
					.Append(point.YCoord)
					.Append(' ')
					.Append(point.XCoord)
					.Append(' ')
					.Append(point.YCoord);
			}
			else
			{
				if (!(dstvContourPoint.YCoord > point.YCoord) || !(point.XCoord < dstvContourPoint.XCoord))
				{
					goto IL_021d;
				}
				stringBuilder.Append("Q ").Append(point.XCoord).Append(' ')
					.Append(dstvContourPoint.YCoord)
					.Append(' ')
					.Append(point.XCoord)
					.Append(' ')
					.Append(point.YCoord);
			}
			goto IL_0293;
			IL_0293:
			if (dstvContourPoint is DstvSkewedPoint dstvSkewedPoint)
			{
				stringBuilder2.Append("<line x1=\"").Append(dstvSkewedPoint.XCoord).Append("\" y1=\"")
					.Append(dstvSkewedPoint.YCoord)
					.Append("\" x2=\"")
					.Append(point.XCoord)
					.Append("\" y2=\"")
					.Append(point.YCoord)
					.Append("\" stroke=\"red\" stroke-width=\"4\" />");
			}
			dstvContourPoint = point;
			continue;
			IL_021d:
			stringBuilder.Append("A ").Append(0.0 - radius).Append(' ')
				.Append(0.0 - radius)
				.Append(" 0 0 0 ")
				.Append(point.XCoord)
				.Append(' ')
				.Append(point.YCoord);
			goto IL_0293;
		}
		string arg = stringBuilder.ToString();
		string arg2 = ((Type == ContourType.AK) ? "grey" : "white");
		return $"<path d=\"{arg}\" fill=\"{arg2}\" stroke=\"black\" stroke-width=\"0.5\" />{stringBuilder2}";
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return (base.GetHashCode() * -1521134295 + EqualityComparer<List<DstvContourPoint>>.Default.GetHashCode(_pointList)) * -1521134295 + EqualityComparer<ContourType>.Default.GetHashCode(Type);
	}

	[CompilerGenerated]
	public virtual bool Equals(Contour? other)
	{
		if ((object)this != other)
		{
			if (base.Equals(other) && EqualityComparer<List<DstvContourPoint>>.Default.Equals(_pointList, other._pointList))
			{
				return EqualityComparer<ContourType>.Default.Equals(Type, other.Type);
			}
			return false;
		}
		return true;
	}

	[CompilerGenerated]
	protected Contour(Contour original)
		: base(original)
	{
		_pointList = original._pointList;
		Type = original.Type;
	}
}
