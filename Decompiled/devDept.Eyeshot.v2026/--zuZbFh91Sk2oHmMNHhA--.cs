using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzuZbFh91Sk2oHmMNHhA_003D_003D : _0023_003DzJSv_IuScKRfn
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected uint _0023_003DzSVkTbmk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> _0023_003DzeBP9GLo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<int> _0023_003DzsLr8dLA_003D = new List<int>();

	public virtual void _0023_003DzWz6I9bg_003D()
	{
	}

	public void _0023_003Dzw5liT4nVBUF_0024(int _0023_003Dz1v6oPQk_003D)
	{
		_0023_003DzSVkTbmk_003D = (uint)_0023_003Dz1v6oPQk_003D;
	}

	public void _0023_003DzxAH9L_0024VFiZ6m()
	{
		_0023_003DzsLr8dLA_003D.Clear();
		_0023_003DzsLr8dLA_003D.Add(0);
		_0023_003DzsLr8dLA_003D.Add(1);
		_0023_003DzsLr8dLA_003D.Add(2);
		_0023_003DzsLr8dLA_003D.Add(3);
	}

	public void _0023_003Dz3WqZPe5_0024satc()
	{
		_0023_003DzsLr8dLA_003D.Clear();
		_0023_003DzsLr8dLA_003D.Add(2);
		_0023_003DzsLr8dLA_003D.Add(3);
		_0023_003DzsLr8dLA_003D.Add(4);
		_0023_003DzsLr8dLA_003D.Add(5);
	}

	public void _0023_003Dz_njfQR1Gf1H3()
	{
		_0023_003DzsLr8dLA_003D.Clear();
		_0023_003DzsLr8dLA_003D.Add(0);
		_0023_003DzsLr8dLA_003D.Add(1);
		_0023_003DzsLr8dLA_003D.Add(4);
		_0023_003DzsLr8dLA_003D.Add(5);
	}

	public void _0023_003DzaCgY2eQ_003D(LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DzcDEsV8s_003D)
	{
		_0023_003DzeBP9GLo_003D = _0023_003Dz2BR6VU1FunA0(_0023_003DzcDEsV8s_003D, 0, null);
	}

	public LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DziR5hgdc_003D(_0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzURVICbg_003D)
	{
		LinkedList<_0023_003DzJSv_IuScKRfn> linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>();
		_0023_003DzY3oBx7Gxo_DR(linkedList, _0023_003DzURVICbg_003D, _0023_003DzeBP9GLo_003D);
		return linkedList;
	}

	public LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DzTc6UTYdwu5VlmRV_0024EszaP83_00243CxO(_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D, _0023_003DzF340z2kdR1wSrBzDCQ_003D_003D _0023_003DzdCP541Q_003D)
	{
		double num = _0023_003Dzt_m8zV0_003D._0023_003DzIkPRXYA_003D();
		_0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D2 = new _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D(_0023_003DzdCP541Q_003D._0023_003DzBJFJHwk_003D - num, _0023_003DzdCP541Q_003D._0023_003DzBJFJHwk_003D + num, _0023_003DzdCP541Q_003D._0023_003Dz40R7bAU_003D - num, _0023_003DzdCP541Q_003D._0023_003Dz40R7bAU_003D + num, _0023_003DzdCP541Q_003D._0023_003DzId5C3LA_003D, _0023_003DzdCP541Q_003D._0023_003DzId5C3LA_003D + _0023_003Dzt_m8zV0_003D._0023_003DzJ40DwJQ_003D());
		return _0023_003DziR5hgdc_003D(_0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D2);
	}

	protected global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> _0023_003Dz2BR6VU1FunA0(LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DzceNyInx9KKsG, int _0023_003DznXmeLxg_003D, global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> _0023_003DzkvBuFaE_003D)
	{
		if (_0023_003DzceNyInx9KKsG.Count == 0)
		{
			return null;
		}
		_0023_003DzWXyMItsxhf25 _0023_003DzWXyMItsxhf26 = _0023_003DzUwplt25zy6y77uhHZQ_003D_003D(_0023_003DzceNyInx9KKsG);
		double num = _0023_003DzWXyMItsxhf26._0023_003DzAqOpw0w_003D + _0023_003DzWXyMItsxhf26._0023_003DzXULhp_00248_003D / 2.0;
		if (_0023_003DzceNyInx9KKsG.Count <= _0023_003DzSVkTbmk_003D || _0023_003Dz6huvP0yWdScitb7UJQ_003D_003D._0023_003Dzo5HYhFiPdo0F(_0023_003DzWXyMItsxhf26._0023_003DzXULhp_00248_003D))
		{
			global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> result = new global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn>(_0023_003DzWXyMItsxhf26._0023_003DzXrexKjY_003D, num, _0023_003DzkvBuFaE_003D, null, null, _0023_003DzceNyInx9KKsG, _0023_003DznXmeLxg_003D);
			_0023_003DzWXyMItsxhf26 = null;
			return result;
		}
		LinkedList<_0023_003DzJSv_IuScKRfn> linkedList = new LinkedList<_0023_003DzJSv_IuScKRfn>();
		LinkedList<_0023_003DzJSv_IuScKRfn> linkedList2 = new LinkedList<_0023_003DzJSv_IuScKRfn>();
		foreach (_0023_003DzJSv_IuScKRfn item in _0023_003DzceNyInx9KKsG)
		{
			if (item._0023_003DzURVICbg_003D[(uint)_0023_003DzWXyMItsxhf26._0023_003DzXrexKjY_003D] > num)
			{
				linkedList2.AddLast(item);
			}
			else
			{
				linkedList.AddLast(item);
			}
		}
		global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> _0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2 = new global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn>(_0023_003DzWXyMItsxhf26._0023_003DzXrexKjY_003D, num, _0023_003DzkvBuFaE_003D, null, null, null, _0023_003DznXmeLxg_003D);
		if (linkedList2.Count > 0)
		{
			_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2._0023_003DzpQ9Yq40_003D = _0023_003Dz2BR6VU1FunA0(linkedList2, _0023_003DznXmeLxg_003D + 1, _0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2);
		}
		if (linkedList.Count > 0)
		{
			_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2._0023_003DzeOkTzI8_003D = _0023_003Dz2BR6VU1FunA0(linkedList, _0023_003DznXmeLxg_003D + 1, _0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2);
		}
		linkedList.Clear();
		linkedList2.Clear();
		_0023_003DzWXyMItsxhf26 = null;
		linkedList = null;
		linkedList2 = null;
		return _0023_003DzySEzUFcWq0mEfRNyuw_003D_003D2;
	}

	protected _0023_003DzWXyMItsxhf25 _0023_003DzUwplt25zy6y77uhHZQ_003D_003D(LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DzceNyInx9KKsG)
	{
		List<double> list = new List<double>();
		for (int i = 0; i < 6; i++)
		{
			list.Add(0.0);
		}
		List<double> list2 = new List<double>();
		for (int j = 0; j < 6; j++)
		{
			list2.Add(0.0);
		}
		if (_0023_003DzceNyInx9KKsG.Count == 0)
		{
			return null;
		}
		bool flag = true;
		foreach (_0023_003DzJSv_IuScKRfn item in _0023_003DzceNyInx9KKsG)
		{
			for (int k = 0; k < _0023_003DzsLr8dLA_003D.Count; k++)
			{
				if (flag)
				{
					list[_0023_003DzsLr8dLA_003D[k]] = item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]];
					list2[_0023_003DzsLr8dLA_003D[k]] = item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]];
					if (k == _0023_003DzsLr8dLA_003D.Count - 1)
					{
						flag = false;
					}
					continue;
				}
				if (list[_0023_003DzsLr8dLA_003D[k]] < item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]])
				{
					list[_0023_003DzsLr8dLA_003D[k]] = item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]];
				}
				if (list2[_0023_003DzsLr8dLA_003D[k]] > item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]])
				{
					list2[_0023_003DzsLr8dLA_003D[k]] = item._0023_003DzURVICbg_003D[(uint)_0023_003DzsLr8dLA_003D[k]];
				}
			}
		}
		_0023_003DzWXyMItsxhf25 _0023_003DzWXyMItsxhf26 = new _0023_003DzWXyMItsxhf25(_0023_003DzsLr8dLA_003D[0], list[_0023_003DzsLr8dLA_003D[0]] - list2[_0023_003DzsLr8dLA_003D[0]], list2[_0023_003DzsLr8dLA_003D[0]]);
		for (int l = 1; l < _0023_003DzsLr8dLA_003D.Count; l++)
		{
			if (list[_0023_003DzsLr8dLA_003D[l]] - list2[_0023_003DzsLr8dLA_003D[l]] > _0023_003DzWXyMItsxhf26._0023_003DzXULhp_00248_003D)
			{
				_0023_003DzWXyMItsxhf26 = new _0023_003DzWXyMItsxhf25(_0023_003DzsLr8dLA_003D[l], list[_0023_003DzsLr8dLA_003D[l]] - list2[_0023_003DzsLr8dLA_003D[l]], list2[_0023_003DzsLr8dLA_003D[l]]);
			}
		}
		return _0023_003DzWXyMItsxhf26;
	}

	protected void _0023_003DzY3oBx7Gxo_DR(LinkedList<_0023_003DzJSv_IuScKRfn> _0023_003DzceNyInx9KKsG, _0023_003Dz_0024tCzkIVROgnZQSJn2A_003D_003D _0023_003DzURVICbg_003D, global::_0023_003DzySEzUFcWq0mEfRNyuw_003D_003D<_0023_003DzJSv_IuScKRfn> _0023_003DzRXJWLHs_003D)
	{
		if (_0023_003DzRXJWLHs_003D._0023_003Dz2mBCSlg_003D)
		{
			foreach (_0023_003DzJSv_IuScKRfn item in _0023_003DzRXJWLHs_003D._0023_003DzceNyInx9KKsG)
			{
				_0023_003DzceNyInx9KKsG.AddLast(item);
			}
			return;
		}
		if (_0023_003DzRXJWLHs_003D._0023_003Dzr_3OnS8_003D % 2 == 0)
		{
			uint _0023_003DzJtUCHPI_003D = (uint)(_0023_003DzRXJWLHs_003D._0023_003Dzr_3OnS8_003D + 1);
			if (_0023_003DzRXJWLHs_003D._0023_003Dz_R6kBWgbod64 > _0023_003DzURVICbg_003D[_0023_003DzJtUCHPI_003D])
			{
				_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzeOkTzI8_003D);
				return;
			}
			if (_0023_003DzRXJWLHs_003D._0023_003DzpQ9Yq40_003D != null)
			{
				_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzpQ9Yq40_003D);
			}
			if (_0023_003DzRXJWLHs_003D._0023_003DzeOkTzI8_003D != null)
			{
				_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzeOkTzI8_003D);
			}
			return;
		}
		uint _0023_003DzJtUCHPI_003D2 = (uint)(_0023_003DzRXJWLHs_003D._0023_003Dzr_3OnS8_003D - 1);
		if (_0023_003DzRXJWLHs_003D._0023_003Dz_R6kBWgbod64 < _0023_003DzURVICbg_003D[_0023_003DzJtUCHPI_003D2])
		{
			_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzpQ9Yq40_003D);
			return;
		}
		if (_0023_003DzRXJWLHs_003D._0023_003DzpQ9Yq40_003D != null)
		{
			_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzpQ9Yq40_003D);
		}
		if (_0023_003DzRXJWLHs_003D._0023_003DzeOkTzI8_003D != null)
		{
			_0023_003DzY3oBx7Gxo_DR(_0023_003DzceNyInx9KKsG, _0023_003DzURVICbg_003D, _0023_003DzRXJWLHs_003D._0023_003DzeOkTzI8_003D);
		}
	}
}
