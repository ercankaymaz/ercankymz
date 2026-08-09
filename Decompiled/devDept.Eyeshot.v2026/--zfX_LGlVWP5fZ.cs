using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

internal static class _0023_003DzfX_LGlVWP5fZ
{
	private struct _0023_003DzLCwSkuY_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal byte _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal byte _0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal bool _0023_003Dz5c1WpgJ9cnNwCb1nD_0024CWgTR87wBp;
	}

	private sealed class _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D
	{
		public byte _0023_003DzfNi7d4A_003D;

		public _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzfaEGzjs_003D;

		public _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzuZGRsz8_003D;

		public int _0023_003Dz736ekIs_003D;

		public int[] _0023_003DznAsnXqw_003D;

		public byte[] _0023_003DzTLd6lkE_003D;

		public byte[] _0023_003Dz0BImzjYMysCp;

		public _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D(byte _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D, List<int> _0023_003Dz4oTePWQb6l93, byte[] _0023_003DzTLd6lkE_003D, byte[] _0023_003Dzok56giLKxWwG)
		{
			this._0023_003Dzn22dx3GkUy5cTbIo9jamiI8_003D(_0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D, _0023_003Dz4oTePWQb6l93, _0023_003DzTLd6lkE_003D, _0023_003Dzok56giLKxWwG);
		}
	}

	public static string _0023_003DzNzMWwTmGe_0024Sn(string _0023_003Dz0EsKsC8_003D, bool _0023_003DzC0qH2wc_003D, int[] _0023_003Dzj0gAoj9FajAy)
	{
		int length = _0023_003Dz0EsKsC8_003D.Length;
		byte[] _0023_003DzbcDOgZU_003D = new byte[_0023_003Dz0EsKsC8_003D.Length];
		byte[] _0023_003Dzok56giLKxWwG = new byte[_0023_003Dz0EsKsC8_003D.Length];
		_0023_003DzFvUXTz_6ID6Z(_0023_003Dz0EsKsC8_003D, ref _0023_003DzbcDOgZU_003D);
		_0023_003Dz8ExEqb48Q2c6(_0023_003DzbcDOgZU_003D, out var _0023_003Dz6wpznLAc243i, out var _0023_003DzKrDS3GngDPVRlzNGIIGd2GA_003D);
		byte b = (_0023_003DzC0qH2wc_003D ? ((byte)1) : ((byte)0));
		_0023_003DzsDgDEoE_003D(ref _0023_003Dzok56giLKxWwG, b);
		_0023_003DzzLUUrN8upLgJ(b, _0023_003DzbcDOgZU_003D, ref _0023_003Dzok56giLKxWwG, _0023_003Dz6wpznLAc243i);
		_0023_003DzXyklhIgB70oC(ref _0023_003DzbcDOgZU_003D);
		List<List<int>> list = _0023_003Dz2byrmSjF38d2(_0023_003Dzok56giLKxWwG);
		_ = list.Count;
		int[] _0023_003DzCpM1EpUyTF_S = _0023_003DzyhfTS8E0nDL6(list, length);
		foreach (_0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D item in _0023_003DzeN33MdYhs3CuAoBPBSwOdvk_003D(b, _0023_003DzbcDOgZU_003D, _0023_003Dzok56giLKxWwG, list, _0023_003DzKrDS3GngDPVRlzNGIIGd2GA_003D, _0023_003Dz6wpznLAc243i, _0023_003DzCpM1EpUyTF_S))
		{
			item._0023_003Dzk_0024VkoJFYsLOb();
			item._0023_003Dz_UpA7MSqRfpD29GnJw_003D_003D();
			item._0023_003Dz7npafs_syBj9();
			item._0023_003DzUhr0c767OYVh(ref _0023_003DzbcDOgZU_003D, ref _0023_003Dzok56giLKxWwG);
		}
		int[] _0023_003Dzj0gAoj9FajAy2 = ((_0023_003Dzj0gAoj9FajAy != null) ? _0023_003Dzj0gAoj9FajAy : new int[1] { _0023_003DzbcDOgZU_003D.Length });
		int[] _0023_003DzZ2AJhLg_003D = _0023_003DzeVlEkt7P25bn(b, _0023_003DzbcDOgZU_003D, _0023_003Dzok56giLKxWwG, _0023_003Dzj0gAoj9FajAy2);
		return _0023_003Dz024SL4JmtVns(_0023_003Dz0EsKsC8_003D, _0023_003DzZ2AJhLg_003D);
	}

	private static void _0023_003DzFvUXTz_6ID6Z(string _0023_003DzwyYng5o_003D, ref byte[] _0023_003DzbcDOgZU_003D)
	{
		_0023_003DzbcDOgZU_003D = new byte[_0023_003DzwyYng5o_003D.Length];
		for (int i = 0; i < _0023_003DzwyYng5o_003D.Length; i++)
		{
			int num = Convert.ToInt32(_0023_003DzwyYng5o_003D[i]);
			_0023_003DzbcDOgZU_003D[i] = _0023_003DzJgZlsQDwcXDryY2X3A_003D_003D._0023_003Dzn5UvmBNMUw2p[num];
		}
	}

	private static byte _0023_003Dzpujhqoxvkagi(byte[] _0023_003DzTLd6lkE_003D, int[] _0023_003DzGc6Z3t056buA, int _0023_003DznwkJBW4_003D, int _0023_003Dzj8RyfSk_003D)
	{
		int num = ((_0023_003DznwkJBW4_003D != -1) ? _0023_003DznwkJBW4_003D : 0);
		int num2 = ((_0023_003Dzj8RyfSk_003D != -1) ? _0023_003Dzj8RyfSk_003D : _0023_003DzTLd6lkE_003D.Length);
		for (int i = num; i < num2; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzTLd6lkE_003D[i];
			switch (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2)
			{
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)4:
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0)
				{
					return 0;
				}
				return 1;
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21:
				i = _0023_003DzGc6Z3t056buA[i];
				break;
			}
		}
		return 0;
	}

	private static void _0023_003DzzLUUrN8upLgJ(byte _0023_003DzfNi7d4A_003D, byte[] _0023_003DzTLd6lkE_003D, ref byte[] _0023_003Dzok56giLKxWwG, int[] _0023_003DzGc6Z3t056buA)
	{
		Stack<_0023_003DzLCwSkuY_003D> stack = new Stack<_0023_003DzLCwSkuY_003D>(127);
		_0023_003DzLCwSkuY_003D item = new _0023_003DzLCwSkuY_003D
		{
			_0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D = _0023_003DzfNi7d4A_003D,
			_0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D = 18,
			_0023_003Dz5c1WpgJ9cnNwCb1nD_0024CWgTR87wBp = false
		};
		stack.Push(item);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003DzTLd6lkE_003D.Length; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzTLd6lkE_003D[i];
			switch (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2)
			{
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)1:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)2:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)5:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)6:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20:
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21:
			{
				bool flag = _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19;
				if (flag)
				{
					_0023_003Dzok56giLKxWwG[i] = stack.Peek()._0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
				}
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21)
				{
					_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = ((_0023_003Dzpujhqoxvkagi(_0023_003DzTLd6lkE_003D, _0023_003DzGc6Z3t056buA, i + 1, _0023_003DzGc6Z3t056buA[i]) == 1) ? ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20) : ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19));
				}
				byte b = ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)5 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)6 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20) ? ((byte)_0023_003Dz8FVCzsQa01Lx(stack.Peek()._0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D)) : ((byte)_0023_003Dz_0024nxsOfnpglkJ(stack.Peek()._0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D)));
				if (b <= 125 && num == 0 && num2 == 0)
				{
					if (flag)
					{
						num3++;
					}
					byte _0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D = _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 switch
					{
						(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)2 => 0, 
						(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)6 => 3, 
						_ => 18, 
					};
					stack.Push(new _0023_003DzLCwSkuY_003D
					{
						_0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D = b,
						_0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D = _0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D,
						_0023_003Dz5c1WpgJ9cnNwCb1nD_0024CWgTR87wBp = flag
					});
				}
				else if (num == 0)
				{
					num2++;
				}
				break;
			}
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22:
				if (num > 0)
				{
					num--;
				}
				else if (num3 != 0)
				{
					num2 = 0;
					while (!stack.Peek()._0023_003Dz5c1WpgJ9cnNwCb1nD_0024CWgTR87wBp)
					{
						stack.Pop();
					}
					stack.Pop();
					num3--;
				}
				_0023_003Dzok56giLKxWwG[i] = stack.Peek()._0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
				break;
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)7:
				if (num <= 0)
				{
					if (num2 > 0)
					{
						num2--;
					}
					else if (!stack.Peek()._0023_003Dz5c1WpgJ9cnNwCb1nD_0024CWgTR87wBp && stack.Count > 1)
					{
						stack.Pop();
					}
				}
				break;
			case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)15:
				num2 = 0;
				num = 0;
				num3 = 0;
				stack.Clear();
				_0023_003Dzok56giLKxWwG[i] = _0023_003DzfNi7d4A_003D;
				break;
			default:
				_0023_003Dzok56giLKxWwG[i] = stack.Peek()._0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
				if (stack.Peek()._0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D != 18)
				{
					_0023_003DzTLd6lkE_003D[i] = stack.Peek()._0023_003Dzze39Kqbb9XTCE7OBE1OmWzk_003D;
				}
				break;
			}
		}
	}

	private static void _0023_003Dzk_0024VkoJFYsLOb(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D)
	{
		for (int i = 0; i < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; i++)
		{
			byte num = _0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i];
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = ((i == 0) ? _0023_003DzElrdNLU_003D._0023_003DzfaEGzjs_003D : ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i - 1]));
			if (num == 13)
			{
				bool flag = _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22;
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i] = (byte)(flag ? ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)18) : _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2);
			}
		}
		for (int j = 0; j < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; j++)
		{
			if (_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[j] != 8)
			{
				continue;
			}
			for (int num2 = j - 1; num2 >= 0; num2--)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num2];
				if ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)4 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0) && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)4)
				{
					_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[j] = 11;
					break;
				}
			}
		}
		for (int k = 0; k < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; k++)
		{
			if (_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[k] == 4)
			{
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[k] = 3;
			}
		}
		for (int l = 1; l < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D - 1; l++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[l];
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D5 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[l - 1];
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D6 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[l + 1];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)9 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D5 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D6 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
			{
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[l] = 8;
			}
			else if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)12 && ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D5 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D6 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8) || (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D5 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D6 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11)))
			{
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[l] = (byte)_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D5;
			}
		}
		_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D[] _0023_003Dz49YJNP0_003D = new _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D[1] { (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)10 };
		for (int m = 0; m < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; m++)
		{
			if (_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[m] == 10)
			{
				int num3 = m;
				int num4 = _0023_003DzElrdNLU_003D._0023_003DzuDxyNb0hPJXg(num3, _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D, _0023_003Dz49YJNP0_003D);
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D7 = ((num3 > 0) ? ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num3 - 1]) : _0023_003DzElrdNLU_003D._0023_003DzfaEGzjs_003D);
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D7 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
				{
					_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D7 = ((num4 < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D) ? ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num4]) : _0023_003DzElrdNLU_003D._0023_003DzuZGRsz8_003D);
				}
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D7 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
				{
					_0023_003DzElrdNLU_003D._0023_003Dzi_0024FeqCTYN6Xe(num3, num4, (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8);
				}
				m = num4;
			}
		}
		for (int n = 0; n < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; n++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D8 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[n];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D8 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)10 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D8 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)9 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D8 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)12)
			{
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[n] = 18;
			}
		}
		for (int num5 = 0; num5 < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; num5++)
		{
			if (_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num5] != 8)
			{
				continue;
			}
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D9 = _0023_003DzElrdNLU_003D._0023_003DzfaEGzjs_003D;
			for (int num6 = num5 - 1; num6 >= 0; num6--)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D10 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num6];
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D10 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D10 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D10 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)4)
				{
					_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D9 = _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D10;
					break;
				}
			}
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D9 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0)
			{
				_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num5] = 0;
			}
		}
	}

	private static void _0023_003Dz_UpA7MSqRfpD29GnJw_003D_003D(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D)
	{
		_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D[] _0023_003Dz49YJNP0_003D = new _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D[8]
		{
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)15,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)16,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)17,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)18,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21,
			(_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22
		};
		for (int i = 0; i < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)15 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)16 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)17 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)18 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22)
			{
				continue;
			}
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0;
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0;
			int num = i;
			int num2 = _0023_003DzElrdNLU_003D._0023_003DzuDxyNb0hPJXg(num, _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D, _0023_003Dz49YJNP0_003D);
			if (num == 0)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = _0023_003DzElrdNLU_003D._0023_003DzfaEGzjs_003D;
			}
			else
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num - 1];
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
				{
					_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3;
				}
			}
			if (num2 == _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 = _0023_003DzElrdNLU_003D._0023_003DzuZGRsz8_003D;
			}
			else
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[num2];
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
				{
					_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3;
				}
			}
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 == _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D4)
			{
				_0023_003DzElrdNLU_003D._0023_003Dzi_0024FeqCTYN6Xe(num, num2, _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3);
			}
			else
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003Dz_1qJfAk_003D = _0023_003DzM96VDmrNoJFU(_0023_003DzElrdNLU_003D._0023_003DzfNi7d4A_003D);
				_0023_003DzElrdNLU_003D._0023_003Dzi_0024FeqCTYN6Xe(num, num2, _0023_003Dz_1qJfAk_003D);
			}
			i = num2;
		}
	}

	private static void _0023_003Dz7npafs_syBj9(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D)
	{
		byte _0023_003DzfNi7d4A_003D = _0023_003DzElrdNLU_003D._0023_003DzfNi7d4A_003D;
		_0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp = new byte[_0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D];
		_0023_003DzsDgDEoE_003D(ref _0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp, _0023_003DzElrdNLU_003D._0023_003DzfNi7d4A_003D);
		for (int i = 0; i < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i];
			if (!_0023_003DzAUKasaC6s1v6(_0023_003DzfNi7d4A_003D))
			{
				switch (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2)
				{
				case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3:
					_0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp[i]++;
					break;
				case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8:
				case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11:
					_0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp[i] += 2;
					break;
				}
			}
			else if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)11 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)8)
			{
				_0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp[i]++;
			}
		}
	}

	private static void _0023_003DzUhr0c767OYVh(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D, ref byte[] _0023_003DzbcDOgZU_003D, ref byte[] _0023_003Dz_fO_GN32YR2o)
	{
		for (int i = 0; i < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; i++)
		{
			int num = _0023_003DzElrdNLU_003D._0023_003DznAsnXqw_003D[i];
			_0023_003DzbcDOgZU_003D[num] = _0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i];
			_0023_003Dz_fO_GN32YR2o[num] = _0023_003DzElrdNLU_003D._0023_003Dz0BImzjYMysCp[i];
		}
	}

	private static int[] _0023_003DzeVlEkt7P25bn(byte _0023_003DzfNi7d4A_003D, byte[] _0023_003DzbcDOgZU_003D, byte[] _0023_003Dz_fO_GN32YR2o, int[] _0023_003Dzj0gAoj9FajAy)
	{
		return _0023_003DzW8u9dIDnmsXR(_0023_003Dz7a7pb9x25WVj(_0023_003DzfNi7d4A_003D, _0023_003DzbcDOgZU_003D, _0023_003Dz_fO_GN32YR2o, _0023_003Dzj0gAoj9FajAy), _0023_003Dzj0gAoj9FajAy);
	}

	private static void _0023_003Dz8ExEqb48Q2c6(byte[] _0023_003DzTLd6lkE_003D, out int[] _0023_003Dz6wpznLAc243i, out int[] _0023_003DzKrDS3GngDPVRlzNGIIGd2GA_003D)
	{
		int[] array = new int[_0023_003DzTLd6lkE_003D.Length];
		int[] array2 = new int[_0023_003DzTLd6lkE_003D.Length];
		for (int i = 0; i < _0023_003DzTLd6lkE_003D.Length; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzTLd6lkE_003D[i];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21)
			{
				int num = 1;
				bool flag = false;
				for (int j = i + 1; j < _0023_003DzTLd6lkE_003D.Length; j++)
				{
					switch ((_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzTLd6lkE_003D[j])
					{
					case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19:
					case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20:
					case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21:
						num++;
						continue;
					case (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22:
						num--;
						if (num != 0)
						{
							continue;
						}
						break;
					default:
						continue;
					}
					flag = true;
					array[i] = j;
					array2[j] = i;
					break;
				}
				if (!flag)
				{
					array[i] = _0023_003DzTLd6lkE_003D.Length;
				}
			}
			else
			{
				array[i] = -1;
				array2[i] = -1;
			}
		}
		_0023_003Dz6wpznLAc243i = array;
		_0023_003DzKrDS3GngDPVRlzNGIIGd2GA_003D = array2;
	}

	private static void _0023_003DzXyklhIgB70oC(ref byte[] _0023_003DzzLvmjQQ_003D)
	{
		for (int i = 0; i < _0023_003DzzLvmjQQ_003D.Length; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzzLvmjQQ_003D[i];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)1 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)5 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)2 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)6)
			{
				_0023_003DzzLvmjQQ_003D[i] = 14;
			}
		}
	}

	private static List<List<int>> _0023_003Dz2byrmSjF38d2(byte[] _0023_003Dzok56giLKxWwG)
	{
		List<int> list = new List<int>();
		List<List<int>> list2 = new List<List<int>>();
		sbyte b = -1;
		for (int i = 0; i < _0023_003Dzok56giLKxWwG.Length; i++)
		{
			if (_0023_003Dzok56giLKxWwG[i] != b)
			{
				if (b >= 0)
				{
					list2.Add(list);
					list.Clear();
				}
				b = (sbyte)_0023_003Dzok56giLKxWwG[i];
			}
			list.Add(i);
		}
		if (list.Count > 0)
		{
			list2.Add(list);
		}
		return list2;
	}

	private static int[] _0023_003DzyhfTS8E0nDL6(List<List<int>> _0023_003DzF4LX8pIgEBfy, int _0023_003Dz736ekIs_003D)
	{
		int[] array = new int[_0023_003Dz736ekIs_003D];
		for (int i = 0; i < _0023_003DzF4LX8pIgEBfy.Count; i++)
		{
			for (int j = 0; j < _0023_003DzF4LX8pIgEBfy[i].Count; j++)
			{
				int num = _0023_003DzF4LX8pIgEBfy[i][j];
				array[num] = num;
			}
		}
		return array;
	}

	private static List<_0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D> _0023_003DzeN33MdYhs3CuAoBPBSwOdvk_003D(byte _0023_003DzkYqFmLk_003D, byte[] _0023_003DzTLd6lkE_003D, byte[] _0023_003Dzok56giLKxWwG, List<List<int>> _0023_003DzF4LX8pIgEBfy, int[] _0023_003DzQgDGE9aoZk73x5_0024quA_003D_003D, int[] _0023_003DzGc6Z3t056buA, int[] _0023_003DzCpM1EpUyTF_S)
	{
		List<_0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D> list = new List<_0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D>(_0023_003DzF4LX8pIgEBfy.Count);
		foreach (List<int> item in _0023_003DzF4LX8pIgEBfy)
		{
			int num = item[0];
			if (_0023_003DzTLd6lkE_003D[num] != 22 || _0023_003DzQgDGE9aoZk73x5_0024quA_003D_003D[num] == -1)
			{
				List<int> list2 = new List<int>(item);
				int num2 = list2[list2.Count - 1];
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzTLd6lkE_003D[num2];
				bool flag = _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21;
				int num3 = _0023_003DzGc6Z3t056buA[num2];
				while (flag && num3 != _0023_003DzTLd6lkE_003D.Length)
				{
					int index = _0023_003DzCpM1EpUyTF_S[num3];
					List<int> collection = _0023_003DzF4LX8pIgEBfy[index];
					list2.AddRange(collection);
				}
				list.Add(new _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D(_0023_003DzkYqFmLk_003D, list2, _0023_003DzTLd6lkE_003D, _0023_003Dzok56giLKxWwG));
			}
		}
		return list;
	}

	private static void _0023_003Dzn22dx3GkUy5cTbIo9jamiI8_003D(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D, byte _0023_003DzkYqFmLk_003D, List<int> _0023_003DzBUIFpC4_003D, byte[] _0023_003DzbcDOgZU_003D, byte[] _0023_003Dzok56giLKxWwG)
	{
		_0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D = _0023_003DzBUIFpC4_003D.Count;
		_0023_003DzElrdNLU_003D._0023_003DznAsnXqw_003D = _0023_003DzBUIFpC4_003D.ToArray();
		_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D = new byte[_0023_003DzBUIFpC4_003D.Count];
		for (int i = 0; i < _0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D; i++)
		{
			_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i] = _0023_003DzbcDOgZU_003D[_0023_003DzBUIFpC4_003D[i]];
		}
		byte val = (_0023_003DzElrdNLU_003D._0023_003DzfNi7d4A_003D = _0023_003Dzok56giLKxWwG[_0023_003DzBUIFpC4_003D[0]]);
		int num = _0023_003DzBUIFpC4_003D[0] - 1;
		byte val2 = ((num >= 0) ? _0023_003Dzok56giLKxWwG[num] : _0023_003DzkYqFmLk_003D);
		_0023_003DzElrdNLU_003D._0023_003DzfaEGzjs_003D = _0023_003DzM96VDmrNoJFU(Math.Max(val, val2));
		_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[_0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D - 1];
		int num2 = _0023_003DzBUIFpC4_003D[_0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D - 1];
		byte val3 = _0023_003Dzok56giLKxWwG[num2];
		byte val4 = ((_0023_003DzBUIFpC4_003D[_0023_003DzElrdNLU_003D._0023_003Dz736ekIs_003D - 1] + 1 < _0023_003DzbcDOgZU_003D.Length && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)22) ? _0023_003Dzok56giLKxWwG[num2] : _0023_003DzkYqFmLk_003D);
		_0023_003DzElrdNLU_003D._0023_003DzuZGRsz8_003D = _0023_003DzM96VDmrNoJFU(Math.Max(val3, val4));
	}

	private static void _0023_003DzsDgDEoE_003D(ref byte[] _0023_003Dzok56giLKxWwG, byte _0023_003Dzw9DKhIc_003D)
	{
		for (int i = 0; i < _0023_003Dzok56giLKxWwG.Length; i++)
		{
			_0023_003Dzok56giLKxWwG[i] = _0023_003Dzw9DKhIc_003D;
		}
	}

	private static int _0023_003DzuDxyNb0hPJXg(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D, int _0023_003DzyzK8swU_003D, int _0023_003DzLMo0v2w_003D, _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D[] _0023_003Dz49YJNP0_003D)
	{
		while (_0023_003DzyzK8swU_003D < _0023_003DzLMo0v2w_003D)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[_0023_003DzyzK8swU_003D];
			int num = 0;
			while (true)
			{
				if (num < _0023_003Dz49YJNP0_003D.Length)
				{
					if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == _0023_003Dz49YJNP0_003D[num])
					{
						break;
					}
					num++;
					continue;
				}
				return _0023_003DzyzK8swU_003D;
			}
			_0023_003DzyzK8swU_003D++;
		}
		return _0023_003DzLMo0v2w_003D;
	}

	private static void _0023_003Dzi_0024FeqCTYN6Xe(this _0023_003DzZd1cUev4i4EQfrN8bpAh3_Q_003D _0023_003DzElrdNLU_003D, int _0023_003DzAqOpw0w_003D, int _0023_003DzLMo0v2w_003D, _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003Dz_1qJfAk_003D)
	{
		for (int i = _0023_003DzAqOpw0w_003D; i < _0023_003DzLMo0v2w_003D; i++)
		{
			_0023_003DzElrdNLU_003D._0023_003DzTLd6lkE_003D[i] = (byte)_0023_003Dz_1qJfAk_003D;
		}
	}

	private static int _0023_003Dz_0024nxsOfnpglkJ(int _0023_003DzGcl_0024E9o_003D)
	{
		if (!_0023_003DzAUKasaC6s1v6(_0023_003DzGcl_0024E9o_003D))
		{
			return _0023_003DzGcl_0024E9o_003D + 1;
		}
		return _0023_003DzGcl_0024E9o_003D + 2;
	}

	private static int _0023_003Dz8FVCzsQa01Lx(int _0023_003DzGcl_0024E9o_003D)
	{
		if (_0023_003DzAUKasaC6s1v6(_0023_003DzGcl_0024E9o_003D))
		{
			return _0023_003DzGcl_0024E9o_003D + 1;
		}
		return _0023_003DzGcl_0024E9o_003D + 2;
	}

	private static bool _0023_003DzAUKasaC6s1v6(int _0023_003DzoMNiNRw_003D)
	{
		return (_0023_003DzoMNiNRw_003D & 1) != 0;
	}

	private static _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzM96VDmrNoJFU(byte _0023_003DzfNi7d4A_003D)
	{
		if ((_0023_003DzfNi7d4A_003D & 1) != 0)
		{
			return (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)3;
		}
		return (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)0;
	}

	private static byte[] _0023_003Dz7a7pb9x25WVj(byte _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D, byte[] _0023_003DzbcDOgZU_003D, byte[] _0023_003Dz_fO_GN32YR2o, int[] _0023_003Dzj0gAoj9FajAy)
	{
		for (int i = 0; i < _0023_003Dz_fO_GN32YR2o.Length; i++)
		{
			_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzbcDOgZU_003D[i];
			if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)16 || _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 == (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)15)
			{
				_0023_003Dz_fO_GN32YR2o[i] = _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
			}
			for (int num = i - 1; num >= 0; num--)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzbcDOgZU_003D[num];
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D2 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21)
				{
					break;
				}
				_0023_003Dz_fO_GN32YR2o[num] = _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
			}
		}
		int num2 = 0;
		foreach (int num3 in _0023_003Dzj0gAoj9FajAy)
		{
			for (int num4 = num3 - 1; num4 >= num2; num4--)
			{
				_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 = (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)_0023_003DzbcDOgZU_003D[num4];
				if (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)19 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)20 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21 && _0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D3 != (_0023_003DzXAO2ZNAQMHwhyBngLQ_003D_003D)21)
				{
					break;
				}
				_0023_003Dz_fO_GN32YR2o[num4] = _0023_003Dz_0024i80RONcts7nnWKxkcAzYGo_003D;
			}
			num2 = num3;
		}
		return _0023_003Dz_fO_GN32YR2o;
	}

	private static int[] _0023_003DzW8u9dIDnmsXR(byte[] _0023_003Dzok56giLKxWwG, int[] _0023_003Dzj0gAoj9FajAy)
	{
		int[] array = new int[_0023_003Dzok56giLKxWwG.Length];
		int num = 0;
		foreach (int num2 in _0023_003Dzj0gAoj9FajAy)
		{
			byte[] array2 = new byte[num2 - num];
			Array.Copy(_0023_003Dzok56giLKxWwG, num, array2, 0, array2.Length);
			int[] array3 = _0023_003DzQSxHcMRRkuX0Xx858msD7n8_003D(array2);
			for (int j = 0; j < array3.Length; j++)
			{
				array[num + j] = array3[j] + num;
			}
			num = num2;
		}
		return array;
	}

	private static int[] _0023_003DzQSxHcMRRkuX0Xx858msD7n8_003D(byte[] _0023_003Dzok56giLKxWwG)
	{
		int num = _0023_003Dzok56giLKxWwG.Length;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = i;
		}
		byte b = 0;
		byte b2 = 127;
		foreach (byte b3 in _0023_003Dzok56giLKxWwG)
		{
			if (b3 > b)
			{
				b = b3;
			}
			if (_0023_003DzAUKasaC6s1v6(b3) && b3 < b2)
			{
				b2 = b3;
			}
		}
		for (int num2 = b; num2 >= b2; num2--)
		{
			for (int k = 0; k < num; k++)
			{
				if (_0023_003Dzok56giLKxWwG[k] >= num2)
				{
					int num3 = k;
					int l;
					for (l = k + 1; l < num && _0023_003Dzok56giLKxWwG[l] >= num2; l++)
					{
					}
					int num4 = num3;
					int num5 = l - 1;
					while (num4 < num5)
					{
						int num6 = array[num4];
						array[num4] = array[num5];
						array[num5] = num6;
						num4++;
						num5--;
					}
					k = l;
				}
			}
		}
		return array;
	}

	private static string _0023_003Dz024SL4JmtVns(string _0023_003Dz0EsKsC8_003D, int[] _0023_003DzZ2AJhLg_003D)
	{
		StringBuilder stringBuilder = new StringBuilder(_0023_003Dz0EsKsC8_003D.Length);
		for (int i = 0; i < _0023_003DzZ2AJhLg_003D.Length; i++)
		{
			stringBuilder.Append(_0023_003Dz0EsKsC8_003D[_0023_003DzZ2AJhLg_003D[i]]);
		}
		return stringBuilder.ToString();
	}
}
