using System;
using System.Collections.Generic;
using System.Diagnostics;

internal class _0023_003Dzi7XR59NGN6Cp : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public _0023_003DzmKBPh7nOT6nY _0023_003DzCJkr8nY_003D = new _0023_003DzmKBPh7nOT6nY();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public List<_0023_003DznZQ9NSjF878u> _0023_003DzhoegMB067LVL = new List<_0023_003DznZQ9NSjF878u>();

	public _0023_003Dzi7XR59NGN6Cp()
	{
		_0023_003DzhoegMB067LVL.Clear();
	}

	public _0023_003Dzi7XR59NGN6Cp(_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y, _0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY)
	{
		_0023_003DzFj_0024IqDQ_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzsiQjbwmUNI0y);
		_0023_003DzjdeMMkk_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzSElTn3BlQAJY);
		_0023_003DzZ97Z2_0024AecinQ();
	}

	public _0023_003Dzi7XR59NGN6Cp(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
	{
		_0023_003DzFj_0024IqDQ_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzhidJeNw_003D._0023_003DzFj_0024IqDQ_003D);
		_0023_003DzjdeMMkk_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzhidJeNw_003D._0023_003DzjdeMMkk_003D);
		_0023_003DzhoegMB067LVL.AddRange(_0023_003DzhidJeNw_003D._0023_003DzhoegMB067LVL);
		_0023_003DzCJkr8nY_003D = _0023_003DzhidJeNw_003D._0023_003DzCJkr8nY_003D;
	}

	public virtual void Dispose()
	{
	}

	public void _0023_003DzblRNW9I_003D(_0023_003DznZQ9NSjF878u _0023_003Dz437_00244ak_003D)
	{
		if (_0023_003Dz437_00244ak_003D._0023_003DzqRJnPHc_003D())
		{
			return;
		}
		if (_0023_003DzhoegMB067LVL.Count == 0)
		{
			_0023_003DzhoegMB067LVL.Add(_0023_003Dz437_00244ak_003D);
		}
		else
		{
			if (_0023_003Dz8y9lXPc_003D(_0023_003Dz437_00244ak_003D))
			{
				return;
			}
			if (_0023_003DziVGaloE_003D(_0023_003Dz437_00244ak_003D))
			{
				_0023_003DzhoegMB067LVL.Add(_0023_003Dz437_00244ak_003D);
				return;
			}
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator = _0023_003DzhoegMB067LVL.GetEnumerator();
			List<_0023_003DznZQ9NSjF878u> list = new List<_0023_003DznZQ9NSjF878u>();
			int num = -1;
			List<int> list2 = new List<int>();
			while (enumerator.MoveNext())
			{
				num++;
				if (!enumerator.Current._0023_003DzlNxMjwYmRTkG(_0023_003Dz437_00244ak_003D))
				{
					list.Add(enumerator.Current);
					list2.Add(num);
				}
			}
			for (int num2 = list2.Count - 1; num2 >= 0; num2--)
			{
				_0023_003DzhoegMB067LVL.RemoveAt(list2[num2]);
			}
			list.Add(_0023_003Dz437_00244ak_003D);
			_0023_003DznZQ9NSjF878u _0023_003DznZQ9NSjF878u2 = new _0023_003DznZQ9NSjF878u();
			foreach (_0023_003DznZQ9NSjF878u item in list)
			{
				_0023_003DznZQ9NSjF878u2._0023_003DzNAcifrFBU1m4(item._0023_003Dz6V_0024QadA_003D, item._0023_003DzwGZbb91qO0Xq);
				_0023_003DznZQ9NSjF878u2._0023_003DzjYw3maUbM4_00249(item._0023_003DzCskoEKg_003D, item._0023_003DzlcZR_0024uiUnlyK);
			}
			_0023_003DzhoegMB067LVL.Add(_0023_003DznZQ9NSjF878u2);
		}
	}

	public bool _0023_003Dz8y9lXPc_003D(_0023_003DznZQ9NSjF878u _0023_003Dz437_00244ak_003D)
	{
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003DzhoegMB067LVL)
		{
			if (_0023_003Dz437_00244ak_003D._0023_003Dzsc0Foo8_003D(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool _0023_003DziVGaloE_003D(_0023_003DznZQ9NSjF878u _0023_003Dz437_00244ak_003D)
	{
		bool result = true;
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003DzhoegMB067LVL)
		{
			if (!_0023_003Dz437_00244ak_003D._0023_003DzlNxMjwYmRTkG(item))
			{
				result = false;
			}
		}
		return result;
	}

	public double _0023_003Dzz_0024qx4xU2P_0024AA(_0023_003DzmKBPh7nOT6nY _0023_003DzB68dg9Q_003D)
	{
		double num = _0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D;
		double num2 = _0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D;
		double num3 = _0023_003DzjdeMMkk_003D._0023_003DzId5C3LA_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D;
		double num4 = _0023_003DzB68dg9Q_003D._0023_003DzBJFJHwk_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D;
		double num5 = _0023_003DzB68dg9Q_003D._0023_003Dz40R7bAU_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D;
		double num6 = _0023_003DzB68dg9Q_003D._0023_003DzId5C3LA_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D;
		return (num4 * num + num5 * num2 + num6 * num3) / (num * num + num2 * num2 + num3 * num3);
	}

	public _0023_003DzmKBPh7nOT6nY _0023_003DzlY77YgY_003D(double _0023_003DzNDQ_E88_003D)
	{
		double _0023_003DzEI2ExbQ_003D = _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D + _0023_003DzNDQ_E88_003D * (_0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D);
		double _0023_003DzFP3nEGM_003D = _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D + _0023_003DzNDQ_E88_003D * (_0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D);
		double _0023_003Dz4IJN9yU_003D = _0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D + _0023_003DzNDQ_E88_003D * (_0023_003DzjdeMMkk_003D._0023_003DzId5C3LA_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D);
		return new _0023_003DzmKBPh7nOT6nY(_0023_003DzEI2ExbQ_003D, _0023_003DzFP3nEGM_003D, _0023_003Dz4IJN9yU_003D);
	}

	public void _0023_003DzFNq7BiVVTMpl()
	{
		int num = 0;
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003DzhoegMB067LVL)
		{
			_ = item;
			num++;
		}
	}

	public bool _0023_003DzqRJnPHc_003D()
	{
		return _0023_003DzhoegMB067LVL.Count == 0;
	}

	public uint _0023_003Dz14lzA48_003D()
	{
		return (uint)_0023_003DzhoegMB067LVL.Count;
	}

	public _0023_003DzmKBPh7nOT6nY _0023_003DzHLkv1LrWqp78(int _0023_003DzoMNiNRw_003D)
	{
		return new _0023_003DzmKBPh7nOT6nY(_0023_003DzlY77YgY_003D(_0023_003DzhoegMB067LVL[_0023_003DzoMNiNRw_003D]._0023_003DzCskoEKg_003D));
	}

	public _0023_003DzmKBPh7nOT6nY _0023_003DzSTJC3fMAjyew(int _0023_003DzoMNiNRw_003D)
	{
		return new _0023_003DzmKBPh7nOT6nY(_0023_003DzlY77YgY_003D(_0023_003DzhoegMB067LVL[_0023_003DzoMNiNRw_003D]._0023_003Dz6V_0024QadA_003D));
	}

	public static bool operator ==(_0023_003Dzi7XR59NGN6Cp _0023_003DzMSiplI0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003Dzl_0024MIsC0_003D)
	{
		if (_0023_003DzMSiplI0_003D._0023_003DzFj_0024IqDQ_003D == _0023_003Dzl_0024MIsC0_003D._0023_003DzFj_0024IqDQ_003D && _0023_003DzMSiplI0_003D._0023_003DzjdeMMkk_003D == _0023_003Dzl_0024MIsC0_003D._0023_003DzjdeMMkk_003D)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(_0023_003Dzi7XR59NGN6Cp _0023_003DzMSiplI0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003Dzl_0024MIsC0_003D)
	{
		return !(_0023_003DzMSiplI0_003D == _0023_003Dzl_0024MIsC0_003D);
	}

	protected void _0023_003DzZ97Z2_0024AecinQ()
	{
		_0023_003DzCJkr8nY_003D._0023_003Dz_0024xXJldw_003D(_0023_003DzjdeMMkk_003D - _0023_003DzFj_0024IqDQ_003D);
		_0023_003DzCJkr8nY_003D._0023_003Dzt_0024wZMac_003D();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747540), _0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302747534), _0023_003DzhoegMB067LVL.Count);
	}
}
