using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzEHrosn01le6VGB6o1hxgJL17jjLqVuSXsBL1dho_003D
{
	public static _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzL9woobs_003D(Tuple<double, Point2D[][]> _0023_003DzfNi7d4A_003D, EndMill _0023_003DzCE8nZ10WIX_0024z, Region _0023_003DzE6hmI4gIDAYUn4D92A_003D_003D, PolyRegion2D _0023_003Dz_Bn_pNI_003D, Point2D _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, Point2D _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D, double _0023_003Dz8uslNzRAwfBK, double _0023_003DzfBEBL_o_003D, double _0023_003Dz9NrCn_o_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzEXLcE10_003D, string _0023_003Dz751t_uo_003D, WorkUnit _0023_003Dz_IUshyU_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Region[] _0023_003DzWaFlkhfmYCja;
		if (_0023_003Dz_Bn_pNI_003D == null)
		{
			list.AddRange(_0023_003DzGXWQSv7Yxgb3eaY4Ig_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D, _0023_003Dz8uslNzRAwfBK, _0023_003Dz8uslNzRAwfBK, _0023_003Dz9NrCn_o_003D, _0023_003DzE6hmI4gIDAYUn4D92A_003D_003D, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: true, _0023_003DzEXLcE10_003D, out _0023_003DzWaFlkhfmYCja));
		}
		else
		{
			ICurve[] array = new ICurve[_0023_003DzfNi7d4A_003D.Item2.Length];
			for (int i = 0; i < _0023_003DzfNi7d4A_003D.Item2.Length; i++)
			{
				array[i] = new LinearPath(Plane.XY, _0023_003DzfNi7d4A_003D.Item2[i]);
			}
			Region[] array2 = Utility.DetectRegionsFromContours(array, Plane.XY);
			PolyRegion2D[] array3 = new PolyRegion2D[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array3[j] = Machining.FromRegion(array2[j]);
			}
			PolyRegion2D[] array4 = Machining._0023_003DzorRMj6zXvNF8(_0023_003Dz_Bn_pNI_003D, array3).ToArray();
			_0023_003DzWaFlkhfmYCja = new Region[array4.Length];
			for (int k = 0; k < array4.Length; k++)
			{
				_0023_003DzWaFlkhfmYCja[k] = array4[k].ToRegion(Plane.XY);
			}
		}
		Region[] array5 = _0023_003DzWaFlkhfmYCja;
		foreach (Region region in array5)
		{
			list.AddRange(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(region, Machining._0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(region.ContourList, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D), _0023_003DzCE8nZ10WIX_0024z, _0023_003Dz8uslNzRAwfBK, _0023_003DzfBEBL_o_003D, _0023_003Dz9NrCn_o_003D, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: true, !_0023_003DzEXLcE10_003D, _0023_003Dz751t_uo_003D, _0023_003Dz_IUshyU_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D));
		}
		stopwatch.Stop();
		return list.ToArray();
	}

	public static _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzGXWQSv7Yxgb3eaY4Ig_003D_003D(Tuple<double, Point2D[][]> _0023_003DzfNi7d4A_003D, Point2D _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, Point2D _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D, double _0023_003DzeG_00246Qcgl8daH, double _0023_003DzIrPGUnY_003D, double _0023_003Dz9NrCn_o_003D, Region _0023_003DzE6hmI4gIDAYUn4D92A_003D_003D, bool _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D, bool _0023_003DzEXLcE10_003D, out Region[] _0023_003DzWaFlkhfmYCja)
	{
		IntegerGrid integerGrid = new IntegerGrid(524288, _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D);
		int num = _0023_003DzfNi7d4A_003D.Item2.Length;
		double num2 = integerGrid._0023_003DzSz9j2QgD23s_0024();
		_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D[] array = new _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D[num];
		for (int i = 0; i < num; i++)
		{
			ICurve curve = new LinearPath(Plane.XY, _0023_003DzfNi7d4A_003D.Item2[i]);
			array[i] = new _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D
			{
				_0023_003DzzwkLTZY_003D = new List<int>(),
				_0023_003Dz06A5WivSSyUp = (LinearPath)curve
			};
			for (int j = 0; j < num; j++)
			{
				if (j != i && Utility.PointInPolygon(curve.StartPoint, _0023_003DzfNi7d4A_003D.Item2[j]))
				{
					array[i]._0023_003DzzwkLTZY_003D.Add(j);
				}
			}
		}
		List<Point3D[][]> list = new List<Point3D[][]>();
		List<ICurve> list2 = new List<ICurve>(num);
		ClipperUtility clipperUtility = new ClipperUtility(_0023_003DzIrPGUnY_003D, num2 * _0023_003DzIrPGUnY_003D / 100.0);
		_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D[] array2 = array;
		for (int k = 0; k < array2.Length; k++)
		{
			_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2 = array2[k];
			if (_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003DzzwkLTZY_003D.Count == 0)
			{
				if (_0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D)
				{
					Point3D[] vertices = _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz06A5WivSSyUp.Vertices;
					if (_0023_003DzEXLcE10_003D)
					{
						Array.Reverse(vertices);
					}
					list.Add(new Point3D[1][] { vertices });
				}
				Point2D[] vertices2 = _0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz06A5WivSSyUp.Vertices;
				clipperUtility.AddContour(integerGrid, vertices2);
			}
			else
			{
				list2.Add(_0023_003DzffJpiSDBgZf8XoMYriAgy_0024Q_iNRLOTseO21CQwk_003D2._0023_003Dz06A5WivSSyUp);
			}
		}
		_0023_003DzWaFlkhfmYCja = Utility.DetectRegionsFromContours(list2, Plane.XY);
		int num3 = 0;
		int length;
		do
		{
			double num4 = _0023_003DzeG_00246Qcgl8daH + _0023_003DzIrPGUnY_003D * (double)num3;
			Point3D[][] array3 = clipperUtility.Execute(num4 * num2, integerGrid, _0023_003Dz9NrCn_o_003D, _0023_003DzEXLcE10_003D);
			length = array3.GetLength(0);
			list.Add(array3);
			num3++;
		}
		while (length > 1 || !_0023_003Dz9sDbTS5Fg0bo(list.Last()[0], _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D));
		list.Reverse();
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list3 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>();
		List<Point3D[]> list4 = new List<Point3D[]>();
		for (int l = 0; l < list.Count; l++)
		{
			Point3D[][] array4 = list[l];
			List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list5 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>(array4.Length);
			Point3D[][] array5 = array4;
			foreach (Point3D[] array6 in array5)
			{
				Point3D[][] array7 = _0023_003Dz9y6F_0024pWf69VkHAqP5Ep4FcSlwwoD._0023_003DzOYxPx6FqLIHX(array6, _0023_003DzE6hmI4gIDAYUn4D92A_003D_003D);
				Point3D[][] array8 = array7;
				foreach (Point3D[] array9 in array8)
				{
					Point3D[] array10 = array9;
					for (int n = 0; n < array10.Length; n++)
					{
						array10[n].Z = _0023_003Dz9NrCn_o_003D;
					}
					if (Machining._0023_003DzySfSteI_003D(array9))
					{
						list5.Add(new _0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7(array7[0], Machining.AddZ(_0023_003DzfNi7d4A_003D.Item2, _0023_003DzfNi7d4A_003D.Item1), _0023_003DzoQcRoMY_003D: true));
					}
					else
					{
						list5.Add(new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array9));
					}
				}
				if (!_0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D && l == list.Count - 1)
				{
					list4.Add(array6);
				}
			}
			list3.AddRange(list5.ToArray());
		}
		Point3D[][] _0023_003DzW_A1z8Q_003D = list4.ToArray();
		if (!_0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D)
		{
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7 item in list3.OfType<_0023_003Dzi_002412OVOc9hQdh7qT5Dqhxke1ucoN0iTgGv7wExJtC1i7>())
			{
				item._0023_003DzW_A1z8Q_003D = _0023_003DzW_A1z8Q_003D;
			}
		}
		return list3.ToArray();
	}

	private static bool _0023_003Dz9sDbTS5Fg0bo(Point3D[] _0023_003DzN57VxTE7ZsCw, Point2D _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, Point2D _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D)
	{
		for (int i = 0; i < _0023_003DzN57VxTE7ZsCw.Length; i++)
		{
			if (Utility.PointInRect(_0023_003DzN57VxTE7ZsCw[i], _0023_003DzN4s3eJdM8IozSjsTmQ_003D_003D, _0023_003DzGmKEsfskniMkM5_yZQ_003D_003D))
			{
				return false;
			}
		}
		return true;
	}
}
