using System;
using System.Collections.Generic;
using System.Diagnostics;

internal abstract class _0023_003Dzq2iTTSx811_0024qBvIVqD7AW7Y_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected _0023_003Dz29lw1Oqn8K7JkXy0VVF09aE_003D _0023_003Dz5rQzobg_003D = new _0023_003Dz29lw1Oqn8K7JkXy0VVF09aE_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<List<_0023_003DzoC5nni_JI9M0>> _0023_003Dzcv8o5nO25OjS = new List<List<_0023_003DzoC5nni_JI9M0>>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzQZT_0024QgDKtAVQ = new List<_0023_003Dzi7XR59NGN6Cp>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003Dzi7XR59NGN6Cp> _0023_003DzcEy0WMEw_0024la1 = new List<_0023_003Dzi7XR59NGN6Cp>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected List<_0023_003DzoC5nni_JI9M0> _0023_003DzBB2Doz8jTrD8 = new List<_0023_003DzoC5nni_JI9M0>();

	public _0023_003Dzq2iTTSx811_0024qBvIVqD7AW7Y_003D()
	{
	}

	public virtual void Dispose()
	{
	}

	public void _0023_003DzQBJ0gJk_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
	{
		if (_0023_003DzhidJeNw_003D._0023_003DzCJkr8nY_003D._0023_003DzZFV3Zeo_003D() && !_0023_003DzhidJeNw_003D._0023_003DzqRJnPHc_003D())
		{
			_0023_003DzQZT_0024QgDKtAVQ.Add(_0023_003DzhidJeNw_003D);
		}
		else if (_0023_003DzhidJeNw_003D._0023_003DzCJkr8nY_003D._0023_003DzW51BQ6g_003D() && !_0023_003DzhidJeNw_003D._0023_003DzqRJnPHc_003D())
		{
			_0023_003DzcEy0WMEw_0024la1.Add(_0023_003DzhidJeNw_003D);
		}
		else
		{
			_0023_003DzhidJeNw_003D._0023_003DzqRJnPHc_003D();
		}
	}

	public abstract void _0023_003DzaCgY2eQ_003D();

	public void _0023_003DzHxyb1LjWGoq4()
	{
		while (_0023_003DzBB2Doz8jTrD8.Count > 0)
		{
			List<_0023_003DzoC5nni_JI9M0> list = new List<_0023_003DzoC5nni_JI9M0>();
			_0023_003DzoC5nni_JI9M0 _0023_003DzoC5nni_JI9M1 = _0023_003DzBB2Doz8jTrD8[0];
			_0023_003DzoC5nni_JI9M0 _0023_003DzoC5nni_JI9M2 = _0023_003DzoC5nni_JI9M1;
			do
			{
				list.Add(_0023_003DzoC5nni_JI9M1);
				_0023_003DzBB2Doz8jTrD8.Remove(_0023_003DzoC5nni_JI9M1);
				_0023_003DzsZ4ZibZTpgv3 _0023_003DzbfrNXYE_003D = _0023_003Dz5rQzobg_003D._0023_003DzJVn1_t7YECLiZMJk8w_003D_003D(_0023_003DzoC5nni_JI9M1)[0];
				do
				{
					_0023_003DzoC5nni_JI9M1 = _0023_003Dz5rQzobg_003D._0023_003Dzzo8RvXc_003D(_0023_003DzbfrNXYE_003D);
					_0023_003DzbfrNXYE_003D = _0023_003Dz5rQzobg_003D[_0023_003DzbfrNXYE_003D]._0023_003DzvmFFjUs_003D;
				}
				while (_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DzEKSHIVc_003D != 0);
			}
			while (_0023_003DzoC5nni_JI9M1 != _0023_003DzoC5nni_JI9M2);
			_0023_003Dzcv8o5nO25OjS.Add(list);
		}
	}

	public List<List<_0023_003DzmKBPh7nOT6nY>> _0023_003DzLRqJOHw_003D()
	{
		List<List<_0023_003DzmKBPh7nOT6nY>> list = new List<List<_0023_003DzmKBPh7nOT6nY>>();
		foreach (List<_0023_003DzoC5nni_JI9M0> _0023_003Dzcv8o5nO25Oj in _0023_003Dzcv8o5nO25OjS)
		{
			List<_0023_003DzmKBPh7nOT6nY> list2 = new List<_0023_003DzmKBPh7nOT6nY>();
			foreach (_0023_003DzoC5nni_JI9M0 item in _0023_003Dzcv8o5nO25Oj)
			{
				list2.Add(_0023_003Dz5rQzobg_003D[item]._0023_003DztUjb52A_003D);
			}
			list.Add(list2);
		}
		return new List<List<_0023_003DzmKBPh7nOT6nY>>(list);
	}

	public List<List<_0023_003DzmKBPh7nOT6nY>> _0023_003DzViCjUgk_003D()
	{
		List<List<_0023_003DzmKBPh7nOT6nY>> list = new List<List<_0023_003DzmKBPh7nOT6nY>>();
		foreach (_0023_003DzsZ4ZibZTpgv3 item in _0023_003Dz5rQzobg_003D._0023_003DzU3hosSAzkxO7())
		{
			List<_0023_003DzmKBPh7nOT6nY> list2 = new List<_0023_003DzmKBPh7nOT6nY>();
			_0023_003DzoC5nni_JI9M0 _0023_003Dz77g161c_003D = _0023_003Dz5rQzobg_003D._0023_003Dzb7SPTpc_003D(item);
			_0023_003DzoC5nni_JI9M0 _0023_003Dz77g161c_003D2 = _0023_003Dz5rQzobg_003D._0023_003Dzzo8RvXc_003D(item);
			list2.Add(_0023_003Dz5rQzobg_003D[_0023_003Dz77g161c_003D]._0023_003DztUjb52A_003D);
			list2.Add(_0023_003Dz5rQzobg_003D[_0023_003Dz77g161c_003D2]._0023_003DztUjb52A_003D);
			list.Add(list2);
		}
		return list;
	}

	public override string ToString()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747285) + _0023_003DzQZT_0024QgDKtAVQ.Count + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747267) + _0023_003DzcEy0WMEw_0024la1.Count + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748022);
	}

	public void _0023_003DzOFAUxPh3KjC2()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (_0023_003DzoC5nni_JI9M0 item in _0023_003Dz5rQzobg_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D())
		{
			if (_0023_003Dz5rQzobg_003D[item]._0023_003DzEKSHIVc_003D == (_0023_003DzLoV38OWkgKii)0)
			{
				num2++;
			}
			else
			{
				num3++;
			}
			num++;
		}
	}
}
