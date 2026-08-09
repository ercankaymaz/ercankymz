using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class HatchPatternLine
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<float, bool> _0023_003Dzt_0024Tb3v15OQhHkGmfXQ_003D_003D;

		internal bool _0023_003DzWJ5HgdrvjB8bKAdB53Yugnf8b7ojPe6Gvg_003D_003D(float _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D > 0f;
		}
	}

	[CompilerGenerated]
	private readonly float _003CLength_003Ek__BackingField;

	public double Angle { get; }

	public Point2D Origin { get; }

	public double DeltaX { get; }

	public double DeltaY { get; }

	public float[] Pattern { get; }

	public HatchPatternLine(double angle, Point2D origin, double deltaX, double deltaY, float[] pattern)
	{
		Angle = angle;
		Origin = origin;
		DeltaX = deltaX;
		DeltaY = deltaY;
		LineType.CheckPattern(pattern, throwEx: true, out var sum);
		Pattern = pattern;
		_003CLength_003Ek__BackingField = sum;
	}

	protected HatchPatternLine(HatchPatternLine another)
	{
		Angle = another.Angle;
		Origin = (Point2D)another.Origin.Clone();
		DeltaX = another.DeltaX;
		DeltaY = another.DeltaY;
		if (another.Pattern != null)
		{
			Pattern = new float[another.Pattern.Length];
			Array.Copy(another.Pattern, Pattern, another.Pattern.Length);
		}
		_003CLength_003Ek__BackingField = another._0023_003Dz4m952JDFwKpj();
	}

	protected internal HatchPatternLine(HatchPatternLineSurrogate surrogate)
		: this(surrogate.Angle, surrogate.Origin, surrogate.DeltaX, surrogate.DeltaY, surrogate.Pattern)
	{
	}

	protected HatchPatternLine(SerializationInfo info, StreamingContext context)
	{
		Angle = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971719));
		Origin = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), typeof(Point2D));
		DeltaX = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985906));
		DeltaY = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985917));
		Pattern = (float[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985900), typeof(float[]));
		_003CLength_003Ek__BackingField = (float)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985882), typeof(float));
	}

	private float _0023_003Dz4m952JDFwKpj()
	{
		return _003CLength_003Ek__BackingField;
	}

	public virtual HatchPatternLineSurrogate ConvertToSurrogate()
	{
		return new HatchPatternLineSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971719), Angle);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), Origin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985906), DeltaX);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985917), DeltaY);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985900), Pattern);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985882), _0023_003Dz4m952JDFwKpj());
	}

	internal bool _0023_003Dz3QLIG1l0mkXxlcWP0A_003D_003D(Hatch _0023_003Dz1L3TZOcNA99t, Plane _0023_003Dzrgqz890sj_0024X9, Polygon2D[] _0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D, Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC, int _0023_003Dz43pxRC2Rpyg7, out List<Point3D> _0023_003DzyIUKu5w_003D, out List<Point3D> _0023_003DzrdSL0CI_003D)
	{
		_0023_003DzyIUKu5w_003D = (_0023_003DzrdSL0CI_003D = null);
		List<Segment3D> list = new List<Segment3D>();
		if (DeltaY == 0.0)
		{
			return false;
		}
		Point3D point3D = new Point3D(_0023_003Dz1L3TZOcNA99t.PatternOrigin.X, _0023_003Dz1L3TZOcNA99t.PatternOrigin.Y);
		Rotation xform = new Rotation(_0023_003Dz1L3TZOcNA99t.PatternAngle, Vector3D.AxisZ, point3D);
		float num = (_0023_003Dz1L3TZOcNA99t.IsUserDefinedPattern ? 1f : _0023_003Dz1L3TZOcNA99t.PatternScale);
		Scaling xform2 = new Scaling(point3D, num);
		Vector2D vector2D = new Vector2D(Math.Cos(Angle), Math.Sin(Angle));
		Vector2D vector2D2 = new Vector2D(0.0 - Math.Sin(Angle), Math.Cos(Angle));
		vector2D.TransformBy(xform);
		vector2D2.TransformBy(xform);
		Point2D point2D = Origin + _0023_003Dz1L3TZOcNA99t.PatternOrigin;
		point2D.TransformBy(xform);
		point2D.TransformBy(xform2);
		double num2 = vector2D.Angle;
		if (num2 < 0.0)
		{
			num2 += Math.PI * 2.0;
		}
		if (!_0023_003Dz4G3BO8QnR9ie(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, num2, point2D, vector2D, vector2D2, num, _0023_003Dz43pxRC2Rpyg7, out var _0023_003DzYN5c5WjV2Cmc))
		{
			return false;
		}
		foreach (var (_0023_003DzQ9zpGF0_003D, _0023_003DzeoY7iyo_003D) in _0023_003DzYN5c5WjV2Cmc)
		{
			if (!_0023_003DzgHCDpYtjiRKWNAh_KnrSaZo_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dz3I7CA0t7AHsj2lxbLQ_003D_003D, num, _0023_003DzeoY7iyo_003D, vector2D, _0023_003Dz43pxRC2Rpyg7 - list.Count, out var _0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D))
			{
				return false;
			}
			list.AddRange(_0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D);
		}
		_0023_003DzyIUKu5w_003D = new List<Point3D>(list.Count);
		_0023_003DzrdSL0CI_003D = new List<Point3D>();
		foreach (Segment3D item in list)
		{
			if (item.LengthSquared > 0.0)
			{
				_0023_003DzyIUKu5w_003D.Add(_0023_003Dzrgqz890sj_0024X9.PointAt(item.P0));
				_0023_003DzyIUKu5w_003D.Add(_0023_003Dzrgqz890sj_0024X9.PointAt(item.P1));
			}
			else
			{
				Point3D point3D2 = _0023_003Dzrgqz890sj_0024X9.PointAt(item.P0);
				_0023_003DzrdSL0CI_003D.Add(new PointTangent(point3D2.X, point3D2.Y, point3D2.Z, vector2D.X, vector2D.Y, 0.0));
			}
		}
		return true;
	}

	private bool _0023_003Dz4G3BO8QnR9ie(Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC, double _0023_003DzxqxZNyiygMO_0024, Point2D _0023_003DzIM9emfcucqP0, Vector2D _0023_003DzxvQyii0_003D, Vector2D _0023_003Dz8gu4oos_003D, double _0023_003DzoMBKEgY_003D, int _0023_003Dz43pxRC2Rpyg7, out List<Tuple<Segment2D, Point2D>> _0023_003DzYN5c5WjV2Cmc)
	{
		_0023_003DzYN5c5WjV2Cmc = new List<Tuple<Segment2D, Point2D>>();
		Segment2D segment2D;
		Segment2D segment2D2;
		if (Math.Cos(_0023_003DzxqxZNyiygMO_0024) >= -0.7071067811865476 && Math.Cos(_0023_003DzxqxZNyiygMO_0024) <= 0.7071067811865476)
		{
			segment2D = new Segment2D(_0023_003DzDPcjoBJLcqli.X, _0023_003DzDPcjoBJLcqli.Y, _0023_003Dz_0024N_0024yKptW9BoC.X, _0023_003DzDPcjoBJLcqli.Y);
			segment2D2 = new Segment2D(_0023_003DzDPcjoBJLcqli.X, _0023_003Dz_0024N_0024yKptW9BoC.Y, _0023_003Dz_0024N_0024yKptW9BoC.X, _0023_003Dz_0024N_0024yKptW9BoC.Y);
		}
		else
		{
			segment2D = new Segment2D(_0023_003DzDPcjoBJLcqli.X, _0023_003DzDPcjoBJLcqli.Y, _0023_003DzDPcjoBJLcqli.X, _0023_003Dz_0024N_0024yKptW9BoC.Y);
			segment2D2 = new Segment2D(_0023_003Dz_0024N_0024yKptW9BoC.X, _0023_003DzDPcjoBJLcqli.Y, _0023_003Dz_0024N_0024yKptW9BoC.X, _0023_003Dz_0024N_0024yKptW9BoC.Y);
		}
		if (Math.Tan(_0023_003DzxqxZNyiygMO_0024) >= 0.0)
		{
			Segment2D s = new Segment2D(segment2D2.P0, segment2D2.P0 + _0023_003DzxvQyii0_003D);
			Segment2D.IntersectionLine(segment2D, s, out var i);
			segment2D.P0 = i;
		}
		else
		{
			Segment2D s2 = new Segment2D(segment2D2.P1, segment2D2.P1 + _0023_003DzxvQyii0_003D);
			Segment2D.IntersectionLine(segment2D, s2, out var i2);
			segment2D.P1 = i2;
		}
		Vector2D vector2D = DeltaY * _0023_003Dz8gu4oos_003D;
		Vector2D vector2D2 = ((Pattern != null && Pattern.Length != 0) ? ((DeltaX > (double)_0023_003Dz4m952JDFwKpj()) ? (DeltaX % (double)_0023_003Dz4m952JDFwKpj() * _0023_003DzxvQyii0_003D) : (DeltaX * _0023_003DzxvQyii0_003D)) : new Vector3D(0.0, 0.0));
		vector2D *= _0023_003DzoMBKEgY_003D;
		vector2D2 *= _0023_003DzoMBKEgY_003D;
		Segment2D seg = new Segment2D(segment2D.P0, segment2D.P0 + _0023_003DzxvQyii0_003D);
		Vector2D vector2D3 = new Vector2D(_0023_003DzIM9emfcucqP0, _0023_003DzIM9emfcucqP0.ProjectTo(seg));
		double num = Math.Truncate(vector2D3.Length / (DeltaY * _0023_003DzoMBKEgY_003D));
		vector2D3.Normalize();
		if (Vector2D.AreOpposite(_0023_003Dz8gu4oos_003D, vector2D3))
		{
			vector2D.Negate();
			vector2D2.Negate();
		}
		_0023_003DzIM9emfcucqP0 += vector2D * num;
		_0023_003DzIM9emfcucqP0 += vector2D2 * num;
		Segment2D segment2D3 = new Segment2D((Point2D)_0023_003DzIM9emfcucqP0.Clone(), _0023_003DzIM9emfcucqP0 + _0023_003DzxvQyii0_003D);
		Segment2D segment2D4 = (Segment2D)segment2D3.Clone();
		Segment2D.IntersectionLine(segment2D3, segment2D, out var i3);
		double num2 = segment2D.Project(i3);
		Segment2D.IntersectionLine(new Segment2D(segment2D4.P0 + vector2D, segment2D4.P1 + vector2D), segment2D, out var i4);
		double num3 = segment2D.Project(i4);
		if (1.0 / Math.Abs(num3 - num2) > (double)_0023_003Dz43pxRC2Rpyg7)
		{
			return false;
		}
		if (num3 < num2)
		{
			vector2D.Negate();
			vector2D2.Negate();
		}
		int num4 = 0;
		while (num2 <= 1.0)
		{
			if (num2 >= 0.0)
			{
				Segment2D.IntersectionLine(segment2D4, segment2D2, out var i5);
				segment2D4 = new Segment2D(i3, i5);
				_0023_003DzYN5c5WjV2Cmc.Add(new Tuple<Segment2D, Point2D>((Segment2D)segment2D4.Clone(), _0023_003DzIM9emfcucqP0 + vector2D2 * num4));
			}
			segment2D4.P0 += vector2D;
			segment2D4.P1 += vector2D;
			num4++;
			Segment2D.IntersectionLine(segment2D4, segment2D, out i3);
			num2 = segment2D.Project(i3);
		}
		return true;
	}

	private bool _0023_003DzgHCDpYtjiRKWNAh_KnrSaZo_003D(Segment2D _0023_003DzQ9zpGF0_003D, IList<Polygon2D> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, float _0023_003DzoMBKEgY_003D, Point2D _0023_003DzeoY7iyo_003D, Vector2D _0023_003DzxvQyii0_003D, int _0023_003Dz43pxRC2Rpyg7, out List<Segment3D> _0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D)
	{
		Vector2D vector2D = new Vector2D(_0023_003DzQ9zpGF0_003D.P0, _0023_003DzQ9zpGF0_003D.P1);
		vector2D.Normalize();
		if (Vector2D.AreOpposite(vector2D, _0023_003DzxvQyii0_003D))
		{
			_0023_003DzQ9zpGF0_003D = new Segment2D(_0023_003DzQ9zpGF0_003D.P1, _0023_003DzQ9zpGF0_003D.P0);
		}
		_0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D = new List<Segment3D>();
		Segment2D[] array = _0023_003Dz9y6F_0024pWf69VkHAqP5Ep4FcSlwwoD._0023_003DzrBa6h4XZWRQzuJ57ZYmUNw0_003D(_0023_003DzQ9zpGF0_003D, _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D);
		if (array.Length > _0023_003Dz43pxRC2Rpyg7)
		{
			return false;
		}
		Segment2D[] array2 = array;
		foreach (Segment2D segment2D in array2)
		{
			Segment3D segment3D = new Segment3D(segment2D.P0.X, segment2D.P0.Y, 0.0, segment2D.P1.X, segment2D.P1.Y, 0.0);
			if (Pattern == null || Pattern.Length == 0)
			{
				_0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D.Add(segment3D);
				continue;
			}
			int num = Pattern.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzWJ5HgdrvjB8bKAdB53Yugnf8b7ojPe6Gvg_003D_003D) * (int)(segment3D.Length / (double)(_0023_003Dz4m952JDFwKpj() * _0023_003DzoMBKEgY_003D));
			if (_0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D.Count + num > _0023_003Dz43pxRC2Rpyg7)
			{
				return false;
			}
			double num2 = segment3D.Project(new Point3D(_0023_003DzeoY7iyo_003D.X, _0023_003DzeoY7iyo_003D.Y));
			double num3 = (double)(_0023_003Dz4m952JDFwKpj() * _0023_003DzoMBKEgY_003D) / segment3D.Length;
			double num4 = num2 % num3;
			if (num4 > 0.0)
			{
				num4 -= num3;
			}
			Segment3D seg = new Segment3D(segment3D.PointAt(num4), segment3D.P0);
			int index = 0;
			double excess = 0.0;
			LineType.GetPenDowns(seg, Pattern, _0023_003DzoMBKEgY_003D, out var _, ref index, ref excess);
			LineType.GetPenDowns(segment3D, Pattern, _0023_003DzoMBKEgY_003D, out var penDownList2, ref index, ref excess);
			_0023_003Dzq1t0WXl0oCR_47A7LQ_003D_003D.AddRange(penDownList2);
		}
		return true;
	}

	public virtual object Clone()
	{
		return new HatchPatternLine(this);
	}
}
