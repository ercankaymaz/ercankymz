using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<ICurve, int> _0023_003DzzXfVjLO8QehtBZRX_0024A_003D_003D;

		public static Func<ICurve, bool> _0023_003DziswhuOY90sa2r1Ll9w_003D_003D;

		public static Func<ICurve, int> _0023_003DzUavHczId_wBEOkDHkA_003D_003D;

		public static Func<ICurve, bool> _0023_003Dz1zkl5k8yTV0cnuaQhw_003D_003D;

		public static Func<ICurve, int> _0023_003Dz0QfxDf7hS1A7nIXVMg_003D_003D;

		public static Func<_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D, ICurve> _0023_003DzvMGAOFpt9_1KaAXVXA_003D_003D;

		public static Func<ICurve, bool> _0023_003DznWEWS9wtjCqBSh9J_0024A_003D_003D;

		public static Func<ICurve, Point3D[]> _0023_003DzPyNQj_vJJ1RRcV9bxA_003D_003D;

		internal int _0023_003DzkoWNuObRoesSKY9ZLQ_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData;
		}

		internal bool _0023_003Dz6ytcM163qn_0024GNvPQaQ_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData < 0;
		}

		internal int _0023_003DzOLLPjY389j047gjXfA_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData;
		}

		internal bool _0023_003DzMVy_0024YiiBp8wjzxIT9w_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData < 0;
		}

		internal int _0023_003Dzjz3ZOaSVjndrNscU2g_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData;
		}

		internal ICurve _0023_003Dzh24fMyzcbJpodHxGIg_003D_003D(_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D._0023_003Dz06A5WivSSyUp;
		}

		internal bool _0023_003DzhEwdD_YLRBaqUNgCLw_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return Math.Abs((int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData) == 1;
		}

		internal Point3D[] _0023_003DzNaGV_ju7_0024_XlSccGxw_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return ((LinearPath)_0023_003Dzt_m8zV0_003D).Vertices;
		}
	}

	private struct _0023_003DzD_uRSS4_003D : IComparable<_0023_003DzD_uRSS4_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D[] _0023_003DzrdSL0CI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzJ4aapyU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzoQcRoMY_003D;

		public int CompareTo(_0023_003DzD_uRSS4_003D _0023_003Dzl_0024MIsC0_003D)
		{
			return _0023_003DzJ4aapyU_003D.CompareTo(_0023_003Dzl_0024MIsC0_003D._0023_003DzJ4aapyU_003D);
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927148), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996331), _0023_003DzrdSL0CI_003D.Length, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996314), _0023_003DzJ4aapyU_003D);
		}
	}

	public static _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzL9woobs_003D(Region _0023_003DzaY4XE9_0024078mD, Point3D[][] _0023_003DzBLGbisU_003D, EndMill _0023_003DzzhSDYPa50tjn, double _0023_003Dz8uslNzRAwfBK, double _0023_003DzfBEBL_o_003D, double _0023_003Dz9NrCn_o_003D, bool _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D, bool _0023_003DzEXLcE10_003D, string _0023_003Dz751t_uo_003D, WorkUnit _0023_003Dz_IUshyU_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003DzaY4XE9_0024078mD.Plane.AxisZ.Z < 0.0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996296));
		}
		ICurve[] array = _0023_003DzBAnOUlxTpkoF(_0023_003DzaY4XE9_0024078mD, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D ? _0023_003Dz8uslNzRAwfBK : (_0023_003DzfBEBL_o_003D + _0023_003DzzhSDYPa50tjn.Diameter / 2.0), _0023_003Dz8uslNzRAwfBK, _0023_003Dz751t_uo_003D, _0023_003Dz_IUshyU_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		if (array.Length == 0)
		{
			return new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[0];
		}
		if (_0023_003DzEXLcE10_003D)
		{
			ICurve[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Reverse();
			}
		}
		List<ICurve> list = new List<ICurve>(array);
		for (int j = 0; j < list.Count; j++)
		{
			LinearPath _0023_003DzN5thJ4k_003D = (LinearPath)list[j];
			_0023_003Dz2h5PhLA_003D(_0023_003Dz9NrCn_o_003D, _0023_003DzN5thJ4k_003D);
		}
		List<ICurve> source = list.OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzkoWNuObRoesSKY9ZLQ_003D_003D).ToList();
		List<ICurve> list2 = source.TakeWhile((ICurve _0023_003Dzt_m8zV0_003D) => (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData < 0).OrderByDescending(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzOLLPjY389j047gjXfA_003D_003D).ToList();
		List<ICurve> list3 = source.SkipWhile((ICurve _0023_003Dzt_m8zV0_003D) => (int)((Entity)_0023_003Dzt_m8zV0_003D).EntityData < 0).OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzjz3ZOaSVjndrNscU2g_003D_003D).ToList();
		int count = list3.Count;
		int count2 = list2.Count;
		_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D[] array3 = new _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D[count + count2];
		for (int num = 0; num < count; num++)
		{
			ICurve curve = list3[num];
			array3[num] = new _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D
			{
				_0023_003DzzwkLTZY_003D = new List<int>(),
				_0023_003Dz06A5WivSSyUp = (LinearPath)curve
			};
			for (int num2 = 0; num2 < count; num2++)
			{
				if (num2 != num && Utility.PointInPolygon(curve.StartPoint, ((LinearPath)list3[num2]).Vertices))
				{
					array3[num]._0023_003DzzwkLTZY_003D.Add(num2);
				}
			}
			array3[num]._0023_003DzzwkLTZY_003D.Reverse();
		}
		for (int num3 = 0; num3 < count2; num3++)
		{
			ICurve curve2 = list2[num3];
			array3[num3 + count] = new _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D
			{
				_0023_003DzzwkLTZY_003D = new List<int>(),
				_0023_003Dz06A5WivSSyUp = (LinearPath)curve2
			};
			for (int num4 = 0; num4 < count2; num4++)
			{
				if (num4 != num3 && Utility.PointInPolygon(list2[num4].StartPoint, ((LinearPath)curve2)._vertices))
				{
					array3[num3 + count]._0023_003DzzwkLTZY_003D.Add(num4 + count);
				}
			}
			array3[num3 + count]._0023_003DzzwkLTZY_003D.Reverse();
		}
		List<Point3D> list4 = new List<Point3D>();
		List<_0023_003DzD_uRSS4_003D> list5 = new List<_0023_003DzD_uRSS4_003D>();
		for (int num5 = array3.Length - 1; num5 >= 0; num5--)
		{
			_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2 = array3[num5];
			if (!_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz4sg0Qp0_003D)
			{
				_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz4sg0Qp0_003D = true;
				list4.AddRange(_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz06A5WivSSyUp.Vertices);
				int num6 = 0;
				int _0023_003Dz_0024FbTgkbgKvtp = num5;
				while (_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003DzzwkLTZY_003D.Count > 0)
				{
					int num7 = _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003DzzwkLTZY_003D[0];
					if (array3[num7]._0023_003Dz4sg0Qp0_003D || !_0023_003DzwQjZLdy6K15Z(list4, array3[num7]._0023_003Dz06A5WivSSyUp, array3.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzh24fMyzcbJpodHxGIg_003D_003D).ToList(), _0023_003Dz_0024FbTgkbgKvtp, num7))
					{
						break;
					}
					array3[num7]._0023_003Dz4sg0Qp0_003D = true;
					_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2 = array3[num7];
					_0023_003Dz_0024FbTgkbgKvtp = num7;
					num6++;
				}
				list5.Add(new _0023_003DzD_uRSS4_003D
				{
					_0023_003DzrdSL0CI_003D = list4.ToArray(),
					_0023_003DzJ4aapyU_003D = num6,
					_0023_003DzoQcRoMY_003D = true
				});
				list4.Clear();
			}
		}
		list5.Sort();
		list5.Reverse();
		if (_0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D)
		{
			LinearPath linearPath = _0023_003DzaY4XE9_0024078mD.ContourList[0].Clone() as LinearPath;
			if (_0023_003DzEXLcE10_003D)
			{
				linearPath.Reverse();
			}
			_0023_003Dz2h5PhLA_003D(_0023_003Dz9NrCn_o_003D, linearPath);
			list5.Add(new _0023_003DzD_uRSS4_003D
			{
				_0023_003DzrdSL0CI_003D = linearPath.Vertices,
				_0023_003DzoQcRoMY_003D = false
			});
			for (int num8 = 1; num8 < _0023_003DzaY4XE9_0024078mD.ContourList.Count; num8++)
			{
				LinearPath linearPath2 = _0023_003DzaY4XE9_0024078mD.ContourList[num8].Clone() as LinearPath;
				if (_0023_003DzEXLcE10_003D)
				{
					linearPath2.Reverse();
				}
				_0023_003Dz2h5PhLA_003D(_0023_003Dz9NrCn_o_003D, linearPath2);
				list5.Add(new _0023_003DzD_uRSS4_003D
				{
					_0023_003DzrdSL0CI_003D = linearPath2.Vertices,
					_0023_003DzoQcRoMY_003D = false
				});
			}
		}
		else
		{
			_0023_003DzBLGbisU_003D = (from _0023_003Dzt_m8zV0_003D in array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzhEwdD_YLRBaqUNgCLw_003D_003D)
				select ((LinearPath)_0023_003Dzt_m8zV0_003D).Vertices).ToArray();
		}
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array4 = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[list5.Count];
		for (int num9 = 0; num9 < list5.Count; num9++)
		{
			_0023_003DzD_uRSS4_003D _0023_003DzD_uRSS4_003D2 = list5[num9];
			array4[num9] = new _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7(_0023_003DzD_uRSS4_003D2._0023_003DzrdSL0CI_003D, _0023_003DzBLGbisU_003D, _0023_003DzD_uRSS4_003D2._0023_003DzoQcRoMY_003D);
		}
		return array4;
	}

	private static int _0023_003Dzg3fAKzQ_003D(int _0023_003Dz437_00244ak_003D, int _0023_003Dz736ekIs_003D)
	{
		if (_0023_003Dz437_00244ak_003D >= _0023_003Dz736ekIs_003D - 1)
		{
			return 0;
		}
		return _0023_003Dz437_00244ak_003D + 1;
	}

	public static ICurve[] _0023_003DzBAnOUlxTpkoF(Region _0023_003DzFDwqpgU_003D, double _0023_003DzeG_00246Qcgl8daH, double _0023_003DzIrPGUnY_003D, string _0023_003Dz751t_uo_003D, WorkUnit _0023_003Dz_IUshyU_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		double num = 0.0;
		Point3D centroid;
		if (_0023_003Dz_IUshyU_003D != null)
		{
			_0023_003DzFDwqpgU_003D.Regen(0.0);
			num = _0023_003DzFDwqpgU_003D.GetArea(out centroid);
		}
		List<ICurve> list = new List<ICurve>();
		int num2 = 0;
		while (true)
		{
			double num3 = _0023_003DzeG_00246Qcgl8daH + _0023_003DzIrPGUnY_003D * (double)num2;
			ICurve[] array3;
			try
			{
				IntegerGrid _0023_003DzOSo8vaE_003D;
				ICurve[] array = _0023_003DzFDwqpgU_003D._0023_003DzeMYhs5Z_0024EcJ2(0.0 - num3, _0023_003DzIrPGUnY_003D / 100.0, out _0023_003DzOSo8vaE_003D);
				ICurve[] array2 = new ICurve[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = (LinearPath)array[i];
				}
				array3 = array2;
			}
			catch (Exception)
			{
				_0023_003Dz_IUshyU_003D.AppendToLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996242) + _0023_003DzFDwqpgU_003D.Plane.Origin.Z);
				return new ICurve[0];
			}
			if (array3.Length == 0)
			{
				break;
			}
			ICurve[] array4 = array3;
			foreach (ICurve curve in array4)
			{
				if (Utility.IsOrientedClockwise(((LinearPath)curve)._vertices))
				{
					((Entity)curve).EntityData = -(num2 + 1);
				}
				else
				{
					((Entity)curve).EntityData = num2 + 1;
				}
				list.Add(curve);
			}
			num2++;
			if (_0023_003Dz_IUshyU_003D != null)
			{
				Region[] array5 = Utility.DetectRegionsFromContours(array3, Plane.XY);
				double num4 = 0.0;
				Region[] array6 = array5;
				foreach (Region region in array6)
				{
					region.Regen(0.0);
					num4 += region.GetArea(out centroid);
				}
				int num5 = (int)(100.0 * (num - num4) / num);
				if (num5 > 100)
				{
					num5 = 100;
				}
				if (!_0023_003Dz_IUshyU_003D.UpdateProgressAndCheckCancelled(num5, 100.0, _0023_003Dz751t_uo_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return new ICurve[0];
				}
			}
		}
		return list.ToArray();
	}

	private static bool _0023_003DzwQjZLdy6K15Z(List<Point3D> _0023_003DzrAOtYIs_003D, LinearPath _0023_003DzOHpyMcKw0SXo, IList<ICurve> _0023_003DzosMf4QgVa5ec, int _0023_003Dz_0024FbTgkbgKvtp, int _0023_003Dz23jZ7fXIiMOX)
	{
		Point3D point3D = _0023_003DzrAOtYIs_003D.Last();
		Point3D[] vertices = _0023_003DzOHpyMcKw0SXo._vertices;
		double num = double.MaxValue;
		int num2 = -1;
		double t = 0.0;
		for (int i = 0; i < vertices.Length; i++)
		{
			Segment2D segment2D = new Segment2D(vertices[i], vertices[_0023_003Dzg3fAKzQ_003D(i, vertices.Length)]);
			double num3 = segment2D.ClosestPointTo(point3D);
			double num4 = Point2D.DistanceSquared(segment2D.PointAt(num3), point3D);
			if (num4 < num)
			{
				num = num4;
				num2 = i;
				t = num3;
			}
		}
		int num5 = -1;
		List<Point3D> list = new List<Point3D>(vertices.Length + 1);
		for (int j = 0; j < num2 + 1; j++)
		{
			list.Add(vertices[j]);
		}
		Point2D point2D = new Segment2D(vertices[num2], vertices[num2 + 1]).PointAt(t);
		if (Point2D.Distance(point2D, vertices[num2]) < Utility._0023_003DzxhnLabVjXjPg)
		{
			num5 = num2;
		}
		else if (Point2D.Distance(point2D, vertices[_0023_003Dzg3fAKzQ_003D(num2, vertices.Length)]) < Utility._0023_003DzxhnLabVjXjPg)
		{
			num5 = num2 + 1;
		}
		else
		{
			list.Add(new Point3D(point2D.X, point2D.Y, point3D.Z));
			num5 = num2 + 1;
		}
		for (int k = num2 + 1; k < vertices.Length; k++)
		{
			list.Add(vertices[k]);
		}
		Segment2D _0023_003Dzc4WZDmM_003D = new Segment2D(point3D, list[num5]);
		List<ICurve> list2 = new List<ICurve>();
		LinearPath linearPath = new LinearPath();
		for (int l = 0; l < _0023_003DzosMf4QgVa5ec.Count; l++)
		{
			if (l != _0023_003Dz23jZ7fXIiMOX)
			{
				if (l == _0023_003Dz_0024FbTgkbgKvtp)
				{
					List<Point3D> list3 = ((LinearPath)_0023_003DzosMf4QgVa5ec[l])._vertices.ToList();
					linearPath = new LinearPath(list3.GetRange(1, list3.Count - 2));
					list2.Add(linearPath);
				}
				else
				{
					list2.Add(_0023_003DzosMf4QgVa5ec[l]);
				}
			}
		}
		if (_0023_003Dz_DJzmpf8ak0C(_0023_003Dzc4WZDmM_003D, list2))
		{
			return false;
		}
		list.RemoveAt(list.Count - 1);
		Point3D[] array = list.ToArray();
		Utility.RotateLeft(array, num5);
		array = array.Append((Point3D)array.First().Clone()).ToArray();
		_0023_003DzrAOtYIs_003D.AddRange(array);
		_0023_003DzrAOtYIs_003D.Add((Point3D)array[0].Clone());
		return true;
	}

	private static bool _0023_003Dz_DJzmpf8ak0C(Segment2D _0023_003Dzc4WZDmM_003D, IList<ICurve> _0023_003DzosMf4QgVa5ec)
	{
		foreach (LinearPath item in _0023_003DzosMf4QgVa5ec)
		{
			if (new Polygon2D(item.Vertices).IntersectWith(_0023_003Dzc4WZDmM_003D))
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003Dz2h5PhLA_003D(double _0023_003Dz9NrCn_o_003D, LinearPath _0023_003DzN5thJ4k_003D)
	{
		Point3D[] vertices = _0023_003DzN5thJ4k_003D.Vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i].Z = _0023_003Dz9NrCn_o_003D;
		}
	}
}
