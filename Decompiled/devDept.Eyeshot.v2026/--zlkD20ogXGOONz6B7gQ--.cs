using System;
using System.Collections.Generic;
using System.Linq;

internal class _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D : _0023_003DzVbNDMkfrndgH
{
	protected List<_0023_003DzVbNDMkfrndgH> _0023_003DzKj5myo8_003D;

	public _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D()
	{
	}

	public _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D(_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003Dz9NoRPtrD1TA7)
		: base(_0023_003Dz9NoRPtrD1TA7)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 22, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908227));
	}

	public override void _0023_003DzCD4XrHXr8HgF()
	{
		_0023_003DzFlURF1uBbVZv = true;
		if (_0023_003DzKj5myo8_003D == null)
		{
			return;
		}
		foreach (_0023_003DzVbNDMkfrndgH item in _0023_003DzKj5myo8_003D)
		{
			item._0023_003DzCD4XrHXr8HgF();
		}
	}

	public override bool _0023_003DzcHbyHyI_003D(string _0023_003Dz4xl6upw_003D)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 39, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746688));
		return _0023_003DzBBFunVA_003D(_0023_003Dz4xl6upw_003D) != null;
	}

	public override _0023_003DzVbNDMkfrndgH _0023_003DzBBFunVA_003D(string _0023_003Dz4xl6upw_003D)
	{
		bool _0023_003DzZIEWk9s_003D = false;
		List<string> _0023_003DzUiVzO5Q_003D = new List<string>();
		_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2 = _0023_003Dzr5YkBp8IsEI_0024;
		_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2._0023_003DzE6Vs4w8mtYNx(_0023_003Dz4xl6upw_003D, ref _0023_003DzZIEWk9s_003D, ref _0023_003DzUiVzO5Q_003D);
		if (_0023_003DzZIEWk9s_003D || _0023_003DzoThm4AM_003D())
		{
			if (_0023_003DzUiVzO5Q_003D.Count == 0)
			{
				if (_0023_003DzZIEWk9s_003D)
				{
					return null;
				}
				return _0023_003DzVr5zdGU_003D();
			}
			int num = 0;
			for (num = 0; num < _0023_003DzKj5myo8_003D.Count && !(_0023_003DzUiVzO5Q_003D.ElementAt(0) == _0023_003DzKj5myo8_003D.ElementAt(num)._0023_003DzPkGjh4I_003D()); num++)
			{
			}
			if (num == _0023_003DzKj5myo8_003D.Count)
			{
				return null;
			}
			if (_0023_003DzUiVzO5Q_003D.Count == 1)
			{
				return _0023_003DzKj5myo8_003D.ElementAt(num);
			}
			_0023_003DzUiVzO5Q_003D = _0023_003DzUiVzO5Q_003D.Skip(1).ToList();
			return _0023_003DzKj5myo8_003D.ElementAt(num)._0023_003DzBBFunVA_003D(_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2._0023_003Dzx_fM4IaFwtZaKN2goQ_003D_003D(_0023_003DzZIEWk9s_003D: true, _0023_003DzUiVzO5Q_003D));
		}
		return _0023_003DzVr5zdGU_003D()._0023_003DzBBFunVA_003D(_0023_003Dz4xl6upw_003D);
	}

	public new bool _0023_003DzoThm4AM_003D()
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 90, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302745085));
		return _0023_003DzLiYrEJY_003D == null;
	}

	public override _0023_003DzVbNDMkfrndgH _0023_003DzlDvF6iY_003D(string _0023_003Dz4xl6upw_003D)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 96, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746672));
		return _0023_003DzBBFunVA_003D(_0023_003Dz4xl6upw_003D) ?? throw new Exception();
	}

	public _0023_003DzVbNDMkfrndgH _0023_003DzlDvF6iY_003D(int _0023_003DzyzK8swU_003D)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 108, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746672));
		if (_0023_003DzyzK8swU_003D < 0 || _0023_003DzyzK8swU_003D >= _0023_003DzKj5myo8_003D.Count())
		{
			throw new Exception();
		}
		return _0023_003DzKj5myo8_003D.ElementAt(_0023_003DzyzK8swU_003D);
	}

	public long _0023_003DzZOay60w_003D()
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 118, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302743004));
		if (_0023_003DzKj5myo8_003D != null)
		{
			return _0023_003DzKj5myo8_003D.Count;
		}
		return 0L;
	}

	public override _0023_003DzmoXaE7LRujYk _0023_003DzEKSHIVc_003D()
	{
		return (_0023_003DzmoXaE7LRujYk)1;
	}

	public override void _0023_003DzOnQC6_0024o_003D(string _0023_003Dz4xl6upw_003D, _0023_003DzVbNDMkfrndgH _0023_003DzklzjGv8_003D, bool _0023_003Dz_ck61Xg9EgoH = false)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 130, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746650));
		bool _0023_003DzZIEWk9s_003D = false;
		List<string> _0023_003DzUiVzO5Q_003D = new List<string>();
		_0023_003Dzr5YkBp8IsEI_0024._0023_003DzE6Vs4w8mtYNx(_0023_003Dz4xl6upw_003D, ref _0023_003DzZIEWk9s_003D, ref _0023_003DzUiVzO5Q_003D);
		if (_0023_003DzZIEWk9s_003D)
		{
			_0023_003DzOnQC6_0024o_003D(_0023_003DzUiVzO5Q_003D, 0, _0023_003DzklzjGv8_003D, _0023_003Dz_ck61Xg9EgoH);
		}
		else
		{
			_0023_003DzVr5zdGU_003D()._0023_003DzOnQC6_0024o_003D(_0023_003DzUiVzO5Q_003D, 0, _0023_003DzklzjGv8_003D, _0023_003Dz_ck61Xg9EgoH);
		}
	}

	public override void _0023_003DzOnQC6_0024o_003D(List<string> _0023_003DzUiVzO5Q_003D, int _0023_003DzfNi7d4A_003D, _0023_003DzVbNDMkfrndgH _0023_003DzklzjGv8_003D, bool _0023_003Dz_ck61Xg9EgoH)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 148, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746650));
		if (_0023_003DzfNi7d4A_003D == 0 && _0023_003DzUiVzO5Q_003D == null)
		{
			throw new Exception();
		}
		if (_0023_003DzKj5myo8_003D == null)
		{
			_0023_003DzKj5myo8_003D = new List<_0023_003DzVbNDMkfrndgH>();
		}
		foreach (_0023_003DzVbNDMkfrndgH item in _0023_003DzKj5myo8_003D)
		{
			if (_0023_003DzUiVzO5Q_003D.ElementAt(_0023_003DzfNi7d4A_003D) == item._0023_003DzPkGjh4I_003D())
			{
				if (_0023_003DzfNi7d4A_003D == _0023_003DzUiVzO5Q_003D.Count() - 1)
				{
					throw new Exception();
				}
				item._0023_003DzOnQC6_0024o_003D(_0023_003DzUiVzO5Q_003D, _0023_003DzfNi7d4A_003D + 1, _0023_003DzklzjGv8_003D, _0023_003Dz_ck61Xg9EgoH: false);
				return;
			}
		}
		if (_0023_003DzOuScLboOB_00246e())
		{
			throw new Exception();
		}
		if (_0023_003DzfNi7d4A_003D == _0023_003DzUiVzO5Q_003D.Count() - 1)
		{
			_0023_003DzklzjGv8_003D._0023_003DzS1FCNXY_003D(this, _0023_003DzUiVzO5Q_003D[_0023_003DzfNi7d4A_003D]);
			_0023_003DzKj5myo8_003D.Add(_0023_003DzklzjGv8_003D);
			return;
		}
		if (!_0023_003Dz_ck61Xg9EgoH)
		{
			throw new Exception();
		}
		_0023_003DzVbNDMkfrndgH _0023_003DzVbNDMkfrndgH2 = this;
		while (_0023_003DzfNi7d4A_003D != _0023_003DzUiVzO5Q_003D.Count - 1)
		{
			_0023_003DzVbNDMkfrndgH _0023_003DzVbNDMkfrndgH3 = new _0023_003DzlkD20ogXGOONz6B7gQ_003D_003D(_0023_003Dzr5YkBp8IsEI_0024);
			_0023_003DzVbNDMkfrndgH2._0023_003DzOnQC6_0024o_003D(_0023_003DzUiVzO5Q_003D.ElementAt(_0023_003DzfNi7d4A_003D), _0023_003DzVbNDMkfrndgH3, _0023_003Dz_ck61Xg9EgoH: false);
			_0023_003DzVbNDMkfrndgH2 = _0023_003DzVbNDMkfrndgH3;
			_0023_003DzfNi7d4A_003D++;
		}
		_0023_003DzVbNDMkfrndgH2._0023_003DzOnQC6_0024o_003D(_0023_003DzUiVzO5Q_003D.ElementAt(_0023_003DzfNi7d4A_003D), _0023_003DzklzjGv8_003D, _0023_003Dz_ck61Xg9EgoH: false);
	}

	public virtual void _0023_003DzOnQC6_0024o_003D(long _0023_003Dze05bQYE_003D, _0023_003DzVbNDMkfrndgH _0023_003DzklzjGv8_003D)
	{
		_0023_003DzOwFNn_0024qSYgr9(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747056), 200, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302746650));
		int num = (int)_0023_003Dze05bQYE_003D;
		if (_0023_003DzKj5myo8_003D == null)
		{
			_0023_003DzKj5myo8_003D = new List<_0023_003DzVbNDMkfrndgH>();
		}
		if (_0023_003Dze05bQYE_003D < 0 || _0023_003Dze05bQYE_003D > uint.MaxValue || num > _0023_003DzKj5myo8_003D.Count())
		{
			throw new Exception();
		}
		if (num != _0023_003DzKj5myo8_003D.Count())
		{
			throw new Exception();
		}
		_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D obj = _0023_003Dz9NoRPtrD1TA7();
		_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2 = _0023_003DzklzjGv8_003D._0023_003Dz9NoRPtrD1TA7();
		if (obj != _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2)
		{
			throw new Exception();
		}
		string text = num.ToString();
		if (_0023_003DzOuScLboOB_00246e())
		{
			throw new Exception();
		}
		_0023_003DzklzjGv8_003D._0023_003DzS1FCNXY_003D(this, text);
		_0023_003DzKj5myo8_003D.Add(_0023_003DzklzjGv8_003D);
	}

	public void _0023_003DzGkfwiw0_003D(_0023_003DzVbNDMkfrndgH _0023_003DzklzjGv8_003D)
	{
		_0023_003DzOnQC6_0024o_003D(_0023_003DzZOay60w_003D(), _0023_003DzklzjGv8_003D);
	}

	public override bool _0023_003Dz8uu_Dw6Acc_00243(_0023_003DzVbNDMkfrndgH _0023_003DzklzjGv8_003D)
	{
		throw new NotImplementedException();
	}

	public override void _0023_003DzBvldItuNGTVKuhZhMg_003D_003D(HashSet<string> _0023_003DzjtiCGTFrecW_, _0023_003DzVbNDMkfrndgH _0023_003DzoMNiNRw_003D)
	{
		throw new NotImplementedException();
	}

	public override void _0023_003Dz1dPJzjY_003D(_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003DzwaocUQk_003D, _0023_003DzRCSzLwxOTjNO _0023_003DzqMm_0024toc_003D, int _0023_003Dz2gwSqZQ_003D, char[] _0023_003DzxoFi_0024YWBLVnC417CVg_003D_003D = null)
	{
		throw new NotImplementedException();
	}
}
