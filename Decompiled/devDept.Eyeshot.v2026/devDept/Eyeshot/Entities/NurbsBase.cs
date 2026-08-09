using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Entities;

public abstract class NurbsBase : Entity
{
	internal enum _0023_003DzKmXuOEFfAuxU
	{

	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzB68dg9Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double[] _0023_003DziP9fFuA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double[] _0023_003DzpugXdEauu4S6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double[] _0023_003Dzhn3YS1oCYpgh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double[][] _0023_003Dz0Dp6TuGHZM0i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DzY4aSZhsxxKuYiBMwvg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzKmXuOEFfAuxU _0023_003Dz1c2CfcL6J3Hu;

	[NonSerialized]
	protected bool geometricalAttributesDirty = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzvRue7ps_003D;

	public bool ShowControl
	{
		get
		{
			return _0023_003DzvRue7ps_003D;
		}
		set
		{
			_0023_003DzvRue7ps_003D = value;
		}
	}

	protected NurbsBase(entityNatureType entityNature)
		: base(entityNature)
	{
		_0023_003DzCBXaK_002496NUpX(3);
	}

	protected NurbsBase(NurbsBase another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
	}

	static NurbsBase()
	{
		_0023_003Dzhn3YS1oCYpgh = new double[30]
		{
			0.25,
			0.75,
			0.125,
			0.375,
			0.625,
			0.875,
			0.0625,
			0.1875,
			0.3125,
			0.4375,
			0.5625,
			0.6875,
			0.8125,
			0.9375,
			1.0 / 32.0,
			3.0 / 32.0,
			5.0 / 32.0,
			7.0 / 32.0,
			9.0 / 32.0,
			11.0 / 32.0,
			13.0 / 32.0,
			15.0 / 32.0,
			17.0 / 32.0,
			19.0 / 32.0,
			21.0 / 32.0,
			23.0 / 32.0,
			25.0 / 32.0,
			27.0 / 32.0,
			29.0 / 32.0,
			31.0 / 32.0
		};
		_0023_003Dz0Dp6TuGHZM0i = new double[0][];
		_0023_003DzY4aSZhsxxKuYiBMwvg_003D_003D = -1;
		_0023_003DzpRz4xD8k0k7hNQTOxg_003D_003D(20);
	}

	public NurbsBase(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
	}

	internal static void _0023_003Dzy_0024hwVn0_003D(ref double _0023_003Dz_eY3Y4c_003D, double[] _0023_003DziP9fFuA_003D, double _0023_003DzhbkBViI_003D)
	{
		foreach (double num in _0023_003DziP9fFuA_003D)
		{
			if (Math.Abs(num - _0023_003Dz_eY3Y4c_003D) / _0023_003DzhbkBViI_003D < 1E-06)
			{
				_0023_003Dz_eY3Y4c_003D = num;
				break;
			}
		}
	}

