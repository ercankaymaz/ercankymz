using System;
using System.Diagnostics;
using System.Linq;

internal sealed class _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz : ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzoMNiNRw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzXrexKjY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzbfrNXYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[,] _0023_003Dz61IPlm0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[,] _0023_003DzNDN2q2o_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003Dz6GIylvE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzOyStcKQz5pzWLxDKuA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003Dz5lPrgVA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[,] _0023_003DzNRXx2Sbl68akfLirUA_003D_003D;

	public _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz(double[,] _0023_003DzPzO_0024GUk_003D, bool _0023_003Dzz1zRqomK9jtILG1k2Q_003D_003D, bool _0023_003DzuWbYKRJA_cXR = false, bool _0023_003DzoQcRoMY_003D = false)
	{
		if (_0023_003DzPzO_0024GUk_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984222), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984199));
		}
		if (_0023_003DzPzO_0024GUk_003D.GetLength(0) != _0023_003DzPzO_0024GUk_003D.GetLength(1))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984422), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984393));
		}
		_0023_003DzoMNiNRw_003D = _0023_003DzPzO_0024GUk_003D.GetLength(1);
		_0023_003Dz61IPlm0_003D = new double[_0023_003DzoMNiNRw_003D, _0023_003DzoMNiNRw_003D];
		_0023_003DzXrexKjY_003D = new double[_0023_003DzoMNiNRw_003D];
		_0023_003DzbfrNXYE_003D = new double[_0023_003DzoMNiNRw_003D];
		_0023_003DzOyStcKQz5pzWLxDKuA_003D_003D = _0023_003Dzz1zRqomK9jtILG1k2Q_003D_003D;
		if (_0023_003DzOyStcKQz5pzWLxDKuA_003D_003D)
		{
			_0023_003Dz61IPlm0_003D = (_0023_003DzuWbYKRJA_cXR ? _0023_003DzPzO_0024GUk_003D : ((double[,])_0023_003DzPzO_0024GUk_003D.Clone()));
			_0023_003DzcnW7lq2r0cr9();
			_0023_003DzBnxun8teKtYd();
		}
		else
		{
			_0023_003DzNDN2q2o_003D = (_0023_003DzuWbYKRJA_cXR ? _0023_003DzPzO_0024GUk_003D : ((double[,])_0023_003DzPzO_0024GUk_003D.Clone()));
			_0023_003Dz6GIylvE_003D = new double[_0023_003DzoMNiNRw_003D];
			_0023_003Dz78XmYKQG618V();
			_0023_003Dz9I9tKu8yL4FQ();
		}
		if (_0023_003DzoQcRoMY_003D)
		{
			int[] array = Enumerable.Range(0, _0023_003DzoMNiNRw_003D).ToArray();
			Array.Sort(array, (int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D) => (Math.Abs(_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D]) == Math.Abs(_0023_003DzXrexKjY_003D[_0023_003DzTSeNR8Q_003D])) ? (-Math.Abs(_0023_003DzbfrNXYE_003D[_0023_003Dz437_00244ak_003D]).CompareTo(Math.Abs(_0023_003DzbfrNXYE_003D[_0023_003DzTSeNR8Q_003D]))) : (-Math.Abs(_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D]).CompareTo(Math.Abs(_0023_003DzXrexKjY_003D[_0023_003DzTSeNR8Q_003D]))));
			_0023_003DzXrexKjY_003D = _0023_003Dz2mJ2y7U_003D(_0023_003DzXrexKjY_003D, array, _0023_003DzuWbYKRJA_cXR: false);
			_0023_003DzbfrNXYE_003D = _0023_003Dz2mJ2y7U_003D(_0023_003DzbfrNXYE_003D, array, _0023_003DzuWbYKRJA_cXR: false);
			_0023_003Dz61IPlm0_003D = _0023_003Dz2mJ2y7U_003D(_0023_003Dz61IPlm0_003D, null, array, null);
		}
	}

	private _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz()
	{
	}

	public int _0023_003Dz_kOoFG0m5mXc()
	{
		if (_0023_003Dz5lPrgVA_003D.HasValue)
		{
			return _0023_003Dz5lPrgVA_003D.Value;
		}
		double num = (double)_0023_003DzoMNiNRw_003D * _0023_003DzXrexKjY_003D[0] * 2.220446049250313E-16;
		int num2 = 0;
		for (int i = 0; i < _0023_003DzXrexKjY_003D.Length; i++)
		{
			if (_0023_003DzXrexKjY_003D[i] > num)
			{
				num2++;
			}
		}
		int? num3 = (_0023_003Dz5lPrgVA_003D = num2);
		return num3.Value;
	}

	private T[,] _0023_003Dz2mJ2y7U_003D<T>(T[,] _0023_003Dzb7SPTpc_003D, int[] _0023_003Dz_5ig6IdrgpzL, int[] _0023_003DzKdyvawT4xYEq, T[,] _0023_003DzOLHnb2M_003D)
	{
		return _0023_003DzlDvF6iY_003D(_0023_003Dzb7SPTpc_003D, _0023_003DzOLHnb2M_003D, _0023_003Dz_5ig6IdrgpzL, _0023_003DzKdyvawT4xYEq);
	}

	private T[,] _0023_003DzlDvF6iY_003D<T>(T[,] _0023_003Dzb7SPTpc_003D, T[,] _0023_003Dzw_E1nLs_003D, int[] _0023_003Dz_5ig6IdrgpzL, int[] _0023_003DzKdyvawT4xYEq)
	{
		if (_0023_003Dzb7SPTpc_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984374));
		}
		int length = _0023_003Dzb7SPTpc_003D.GetLength(0);
		int length2 = _0023_003Dzb7SPTpc_003D.GetLength(1);
		int num = length;
		int num2 = length2;
		if (_0023_003Dz_5ig6IdrgpzL == null && _0023_003DzKdyvawT4xYEq == null)
		{
			return _0023_003Dzb7SPTpc_003D;
		}
		if (_0023_003Dz_5ig6IdrgpzL != null)
		{
			num = _0023_003Dz_5ig6IdrgpzL.Length;
			for (int i = 0; i < _0023_003Dz_5ig6IdrgpzL.Length; i++)
			{
				if (_0023_003Dz_5ig6IdrgpzL[i] < 0 || _0023_003Dz_5ig6IdrgpzL[i] >= length)
				{
					throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984383));
				}
			}
		}
		if (_0023_003DzKdyvawT4xYEq != null)
		{
			num2 = _0023_003DzKdyvawT4xYEq.Length;
			for (int j = 0; j < _0023_003DzKdyvawT4xYEq.Length; j++)
			{
				if (_0023_003DzKdyvawT4xYEq[j] < 0 || _0023_003DzKdyvawT4xYEq[j] >= length2)
				{
					throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984383));
				}
			}
		}
		if (_0023_003Dzw_E1nLs_003D != null)
		{
			if (_0023_003Dzw_E1nLs_003D.GetLength(0) < num || _0023_003Dzw_E1nLs_003D.GetLength(1) < num2)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984350));
			}
		}
		else
		{
			_0023_003Dzw_E1nLs_003D = new T[num, num2];
		}
		if (_0023_003DzKdyvawT4xYEq == null)
		{
			for (int k = 0; k < _0023_003Dz_5ig6IdrgpzL.Length; k++)
			{
				for (int l = 0; l < length2; l++)
				{
					_0023_003Dzw_E1nLs_003D[k, l] = _0023_003Dzb7SPTpc_003D[_0023_003Dz_5ig6IdrgpzL[k], l];
				}
			}
		}
		else if (_0023_003Dz_5ig6IdrgpzL == null)
		{
			for (int m = 0; m < length; m++)
			{
				for (int n = 0; n < _0023_003DzKdyvawT4xYEq.Length; n++)
				{
					_0023_003Dzw_E1nLs_003D[m, n] = _0023_003Dzb7SPTpc_003D[m, _0023_003DzKdyvawT4xYEq[n]];
				}
			}
		}
		else
		{
			for (int num3 = 0; num3 < _0023_003Dz_5ig6IdrgpzL.Length; num3++)
			{
				for (int num4 = 0; num4 < _0023_003DzKdyvawT4xYEq.Length; num4++)
				{
					_0023_003Dzw_E1nLs_003D[num3, num4] = _0023_003Dzb7SPTpc_003D[_0023_003Dz_5ig6IdrgpzL[num3], _0023_003DzKdyvawT4xYEq[num4]];
				}
			}
		}
		return _0023_003Dzw_E1nLs_003D;
	}

	private T[] _0023_003Dz2mJ2y7U_003D<T>(T[] _0023_003Dzb7SPTpc_003D, int[] _0023_003DznAsnXqw_003D, bool _0023_003DzuWbYKRJA_cXR)
	{
		if (_0023_003Dzb7SPTpc_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985034));
		}
		if (_0023_003DznAsnXqw_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985011));
		}
		T[] array = new T[_0023_003DznAsnXqw_003D.Length];
		for (int i = 0; i < _0023_003DznAsnXqw_003D.Length; i++)
		{
			int num = _0023_003DznAsnXqw_003D[i];
			if (num >= 0)
			{
				array[i] = _0023_003Dzb7SPTpc_003D[num];
			}
			else
			{
				array[i] = _0023_003Dzb7SPTpc_003D[_0023_003Dzb7SPTpc_003D.Length + num];
			}
		}
		if (_0023_003DzuWbYKRJA_cXR)
		{
			for (int j = 0; j < array.Length; j++)
			{
				_0023_003Dzb7SPTpc_003D[j] = array[j];
			}
		}
		return array;
	}

	public double[] _0023_003DzMSUJVwizKGcggd0NSj1eFPw_003D()
	{
		return _0023_003DzXrexKjY_003D;
	}

	public double[] _0023_003DzrXt1URSvg5rxV1xGbQMDOJ9FQx5AHP2h7A_003D_003D()
	{
		return _0023_003DzbfrNXYE_003D;
	}

	public double[,] _0023_003DziqPmecX6waT2d26HKbXnPEE_003D()
	{
		return _0023_003Dz61IPlm0_003D;
	}

	public double[,] _0023_003DzElfvLeQVY7Pc6NhP_0024e_3Ju4_003D()
	{
		if (_0023_003DzNRXx2Sbl68akfLirUA_003D_003D != null)
		{
			return _0023_003DzNRXx2Sbl68akfLirUA_003D_003D;
		}
		double[,] array = new double[_0023_003DzoMNiNRw_003D, _0023_003DzoMNiNRw_003D];
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			for (int j = 0; j < _0023_003DzoMNiNRw_003D; j++)
			{
				array[i, j] = 0.0;
			}
			array[i, i] = _0023_003DzXrexKjY_003D[i];
			if (_0023_003DzbfrNXYE_003D[i] > 0.0)
			{
				array[i, i + 1] = _0023_003DzbfrNXYE_003D[i];
			}
			else if (_0023_003DzbfrNXYE_003D[i] < 0.0)
			{
				array[i, i - 1] = _0023_003DzbfrNXYE_003D[i];
			}
		}
		return _0023_003DzNRXx2Sbl68akfLirUA_003D_003D = array;
	}

	private void _0023_003DzcnW7lq2r0cr9()
	{
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			_0023_003DzXrexKjY_003D[i] = _0023_003Dz61IPlm0_003D[_0023_003DzoMNiNRw_003D - 1, i];
		}
		for (int num = _0023_003DzoMNiNRw_003D - 1; num > 0; num--)
		{
			double num2 = 0.0;
			double num3 = 0.0;
			for (int j = 0; j < num; j++)
			{
				num2 += Math.Abs(_0023_003DzXrexKjY_003D[j]);
			}
			if (num2 == 0.0)
			{
				_0023_003DzbfrNXYE_003D[num] = _0023_003DzXrexKjY_003D[num - 1];
				for (int k = 0; k < num; k++)
				{
					_0023_003DzXrexKjY_003D[k] = _0023_003Dz61IPlm0_003D[num - 1, k];
					_0023_003Dz61IPlm0_003D[num, k] = 0.0;
					_0023_003Dz61IPlm0_003D[k, num] = 0.0;
				}
			}
			else
			{
				for (int l = 0; l < num; l++)
				{
					_0023_003DzXrexKjY_003D[l] /= num2;
					num3 += _0023_003DzXrexKjY_003D[l] * _0023_003DzXrexKjY_003D[l];
				}
				double num4 = _0023_003DzXrexKjY_003D[num - 1];
				double num5 = Math.Sqrt(num3);
				if (num4 > 0.0)
				{
					num5 = 0.0 - num5;
				}
				_0023_003DzbfrNXYE_003D[num] = num2 * num5;
				num3 -= num4 * num5;
				_0023_003DzXrexKjY_003D[num - 1] = num4 - num5;
				for (int m = 0; m < num; m++)
				{
					_0023_003DzbfrNXYE_003D[m] = 0.0;
				}
				for (int n = 0; n < num; n++)
				{
					num4 = _0023_003DzXrexKjY_003D[n];
					_0023_003Dz61IPlm0_003D[n, num] = num4;
					num5 = _0023_003DzbfrNXYE_003D[n] + _0023_003Dz61IPlm0_003D[n, n] * num4;
					for (int num6 = n + 1; num6 <= num - 1; num6++)
					{
						num5 += _0023_003Dz61IPlm0_003D[num6, n] * _0023_003DzXrexKjY_003D[num6];
						_0023_003DzbfrNXYE_003D[num6] += _0023_003Dz61IPlm0_003D[num6, n] * num4;
					}
					_0023_003DzbfrNXYE_003D[n] = num5;
				}
				num4 = 0.0;
				for (int num7 = 0; num7 < num; num7++)
				{
					_0023_003DzbfrNXYE_003D[num7] /= num3;
					num4 += _0023_003DzbfrNXYE_003D[num7] * _0023_003DzXrexKjY_003D[num7];
				}
				double num8 = num4 / (num3 + num3);
				for (int num9 = 0; num9 < num; num9++)
				{
					_0023_003DzbfrNXYE_003D[num9] -= num8 * _0023_003DzXrexKjY_003D[num9];
				}
				for (int num10 = 0; num10 < num; num10++)
				{
					num4 = _0023_003DzXrexKjY_003D[num10];
					num5 = _0023_003DzbfrNXYE_003D[num10];
					for (int num11 = num10; num11 <= num - 1; num11++)
					{
						_0023_003Dz61IPlm0_003D[num11, num10] -= num4 * _0023_003DzbfrNXYE_003D[num11] + num5 * _0023_003DzXrexKjY_003D[num11];
					}
					_0023_003DzXrexKjY_003D[num10] = _0023_003Dz61IPlm0_003D[num - 1, num10];
					_0023_003Dz61IPlm0_003D[num, num10] = 0.0;
				}
			}
			_0023_003DzXrexKjY_003D[num] = num3;
		}
		for (int num12 = 0; num12 < _0023_003DzoMNiNRw_003D - 1; num12++)
		{
			_0023_003Dz61IPlm0_003D[_0023_003DzoMNiNRw_003D - 1, num12] = _0023_003Dz61IPlm0_003D[num12, num12];
			_0023_003Dz61IPlm0_003D[num12, num12] = 1.0;
			double num13 = _0023_003DzXrexKjY_003D[num12 + 1];
			if (num13 != 0.0)
			{
				for (int num14 = 0; num14 <= num12; num14++)
				{
					_0023_003DzXrexKjY_003D[num14] = _0023_003Dz61IPlm0_003D[num14, num12 + 1] / num13;
				}
				for (int num15 = 0; num15 <= num12; num15++)
				{
					double num16 = 0.0;
					for (int num17 = 0; num17 <= num12; num17++)
					{
						num16 += _0023_003Dz61IPlm0_003D[num17, num12 + 1] * _0023_003Dz61IPlm0_003D[num17, num15];
					}
					for (int num18 = 0; num18 <= num12; num18++)
					{
						_0023_003Dz61IPlm0_003D[num18, num15] -= num16 * _0023_003DzXrexKjY_003D[num18];
					}
				}
			}
			for (int num19 = 0; num19 <= num12; num19++)
			{
				_0023_003Dz61IPlm0_003D[num19, num12 + 1] = 0.0;
			}
		}
		for (int num20 = 0; num20 < _0023_003DzoMNiNRw_003D; num20++)
		{
			_0023_003DzXrexKjY_003D[num20] = _0023_003Dz61IPlm0_003D[_0023_003DzoMNiNRw_003D - 1, num20];
			_0023_003Dz61IPlm0_003D[_0023_003DzoMNiNRw_003D - 1, num20] = 0.0;
		}
		_0023_003Dz61IPlm0_003D[_0023_003DzoMNiNRw_003D - 1, _0023_003DzoMNiNRw_003D - 1] = 1.0;
		_0023_003DzbfrNXYE_003D[0] = 0.0;
	}

	private double _0023_003DzQ1oMRv0FboHIWZ5MXQ_003D_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D)
	{
		double result = 0.0;
		double num = Math.Abs(_0023_003DzjbqS1qE_003D);
		double num2 = Math.Abs(_0023_003Dz1v6oPQk_003D);
		if (num > num2)
		{
			result = _0023_003Dz1v6oPQk_003D / _0023_003DzjbqS1qE_003D;
			result = num * Math.Sqrt(1.0 + result * result);
		}
		else if (_0023_003Dz1v6oPQk_003D != 0.0)
		{
			result = _0023_003DzjbqS1qE_003D / _0023_003Dz1v6oPQk_003D;
			result = num2 * Math.Sqrt(1.0 + result * result);
		}
		return result;
	}

	private void _0023_003DzBnxun8teKtYd()
	{
		for (int i = 1; i < _0023_003DzoMNiNRw_003D; i++)
		{
			_0023_003DzbfrNXYE_003D[i - 1] = _0023_003DzbfrNXYE_003D[i];
		}
		_0023_003DzbfrNXYE_003D[_0023_003DzoMNiNRw_003D - 1] = 0.0;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 2.220446049250313E-16;
		for (int j = 0; j < _0023_003DzoMNiNRw_003D; j++)
		{
			num2 = Math.Max(num2, Math.Abs(_0023_003DzXrexKjY_003D[j]) + Math.Abs(_0023_003DzbfrNXYE_003D[j]));
			int k;
			for (k = j; k < _0023_003DzoMNiNRw_003D && !(Math.Abs(_0023_003DzbfrNXYE_003D[k]) <= num3 * num2); k++)
			{
			}
			if (k > j)
			{
				int num4 = 0;
				do
				{
					num4++;
					double num5 = _0023_003DzXrexKjY_003D[j];
					double num6 = (_0023_003DzXrexKjY_003D[j + 1] - num5) / (2.0 * _0023_003DzbfrNXYE_003D[j]);
					double num7 = _0023_003DzQ1oMRv0FboHIWZ5MXQ_003D_003D(num6, 1.0);
					if (num6 < 0.0)
					{
						num7 = 0.0 - num7;
					}
					_0023_003DzXrexKjY_003D[j] = _0023_003DzbfrNXYE_003D[j] / (num6 + num7);
					_0023_003DzXrexKjY_003D[j + 1] = _0023_003DzbfrNXYE_003D[j] * (num6 + num7);
					double num8 = _0023_003DzXrexKjY_003D[j + 1];
					double num9 = num5 - _0023_003DzXrexKjY_003D[j];
					for (int l = j + 2; l < _0023_003DzoMNiNRw_003D; l++)
					{
						_0023_003DzXrexKjY_003D[l] -= num9;
					}
					num += num9;
					num6 = _0023_003DzXrexKjY_003D[k];
					double num10 = 1.0;
					double num11 = num10;
					double num12 = num10;
					double num13 = _0023_003DzbfrNXYE_003D[j + 1];
					double num14 = 0.0;
					double num15 = 0.0;
					for (int num16 = k - 1; num16 >= j; num16--)
					{
						num12 = num11;
						num11 = num10;
						num15 = num14;
						num5 = num10 * _0023_003DzbfrNXYE_003D[num16];
						num9 = num10 * num6;
						num7 = _0023_003DzQ1oMRv0FboHIWZ5MXQ_003D_003D(num6, _0023_003DzbfrNXYE_003D[num16]);
						_0023_003DzbfrNXYE_003D[num16 + 1] = num14 * num7;
						num14 = _0023_003DzbfrNXYE_003D[num16] / num7;
						num10 = num6 / num7;
						num6 = num10 * _0023_003DzXrexKjY_003D[num16] - num14 * num5;
						_0023_003DzXrexKjY_003D[num16 + 1] = num9 + num14 * (num10 * num5 + num14 * _0023_003DzXrexKjY_003D[num16]);
						for (int m = 0; m < _0023_003DzoMNiNRw_003D; m++)
						{
							num9 = _0023_003Dz61IPlm0_003D[m, num16 + 1];
							_0023_003Dz61IPlm0_003D[m, num16 + 1] = num14 * _0023_003Dz61IPlm0_003D[m, num16] + num10 * num9;
							_0023_003Dz61IPlm0_003D[m, num16] = num10 * _0023_003Dz61IPlm0_003D[m, num16] - num14 * num9;
						}
					}
					num6 = (0.0 - num14) * num15 * num12 * num13 * _0023_003DzbfrNXYE_003D[j] / num8;
					_0023_003DzbfrNXYE_003D[j] = num14 * num6;
					_0023_003DzXrexKjY_003D[j] = num10 * num6;
				}
				while (Math.Abs(_0023_003DzbfrNXYE_003D[j]) > num3 * num2);
			}
			_0023_003DzXrexKjY_003D[j] += num;
			_0023_003DzbfrNXYE_003D[j] = 0.0;
		}
		for (int n = 0; n < _0023_003DzoMNiNRw_003D - 1; n++)
		{
			int num17 = n;
			double num18 = _0023_003DzXrexKjY_003D[n];
			for (int num19 = n + 1; num19 < _0023_003DzoMNiNRw_003D; num19++)
			{
				if (_0023_003DzXrexKjY_003D[num19] < num18)
				{
					num17 = num19;
					num18 = _0023_003DzXrexKjY_003D[num19];
				}
			}
			if (num17 != n)
			{
				_0023_003DzXrexKjY_003D[num17] = _0023_003DzXrexKjY_003D[n];
				_0023_003DzXrexKjY_003D[n] = num18;
				for (int num20 = 0; num20 < _0023_003DzoMNiNRw_003D; num20++)
				{
					num18 = _0023_003Dz61IPlm0_003D[num20, n];
					_0023_003Dz61IPlm0_003D[num20, n] = _0023_003Dz61IPlm0_003D[num20, num17];
					_0023_003Dz61IPlm0_003D[num20, num17] = num18;
				}
			}
		}
	}

	private void _0023_003Dz78XmYKQG618V()
	{
		int num = 0;
		int num2 = _0023_003DzoMNiNRw_003D - 1;
		for (int i = num + 1; i <= num2 - 1; i++)
		{
			double num3 = 0.0;
			for (int j = i; j <= num2; j++)
			{
				num3 += Math.Abs(_0023_003DzNDN2q2o_003D[j, i - 1]);
			}
			if (num3 == 0.0)
			{
				continue;
			}
			double num4 = 0.0;
			for (int num5 = num2; num5 >= i; num5--)
			{
				_0023_003Dz6GIylvE_003D[num5] = _0023_003DzNDN2q2o_003D[num5, i - 1] / num3;
				num4 += _0023_003Dz6GIylvE_003D[num5] * _0023_003Dz6GIylvE_003D[num5];
			}
			double num6 = Math.Sqrt(num4);
			if (_0023_003Dz6GIylvE_003D[i] > 0.0)
			{
				num6 = 0.0 - num6;
			}
			num4 -= _0023_003Dz6GIylvE_003D[i] * num6;
			_0023_003Dz6GIylvE_003D[i] -= num6;
			for (int k = i; k < _0023_003DzoMNiNRw_003D; k++)
			{
				double num7 = 0.0;
				for (int num8 = num2; num8 >= i; num8--)
				{
					num7 += _0023_003Dz6GIylvE_003D[num8] * _0023_003DzNDN2q2o_003D[num8, k];
				}
				num7 /= num4;
				for (int l = i; l <= num2; l++)
				{
					_0023_003DzNDN2q2o_003D[l, k] -= num7 * _0023_003Dz6GIylvE_003D[l];
				}
			}
			for (int m = 0; m <= num2; m++)
			{
				double num9 = 0.0;
				for (int num10 = num2; num10 >= i; num10--)
				{
					num9 += _0023_003Dz6GIylvE_003D[num10] * _0023_003DzNDN2q2o_003D[m, num10];
				}
				num9 /= num4;
				for (int n = i; n <= num2; n++)
				{
					_0023_003DzNDN2q2o_003D[m, n] -= num9 * _0023_003Dz6GIylvE_003D[n];
				}
			}
			_0023_003Dz6GIylvE_003D[i] = num3 * _0023_003Dz6GIylvE_003D[i];
			_0023_003DzNDN2q2o_003D[i, i - 1] = num3 * num6;
		}
		for (int num11 = 0; num11 < _0023_003DzoMNiNRw_003D; num11++)
		{
			for (int num12 = 0; num12 < _0023_003DzoMNiNRw_003D; num12++)
			{
				_0023_003Dz61IPlm0_003D[num11, num12] = ((num11 == num12) ? 1 : 0);
			}
		}
		for (int num13 = num2 - 1; num13 >= num + 1; num13--)
		{
			if (_0023_003DzNDN2q2o_003D[num13, num13 - 1] != 0.0)
			{
				for (int num14 = num13 + 1; num14 <= num2; num14++)
				{
					_0023_003Dz6GIylvE_003D[num14] = _0023_003DzNDN2q2o_003D[num14, num13 - 1];
				}
				for (int num15 = num13; num15 <= num2; num15++)
				{
					double num16 = 0.0;
					for (int num17 = num13; num17 <= num2; num17++)
					{
						num16 += _0023_003Dz6GIylvE_003D[num17] * _0023_003Dz61IPlm0_003D[num17, num15];
					}
					num16 = num16 / _0023_003Dz6GIylvE_003D[num13] / _0023_003DzNDN2q2o_003D[num13, num13 - 1];
					for (int num18 = num13; num18 <= num2; num18++)
					{
						_0023_003Dz61IPlm0_003D[num18, num15] += num16 * _0023_003Dz6GIylvE_003D[num18];
					}
				}
			}
		}
	}

	private static void _0023_003Dzw9_0024_EJNx1dfS(double _0023_003Dzn6XKGHw_003D, double _0023_003DzghVYKJ4_003D, double _0023_003DzxZ8FyFw_003D, double _0023_003DzL30XLe0_003D, out double _0023_003DzSigQypHed5Fj, out double _0023_003DzQeq_JrbgU0CE)
	{
		if (Math.Abs(_0023_003DzxZ8FyFw_003D) > Math.Abs(_0023_003DzL30XLe0_003D))
		{
			double num = _0023_003DzL30XLe0_003D / _0023_003DzxZ8FyFw_003D;
			double num2 = _0023_003DzxZ8FyFw_003D + num * _0023_003DzL30XLe0_003D;
			_0023_003DzSigQypHed5Fj = (_0023_003Dzn6XKGHw_003D + num * _0023_003DzghVYKJ4_003D) / num2;
			_0023_003DzQeq_JrbgU0CE = (_0023_003DzghVYKJ4_003D - num * _0023_003Dzn6XKGHw_003D) / num2;
		}
		else
		{
			double num = _0023_003DzxZ8FyFw_003D / _0023_003DzL30XLe0_003D;
			double num2 = _0023_003DzL30XLe0_003D + num * _0023_003DzxZ8FyFw_003D;
			_0023_003DzSigQypHed5Fj = (num * _0023_003Dzn6XKGHw_003D + _0023_003DzghVYKJ4_003D) / num2;
			_0023_003DzQeq_JrbgU0CE = (num * _0023_003DzghVYKJ4_003D - _0023_003Dzn6XKGHw_003D) / num2;
		}
	}

	private void _0023_003Dz9I9tKu8yL4FQ()
	{
		int num = _0023_003DzoMNiNRw_003D;
		int num2 = num - 1;
		int num3 = 0;
		int num4 = num - 1;
		double num5 = 2.220446049250313E-16;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		for (int i = 0; i < num; i++)
		{
			if (i < num3 || i > num4)
			{
				_0023_003DzXrexKjY_003D[i] = _0023_003DzNDN2q2o_003D[i, i];
				_0023_003DzbfrNXYE_003D[i] = 0.0;
			}
			for (int j = Math.Max(i - 1, 0); j < num; j++)
			{
				num12 += Math.Abs(_0023_003DzNDN2q2o_003D[i, j]);
			}
		}
		int num13 = 0;
		while (num2 >= num3)
		{
			int num14;
			for (num14 = num2; num14 > num3; num14--)
			{
				num10 = Math.Abs(_0023_003DzNDN2q2o_003D[num14 - 1, num14 - 1]) + Math.Abs(_0023_003DzNDN2q2o_003D[num14, num14]);
				if (num10 == 0.0)
				{
					num10 = num12;
				}
				if (double.IsNaN(num10) || Math.Abs(_0023_003DzNDN2q2o_003D[num14, num14 - 1]) < num5 * num10)
				{
					break;
				}
			}
			if (num14 == num2)
			{
				_0023_003DzNDN2q2o_003D[num2, num2] += num6;
				_0023_003DzXrexKjY_003D[num2] = _0023_003DzNDN2q2o_003D[num2, num2];
				_0023_003DzbfrNXYE_003D[num2] = 0.0;
				num2--;
				num13 = 0;
				continue;
			}
			double num16;
			double num15;
			if (num14 == num2 - 1)
			{
				num15 = _0023_003DzNDN2q2o_003D[num2, num2 - 1] * _0023_003DzNDN2q2o_003D[num2 - 1, num2];
				num7 = (_0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1] - _0023_003DzNDN2q2o_003D[num2, num2]) / 2.0;
				num8 = num7 * num7 + num15;
				num11 = Math.Sqrt(Math.Abs(num8));
				_0023_003DzNDN2q2o_003D[num2, num2] += num6;
				_0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1] = _0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1] + num6;
				num16 = _0023_003DzNDN2q2o_003D[num2, num2];
				if (num8 >= 0.0)
				{
					num11 = ((num7 >= 0.0) ? (num7 + num11) : (num7 - num11));
					_0023_003DzXrexKjY_003D[num2 - 1] = num16 + num11;
					_0023_003DzXrexKjY_003D[num2] = _0023_003DzXrexKjY_003D[num2 - 1];
					if (num11 != 0.0)
					{
						_0023_003DzXrexKjY_003D[num2] = num16 - num15 / num11;
					}
					_0023_003DzbfrNXYE_003D[num2 - 1] = 0.0;
					_0023_003DzbfrNXYE_003D[num2] = 0.0;
					num16 = _0023_003DzNDN2q2o_003D[num2, num2 - 1];
					num10 = Math.Abs(num16) + Math.Abs(num11);
					num7 = num16 / num10;
					num8 = num11 / num10;
					num9 = Math.Sqrt(num7 * num7 + num8 * num8);
					num7 /= num9;
					num8 /= num9;
					for (int k = num2 - 1; k < num; k++)
					{
						num11 = _0023_003DzNDN2q2o_003D[num2 - 1, k];
						_0023_003DzNDN2q2o_003D[num2 - 1, k] = num8 * num11 + num7 * _0023_003DzNDN2q2o_003D[num2, k];
						_0023_003DzNDN2q2o_003D[num2, k] = num8 * _0023_003DzNDN2q2o_003D[num2, k] - num7 * num11;
					}
					for (int l = 0; l <= num2; l++)
					{
						num11 = _0023_003DzNDN2q2o_003D[l, num2 - 1];
						_0023_003DzNDN2q2o_003D[l, num2 - 1] = num8 * num11 + num7 * _0023_003DzNDN2q2o_003D[l, num2];
						_0023_003DzNDN2q2o_003D[l, num2] = num8 * _0023_003DzNDN2q2o_003D[l, num2] - num7 * num11;
					}
					for (int m = num3; m <= num4; m++)
					{
						num11 = _0023_003Dz61IPlm0_003D[m, num2 - 1];
						_0023_003Dz61IPlm0_003D[m, num2 - 1] = num8 * num11 + num7 * _0023_003Dz61IPlm0_003D[m, num2];
						_0023_003Dz61IPlm0_003D[m, num2] = num8 * _0023_003Dz61IPlm0_003D[m, num2] - num7 * num11;
					}
				}
				else
				{
					_0023_003DzXrexKjY_003D[num2 - 1] = num16 + num7;
					_0023_003DzXrexKjY_003D[num2] = num16 + num7;
					_0023_003DzbfrNXYE_003D[num2 - 1] = num11;
					_0023_003DzbfrNXYE_003D[num2] = 0.0 - num11;
				}
				num2 -= 2;
				num13 = 0;
				continue;
			}
			num16 = _0023_003DzNDN2q2o_003D[num2, num2];
			double num17 = 0.0;
			num15 = 0.0;
			if (num14 < num2)
			{
				num17 = _0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1];
				num15 = _0023_003DzNDN2q2o_003D[num2, num2 - 1] * _0023_003DzNDN2q2o_003D[num2 - 1, num2];
			}
			if (num13 == 10)
			{
				num6 += num16;
				for (int n = num3; n <= num2; n++)
				{
					_0023_003DzNDN2q2o_003D[n, n] -= num16;
				}
				num10 = Math.Abs(_0023_003DzNDN2q2o_003D[num2, num2 - 1]) + Math.Abs(_0023_003DzNDN2q2o_003D[num2 - 1, num2 - 2]);
				num16 = (num17 = 0.75 * num10);
				num15 = -0.4375 * num10 * num10;
			}
			if (num13 == 30)
			{
				num10 = (num17 - num16) / 2.0;
				num10 = num10 * num10 + num15;
				if (num10 > 0.0)
				{
					num10 = Math.Sqrt(num10);
					if (num17 < num16)
					{
						num10 = 0.0 - num10;
					}
					num10 = num16 - num15 / ((num17 - num16) / 2.0 + num10);
					for (int num18 = num3; num18 <= num2; num18++)
					{
						_0023_003DzNDN2q2o_003D[num18, num18] -= num10;
					}
					num6 += num10;
					num16 = (num17 = (num15 = 0.964));
				}
			}
			num13++;
			int num19;
			for (num19 = num2 - 2; num19 >= num14; num19--)
			{
				num11 = _0023_003DzNDN2q2o_003D[num19, num19];
				num9 = num16 - num11;
				num10 = num17 - num11;
				num7 = (num9 * num10 - num15) / _0023_003DzNDN2q2o_003D[num19 + 1, num19] + _0023_003DzNDN2q2o_003D[num19, num19 + 1];
				num8 = _0023_003DzNDN2q2o_003D[num19 + 1, num19 + 1] - num11 - num9 - num10;
				num9 = _0023_003DzNDN2q2o_003D[num19 + 2, num19 + 1];
				num10 = Math.Abs(num7) + Math.Abs(num8) + Math.Abs(num9);
				num7 /= num10;
				num8 /= num10;
				num9 /= num10;
				if (num19 == num14 || Math.Abs(_0023_003DzNDN2q2o_003D[num19, num19 - 1]) * (Math.Abs(num8) + Math.Abs(num9)) < num5 * (Math.Abs(num7) * (Math.Abs(_0023_003DzNDN2q2o_003D[num19 - 1, num19 - 1]) + Math.Abs(num11) + Math.Abs(_0023_003DzNDN2q2o_003D[num19 + 1, num19 + 1]))))
				{
					break;
				}
			}
			for (int num20 = num19 + 2; num20 <= num2; num20++)
			{
				_0023_003DzNDN2q2o_003D[num20, num20 - 2] = 0.0;
				if (num20 > num19 + 2)
				{
					_0023_003DzNDN2q2o_003D[num20, num20 - 3] = 0.0;
				}
			}
			for (int num21 = num19; num21 <= num2 - 1; num21++)
			{
				bool flag = num21 != num2 - 1;
				if (num21 != num19)
				{
					num7 = _0023_003DzNDN2q2o_003D[num21, num21 - 1];
					num8 = _0023_003DzNDN2q2o_003D[num21 + 1, num21 - 1];
					num9 = (flag ? _0023_003DzNDN2q2o_003D[num21 + 2, num21 - 1] : 0.0);
					num16 = Math.Abs(num7) + Math.Abs(num8) + Math.Abs(num9);
					if (num16 != 0.0)
					{
						num7 /= num16;
						num8 /= num16;
						num9 /= num16;
					}
				}
				if (num16 == 0.0)
				{
					break;
				}
				num10 = Math.Sqrt(num7 * num7 + num8 * num8 + num9 * num9);
				if (num7 < 0.0)
				{
					num10 = 0.0 - num10;
				}
				if (num10 == 0.0)
				{
					continue;
				}
				if (num21 != num19)
				{
					_0023_003DzNDN2q2o_003D[num21, num21 - 1] = (0.0 - num10) * num16;
				}
				else if (num14 != num19)
				{
					_0023_003DzNDN2q2o_003D[num21, num21 - 1] = 0.0 - _0023_003DzNDN2q2o_003D[num21, num21 - 1];
				}
				num7 += num10;
				num16 = num7 / num10;
				num17 = num8 / num10;
				num11 = num9 / num10;
				num8 /= num7;
				num9 /= num7;
				for (int num22 = num21; num22 < num; num22++)
				{
					num7 = _0023_003DzNDN2q2o_003D[num21, num22] + num8 * _0023_003DzNDN2q2o_003D[num21 + 1, num22];
					if (flag)
					{
						num7 += num9 * _0023_003DzNDN2q2o_003D[num21 + 2, num22];
						_0023_003DzNDN2q2o_003D[num21 + 2, num22] = _0023_003DzNDN2q2o_003D[num21 + 2, num22] - num7 * num11;
					}
					_0023_003DzNDN2q2o_003D[num21, num22] -= num7 * num16;
					_0023_003DzNDN2q2o_003D[num21 + 1, num22] = _0023_003DzNDN2q2o_003D[num21 + 1, num22] - num7 * num17;
				}
				for (int num23 = 0; num23 <= Math.Min(num2, num21 + 3); num23++)
				{
					num7 = num16 * _0023_003DzNDN2q2o_003D[num23, num21] + num17 * _0023_003DzNDN2q2o_003D[num23, num21 + 1];
					if (flag)
					{
						num7 += num11 * _0023_003DzNDN2q2o_003D[num23, num21 + 2];
						_0023_003DzNDN2q2o_003D[num23, num21 + 2] = _0023_003DzNDN2q2o_003D[num23, num21 + 2] - num7 * num9;
					}
					_0023_003DzNDN2q2o_003D[num23, num21] -= num7;
					_0023_003DzNDN2q2o_003D[num23, num21 + 1] = _0023_003DzNDN2q2o_003D[num23, num21 + 1] - num7 * num8;
				}
				for (int num24 = num3; num24 <= num4; num24++)
				{
					num7 = num16 * _0023_003Dz61IPlm0_003D[num24, num21] + num17 * _0023_003Dz61IPlm0_003D[num24, num21 + 1];
					if (flag)
					{
						num7 += num11 * _0023_003Dz61IPlm0_003D[num24, num21 + 2];
						_0023_003Dz61IPlm0_003D[num24, num21 + 2] = _0023_003Dz61IPlm0_003D[num24, num21 + 2] - num7 * num9;
					}
					_0023_003Dz61IPlm0_003D[num24, num21] -= num7;
					_0023_003Dz61IPlm0_003D[num24, num21 + 1] = _0023_003Dz61IPlm0_003D[num24, num21 + 1] - num7 * num8;
				}
			}
		}
		if (num12 == 0.0)
		{
			return;
		}
		for (num2 = num - 1; num2 >= 0; num2--)
		{
			num7 = _0023_003DzXrexKjY_003D[num2];
			num8 = _0023_003DzbfrNXYE_003D[num2];
			if (num8 == 0.0)
			{
				int num25 = num2;
				_0023_003DzNDN2q2o_003D[num2, num2] = 1.0;
				for (int num26 = num2 - 1; num26 >= 0; num26--)
				{
					double num15 = _0023_003DzNDN2q2o_003D[num26, num26] - num7;
					num9 = 0.0;
					for (int num27 = num25; num27 <= num2; num27++)
					{
						num9 += _0023_003DzNDN2q2o_003D[num26, num27] * _0023_003DzNDN2q2o_003D[num27, num2];
					}
					if (_0023_003DzbfrNXYE_003D[num26] < 0.0)
					{
						num11 = num15;
						num10 = num9;
					}
					else
					{
						num25 = num26;
						double num28;
						if (_0023_003DzbfrNXYE_003D[num26] == 0.0)
						{
							_0023_003DzNDN2q2o_003D[num26, num2] = ((num15 != 0.0) ? ((0.0 - num9) / num15) : ((0.0 - num9) / (num5 * num12)));
						}
						else
						{
							double num16 = _0023_003DzNDN2q2o_003D[num26, num26 + 1];
							double num17 = _0023_003DzNDN2q2o_003D[num26 + 1, num26];
							num8 = (_0023_003DzXrexKjY_003D[num26] - num7) * (_0023_003DzXrexKjY_003D[num26] - num7) + _0023_003DzbfrNXYE_003D[num26] * _0023_003DzbfrNXYE_003D[num26];
							num28 = (num16 * num10 - num11 * num9) / num8;
							_0023_003DzNDN2q2o_003D[num26, num2] = num28;
							_0023_003DzNDN2q2o_003D[num26 + 1, num2] = ((Math.Abs(num16) > Math.Abs(num11)) ? ((0.0 - num9 - num15 * num28) / num16) : ((0.0 - num10 - num17 * num28) / num11));
						}
						num28 = Math.Abs(_0023_003DzNDN2q2o_003D[num26, num2]);
						if (num5 * num28 * num28 > 1.0)
						{
							for (int num29 = num26; num29 <= num2; num29++)
							{
								_0023_003DzNDN2q2o_003D[num29, num2] /= num28;
							}
						}
					}
				}
			}
			else if (num8 < 0.0)
			{
				int num30 = num2 - 1;
				if (Math.Abs(_0023_003DzNDN2q2o_003D[num2, num2 - 1]) > Math.Abs(_0023_003DzNDN2q2o_003D[num2 - 1, num2]))
				{
					_0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1] = num8 / _0023_003DzNDN2q2o_003D[num2, num2 - 1];
					_0023_003DzNDN2q2o_003D[num2 - 1, num2] = (0.0 - (_0023_003DzNDN2q2o_003D[num2, num2] - num7)) / _0023_003DzNDN2q2o_003D[num2, num2 - 1];
				}
				else
				{
					_0023_003Dzw9_0024_EJNx1dfS(0.0, 0.0 - _0023_003DzNDN2q2o_003D[num2 - 1, num2], _0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1] - num7, num8, out _0023_003DzNDN2q2o_003D[num2 - 1, num2 - 1], out _0023_003DzNDN2q2o_003D[num2 - 1, num2]);
				}
				_0023_003DzNDN2q2o_003D[num2, num2 - 1] = 0.0;
				_0023_003DzNDN2q2o_003D[num2, num2] = 1.0;
				for (int num31 = num2 - 2; num31 >= 0; num31--)
				{
					double num32 = 0.0;
					double num33 = 0.0;
					for (int num34 = num30; num34 <= num2; num34++)
					{
						num32 += _0023_003DzNDN2q2o_003D[num31, num34] * _0023_003DzNDN2q2o_003D[num34, num2 - 1];
						num33 += _0023_003DzNDN2q2o_003D[num31, num34] * _0023_003DzNDN2q2o_003D[num34, num2];
					}
					double num15 = _0023_003DzNDN2q2o_003D[num31, num31] - num7;
					if (_0023_003DzbfrNXYE_003D[num31] < 0.0)
					{
						num11 = num15;
						num9 = num32;
						num10 = num33;
					}
					else
					{
						num30 = num31;
						if (_0023_003DzbfrNXYE_003D[num31] == 0.0)
						{
							_0023_003Dzw9_0024_EJNx1dfS(0.0 - num32, 0.0 - num33, num15, num8, out _0023_003DzNDN2q2o_003D[num31, num2 - 1], out _0023_003DzNDN2q2o_003D[num31, num2]);
						}
						else
						{
							double num16 = _0023_003DzNDN2q2o_003D[num31, num31 + 1];
							double num17 = _0023_003DzNDN2q2o_003D[num31 + 1, num31];
							double num35 = (_0023_003DzXrexKjY_003D[num31] - num7) * (_0023_003DzXrexKjY_003D[num31] - num7) + _0023_003DzbfrNXYE_003D[num31] * _0023_003DzbfrNXYE_003D[num31] - num8 * num8;
							double num36 = (_0023_003DzXrexKjY_003D[num31] - num7) * 2.0 * num8;
							if (num35 == 0.0 && num36 == 0.0)
							{
								num35 = num5 * num12 * (Math.Abs(num15) + Math.Abs(num8) + Math.Abs(num16) + Math.Abs(num17) + Math.Abs(num11));
							}
							_0023_003Dzw9_0024_EJNx1dfS(num16 * num9 - num11 * num32 + num8 * num33, num16 * num10 - num11 * num33 - num8 * num32, num35, num36, out _0023_003DzNDN2q2o_003D[num31, num2 - 1], out _0023_003DzNDN2q2o_003D[num31, num2]);
							if (Math.Abs(num16) > Math.Abs(num11) + Math.Abs(num8))
							{
								_0023_003DzNDN2q2o_003D[num31 + 1, num2 - 1] = (0.0 - num32 - num15 * _0023_003DzNDN2q2o_003D[num31, num2 - 1] + num8 * _0023_003DzNDN2q2o_003D[num31, num2]) / num16;
								_0023_003DzNDN2q2o_003D[num31 + 1, num2] = (0.0 - num33 - num15 * _0023_003DzNDN2q2o_003D[num31, num2] - num8 * _0023_003DzNDN2q2o_003D[num31, num2 - 1]) / num16;
							}
							else
							{
								_0023_003Dzw9_0024_EJNx1dfS(0.0 - num9 - num17 * _0023_003DzNDN2q2o_003D[num31, num2 - 1], 0.0 - num10 - num17 * _0023_003DzNDN2q2o_003D[num31, num2], num11, num8, out _0023_003DzNDN2q2o_003D[num31 + 1, num2 - 1], out _0023_003DzNDN2q2o_003D[num31 + 1, num2]);
							}
						}
						double num28 = Math.Max(Math.Abs(_0023_003DzNDN2q2o_003D[num31, num2 - 1]), Math.Abs(_0023_003DzNDN2q2o_003D[num31, num2]));
						if (num5 * num28 * num28 > 1.0)
						{
							for (int num37 = num31; num37 <= num2; num37++)
							{
								_0023_003DzNDN2q2o_003D[num37, num2 - 1] = _0023_003DzNDN2q2o_003D[num37, num2 - 1] / num28;
								_0023_003DzNDN2q2o_003D[num37, num2] /= num28;
							}
						}
					}
				}
			}
		}
		for (int num38 = 0; num38 < num; num38++)
		{
			if (num38 < num3 || num38 > num4)
			{
				for (int num39 = num38; num39 < num; num39++)
				{
					_0023_003Dz61IPlm0_003D[num38, num39] = _0023_003DzNDN2q2o_003D[num38, num39];
				}
			}
		}
		for (int num40 = num - 1; num40 >= num3; num40--)
		{
			for (int num41 = num3; num41 <= num4; num41++)
			{
				num11 = 0.0;
				for (int num42 = num3; num42 <= Math.Min(num40, num4); num42++)
				{
					num11 += _0023_003Dz61IPlm0_003D[num41, num42] * _0023_003DzNDN2q2o_003D[num42, num40];
				}
				_0023_003Dz61IPlm0_003D[num41, num40] = num11;
			}
		}
	}

	public object Clone()
	{
		return new _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz
		{
			_0023_003DzXrexKjY_003D = (double[])_0023_003DzXrexKjY_003D.Clone(),
			_0023_003DzbfrNXYE_003D = (double[])_0023_003DzbfrNXYE_003D.Clone(),
			_0023_003DzNDN2q2o_003D = (double[,])_0023_003DzNDN2q2o_003D.Clone(),
			_0023_003DzoMNiNRw_003D = _0023_003DzoMNiNRw_003D,
			_0023_003Dz6GIylvE_003D = _0023_003Dz6GIylvE_003D,
			_0023_003DzOyStcKQz5pzWLxDKuA_003D_003D = _0023_003DzOyStcKQz5pzWLxDKuA_003D_003D,
			_0023_003Dz61IPlm0_003D = (double[,])_0023_003Dz61IPlm0_003D.Clone()
		};
	}

	private int _0023_003DzDS1t_pKZ5L_0024cEiADHOt89vw_003D(int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D)
	{
		if (Math.Abs(_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D]) == Math.Abs(_0023_003DzXrexKjY_003D[_0023_003DzTSeNR8Q_003D]))
		{
			return -Math.Abs(_0023_003DzbfrNXYE_003D[_0023_003Dz437_00244ak_003D]).CompareTo(Math.Abs(_0023_003DzbfrNXYE_003D[_0023_003DzTSeNR8Q_003D]));
		}
		return -Math.Abs(_0023_003DzXrexKjY_003D[_0023_003Dz437_00244ak_003D]).CompareTo(Math.Abs(_0023_003DzXrexKjY_003D[_0023_003DzTSeNR8Q_003D]));
	}
}
