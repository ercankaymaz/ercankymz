using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

internal class _0023_003DzA4VSB_BJWjRqoVnNLXRJWAM_003D : _0023_003DzsbeHAAjCqCPR
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D;

	public _0023_003DzA4VSB_BJWjRqoVnNLXRJWAM_003D()
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D = new List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D>();
		_0023_003DzY_d7Tns_003D = 0;
		_0023_003DzzhSDYPa50tjn = null;
		_0023_003DzSVkTbmk_003D = 1u;
		_0023_003DzeBP9GLo_003D = new _0023_003DzuZbFh91Sk2oHmMNHhA_003D_003D();
	}

	public override void Dispose()
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Clear();
		if (_0023_003DzeBP9GLo_003D != null)
		{
			_0023_003DzeBP9GLo_003D._0023_003DzWz6I9bg_003D();
		}
		base.Dispose();
	}

	public override void _0023_003DzjpKkg5PwQXfk(_0023_003DzDS4a8SQ0SZSap4ac3A_003D_003D _0023_003DzuwH5j5s_003D)
	{
		_0023_003Dz_0024KKopL9T7nzT = _0023_003DzuwH5j5s_003D;
		_0023_003DzeBP9GLo_003D._0023_003DzxAH9L_0024VFiZ6m();
		_0023_003DzeBP9GLo_003D._0023_003Dzw5liT4nVBUF_0024((int)_0023_003DzSVkTbmk_003D);
		_0023_003DzeBP9GLo_003D._0023_003DzaCgY2eQ_003D(_0023_003DzuwH5j5s_003D._0023_003DzceNyInx9KKsG);
	}

	public override void _0023_003Dzak_n3oJBpB71(_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Add(_0023_003DzB68dg9Q_003D);
	}

	public override void _0023_003Dzc_0024pb7t4_003D()
	{
		_0023_003Dz829Pj81PBMzsVrIcHg_003D_003D(null);
	}

	public void _0023_003Dzz8DDgng_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003Dz829Pj81PBMzsVrIcHg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
	}

	public override List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> _0023_003DzbbwM8JeHW4GP()
	{
		return _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D;
	}

	public override void _0023_003DzjMxCQzALYgSK()
	{
		_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Clear();
	}

	protected void _0023_003Dzlt_reWoFHRX_iUQfhA_003D_003D()
	{
		_0023_003DzY_d7Tns_003D = 0;
		foreach (_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D item in _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D)
		{
			foreach (_0023_003DzJSv_IuScKRfn item2 in _0023_003Dz_0024KKopL9T7nzT._0023_003DzceNyInx9KKsG)
			{
				if (item._0023_003Dz_JojPRlCDQpL(item2))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzAuzAB79Pwj5S4SKNzQ_003D_003D(item, item2, null);
					_0023_003DzY_d7Tns_003D++;
				}
			}
		}
	}

	protected void _0023_003DzM2PbyEDOU6oa5p0Vpw_003D_003D()
	{
		_0023_003DzY_d7Tns_003D = 0;
		foreach (_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D item in _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D)
		{
			foreach (_0023_003DzJSv_IuScKRfn item2 in _0023_003DzeBP9GLo_003D._0023_003DzTc6UTYdwu5VlmRV_0024EszaP83_00243CxO(_0023_003DzzhSDYPa50tjn, item))
			{
				if (item._0023_003Dz_JojPRlCDQpL(item2))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzAuzAB79Pwj5S4SKNzQ_003D_003D(item, item2, null);
					_0023_003DzY_d7Tns_003D++;
				}
			}
		}
	}

	protected void _0023_003Dzws_0024UjzW9QJOjdBmT2Q_003D_003D()
	{
		_0023_003DzY_d7Tns_003D = 0;
		foreach (_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D item in _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D)
		{
			foreach (_0023_003DzJSv_IuScKRfn item2 in _0023_003DzeBP9GLo_003D._0023_003DzTc6UTYdwu5VlmRV_0024EszaP83_00243CxO(_0023_003DzzhSDYPa50tjn, item))
			{
				if (_0023_003DzzhSDYPa50tjn._0023_003DzzSjnXmrsuAepxLu2FQ_003D_003D(item, item2) && item._0023_003Dz_JojPRlCDQpL(item2))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzAuzAB79Pwj5S4SKNzQ_003D_003D(item, item2, null);
					_0023_003DzY_d7Tns_003D++;
				}
			}
		}
	}

	protected void _0023_003Dzwhh08uJzZJsxgaTNgA_003D_003D()
	{
		_0023_003DzY_d7Tns_003D = 0;
		int num = 0;
		int num2 = 0;
		LinkedList<_0023_003DzJSv_IuScKRfn> linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>();
		uint count = (uint)_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Count;
		List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list = _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			num3++;
			linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>(_0023_003DzeBP9GLo_003D._0023_003DzTc6UTYdwu5VlmRV_0024EszaP83_00243CxO(_0023_003DzzhSDYPa50tjn, list[i]));
			LinkedList<_0023_003DzJSv_IuScKRfn>.Enumerator enumerator = linkedList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzzhSDYPa50tjn._0023_003DzzSjnXmrsuAepxLu2FQ_003D_003D(list[i], enumerator.Current) && list[i]._0023_003Dz_JojPRlCDQpL(enumerator.Current))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzwRZRUP_y0ph7m1qG2Q_003D_003D(list[i], enumerator.Current, null);
					num++;
				}
			}
			enumerator = linkedList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzzhSDYPa50tjn._0023_003DzzSjnXmrsuAepxLu2FQ_003D_003D(list[i], enumerator.Current) && list[i]._0023_003Dz_JojPRlCDQpL(enumerator.Current))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzbDLxTiZxQIw0(list[i], enumerator.Current, null);
				}
			}
			enumerator = linkedList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzzhSDYPa50tjn._0023_003DzzSjnXmrsuAepxLu2FQ_003D_003D(list[i], enumerator.Current) && list[i]._0023_003Dz_JojPRlCDQpL(enumerator.Current))
				{
					_0023_003DzzhSDYPa50tjn._0023_003Dz87KX2476hK3U(list[i], enumerator.Current, null);
				}
			}
			num2 += linkedList.Count;
		}
		_0023_003DzY_d7Tns_003D = num;
	}

	protected void _0023_003Dz829Pj81PBMzsVrIcHg_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003DzY_d7Tns_003D = 0;
		int num = 0;
		int num2 = 0;
		LinkedList<_0023_003DzJSv_IuScKRfn> linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>();
		uint count = (uint)_0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D.Count;
		List<_0023_003DzF340z2kdR1wSrBzDCQ_003D_003D> list = _0023_003DzZIWyX_0024uX1cTgAvtWlA_003D_003D;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			num3++;
			linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>(_0023_003DzeBP9GLo_003D._0023_003DzTc6UTYdwu5VlmRV_0024EszaP83_00243CxO(_0023_003DzzhSDYPa50tjn, list[i]));
			LinkedList<_0023_003DzJSv_IuScKRfn>.Enumerator enumerator = linkedList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzzhSDYPa50tjn._0023_003DzzSjnXmrsuAepxLu2FQ_003D_003D(list[i], enumerator.Current) && list[i]._0023_003Dz_JojPRlCDQpL(enumerator.Current))
				{
					_0023_003DzzhSDYPa50tjn._0023_003DzAuzAB79Pwj5S4SKNzQ_003D_003D(list[i], enumerator.Current, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
					num++;
				}
			}
			num2 += linkedList.Count;
		}
		_0023_003DzY_d7Tns_003D = num;
	}
}