	internal static double _0023_003Dz_0024Ad3BZI_003D(int _0023_003DzB68dg9Q_003D, int _0023_003DzN6G05Lg_003D)
	{
		if (_0023_003DzB68dg9Q_003D > 20)
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302973471), 20, _0023_003DzB68dg9Q_003D));
		}
		if (_0023_003DzN6G05Lg_003D > _0023_003DzB68dg9Q_003D || _0023_003DzN6G05Lg_003D < 0 || _0023_003DzB68dg9Q_003D < 0)
		{
			return 0.0;
		}
		return _0023_003Dz0Dp6TuGHZM0i[_0023_003DzB68dg9Q_003D][_0023_003DzN6G05Lg_003D];
	}

	private static void _0023_003DzpRz4xD8k0k7hNQTOxg_003D_003D(int _0023_003DzJ_0024_0024h1ss_003D)
	{
		if (_0023_003Dz0Dp6TuGHZM0i != null && _0023_003Dz0Dp6TuGHZM0i.Length != 0)
		{
			double[][] array = new double[_0023_003DzJ_0024_0024h1ss_003D + 1][];
			for (int i = 0; i < _0023_003Dz0Dp6TuGHZM0i.Length; i++)
			{
				array[i] = _0023_003Dz0Dp6TuGHZM0i[i];
			}
			_0023_003Dz0Dp6TuGHZM0i = array;
		}
		else
		{
			_0023_003Dz0Dp6TuGHZM0i = new double[_0023_003DzJ_0024_0024h1ss_003D + 1][];
		}
		for (int j = _0023_003DzY4aSZhsxxKuYiBMwvg_003D_003D + 1; j <= _0023_003DzJ_0024_0024h1ss_003D; j++)
		{
			_0023_003Dz0Dp6TuGHZM0i[j] = new double[j + 1];
			if (j == 0)
			{
				_0023_003Dz0Dp6TuGHZM0i[0][0] = 1.0;
				continue;
			}
			for (int k = 0; k <= j; k++)
			{
				double num = ((k != 0) ? _0023_003Dz0Dp6TuGHZM0i[j - 1][k - 1] : 0.0);
				double num2 = ((k <= j - 1) ? _0023_003Dz0Dp6TuGHZM0i[j - 1][k] : 0.0);
				_0023_003Dz0Dp6TuGHZM0i[j][k] = num + num2;
			}
		}
		_0023_003DzY4aSZhsxxKuYiBMwvg_003D_003D = _0023_003DzJ_0024_0024h1ss_003D;
	}

	protected static double Bernstain(int i, int n, double u)
	{
		double[] array = new double[n + 1];
		array[n - i] = 1.0;
		double num = 1.0 - u;
		for (int j = 1; j <= n; j++)
		{
			for (int num2 = n; num2 >= j; num2--)
			{
				array[num2] = num * array[num2] + u * array[num2 - 1];
			}
		}
		return array[n];
	}

	protected static double BernstainDer(int i, int n, double u)
	{
		if (i == 0)
		{
			if (i == n)
			{
				return 0.0;
			}
			return (double)n * (0.0 - Bernstain(i, n - 1, u));
		}
		if (i == n)
		{
			return (double)n * Bernstain(i - 1, n - 1, u);
		}
		return (double)n * (Bernstain(i - 1, n - 1, u) - Bernstain(i, n - 1, u));
	}

	public static double ChordLengthParametrization<T>(IList<T> Q, out double[] ub, bool square = false) where T : Point3D
	{
		double[] distances;
		return ChordLengthParametrization(0, Q.Count, Q, out distances, out ub, square);
	}

	public static double ChordLengthParametrization<T>(int from, int to, IList<T> Q, out double[] distances, out double[] ub, bool square = false) where T : Point3D
	{
		int num = to - from;
		double num2 = 0.0;
		distances = new double[num];
		for (int i = from + 1; i < to; i++)
		{
			T val = Q[i];
			Point3D point3D = Q[i - 1];
			double num3 = val.X - point3D.X;
			double num4 = val.Y - point3D.Y;
			double num5 = val.Z - point3D.Z;
			double num6 = (square ? Math.Sqrt(Math.Sqrt(num3 * num3 + num4 * num4 + num5 * num5)) : Math.Sqrt(num3 * num3 + num4 * num4 + num5 * num5));
			distances[i - from] = num6;
			num2 += num6;
		}
		_0023_003DzrYXEkm3JIzJSWz0OLBC4hoM_003D(num, distances, num2, out ub, square);
		return num2;
	}

	internal static void _0023_003DzrYXEkm3JIzJSWz0OLBC4hoM_003D(int _0023_003Dz9JZgoew_003D, double[] _0023_003Dzm31E4f0eLEcvrLl9WQ_003D_003D, double _0023_003DzGciz8G02kWNQ, out double[] _0023_003Dzf9Vy1JQ_003D, bool _0023_003Dz0jndlI35hm2U)
	{
		_0023_003Dzf9Vy1JQ_003D = new double[_0023_003Dz9JZgoew_003D];
		if (_0023_003DzGciz8G02kWNQ > 0.0)
		{
			for (int i = 1; i < _0023_003Dz9JZgoew_003D - 1; i++)
			{
				_0023_003Dzf9Vy1JQ_003D[i] = _0023_003Dzf9Vy1JQ_003D[i - 1] + _0023_003Dzm31E4f0eLEcvrLl9WQ_003D_003D[i] / _0023_003DzGciz8G02kWNQ;
			}
			_0023_003Dzf9Vy1JQ_003D[_0023_003Dz9JZgoew_003D - 1] = 1.0;
		}
		else
		{
			for (int j = 1; j < _0023_003Dz9JZgoew_003D - 1; j++)
			{
				_0023_003Dzf9Vy1JQ_003D[j] = j / _0023_003Dz9JZgoew_003D - 1;
			}
			_0023_003Dzf9Vy1JQ_003D[_0023_003Dz9JZgoew_003D - 1] = 1.0;
		}
	}

	internal static void _0023_003DzP0A53cFshwnVQKkCf4TpIss_003D(double[] _0023_003Dz_0024aMC_00244k_003D, int _0023_003DzbU0rLpQ_003D, ref double[] _0023_003DziP9fFuA_003D)
	{
		Array.Resize(ref _0023_003DziP9fFuA_003D, _0023_003Dz_0024aMC_00244k_003D.Length + _0023_003DzbU0rLpQ_003D + 1);
		for (int i = 1; i < _0023_003Dz_0024aMC_00244k_003D.Length - _0023_003DzbU0rLpQ_003D; i++)
		{
			_0023_003DziP9fFuA_003D[i + _0023_003DzbU0rLpQ_003D] = 0.0;
			for (int j = i; j < i + _0023_003DzbU0rLpQ_003D; j++)
			{
				_0023_003DziP9fFuA_003D[i + _0023_003DzbU0rLpQ_003D] += _0023_003Dz_0024aMC_00244k_003D[j];
			}
			_0023_003DziP9fFuA_003D[i + _0023_003DzbU0rLpQ_003D] /= _0023_003DzbU0rLpQ_003D;
		}
		for (int k = 0; k <= _0023_003DzbU0rLpQ_003D; k++)
		{
			_0023_003DziP9fFuA_003D[k] = _0023_003Dz_0024aMC_00244k_003D[0];
		}
		for (int l = _0023_003DziP9fFuA_003D.Length - _0023_003DzbU0rLpQ_003D - 1; l < _0023_003DziP9fFuA_003D.Length; l++)
		{
			_0023_003DziP9fFuA_003D[l] = _0023_003Dz_0024aMC_00244k_003D[^1];
		}
	}

	private protected virtual void _0023_003Dz7roAELUN1jwt()
	{
		geometricalAttributesDirty = true;
	}

	public abstract void ControlBoundingBox(out Point3D min, out Point3D max);

	public void ControlBoundingBox(double inflateBy, out Point3D min, out Point3D max)
	{
		ControlBoundingBox(out min, out max);
		min.X -= inflateBy;
		min.Y -= inflateBy;
		min.Z -= inflateBy;
		max.X += inflateBy;
		max.Y += inflateBy;
		max.Z += inflateBy;
	}

	public abstract Size3D ControlBoundingBox();

	internal void _0023_003Dzx6R3pGE2FVDTWBiMuw_003D_003D(double[] _0023_003DzAvn2b38_003D)
	{
		int num = _0023_003DzAvn2b38_003D.Length - 1;
		double num2 = 0.0;
		double num3 = 1.0;
		double num4 = 1.0;
		double num5 = 0.5;
		int num6 = num;
		for (int num7 = 2; num7 < num6 - num7 - 1; num7 *= 2)
		{
			_0023_003DzAvn2b38_003D[0] = num5 * 0.5;
			for (int i = 1; i <= num7; i++)
			{
				_0023_003DzAvn2b38_003D[i] = num5 / (double)(1 - 4 * i * i);
			}
			_0023_003DzAvn2b38_003D[num7] *= 0.5;
			_0023_003DzKAz_ZEbHdmvq(num7, 0.5 * num2, num3, _0023_003DzAvn2b38_003D);
			num2 = Math.Sqrt(2.0 + num2);
			num3 /= num2;
			num4 = (_0023_003DzAvn2b38_003D[num6] = num4 / (2.0 + num2));
			_0023_003DzAvn2b38_003D[num6 - 1] = _0023_003DzAvn2b38_003D[0];
			_0023_003DzAvn2b38_003D[num6 - 2] = _0023_003DzAvn2b38_003D[num7];
			num6 -= 3;
			int num8 = num7;
			while (num8 > 1)
			{
				num8 >>= 1;
				for (int i = num8; i <= num7 - num8; i += num8 << 1)
				{
					_0023_003DzAvn2b38_003D[num6] = _0023_003DzAvn2b38_003D[i];
					num6--;
				}
			}
			num5 *= 0.5;
		}
	}

	public static double[] UniformKnotVector(int p, int n)
	{
		double[] array = new double[n + p + 1];
		for (int i = 0; i <= p; i++)
		{
			array[i] = 0.0;
			array[n + i] = 1.0;
		}
		int num = n - p;
		double num2 = 1f / (float)num;
		for (int j = p; j < n; j++)
		{
			array[j] = array[p] + num2 * (double)(j - p);
		}
		return array;
	}

	internal static double[] _0023_003Dz7jvBnSNb_J4p_MHxFTUMnyU_003D(int _0023_003DzoMNiNRw_003D)
	{
		double[] array = new double[_0023_003DzoMNiNRw_003D + 3 + 1 + _0023_003DzoMNiNRw_003D];
		for (int i = 0; i <= 3; i++)
		{
			array[i] = 0.0;
			array[_0023_003DzoMNiNRw_003D + i + _0023_003DzoMNiNRw_003D] = 1.0;
		}
		int num = _0023_003DzoMNiNRw_003D - 1;
		double num2 = 1f / (float)num;
		for (int j = 0; j < _0023_003DzoMNiNRw_003D - 2; j++)
		{
			array[4 + 2 * j] = array[3] + num2 * (double)(j + 1);
			array[4 + 2 * j + 1] = array[4 + 2 * j];
		}
		return array;
	}

	internal abstract void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();

	internal static bool _0023_003DzN2CR_YoUpoGCkzzbhw_003D_003D(Point3D _0023_003Dzl3DhHgI_003D, Point4D[] _0023_003DzpDQeEMI7yWiW)
	{
		int num = _0023_003DzpDQeEMI7yWiW.Length - 1;
		Point3D euclid = _0023_003DzpDQeEMI7yWiW[0].Euclid;
		Point3D euclid2 = _0023_003DzpDQeEMI7yWiW[1].Euclid;
		Point3D euclid3 = _0023_003DzpDQeEMI7yWiW[num - 1].Euclid;
		Point3D euclid4 = _0023_003DzpDQeEMI7yWiW[num].Euclid;
		Vector3D vector3D = new Vector3D(euclid, _0023_003Dzl3DhHgI_003D);
		Vector3D vector3D2 = new Vector3D(euclid4, euclid);
		double num2 = vector3D * new Vector3D(euclid, euclid2);
		double num3 = new Vector3D(euclid4, _0023_003Dzl3DhHgI_003D) * new Vector3D(euclid4, euclid3);
		double num4 = vector3D2 * new Vector3D(euclid4, _0023_003Dzl3DhHgI_003D);
		double num5 = vector3D2 * vector3D;
		if ((num2 < 0.0 || num3 < 0.0) && num4 * num5 > 0.0)
		{
			if (Math.Abs(num2) < Utility._0023_003DzxhnLabVjXjPg || Math.Abs(num3) < Utility._0023_003DzxhnLabVjXjPg)
			{
				return true;
			}
			vector3D2.Normalize();
			vector3D.Normalize();
			Vector3D vector3D3 = new Vector3D(euclid4, _0023_003Dzl3DhHgI_003D);
			vector3D3.Normalize();
			Vector3D.AngleBetween(vector3D2, vector3D3);
			Vector3D.AngleBetween(vector3D2, vector3D);
			return false;
		}
		return true;
	}

	internal static bool _0023_003DzE5Q9OFZ0j3Jvz4z1akEIAtCl1_0024bonJ6plQ_003D_003D(Point3D _0023_003Dzl3DhHgI_003D, Point4D[] _0023_003DzpDQeEMI7yWiW)
	{
		int num = _0023_003DzpDQeEMI7yWiW.Length - 1;
		Point3D euclid = _0023_003DzpDQeEMI7yWiW[0].Euclid;
		Point3D euclid2 = _0023_003DzpDQeEMI7yWiW[num].Euclid;
		Point3D point3D = new Point3D();
		point3D = ((!(Point3D.DistanceSquared(_0023_003Dzl3DhHgI_003D, euclid) <= Point3D.DistanceSquared(_0023_003Dzl3DhHgI_003D, euclid2))) ? ((Point3D)euclid2.Clone()) : ((Point3D)euclid.Clone()));
		Vector3D vector3D = new Vector3D(_0023_003Dzl3DhHgI_003D, point3D);
		foreach (Point4D point4D in _0023_003DzpDQeEMI7yWiW)
		{
			if (vector3D * new Vector3D(point3D, point4D.Euclid) < -1E-12)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003DzNYEnrprpSbmW(Point4D[] _0023_003DzpDQeEMI7yWiW)
	{
		int num = _0023_003DzpDQeEMI7yWiW.Length - 1;
		Point3D euclid = _0023_003DzpDQeEMI7yWiW[0].Euclid;
		Point3D euclid2 = _0023_003DzpDQeEMI7yWiW[num].Euclid;
		for (int i = 1; i < num; i++)
		{
			Point3D euclid3 = _0023_003DzpDQeEMI7yWiW[i - 1].Euclid;
			Point3D euclid4 = _0023_003DzpDQeEMI7yWiW[i + 1].Euclid;
			Segment3D seg = new Segment3D(euclid3, euclid4);
			Point3D euclid5 = _0023_003DzpDQeEMI7yWiW[i].Euclid;
			Vector3D vector3D = new Vector3D(euclid5.ProjectTo(seg), euclid5);
			double num2;
			if (i < num / 2)
			{
				Point3D p = euclid2.ProjectTo(seg);
				num2 = vector3D * new Vector3D(p, euclid2);
			}
			else
			{
				Point3D p = euclid.ProjectTo(seg);
				num2 = vector3D * new Vector3D(p, euclid);
			}
			if (num2 > 1E-09)
			{
				return false;
			}
		}
		return true;
	}

	protected double[,] BezierToPowerMatrix(int p)
	{
		double[,] array = new double[p + 1, p + 1];
		array[0, 0] = (array[p, p] = 1.0);
		if (p % 2 > 0)
		{
			array[p, 0] = -1.0;
		}
		else
		{
			array[p, 0] = 1.0;
		}
		double num = -1.0;
		for (int i = 1; i < p; i++)
		{
			array[i, i] = _0023_003Dz_0024Ad3BZI_003D(p, i);
			array[i, 0] = (array[p, p - i] = num * array[i, i]);
			num = 0.0 - num;
		}
		int num2 = (p + 1) / 2;
		int num3 = p - 1;
		for (int j = 1; j < num2; j++)
		{
			num = -1.0;
			for (int k = j + 1; k <= num3; k++)
			{
				array[k, j] = (array[num3, p - k] = num * _0023_003Dz_0024Ad3BZI_003D(p, j) * _0023_003Dz_0024Ad3BZI_003D(p - j, k - j));
				num = 0.0 - num;
			}
			num3--;
		}
		return array;
	}

	protected static double[,] PowerToBezierMatrix(int p, double[,] M)
	{
		double[,] array = new double[M.GetLength(0), M.GetLength(1)];
		for (int i = 0; i <= p; i++)
		{
			array[i, 0] = (array[p, i] = 1.0);
			array[i, i] = 1.0 / M[i, i];
		}
		int num = (p + 1) / 2;
		int num2 = p - 1;
		for (int j = 1; j < num; j++)
		{
			for (int k = j + 1; k <= num2; k++)
			{
				double num3 = 0.0;
				for (int l = j; l < k; l++)
				{
					num3 -= M[k, l] * array[l, j];
				}
				array[k, j] = num3 / M[k, k];
				array[num2, p - k] = array[k, j];
			}
			num2--;
		}
		return array;
	}

	public static int Multiplicity(double[] knots, double u)
	{
		int num = 0;
		for (int i = 0; i < knots.Length; i++)
		{
			if (Math.Abs(knots[i] - u) < 1E-12)
			{
				num++;
			}
		}
		return num;
	}

	internal static int _0023_003DzV5xO_7_KG_6g6UfMSw_003D_003D(double[] _0023_003Dzr7tgnwG7XK6N)
	{
		int num = 1;
		for (int i = 1; i < _0023_003Dzr7tgnwG7XK6N.Length; i++)
		{
			if (Math.Abs(_0023_003Dzr7tgnwG7XK6N[i] - _0023_003Dzr7tgnwG7XK6N[i - 1]) > 1E-12)
			{
				num++;
			}
		}
		return num;
	}

	private void _0023_003DzKAz_ZEbHdmvq(int _0023_003DzoMNiNRw_003D, double _0023_003Dz70vtANc_003D, double _0023_003DzsbNiXlg_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		int num = _0023_003DzoMNiNRw_003D >> 1;
		for (int i = 0; i <= num - 1; i++)
		{
			int num2 = _0023_003DzoMNiNRw_003D - i;
			double num3 = _0023_003DzjbqS1qE_003D[i] + _0023_003DzjbqS1qE_003D[num2];
			_0023_003DzjbqS1qE_003D[i] -= _0023_003DzjbqS1qE_003D[num2];
			_0023_003DzjbqS1qE_003D[num2] = num3;
		}
		double num4 = _0023_003DzjbqS1qE_003D[_0023_003DzoMNiNRw_003D];
		double num6;
		while (num >= 2)
		{
			_0023_003Dz0cdeaj3uYeec(num, _0023_003Dz70vtANc_003D, _0023_003DzsbNiXlg_003D, _0023_003DzjbqS1qE_003D);
			double num3 = 1.0 - 2.0 * _0023_003DzsbNiXlg_003D * _0023_003DzsbNiXlg_003D;
			_0023_003DzsbNiXlg_003D *= 2.0 * _0023_003Dz70vtANc_003D;
			_0023_003Dz70vtANc_003D = num3;
			_0023_003DzITu_0024W9PDK8AG(num, _0023_003DzjbqS1qE_003D);
			int num5 = num >> 1;
			num6 = _0023_003DzjbqS1qE_003D[num];
			_0023_003DzjbqS1qE_003D[num] = _0023_003DzjbqS1qE_003D[0];
			_0023_003DzjbqS1qE_003D[0] = num4 - num6;
			num4 += num6;
			for (int i = 1; i <= num5 - 1; i++)
			{
				int num2 = num - i;
				num3 = _0023_003DzjbqS1qE_003D[num + num2];
				num6 = _0023_003DzjbqS1qE_003D[num + i];
				_0023_003DzjbqS1qE_003D[num + i] = _0023_003DzjbqS1qE_003D[i];
				_0023_003DzjbqS1qE_003D[num + num2] = _0023_003DzjbqS1qE_003D[num2];
				_0023_003DzjbqS1qE_003D[i] = num3 - num6;
				_0023_003DzjbqS1qE_003D[num2] = num3 + num6;
			}
			num3 = _0023_003DzjbqS1qE_003D[num5];
			_0023_003DzjbqS1qE_003D[num5] = _0023_003DzjbqS1qE_003D[num + num5];
			_0023_003DzjbqS1qE_003D[num + num5] = num3;
			num = num5;
		}
		num6 = _0023_003DzjbqS1qE_003D[1];
		_0023_003DzjbqS1qE_003D[1] = _0023_003DzjbqS1qE_003D[0];
		_0023_003DzjbqS1qE_003D[0] = num4 + num6;
		_0023_003DzjbqS1qE_003D[_0023_003DzoMNiNRw_003D] = num4 - num6;
		_0023_003DzITu_0024W9PDK8AG(_0023_003DzoMNiNRw_003D, _0023_003DzjbqS1qE_003D);
	}

	private void _0023_003Dz0cdeaj3uYeec(int _0023_003DzoMNiNRw_003D, double _0023_003Dz70vtANc_003D, double _0023_003DzsbNiXlg_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		if (_0023_003DzoMNiNRw_003D > 2)
		{
			double num = 0.5;
			double num2 = 0.5;
			double num3 = 0.5 * (_0023_003Dz70vtANc_003D - _0023_003DzsbNiXlg_003D);
			double num4 = 0.5 * (_0023_003Dz70vtANc_003D + _0023_003DzsbNiXlg_003D);
			double num5 = 2.0 * _0023_003DzsbNiXlg_003D;
			double num6;
			int num7;
			if (_0023_003DzsbNiXlg_003D < 0.0)
			{
				num6 = _0023_003DzjbqS1qE_003D[_0023_003DzoMNiNRw_003D - 1];
				for (num7 = _0023_003DzoMNiNRw_003D - 2; num7 >= 2; num7 -= 2)
				{
					_0023_003DzjbqS1qE_003D[num7 + 1] = _0023_003DzjbqS1qE_003D[num7] - _0023_003DzjbqS1qE_003D[num7 - 1];
					_0023_003DzjbqS1qE_003D[num7] += _0023_003DzjbqS1qE_003D[num7 - 1];
				}
				_0023_003DzjbqS1qE_003D[1] = 2.0 * num6;
				_0023_003DzjbqS1qE_003D[0] *= 2.0;
				_0023_003DzAiLMa08AsdFt(_0023_003DzoMNiNRw_003D, 1.0 - num5 * _0023_003DzsbNiXlg_003D, num5 * _0023_003Dz70vtANc_003D, _0023_003DzjbqS1qE_003D);
				num6 = num3;
				num3 = num4;
				num4 = num6;
				num5 = 0.0 - num5;
			}
			int num8 = _0023_003DzoMNiNRw_003D >> 1;
			int num9;
			for (num7 = 1; num7 <= num8 - 3; num7 += 2)
			{
				num9 = _0023_003DzoMNiNRw_003D - num7;
				num6 = num4 * _0023_003DzjbqS1qE_003D[num7] - num3 * _0023_003DzjbqS1qE_003D[num9];
				_0023_003DzjbqS1qE_003D[num7] = num3 * _0023_003DzjbqS1qE_003D[num7] + num4 * _0023_003DzjbqS1qE_003D[num9];
				_0023_003DzjbqS1qE_003D[num9] = num6;
				num -= num5 * num4;
				num2 += num5 * num3;
				num6 = num2 * _0023_003DzjbqS1qE_003D[num7 + 1] - num * _0023_003DzjbqS1qE_003D[num9 - 1];
				_0023_003DzjbqS1qE_003D[num7 + 1] = num * _0023_003DzjbqS1qE_003D[num7 + 1] + num2 * _0023_003DzjbqS1qE_003D[num9 - 1];
				_0023_003DzjbqS1qE_003D[num9 - 1] = num6;
				num3 -= num5 * num2;
				num4 += num5 * num;
			}
			num7 = num8 - 1;
			num9 = _0023_003DzoMNiNRw_003D - num7;
			num6 = num4 * _0023_003DzjbqS1qE_003D[num7] - num3 * _0023_003DzjbqS1qE_003D[num9];
			_0023_003DzjbqS1qE_003D[num7] = num3 * _0023_003DzjbqS1qE_003D[num7] + num4 * _0023_003DzjbqS1qE_003D[num9];
			_0023_003DzjbqS1qE_003D[num9] = num6;
			_0023_003DzjbqS1qE_003D[num8] *= num2 + num5 * num3;
			if (_0023_003DzsbNiXlg_003D >= 0.0)
			{
				_0023_003DzAiLMa08AsdFt(_0023_003DzoMNiNRw_003D, 1.0 - num5 * _0023_003DzsbNiXlg_003D, num5 * _0023_003Dz70vtANc_003D, _0023_003DzjbqS1qE_003D);
				num6 = _0023_003DzjbqS1qE_003D[1];
				for (num7 = 2; num7 <= _0023_003DzoMNiNRw_003D - 2; num7 += 2)
				{
					_0023_003DzjbqS1qE_003D[num7 - 1] = _0023_003DzjbqS1qE_003D[num7] - _0023_003DzjbqS1qE_003D[num7 + 1];
					_0023_003DzjbqS1qE_003D[num7] += _0023_003DzjbqS1qE_003D[num7 + 1];
				}
				_0023_003DzjbqS1qE_003D[_0023_003DzoMNiNRw_003D - 1] = num6;
			}
		}
		else if (_0023_003DzsbNiXlg_003D >= 0.0)
		{
			double num6 = 0.5 * (_0023_003Dz70vtANc_003D + _0023_003DzsbNiXlg_003D) * _0023_003DzjbqS1qE_003D[1];
			_0023_003DzjbqS1qE_003D[1] = _0023_003DzjbqS1qE_003D[0] - num6;
			_0023_003DzjbqS1qE_003D[0] += num6;
		}
		else
		{
			double num6 = _0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[1];
			_0023_003DzjbqS1qE_003D[0] += _0023_003DzjbqS1qE_003D[1];
			_0023_003DzjbqS1qE_003D[1] = 0.5 * (_0023_003Dz70vtANc_003D - _0023_003DzsbNiXlg_003D) * num6;
		}
	}

	private void _0023_003DzITu_0024W9PDK8AG(int _0023_003DzoMNiNRw_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		if (_0023_003DzoMNiNRw_003D <= 2)
		{
			return;
		}
		int num = _0023_003DzoMNiNRw_003D >> 2;
		int num2 = num << 1;
		int num3 = _0023_003DzoMNiNRw_003D - 1;
		int num4 = 0;
		for (int i = 0; i <= num2 - 2; i += 2)
		{
			double num5;
			if (i < num4)
			{
				num5 = _0023_003DzjbqS1qE_003D[i];
				_0023_003DzjbqS1qE_003D[i] = _0023_003DzjbqS1qE_003D[num4];
				_0023_003DzjbqS1qE_003D[num4] = num5;
			}
			else if (i > num4)
			{
				num5 = _0023_003DzjbqS1qE_003D[num3 - i];
				_0023_003DzjbqS1qE_003D[num3 - i] = _0023_003DzjbqS1qE_003D[num3 - num4];
				_0023_003DzjbqS1qE_003D[num3 - num4] = num5;
			}
			num5 = _0023_003DzjbqS1qE_003D[i + 1];
			_0023_003DzjbqS1qE_003D[i + 1] = _0023_003DzjbqS1qE_003D[num2 + num4];
			_0023_003DzjbqS1qE_003D[num2 + num4] = num5;
			int num6 = num;
			while (num4 >= num6)
			{
				num4 -= num6;
				num6 >>= 1;
			}
			num4 += num6;
		}
	}

	private void _0023_003DzAiLMa08AsdFt(int _0023_003DzoMNiNRw_003D, double _0023_003Dz70vtANc_003D, double _0023_003DzsbNiXlg_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		if (_0023_003DzoMNiNRw_003D > 4)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = _0023_003DzsbNiXlg_003D * _0023_003DzsbNiXlg_003D;
			double num4 = _0023_003DzsbNiXlg_003D * _0023_003Dz70vtANc_003D;
			double num5 = 4.0 * num4;
			_0023_003Dz70vtANc_003D = 1.0 - 2.0 * num3;
			_0023_003DzsbNiXlg_003D = 2.0 * num4;
			double num6;
			if (_0023_003DzsbNiXlg_003D >= 0.0)
			{
				_0023_003Dz6wQjeLu6pdqV(_0023_003DzoMNiNRw_003D, _0023_003Dz70vtANc_003D, _0023_003DzsbNiXlg_003D, _0023_003DzjbqS1qE_003D);
				num6 = _0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[1];
				_0023_003DzjbqS1qE_003D[0] += _0023_003DzjbqS1qE_003D[1];
				_0023_003DzjbqS1qE_003D[1] = num6;
			}
			int num8;
			double num9;
			double num10;
			double num11;
			for (int num7 = (_0023_003DzoMNiNRw_003D >> 1) - 4; num7 >= 4; num7 -= 4)
			{
				num8 = _0023_003DzoMNiNRw_003D - num7;
				num9 = _0023_003DzjbqS1qE_003D[num7 + 2] - _0023_003DzjbqS1qE_003D[num8 - 2];
				num6 = _0023_003DzjbqS1qE_003D[num7 + 3] + _0023_003DzjbqS1qE_003D[num8 - 1];
				num10 = num3 * num9 - num4 * num6;
				num11 = num3 * num6 + num4 * num9;
				_0023_003DzjbqS1qE_003D[num7 + 2] -= num10;
				_0023_003DzjbqS1qE_003D[num7 + 3] -= num11;
				_0023_003DzjbqS1qE_003D[num8 - 2] += num10;
				_0023_003DzjbqS1qE_003D[num8 - 1] -= num11;
				num += num5 * num4;
				num2 += num5 * (0.5 - num3);
				num9 = _0023_003DzjbqS1qE_003D[num7] - _0023_003DzjbqS1qE_003D[num8];
				num6 = _0023_003DzjbqS1qE_003D[num7 + 1] + _0023_003DzjbqS1qE_003D[num8 + 1];
				num10 = num * num9 - num2 * num6;
				num11 = num * num6 + num2 * num9;
				_0023_003DzjbqS1qE_003D[num7] -= num10;
				_0023_003DzjbqS1qE_003D[num7 + 1] -= num11;
				_0023_003DzjbqS1qE_003D[num8] += num10;
				_0023_003DzjbqS1qE_003D[num8 + 1] -= num11;
				num3 += num5 * num2;
				num4 += num5 * (0.5 - num);
			}
			num8 = _0023_003DzoMNiNRw_003D - 2;
			num9 = _0023_003DzjbqS1qE_003D[2] - _0023_003DzjbqS1qE_003D[num8];
			num6 = _0023_003DzjbqS1qE_003D[3] + _0023_003DzjbqS1qE_003D[num8 + 1];
			num10 = num3 * num9 - num4 * num6;
			num11 = num3 * num6 + num4 * num9;
			_0023_003DzjbqS1qE_003D[2] -= num10;
			_0023_003DzjbqS1qE_003D[3] -= num11;
			_0023_003DzjbqS1qE_003D[num8] += num10;
			_0023_003DzjbqS1qE_003D[num8 + 1] -= num11;
			if (_0023_003DzsbNiXlg_003D < 0.0)
			{
				_0023_003DzjbqS1qE_003D[1] = 0.5 * (_0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[1]);
				_0023_003DzjbqS1qE_003D[0] -= _0023_003DzjbqS1qE_003D[1];
				_0023_003Dz6wQjeLu6pdqV(_0023_003DzoMNiNRw_003D, _0023_003Dz70vtANc_003D, _0023_003DzsbNiXlg_003D, _0023_003DzjbqS1qE_003D);
			}
		}
		else
		{
			if (_0023_003DzsbNiXlg_003D < 0.0)
			{
				_0023_003DzjbqS1qE_003D[1] = 0.5 * (_0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[1]);
				_0023_003DzjbqS1qE_003D[0] -= _0023_003DzjbqS1qE_003D[1];
			}
			if (_0023_003DzoMNiNRw_003D > 2)
			{
				double num9 = _0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[2];
				double num6 = _0023_003DzjbqS1qE_003D[1] - _0023_003DzjbqS1qE_003D[3];
				_0023_003DzjbqS1qE_003D[0] += _0023_003DzjbqS1qE_003D[2];
				_0023_003DzjbqS1qE_003D[1] += _0023_003DzjbqS1qE_003D[3];
				_0023_003DzjbqS1qE_003D[2] = num9;
				_0023_003DzjbqS1qE_003D[3] = num6;
			}
			if (_0023_003DzsbNiXlg_003D >= 0.0)
			{
				double num6 = _0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[1];
				_0023_003DzjbqS1qE_003D[0] += _0023_003DzjbqS1qE_003D[1];
				_0023_003DzjbqS1qE_003D[1] = num6;
			}
		}
	}

	private void _0023_003Dz6wQjeLu6pdqV(int _0023_003DzoMNiNRw_003D, double _0023_003Dz70vtANc_003D, double _0023_003DzsbNiXlg_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		int num = _0023_003DzoMNiNRw_003D;
		while (num > 4)
		{
			int num2 = num >> 1;
			double num3 = 1.0;
			double num4 = 0.0;
			double num5 = 1.0 - 2.0 * _0023_003DzsbNiXlg_003D * _0023_003DzsbNiXlg_003D;
			double num6 = 2.0 * _0023_003DzsbNiXlg_003D * _0023_003Dz70vtANc_003D;
			double num7 = 2.0 * num6;
			_0023_003Dz70vtANc_003D = num5;
			_0023_003DzsbNiXlg_003D = num6;
			for (int i = 0; i <= _0023_003DzoMNiNRw_003D - num; i += num)
			{
				int num8 = i + num2;
				double num9 = _0023_003DzjbqS1qE_003D[i] - _0023_003DzjbqS1qE_003D[num8];
				double num10 = _0023_003DzjbqS1qE_003D[i + 1] - _0023_003DzjbqS1qE_003D[num8 + 1];
				_0023_003DzjbqS1qE_003D[i] += _0023_003DzjbqS1qE_003D[num8];
				_0023_003DzjbqS1qE_003D[i + 1] += _0023_003DzjbqS1qE_003D[num8 + 1];
				_0023_003DzjbqS1qE_003D[num8] = num9;
				_0023_003DzjbqS1qE_003D[num8 + 1] = num10;
				num9 = _0023_003DzjbqS1qE_003D[i + 2] - _0023_003DzjbqS1qE_003D[num8 + 2];
				num10 = _0023_003DzjbqS1qE_003D[i + 3] - _0023_003DzjbqS1qE_003D[num8 + 3];
				_0023_003DzjbqS1qE_003D[i + 2] += _0023_003DzjbqS1qE_003D[num8 + 2];
				_0023_003DzjbqS1qE_003D[i + 3] += _0023_003DzjbqS1qE_003D[num8 + 3];
				_0023_003DzjbqS1qE_003D[num8 + 2] = num5 * num9 - num6 * num10;
				_0023_003DzjbqS1qE_003D[num8 + 3] = num5 * num10 + num6 * num9;
			}
			for (int j = 4; j <= num2 - 4; j += 4)
			{
				num3 -= num7 * num6;
				num4 += num7 * num5;
				num5 -= num7 * num4;
				num6 += num7 * num3;
				for (int i = j; i <= _0023_003DzoMNiNRw_003D - num + j; i += num)
				{
					int num8 = i + num2;
					double num9 = _0023_003DzjbqS1qE_003D[i] - _0023_003DzjbqS1qE_003D[num8];
					double num10 = _0023_003DzjbqS1qE_003D[i + 1] - _0023_003DzjbqS1qE_003D[num8 + 1];
					_0023_003DzjbqS1qE_003D[i] += _0023_003DzjbqS1qE_003D[num8];
					_0023_003DzjbqS1qE_003D[i + 1] += _0023_003DzjbqS1qE_003D[num8 + 1];
					_0023_003DzjbqS1qE_003D[num8] = num3 * num9 - num4 * num10;
					_0023_003DzjbqS1qE_003D[num8 + 1] = num3 * num10 + num4 * num9;
					num9 = _0023_003DzjbqS1qE_003D[i + 2] - _0023_003DzjbqS1qE_003D[num8 + 2];
					num10 = _0023_003DzjbqS1qE_003D[i + 3] - _0023_003DzjbqS1qE_003D[num8 + 3];
					_0023_003DzjbqS1qE_003D[i + 2] += _0023_003DzjbqS1qE_003D[num8 + 2];
					_0023_003DzjbqS1qE_003D[i + 3] += _0023_003DzjbqS1qE_003D[num8 + 3];
					_0023_003DzjbqS1qE_003D[num8 + 2] = num5 * num9 - num6 * num10;
					_0023_003DzjbqS1qE_003D[num8 + 3] = num5 * num10 + num6 * num9;
				}
			}
			num = num2;
		}
		if (num > 2)
		{
			for (int i = 0; i <= _0023_003DzoMNiNRw_003D - 4; i += 4)
			{
				double num9 = _0023_003DzjbqS1qE_003D[i] - _0023_003DzjbqS1qE_003D[i + 2];
				double num10 = _0023_003DzjbqS1qE_003D[i + 1] - _0023_003DzjbqS1qE_003D[i + 3];
				_0023_003DzjbqS1qE_003D[i] += _0023_003DzjbqS1qE_003D[i + 2];
				_0023_003DzjbqS1qE_003D[i + 1] += _0023_003DzjbqS1qE_003D[i + 3];
				_0023_003DzjbqS1qE_003D[i + 2] = num9;
				_0023_003DzjbqS1qE_003D[i + 3] = num10;
			}
		}
		if (_0023_003DzoMNiNRw_003D > 4)
		{
			_0023_003Dzkh9cMd8kBOA4(_0023_003DzoMNiNRw_003D, _0023_003DzjbqS1qE_003D);
		}
	}

	private void _0023_003Dzkh9cMd8kBOA4(int _0023_003DzoMNiNRw_003D, double[] _0023_003DzjbqS1qE_003D)
	{
		int num = _0023_003DzoMNiNRw_003D >> 2;
		int num2 = num << 1;
		int num3 = _0023_003DzoMNiNRw_003D - 2;
		int num4 = 0;
		for (int i = 0; i <= num2 - 4; i += 4)
		{
			int num8;
			double num5;
			double num6;
			if (i < num4)
			{
				num5 = _0023_003DzjbqS1qE_003D[i];
				num6 = _0023_003DzjbqS1qE_003D[i + 1];
				_0023_003DzjbqS1qE_003D[i] = _0023_003DzjbqS1qE_003D[num4];
				_0023_003DzjbqS1qE_003D[i + 1] = _0023_003DzjbqS1qE_003D[num4 + 1];
				_0023_003DzjbqS1qE_003D[num4] = num5;
				_0023_003DzjbqS1qE_003D[num4 + 1] = num6;
			}
			else if (i > num4)
			{
				int num7 = num3 - i;
				num8 = num3 - num4;
				num5 = _0023_003DzjbqS1qE_003D[num7];
				num6 = _0023_003DzjbqS1qE_003D[num7 + 1];
				_0023_003DzjbqS1qE_003D[num7] = _0023_003DzjbqS1qE_003D[num8];
				_0023_003DzjbqS1qE_003D[num7 + 1] = _0023_003DzjbqS1qE_003D[num8 + 1];
				_0023_003DzjbqS1qE_003D[num8] = num5;
				_0023_003DzjbqS1qE_003D[num8 + 1] = num6;
			}
			num8 = num2 + num4;
			num5 = _0023_003DzjbqS1qE_003D[i + 2];
			num6 = _0023_003DzjbqS1qE_003D[i + 3];
			_0023_003DzjbqS1qE_003D[i + 2] = _0023_003DzjbqS1qE_003D[num8];
			_0023_003DzjbqS1qE_003D[i + 3] = _0023_003DzjbqS1qE_003D[num8 + 1];
			_0023_003DzjbqS1qE_003D[num8] = num5;
			_0023_003DzjbqS1qE_003D[num8 + 1] = num6;
			int num9 = num;
			while (num4 >= num9)
			{
				num4 -= num9;
				num9 >>= 1;
			}
			num4 += num9;
		}
	}

	protected Vector3D[] ComputeHodograph(int deg, Point4D[] pw)
	{
		int num = pw.Length;
		Vector3D[] array = new Vector3D[num - 1];
		for (int i = 1; i < num; i++)
		{
			Point4D point4D = pw[i - 1];
			Point4D point4D2 = pw[i];
			Vector3D vector3D = new Vector3D(point4D.X / point4D.W, point4D.Y / point4D.W, point4D.Z / point4D.W);
			Vector3D vector3D2 = new Vector3D(point4D2.X / point4D2.W, point4D2.Y / point4D2.W, point4D2.Z / point4D2.W);
			array[i - 1] = _0023_003DzB68dg9Q_003D * (vector3D2 - vector3D);
			array[i - 1].Normalize();
		}
		return array;
	}

	protected static BoundingCone ComputeConeFromVectors(IList<Vector3D> D)
	{
		if (D.Count == 0)
		{
			return null;
		}
		Vector3D vector3D = (Vector3D)D[0].Clone();
		double num = 0.0;
		for (int i = 1; i < D.Count; i++)
		{
			double num2 = Math.Acos(Math.Max(Math.Min(Vector3D.Dot(D[i], vector3D), 1.0), -1.0));
			if (num2 > num && Math.Abs(num2 - num) > 1E-12)
			{
				Vector3D vector3D2;
				if (num == 0.0)
				{
					vector3D2 = (Vector3D)vector3D.Clone();
				}
				else
				{
					vector3D2 = (Math.Sin(num2) / Math.Tan(num) + Math.Cos(num2)) * vector3D - D[i];
					vector3D2.Normalize();
				}
				vector3D = D[i] + vector3D2;
				vector3D.Normalize();
				num = Math.Acos(Math.Max(Math.Min(Vector3D.Dot(vector3D, D[i]), 1.0), -1.0));
			}
		}
		return new BoundingCone
		{
			Axis = vector3D,
			HalfAngle = num
		};
	}

	internal static bool _0023_003DzcpymVWGKJIjE(double[,] _0023_003DzE8QrneA_003D, ref double[] _0023_003DzH9VU2k0_003D)
	{
		int[] array = new int[_0023_003DzH9VU2k0_003D.Length];
		if (!_0023_003DzyAXRKFBL3nUG(_0023_003DzE8QrneA_003D, array, out var _))
		{
			return false;
		}
		lubksb(_0023_003DzE8QrneA_003D, array, ref _0023_003DzH9VU2k0_003D);
		return true;
	}

	internal static bool _0023_003DzcpymVWGKJIjE(double[,] _0023_003DzE8QrneA_003D, ref double[,] _0023_003DzH9VU2k0_003D)
	{
		int[] _0023_003Dz2UNjEsx3Hq9s = new int[_0023_003DzH9VU2k0_003D.GetLength(0)];
		if (!_0023_003DzyAXRKFBL3nUG(_0023_003DzE8QrneA_003D, _0023_003Dz2UNjEsx3Hq9s, out var _))
		{
			return false;
		}
		_0023_003Dz4nDdiBU9vTSw(_0023_003DzE8QrneA_003D, _0023_003Dz2UNjEsx3Hq9s, ref _0023_003DzH9VU2k0_003D);
		return true;
	}

	internal static bool _0023_003DzhrvLkG8qVgMc7JLCgw_003D_003D(double[,] _0023_003DzE8QrneA_003D, ref double[,] _0023_003DzH9VU2k0_003D, int _0023_003DzBlNmjoc_003D, int _0023_003Dz948_aeQ_003D)
	{
		int length = _0023_003DzH9VU2k0_003D.GetLength(0);
		int[] indx = new int[length];
		double[,] al = new double[length, _0023_003DzBlNmjoc_003D];
		bandec(_0023_003DzE8QrneA_003D, _0023_003DzBlNmjoc_003D, _0023_003Dz948_aeQ_003D, al, indx, out var _);
		banbks(_0023_003DzE8QrneA_003D, _0023_003DzBlNmjoc_003D, _0023_003Dz948_aeQ_003D, al, indx, ref _0023_003DzH9VU2k0_003D);
		return true;
	}

	private static bool _0023_003DzyAXRKFBL3nUG(double[,] _0023_003DzjbqS1qE_003D, int[] _0023_003Dz2UNjEsx3Hq9s, out int _0023_003DzXrexKjY_003D)
	{
		int num = 0;
		int length = _0023_003DzjbqS1qE_003D.GetLength(0);
		double[] array = new double[length];
		_0023_003DzXrexKjY_003D = 1;
		for (int i = 0; i < length; i++)
		{
			double num2 = 0.0;
			for (int j = 0; j < length; j++)
			{
				double num3;
				if ((num3 = Math.Abs(_0023_003DzjbqS1qE_003D[i, j])) > num2)
				{
					num2 = num3;
				}
			}
			if (num2 == 0.0)
			{
				return false;
			}
			array[i] = 1.0 / num2;
		}
		for (int j = 0; j < length; j++)
		{
			for (int i = 0; i < j; i++)
			{
				double num4 = _0023_003DzjbqS1qE_003D[i, j];
				for (int k = 0; k < i; k++)
				{
					num4 -= _0023_003DzjbqS1qE_003D[i, k] * _0023_003DzjbqS1qE_003D[k, j];
				}
				_0023_003DzjbqS1qE_003D[i, j] = num4;
			}
			double num2 = 0.0;
			for (int i = j; i < length; i++)
			{
				double num4 = _0023_003DzjbqS1qE_003D[i, j];
				for (int k = 0; k < j; k++)
				{
					num4 -= _0023_003DzjbqS1qE_003D[i, k] * _0023_003DzjbqS1qE_003D[k, j];
				}
				_0023_003DzjbqS1qE_003D[i, j] = num4;
				double num5;
				if ((num5 = array[i] * Math.Abs(num4)) >= num2)
				{
					num2 = num5;
					num = i;
				}
			}
			if (j != num)
			{
				for (int k = 0; k < length; k++)
				{
					double num5 = _0023_003DzjbqS1qE_003D[num, k];
					_0023_003DzjbqS1qE_003D[num, k] = _0023_003DzjbqS1qE_003D[j, k];
					_0023_003DzjbqS1qE_003D[j, k] = num5;
				}
				_0023_003DzXrexKjY_003D = -_0023_003DzXrexKjY_003D;
				array[num] = array[j];
			}
			_0023_003Dz2UNjEsx3Hq9s[j] = num;
			if (_0023_003DzjbqS1qE_003D[j, j] == 0.0)
			{
				_0023_003DzjbqS1qE_003D[j, j] = 2.220446049250313E-16;
			}
			if (j != length - 1)
			{
				double num5 = 1.0 / _0023_003DzjbqS1qE_003D[j, j];
				for (int i = j + 1; i < length; i++)
				{
					_0023_003DzjbqS1qE_003D[i, j] *= num5;
				}
			}
		}
		return true;
	}

	public static void bandec(double[,] a, int m1, int m2, double[,] al, int[] indx, out double d)
	{
		int length = a.GetLength(0);
		int num = m1 + m2 + 1;
		int num2 = m1;
		for (int i = 0; i < m1; i++)
		{
			for (int j = m1 - i; j < num; j++)
			{
				a[i, j - num2] = a[i, j];
			}
			num2--;
			for (int j = num - num2 - 1; j < num; j++)
			{
				a[i, j] = 0.0;
			}
		}
		d = 1.0;
		num2 = m1;
		for (int k = 0; k < length; k++)
		{
			double num3 = a[k, 0];
			int i = k;
			if (num2 < length)
			{
				num2++;
			}
			for (int j = k + 1; j < num2; j++)
			{
				if (Math.Abs(a[j, 0]) > Math.Abs(num3))
				{
					num3 = a[j, 0];
					i = j;
				}
			}
			indx[k] = i + 1;
			if (num3 == 0.0)
			{
				a[k, 0] = 1E-40;
			}
			if (i != k)
			{
				d = 0.0 - d;
				for (int j = 0; j < num; j++)
				{
					Utility.Swap(ref a[k, j], ref a[i, j]);
				}
			}
			for (i = k + 1; i < num2; i++)
			{
				num3 = (al[k, i - k - 1] = a[i, 0] / a[k, 0]);
				for (int j = 1; j < num; j++)
				{
					a[i, j - 1] = a[i, j] - num3 * a[k, j];
				}
				a[i, num - 1] = 0.0;
			}
		}
	}

	public static void banbks(double[,] a, int m1, int m2, double[,] al, int[] indx, ref double[] b)
	{
		int length = a.GetLength(0);
		int num = m1 + m2 + 1;
		int num2 = m1;
		for (int i = 0; i < length; i++)
		{
			int num3 = indx[i] - 1;
			if (num3 != i)
			{
				Utility.Swap(ref b[i], ref b[num3]);
			}
			if (num2 < length)
			{
				num2++;
			}
			for (num3 = i + 1; num3 < num2; num3++)
			{
				b[num3] -= al[i, num3 - i - 1] * b[i];
			}
		}
		num2 = 1;
		for (int num4 = length - 1; num4 >= 0; num4--)
		{
			double num5 = b[num4];
			for (int i = 1; i < num2; i++)
			{
				num5 -= a[num4, i] * b[i + num4];
			}
			b[num4] = num5 / a[num4, 0];
			if (num2 < num)
			{
				num2++;
			}
		}
	}

	[CLSCompliant(false)]
	public static void banbks(double[,] a, int m1, int m2, double[,] al, int[] indx, ref double[,] b)
	{
		int length = a.GetLength(0);
		int num = m1 + m2 + 1;
		for (int i = 0; i < b.GetLength(1); i++)
		{
			int num2 = m1;
			for (int j = 0; j < length; j++)
			{
				int num3 = indx[j] - 1;
				if (num3 != j)
				{
					Utility.Swap(ref b[j, i], ref b[num3, i]);
				}
				if (num2 < length)
				{
					num2++;
				}
				for (num3 = j + 1; num3 < num2; num3++)
				{
					b[num3, i] -= al[j, num3 - j - 1] * b[j, i];
				}
			}
			num2 = 1;
			for (int num4 = length - 1; num4 >= 0; num4--)
			{
				double num5 = b[num4, i];
				for (int j = 1; j < num2; j++)
				{
					num5 -= a[num4, j] * b[j + num4, i];
				}
				b[num4, i] = num5 / a[num4, 0];
				if (num2 < num)
				{
					num2++;
				}
			}
		}
	}

	public static void lubksb(double[,] a, int[] indx, ref double[] b)
	{
		int length = a.GetLength(0);
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			int num2 = indx[i];
			double num3 = b[num2];
			b[num2] = b[i];
			if (num != 0)
			{
				for (int j = num - 1; j < i; j++)
				{
					num3 -= a[i, j] * b[j];
				}
			}
			else if (num3 != 0.0)
			{
				num = i + 1;
			}
			b[i] = num3;
		}
		for (int i = length - 1; i >= 0; i--)
		{
			double num3 = b[i];
			for (int j = i + 1; j < length; j++)
			{
				num3 -= a[i, j] * b[j];
			}
			b[i] = num3 / a[i, i];
		}
	}

	private static void _0023_003Dz4nDdiBU9vTSw(double[,] _0023_003DzjbqS1qE_003D, int[] _0023_003Dz2UNjEsx3Hq9s, ref double[,] _0023_003Dz1v6oPQk_003D)
	{
		int length = _0023_003DzjbqS1qE_003D.GetLength(0);
		for (int i = 0; i < _0023_003Dz1v6oPQk_003D.GetLength(1); i++)
		{
			int num = 0;
			for (int j = 0; j < length; j++)
			{
				int num2 = _0023_003Dz2UNjEsx3Hq9s[j];
				double num3 = _0023_003Dz1v6oPQk_003D[num2, i];
				_0023_003Dz1v6oPQk_003D[num2, i] = _0023_003Dz1v6oPQk_003D[j, i];
				if (num != 0)
				{
					for (int k = num - 1; k < j; k++)
					{
						num3 -= _0023_003DzjbqS1qE_003D[j, k] * _0023_003Dz1v6oPQk_003D[k, i];
					}
				}
				else if (num3 != 0.0)
				{
					num = j + 1;
				}
				_0023_003Dz1v6oPQk_003D[j, i] = num3;
			}
			for (int j = length - 1; j >= 0; j--)
			{
				double num3 = _0023_003Dz1v6oPQk_003D[j, i];
				for (int k = j + 1; k < length; k++)
				{
					num3 -= _0023_003DzjbqS1qE_003D[j, k] * _0023_003Dz1v6oPQk_003D[k, i];
				}
				_0023_003Dz1v6oPQk_003D[j, i] = num3 / _0023_003DzjbqS1qE_003D[j, j];
			}
		}
	}

	internal static double[] _0023_003DzphmdrE9a2afe(double[,] _0023_003DzE8QrneA_003D, double[] _0023_003DzH9VU2k0_003D)
	{
		Utility._0023_003DzQblHGY4s1vkJ(_0023_003DzE8QrneA_003D, out var _0023_003DzAvn2b38_003D, out var _0023_003Dz77g161c_003D);
		double num = 0.0;
		int length = _0023_003DzE8QrneA_003D.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			if (_0023_003DzAvn2b38_003D[i] > num)
			{
				num = _0023_003DzAvn2b38_003D[i];
			}
		}
		double num2 = num * 1E-06;
		for (int j = 0; j < length; j++)
		{
			if (_0023_003DzAvn2b38_003D[j] < num2)
			{
				_0023_003DzAvn2b38_003D[j] = 0.0;
			}
		}
		_0023_003DzHDMw_Nq6S4WP(_0023_003DzE8QrneA_003D, _0023_003DzAvn2b38_003D, _0023_003Dz77g161c_003D, _0023_003DzH9VU2k0_003D, out var _0023_003DzBJFJHwk_003D);
		return _0023_003DzBJFJHwk_003D;
	}

	internal static double[,] _0023_003DzphmdrE9a2afe(double[,] _0023_003DzE8QrneA_003D, double[,] _0023_003DzH9VU2k0_003D)
	{
		Utility._0023_003DzQblHGY4s1vkJ(_0023_003DzE8QrneA_003D, out var _0023_003DzAvn2b38_003D, out var _0023_003Dz77g161c_003D);
		double num = 0.0;
		int length = _0023_003DzE8QrneA_003D.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			if (_0023_003DzAvn2b38_003D[i] > num)
			{
				num = _0023_003DzAvn2b38_003D[i];
			}
		}
		double num2 = num * 1E-06;
		for (int j = 0; j < length; j++)
		{
			if (_0023_003DzAvn2b38_003D[j] < num2)
			{
				_0023_003DzAvn2b38_003D[j] = 0.0;
			}
		}
		_0023_003DzHDMw_Nq6S4WP(_0023_003DzE8QrneA_003D, _0023_003DzAvn2b38_003D, _0023_003Dz77g161c_003D, _0023_003DzH9VU2k0_003D, out var _0023_003DzBJFJHwk_003D);
		return _0023_003DzBJFJHwk_003D;
	}

	private static void _0023_003DzHDMw_Nq6S4WP(double[,] _0023_003Dz_eY3Y4c_003D, double[] _0023_003DzAvn2b38_003D, double[,] _0023_003Dz77g161c_003D, double[] _0023_003Dz1v6oPQk_003D, out double[] _0023_003DzBJFJHwk_003D)
	{
		int length = _0023_003Dz_eY3Y4c_003D.GetLength(0);
		int length2 = _0023_003Dz_eY3Y4c_003D.GetLength(1);
		double[] array = new double[length2];
		for (int i = 0; i < length2; i++)
		{
			double num = 0.0;
			if (_0023_003DzAvn2b38_003D[i] != 0.0)
			{
				for (int j = 0; j < length; j++)
				{
					num += _0023_003Dz_eY3Y4c_003D[j, i] * _0023_003Dz1v6oPQk_003D[j];
				}
				num /= _0023_003DzAvn2b38_003D[i];
			}
			array[i] = num;
		}
		_0023_003DzBJFJHwk_003D = new double[length2];
		for (int i = 0; i < length2; i++)
		{
			double num = 0.0;
			for (int k = 0; k < length2; k++)
			{
				num += _0023_003Dz77g161c_003D[i, k] * array[k];
			}
			_0023_003DzBJFJHwk_003D[i] = num;
		}
	}

	private static void _0023_003DzHDMw_Nq6S4WP(double[,] _0023_003Dz_eY3Y4c_003D, double[] _0023_003DzAvn2b38_003D, double[,] _0023_003Dz77g161c_003D, double[,] _0023_003Dz1v6oPQk_003D, out double[,] _0023_003DzBJFJHwk_003D)
	{
		int length = _0023_003Dz_eY3Y4c_003D.GetLength(0);
		int length2 = _0023_003Dz_eY3Y4c_003D.GetLength(1);
		double[] array = new double[length2];
		_0023_003DzBJFJHwk_003D = new double[length2, _0023_003Dz1v6oPQk_003D.GetLength(1)];
		for (int i = 0; i < _0023_003Dz1v6oPQk_003D.GetLength(1); i++)
		{
			for (int j = 0; j < length2; j++)
			{
				double num = 0.0;
				if (_0023_003DzAvn2b38_003D[j] != 0.0)
				{
					for (int k = 0; k < length; k++)
					{
						num += _0023_003Dz_eY3Y4c_003D[k, j] * _0023_003Dz1v6oPQk_003D[k, i];
					}
					num /= _0023_003DzAvn2b38_003D[j];
				}
				array[j] = num;
			}
			for (int j = 0; j < length2; j++)
			{
				double num = 0.0;
				for (int l = 0; l < length2; l++)
				{
					num += _0023_003Dz77g161c_003D[j, l] * array[l];
				}
				_0023_003DzBJFJHwk_003D[j, i] = num;
			}
		}
	}

	public static bool Cholesky(double[,] A, int size, out double[,] L)
	{
		L = new double[size, size];
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < i + 1; j++)
			{
				double num = 0.0;
				for (int k = 0; k < j; k++)
				{
					num += L[i, k] * L[j, k];
				}
				if (i == j)
				{
					double num2 = A[i, i] - num;
					if (num2 < 0.0)
					{
						return false;
					}
					L[i, j] = Math.Sqrt(num2);
				}
				else
				{
					L[i, j] = 1.0 / L[j, j] * (A[i, j] - num);
				}
			}
		}
		return true;
	}

	public static void Cholesky(double[,] A, int size, out double[,] L, out double[] D)
	{
		L = new double[size, size];
		D = new double[size];
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j <= i; j++)
			{
				L[i, j] = A[i, j];
			}
		}
		for (int k = 0; k < size - 1; k++)
		{
			for (int l = k + 1; l < size; l++)
			{
				D[l] = L[l, k];
				L[l, k] = D[l] / L[k, k];
				for (int m = k + 1; m <= l; m++)
				{
					L[l, m] -= L[l, k] * D[m];
				}
			}
		}
		for (int n = 0; n < size; n++)
		{
			D[n] = L[n, n];
			L[n, n] = 1.0;
		}
	}

	internal void _0023_003DzzpUV1ZQ_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (!_0023_003DzELu0Pss_003D.PlanarReflections && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetLighting(enable: false);
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(1f);
			if (_0023_003DzELu0Pss_003D.Viewport.Background.StyleMode == backgroundStyleType.None)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(Color.Black);
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.Viewport.Background.GetContrastColor());
			}
			_0023_003Dzp7j_tCs_FYVt(_0023_003DzELu0Pss_003D.RenderContext);
			_0023_003DzELu0Pss_003D.RenderContext.SetLineStipple(2, 43690, _0023_003DzELu0Pss_003D.Viewport.Camera);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: true);
			_0023_003DzfbUXMcWg3bvT(_0023_003DzELu0Pss_003D.RenderContext);
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: false);
		}
	}

	internal virtual void _0023_003DzfbUXMcWg3bvT(RenderContextBase _0023_003DzQdnFby4_003D)
	{
	}

	internal virtual void _0023_003Dzp7j_tCs_FYVt(RenderContextBase _0023_003DzQdnFby4_003D)
	{
	}

	protected internal override void DrawForDepthPass(DrawParams data)
	{
		bool showControl = ShowControl;
		ShowControl = false;
		base.DrawForDepthPass(data);
		ShowControl = showControl;
	}
}
