using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;

internal sealed class _0023_003Dzq41Q4IpTZTmuG_g9p73JEI_0024_1ZZW
{
	public List<Point2D> _0023_003DzFsatqHw_003D;

	public _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[] _0023_003DzfRXMst08ZQJJk2RLIg_003D_003D;

	private readonly _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[] _0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D;

	public _0023_003Dzq41Q4IpTZTmuG_g9p73JEI_0024_1ZZW(PolyRegion2D _0023_003DzD_npGCK4gceWlLnvjA_003D_003D)
	{
		_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D = new _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[_0023_003DzD_npGCK4gceWlLnvjA_003D_003D.ContourList.Count];
		_0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D = new _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D.Length];
		_0023_003DzFsatqHw_003D = new List<Point2D>(_0023_003DzD_npGCK4gceWlLnvjA_003D_003D.ContourList[0].Points.Length);
		for (int i = 0; i < _0023_003DzD_npGCK4gceWlLnvjA_003D_003D.ContourList.Count; i++)
		{
			Polygon2D polygon2D = _0023_003DzD_npGCK4gceWlLnvjA_003D_003D.ContourList[i];
			_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i] = new _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi(polygon2D.Points.Length);
			_0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D[i] = new _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi(polygon2D.Points.Length);
			for (int j = 0; j < polygon2D.Points.Length - 1; j++)
			{
				if (i > 0 && _0023_003DzFsatqHw_003D.Count > 0)
				{
					bool flag = false;
					for (int k = 0; k < i; k++)
					{
						foreach (int item in _0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[k]._0023_003DzcrRI_CI_003D)
						{
							if (Point2D.Distance(polygon2D.Points[j], _0023_003DzFsatqHw_003D[item]) < Utility._0023_003DzheSR8QM7q9ya)
							{
								_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]._0023_003DzcrRI_CI_003D.Add(item);
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]._0023_003DzcrRI_CI_003D.Add(_0023_003DzFsatqHw_003D.Count);
				_0023_003DzFsatqHw_003D.Add(polygon2D.Points[j]);
			}
			_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]._0023_003DzcrRI_CI_003D.Add(_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]._0023_003DzcrRI_CI_003D[0]);
			_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]._0023_003DzZH19a0bYlPkl(_0023_003DzFsatqHw_003D);
			_0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D[i] = new _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi(_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[i]);
		}
	}

	public int _0023_003DzwVFSvec_003D(Point2D _0023_003DzlY77YgY_003D, int _0023_003Dz06A5WivSSyUp, int _0023_003DzyzK8swU_003D)
	{
		int count = _0023_003DzFsatqHw_003D.Count;
		_0023_003DzFsatqHw_003D.Add(_0023_003DzlY77YgY_003D);
		_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[_0023_003Dz06A5WivSSyUp]._0023_003DzcrRI_CI_003D.Insert(_0023_003DzyzK8swU_003D, count);
		return count;
	}

	public int _0023_003DzSXxZOK9GJeL1(IList<Point2D> _0023_003DzrdSL0CI_003D, int _0023_003Dz06A5WivSSyUp, int _0023_003DzyzK8swU_003D)
	{
		int count = _0023_003DzFsatqHw_003D.Count;
		_0023_003DzFsatqHw_003D.AddRange(_0023_003DzrdSL0CI_003D);
		_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D[_0023_003Dz06A5WivSSyUp]._0023_003DzcrRI_CI_003D.InsertRange(_0023_003DzyzK8swU_003D, Enumerable.Range(count, _0023_003DzrdSL0CI_003D.Count));
		return count;
	}

	public PolyRegion2D _0023_003DzGX3_dxusCIHn()
	{
		List<Polygon2D> list = new List<Polygon2D>(_0023_003DzfRXMst08ZQJJk2RLIg_003D_003D.Length);
		_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[] array = _0023_003DzfRXMst08ZQJJk2RLIg_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi obj = array[i];
			List<Point2D> list2 = new List<Point2D>(obj._0023_003DzcrRI_CI_003D.Count);
			foreach (int item in obj._0023_003DzcrRI_CI_003D)
			{
				list2.Add((Point2D)_0023_003DzFsatqHw_003D[item].Clone());
			}
			list.Add(new Polygon2D(list2));
		}
		return new PolyRegion2D(list);
	}

	internal pointStatusType _0023_003DzrfhmnHeX0Pzt(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzZTe_0024jFG9ebLg, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		pointStatusType pointStatusType2 = _0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D[0]._0023_003DzrfhmnHeX0Pzt(_0023_003DzFsatqHw_003D, _0023_003DzZTe_0024jFG9ebLg, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		if (pointStatusType2 != pointStatusType.Inside)
		{
			return pointStatusType2;
		}
		for (int i = 1; i < _0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D.Length; i++)
		{
			switch (_0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D[i]._0023_003DzrfhmnHeX0Pzt(_0023_003DzFsatqHw_003D, _0023_003DzZTe_0024jFG9ebLg, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D))
			{
			case pointStatusType.Onto:
				return pointStatusType.Onto;
			case pointStatusType.Inside:
				return pointStatusType.Outside;
			}
		}
		return pointStatusType.Inside;
	}

	public void _0023_003DzipjeF10_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		foreach (Point2D item in _0023_003DzFsatqHw_003D)
		{
			_0023_003DzipjeF10_003D(item, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		}
		_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi[] array = _0023_003DzfRXMst08ZQJJk2RLIg_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi2 = array[i];
			_0023_003DzipjeF10_003D(_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi2._0023_003DzZqSqKm8_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
			_0023_003DzipjeF10_003D(_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi2._0023_003DztvD0Jdc_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		}
		array = _0023_003DzeYYEUDLwhBApYLw6CQ_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi _0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi3 = array[i];
			_0023_003DzipjeF10_003D(_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi3._0023_003DzZqSqKm8_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
			_0023_003DzipjeF10_003D(_0023_003Dz88MYyaDbRMBsUd_0024_hi9zORROxIgi3._0023_003DztvD0Jdc_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		}
	}

	private void _0023_003DzipjeF10_003D(Point2D _0023_003DzlY77YgY_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		_0023_003DzlY77YgY_003D.X *= _0023_003DzBJFJHwk_003D;
		_0023_003DzlY77YgY_003D.Y *= _0023_003Dz40R7bAU_003D;
	}
}
